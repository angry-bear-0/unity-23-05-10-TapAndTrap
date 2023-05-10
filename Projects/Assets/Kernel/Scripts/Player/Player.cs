using System.Collections;
using UnityEngine;
public class Player : MonoBehaviour 
{
	public enum LayerKind
	{
		none,
		item		= 9,
		floor		= 11,
		obstacle	= 12,
		stumble		= 13,
	}
	private enum ImpactX
	{
		Left,
		Middle,
		Right
	}

	private enum ImpactY
	{
		Upper,
		Middle,
		Lower,
		over
	}

	private enum ImpactZ
	{
		Before,
		Middle,
		After
	}
	private const float		CHANGE_LANE_SPEED		= 8f;

	private const float		ROLL_TIME				= 0.875f;
	private Vector3			PLAYER_LOWER_CENTER		= new Vector3(0, 0.25f, 0.0f);
	private Vector3			PLAYER_NORMAL_CENTER	= new Vector3(0, 0.5f,  0.0f);
									
			
	public Transform			_PetRoot			= null;
	public Transform			_PetPelvise			= null;
	public GameObject			_Balloon			= null;
	public GameObject			_Cloud				= null;
	public CharacterController	_Ctrlr				= null;
	public	Transform		trCollisionObj			= null;
	private Transform		mTransform				= null;

	private	PlayerGameAni	mGameAni;
    private PlayerHomeAni   mHomeAni;
	private Tracker			mTracker;
	private AvtGame			mAvtGame				= null;

	private bool			mInitedGame				= false;
	private bool			mInitedHome				= false;
	private bool			mIsStart				= false;

	private JumpKind		mJumpKind				= JumpKind.none;
	private float			mJumpCurTm				= 0;
	private	float			mJumpDuration			= 0;

	private float			mRollingTm				= 0;
	
	private LaneIdx			mCurLane				= LaneIdx.center;

	private int				mOldDist				= 0;
	
	private float			mCurZ					= 0f;
	private float			mCurX					= 0f;					
	private float			mCurY					= 0f;
	private float			mDstX					= 0f;
	private float			mLastGroundY			= 0f;
	private float			mLastY					= 0f;
	private float			mGravity				= MD.gravity;

	private Vector3			mVtr3Temp				= Vector3.zero;
	private Ray				mRay					= new Ray();
	private bool			mIsFall					= false;
	private bool			mCheckFall				= false;
	private float			mBalloonTm				= 0f;

	private InputKind		mCurInput				= InputKind.none;
	private InputKind		mPrevInput				= InputKind.none;
	private float			mCurInputTime			= 0f;
	private float			mLastInputTime			= 0f;
	private float			mCollidedTm				= 0f;
	
	private int				mLayerFloorMask			= 0;
	private bool			mIsDrop					= false;
	private int				mLayerObsMask			= 0;
	private float			mFallHeight				= 0;
	
	private SkinnedMeshRenderer[]	mMesh;

	private bool isRolling	{ get { return mRollingTm > 0; } }
	private bool hasBalloon { get { return mBalloonTm > 0; } }
	public bool IsItemJump	{ get {	return mJumpKind == JumpKind.fly || mJumpKind == JumpKind.spring; }	}

