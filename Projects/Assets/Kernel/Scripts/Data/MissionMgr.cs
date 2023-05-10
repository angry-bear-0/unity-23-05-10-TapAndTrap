using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MissionMgr
{
	const int MISSION_CNT = 11;

	public static MissionInfo mssion1 { get { return mssInfos1[mssIdx1]; } }
	public static MissionInfo mssion2 { get { return mssInfos2[mssIdx2]; } }
	public static MissionInfo mssion3 { get { return mssInfos3[mssIdx3]; } }

	public static MissionInfo getMision(int _idx)
	{
		switch(_idx)
		{
		case 0:	return mssion1;
		case 1:	return mssion2;
		case 2:	return mssion3;
		}

		return null;
	}

	public static List<MissionInfo> mssInfos1 = new  List<MissionInfo>();
	public static List<MissionInfo> mssInfos2 = new  List<MissionInfo>();
	public static List<MissionInfo> mssInfos3 = new  List<MissionInfo>();

	public static int mssIdx1 { get; private set; } = 0;
	public static int mssIdx2 { get; private set; } = 0;
	public static int mssIdx3 { get; private set; } = 0;

	public static void Init()
	{
		if(mssInfos1.Count > 0)
			return;

		mssInfos1.Add(new MssEarnCoinOneRun());
		mssInfos1.Add(new MssJumpOneRun());
		mssInfos1.Add(new MssRollOneRun());
		mssInfos1.Add(new MssMagnetOneRun());
		mssInfos1.Add(new MssTrampolineOneRun());
		mssInfos1.Add(new MssBallonOneRun());
		mssInfos1.Add(new MssShieldOneRun());
		mssInfos1.Add(new MssChangeLaneOneRun());
		mssInfos1.Add(new MssStuntOneRun());
		mssInfos1.Add(new MssWaveHandOneRun());
		mssInfos1.Add(new MssStumbleOneRun());

		mssInfos2.Add(new MssX2OneRun());
		mssInfos2.Add(new MssFlyOneRun());
		mssInfos2.Add(new MssRunWithoutCoin());
		mssInfos2.Add(new MssRunWithoutRoll());
		mssInfos2.Add(new MssRunWithoutChangeLane());
		mssInfos2.Add(new MssRunWithoutJumping());
		mssInfos2.Add(new MssRunWithoutStunting());
		mssInfos2.Add(new MssRunWithoutStumble());
		mssInfos2.Add(new MssRunWithoutShield());
		mssInfos2.Add(new MssRebirthOneRun());
		mssInfos2.Add(new MssFood());

		mssInfos3.Add(new MssMagnet());
		mssInfos3.Add(new MssX2());
		mssInfos3.Add(new MssStunt());
		mssInfos3.Add(new MssCoins());
		mssInfos3.Add(new MssStumbles());
		mssInfos3.Add(new MssTrampoline());
		mssInfos3.Add(new MssFlys());
		mssInfos3.Add(new MssShields());
		mssInfos3.Add(new MssRebirthes());
		mssInfos3.Add(new MssSuperFoods());
		mssInfos3.Add(new MssHeadStarts());
	}

	public static void Load()
	{
		mssIdx1 = ObscuredPrefs.GetInt("mission1Idx", mssIdx1);
		mssIdx2 = ObscuredPrefs.GetInt("mission2Idx", mssIdx2);
		mssIdx3 = ObscuredPrefs.GetInt("mission3Idx", mssIdx3);

		mssInfos1[mssIdx1].Load();
		mssInfos2[mssIdx2].Load();
		mssInfos3[mssIdx3].Load();
	}

	public static void Save()
	{
		ObscuredPrefs.SetInt("mission1Idx", mssIdx1);
		ObscuredPrefs.SetInt("mission2Idx", mssIdx2);
		ObscuredPrefs.SetInt("mission3Idx", mssIdx3);

		mssInfos1[mssIdx1].Save();
		mssInfos2[mssIdx2].Save();
		mssInfos3[mssIdx3].Save();
	}

	public static void OnInit()
	{
		mssInfos1[mssIdx1].OnInit();
		mssInfos2[mssIdx2].OnInit();
		mssInfos3[mssIdx3].OnInit();
	}

	public static void OnEvent(PlayerEventKind _event, int _param = 1)
	{
		mssInfos1[mssIdx1].OnEvent(_event, _param);
		mssInfos2[mssIdx2].OnEvent(_event, _param);
		mssInfos3[mssIdx3].OnEvent(_event, _param);
	}

	public static bool Completed()
	{
		return mssInfos1[mssIdx1].GetProgress() >= 100 && mssInfos2[mssIdx2].GetProgress() >= 100 && mssInfos3[mssIdx3].GetProgress() >= 100;
	}

	public static bool DoNextMissionSet()
	{
		if (!Completed())
			return false;

		mssInfos1[mssIdx1].OnComplete();
		mssIdx1 = (mssIdx1 + 1) % MISSION_CNT;
		mssInfos1[mssIdx1].Load();
		mssInfos1[mssIdx1].OnInit();

		mssInfos1[mssIdx1].OnComplete();
		mssIdx2 = (mssIdx2 + 1) % MISSION_CNT;
		mssInfos2[mssIdx2].Load();
		mssInfos2[mssIdx2].OnInit();

		mssInfos1[mssIdx1].OnComplete();
		mssIdx3 = (mssIdx3 + 1) % MISSION_CNT;
		mssInfos3[mssIdx3].Load();
		mssInfos3[mssIdx3].OnInit();

		return true;
	}

	public static bool BuyMission1()
	{
		if (mssInfos1[mssIdx1].GetProgress() >= 100)
			return false;

		mssInfos1[mssIdx1].InitForcely();
		mssInfos1[mssIdx1].Save();
		mssIdx1 = (mssIdx1 + 1) % MISSION_CNT;
		mssInfos1[mssIdx1].Load();
		mssInfos1[mssIdx1].OnInit();
		return true;
	}

	public static bool BuyMission2()
	{
		if(mssInfos2[mssIdx2].GetProgress() >= 100)
			return false;

		mssInfos2[mssIdx2].InitForcely();
		mssInfos2[mssIdx2].Save();
		mssIdx2 = (mssIdx2 + 1) % MISSION_CNT;
		mssInfos2[mssIdx2].Load();
		mssInfos2[mssIdx2].OnInit();
		return true;
	}

	public static bool BuyMission3()
	{
		if(mssInfos3[mssIdx3].GetProgress() >= 100)
			return false;

		mssInfos3[mssIdx3].InitForcely();
		mssInfos3[mssIdx3].Save();
		mssIdx3 = (mssIdx3 + 1) % MISSION_CNT;
		mssInfos3[mssIdx3].Load();
		mssInfos3[mssIdx3].OnInit();
		return true;
	}
}
