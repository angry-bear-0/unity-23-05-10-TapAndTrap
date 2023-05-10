using System.Collections;
using UnityEngine;

public class Tracker: MonoBehaviour
{
    private const float		DELTA_DISTANCE_CATCH	= 2.32f;
    private const float		DELTA_DISTANCE_NEAR		= 1f;
    private const float		DELTA_DISTANCE_FAR		= 4f;

	private Transform		mTrans;
	private Animation		mAnimation;

	private bool			mInitedHome				= false;
	private bool			mInitedGame				= false;

	private Vector3			mPos					= Vector3.zero;
	private float			mDist					= 0;
    private float			mCurDeltaDist;
    private float			mDstDeltaDist;


	private bool			mIsStart				= false;
	private bool			mIsRunning				= true;
	private bool			mIsNear					= false;
    private Vector3			StartPos				= new Vector3(0f, 0f, -15f);
	private	int				mLayerObsMask			= 1 << 12;
	private	Ray				mRay					= new Ray();

	private bool isObstacleInFront
	{
		get
		{
			mRay.origin = mTrans.position + Vector3.up * 0.5f;
			mRay.direction = Vector3.forward;
			return Physics.SphereCast(mRay,0.5f, 5f, mLayerObsMask);
		}
	}
	public void StartRun()
	{
		mIsStart = true;
		if(GD.rebirthing)
		{
			mIsRunning = true;
			GoFarHero();
		}
	}
	void Start () 
	{
		
    }

	void initHome()
	{
		if(mInitedHome)
			return;
		mInitedHome		= true;
		mTrans			= transform;
		mAnimation		= gameObject.GetComponent<Animation>();
	}
	void initGame()
	{
		if(mInitedGame)
			return;

		mInitedGame = true;
		transform.position		= StartPos;
		mPos					= Vector3.zero;
		mDist					= 0;
		mCurDeltaDist			= 20f;
		mDstDeltaDist			= DELTA_DISTANCE_FAR;

		mIsStart				= false;
		mIsRunning				= true;
		mIsNear					= false;
	}
	// Update is called once per frame
	void Update () 
	{
		if(GameMgr.gameState == GameState.home)
			initHome();
		else if(GameMgr.gameState == GameState.play)
			initGame();
		
		//update animation 
		if(mIsRunning)
			mAnimation.PlayQueued("trackerRun");

		if(!mIsStart)
			return;

		if(mDstDeltaDist.Equals(DELTA_DISTANCE_CATCH))
			mCurDeltaDist = mDstDeltaDist;
		else if(mDstDeltaDist.Equals(DELTA_DISTANCE_FAR))
			mCurDeltaDist = Mathf.Lerp(mCurDeltaDist, mDstDeltaDist, Time.deltaTime);
		else if(mDstDeltaDist.Equals(DELTA_DISTANCE_NEAR))
			mCurDeltaDist = Mathf.Lerp(mCurDeltaDist, mDstDeltaDist, Time.deltaTime * 5f);

		mDist = GameMgr.playerTr.position.z - mCurDeltaDist;
		mPos.Set(GameMgr.playerTr.position.x, Mathf.Lerp(mPos.y, GameMgr.playerTr.position.y, Time.deltaTime * 7f), mDist);
 		mTrans.position = mPos;
	}
	
	public void DoAction(ActionKind _action)
	{
		switch(_action)
		{
		case ActionKind.jump:
			if(isObstacleInFront || mIsNear)
				mAnimation.CrossFade("trackerJump", 0.1f, PlayMode.StopAll);

			break;
		case ActionKind.lower:
			mAnimation.CrossFade("trackerLower", 0.1f, PlayMode.StopAll);
			break;
		case ActionKind.moveLeft:
		case ActionKind.moveRight:
			break;
		case ActionKind.frighten:
			mAnimation.CrossFade("trackerDropEnd", 0.1f, PlayMode.StopAll);
			mIsRunning = false;
			break;
		case ActionKind.stop:
			mAnimation.Stop();
			mIsRunning = false;
			break;
		case ActionKind.run:
			mIsRunning = true;
			break;
		}
    }
	
    public void Catch()
	{
		StopAllCoroutines();
		mDstDeltaDist = DELTA_DISTANCE_CATCH;
		mIsNear=true;
	}

    public void GoNearHero() 
	{
		mDstDeltaDist = DELTA_DISTANCE_NEAR;
		mIsNear = true;
		StartCoroutine(GoNearCoroutine());
    }
	public bool IsNear()
	{
		return mIsNear;
	}
    public void GoFarHero() 
	{
		StopCoroutine(GoNearCoroutine());
		mDstDeltaDist = DELTA_DISTANCE_FAR;
		mIsNear = false;
    }

	IEnumerator GoNearCoroutine()
	{
		yield return new WaitForSeconds(MD.tracTm);
		GoFarHero();
		mIsNear = false;
		yield break;
	}

	public void GoToPosition(Vector3 _pos, float _tm)
	{
//		mDstPos = _pos.z - DELTA_DISTANCE_CATCH;
    }
    public void Reset()
    {
        mIsStart	= false;
        mIsRunning	= true;
		mInitedGame = false;
        transform.position = StartPos;
	}
}
