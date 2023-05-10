using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
    using UnityEditor;
#endif
#if UNITY_EDITOR
static public class CCRMenu
{
    static Dictionary<string, ObsKind>     dicObs = null;
    static Dictionary<string, ItemKind>    dicItem = null;
    static Dictionary<string, ItemForWeek> dicItemweek = null;
    static void Init()
    {
        if (dicObs == null)
        {
            dicObs = new Dictionary<string, ObsKind>();
            dicObs["pfCartStand"]			= ObsKind.cartstand;
            dicObs["pfCartTroupe"]			= ObsKind.carttroupe;
            dicObs["pfRunTroupe"]           = ObsKind.runtroupe;
            dicObs["pfRunStand"]            = ObsKind.runstand;
            dicObs["pfIncline"]             = ObsKind.cartladder;
			dicObs["pfBalloon"]				= ObsKind.balloon;
			dicObs["pfBall"]				= ObsKind.ball;
            //dicObs["pfGroundStaff"]     = ObsKind.groundStaff;
            //dicObs["pfLight"]           = ObsKind.light;
            //dicObs["pfRubberwithWheel"] = ObsKind.rubberwithWheel;
            //dicObs["pfStaff"]           = ObsKind.staff;
            //dicObs["pfSteelyard"]       = ObsKind.steelyard;
            dicObs["pfHrudleUp"]          = ObsKind.hurdleup;
            dicObs["pfHurdleMiddle"]      = ObsKind.hurdlemiddle;
            dicObs["pfHurdleDown"]        = ObsKind.hurdledown;
			dicObs["pfFlagPole2"]		  = ObsKind.flagPole2;
			dicObs["pfFlagPole3"]		  = ObsKind.flagPole3;
			dicObs["pfFlagPole4"]		  = ObsKind.flagPole4;
			dicObs["pfSwingBob"]		  = ObsKind.swingBob;
            //dicObs["pfWall"]            = ObsKind.wall;
            //dicObs["pfWallDown"]        = ObsKind.wallDown;
            //dicObs["pfWallLeft"]        = ObsKind.wallLeft;
            //dicObs["pfWallRight"]       = ObsKind.wallRight;
            //dicObs["pfWheelonWheel"]    = ObsKind.wheelonWheel;
        }
        if (dicItem == null)
        {
            dicItem = new Dictionary<string, ItemKind>();
            dicItem["pfItmBalloon"]         = ItemKind.balloon;
			dicItem["pfItmFly"]				= ItemKind.fly;
            //dicItem["pffly"]             = ItemKind.fly;
            dicItem["pfItmShield"]       = ItemKind.shield;
            dicItem["pfItmSpring"]       = ItemKind.spring;
            dicItem["pfItmMagnet"]       = ItemKind.magnet;

//             dicItem["pfCoinBag"]         = ItemKind.coinBag;
//             dicItem["pfGem"]             = ItemKind.gem;
//             dicItem["pfMegaHeadStart"]   = ItemKind.megaHeadStart;
//             dicItem["pfMultiPler"]       = ItemKind.multiPler;
//             dicItem["pfMysterBox"]       = ItemKind.mysterBox;
//             dicItem["pfPlane"]           = ItemKind.plane;
//             dicItem["pfSuperMysteryBox"] = ItemKind.superMysteryBox;
        }
        if (dicItemweek == null)
        {
            dicItemweek = new Dictionary<string, ItemForWeek>();
            dicItemweek["pfFlower"]     = ItemForWeek.flower;
            dicItemweek["pfSnowman"]    = ItemForWeek.snowman;
            dicItemweek["pfRedleaves"]  = ItemForWeek.redleaves;
            dicItemweek["pfIcecream"]   = ItemForWeek.icecream;
        }
    }
    [MenuItem("CCR/JCR_ExtractInfo %q" , true)]
    static public bool JCR_ExtractInfoValidation() { return (Selection.activeGameObject != null); }
    [MenuItem ("CCR/JCR_ExtractInfo  %q" , false , 0)]
    static public void JCR_ExtractInfo()
    {
       /* if (Selection.activeGameObject.transform.Find("pfWheel") == null)
        {
            Debug.Log("Err: No Wheel");
            return;
        }
        */
        Init();
        List<ObsInfo> obss = new List<ObsInfo>();
        List<Items>   itss = new List<Items>();
        List<Itemfws> ifss = new List<Itemfws>();
        List<Coins> coins = new List<Coins>();
		List<JumpCoins> jump = new List<JumpCoins>();

        if (!Selection.activeGameObject)
        {
            //Debug.Log("GameObject null");
            return;
        }
		foreach (Transform c in Selection.activeGameObject.transform)
		{

            if (dicObs.ContainsKey(c.name))
            { 
                obss.Add(new ObsInfo(dicObs[c.name], c.localPosition/*, c.localRotation*/)); 
            }
			if (dicItem.ContainsKey(c.name))
				itss.Add(new Items(dicItem[c.name], c.localPosition/*, c.localRotation*/));
			if (dicItemweek.ContainsKey(c.name))
				ifss.Add(new Itemfws(dicItemweek[c.name], c.localPosition/*, c.localRotation*/));
			else if (c.name == "pfCoin")
				coins.Add(new Coins(c.localPosition));
			if (c.name == "pfFlyCoin")
				jump.Add(new JumpCoins(c.localPosition/*, c.localRotation*/));

		}
        string s = null;
        if (itss.Count > 0)
        {
            s += string.Format("new RoadBlock(\n\t\tnew Items[] {2}\r\n\t\t\t\tnew Items(ItemKind.{0}, new Vector3{1})", itss[0].Itemkind.ToString(), itss[0].pos.ToString("0.000000f"), "{");
            for (int i = 1; i < itss.Count; i++)
            {
                s += string.Format("\r\n\t\t\t\tnew Items(ItemKind.{0}, new Vector3{1}),", itss[i].Itemkind.ToString(), itss[i].pos.ToString("0.000000f"));
            }
            s += "},";
        }
        else
        {
            s += "new RoadBlock(null, ";
        }
        if (obss.Count > 0)
        {
			s += string.Format("\r\n\t\tnew ObsInfo[] {2}\r\n\t\t\t\tnew ObsInfo(ObsKind.{0}, new Vector3{1}),", obss[0].kind.ToString(), obss[0].pos.ToString("0.000000f"),"{");
            for (int i = 1; i < obss.Count; i++)
				s += string.Format("\r\n\t\t\t\tnew ObsInfo(ObsKind.{0}, new Vector3{1}),", obss[i].kind.ToString(), obss[i].pos.ToString("0.000000f")/*, obss[i].rot.ToString("0.000000f")*/);
            s += "},";
        }
        else
        {
            s += "null, ";
        }
        if (ifss.Count > 0)
        {
            s += string.Format("\r\n\t\t\t\tnew ItemsForWeek[] {2}\tnew Itemsfws(ItemForWeek.{0}, new Vector3{1}),", ifss[0].Itemfw.ToString(), obss[0].pos.ToString("0.000000f"), "{");
            for (int i = 1; i < itss.Count; i++)
            {
                s += string.Format("\r\n\t\t\t\tnew Items(ItemKind.{0}, new Vector3{1}),", ifss[i].Itemfw.ToString(), ifss[i].pos.ToString("0.000000ff")/*, ifss[i].rot.ToString("0.000000f")*/);
            }
        }
        else
        {
            s += " null,";
        }

        if (coins.Count > 0)
        {
			s += string.Format("\r\n\t\tnew Coins[] {1}\r\n\t\t\t\tnew Coins(new Vector3{0}),", coins[0].pos.ToString("0.000000f"),"{");
            for (int i = 1; i < coins.Count; i++)
            {
                if ((i - 1) % 3 == 0)
                {
					s += string.Format("\n\t\t\t\tnew Coins(new Vector3{0}),", coins[i].pos.ToString("0.000000f"));
                }
                else
                {
                    s += string.Format("\tnew Coins(new Vector3{0}),", coins[i].pos.ToString("0.000000f"));
                }
            }
            s += "},";
        }
        else
        {
            s += " null,";
        }
		if (jump.Count > 0)
		{
			s += string.Format("\r\n\t\tnew JumpCoins[] {1}\r\n\t\t\t\tnew JumpCoins( new Vector3{0}),", jump[0].pos.ToString("0.000000f"), "{");
			for (int i = 1; i < jump.Count; i++)
				s += string.Format("\r\n\t\t\t\tnew JumpCoins(new Vector3{0}),", jump[i].pos.ToString("0.000000f"));
			s += "}),";
		}
		else
		{
			s += " null),";
		}
       // s += "};";
        //Debug.Log(s);
    }

