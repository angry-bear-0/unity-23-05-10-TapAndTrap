using UnityEngine;
using System.Collections;

public class Roll : MonoBehaviour 
{
    private Transform mPRS;
	private Transform mPlayer;
//	private int		mExsitSeg;
	private int		mAngleObs;
	private int		mAngPlayer;
	private int mRebirthCnt = 0;
	private float	mShieldTm = 0f;
	Animation		mAni;
    
	public bool mRoll = false;
	// Use this for initialization
	void Start ()
	{
		mPRS = transform;
		mAni = mPRS.GetChild(0).GetComponent<Animation>();
	}

	public void StartRoll(int _segId)
	{
		mRoll = true;
		mRebirthCnt = GD.rebirthCnt;

//		mExsitSeg = _segId;
	}

	// Update is called once per frame
	void Update ()
	{
		if (GD.dead)
		    return;
		if(GameMgr.gameState != GameState.play)
			return;
		if(mAni)
			mAni.PlayQueued("aniFan");
		if (GD.rebirthCnt != mRebirthCnt)
		{
			mRebirthCnt = GD.rebirthCnt;
			mPRS.localPosition = Vector3.zero;
		}
		if(GD.usingShield && mShieldTm <= 0f)
		{
			mShieldTm = GD.dtUpgradeShieldCT.val;
		}
		if(mShieldTm > 0f)
		{
			if(GD.collided)
			{
				mPRS.localPosition = Vector3.zero;
				mShieldTm = 0f;
			}
			else
			{
				mShieldTm -= Time.deltaTime;
			}
		}
		if (mRoll)
		{
			if(mPlayer)
                mAngPlayer =(int) mPlayer.position.z;
            else
                mPlayer = GameMgr.playerTr;
            mAngleObs = (int)mPRS.position.z;
            int segId = mAngleObs / 50;

            int btDis = segId * 50 - mAngPlayer;   
            if (btDis < 10)
             {
                mPRS.Translate(0f, 0f, -0.1f);
             }
			
 			if (mAngleObs-mAngPlayer<-5)
            {
 				mPRS.localPosition = Vector3.zero;
 				mRoll = false;
 			}
		}
	}
}