	private bool isGround
	{
		get
		{
// 			Vector3 vStart = mTransform.position + Vector3.up * (0.25f - _Ctrlr.skinWidth - 0.01f);
// 			return Physics.CheckSphere(vStart, 0.25f, mLayerFloorMask);

// 			mRay.origin = mTransform.position + Vector3.up * (0.25f - _Ctrlr.skinWidth - 0.01f);
// 			mRay.direction = Vector3.down;
// 			return Physics.Raycast(mRay, 0.25f, mLayerFloorMask);
			
			return _Ctrlr.isGrounded;
		}
	}
	private void initHome()
	{
		if(mInitedHome)
			return;
		mInitedHome		= true;
		mTransform		= transform;
        
		mTracker		= GameMgr.tracker;
		mGameAni	= gameObject.GetComponent<PlayerGameAni>();
        mHomeAni	= GetComponent<PlayerHomeAni>();

		mLayerFloorMask = 1 << (int)LayerKind.floor;
		mLayerObsMask	= 1 << (int)LayerKind.obstacle;
	}
	void Start()
	{
		mTransform = transform;

		mGameAni = gameObject.GetComponent<PlayerGameAni>();
		mHomeAni = GetComponent<PlayerHomeAni>();
	}
	void initGame()
	{
		if(mInitedGame)
			return;
		mGameAni.Init = false;
		mInitedGame = true;
		mAvtGame		= AvtGame.instance;
		mCurInput		= InputKind.none;
		mPrevInput		= InputKind.none;
		mCurLane		= LaneIdx.center;
		mCurInputTime	= 0f;
		mLastInputTime	= 0f;
		mJumpKind		= JumpKind.none;
		mGravity		= MD.gravity;
		GD.speed		= 0;
		mCurZ			= 0f;
		mCurX			= 0f;
		mDstX			= 0f;
		mLastGroundY	= 0;
		mIsStart		= false;
		mIsDrop			= false;
		mIsFall			= false;
		mBalloonTm		= 0;
		mMesh			= gameObject.GetComponentsInChildren<SkinnedMeshRenderer>();
		_Ctrlr.detectCollisions	= true;
		GD.dist     = 0;
		mOldDist    = 0;
	}
	public void Reset()
	{
		mIsStart = false;

		if(mBalloonTm > 0f)
		{
			_Balloon.SetActive(false);
			mBalloonTm = 0f;
		}
		if(GD.usingShield)
		{
			ActiveShield(false);
		}
		if(_Cloud.activeSelf)
			_Cloud.SetActive(false);
		mInitedGame = false;
		transform.position = Vector3.zero;

		mHomeAni.Init = false;
		mGameAni.Init = false;
		doAction(ActionKind.stop, InputKind.none, true, true);
		mTracker.Reset();
		GD.dist     = 0;
		mOldDist    = 0;
	}
	//Move Functions
	private void onRollBegin()
	{
		if (isRolling || mJumpKind == JumpKind.fly || mJumpKind == JumpKind.spring)
			return;

		if (mJumpKind != JumpKind.none)
		{
			onJumpEnd();
			mGravity	= MD.gravity;
		}

		mRollingTm		= ROLL_TIME;
		_Ctrlr.center	= PLAYER_LOWER_CENTER;
		_Ctrlr.height	= MD.playerLowHeight;
		PlayerEventMgr.inst.OnEvent(PlayerEventKind.roll);
		doAction(ActionKind.lower, InputKind.down, true, true);
	}
	private void onRollEnd()
	{
		mRollingTm		= 0;
		_Ctrlr.height	= MD.playerNormalHeight;
		_Ctrlr.center	= PLAYER_NORMAL_CENTER;
	}
	private void onJumpBegin()
	{
		if (mIsFall || (mJumpKind == JumpKind.normal && mLastInputTime - mCurInputTime > 0.25f) || mJumpKind == JumpKind.spring || mJumpKind == JumpKind.fly ||  mJumpKind == JumpKind.stunt)
			return;

		if (isRolling)
			onRollEnd();

		float fDblUpTime = mLastInputTime - mCurInputTime;
		if (mJumpKind == JumpKind.none)
		{
			mJumpKind       = JumpKind.normal;
			mJumpCurTm      = 0f;
			mLastY			= 0f;
			mJumpDuration   = MD.jumpNormalTm;
			mGravity		= MD.gravity;
			doAction(ActionKind.jump, InputKind.up, true, true);
			PlayerEventMgr.inst.OnEvent(PlayerEventKind.jump);
		}
		else if (fDblUpTime <= 0.25f && mJumpKind == JumpKind.normal)
		{
			mJumpKind       = JumpKind.stunt;
			mJumpDuration   = MD.jumpSkillTm;
			if (fDblUpTime <= 0.15f && GD.GetJumpSkillIdx(0.15f) > -1)
			{
				doAction(ActionKind.stuntHight, InputKind.up, true, true);
				GD.newCheers = 3;
			}
			else if (fDblUpTime <= 0.20f && GD.GetJumpSkillIdx(0.20f) > -1)
			{
				doAction(ActionKind.stuntGood, InputKind.up, true, true);
				GD.newCheers = 4;
			}
			else
			{
				doAction(ActionKind.stuntNormal, InputKind.up, true, true);
				GD.newCheers = 5;
			}
			PlayerEventMgr.inst.OnEvent(PlayerEventKind.stunt);
		}
	}
	private void onJumpEnd()
	{
		if(mJumpKind != JumpKind.none)
		{
			mJumpKind	= JumpKind.none;
		}
	}
	private void changeLane(InputKind _input)
	{
		if (_input == InputKind.right)
		{
			if (mCurLane != LaneIdx.right)
			{
				mDstX += MD.laneWidth;
				if (mCurLane == LaneIdx.center) 
					mCurLane = LaneIdx.right;
				else if (mCurLane == LaneIdx.left) 
					mCurLane = LaneIdx.center;
				PlayerEventMgr.inst.OnEvent(PlayerEventKind.moveRight);
			}
			else
			{
				if (mJumpKind == JumpKind.none)
				{
					onCollisionStumble();
				}
				else if (mPrevInput != InputKind.right && mJumpKind == JumpKind.normal)
				{
					doAction(ActionKind.saluteRight);
					PlayerEventMgr.inst.OnEvent(PlayerEventKind.saluteRight);
				}
			}
		}
		else if (_input == InputKind.left)
		{
			if (mCurLane != LaneIdx.left)
			{
				mDstX -= MD.laneWidth;
				if (mCurLane == LaneIdx.center) mCurLane = LaneIdx.left;
				else if (mCurLane == LaneIdx.right) mCurLane = LaneIdx.center;
				PlayerEventMgr.inst.OnEvent(PlayerEventKind.moveLeft);
			}
			else
			{
				if (mJumpKind == JumpKind.none)
				{
					onCollisionStumble();
				}
				else if (mPrevInput != InputKind.left && mJumpKind == JumpKind.normal)
				{
					doAction(ActionKind.saluteLeft);
					PlayerEventMgr.inst.OnEvent(PlayerEventKind.saluteLeft);
				}
			}
		}
	}
	private void onDrop()
	{
		StartCoroutine(StartDropCoroutine());
		mIsDrop = true;

		GD.dead = true;
	}
	private void updateMoveForward()
	{
		//update speed of character
		if (GD.dead)
			GD.speed = 0;
		else if(GD.speed < MD.maxSpeed)
			GD.speed = 8 * (1 + MD.accel * mCurZ / 1000);

		//update Z value.
		mCurZ += GD.speed * Time.deltaTime;
		GD.dist = Mathf.FloorToInt(mCurZ);

		if (mOldDist != GD.dist)
		{
			int diff = GD.dist - mOldDist;
			PlayerEventMgr.inst.OnEvent(PlayerEventKind.run, diff);
			int score = Mathf.Min(1, Mathf.FloorToInt(diff * (GD.petMultiplier * GD.multiplier)));
			GD.earnedScore += score;
			PlayerEventMgr.inst.OnEvent(PlayerEventKind.score, score);
			mOldDist = GD.dist;
		}
	}
	private void updateChangeLane()
	{
		mCurX = Mathf.Lerp(mCurX, mDstX, CHANGE_LANE_SPEED * Time.deltaTime);
	}
	private void updateMoveWithGravity()
	{
		Vector3 pos = mTransform.position;
		if(mJumpKind != JumpKind.none)
		{
			mJumpCurTm += Time.deltaTime;
			if(mJumpCurTm <= mJumpDuration)
			{
				float tm = mJumpCurTm / mJumpDuration;
				float y = 0;
				if(mJumpKind == JumpKind.normal)
					y = (hasBalloon ? MD.leapH : MD.jumpH) * GameMgr.inst._AniCurve.GetValue(tm, JumpKind.normal);
				else if(mJumpKind == JumpKind.stunt)
					y = (hasBalloon ? MD.leapH : MD.jumpH) * GameMgr.inst._AniCurve.GetValue(tm, JumpKind.stunt);
				else if(mJumpKind == JumpKind.spring)
					y = MD.springH * GameMgr.inst._AniCurve.GetValue(tm, JumpKind.spring);
				else if(mJumpKind == JumpKind.fly)
					y = MD.flyH * GameMgr.inst._AniCurve.GetValue(tm, JumpKind.fly);

				mGravity= y - mLastY;
				mCurY	= pos.y + mGravity;
				mLastY	= y;

				if(mJumpKind == JumpKind.fly)
				{ 
					mCurY = Mathf.Min(mCurY, MD.flyH);
				}
				else if (mJumpCurTm > 0.15f) //check jump to track
				{
					if(isGround)
					{
						onJumpEnd();
						mGravity    = MD.gravity;
						doAction(ActionKind.land);
					}
				}
			}
			else
			{
				if(mJumpKind == JumpKind.fly)
				{
					if(mJumpCurTm > GD.dtUpgradeFly.val)
					{
						mJumpKind = JumpKind.none;
						doAction(ActionKind.fall, InputKind.none, true, true);
						mIsFall     = true;
						mGravity    = MD.gravity;
						_Cloud.SetActive(false);
					}
				}
				else
				{
					onJumpEnd();
					
					if (isGround)
					{
						mIsFall		= false;
						doAction(ActionKind.land);
					}
					else
					{
						doAction(ActionKind.fall, InputKind.none, true, true);
						mIsFall		= true;
						mGravity	= Mathf.Max(mGravity / (Time.smoothDeltaTime * Time.smoothDeltaTime), MD.gravity);
					}
				}
			}
		}
		
		if(isGround)
		{
			mCheckFall = false;
			if(mIsFall)
			{
				mIsFall     = false;
				mGravity    = MD.gravity;
				doAction(ActionKind.land);
			}
			else
			{
				if(mJumpKind == JumpKind.none)
				{
					mLastGroundY    = pos.y;
					mCurY           = pos.y - 0.01f;
				}
			}
		}
		else
		{
			if(mJumpKind == JumpKind.none)
			{
				if(!mIsFall && !mCheckFall)
				{
					mCheckFall	= true;
					mGravity    = MD.gravity;
					mFallHeight	= pos.y;
				}
				else if (mCheckFall && !mIsFall && !isRolling && mFallHeight - pos.y > 0.03f)
				{
					doAction(ActionKind.fall, InputKind.none, true, true);
					mIsFall		= true;
					mGravity    = MD.gravity;
					mCheckFall	= false;
				}
				mGravity += MD.gravity * Time.deltaTime;
				mCurY = pos.y + mGravity * Time.deltaTime;
			}
		}

		if(mIsDrop)
		{
			GameMgr.heroTr.parent = _PetRoot;
			GameMgr.heroTr.localPosition = Vector3.zero;
			GameMgr.heroTr.localRotation = Quaternion.identity;
			mCurZ = pos.z;
			moveToGround();
		}
	}
	private void moveToGround()
	{
		RaycastHit rh;
		mRay.origin = mTransform.position + Vector3.up * 0.25f;

		mRay.direction = Vector3.down;

		if(Physics.Raycast(mRay, out rh, 20f, mLayerFloorMask))
		{
			mCurY = rh.point.y;
		}
		else
		{
			mCurY = mTransform.position.y;
		}
	}

