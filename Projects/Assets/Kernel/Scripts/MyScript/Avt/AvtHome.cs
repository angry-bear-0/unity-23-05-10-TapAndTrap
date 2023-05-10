using System.Collections;
using UnityEngine;
public class AvtHome : AvtBase
{
	static public AvtHome inst { get; private set; }

	[SerializeField] protected	 UILabel	_TxtHp;
    [SerializeField] protected	 UILabel	_TxtLvl;
    [SerializeField] protected	 UISlider	_SldHp;

    static public void Create(bool _needLoading, bool _needPlayer, bool _needUI3DCamera, bool _needBackground)
    {
        GameObject obj = Instantiate(Resources.Load("Prefabs/Avt/pfAvtHome")) as GameObject;
        Transform trans = obj.GetComponent<Transform>();
        trans.parent = GameObject.Find("CameraUI").GetComponent<Transform>();
        trans.localPosition = Vector3.zero;
        trans.localRotation = Quaternion.identity;
        trans.localScale = Vector3.one;
        AvtHome script = obj.GetComponent<AvtHome>();
        script.Active( _needLoading, _needPlayer, _needUI3DCamera, _needBackground);
		script.Init();
    }
	void Init() 
	{
		inst = this;
		if(GD.dead || GD.dist > 0f)
		{
			mPlayer.Reset();
			GD.dead = false;
			RoadMaker.mInst.InitHome();
			RoadMaker.mInst.reSetAllObs();
			mGameMgr._InputHome.SetActive(true);
			
			GD.needGemToRebirth = 1;
		}
		GameMgr.cameraMgr.Reset();
		mGameMgr._InputHome.SetActive(true);
		mPlayer = GameMgr.player;
        mGameMgr._InputHome.GetComponent<InputHome>().InitGame();
	}
    void Update()
    {
		if (!mPlayer)
			mPlayer = GameMgr.player;
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (!DlgBase.DoEscapePress())
            {
                GameExit();
            }
        }
        updateHomeUI();
    }
    public void OnBtnClicked(GameObject _btn)
    {
        switch (_btn.name)
        {
            case "btnOpenDlgSetting":
				DlgSetting.OpenDlg(DlgMgr.MInst.dlgMgr.DlgSettingManager);
				break;
            case "btnOpenDlgMss":
                DlgMission.OpenDlg(this);
                break;
			case "btnOpenDlgMe":
				DlgMe.OpenDlg();
                break;
            case "btnPlay":
                Play();
                break;
            case "btnOpenDlgShop":
                DlgShop.OpenDlg();
                break;
			case "btnOpenDlgHp":
				DlgFood.OpenDlg(msgDlgFood);
				break;
        }
    }
    IEnumerator CloseDlgRoutin()
    {
        Cmm.SendMessageRecursively(gameObject, "PlayReverse", 2);
        yield return new WaitForSeconds(1f);
        base.DeactiveUI(gameObject);
        yield break;
    }
    public void Play()
    {
        if (GameMgr.gameState == GameState.play)
        {
            return;
        }
        {
			if (GD.dtPetHp < 10)
			{
				DlgOkCancel.OpenDlg(null, null, ST.getCorrectStr(ST.NOFOOD));
				return;
			}
            StartCoroutine(CloseDlgRoutin());
            mGameMgr.GoAvtGame();                    
        }
    }
    public void GameExit()
    {
		DlgOkCancel.OpenDlg(OnDlgOkCancel,null, ST.getCorrectStr(ST.QUIT));
    }
	private void OnDlgOkCancel(object _usrData)
	{
		Application.Quit();
	}
	void updateHomeUI()
	{
		_TxtLvl.text	= Lang.Format("uiLevel", GD.dtLevel);
		_TxtHp.text		= GD.dtPetHp.ToString() + "/" + GD.targetHp.ToString();
		_SldHp.value	= (float)GD.dtPetHp / (float)GD.targetHp;
	}
	protected virtual void FixedUpdate()
	{
		if (Time.frameCount % 40 == 0)
			System.GC.Collect();
	}
	public void Close()
	{
		DeactiveUI(gameObject);
		inst = null;
	}
    private void msgDlgFood(object _usrData)
    {
        switch ((MsgDlgFood)_usrData)
        {
        case MsgDlgFood.btnAdd:
            DlgShop.OpenDlg(0);
            break;
        case MsgDlgFood.btnFood:
			if (GD.dtPetHp < GD.targetHp)
			{
				if(GD.dtFoodCnt > 0)
				{
					GD.dtFoodCnt--;
					PlayerEventMgr.inst.OnEvent(PlayerEventKind.food);
					GD.dtPetHp = Mathf.Min(GD.targetHp, GD.dtPetHp + MD.petFeedInc);
					mPlayer.OnInputHome(InputHomeKind.eat);
					Util.PlaySound("sfxEating");
					updateHomeUI();
					GD.Save();
				}
				else
				{
					DlgOkCancel.OpenDlg(null, null, Lang.Get("uiMsgNoFood"));
				}
			}
			else
			{
				DlgOkCancel.OpenDlg(null, null, Lang.Get("uiMsgFullHP"));
			}
            break;

        case MsgDlgFood.btnSuper:
			if(GD.dtPetHp < GD.targetHp)
			{
				if (GD.dtSuperFoodCnt > 0)
				{
					GD.dtSuperFoodCnt--;
					PlayerEventMgr.inst.OnEvent(PlayerEventKind.superFood);
					GD.dtPetHp = GD.targetHp;
					mPlayer.OnInputHome(InputHomeKind.eat);
					Util.PlaySound("sfxEating");
					updateHomeUI();
					GD.Save();
				}
				else
				{
					DlgOkCancel.OpenDlg(null, null, ST.getCorrectStr(ST.NOSUPFOOD));
				}
			}
			else
			{
				DlgOkCancel.OpenDlg(null, null, Lang.Get("uiMsgFullHP"));
			}
			break;
        }
    }

}
