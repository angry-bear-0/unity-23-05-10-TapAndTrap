using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionInfo : PlayerEventBase
{
	public int			stage		{ get; protected set; } = 0;
	public int			goal		{ get; protected set; } = 0;
	public string		desc		{ get {return Lang.Format(mDesc, NGUIText.SpaceDigitString(goal));} }

	protected int		mIniValue	= 0;
	protected int		mIncrement	= 1;
	protected string	mDesc = "";
	public float	GetProgress()	{ return Mathf.Min(1, (float) value / goal);}
	public int		GetPriceByGem()	{ return 30 + stage * 10;}

	public MissionInfo(bool _inOneRun, string _desc, int _iniVal, int _inc) : base (_inOneRun) {mDesc = _desc; mIniValue = _iniVal; mIncrement = _inc;}

	public override void OnInit()
	{
		goal    = mIniValue + stage + mIncrement;
		if(mInOneRun)
			value = 0;
	}

	public override bool OnEvent(PlayerEventKind _event, int _param = 1)
	{
		if (value < goal)
			return doEvent(_event, _param);

		return false;
	}

	protected virtual bool doEvent(PlayerEventKind _event, int _param) { return false; }

	public void OnComplete()
	{
		value = 0;
		stage ++;
		Save();
	}

	public void Load()
	{
		stage		= ObscuredPrefs.GetInt(desc + ".stage", stage);
		if (!mInOneRun)
			value = ObscuredPrefs.GetInt(desc + ".value", value);
	}

	public void Save()
	{
		ObscuredPrefs.SetInt(desc + ".stage", stage);
		if(!mInOneRun)
			ObscuredPrefs.SetInt(desc + ".value", value);
	}
}

//0
public class MssEarnCoinOneRun : MissionInfo
{
	public MssEarnCoinOneRun() : base(true, "cdMssEarnCoinOneRun", 500, 500) { }

	protected override bool doEvent(PlayerEventKind _event, int _param = 1)
	{
		if (_event == PlayerEventKind.getCoin)
			value ++;
		return false;
	}
}

//1
public class MssJumpOneRun : MissionInfo
{
	public MssJumpOneRun() : base(true, "cdMssJumpOneRun", 20, 10) { }

	protected override bool doEvent(PlayerEventKind _event, int _param = 1)
	{
		if(_event == PlayerEventKind.jump)
			value++;
		return false;
	}
}

//2
public class MssRollOneRun : MissionInfo
{
	public MssRollOneRun() : base(true, "cdMssRollOneRun", 20, 10) { }

	protected override bool doEvent(PlayerEventKind _event, int _param = 1)
	{
		if(_event == PlayerEventKind.roll)
			value++;
		return false;
	}
}

//3
public class MssMagnetOneRun : MissionInfo
{
	public MssMagnetOneRun() : base(true, "cdMssMagnetOneRun", 3, 1) { }

	protected override bool doEvent(PlayerEventKind _event, int _param = 1)
	{
		if(_event == PlayerEventKind.magnet)
			value++;
		return false;
	}
}

//4
public class MssTrampolineOneRun : MissionInfo
{
	public MssTrampolineOneRun() : base(true, "cdMssTrampolineOneRun", 3, 1) { }

	protected override bool doEvent(PlayerEventKind _event, int _param = 1)
	{
		if(_event == PlayerEventKind.trampoline)
			value++;
		return false;
	}
}

//5
public class MssBallonOneRun : MissionInfo
{
	public MssBallonOneRun() : base(true, "cdMssBallonOneRun", 3, 1) { }

	protected override bool doEvent(PlayerEventKind _event, int _param = 1)
	{
		if(_event == PlayerEventKind.balloon)
			value++;
		return false;
	}
}

//6
public class MssShieldOneRun : MissionInfo
{
	public MssShieldOneRun() : base(true, "cdMssShieldOneRun", 2, 1) { }

	protected override bool doEvent(PlayerEventKind _event, int _param = 1)
	{
		if(_event == PlayerEventKind.shield)
			value++;
		return false;
	}
}

//7
public class MssChangeLaneOneRun : MissionInfo
{
	public MssChangeLaneOneRun() : base(true, "cdMssChangeLaneOneRun", 30, 15) { }

	protected override bool doEvent(PlayerEventKind _event, int _param = 1)
	{
		if(_event == PlayerEventKind.moveRight || _event == PlayerEventKind.moveLeft)
			value++;
		return false;
	}
}