	private void updateUseBalloon()
	{
		if (mBalloonTm > 0f)
		{
			mBalloonTm -= Time.deltaTime;
			if (mBalloonTm <= 0f)
			{
				_Balloon.SetActive(false);
			}
		}
	}
	public void Fly()
	{
		mJumpKind = JumpKind.fly;
		GD.flying = true;
        PlayerEventMgr.inst.OnEvent(PlayerEventKind.fly);
        GD.Save();
		doAction(ActionKind.fly);
		mJumpCurTm		= 0f;
		mLastY			= 0;
		mJumpDuration	= MD.jumpFlyTm;
		mAvtGame.UseItemFly();
		mVtr3Temp = mTransform.position;
		mVtr3Temp += Vector3.forward * (MD.jumpFlyTm * GD.speed);
		RoadMaker.mInst.setFlyCoin(mVtr3Temp);
		_Cloud.SetActive(true);
	}
	public void StartRun()
	{
		if(GameMgr.gameState != GameState.play)
			return;
		mIsStart	= true;
		doAction(ActionKind.run);
		mTracker.StartRun();
		if(GD.rebirthing)
		{
			doAction(ActionKind.stop, InputKind.none, true, true);
			GD.dead = false;
			mIsDrop = false;
			mAvtGame.activeShieldBtn(true);
            if(mBalloonTm > 0f)
			{
				_Balloon.SetActive(false);
				mBalloonTm = 0f;
			}
			Instantiate(Resources.Load("Prefabs/Particle/ptcRelife"), GameMgr.inst._MainCam.transform/* .instance.mCsPlayer.PlrTrans*/);
			StopCoroutine(StartDropCoroutine());
			doAction(ActionKind.run, InputKind.none, true, true);
			GD.rebirthing = false;
		}
	}
	public void Mount()
	{
		mGameAni.DoAction(ActionKind.mount);
	}
	
