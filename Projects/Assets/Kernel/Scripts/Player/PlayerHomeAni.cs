using UnityEngine;

public class PlayerHomeAni : PlayerAniBase
{
	private static int mPetCondition = -1;
	public  bool Init
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
		InitComponent();
		mInitedHome	= true;
		mPlayer		= gameObject.GetComponent<Player>();
    }
	void initGame()
	{
		if(mInitedGame)
			return;
		InitComponent();
		changeHeroParent(true);
		mAniHero.Play("heroIdle");
		mAniPet.Play("petStandIdle");
		mInitedGame			= true;
		mIsHeroOnPetRoot	= false;
	}
	public void InitComponent()
	{
		mAniHero	= GameMgr.hero.GetComponent<Animation>();
		mAniPet		= gameObject.GetComponent<Animation>();
		mTrHero		= GameMgr.heroTr;
	}
	// Use this for initialization
	void Start () 
	{
		initHome();
	}
	
	// Update is called once per frame
	void Update () 
	{
		initGame();
		
		if(GameMgr.gameState != GameState.home)
			return;
		
		int nRnd = Random.Range(0, 35);
		if (!mAniHero.isPlaying)
        {
			if (Util.IsInPercent(50))
				mAniHero.CrossFadeQueued("heroIdle", 0.2f);
            
			mAniHero.CrossFadeQueued("heroRest" + Util.IntRandom(0, 5), 0.2f);
			mAniHero.CrossFadeQueued("heroIdle", 0.2f);
        }

		if ((float)GD.dtPetHp / GD.targetHp >= 0.45f)
		{
			GD.petMultiplier = 1f;
			GD.petCondition = 2;
			DoAction(ActionKind.petStand);
		}
		else if ((float)GD.dtPetHp / GD.targetHp >= 0.15f)
		{
			GD.petMultiplier = 0.7f;
			GD.petCondition = 1;
			DoAction(ActionKind.petSit);
		}
		else
		{
			GD.petMultiplier = 0.4f;
			GD.petCondition = 0;
			DoAction(ActionKind.petLie);
		}
	}
	public void DoAction(ActionKind _action)
	{
		switch(_action)
		{
		case ActionKind.rest:
			mAniPet.CrossFade("petRest0", 0.1f);
			mAniHero.CrossFade("heroRest0", 0.1f);
			mPrevAction = mCurAction;
			mCurAction = _action;
			break;
		case ActionKind.petLie:
			if (mPetCondition == -1)
			{ 
				mAniPet.Play("petLieIdle");
			}
			else
			{
				if(mAniPet.isPlaying)
					break;

				if(GD.petCondition != mPetCondition)
				{ 
					mAniPet.CrossFade("petLie", 0.1f);
					mAniPet.CrossFadeQueued("petLieIdle", 0.25f);
				}
				else
				{ 
					mAniPet.CrossFade("petLieIdle", 0.1f);
				}
			}
			mPetCondition	= GD.petCondition;
			mPrevAction		= mCurAction;
			mCurAction		= _action;
			break;
		case ActionKind.petSit:
			if(mPetCondition == -1)
			{ 
				mAniPet.Play("petSitIdle");
			}
			else
			{
				if(mAniPet.isPlaying)
					break;
				
				if(GD.petCondition != mPetCondition)
				{
					if(mPetCondition == MD.petConditionBad)
						mAniPet.CrossFade("petSitUp", 0.1f);
					else
						mAniPet.CrossFade("petSitDown", 0.1f);

					mAniPet.CrossFadeQueued("petSitIdle", 0.25f);
				}
				else
					mAniPet.CrossFade("petSitIdle", 0.15f);
			}

			mPetCondition   = GD.petCondition;
			mPrevAction     = mCurAction;
			mCurAction      = _action;
			break;
		case ActionKind.petStand:
			if(mPetCondition == -1)
			{
				mAniPet.Play("petStandIdle");
			}
			else
			{
				if(mAniPet.isPlaying)
					break;
				if(GD.petCondition != mPetCondition)
				{
					mAniPet.CrossFade("petStand", 0.15f);
					mAniPet.CrossFadeQueued("petStandIdle", 0.25f);
				}
				else
				{
					if(Util.IsInPercent(50))
						mAniPet.CrossFadeQueued("petStandIdle");

					mAniPet.CrossFadeQueued("petRest" + Util.IntRandom(0, 5), 0.1f);
					mAniPet.CrossFadeQueued("petStandIdle", 0.25f);
				}
			}
			mPetCondition   = GD.petCondition;
			mPrevAction     = mCurAction;
			mCurAction      = _action;
			break;
		case ActionKind.petBody:
			if(mAniPet.IsPlaying("petStrokeBody1") ||mAniPet.IsPlaying("petStrokeBody2") ||mAniPet.IsPlaying("petStrokeNeck1") ||mAniPet.IsPlaying("petStrokeNeck2") || mAniPet.IsPlaying("petStrokeLeg1") ||mAniPet.IsPlaying("petStrokeLeg2"))
				break;
			if(Util.IsInPercent(50))
			{
				mAniPet.CrossFade("petStrokeBody1", 0.1f);
				mAniPet.CrossFadeQueued("petStandIdle", 0.25f);
				mAniHero.CrossFade("heroStrokeBody1",0.1f);
				mAniHero.CrossFadeQueued("heroIdle",0.25f);
			}
			else
			{
				mAniPet.CrossFade("petStrokeBody2", 0.1f);
				mAniPet.CrossFadeQueued("petStandIdle", 0.25f);
				mAniHero.CrossFade("heroStrokeBody2", 0.1f);
				mAniHero.CrossFadeQueued("heroIdle",0.25f);
			}
			mPrevAction = mCurAction;
			mCurAction = _action;
			break;
		case ActionKind.petLeg:
			if(mAniPet.IsPlaying("petStrokeBody1") ||mAniPet.IsPlaying("petStrokeBody2") ||mAniPet.IsPlaying("petStrokeNeck1") ||mAniPet.IsPlaying("petStrokeNeck2") || mAniPet.IsPlaying("petStrokeLeg1") ||mAniPet.IsPlaying("petStrokeLeg2"))
				break;
			if(Util.IsInPercent(50))
			{
				mAniPet.CrossFade("petStrokeLeg1", 0.1f);
				mAniPet.CrossFadeQueued("petStandIdle", 0.25f);
				mAniHero.CrossFade("heroStrokeLeg1", 0.1f);
				mAniHero.CrossFadeQueued("heroIdle",0.25f);
			}
			else
			{
				mAniPet.CrossFade("petStrokeLeg2", 0.1f);
				mAniPet.CrossFadeQueued("petStandIdle", 0.25f);
				mAniHero.CrossFade("heroStrokeLeg2", 0.1f);
				mAniHero.CrossFadeQueued("heroIdle",0.25f);
			}
			mPrevAction = mCurAction;
			mCurAction = _action;
			break;
		case ActionKind.petNeck:
			if(mAniPet.IsPlaying("petStrokeBody1") ||mAniPet.IsPlaying("petStrokeBody2") ||mAniPet.IsPlaying("petStrokeNeck1") ||mAniPet.IsPlaying("petStrokeNeck2") || mAniPet.IsPlaying("petStrokeLeg1") ||mAniPet.IsPlaying("petStrokeLeg2"))
				break;
			if(Util.IsInPercent(50))
			{
				mAniPet.CrossFade("petStrokeNeck1", 0.1f);
				mAniPet.CrossFadeQueued("petStandIdle", 0.25f);
				mAniHero.CrossFade("heroStrokeNeck1", 0.1f);
				mAniHero.CrossFadeQueued("heroIdle",0.25f);
			}
			else
			{
				mAniPet.CrossFade("petStrokeNeck2", 0.1f);
				mAniPet.CrossFadeQueued("petStandIdle", 0.25f);
				mAniHero.CrossFade("heroStrokeNeck2", 0.1f);
				mAniHero.CrossFadeQueued("heroIdle",0.25f);
			}
			mPrevAction = mCurAction;
			mCurAction = _action;
			break;
		case ActionKind.petEat:
			if(mPetCondition == MD.petConditionGood)
				mAniPet.CrossFade("petStandEat", 0.1f);
			else if(mPetCondition == MD.petConditionNormal)
				mAniPet.CrossFade("petSitEat", 0.1f);
			else if(mPetCondition == MD.petConditionBad)
				mAniPet.CrossFade("petLieEat", 0.1f);
			//mAvtMgr._Barrel.SetActive(true);
			mPrevAction = mCurAction;
			mCurAction = _action;
			break;
		case ActionKind.heroAppear:
			mAniHero.CrossFade("characAppear", 0.1f);
			break;
		}
	}
}
