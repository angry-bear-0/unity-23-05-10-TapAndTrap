using System.Collections;
using UnityEngine;

public class AvtGame : AvtBase
{							
	static private AvtGame	mInst = null;
	static public AvtGame	instance { get { return mInst; } }

	//Score and Coin Variables
	[SerializeField] protected   UILabel	_CurCoinCnt;
    [SerializeField] protected   UILabel	_CurScore;

	//SfSkin variables
	public GameObject		_GrpShield;
	public UILabel			_TxtShieldCnt;
	public UISprite			_SprShieldCoolTm;
	public UISprite			_SprShieldDisable;
	public GameObject		_SprShieldIcon;

	private bool			mDieAniState		= false;
	private float			mShieldTm			= 0;
	private float			mShieldCoolTm		= 0;
	private float			mCoolDivideTm		= 0;
	private Object			mPfEatArrowEff;

	//Item2X Varials 
	public	UISprite		_frm2x;
	public	GameObject		_ico2X;
	public float			mDoubleCoinTm				= 0f;

	//Mgt Varials
	public	UISprite		_frmMgt;
	public	GameObject		_icoMgt;
	private float			mMgtTm				= 0f;

	//Balloon varialbles	
	public	UISprite		_frmBll;
	public	GameObject		_icoBll;
	private float			mBalloonTm;

	//fly(Gliding) varialbles
	public UISprite			_frmFly;
	public GameObject		_icoFly;
	private float			mFlyTm;

	[SerializeField] protected  UILabel			_TxtMulPoint;
	[SerializeField] protected  UILabel			_TxtMulLV;
	[SerializeField] protected  UISlider		_SldBarMult;

	//ScoreBooster
	public GameObject		_icoScoreBooster;
	
	//HeadStart
	public GameObject		_icoHeadStart;

	//Start Game time
	private float			mGameStartTm = 0;

