using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PnlStun : PanelBase
{
	public static PnlStun inst;

	[SerializeField] protected Transform	_Pivot3D;
	[SerializeField] protected UILabel		_Name;
	[SerializeField] protected UILabel		_NeedLvl;
	[SerializeField] protected UILabel		_Cheer;
	[SerializeField] protected UILabel		_InputTime;
	[SerializeField] protected GameObject	_BtnSelect;
	[SerializeField] protected GameObject	_BtnSelected;
	[SerializeField] protected GameObject	_BtnBuy;
	[SerializeField] protected GameObject	_BtnSelectCoin;
	[SerializeField] protected GameObject	_BtnSelectGold;
	[SerializeField] protected UILabel		_TxtPriceCoin;
	[SerializeField] protected UILabel		_TxtPriceGold;
	[SerializeField] protected GameObject[]	_Difficulty;
	[SerializeField] protected GameObject	_ListGrper;

	protected int		mSelectedIdx	= -1;
	protected Animation	mAniPet			= null;
	protected Animation	mAniHero		= null;

	protected GameObject mGoPet		= null;
	protected GameObject mGoHero	= null;
	
	protected void Awake()
	{
		inst = this;
	}

	void OnDestory()
	{
		inst = null;
	}

	override protected void onClosedDlg()
	{

	}

	override public void Init(DlgBase _dlgParent)
	{
		base.Init(_dlgParent);

		//create pet
		update3DModels();

		Util.SendMessageRecursively(_ListGrper, "initUI", 1);
	}

	private void update3DModels()
	{
		if (mGoPet != null)
			Destroy(mGoPet);

		if(mGoHero != null)
			Destroy(mGoHero);

		mGoPet = Instantiate(Resources.Load("Prefabs/Character/Pet/petSimple")) as GameObject;
		mGoPet.transform.parent          = _Pivot3D;
		mGoPet.transform.localPosition   = Vector3.zero;
		mGoPet.transform.localRotation   = Quaternion.identity;
		mGoPet.transform.localScale      = Vector3.one;
		mGoPet.transform.GetChild(0).GetComponent<SkinnedMeshRenderer>().material.mainTexture = GameMgr.inst._PetTx[GD.dtPetIdx];
		mGoPet.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material.mainTexture = GameMgr.inst._PetTx[GD.dtPetIdx];
		mAniPet = mGoPet.GetComponent<Animation>();

		//create avatar
		mGoHero   = Instantiate(Resources.Load("Prefabs/Character/Hero/Hero" + (GD.dtHeroIdx).ToString())) as GameObject;
		mGoHero.transform.parent         = mGoPet.GetComponent<Player>()._PetPelvise;
		mGoHero.transform.localPosition  = Vector3.zero;
		mGoHero.transform.localRotation  = Quaternion.identity;
		mGoHero.transform.localScale     = Vector3.one;
		for(int i = 0; i < GD.dtHeroInfos[GD.dtHeroIdx].data.clothes.Length; i++)
			mGoHero.transform.GetChild(i).gameObject.SetActive(i == GD.dtHeroInfos[GD.dtHeroIdx].clothIdx);

		mAniHero = mGoHero.GetComponent<Animation>();
	}
	private void Update()
	{
		if (mAniHero == null)
			return;

		if (!mAniPet.isPlaying)
		{
			mAniPet.Play("petJumpSkill");
			mAniHero.Play("heroStunt" + (mSelectedIdx).ToString());
		}
	}

	void onBtnItem(int _idx)
	{
		if (mSelectedIdx == _idx)
			return;

		mAniPet.Stop();
		mAniHero.Stop();

		mSelectedIdx = _idx;
		updateUI();
	}

	void updateUI()
	{
		StuntInfo si = GD.dtStuntInfos[mSelectedIdx];
		_Name.text		= si.data.name;
		_NeedLvl.text	= (si.data.needLvl + 1).ToString();
		_Cheer.text		= si.data.cheer.ToString();
		_InputTime.text	= si.data.inputTm.ToString() + "s";
		
		bool isSelected = GD.dtStuntIdxs[si.data.difficulty] == mSelectedIdx;
		_BtnBuy.SetActive(!si.bought);
		_BtnSelect.SetActive(si.bought && !isSelected);
		_BtnSelected.SetActive(si.bought && isSelected);

		if(!si.bought)
		{
			bool isCoin = (si.data.price.kind == PriceKind.coin);
			_BtnSelectCoin.SetActive(isCoin);
			_BtnSelectGold.SetActive(!isCoin);
			_TxtPriceCoin.text = si.data.price.price.ToString();
			_TxtPriceGold.text = si.data.price.price.ToString();
		}
				
		for (int i = 0; i <= MD.maxDifficulty; i ++)
			_Difficulty[i].SetActive(si.data.difficulty == i);
	}
	private void OnEnable()
	{
		if (mSelectedIdx != -1)
			update3DModels();
	}
	public void OnClickBtn()
	{
		StuntInfo si = GD.dtStuntInfos[mSelectedIdx];
		if(si.bought)
		{
			GD.dtStuntIdxs[si.data.difficulty] = mSelectedIdx;
			updateUI();
			Util.SendMessageRecursively(_ListGrper, "updateUI", 1);
			Util.PlaySound("sfxTap");
		}
		else
		{
			DlgOkCancel.OpenDlg(onYesPurchase, null, Lang.Get("msgConfirmBuy"));
		}
	}

	void onYesPurchase(object _userData)
	{
		StuntInfo si = GD.dtStuntInfos[mSelectedIdx];
		if(si.data.price.kind == PriceKind.coin)
		{
			if(GD.dtCoins < si.data.price.price)
			{ 
				DlgOkCancel.OpenDlg(null, null, ST.getCorrectStr(ST.NOCOIN));
				return;
			}
			else
			{
				GD.dtCoins -= si.data.price.price;
			}
		}
		else if(si.data.price.kind == PriceKind.gold)
		{
			if(GD.dtGems < si.data.price.price)
			{ 
				DlgOkCancel.OpenDlg(null, null, ST.getCorrectStr(ST.NOGEM));
				return;
			}
			else
			{
				GD.dtGems -= si.data.price.price;
			}
		}

		si.bought = true;
		GD.dtStuntIdxs[si.data.difficulty] = mSelectedIdx;
		updateUI();
		Util.SendMessageRecursively(_ListGrper, "updateUI", 1);
		DlgMe.inst.UpdateCurrencyInfo();
		Util.PlaySound("sfxDropCoin");
		PlayerEventMgr.inst.OnEvent(PlayerEventKind.buyStunt);
	}
}
