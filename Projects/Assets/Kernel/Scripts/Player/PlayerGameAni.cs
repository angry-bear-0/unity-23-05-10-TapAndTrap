using UnityEngine;
public class PlayerGameAni: PlayerAniBase 
{
	[SerializeField] protected  AudioSource	_SndRun;
	private float	mActionStartTime	= 0;
	private float	mRunIdleTm			= 0;
	private	bool	mEnableRunIdle		= true;
	public bool Init
	{
		set
		{
			mInitedGame = value;
		}
	}
	void initHome()
	{
		if(mInitedHome)
			return;
		mInitedHome = true;

		mPlayer	= GameMgr.player;
		mAniPet		= gameObject.GetComponent<Animation>();
	}
	void initGame()
	{
		if(mInitedGame)
			return;
		mInitedGame			= true;
		mActionStartTime	= 0;
		mRunIdleTm			= Random.Range(4f, 6f);

		mTrHero				= GameMgr.heroTr;
		mAniHero			= mTrHero.GetComponent<Animation>();
		mIsHeroOnPetRoot	= true;
	}
		// Update is called once per frame
	void Update () 
	{
		initHome();
		initGame();
		if(GameMgr.gameState != GameState.play)
			return;
		if(mAniPet.IsPlaying("petMount")) 
			return;
		updateRun();
	}
	private void updateRun()
	{
		if (!mAniHero.isPlaying && mCurAction != ActionKind.fly && !GD.dead)
			recordCurAction(ActionKind.run);

		updateRunIdleAction();

		if(mCurAction == ActionKind.fly)
		{
			if((Time.time - mActionStartTime) <= GD.dtUpgradeFly.val)
			{
				mAniPet.CrossFadeQueued("petFly", 0.1f);
				mAniHero.CrossFadeQueued("heroFly", 0.15f);
			}
		}

		if (mAniPet.IsPlaying("petRun") && mAniHero.IsPlaying("heroRun")) 
		{
			mAniHero["heroRun"].normalizedTime = mAniPet["petRun"].normalizedTime;
		}
	}
	private void doRunAni()
	{
		if (!mIsHeroOnPetRoot)
			return;

		changeHeroParent(false);
		mAniPet.Play("petRun");
        mAniHero.Play("heroRun");
		_SndRun.PlayDelayed(0.2f);

		for(int _idx = 0; _idx < 5; _idx++)
		{
			mAniHero.CrossFadeQueued("heroRun", 0.02f);
			mAniPet.CrossFadeQueued("petRun", 0.02f);
		}
	}
	private void updateRunIdleAction()
	{
		if(!mEnableRunIdle || GD.dead)
			return;

		mRunIdleTm -= Time.deltaTime;
		if (mRunIdleTm > 0 && !mAniPet.isPlaying)
		{
			mAniHero.CrossFade("heroRun", 0.1f);
			mAniPet.CrossFade("petRun", 0.02f);
			if (!_SndRun.isPlaying)
				_SndRun.PlayDelayed(0.1f);
			return;
		}

		if (mAniPet.isPlaying)
			return;

		mRunIdleTm = Random.Range(3f, 5f);
		if (Util.IsInPercent(35))
		{
			mAniHero.CrossFade("heroGeeho", 0.1f);
			Util.PlaySound("sfxSayGiddyup", GD.dtHeroInfos[GD.dtHeroIdx].data.pitch, 0.2f);
			Util.PlaySound("sfxHorseCrying", GD.dtHeroInfos[GD.dtHeroIdx].data.pitch, 0.3f);
			mAniPet.CrossFade("petRun", 0.02f);
			mAniPet.CrossFadeQueued("petRun", 0.02f);
			mAniPet.CrossFadeQueued("petRun", 0.02f);
		}
		else if (Util.IsInPercent(45))
		{
			string heroAniName;
			heroAniName = "heroRunSkill" + Util.IntRandom(1, 4).ToString();
			mAniHero.CrossFade(heroAniName, 0.02f);
			Util.PlaySound("sfxSayWuh", GD.dtHeroInfos[GD.dtHeroIdx].data.pitch);
			mAniPet.CrossFade("petRun", 0.02f);
			mAniPet.CrossFadeQueued("petRun", 0.02f);
			mAniPet.CrossFadeQueued("petRun", 0.02f);
			mAniPet.CrossFadeQueued("petRun", 0.02f);
			GD.newCheers = 2;
		}
		else
		{
			mAniHero.CrossFade("heroLookback", 0.1f);
			mAniPet.CrossFade("petRun", 0.02f);
			mAniPet.CrossFadeQueued("petRun", 0.02f);
			mAniPet.CrossFadeQueued("petRun", 0.02f);
		}
		int n = Util.IntRandom(4, 7);
		for(int _idx = 0; _idx < n; _idx++)
		{
			mAniHero.CrossFadeQueued("heroRun", 0.02f);
			mAniPet.CrossFadeQueued("petRun", 0.02f);
		}
	}
	void doJumpSkill(ActionKind _action)
	{
		int stuntIdx = 0;
		switch(_action)
		{
		case ActionKind.stuntHight:
			stuntIdx = GD.GetJumpSkillIdx(0.15f);
			Util.PlaySound("sfxSayWoohoo", GD.dtHeroInfos[GD.dtHeroIdx].data.pitch);
			break;
		case ActionKind.stuntGood:
			stuntIdx = GD.GetJumpSkillIdx(0.2f);
			Util.PlaySound("sfxSayYipee", GD.dtHeroInfos[GD.dtHeroIdx].data.pitch);
			break;
		case ActionKind.stuntNormal:
			stuntIdx = GD.GetJumpSkillIdx(0.25f);
			Util.PlaySound("sfxSayYay", GD.dtHeroInfos[GD.dtHeroIdx].data.pitch);
			break;
		}
		if (stuntIdx < 0)
			return;

		mAniPet["petJumpSkill"].time = mAniPet["petJump"].time;
		mAniPet["petJumpSkill"].time = mAniPet["petJump"].time;
		mAniPet["petJumpSkill"].weight = 1f;
		mAniPet["petJump"].weight = 0f;

		string sStuntAni = "heroStunt" + stuntIdx.ToString();
		mAniHero[sStuntAni].time = mAniHero["heroJump"].time;
		mAniPet.CrossFade("petJumpSkill", 0.1f);
		mAniHero.CrossFade(sStuntAni, 0.1f);
	}
	public void DoAction(ActionKind _action)
	{
		switch(_action)
		{
		case ActionKind.run:
			GD.collided = false;
			doRunAni();
			break;
		case ActionKind.moveRight:
			mAniPet.CrossFade("petMoveRight", 0.1f);
			mAniHero.CrossFade("heroMoveRight" ,0.1f);
			_SndRun.Stop();
			Util.PlaySound("sfxChangeLane");
			mRunIdleTm = Random.Range(5f, 8f);
			break;
		case ActionKind.moveLeft:
			mAniPet.CrossFade("petMoveLeft", 0.1f);
			mAniHero.CrossFade("heroMoveLeft", 0.1f);
			_SndRun.Stop();
			Util.PlaySound("sfxChangeLane");
			mRunIdleTm = Random.Range(5f, 8f);
			break;
		case ActionKind.jump:
			mAniPet.CrossFade("petJump", 0.1f, PlayMode.StopAll);
			mAniHero.CrossFade("heroJump", 0.1f);
			_SndRun.Stop();
			Util.PlaySound("sfxJump");
			mEnableRunIdle = false;
			mRunIdleTm = Random.Range(3f, 5f);
			break;
		case ActionKind.lower:
			mAniPet.CrossFade("petLower", 0.1f,PlayMode.StopAll);
			mAniHero.CrossFade("heroLower", 0.1f);
			_SndRun.Stop();
			Util.PlaySound("sfxRoll");
			mEnableRunIdle = true;
			mRunIdleTm = Random.Range(3f, 5f);
			break;
		case ActionKind.stuntHight:
		case ActionKind.stuntGood:
		case ActionKind.stuntNormal:
			doJumpSkill(_action);
            break;
		case ActionKind.saluteLeft:
			mAniHero["heroSaluteLeft"].time = mAniHero["heroJump"].time;
			mAniHero.Play("heroSaluteLeft", PlayMode.StopAll);
			break;

		case ActionKind.saluteRight:
			mAniHero["heroSaluteRight"].time = mAniHero["heroJump"].time;
			mAniHero.Play("heroSaluteRight", PlayMode.StopAll);
			break;

		case ActionKind.drop:
			changeHeroParent(true);
			mAniPet.Play("petDrop");
			mAniHero.Play("heroDropBegin");
			mEnableRunIdle = false;
			_SndRun.Stop();
			break;

		case ActionKind.frighten:
			mAniHero.CrossFade("heroDropEnd", 0.1f);
			mEnableRunIdle = false;
			break;

		case ActionKind.stumble:
			mAniPet.CrossFade("petStumble", 0.1f);
			mAniHero.CrossFade("heroStumble", 0.1f);
			mRunIdleTm = Random.Range(7f, 10f);
			break;

		case ActionKind.land:
			mAniPet.CrossFade("petLand", 0.1f);
			mAniHero.CrossFade("heroLand", 0.1f);
			Util.PlaySound("sfxJumpEnd");
			mAniPet.CrossFadeQueued("petRun", 0.1f);
			mAniHero.CrossFadeQueued("heroRun", 0.1f);
			_SndRun.PlayDelayed(0.2f);
			mEnableRunIdle = true;
			mRunIdleTm = Random.Range(3f, 5f);
			break;

		case ActionKind.fall:
			mAniPet.CrossFade("petFall", 0.1f);
			mAniHero.CrossFade("heroFall", 0.1f);
			break;

		case ActionKind.mount:
			mAniPet.CrossFade("petMount", 0.1f);
			mAniHero.CrossFade("heroMount", 0.1f);
			break;
        //item animation
        case ActionKind.spring:
			mEnableRunIdle = false;
            mAniPet.CrossFade("petJumpSkill", 0.1f);
            mAniHero.CrossFade("heroSpring", 0.1f);
			Util.PlaySound("sfxSayWee", GD.dtHeroInfos[GD.dtHeroIdx].data.pitch);
			_SndRun.Stop();
            break;
		case ActionKind.fly:
			mEnableRunIdle = false;
			mAniPet.CrossFade("petFly", 0.1f);
			mAniHero.CrossFade("heroFly", 0.1f);
			Util.PlaySound("sfxSayWee", GD.dtHeroInfos[GD.dtHeroIdx].data.pitch);
			_SndRun.Stop();
			break;
		}
		recordCurAction(_action);
	}
	private void recordCurAction(ActionKind _action)
	{
		if(mCurAction != _action)
			mActionStartTime = Time.time;

		mCurAction	= _action;
	}
}