    [MenuItem("CCR/JCR_SetCorrectPostion %w", true)]
	static public bool JCR_SetCorrectPositionBool() { return (Selection.activeGameObject != null); }
    [MenuItem("CCR/JCR_SetCorrectPosition %w", false, 0)]
    static public void JCR_SetCorrectPosition()
    {
        Vector3    mObjPos   = new Vector3(0.0f, 0.0f, 0.0f);
        float      mAngle;        
        GameObject go;

        go = Selection.activeGameObject;
        if (!go)
        {
            //Debug.Log("GameObject Null");
            return;
        }else { mObjPos = go.transform.position;}
       
        /////////////////////  Set Correct Position          ////////////
        float mDis =  Vector2.Distance(new Vector2(mObjPos.x, mObjPos.z),Vector2.zero);
        //mDis = mObjPos.magnitude;

		if (mDis < 190.186)
		{
			mObjPos.x += 189.386f - mDis;
			mObjPos.y = 0.599f;
			// if (go.transform.name == "pfObshurdle2") mObjPos.y = 0.88f;
		}

		if (mDis >= 190.186f && mDis < 191.786f)
		{
			mObjPos.x += 190.986f - mDis;
			mObjPos.y = 0.0f;
			//if (go.transform.name == "pfObshurdle2") mObjPos.y = 0.47f;
		}

		if (mDis >191.786f)
		{
			mObjPos.x += 192.586f - mDis;
			mObjPos.y = -0.599f;
		}
        go.transform.position = mObjPos;

        mAngle = -Cmm.GetAngleFromRightToVector(mObjPos.x, mObjPos.z);
        Quaternion rot = Quaternion.Euler(0, mAngle, 0 ) * Quaternion.Euler(0, 0, -20);
        go.transform.rotation = rot;
    }

