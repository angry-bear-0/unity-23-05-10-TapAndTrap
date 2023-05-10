using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PnlHero : PanelBase
{
	public static PnlHero inst;

	[SerializeField] protected Transform	_Pivot3D;
	[SerializeField] protected UILabel		_Name;
	[SerializeField] protected GameObject[]	_ClothGrps;
	[SerializeField] protected GameObject   _BtnSelect;
	[SerializeField] protected GameObject   _BtnSelected;
	[SerializeField] protected GameObject   _BtnBuy;
	[SerializeField] protected GameObject   _BtnSelectCoin;
	[SerializeField] protected GameObject   _BtnSelectGold;
	[SerializeField] protected UILabel      _TxtPriceCoin;
	[SerializeField] protected UILabel      _TxtPriceGold;
	[SerializeField] protected GameObject   _ListGrper;

	protected int   mSelectedIdx        = -1;
	protected int   mClotheIdx			= 0;

	protected GameObject	mAvatar;
	protected Animation		mAniHero;

	public int  curAvatar	{ get { return mSelectedIdx;} }
	public int  curCloth	{ get { return mClotheIdx;} }

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

		Util.SendMessageRecursively(_ListGrper, "initUI", 1);
	}
	void onBtnItem(int _idx)
	{
		if(mSelectedIdx == _idx)
			return;

		mSelectedIdx = _idx;
		mClotheIdx = -1;
		updateContentUI();
	}
	void updateContentUI()
	{
		HeroInfo ai = GD.dtHeroInfos[mSelectedIdx];
		_Name.text	= ai.data.name;

		for(int i = 0; i < MD.maxClothes; i++)
			_ClothGrps[i].SetActive((i+1) == ai.data.clothes.Length);

		refreshAvatar();
		Util.SendMessageRecursively(_ClothGrps[GD.dtHeroInfos[mSelectedIdx].data.clothes.Length-1], "updateUI", 1);
	}
	void onBtnCloth(int _idx)
	{
		if(mClotheIdx == _idx)
			return;

		mClotheIdx = _idx;
		refreshCloth();
		updateButton();
	}
	void refreshAvatar()
	{
		if(mAvatar != null)
			Destroy(mAvatar);

		mAvatar = (GameObject)Instantiate(Resources.Load("Prefabs/Character/Hero/Hero" + (mSelectedIdx).ToString()));
		mAvatar.transform.parent		= _Pivot3D;
		mAvatar.transform.localPosition	= Vector3.zero;
		mAvatar.transform.localScale	= Vector3.one;
		mAvatar.transform.localRotation	= Quaternion.identity;

		mAniHero = mAvatar.GetComponent<Animation>();
	}
	void refreshCloth()
	{
		for(int i = 0; i < GD.dtHeroInfos[mSelectedIdx].data.clothes.Length; i++)
			mAvatar.transform.GetChild(i).gameObject.SetActive(i == mClotheIdx);
	}

	void updatePurchasedInfo()
	{
		Util.SendMessageRecursively(_ClothGrps[GD.dtHeroInfos[mSelectedIdx].data.clothes.Length-1], "updateUI", 1);
		updateAvatarList();
		updateButton();
	}
	public void OnClickBtn()
	{
		HeroInfo ai  = GD.dtHeroInfos[mSelectedIdx];
		if(ai.bought[mClotheIdx])
		{
			GD.dtHeroIdx	= mSelectedIdx;
			ai.clothIdx		= mClotheIdx;
			updatePurchasedInfo();
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
		HeroInfo ai	= GD.dtHeroInfos[mSelectedIdx];
		PriceBase price	= ai.data.clothes[mClotheIdx].price;
		if(price.kind == PriceKind.coin)
		{
			if(GD.dtCoins < price.price)
			{
				DlgOkCancel.OpenDlg(null, null, ST.getCorrectStr(ST.NOCOIN));
				return;
			}
			else
			{
				GD.dtCoins -= price.price;
			}
		}
		else if(price.kind == PriceKind.gold)
		{
			if(GD.dtGems < price.price)
			{
				DlgOkCancel.OpenDlg(null, null, ST.getCorrectStr(ST.NOGEM));
				return;
			}
			else
			{
				GD.dtGems -= price.price;
			}
		}

		GD.dtHeroIdx			= mSelectedIdx;
		ai.clothIdx				= mClotheIdx;
		ai.bought[mClotheIdx]	= true;
		updatePurchasedInfo();
		GameMgr.inst.UpdateCharacter();
		DlgMe.inst.UpdateCurrencyInfo();
		Util.PlaySound("sfxDropCoin");
		PlayerEventMgr.inst.OnEvent(PlayerEventKind.buyAvatar);
	}
	void updateAvatarList()
	{
		Util.SendMessageRecursively(_ListGrper, "updateUI", 1);
	}

	void updateButton()
	{
		HeroInfo ai	= GD.dtHeroInfos[mSelectedIdx];

		bool isSelected = ai.clothIdx == mClotheIdx && mSelectedIdx == GD.dtHeroIdx;
		_BtnBuy.SetActive(!ai.bought[mClotheIdx]);
		_BtnSelect.SetActive(ai.bought[mClotheIdx] && !isSelected);
		_BtnSelected.SetActive(ai.bought[mClotheIdx] && isSelected);

		if(!ai.bought[mClotheIdx])
		{
			PriceBase price = ai.data.clothes[mClotheIdx].price;
			bool isCoin = (price.kind == PriceKind.coin);
			_BtnSelectCoin.SetActive(isCoin);
			_BtnSelectGold.SetActive(!isCoin);
			_TxtPriceCoin.text = price.price.ToString();
			_TxtPriceGold.text = price.price.ToString();
		}
	}

	private void Update()
	{
		if(mAniHero == null)
			return;

		if(!mAniHero.isPlaying)
		{
			mAniHero.Play("heroIdle");
			if(Util.IsInPercent(50))
				mAniHero.CrossFadeQueued("heroIdle", 0.1f);
			mAniHero.CrossFadeQueued("heroRest" + Util.IntRandom(0, 5).ToString(), 0.1f);
			mAniHero.CrossFadeQueued("heroIdle", 0.25f);
		}
	}
}
