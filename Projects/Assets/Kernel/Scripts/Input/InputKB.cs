using UnityEngine;

public class InputKB : InputBase {

    // Use this for initialization
    //public GameObject keyReciever;
    

    private int mJump;
    private int mMove;
    private InputKind mCurKey = InputKind.none;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
		if(mInputMode == InputMode.game)
		{
			if (Input.GetKeyDown(KeyCode.UpArrow))// .GetButton("Up"))
				mCurKey = InputKind.up;
			else if (Input.GetKeyDown(KeyCode.DownArrow))//.GetButton("Down"))
				mCurKey =  InputKind.down;
			else if (Input.GetKeyDown(KeyCode.RightArrow))//.GetButtonDown("Right"))
				mCurKey = InputKind.right;
			else if (Input.GetKeyDown(KeyCode.LeftArrow))//.GetButtonDown("Left"))
				mCurKey =  InputKind.left;
			else if(Input.GetKeyDown(KeyCode.Keypad7))//.GetButtonDown("Left"))
				mCurKey = InputKind.upLeft;
			else if(Input.GetKeyDown(KeyCode.Keypad9))//.GetButtonDown("Left"))
				mCurKey = InputKind.upRight;
			else if(Input.GetKeyDown(KeyCode.Keypad1))//.GetButtonDown("Left"))
				mCurKey = InputKind.downLeft;
			else if(Input.GetKeyDown(KeyCode.Keypad3))//.GetButtonDown("Left"))
				mCurKey = InputKind.downRight;
			if(mCurKey != InputKind.none)
			{
				OnInputEvent(mCurKey,Vector2.zero);
				mCurKey = InputKind.none;
			}
		}
    }
}