//8
public class MssStuntOneRun : MissionInfo
{
	public MssStuntOneRun() : base(true, "cdMssStuntOneRun", 10, 5) { }

	protected override bool doEvent(PlayerEventKind _event, int _param = 1)
	{
		if(_event == PlayerEventKind.stunt)
			value++;
		return false;
	}
}

//9
public class MssWaveHandOneRun : MissionInfo
{
	public MssWaveHandOneRun() : base(true, "cdMssWaveHandOneRun", 8, 4) { }

	protected override bool doEvent(PlayerEventKind _event, int _param = 1)
	{
		if(_event == PlayerEventKind.saluteLeft || _event == PlayerEventKind.saluteRight)
			value++;
		return false;
	}
}

//10
public class MssStumbleOneRun : MissionInfo
{
	public MssStumbleOneRun() : base(true, "cdMssStumbleOneRun", 3, 1) { }

	protected override bool doEvent(PlayerEventKind _event, int _param = 1)
	{
		if(_event == PlayerEventKind.stumble)
			value++;
		return false;
	}
}

//*************************************************
//11
public class MssX2OneRun : MissionInfo
{
	public MssX2OneRun() : base(true, "cdMssX2OneRun", 3, 1) { }

	protected override bool doEvent(PlayerEventKind _event, int _param = 1)
	{
		if(_event == PlayerEventKind.x2)
			value++;
		return false;
	}
}
//12
public class MssFlyOneRun : MissionInfo
{
	public MssFlyOneRun() : base(true, "cdMssFlyOneRun", 3, 1) { }

	protected override bool doEvent(PlayerEventKind _event, int _param = 1)
	{
		if(_event == PlayerEventKind.fly)
			value++;
		return false;
	}
}
//13
public class MssRunWithoutCoin : MissionInfo
{
	public MssRunWithoutCoin() : base(true, "cdMssRunWithoutCoin", 50, 20) { }

	protected override bool doEvent(PlayerEventKind _event, int _param = 1)
	{
		if(_event == PlayerEventKind.getCoin)
			value = 0;
		if(_event == PlayerEventKind.run)
			value ++;
		return false;
	}
}
//14
public class MssRunWithoutRoll : MissionInfo
{
	public MssRunWithoutRoll() : base(true, "cdMssRunWithoutRoll", 30, 10) { }

	protected override bool doEvent(PlayerEventKind _event, int _param = 1)
	{
		if(_event == PlayerEventKind.roll)
			value = 0;
		if(_event == PlayerEventKind.run)
			value++;
		return false;
	}
}
//15
public class MssRunWithoutChangeLane : MissionInfo
{
	public MssRunWithoutChangeLane() : base(true, "cdMssRunWithoutChangeLane", 20, 7) { }

	protected override bool doEvent(PlayerEventKind _event, int _param = 1)
	{
		if(_event == PlayerEventKind.moveLeft || _event == PlayerEventKind.moveRight)
			value = 0;
		if(_event == PlayerEventKind.run)
			value++;
		return false;
	}
}
//16
public class MssRunWithoutJumping : MissionInfo
{
	public MssRunWithoutJumping() : base(true, "cdMssRunWithoutJumping", 30, 10) { }

	protected override bool doEvent(PlayerEventKind _event, int _param = 1)
	{
		if(_event == PlayerEventKind.moveLeft || _event == PlayerEventKind.moveRight)
			value = 0;
		if(_event == PlayerEventKind.run)
			value++;
		return false;
	}
}
//17
public class MssRunWithoutStunting : MissionInfo
{
	public MssRunWithoutStunting() : base(true, "cdMssRunWithoutStunting", 80, 40) { }

	protected override bool doEvent(PlayerEventKind _event, int _param = 1)
	{
		if(_event == PlayerEventKind.stunt)
			value = 0;
		if(_event == PlayerEventKind.run)
			value++;
		return false;
	}
}
//18
public class MssRunWithoutStumble : MissionInfo
{
	public MssRunWithoutStumble() : base(true, "cdMssRunWithoutStumble", 300, 80) { }

	protected override bool doEvent(PlayerEventKind _event, int _param = 1)
	{
		if(_event == PlayerEventKind.stumble)
			value = 0;
		if(_event == PlayerEventKind.run)
			value++;
		return false;
	}
}
//19
public class MssRunWithoutShield : MissionInfo
{
	public MssRunWithoutShield() : base(true, "cdMssRunWithoutShield", 200, 70) { }

