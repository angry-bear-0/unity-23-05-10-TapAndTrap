using UnityEngine;

public class InputTap : InputBase {

    public static bool enable		= true;

	private Camera		mUICam			= null;
    private bool		mTouched		= false;
    private Vector2		mTouchStartPos	= Vector2.zero;
    private Vector2		mTouchCurPos	= Vector2.zero;
    private InputKind	mCurDir			= InputKind.none;                       //currentDirection
    private float		dirAngle		= 0;
    private float		mDblTapTm		= 0;                    //DoubleTap
	private	bool		dblTaping		= false;
	

    const float INDICATOR_TM	= 0.085f;
    const float DBLTAP_TM		= 0.4f;
    const float DBLTOUCH_TM		= 0.25f;


	//    bool dblTouching = false;

	public static void SetSendEvent(object _usrData = null)
	{

	}

    // Update is called once per frame
    void Update()
    {
        Init();
		if(mInputMode == InputMode.game)
		{
			InputKind indicator = InputKind.none;

			if (mTouched && mTouchCurPos != UICamera.lastEventPosition)
			{
				mTouchCurPos = UICamera.lastEventPosition;
				Vector2 dir = mTouchCurPos - mTouchStartPos;
				if (dir.sqrMagnitude < 100.0f)
					indicator = InputKind.none;                                             //disregard tapping
				else
					dirAngle = GetAngleFromRightToVector(dir);

				if ((dirAngle + 40) % 90 < 80)                              //ctrl decision
				{
					indicator = GetDirIndicator(dirAngle);//Util.GetAngleFromRightToVector(dir));
					//Debug.Log(indicator);
				}
				else
				{ 
					if (dirAngle >= 40 && dirAngle <= 50) { indicator = InputKind.upRight; }//1 sector ctrl
					if (dirAngle >= 130 && dirAngle <= 140) { indicator = InputKind.upLeft; }//2 sector ctrl
					if (dirAngle >= 220 && dirAngle <= 230) { indicator = InputKind.downLeft; }//3 sector ctrl
					if (dirAngle >= 310 && dirAngle <= 320) { indicator = InputKind.downRight; }//4 sector ctrl
				}
				if (mCurDir != indicator)
				{
					mCurDir = indicator;
				}

				if (dir.sqrMagnitude > 900)                                      //send tapping data
					ReleasePress();
			}

			if (enable)
			{
				if (mDblTapTm > 0 && dblTaping) //do double tapping
				{
					mDblTapTm -= Time.deltaTime;                                 //?????
					if (mDblTapTm < 0)
					{
						dblTaping = false;
					}
				}
			}
		}
        
    }

    static public float GetAngleFromRightToVector(Vector2 v)
    {
        float angle = Vector2.Angle(v, Vector2.right);
        if (v.y >= 0)
            return angle;
        else
            return 180 + (180 - angle);
    }

    void ReleasePress()
    {
        mTouched = false;                                           //touch end
        if (mCurDir != InputKind.none)
        {
            mDblTapTm = 0;                                          //dobule tap disregard
            dblTaping = false;
        }
		OnInputEvent(mCurDir, UICamera.lastEventPosition);
		mCurDir = InputKind.none;
    }
    void OnPress(bool _isPressed)
    {
        if (mUICam == null)
            return;
		if(mInputMode == InputMode.home && _isPressed)
			OnInputEvent(InputKind.tap,UICamera.lastEventPosition);
		if(mInputMode == InputMode.game)
		{
			if (_isPressed && !GD.dead && enable)                    //enable???
			{
				mTouched = _isPressed;
				mTouchStartPos = UICamera.lastEventPosition;             //last = start?
				mTouchCurPos = mTouchStartPos;        
			}
			else if (mTouched)
			{
				if (mCurDir == InputKind.none)
				{
					if (!dblTaping)
					{
						mDblTapTm = DBLTAP_TM;                    
						dblTaping = true;
					}
					else if (mDblTapTm > 0)
					{
						mDblTapTm = 0;
						dblTaping = false;                                 //double tap true
						mCurDir = InputKind.dblTap;                  //double tap single
						//SendInputEvent(mCurDir);
						//mCurDir = InputKind.none;
					}
				}
				ReleasePress();
			}
		}

        
    }

    InputKind GetDirIndicator(float _angle)
    {
        return (InputKind)(Mathf.FloorToInt((Mathf.FloorToInt(_angle + 45) % 360) / 90) + 1);             //return range(0,3)
    }

    public void Reset()
    {
        mTouched = false;
        mCurDir = InputKind.none;
  //      mShowIndicatorTm = 0;
        mDblTapTm = 0;
  //      mDblTouchTm = 0;
        dblTaping = false;
    }

    void Init()
    {
        if (mInited)
            return;
        mUICam = NGUITools.FindCameraForLayer(gameObject.layer);
    }
}
