using UnityEngine;
using System.Collections;
public class CamMgr : MonoBehaviour 
{
	public enum Action
	{
		start = 0,
		die = 1,
		idle,
		size
	}
	private string [] mAniName = { "aniCamGainup", "aniCamHeroDie" };

	public  Transform		_CamDist		= null;
	public  Transform		_CamEff			= null;
	public	Transform		_CamLane		= null;
	[HideInInspector]

	public	bool			_Start;
	private Player			mPlayer		= null;
    // StartPos
	private Vector3			mCamEffHomePos		= new Vector3(1, 1, 1.5f);
	private Quaternion		mCamEffHomeRot		= Quaternion.Euler(20f, -150f, 0f);
	private Vector3			mCamEffGamePos		= new Vector3(0f, 3.08f, -2.86f);
	private Quaternion		mCamEffGameRot		= Quaternion.Euler(20f, 0f, 0f);
	private Animation		mCamAni				= null;
	private float			mSmoothSpeed		= 0.1f;

    public void init() 
    {
		_Start = false;
    }

	void Start () 
	{	
		mCamAni = GetComponentInChildren<Animation>();
	}

	void Update()
	{
		if(_Start)
		{
			updateFollowing();
		}
	}

	void updateFollowing()
	{
		if(GameMgr.player == null)
			return;
		if(!mPlayer)
			mPlayer = GameMgr.player;
        Vector3 temp = _CamDist.position;
		Vector3 plrCamPos = mPlayer.GetPosForCam();
		temp.z = Mathf.Lerp(temp.z, plrCamPos.z, Time.deltaTime * 7);
		_CamDist.position = temp;

		temp = _CamLane.localPosition;
		temp.x = Mathf.SmoothDamp(temp.x, plrCamPos.x, ref mSmoothSpeed, 0.2f);
		temp.y = Mathf.Lerp(temp.y, plrCamPos.y, Time.deltaTime * 7);
		_CamLane.localPosition = temp;
	}
	public void ResetCamEff()
	{
		_CamEff.localPosition = mCamEffGamePos;
		_CamEff.localRotation = mCamEffGameRot;
	}
	public void CamAniPlay(Action _action)
	{
		switch(_action)
		{
			case Action.start:
			case Action.die:
				mCamAni.Play(mAniName[(int)_action]);
				break;
		}
	}
	public void Reset()
	{
		init();
		_CamDist.position = Vector3.zero;
		_CamLane.position = Vector3.zero;
		_CamEff.localPosition = mCamEffHomePos;
        _CamEff.localRotation = mCamEffHomeRot;
	}
}