	protected override bool doEvent(PlayerEventKind _event, int _param = 1)
	{
		if(_event == PlayerEventKind.shield)
			value = 0;
		if(_event == PlayerEventKind.run)
			value++;
		return false;
	}
}
//20
public class MssRebirthOneRun : MissionInfo
{
	public MssRebirthOneRun() : base(true, "cdMssRebirthOneRun", 2, 1) { }

	protected override bool doEvent(PlayerEventKind _event, int _param = 1)
	{
		if(_event == PlayerEventKind.rebirth)
			value++;
		return false;
	}
}
//21
public class MssFood : MissionInfo
{
	public MssFood() : base(false, "cdMssFood", 3, 2) { }

	protected override bool doEvent(PlayerEventKind _event, int _param = 1)
	{
		if(_event == PlayerEventKind.food)
			value++;
		return false;
	}
}
//********************************************************************************
//22
public class MssMagnet : MissionInfo
{
	public MssMagnet() : base(false, "cdMssMagnet", 30, 10) { }

	protected override bool doEvent(PlayerEventKind _event, int _param = 1)
	{
		if(_event == PlayerEventKind.magnet)
			value++;
		return false;
	}
}
//23
public class MssX2 : MissionInfo
{
	public MssX2() : base(false, "cdMssX2", 30, 10) { }

	protected override bool doEvent(PlayerEventKind _event, int _param = 1)
	{
		if(_event == PlayerEventKind.x2)
			value++;
		return false;
	}
}
//24
public class MssStunt : MissionInfo
{
	public MssStunt() : base(false, "cdMssStunt", 50, 20) { }

	protected override bool doEvent(PlayerEventKind _event, int _param = 1)
	{
		if(_event == PlayerEventKind.stunt)
			value++;
		return false;
	}
}
//25
public class MssCoins : MissionInfo
{
	public MssCoins() : base(false, "cdMssCoins", 3000, 1000) { }

	protected override bool doEvent(PlayerEventKind _event, int _param = 1)
	{
		if(_event == PlayerEventKind.getCoin)
			value++;
		return false;
	}
}
//26
public class MssStumbles : MissionInfo
{
	public MssStumbles() : base(false, "cdMssStumbles", 30, 10) { }

	protected override bool doEvent(PlayerEventKind _event, int _param = 1)
	{
		if(_event == PlayerEventKind.stumble)
			value++;
		return false;
	}
}
//27
public class MssTrampoline : MissionInfo
{
	public MssTrampoline() : base(false, "cdMssTrampoline", 30, 10) { }

	protected override bool doEvent(PlayerEventKind _event, int _param = 1)
	{
		if(_event == PlayerEventKind.trampoline)
			value++;
		return false;
	}
}
//28
public class MssFlys : MissionInfo
{
	public MssFlys() : base(false, "cdMssFlys", 30, 10) { }

	protected override bool doEvent(PlayerEventKind _event, int _param = 1)
	{
		if(_event == PlayerEventKind.fly)
			value++;
		return false;
	}
}
//29
public class MssShields : MissionInfo
{
	public MssShields() : base(false, "cdMssShields", 15, 5) { }

	protected override bool doEvent(PlayerEventKind _event, int _param = 1)
	{
		if(_event == PlayerEventKind.shield)
			value++;
		return false;
	}
}
//30
public class MssRebirthes : MissionInfo
{
	public MssRebirthes() : base(false, "cdMssRebirthes", 12, 4) { }

	protected override bool doEvent(PlayerEventKind _event, int _param = 1)
	{
		if(_event == PlayerEventKind.rebirth)
			value++;
		return false;
	}
}
//31
public class MssSuperFoods : MissionInfo
{
	public MssSuperFoods() : base(false, "cdMssSuperFoods", 2, 1) { }

	protected override bool doEvent(PlayerEventKind _event, int _param = 1)
	{
		if(_event == PlayerEventKind.superFood)
			value++;
		return false;
	}
}
//32
public class MssHeadStarts : MissionInfo
{
	public MssHeadStarts() : base(false, "cdMssHeadStarts", 6, 2) { }

	protected override bool doEvent(PlayerEventKind _event, int _param = 1)
	{
		if(_event == PlayerEventKind.headStart)
			value++;
		return false;
	}
}