    [MenuItem("CCR/GJC_CreatCoins %e", true)]
	static public bool GJC_CreatCoinsBool() { return (Selection.activeGameObject != null);}
    [MenuItem("CCR/GJC_CreatCoins %e", false, 0)]
    static public void GJC_CreatCoins()
    {
		Vector3 mCurPosx = new Vector3(189.535f, 191.126f, 192.586f);
		Vector3 mCurPosy = new Vector3(0.969f, 0.370f, -0.229f);
		makeCoin(mCurPosx, mCurPosy, 4);	
    }

	[MenuItem("CCR/GJC_CreatTrainCoins %t", true)]
	static public bool GJC_CreatTrainCoinsBool() { return (Selection.activeGameObject != null); }
	[MenuItem("CCR/GJC_CreatTrainCoins %t", false, 0)]
	static public void GJC_CreatTrainCoins() 
	{
		Vector3 mTrainPosx = new Vector3(190.284f, 191.885f, 193.475f);
		Vector3 mTrainPosy = new Vector3(2.823f, 2.225f, 1.625f);
		makeCoin(mTrainPosx, mTrainPosy, 4);
	}

	[MenuItem("CCR/GJC_CreatGapCoins", true)]
	static public bool GJC_CreatGapCoinsBool() { return (Selection.activeGameObject != null); }
	[MenuItem("CCR/GJC_CreatGapCoins", false, 0)]
	static public void GJC_CreatGapCoins()
	{
		Vector3 mTrainPosx = new Vector3(190.335f, 190.335f, 191.935f);
		Vector3 mTrainPosy = new Vector3(0.669f, 0.669f, 0.071f);
		makeCoin(mTrainPosx, mTrainPosy, 0);
	}