	static public void Create(bool _needLoading, bool _needPlayer, bool _needUI3DCamera, bool _needBackground)
    {
        GameObject	obj		= Instantiate(Resources.Load("Prefabs/Avt/pfAvtGame")) as GameObject;
        Transform	trans	= obj.GetComponent<Transform>();
		
        trans.parent		= GameObject.Find("CameraUI").GetComponent<Transform>();
        trans.localPosition = Vector3.zero;
        trans.localRotation = Quaternion.identity;
        trans.localScale	= Vector3.one;
        AvtGame script		= obj.GetComponent<AvtGame>();

        script.Active(_needLoading, _needPlayer, _needUI3DCamera, _needBackground);
        script.init();
    }
    void init()
    {
		mGameStartTm = Time.time;
		StartCoroutine(StartRunAction());
        GD.InitGame();
		PlayerEventMgr.inst.OnInit();
		RoadMaker.mInst.InitGame();
		mPfEatArrowEff = Resources.Load("Prefabs/Item/pfItemEatEffect");
		_SprShieldCoolTm.fillAmount = 0f;
		mDieAniState = false;

		mGameMgr._InputHome.SetActive(false);
		
		if(GD.dtShieldCnt <= 0)
			_SprShieldIcon.SetActive(false);

		_SldBarMult.value = (float)GD.curMultiplierPoint / (float)GD.maxMultiplierPoint;
		_TxtMulLV.text = "X" + GD.multiplier.ToString();
		_TxtMulPoint.text = GD.curMultiplierPoint.ToString() + "/" + GD.maxMultiplierPoint.ToString();
	}
	protected void Awake()
	{
		mInst = this;
    }
	void Start()
	{

	}
    void Update()
    {
		if (GD.dead) 
		{
			if(!mDieAniState)
			{
				mDieAniState = true;
				GameMgr.cameraMgr.CamAniPlay(CamMgr.Action.die);
				StartCoroutine(StartDropCoroutine());
			}
        }
		else
		{
			mDieAniState = false;
	        if (Input.GetKeyUp(KeyCode.Escape) && !GD.dead)
			{
				if (GameMgr.gameState == GameState.pause)
				{
					DlgBase.DoEscapePress();
					Resume();
				}
				else if (!DlgBase.DoEscapePress())
				{
					Pause();
				}
			}
        }
        if (GameMgr.gameState != GameState.pause)
        {
            updateGameUI();
        }
	}
	protected virtual void FixedUpdate()
	{
		if (Time.frameCount % 40 == 0)
			System.GC.Collect();
	}
    public void OnBtnClicked(GameObject _obj)
    {
		if(GD.dead)
			return;
        if (_obj.gameObject.name == "btnPause" )
        {
			if(GameMgr.gameState != GameState.pause)
			{
                Pause();
			}
		}
		if(_obj.gameObject.name == "icoSfSkin")
		{
			if(GD.dtShieldCnt > 0)
			{
				UseItemShield();
			}
		}
		if(_obj.gameObject.name == "icoHeadStart")
		{
			if(GD.dtHeadSartCnt > 0)
			{
				GD.dtHeadSartCnt --;
				GameMgr.player.Fly();
                GD.Save();
				UseItemFly();
				PlayerEventMgr.inst.OnEvent(PlayerEventKind.headStart);
			}
		}
		if(_obj.gameObject.name == "icoScoreBooster")
		{
			if(GD.dtScoreBoosterCnt > 0)
			{
				UseItemScBst();
			}
		}
	}
	public void UseItemShield()
	{
		if (GD.dtShieldCnt <= 0)
			return;
		if(mShieldCoolTm > 0f)
			return;
		GD.usingShield = true;
		GD.dtShieldCnt--;
		PlayerEventMgr.inst.OnEvent(PlayerEventKind.shield);
		_SprShieldIcon.SetActive(true);
		_SprShieldCoolTm.fillAmount = 1f; 
		mShieldTm = GD.dtUpgradeShield.val;
		mCoolDivideTm = mShieldTm;
		GameMgr.player.ActiveShield(true);
		activeShieldBtn(false);
        GD.Save();
	}
	public void activeShieldBtn(bool _state)
	{
		_GrpShield.GetComponent<BoxCollider>().enabled = _state;
	}
	public void msgEraseSfSkin()
	{
		mShieldTm = 0;
		_SprShieldCoolTm.fillAmount = 0;
		GameMgr.player.ActiveShield(false);
		_SprShieldIcon.SetActive(false);
		disableSfSkinBtn();
	}
	private void disableSfSkinBtn()
	{
		if(GD.dtShieldCnt > 0)
		{
			mShieldCoolTm = GD.dtUpgradeShieldCT.val;
			_SprShieldDisable.fillAmount = 1;
		}
	}
	public void UseItemSfSkinCntUp()
	{
		++GD.dtShieldCnt;
		Instantiate(mPfEatArrowEff);
		GD.Save();
	}
	public void UseItem2X()
	{
		_ico2X.SetActive(true);
		_frm2x.fillAmount = 1f;
		mDoubleCoinTm = GD.dtUpgradeDoubleCoin.val;

		Instantiate(mPfEatArrowEff);
	}
	public void UseItemMgt()
	{
		_icoMgt.SetActive(true);
		_frmMgt.fillAmount = 1f;
		mMgtTm = GD.dtUpgradeMagnet.val;
		GD.usingMagnet = true;
	}
	public void TakeCoin()
	{
	}
	public void UseItemBll()
	{
		_icoBll.SetActive(true);
		_frmBll.fillAmount = 1f;
		mBalloonTm = GD.dtUpgradeBalloon.val;
	}
	public void UseItemFly()
	{
		_icoFly.SetActive(true);
		_frmFly.fillAmount = 1f;
		mFlyTm = GD.dtUpgradeFly.val;
	}
	public void UseItemScBst()
	{
		GD.dtScoreBoosterCnt --;
		if(_icoScoreBooster.activeSelf)
			_icoScoreBooster.SetActive(false);
		GD.multiplier += (int)GD.dtUpgradeScoreBooster.val;
		PlayerEventMgr.inst.OnEvent(PlayerEventKind.scoreBoost);
        GD.Save();
	}
	IEnumerator StartRunAction()
    {
		GameMgr.player.Mount();
		yield return new WaitForSeconds(2.2f);
		Util.PlaySound("sfxHorse");

		GameMgr.cameraMgr.CamAniPlay(CamMgr.Action.start);
		yield return new WaitForSeconds(2.5f);
		Util.PlaySound("sfxSayGiddyup", GD.dtHeroInfos[GD.dtHeroIdx].data.pitch);
		Util.PlaySound("sfxHorseCrying", GD.dtHeroInfos[GD.dtHeroIdx].data.pitch, 0.1f);
		yield return new WaitForSeconds(0.425f);
		GameMgr.cameraMgr.init();
		GameMgr.cameraMgr._Start = true;

		GameMgr.player.StartRun();
		mTracker.GoNearHero();
		if (GD.dtHeadSartCnt > 0)
			_icoHeadStart.SetActive(true);
		if (GD.dtScoreBoosterCnt > 0)
			_icoScoreBooster.SetActive(true);
		
		yield return new WaitForSeconds(2f);
		Util.PlaySound("sfxTrackerSay");

		yield break;
    }
	public void RebirthPet()
	{
		GameMgr.player.StartRun();
		GameMgr.cameraMgr.ResetCamEff();
	}
	public void Close()
	{
		base.DeactiveUI(gameObject);
	}
    public void Pause()
    {
        if (GameMgr.gameState == GameState.pause)
			return;
        GameMgr.gameState = GameState.pause;
		DlgPause.OpenDlg(msgDlgPause);
		Time.timeScale = 0f;
    }
	public void Resume()
	{
		GameMgr.gameState = GameState.play;
		TimeCount();
		Time.timeScale = 1;        
	}
    private void TimeCount()
    { 
    
    }
	void updateGameUI()
	{
		_TxtShieldCnt.text = GD.dtShieldCnt.ToString();

		if(Time.time - mGameStartTm >= 10f)
		{
			if(_icoScoreBooster.activeSelf)
				_icoScoreBooster.SetActive(false);
			if(_icoHeadStart.activeSelf)
				_icoHeadStart.SetActive(false);
		}

		_CurCoinCnt.text	= NGUIText.SpaceDigitString(GD.earnedCoin);
		_CurScore.text		= NGUIText.SpaceDigitString(GD.earnedScore);

		if(mFlyTm > 0)
		{
			mFlyTm -= Time.deltaTime;
			_frmFly.fillAmount = mFlyTm / GD.dtUpgradeFly.val;
			if(mFlyTm <= 0f)
			{
				GD.flying = false;
				_icoFly.SetActive(false);
				_frmFly.fillAmount = 0f;
			}
		}

		if(mMgtTm > 0)
		{
			mMgtTm -= Time.deltaTime;
			_frmMgt.fillAmount = mMgtTm / GD.dtUpgradeMagnet.val;
			if(mMgtTm <= 0f)
			{
				_icoMgt.SetActive(false);
				_frmMgt.fillAmount = 0f;
				GD.usingMagnet = false;
			}
		}

		if(mDoubleCoinTm > 0)
		{
			mDoubleCoinTm -= Time.deltaTime;
			_frm2x.fillAmount = mDoubleCoinTm / GD.dtUpgradeDoubleCoin.val;
			if(mDoubleCoinTm <= 0f)
			{
				_ico2X.SetActive(false);
				_frm2x.fillAmount = 0f;
			}
		}

		if(mBalloonTm > 0)
		{
			mBalloonTm -= Time.deltaTime;
			_frmBll.fillAmount = mBalloonTm / GD.dtUpgradeBalloon.val;
			if(mBalloonTm <= 0f)
			{
				_icoBll.SetActive(false);
				_frmBll.fillAmount = 0f;
			}
		}

		if(mShieldTm > 0)
		{
			mShieldTm -= Time.deltaTime;
			_SprShieldCoolTm.fillAmount = mShieldTm / mCoolDivideTm;
			if(mShieldTm <= 0f || GD.usingShield == false)
			{
				msgEraseSfSkin();
				GD.usingShield = false;
			}
		}

        if(mShieldCoolTm > 0)
		{
			mShieldCoolTm -= Time.deltaTime;
			_SprShieldDisable.fillAmount = mShieldCoolTm / GD.dtUpgradeShieldCT.val;
			if(mShieldCoolTm <= 0 )
			{
				_SprShieldIcon.SetActive(true);
				mShieldCoolTm = 0;
				activeShieldBtn(true);
			}
		}
		else
		{
			if(GD.dtShieldCnt > 0 && _SprShieldIcon.activeSelf == false)
				_SprShieldIcon.SetActive(true);
		}

		if(GD.newCheers != 0)
		{
			GD.curMultiplierPoint += GD.newCheers;
			if(GD.curMultiplierPoint >= GD.maxMultiplierPoint)
			{
				GD.multiplier++;
				_TxtMulLV.text = "x" + GD.multiplier.ToString();
				GD.curMultiplierPoint -= GD.maxMultiplierPoint;
				GD.maxMultiplierPoint += MD.stepMaxMultiplierPoint;
			}
			_SldBarMult.value = (float)GD.curMultiplierPoint / (float)GD.maxMultiplierPoint;
			_TxtMulLV.text = "x" + GD.multiplier.ToString();
			_TxtMulPoint.text = string.Format("{0}/{1}", GD.curMultiplierPoint, GD.maxMultiplierPoint);
			GD.newCheers = 0;
		}
	}
	void ManageGem()
	{
		
	}
	private void msgDlgPause(object _usrData)
	{
		switch((MsgDlgPause)_usrData)
		{
			case MsgDlgPause.btnResume:
			case MsgDlgPause.btnClose:
				Resume();
				break;
			case MsgDlgPause.btnSet:
				DlgSetting.OpenDlg(DlgMgr.MInst.dlgMgr.DlgSettingManager);
				break;
			case MsgDlgPause.btnGoHome:
				Resume();
				GameMgr.inst.GoAvtHome();
				break;
		}
	}
	IEnumerator StartDropCoroutine()
	{
		yield return new WaitForSecondsRealtime(3f);
		DlgRebirth.OpenDlg(msgDlgRebirth);

		yield break;
	}
	private void msgDlgRebirth(object _usrData)
	{
		switch((MsgDlgRebirth)_usrData)
		{
		case MsgDlgRebirth.none:
		case MsgDlgRebirth.bg:
			DlgResult.OpenDlg();
			break;
		case MsgDlgRebirth.btnRebirth:
			if(GD.dtGems < GD.needGemToRebirth)
			{
				DlgResult.OpenDlg();
			}
			else
			{
				GD.dtGems -= GD.needGemToRebirth;
				GD.needGemToRebirth *= 2;
				PlayerEventMgr.inst.OnEvent(PlayerEventKind.rebirth);
				GD.rebirthing = true;
				RebirthPet();
			}
			GD.Save();
			break;
		}
	}
}
