using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Jobs;

public class AppClient
{
    public static AppClient me = new AppClient();
    
    protected int mState;
    public int state { get { return mState; } set { mState = value;  } }

    protected int mLevel = 0;
    public int level { get { return mLevel; } set { mLevel = value;   } }  

    protected int mLastLevel = 0;
    public int lastLevel { get { return mLastLevel;  } set { mLastLevel = value; updateLevel(); } }


    protected int mBallLevel = 0;
    public int ballLevel { get { return mBallLevel;  } set { mBallLevel = value; } }

    protected int mLastBallLevel = 0;
    public int lastBallLevel { get { return mLastBallLevel;  } set { mLastBallLevel = value; } }


    protected int mRoundType = RoundType.none;
    public int roundType { get { return mRoundType;  } set { mRoundType = value; } }

    protected int mLeftCount = 0;
    public int leftCount { get { return mLeftCount; } set { mLeftCount = value; } } 

    protected float mLeftTime = 0;
    public float leftTime {  get { return mLeftTime;  } set { mLeftTime = value; } }

    protected int mLimitCount = 0;
    public int limitCount { get { return mLimitCount; } set { mLimitCount = value; } }

    protected float mLimitTime = 0;
    public float limitTime { get { return mLimitTime;  } set { mLimitTime = value; } }

    protected float mLiveTime = 0;
    public float liveTime { get { return mLiveTime; } set { mLiveTime = value; } }

    protected int mLiveCount = 5;
    public int liveCount { get { return mLiveCount; } set { mLiveCount = value; } }   

    public int[] goals = new int[3];

    public int[] stars = new int[50];

    protected float[] mPoints = new float[50];
    public float[] points = new float[50] {
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
    };

    public AppClient() 
    {
        updateStars();
        mLastLevel = mLevel;
    }  

    public void Update(float _dt)
    {
        if (mState == AppState.play)
        {
            if (mLeftTime > 0)
                mLeftTime -= _dt;
            if ((mRoundType == RoundType.both || mRoundType == RoundType.onlyTime) && mLeftTime < 0)
                mState = AppState.die;
            if ((mRoundType == RoundType.both || mRoundType == RoundType.onlyCount) && mLeftCount <= 0)
                mState = AppState.die;
        }

        if (mLiveTime < 0)
        {
            mLiveTime = AppMD.APP_LIVE_TIME;
            if (mLiveCount < AppMD.APP_LIVE_COUNT)
                mLiveCount += 1;
        }
        else
        {
            mLiveTime -= _dt;
        }

        if (mState == AppState.result)
        {
            float mPoint = AppMD.APP_POINT_TIME * mLeftTime + AppMD.APP_POINT_COUNT * mLeftCount;
            
            if (mPoint > points[mLastLevel])
                points[mLastLevel] = mPoint;

            if (mPoint < AppMD.appRoundGoalsData[lastLevel].goals[0])
                mState = AppState.die;
            else 
                mState = AppState.win;

            updateStars();
        }
    }

    

    AppRoundGoalData mGoalData = null;
    protected void updateLevel()
    {
        mGoalData = AppMD.appRoundGoalsData[mLastLevel];
        roundType = mGoalData.roundType;
        limitCount = mGoalData.limitCount;
        limitTime = mGoalData.limitTime;
        goals = mGoalData.goals;
        leftCount = limitCount;
        leftTime = limitTime;
        leftTime = limitTime;
    }

    protected void updateStars()
    {
        for (int i = 0; i < 5; i++)
            stars[i] = -1;

        for (int i = 0; i < 5; i ++)
        {
            for (int j = 0; j < 3; j ++ )
            {
                if (points[i] > AppMD.appRoundGoalsData[i].goals[j])
                    stars[i] = j;
            }
            if (stars[i] == -1)
            {
                mLevel = i;
                break;
            }
        }
    }

    public static void Start()
    {
        Debug.Log("Start");
    }

    public static void Exit()
    {
        Debug.Log("Exit");
    }

    public void Restart()
    {
        if (liveCount > 0) liveCount --;
    }

}