	[MenuItem("CCR/GJC_CreatParabolaCoins", true)]
	static public bool GJC_CreatParabolaCoinBool() { return (Selection.activeGameObject != null); }
	[MenuItem("CCR/GJC_CreatParabolaCoins", false, 0)]
	static public void GJC_CreatParabolaCoins()
	{
		GameObject hurdle;
		float mDis;
		float mPoint;
		Vector3 mHurdlePos;
		Vector3 mBeginPos = new Vector3(0, 0, 0);

		hurdle = Selection.activeGameObject;
		if (hurdle.tag != "hurdle")
		{
			//Debug.Log("Selected is not hurdle!");
			return;
		}
		else
		{
			mHurdlePos = hurdle.transform.position;
			mPoint = Vector2.Distance(new Vector2(mHurdlePos.x, mHurdlePos.z), Vector2.zero);
			if (mPoint < 190.186f)
			{
				mBeginPos.y = 0.969f;
			}
			if (mPoint >= 190.186f && mPoint <= 191.786f)
			{
				mBeginPos.y = 0.370f;
			}
			if (mPoint > 191.786f)
			{
				mBeginPos.y = -0.229f;
			}

			mDis = Vector2.Distance(new Vector2(mHurdlePos.x, mHurdlePos.z - 5), Vector2.zero);
			if (mPoint < 190.186f)
			{
				mBeginPos.x = mHurdlePos.x + 189.535f - mDis;
			}
			if (mPoint >= 190.186f && mPoint <= 191.786f)
			{
				mBeginPos.x = mHurdlePos.x + 191.126f - mDis;
			}
			if (mPoint > 191.786f)
			{
				mBeginPos.x = mHurdlePos.x + 192.586f - mDis;
			}
			mBeginPos.z = mHurdlePos.z - 5;
			MakeCoins.hurdleCoin(mBeginPos);
		}
	}

