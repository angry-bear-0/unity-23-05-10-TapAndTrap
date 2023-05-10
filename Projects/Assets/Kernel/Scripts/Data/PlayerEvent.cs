using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerEventKind
{
	none,

	//input animation
	moveRight,
	moveLeft,
	jump,
	roll,
	saluteLeft,
	saluteRight,
	stunt,
	shield,
	pickLeft,
	pickRight,
	fly,
	trampoline,
	stumble,
	x2,
	magnet,
	balloon,
	run,
	food,
	superFood,
	headStart,
	scoreBoost,

	rebirth,
	score,
	getCoin,
	buyPet,
	buyAvatar,
	buyStunt,	//param 0:normal, 1:good, 2:high
	missionSet,
	levelUp,	

	cnt,
}

public class PlayerEventBase
{
	public int			value		{ get; protected set; } = 0;

	protected bool				mInOneRun	= false;

	public PlayerEventBase(bool _inOneRun) { mInOneRun = _inOneRun; }

	public virtual	void OnInit()	
	{
		if (mInOneRun)
			value = 0;
	}
	public virtual	bool OnEvent(PlayerEventKind _event, int _param = 1)	{ return false; } //if processed, return true;

	public void InitForcely() { value = 0; }
}
