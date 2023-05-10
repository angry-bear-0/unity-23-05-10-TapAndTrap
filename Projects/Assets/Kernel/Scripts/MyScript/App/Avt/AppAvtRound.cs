using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AppAvtRound : AppAvtBase
{
    [SerializeField] UISprite _SprAvatar;
    [SerializeField] UILabel _LblLeftCount;
    [SerializeField] UILabel _LblRoundLvl;
    [SerializeField] UILabel _LblLiveCount;
    [SerializeField] UILabel _LblLeftTime;

    [SerializeField] GameObject _GoButtonPlay;
    [SerializeField] GameObject _GoButtonPause;

    [SerializeField] PfTechSlot[] _TechSlots;
    [SerializeField] UILabel _LblCounter;

    protected int mLevel = 0;
    public int level { get { return mLevel; } set { mLevel = value; } }

    protected AppRoundGoalData mGoalData;

    protected float mReadyTime;

    protected bool mInited = false;
    protected bool mFinished = false;


    protected new void Start()
    {
        base.Start();

        level = AppClient.me.lastLevel;
        if (level < 0 && level >= AppMD.appRoundUIsData.Length)
            return;

        AppRoundGoalData limitData = AppMD.appRoundGoalsData[level];

        mReadyTime = 3;
        AppClient.me.state = AppState.ready;

        for (int i = 0; i < _TechSlots.Length; i++)
            _TechSlots[i].Init(this, i);

        _GoButtonPause.SetActive(true);
        _GoButtonPlay.SetActive(false);
    }

    protected new void Update()
    {
        float dt = Time.deltaTime;

        if (AppClient.me.state == AppState.ready)
        {
            if (mReadyTime > 0)
            {
                mReadyTime -= dt;
                if (_LblCounter != null)
                    _LblCounter.text = Mathf.RoundToInt(mReadyTime).ToString();
            }
            else
            {
                AppClient.me.state = AppState.play;
                mFinished = false;
                _LblCounter.gameObject.SetActive(false);
            }
        }

        if (_LblLeftCount != null) _LblLeftCount.text = AppClient.me.leftCount.ToString();
        if (_LblRoundLvl != null) _LblRoundLvl.text = string.Format("Level {0}", Mathf.RoundToInt(AppClient.me.lastLevel + 1));
        if (_LblLiveCount != null) _LblLiveCount.text = AppClient.me.liveCount.ToString();
        if (_LblLeftTime != null) _LblLeftTime.text = string.Format("{0}s", Mathf.RoundToInt(AppClient.me.leftTime));

        if (!mFinished && (AppClient.me.state == AppState.win || AppClient.me.state == AppState.die))
        {
            mFinished = true;
            if (AppClient.me.state == AppState.win)
                AppDlgWin.OpenDlg(handleDialog);
            else if (AppClient.me.state == AppState.die)
                AppDlgLose.OpenDlg(handleDialog);
        }
    }

    public void OnClickTech(int _index)
    {
        AppDlgOk.OpenDlg("OnClickTech", "Developing...", "OK");
    }

    protected void handleDialog(object _obj)
    {
        if (_obj == null) return;
        switch ((string)_obj)
        {
            case "next": onClickNext(); break;
            case "restart": onClickRestart(); break;
            case "setting": onClickSetting(); break;
            case "out": onClickOut(); break;
        }
    }
    public void OnClickPlay()
    {
        onClickPlay();
    }

    public void OnClickPause()
    {
        onClickPause();
        AppDlgPause.OpenDlg(handleDialog);
    }
    protected void onClickPause()
    {
        AppClient.me.state = AppState.pause;
        _GoButtonPause.SetActive(false);
        _GoButtonPlay.SetActive(true);
    }

    protected void onClickPlay()
    {
        AppClient.me.state = AppState.play;
        _GoButtonPause.SetActive(true);
        _GoButtonPlay.SetActive(false);
    }

    protected void onClickRestart()
    {
        AppClient.me.Restart();
        AppAvtMgr.inst.LoadScene(SceneManager.GetActiveScene().name);
    }

    protected void onClickSetting()
    {
        AppDlgOk.OpenDlg("OnClickSetting", "developing...", "Ok");
    }

    protected void onClickNext()
    {
        AppClient.me.lastLevel = level + 1;
        AppAvtMgr.inst.LoadScene(SceneManager.GetActiveScene().name);
    }

    protected void onClickOut()
    {
        AppAvtMgr.inst.LoadScene("scnHome");
    }
}