	static public void makeCoin(Vector3 _curPosx, Vector3 _curPosy, int _coinNum) 
	{
		Vector3 mCoinPos = new Vector3(0, 0, 0);
		Vector2 mPoint = new Vector2(0, 0);
		float mAngle;
		GameObject coin;

		coin = Selection.activeGameObject;
		if (coin.tag != "coin")
		{
			//Debug.Log("Selected is not coin.");
			return;
		}
		else
			mCoinPos = coin.transform.position;
		float mDis = Vector2.Distance(new Vector2(mCoinPos.x, mCoinPos.z), Vector2.zero);
		if (mDis < 190.186f)
		{
			mCoinPos.x += _curPosx.x - mDis;
			mCoinPos.y = mPoint.y = _curPosy.x;
			mPoint.x = _curPosx.x;
		}
		if (mDis >= 190.186f && mDis <= 191.786f)
		{
			mCoinPos.x += _curPosx.y - mDis;
			mCoinPos.y = mPoint.y = _curPosy.y;
			mPoint.x = _curPosx.y;
		}
		if (mDis > 191.786f)
		{
			mCoinPos.x += _curPosx.z - mDis;
			mCoinPos.y = mPoint.y = _curPosy.z;
			mPoint.x = _curPosx.z;
		}
		coin.transform.position = mCoinPos;
		mAngle = -Cmm.GetAngleFromRightToVector(mCoinPos.x, mCoinPos.z);
		coin.transform.rotation = Quaternion.Euler(0, mAngle, 0) * Quaternion.Euler(0, 0, -20);
		MakeCoins.bottomCoin(mCoinPos, mPoint, _coinNum);
	}
	static public Vector3 GetLanePos(Transform _trans, LaneIdx _laneIdx)
	{
		Vector3 mObjPos = _trans.position;
// 		float mAngle;
// 		float mDis = Vector2.Distance(new Vector2(mObjPos.x, mObjPos.z), Vector2.zero);

		if (_laneIdx == LaneIdx.left)
		{
// 			mObjPos.x += 189.386f - mDis;
// 			mObjPos.y = 0.599f;

            mObjPos.x=-1.6f;
		}
		if (_laneIdx == LaneIdx.right) 
		{
// 			mObjPos.x += 192.586f - mDis;
// 			mObjPos.y = -0.599f; 
            mObjPos.x = 1.6f;
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
	[MenuItem("CCR/HGN_setPosition of coins at correct position", true)]
	static public bool HGN_setPosOfCoinsBool() { return (Selection.activeGameObject != null); }
	[MenuItem("CCR/HGN_setPosition of coins at correct position", false, 0)]
	static public void HGN_setPosOfCoins()
	{
		if (!Selection.activeGameObject)
		{
			//Debug.Log("GameObject null");
			return;
		}
		Vector3 []coins = new Vector3[100];
		int nCnt = 0;
		foreach (GameObject c in Selection.gameObjects)
		{
			if(c.name == "pfCoin")
			{
				coins[nCnt] = c.transform.position;
				nCnt ++;
			}
		}
		
		Vector3 tmp = new Vector3();
		for(int i = 1; i < nCnt; i++)
		{
			if(coins[0].z > coins[i].z )
			{
				tmp = coins[0];
				coins[0] = coins[i];
				coins[i] = tmp;
			}
		}
		for(int j = 1; j < nCnt; j++)
		{
			if( coins[j].x == 0.8 || coins[j].x == -0.8 || coins[j - 1].x == 0.8 || coins[j - 1].x == -0.8)
			{
				coins[j].z = coins[j - 1].z + 1;
			}
			else
			{
				coins[j].z = coins[j - 1].z + 2;
			}
		}
		int index = 0;
		foreach (GameObject c in Selection.gameObjects)
		{
			if (c.name == "pfCoin")
			{
				c.transform.position = coins[index];
				index ++;
			}
		}
	}
	[MenuItem("CCR/HGN_setSameZPosition", true)]
	static public bool HGN_setSameZPosOfCoinsBool() { return (Selection.activeGameObject != null); }
	[MenuItem("CCR/HGN_setSameZPosition", false, 0)]
	static public void HGN_setSameZPosOfCoins()
	{
		if (!Selection.activeGameObject)
		{
			//Debug.Log("GameObject null");
			return;
		}
		Vector3 coin = new Vector3();
		int nCnt = 0;
		foreach (GameObject c in Selection.gameObjects)
		{
			// (c.name == "pfCoin")
			{
				if(nCnt == 0)
					coin = c.transform.position;
				else
				{
					coin.Set(c.transform.position.x, c.transform.position.y, coin.z);
					c.transform.position = coin;
				}
				nCnt++;
			}
		}

	}

	[MenuItem("CCR/HGN_setPosition of CartTroup", true)]
	static public bool HGN_setPosOfCartTroupBool() { return (Selection.activeGameObject != null); }
	[MenuItem("CCR/HGN_setPosition of CartTroup", false, 0)]
	static public void HGN_setPosOfCartTroup()
	{
		if (!Selection.activeGameObject)
		{
			//Debug.Log("GameObject null");
			return;
		}
		Vector3[] coins = new Vector3[100];
		int nCnt = 0;
		foreach (GameObject c in Selection.gameObjects)
		{
            if (c.name == "pfCartTroupe" || c.name == "pfCartStand" || c.name == "pfRunTroupe" || c.name == "pfRunStand")
			{
				coins[nCnt] = c.transform.position;
				nCnt++;
			}
		}

		Vector3 tmp = new Vector3();
		for (int i = 1; i < nCnt; i++)
		{
			if (coins[0].z > coins[i].z)
			{
				tmp = coins[0];
				coins[0] = coins[i];
				coins[i] = tmp;
			}
		}
		for (int j = 1; j < nCnt; j++)
		{
			
			{
				coins[j].z = coins[j - 1].z + 3.2f;
			}
		}
		int index = 0;
		foreach (GameObject c in Selection.gameObjects)
		{
            if (c.name == "pfCartTroupe" || c.name == "pfCartStand" || c.name == "pfRunTroupe" || c.name == "pfRunStand")
			{
				c.transform.position = coins[index];
				index++;
			}
		}
	}
}
#endif
