using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.Networking.Types;

public class AppRoundMgr : AppScnBase
{
    const int MAX_SLIDE_CNT = 16;

    protected AppRoundData mRoundData = null;

    protected ActrRound mRound;
    protected ActrBall mBall;
    
    protected RaycastHit[] mCachedRayCastHits = new RaycastHit[300];
    protected AppMapInfo mMapInfo = null;

    protected int mLevel = 0;
    protected int mBallLevel = 0;

    
    protected new void Awake()
    {
        base.Awake();
    }
    protected new void Update()
    {
        base.Update();
    }


    protected new void Start()
    {
        base.Start();
        mLevel = AppClient.me.lastLevel;
        if (mLevel < 0 && mLevel >= AppMD.appRoundUIsData.Length)
            return;
        
        mBallLevel = AppClient.me.lastBallLevel;
        if (mBallLevel < 0 && mLevel >= AppMD.appBallsData.Length)
            return;
        
        mRoundData = AppMD.appRoundsData[mLevel];

        AppClient.me.lastLevel = mLevel;
        
        CreateRound();
    }

    public void CreateRound()
    {
        GameObject obj = Instantiate(Resources.Load(mRoundData.pfName)) as GameObject;
        Transform trans = obj.GetComponent<Transform>();
        trans.parent = transform;

        trans.localPosition = new Vector3(0f, 0f, 0);
        trans.localRotation = Quaternion.identity;
        trans.localScale = Vector3.one;

        mRound = obj.GetComponent<ActrRound>();
        mRound.Init(mLevel);
    }
}