	void doAction(ActionKind _action ,InputKind _input = InputKind.none, bool _isNeedPlayerAction = true , bool _isNeedTrackerAction = false )
	{
		if(_input != InputKind.none)
		{
			mPrevInput		= mCurInput;
			mCurInput		= _input;
			mCurInputTime	= Time.time;
		}
		if(_isNeedPlayerAction)
			mGameAni.DoAction(_action);
		if(_isNeedTrackerAction)
			mTracker.DoAction(_action);
	}
	public void OnInputGame(InputKind _input)
	{
		if(GD.dead)
			return;
		if(GameMgr.gameState != GameState.play || !mIsStart)
			return;
		mLastInputTime = Time.time;
		switch(_input) 
		{
		case InputKind.right:
            if (mJumpKind != JumpKind.none || mIsFall || isRolling)
                doAction(ActionKind.moveRight, _input, false, false);
            else
                doAction(ActionKind.moveRight, _input, true, true);
			changeLane(_input);
			break;
		case InputKind.left:
			if(mJumpKind != JumpKind.none || mIsFall || isRolling)
				doAction(ActionKind.moveLeft, _input, false, false);
			else
				doAction(ActionKind.moveLeft, _input, true, true);
			changeLane(_input);
			break;
		case InputKind.up:
			onJumpBegin();
			break;
		case InputKind.down:
			onRollBegin();
			break;
		case InputKind.dblTap:
			if(!GD.usingShield && GD.dtShieldCnt > 0)
			{
				//ActiveSfSkin(true);
				mAvtGame.UseItemShield();
			}
			break;
		case InputKind.downLeft:
			interpolateInput(false, true);
			break;
		case InputKind.downRight:
			interpolateInput(false, false);
			break;
		case InputKind.upLeft:
			interpolateInput(true, true);
			break;
		case InputKind.upRight:
			interpolateInput(true, false);
			break;
		}
	}
	public void OnInputHome(InputHomeKind _input)
	{
		switch(_input)
		{
		case InputHomeKind.body:
			mHomeAni.DoAction(ActionKind.petBody);
			break;
		case InputHomeKind.leg:
			mHomeAni.DoAction(ActionKind.petLeg);
			break;
		case InputHomeKind.neck:
			mHomeAni.DoAction(ActionKind.petNeck);
			break;
		case InputHomeKind.eat:
			mHomeAni.DoAction(ActionKind.petEat);
			break;
		}
	}

