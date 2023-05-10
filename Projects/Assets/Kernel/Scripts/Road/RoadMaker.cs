//using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadMaker : MonoBehaviour 
{
	public static	RoadMaker	mInst = null;
	private			Transform	mCurSeg;
	private			Transform	mObs;
	private			RoadBlock	mBlock;
	//test
	

	private		bool			mWork			= false;

	private		int				mSegIdx;
	private		int				mObjSegIdx;
	private		int				mRoadLv;
	private		int[]			mLvSet;
    private     int				mLvIdx;
	private		float[]			mLvfrequences;  // number of Lv
    private     Vector3         mVtemp;
	//test
	private		int[]			mAllUseCnt;
	private		int[]			mCurUseCnt;

	private		int[]			mObsEachIdx;
	private		int				mRebirthCnt = 0;

	public void InitHome()
	{
		RoadRes.MInst.InitHome();
	}

	public void InitGame()
	{
		RoadRes.MInst.InitGame();
		mWork				= true;
        mLvIdx				= 0;
		mSegIdx				= 0;
		mObjSegIdx			= -1;
		mRoadLv				= 1;
		mLvSet				= new int[MD.roadSetLen];
		mLvfrequences		= new float[MD.roadLvCnt];  // number of Lv
		mCurUseCnt			= new int[(int)ObsKind.size];
		mAllUseCnt			= new int[(int)ObsKind.size];
		mObsEachIdx			= new int[(int)ObsKind.size];
		mRebirthCnt			= GD.rebirthCnt;
        for (int i = 0; i < (int)ObsKind.size; i++)
		{
			mAllUseCnt[i]	= 0;
			mCurUseCnt[i]	= 0;
			mObsEachIdx[i]	= 0;
		}
	}
	// Use this for initialization
	void Awake ()
	{
		mInst = this;
	}

	// Update is called once per frame
	void Update ()
	{
		if (!mWork)
			return;

		if (mSegIdx != getSegIdx())
		{
			mSegIdx = getSegIdx();
            updateRoad();
		}
		if(GD.rebirthCnt != mRebirthCnt)
		{
			resetCurObjSeg();
			
			mRebirthCnt = GD.rebirthCnt;
        }
		if (GD.usingShield && GD.collided)
		{
			GD.usingShield = false;
            GD.Save();
			//Instantiate(Resources.Load("Prefabs/Particle/ptcRelife"), AvtMgr.instance.mCsPlayer.PlrTrans);
			resetCurObjSeg();
		}


		if (mObjSegIdx != getObsSegIdx())
		{
			mObjSegIdx = getObsSegIdx();
			setBlocks();
            setCoins();
			setObs();
			setItems();
		}
	}

	void updateRoad()
	{
		mCurSeg = RoadRes.GetRoad();
		mCurSeg.Translate(0f,0f,600);
	}
    
    void setBlocks()
    {
		mLvIdx++;
		if (mLvIdx % MD.roadSetLen == 0)
		{
			mLvIdx = 0;
			makeLvSet(decideLevel(decideDifficulty()));
		}
		mBlock = selectRoadLevel(mLvSet[mLvIdx]);
    }
	private void resetCurObjSeg()
	{
		for(int i = 0; i < (int)ObsKind.size; i++)
		{
			Transform[] idealObs = RoadRes.instance.Obs[i]; ;
			for(int j = 0; j < idealObs.Length; j++)
			{
				if (idealObs[j].position.z - GameMgr.playerTr.position.z < (50 - GameMgr.playerTr.position.z % 50))
					idealObs[j].localPosition = Vector3.zero;
			}
		}
	}

    void setCoins()
	{
		int nJumpSize = 0;

		if (GD.flying)
			return;
		
		if (mBlock.rbCoinPos != null)//동전
		{
			for (int i = 0; i < mBlock.rbCoinPos.Length; i++)
			{
				mObs = RoadRes.GetCoin(mBlock.rbCoinPos.Length);
				if (mObs)
	                Cmm.SetPos(mObs, mBlock.rbCoinPos[i].pos.x, mBlock.rbCoinPos[i].pos.y, mBlock.rbCoinPos[i].pos.z + (mObjSegIdx + 1f) * 50f);
			}
			if (mBlock.rbJumpCoins != null)
			{
				for (int i = 0; i < mBlock.rbJumpCoins.Length; i++)
				{
                    int nJumppartSize = 0;
                    nJumppartSize = setJumpCoin(mBlock.rbJumpCoins[i].pos);
                    nJumpSize = nJumpSize + nJumppartSize;     
				}
			}
		}
		//else
			//print("No Coins");

		manageIdealObs(ObsKind.coin, mBlock.rbCoinPos.Length + nJumpSize);

    }

    void setObs()
    {
        if (mBlock.rbObsInfo != null)
        {
            for (int i = 0; i < mBlock.rbObsInfo.Length; i++)
            {
                mObs = RoadRes.GetObs(mBlock.rbObsInfo[i].kind);
				mObsEachIdx[(int)mBlock.rbObsInfo[i].kind]++;
				if (mObs)
					Cmm.SetPos(mObs, mBlock.rbObsInfo[i].pos.x, mBlock.rbObsInfo[i].pos.y, mBlock.rbObsInfo[i].pos.z + (mObjSegIdx + 1f) * 50f);
				switch (mBlock.rbObsInfo[i].kind)
				{
					case ObsKind.runtroupe:
					case ObsKind.runstand:
					case ObsKind.ball:
						if (mObs)
							mObs.GetComponent<Roll>().StartRoll(mSegIdx+1);
						break;
				}
            }
        }

		for (int i = 0; i < (int)ObsKind.size - 2; i++)
		{
			manageIdealObs((ObsKind)i, mObsEachIdx[i]);
			mObsEachIdx[i] = 0;
		}
    }

    void setItems()
    {
		int idx = 0;
		if (mBlock.rbItems != null)//item
		{
			for (int i = 0; i < mBlock.rbItems.Length; i++)
			{
				mObs = RoadRes.GetItem(mBlock.rbItems[i].Itemkind);
				if (mObs)
					Cmm.SetPos(mObs, mBlock.rbItems[i].pos.x, mBlock.rbItems[i].pos.y, mBlock.rbItems[i].pos.z + (mObjSegIdx + 1f) * 50f);
			}

			idx = mBlock.rbItems.Length;

		}
		else
		{
			idx = 0;
		}
		manageIdealObs(ObsKind.item, idx);
    }
	void manageIdealObs(ObsKind _obsKind, int _useCnt)
	{
		Transform[]	idealObs = RoadRes.instance.Obs[(int)_obsKind];
        for (int i = 0; i < idealObs.Length; i++ )
        {
            if (idealObs[i].position.z < (GameMgr.playerTr.position.z - 5))
                idealObs[i].localPosition = Vector3.zero;
        }
		
	}
	float decideDifficulty()
	{
		float dif = 0.0f;
		float distance = GD.dist;
		//난도 = Clamp1(0.3 x Clamp1((Lv-1) ^ 0.7 / 10) + Dist ^ 0.9 /2000)
		dif = Mathf.Clamp01(0.3f * Mathf.Clamp01(Mathf.Pow(mRoadLv, 0.7f) / 10) + Mathf.Pow(distance, 0.9f) / 600);
		//mRoadLv++;
		return dif;
	}

	float[] decideLevel(float _dif)
	{
		float[] segCnt = new float[MD.roadLvCnt];
		float sumLvFre = 0.0f;
        for (int i = 0; i < MD.roadLvCnt; i++)
		{
			// 확률 = MIN(1, ROUND(난도-시작난도 + 0.5,0)) * (시작확률-POWER(CLAMP(0, 난도-시작난도, 끝난도-시작난도)/(끝난도-시작난도), 변화곁수) * (시작확률-끝확률))	
			mLvfrequences[i] = Mathf.Min(1, Mathf.Round(_dif - RoadLvFrequece.RoadStLv[i] + 0.5f)) * (RoadLvFrequece.RoadStFre[i] - Mathf.Pow(Mathf.Clamp(0, _dif - RoadLvFrequece.RoadStLv[i], RoadLvFrequece.RoadEndLv[i] - RoadLvFrequece.RoadStLv[i]), RoadLvFrequece.Alpha[i]) * (RoadLvFrequece.RoadStFre[i] - RoadLvFrequece.RoadEndFre[i]));
			sumLvFre += mLvfrequences[i];
		}
        for (int i = 1; i < MD.roadLvCnt; i++)
		{
			segCnt[i] = Mathf.Round(mLvfrequences[i] / sumLvFre * 100);
		}
		segCnt[0] = 100 - segCnt[1] - segCnt[2] - segCnt[3] - segCnt[4];
		for (int i = 0; i < segCnt.Length; i++)
		{
			segCnt[i] = Mathf.Round(12 * segCnt[i] / 100);
		}
		return segCnt;
	}

	void makeLvSet(float[] _lvCnt)
	{
		int idx = 0;
		for (int i = 0; i < _lvCnt.Length; i++)
		{
			while (idx < _lvCnt[i])
			{
				mLvSet[idx] = i + 1;
				idx++;
				if (idx == mLvSet.Length - 1)
				{
					break;
				}
			}
		}
		resortArrayOrder(mLvSet);
	}

	void resortArrayOrder(int[] _a)
	{
		List<int> b = new List<int>(_a);
		for (int i = 0; i < _a.Length; i++)
		{
			int idx = Random.Range(0, b.Count);
			_a[i] = b[idx];
			b.RemoveAt(idx);
		}
	}

	RoadBlock selectRoadLevel(int level)
	{
		//print("level = " + level);
		int[] a = new int[5];
		
        //level = 0;
        switch (level)
               {
                   case 0:
                       a[0] = Random.Range(0, RoadData.lv0.Length);
                       return RoadData.lv0[a[0]];
                   case 1:
                       a[1] = Random.Range(0, RoadData.lv1.Length);
                       return RoadData.lv1[a[1]];
                   case 2:
                       a[2] = Random.Range(0, RoadData.lv2.Length);
                       return RoadData.lv2[a[2]];
                   case 3:
                       a[3] = Random.Range(0, RoadData.lv3.Length);
                       return RoadData.lv3[a[3]];
                   case 4:
                       a[4] = Random.Range(0, RoadData.lv4.Length);
                       return RoadData.lv4[a[4]];
               }
               return RoadData.lv0[0]; 
	}

	private int getSegIdx()
	{
		int idx = ((int)((GD.dist - 50) / MD.roadSegLen));//% MD.roadSegCnt;
		return idx;
	}

	private int getObsSegIdx()
	{
        int idx = ((int)(GD.dist / MD.obsSegLen));
		return idx;
	}

	void resetObs( int _allCnt, int _useCnt, int _Size ,int _allIdx, Transform[] _trans, bool _isReset = false)
	{
		for(int i = _allCnt - 1; i >= _allCnt - _useCnt; i--)
		{
			int nIdx = i< 0? _Size + i:i;
			{
				_trans[nIdx].localPosition = Vector3.zero;
			}
		}
	}

	private int setJumpCoin(Vector3 _pos)
	{
		float fJumpDst = GD.speed * MD.jumpNormalTm;
		int	  nSize    = Mathf.RoundToInt(fJumpDst);
        
        _pos.z = _pos.z + (mObjSegIdx + 1f) * 50f - fJumpDst / 2;

		for (int i = 0; i < nSize; i++)
		{
			mObs = RoadRes.GetCoin(nSize);
            _pos.y = (GameMgr.inst._AniCurve.GetValue((float)i / (float)nSize, JumpKind.normal) * MD.jumpH + 0.3f);
			if (mObs)
	            Cmm.SetPos(mObs, _pos.x, _pos.y, _pos.z + i);
		}
		return nSize;
	}
	public void setFlyCoin(Vector3 _itemFly)
	{
		float fFlyDist = GD.speed * (GD.dtUpgradeFly.val - MD.jumpFlyTm);
		mBlock = RoadData.FlyCoin[Random.Range(0, 4)];

        int nSize = Mathf.FloorToInt(fFlyDist / 2f);
		for (int i = 0; i < nSize&& i < mBlock.rbCoinPos.Length; i++)
		{
			mObs = RoadRes.GetCoin(nSize);
			if (mObs)
				Cmm.SetPos(mObs, mBlock.rbCoinPos[i].pos.x, mBlock.rbCoinPos[i].pos.y, _itemFly.z + 2f * i);
			mObs.position += 6.8f * mObs.up;
		}
        manageIdealObs(ObsKind.coin, nSize);
	}
	public void setSpringCoin(Transform _itemSpring) 
	{
		float		fAniStart		= 1.708f;
		float		fSpringDist		= GD.speed * fAniStart;
		int			nSize			= Mathf.RoundToInt(fSpringDist);
		Vector3[]	TransPos		= new Vector3[(int)LaneIdx.size];
		TransPos[(int)LaneIdx.center] = GetLanePos(_itemSpring, LaneIdx.center);
		TransPos[(int)LaneIdx.left] = GetLanePos(_itemSpring, LaneIdx.left);
		TransPos[(int)LaneIdx.right] = GetLanePos(_itemSpring, LaneIdx.right);

		for (int nIdx = 0; nIdx < (int)LaneIdx.size; nIdx++)
		{
			Vector3 tmp		= TransPos[nIdx];
			for (int i = 0; i <= nSize-1; i++)
			{
				if(i > 1 && i < nSize - 2)
					mObs			= RoadRes.GetCoin(nSize - 1);
				tmp.y = (GameMgr.inst._AniCurve.GetValue((float)i / (float)nSize, JumpKind.spring) * MD.springH) + _itemSpring.position.y;
                tmp.z += 1f;
				if (i > 1 && i < nSize - 2 && mObs)
	                Cmm.SetPos(mObs, tmp.x, tmp.y, tmp.z );
			}
		}
        manageIdealObs(ObsKind.coin,3*(nSize-1));
	}
	private Vector3 GetLanePos(Transform _trans, LaneIdx _laneIdx)
	{
		Vector3 mObjPos = _trans.position;
		// 		float mAngle;
		// 		float mDis = Vector2.Distance(new Vector2(mObjPos.x, mObjPos.z), Vector2.zero);

		if (_laneIdx == LaneIdx.left)
		{
			// 			mObjPos.x += 189.386f - mDis;
			// 			mObjPos.y = 0.599f;

			mObjPos.x = - MD.laneWidth;
		}
		if (_laneIdx == LaneIdx.right)
		{
			// 			mObjPos.x += 192.586f - mDis;
			// 			mObjPos.y = -0.599f; 
			mObjPos.x = MD.laneWidth;// 1.6f;
		}
		if (_laneIdx == LaneIdx.center)
		{
			// 			mObjPos.x += 190.986f - mDis;
			// 			mObjPos.y = 0.0f;
			mObjPos.x = 0f;
		}

		_trans.position = mObjPos;
		//mAngle = -Cmm.GetAngleFromRightToVector(mObjPos.x, mObjPos.z);
		//Quaternion rot = Quaternion.Euler(0, mAngle, 0) * Quaternion.Euler(0, 0, -20);
		//_trans.rotation = rot;
		return _trans.position;
	}
	public void reSetAllObs()
	{
		for (int i = 0; i < (int)ObsKind.size; i++)
		{
			for (int nIdx = 0; nIdx < RoadRes.MInst.Obs[i].Length; nIdx++)
			{
				RoadRes.MInst.Obs[i][nIdx].localPosition = Vector3.zero;
			}
		}

	}
}
