using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PnlPet : PanelBase
{
	public static PnlPet inst;

	[SerializeField] protected Transform	_Pivot3D;
	[SerializeField] protected UILabel		_Name;
	[SerializeField] protected UILabel		_NeedLvl;
	[SerializeField] protected UILabel		_Stamina;
	[SerializeField] protected UILabel		_FirstMulti;
	[SerializeField] protected GameObject   _BtnSelect;
	[SerializeField] protected GameObject   _BtnSelected;
	[SerializeField] protected GameObject   _BtnBuy;
	[SerializeField] protected GameObject   _BtnSelectCoin;
	[SerializeField] protected GameObject   _BtnSelectGold;
	[SerializeField] protected UILabel      _TxtPriceCoin;
	[SerializeField] protected UILabel      _TxtPriceGold;
	[SerializeField] protected GameObject	_ListGrper;

	protected int	mSelectedIdx = -1;

	protected	Animation	mAniPet	= null;
	protected	Transform	mTrPet	= null;

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
		GameObject goPet = Instantiate(Resources.Load("Prefabs/Character/Pet/petSimple")) as GameObject;
		mTrPet					= goPet.transform;
		mTrPet.parent			= _Pivot3D;
		mTrPet.localPosition	= Vector3.zero;
		mTrPet.localRotation	= Quaternion.identity;
		mTrPet.localScale		= Vector3.one;

		mAniPet = goPet.GetComponent<Animation>();
		mAniPet.Play("petStandIdle");
		
		Util.SendMessageRecursively(_ListGrper, "initUI", 1);
	}

	private void Update()
	{
		if(mAniPet == null)
			return;

		if(!mAniPet.isPlaying)
		{
			mAniPet.Play("petStandIdle");
			if(Util.IsInPercent(50))
				mAniPet.CrossFadeQueued("petStandIdle", 0.1f);
			mAniPet.CrossFadeQueued("petRest" + Util.IntRandom(0, 5).ToString(), 0.1f);
			mAniPet.CrossFadeQueued("petStandIdle", 0.1f);
		}
	}

	void onBtnItem(int _idx)
	{
		if(mSelectedIdx == _idx)
			return;

		mSelectedIdx = _idx;
		updateUI();
	}

	void updateUI()
	{
		PetInfo pi			= GD.dtPetInfos[mSelectedIdx];
		_Name.text			= pi.data.name;
		_NeedLvl.text		= (pi.data.needLvl + 1).ToString();
		_Stamina.text		= pi.data.hp.ToString();
		_FirstMulti.text	= pi.data.baseMulti.ToString() + "X";

		bool isSelected = GD.dtPetIdx == mSelectedIdx;
		_BtnBuy.SetActive(!pi.bought);
		_BtnSelect.SetActive(pi.bought && !isSelected);
		_BtnSelected.SetActive(pi.bought && isSelected);

		if(!pi.bought)
		{
			bool isCoin = (pi.data.price.kind == PriceKind.coin);
			_BtnSelectCoin.SetActive(isCoin);
			_BtnSelectGold.SetActive(!isCoin);
			_TxtPriceCoin.text = pi.data.price.price.ToString();
			_TxtPriceGold.text = pi.data.price.price.ToString();
		}

		mTrPet.GetChild(0).GetComponent<SkinnedMeshRenderer>().material.mainTexture = GameMgr.inst._PetTx[mSelectedIdx];
		mTrPet.GetChild(1).GetComponent<SkinnedMeshRenderer>().material.mainTexture = GameMgr.inst._PetTx[mSelectedIdx];
	}

	public void OnClickBtn()
	{
		PetInfo pi  = GD.dtPetInfos[mSelectedIdx];
		if(pi.bought)
		{
			GD.dtPetIdx = mSelectedIdx;
			updateUI();
			Util.SendMessageRecursively(_ListGrper, "updateUI", 1);
			Util.PlaySound("sfxTap");
			GameMgr.inst.UpdateCharacter();
		}
		else
		{
			DlgOkCancel.OpenDlg(onYesPurchase, null, Lang.Get("msgConfirmBuy"));
		}
	}

	void onYesPurchase(object _userData)
	{
		PetInfo pi	= GD.dtPetInfos[mSelectedIdx];
		if(pi.data.price.kind == PriceKind.coin)
		{
			if(GD.dtCoins < pi.data.price.price)
			{
				DlgOkCancel.OpenDlg(null, null, ST.getCorrectStr(ST.NOCOIN));
				return;
			}
			else
			{
				GD.dtCoins -= pi.data.price.price;
			}
		}
		else if(pi.data.price.kind == PriceKind.gold)
		{
			if(GD.dtGems < pi.data.price.price)
			{
				DlgOkCancel.OpenDlg(null, null, ST.getCorrectStr(ST.NOGEM));
				return;
			}
			else
			{
				GD.dtGems -= pi.data.price.price;
			}
		}

		pi.bought = true;
		GD.dtPetIdx = mSelectedIdx;
		updateUI();
		GameMgr.inst.UpdateCharacter();
		Util.SendMessageRecursively(_ListGrper, "updateUI", 1);
		DlgMe.inst.UpdateCurrencyInfo();
		Util.PlaySound("sfxDropCoin");
		PlayerEventMgr.inst.OnEvent(PlayerEventKind.buyPet);
	}
}
