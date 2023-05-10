using UnityEngine;

public class InputMgr : MonoBehaviour
{
	private InputTap mCsInputTap;
	private InputKB	mCsInputKB;
	static public InputMgr Create()
	{
		GameObject obj		= Instantiate(Resources.Load("Prefabs/Avt/pfInput")) as GameObject;
		Transform trans		= obj.GetComponent<Transform>();
		trans.parent		= GameObject.Find("CameraUI").transform;
		trans.localPosition = Vector3.zero;
		trans.localRotation = Quaternion.identity;
		trans.localScale	= Vector3.one;
		InputMgr script		= obj.GetComponent<InputMgr>();
		script.mCsInputTap	= obj.GetComponent<InputTap>();
		script.mCsInputKB	= obj.GetComponent<InputKB>();
		return script;
	}
	public void SetSendModule(OnInputDelegate _onInput, object _usrData)
	{
//		print("steInputModule");
		mCsInputTap.OnInputEvent = _onInput;
		mCsInputTap.mInputMode = (InputMode)_usrData;
		mCsInputKB.OnInputEvent = _onInput;
		mCsInputKB.mInputMode = (InputMode)_usrData;
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
