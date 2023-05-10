using UnityEngine;

public enum InputKind
{
	none,
	right,
	up,
	left,
	down,
	upRight,
	upLeft,
	downLeft,
	downRight,
	tap,
	dblTap,
	cnt
}

public enum InputMode
{
	home,
	game,
}
public delegate void OnInputDelegate(object _input, object _lastPos);
public class InputBase : MonoBehaviour {

	//protected Ctrlr mCtrlr;


   // protected InputTap mIT;
	protected bool mInited = false;
	
	public OnInputDelegate OnInputEvent;
	[HideInInspector]public InputMode mInputMode;
	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		
	}
}