	private void interpolateInput(bool _isUp, bool _isLeft)
	{
		mRay.origin = mTransform.position + mTransform.up;
		mRay.direction = mTransform.forward;
		if(Physics.Raycast(mRay, 10f, mLayerObsMask))
		{
			mRay.origin = mTransform.position + mTransform.up + (_isUp ? 0.5f: - 0.5f) *  mTransform.up;
			if(Physics.Raycast(mRay, 10f, mLayerObsMask))
				OnInputGame(_isLeft? InputKind.left: InputKind.right);
			else
				OnInputGame(_isUp?InputKind.up:InputKind.down);
		}
		else
			OnInputGame(_isUp ? InputKind.up : InputKind.down);
	}
	void OnControllerColliderHit(ControllerColliderHit _hit)
	{
        if (GameMgr.gameState != GameState.play || mIsDrop)
            return;

		if(_hit.gameObject.layer == (int)LayerKind.floor) //avoid repeat collision
			return;

		if(trCollisionObj == _hit.transform) //avoid repeat collision
			return;

		trCollisionObj = _hit.transform;

		if(_hit.gameObject.layer == (int)LayerKind.item)
		{
			switch(_hit.gameObject.name)
			{
			case "pfItmSpring":
				if (isRolling)
					onRollEnd();
				mJumpKind		= JumpKind.spring;
				mJumpCurTm		= 0f;
				mLastY			= 0;
				mGravity		= MD.gravity;
				mJumpDuration	= MD.jumpSpringTm;

				PlayerEventMgr.inst.OnEvent(PlayerEventKind.trampoline);
				doAction(ActionKind.spring);
				RoadMaker.mInst.setSpringCoin(_hit.transform);
				break;
			case "pfItmFly":
				Fly();
				break;
			case "pfItmShield":
				++GD.dtShieldCnt;
				break;
			case "pfItm2X":
				PlayerEventMgr.inst.OnEvent(PlayerEventKind.x2);
				mAvtGame.UseItem2X();
				break;
			case "pfItmMagnet":
				PlayerEventMgr.inst.OnEvent(PlayerEventKind.magnet);
				mAvtGame.UseItemMgt();
				break;
			case "pfItmBalloon":
				mBalloonTm = GD.dtUpgradeBalloon.val;
				PlayerEventMgr.inst.OnEvent(PlayerEventKind.balloon);
				_Balloon.SetActive(true);
				mAvtGame.UseItemBll();
				break;
			case "pfItmGem":
				++GD.dtGems;
				break;
			}
			GameObject goItmEff = Instantiate(Resources.Load("Prefabs/Particle/ptcItmEff"), mTransform) as GameObject;
			Destroy(goItmEff,0.1f);
			Util.PlaySound("sfxItem");
			_hit.transform.localPosition = Vector3.zero;// gameObject.SetActive(false);
		}
		else if(!GD.dead && _hit.gameObject.layer != (int)LayerKind.floor)
		{	
			if(mJumpKind == JumpKind.fly && mJumpCurTm < mJumpDuration)
				return;

			if(_hit.gameObject.layer == (int)LayerKind.obstacle)//perfect collision
			{
				ImpactZ impactZ = GetImpactZ(_hit.collider);
				ImpactX impactX = GetImpactX(_hit.collider);
				ImpactY impactY = GetImpactY(_hit.collider);

				if(mTracker.IsNear())
				{
					onCollisionPerfect();
					return;
				}
				switch(_hit.gameObject.name)
				{
				case "pfCartStand":
				case "pfCartTroupe":
				case "pfSwingBob":
				case "pfPole":
					if(impactZ == ImpactZ.Before)
					{
						if(impactX == ImpactX.Middle)
							onCollisionPerfect();
						else if(impactY == ImpactY.Middle)
							onCollisionStumble();
						else
							onCollisionStumble();
					}
					else
					{
						if(mCurInput == InputKind.right)
						{
							changeLane(InputKind.left);
							//doAction(ActionKind.moveLeft, InputKind.none, false, true);
						}
						else if(mCurInput == InputKind.left)
						{
							changeLane(InputKind.right);
							//doAction(ActionKind.moveRight, InputKind.none, false, true);
						}
						//if(mJumpKind == JumpKind.none)
						//	mIsSideLightClsn = true;
						//mLightClsntTm = MD.tracTm;
						//mPrevLghtClsnTrans = collision.transform.parent;

						onCollisionStumble();
					}
					break;

				case "pfHurdleUp":
				case "pfHurdleMiddle":
				case "pfHurdleDown":
					if(impactX == ImpactX.Middle)
					{
						onCollisionPerfect();
					}
					else
					{
						if(mCurInput == InputKind.right && impactX == ImpactX.Left)
							changeLane(InputKind.left);
						else if (mCurInput == InputKind.left && impactX == ImpactX.Right)
							changeLane(InputKind.right);

						onCollisionStumble();
					}
					break;

				case "pfBall":
				case "pfIncline":
					onCollisionPerfect();
					break;

				case "pfBalloonObs":
					onCollisionStumble();
					break;
				}
			}
			
        }
	}
	private void onCollisionPerfect()
	{
		GD.collided = true;
		if (GD.usingShield)
		{
			mAvtGame.msgEraseSfSkin();
			Instantiate(Resources.Load("Prefabs/Particle/ptcRelife"), GameMgr.inst._MainCam.transform);
			Util.PlaySound("sfxBreakObs");
			mTracker.GoFarHero();
		}
		else
		{
			if(GD.dead) 
				return;
			mJumpKind = JumpKind.none;
			onRollEnd();
			onDrop();
			mAvtGame.activeShieldBtn(false);
			_Cloud.SetActive(false);
			Util.PlaySound("sfxHit");
			_Ctrlr.detectCollisions	= false;
			Destroy(Instantiate(Resources.Load("Prefabs/Particle/ptcGetHit"), mTransform) as GameObject, 0.5f);
		}
	}
	private void onCollisionStumble()
	{
		if(mTracker.IsNear())
		{
			onCollisionPerfect();
		}
		else
		{
			if(!GD.usingShield)
			{
				doAction(ActionKind.stumble);
				Util.PlaySound("sfxHit");
				Destroy(Instantiate(Resources.Load("Prefabs/Particle/ptcGetHit"), mTransform) as GameObject, 0.5f);
				mTracker.GoNearHero();
				PlayerEventMgr.inst.OnEvent(PlayerEventKind.stumble);
			}
			else
			{
				GD.usingShield = false;
			}
		}
	}
	IEnumerator StumbleCoroutine()
	{
		doAction(ActionKind.stumble);
		yield return new WaitForSeconds(0.333f);
		doAction(ActionKind.fall);
		yield break; 
	}
	void updateEatingCoin()
	{
		Vector3 posPlayer = mTransform.position;
		for (int i = 0; i < RoadRes.instance.Coins.Length; i++)
		{
			Transform trsCoin = RoadRes.instance.Coins[i];
			Vector3 diff = trsCoin.position - posPlayer;
			float diffY = ((hasBalloon && mJumpKind != JumpKind.none) || mJumpKind == JumpKind.spring) ? 1.5f : 0.7f;
			if (Mathf.Abs(diff.x) < 0.5f && Mathf.Abs(diff.z) < 0.5f && Mathf.Abs(diff.y) < diffY)
			{
				trsCoin.GetComponent<Coin>().reset();
				Util.PlaySound("sfxCoin");
				int coin = AvtGame.instance.mDoubleCoinTm > 0 ? 2 : 1;
				GD.earnedCoin += coin;
				PlayerEventMgr.inst.OnEvent(PlayerEventKind.getCoin, coin);
				GameObject goItmEff = Instantiate(Resources.Load("Prefabs/Particle/ptcItmEff"), mTransform) as GameObject;
				Destroy(goItmEff, 0.3f);
			}
		}
	}
	void Update()
	{
		if(GameMgr.gameState == GameState.home)
		{
			initHome();
		}
		else if(GameMgr.gameState == GameState.play)
		{
			initGame();
			Shader.SetGlobalFloat("_Offset", mTransform.position.z);

			if (mIsStart)
			{
				if(isRolling)
				{
					mRollingTm -= Time.deltaTime;
					if(mRollingTm < 0)
						onRollEnd();
				}

				if(trCollisionObj != null)
				{
					mCollidedTm += Time.deltaTime;
					if(mCollidedTm > 1.2f)
					{
						trCollisionObj  = null;
						mCollidedTm     = 0;
					}
				}

				updateMoveForward();
				updateChangeLane();
				updateMoveWithGravity();

				mVtr3Temp.Set(mCurX, mCurY, mCurZ);
				_Ctrlr.Move(mVtr3Temp - mTransform.position);
				updateUseBalloon();
				updateEatingCoin();
			}
		}
	}

