using UnityEngine;

public enum InputHomeKind
{
	none,
	neck,
	body,
	leg,
	eat
}
public class InputHome : InputBase {
	
	private Camera			mMainCam;
	private Player			mPlayer;
	private Vector3			mTouchPos		= Vector3.zero;
	private bool			initedHome		= false;
	RaycastHit				rayHit			= new RaycastHit();
	private float			mPetTchTm		= 0f;
	private int				mPetTchCnt		= 0;

	// Use this for initialization
	void Start () {
		
	}
	public void InitGame()
	{
		GameMgr.inputMgr.SetSendModule(onInputHome, InputMode.home);
	}

	private void init()
	{
		if(initedHome)
			return;
		initedHome				= true;
		mPlayer		= GameMgr.player;
		mMainCam	= GameMgr.inst._MainCam;
		
		mPetTchTm = 0f;
		mPetTchCnt = 0;
	}

	// Update is called once per frame
	void Update ()
	{
		init();
		if(mPetTchTm > 0)
		{
			mPetTchTm -= Time.deltaTime;
			if(mPetTchTm <= 0f)
				mPetTchTm = 0f;
		}
	}
	private void onInputHome(object _input, object _lastTapPos)
	{
		InputHomeKind inputHomeKind = InputHomeKind.none;
		Vector2 vLastPos = (Vector2)_lastTapPos;
		if((InputKind)_input == InputKind.tap)
		{
			if(GD.petCondition == MD.petConditionGood)
			{
				mTouchPos.Set(vLastPos.x, vLastPos.y, 0f);
				Ray ray = mMainCam.ScreenPointToRay(mTouchPos);
				Physics.Raycast(ray, out rayHit, 10f);
				if(rayHit.collider == null)
					return;
				switch(rayHit.collider.gameObject.name)
				{
					case "neck":
						inputHomeKind = InputHomeKind.neck;
						mPlayer.OnInputHome(InputHomeKind.neck);
                        GD.Save();
						break;
					case "body":
						inputHomeKind = InputHomeKind.body;
						mPlayer.OnInputHome(InputHomeKind.body);
                        GD.Save();
						break;
					case "leg":
						inputHomeKind = InputHomeKind.leg;
						mPlayer.OnInputHome(InputHomeKind.leg);
                        GD.Save();
						break;
				}
			}
			
			if(inputHomeKind == InputHomeKind.body && inputHomeKind == InputHomeKind.neck && inputHomeKind == InputHomeKind.leg)
			{
				if(mPetTchTm == 0f)
				{
					GD.dtPetHp += MD.petTouchInc;
					mPetTchTm = MD.petHpIncTm;
				}
				else
				{
					if(mPetTchCnt < 3)
					{
						GD.dtPetHp += MD.petFeedInc - mPetTchCnt;
					}
					else
						++GD.dtPetHp;
				}
				++mPetTchCnt;
			}
		}
	}
}
