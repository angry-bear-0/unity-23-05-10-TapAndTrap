using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public delegate void deleFunc(object _userData);
public delegate void confirmButton(PriceBase _price, int _cnt);
public delegate void deleMsgDlg(object _usrData);

public class DlgBase : MonoBehaviour
{
	[SerializeField] protected GameObject _Block;

	protected bool mInited = false;
	private bool mOpenned = false;
	static List<GameObject> stack = new List<GameObject>();
	private GameObject mCloseBtn = null;

	public delegate void CloseDelegate(GameObject _go);
	public CloseDelegate onCloseDelegate;

	protected bool mClosing = false;
	// Use this for initialization
	protected void Start()
	{
		useGUILayout = false;
		foreach (Transform c in transform)
			if (c.GetComponent<UITweener>() != null)
				c.GetComponent<UITweener>().enabled = false;
	}

	IEnumerator showDlgAni()
	{
		yield return new WaitForSecondsRealtime(0.05f);
		Util.SendMessageRecursively(gameObject, "PlayForward", 1);
		yield break;
	}

	protected void Update()
	{
		if(!mOpenned)
		{
			mInited = true;
			mOpenned = true;
			StartCoroutine(showDlgAni());
		}
	}
	public void BlockInput(bool _block)
	{
		if(_Block != null)
			_Block.SetActive(_block);
	}

	protected void onOpen()
	{
		Util.PlaySound("sfxDlgOpen");
		stack.Add(gameObject);
	}

	virtual protected void onClose()
	{
		mClosing = true;
		stack.Remove(gameObject);
	}

	public static bool IsAnyDlgOpened()
	{
		return stack.Count > 0;
	}

	public static void InitStack()
	{
		stack.Clear();
	}

	protected virtual void onClosedDlg(GameObject _closeBtn)
	{

	}

	static public int depth
	{
		get { return (stack.Count + 1) * 100; }
	}

	static public bool DoEscapePress()
	{
		if(stack.Count <= 0)
			return false;
		stack[stack.Count - 1].SendMessage("msgEscapeKey", SendMessageOptions.DontRequireReceiver);
		return true;
	}

	virtual public void OnBtnClose(GameObject _gameObj)
	{
		mCloseBtn = _gameObj;
		msgEscapeKey();
	}

	protected IEnumerator closeDlgRoutin()
	{
		onClose();
		if(onCloseDelegate != null)
			onCloseDelegate(mCloseBtn);

		BlockInput(true);
		mInited = false;
		Util.PlaySound("sfxDlgClose");
		Util.SendMessageRecursively(gameObject, "PlayReverse", 1);
		yield return new WaitForSecondsRealtime(0.8f);
		onClosedDlg(mCloseBtn);
		Destroy(gameObject);
		yield break;
	}

	protected void msgEscapeKey()
	{
		if(mInited && !mClosing)
			StartCoroutine(closeDlgRoutin());
	}
}