	IEnumerator StartDropCoroutine() 
	{
		mGameAni.DoAction(ActionKind.drop);
		
		mTracker.Catch();
		yield return new WaitForSeconds(0.82f);

		mGameAni.DoAction(ActionKind.frighten);
		mTracker.DoAction(ActionKind.frighten);
		yield break;
	}
	public Vector3 GetPosForCam()
	{
        Vector3 vResult = Vector3.zero;
		vResult = mTransform.position;

        if (mJumpKind == JumpKind.normal || mJumpKind == JumpKind.stunt)
        	vResult.y = mLastGroundY + (hasBalloon ? 1.2f : 0f);
		else if (mJumpKind == JumpKind.spring && mJumpCurTm <= mJumpDuration)
            vResult.y -= 0.1f;

		if(mCurLane == LaneIdx.right)
		{
			vResult.x -= 1.15f;
		}
		if(mCurLane == LaneIdx.left)
		{
			vResult.x += 0.83f;
		}
		if(mCurLane == LaneIdx.center)
		{
			vResult.x += 0.48f;
		}
		return vResult;
	}

	public void ActiveShield(bool _isSfSkin)
	{
		if(_isSfSkin)
		{
			for(int i = 0; i < mMesh.Length; i++)
				mMesh[i].material.shader = GameMgr.inst._SfSkinShader;
		}
		else
		{
			for (int i = 0; i < mMesh.Length; i++)
				mMesh[i].material.shader = GameMgr.inst._NormalShader;
		}
	}
 	private ImpactX GetImpactX(Collider _collider)
	{
		float fPlrPosX = mTransform.position.x;
		float fObstacleX = _collider.transform.parent.position.x;
		if(fObstacleX.Equals(-MD.laneWidth))
			fPlrPosX += MD.laneWidth;
		if(fObstacleX.Equals(MD.laneWidth))
			fPlrPosX -= MD.laneWidth;

		if(fPlrPosX <= - MD.laneWidth / 6f)
			return ImpactX.Left;
		if (fPlrPosX >= MD.laneWidth / 6f)
			return ImpactX.Right;	
		return ImpactX.Middle;	
	}
	private ImpactY GetImpactY(Collider collider)
	{
		Bounds bndPlayer	= _Ctrlr.bounds;
		Bounds bndCollider	= collider.bounds;
		float num	= Mathf.Max(bndPlayer.min.y, bndCollider.min.y);
		float num2	= Mathf.Min(bndPlayer.max.y, bndCollider.max.y);
		float num3	= (num + num2) * 0.5f;
		float num4	= (num3 - bndCollider.min.y) / bndCollider.size.y;
		if (num4 < 0.3f)
			return ImpactY.Lower;
		if (num4 > 0.7f)
			return ImpactY.Upper;
		return ImpactY.Middle;
	}
	private ImpactZ GetImpactZ(Collider collider)
	{
		Bounds bndPlayer	= _Ctrlr.bounds;
		Bounds bndCollider	= collider.bounds;

		if (bndPlayer.max.z > bndCollider.max.z)
			return ImpactZ.After;
		if (bndPlayer.min.z <= (bndCollider.min.z + 0.25f))
			return ImpactZ.Before;
		return ImpactZ.Middle;
	}
}
