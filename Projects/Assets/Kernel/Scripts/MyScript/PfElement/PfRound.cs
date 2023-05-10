using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PfRound : MonoBehaviour
{
    [SerializeField] UISprite _sprBg;
    [SerializeField] UISprite[] _sprStars;

    AppAvtHome mAvtInst = null;

    protected AppRoundUIData mRoundUIData = null;
    protected AppRoundGoalData mGoalData = null;


    protected int mlevel = 0;
    public int level {  get { return mlevel; } set { mlevel = value; } }

    protected float mPoint = 0;
    public float point {  get { return mPoint;  }  set { mPoint = value; } }

    protected int mStar = 0;
    public int star { get { return mStar; } set { mStar = value; } }

    protected bool mState = false;
    public bool state { get { return mState; } set { mState = value; } }

    public void Init(AppAvtHome _avtHome, int _level)
    {
        level = _level;

        if (_sprStars.Length != 3)
            return;

        if (level >= AppMD.appRoundUIsData.Length)
        {
            for (int i = 0; i < 3; i++)
                _sprStars[i].gameObject.SetActive(false);
            return;
        }

        mRoundUIData = AppMD.appRoundUIsData[level];
        mGoalData = AppMD.appRoundGoalsData[level];
        mPoint = AppClient.me.points[level];

        mAvtInst = _avtHome;


        mStar = -1;
        for(int i = 0; i < 3; i++)
        {
            if (mPoint > mGoalData.goals[i])
                mStar = i;
        }

        mState = (level <= AppClient.me.level);

        
        for(int i = 0; i < 3; i++)
            _sprStars[i].gameObject.SetActive(mStar >= 0 && mState);

        for (int i = 0; i <= mStar; i++)
            _sprStars[i].spriteName = "sprIconStar_01";

        for (int i = mStar + 1; i < 3; i++)
            _sprStars[i].spriteName = "sprIconStar_00";
        
        _sprBg.spriteName = state ? mRoundUIData.spriteName1 : mRoundUIData.spriteName0;
    }

    public void OnClick()
    {
        if (level > AppClient.me.level)
        {
            AppDlgOk.OpenDlg("Lock Error", "", "OK");
            return;
        }
        if (AppClient.me.liveCount < 1)
        {
            AppDlgOk.OpenDlg("Live Error", "", "OK");
            return;
        }
        mAvtInst.OnClickRound(level);
    }
}
