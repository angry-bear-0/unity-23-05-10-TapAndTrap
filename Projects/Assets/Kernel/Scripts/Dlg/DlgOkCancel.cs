using System.Collections;
using UnityEngine;

public class DlgOkCancel : DlgBase 
{
	deleFunc		mYes;
	deleFunc		mNo;
	object			mUsrData = null;

    public UILabel		_AlertString;

    public static void OpenDlg(deleFunc _yes, deleFunc _no, string _alert, object _usrData = null)
    {
        GameObject obj		= Instantiate(Resources.Load("Prefabs/Dlg/pfDlgOkCancel")) as GameObject;
        Transform trans		= obj.GetComponent<Transform>();
        trans.parent		= GameObject.Find("CameraUI").GetComponent<Transform>();
        trans.localPosition = new Vector3(0f, 0f, -500f);
        trans.localRotation = Quaternion.identity;
        trans.localScale	= Vector3.one;

        obj.GetComponent<DlgOkCancel>().Init(_yes, _no, _alert, _usrData);
        NGUITools.AdjustDepth(obj, depth);
    }
    public void Init(deleFunc _yes, deleFunc _no, string _alert, object _usrData = null)
    {
        onOpen();
		mYes	= _yes;
		mNo		= _no;
		mUsrData= _usrData;
		Util.PlaySound("msgOpen");
		_AlertString.text = _alert;
    }
	protected override void onClosedDlg(GameObject _closeBtn)
	{
		if (_closeBtn == null || _closeBtn.name == "btnCancel" || _closeBtn.name == "btnClose")
		{
			if(mNo != null)
				mNo(mUsrData);
		}
		else if (_closeBtn.name == "btnCheck")
		{
			if(mYes != null)
				mYes(mUsrData);
		}
	}
}
