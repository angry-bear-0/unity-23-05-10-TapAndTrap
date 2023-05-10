using System.Collections;
using UnityEngine;

public class DlgOk : DlgBase 
{
	deleFunc        mOk = null;
    public UILabel  lblTitle;
	public UILabel	lblText;
	public UILabel	lblBtnText;
	object			mUserData = null;

	public static void OpenDlg(string _title, string _text, string _btnText) 
	{
		OpenDlg(_title, _text, _btnText, null, null);
	}

    public static void OpenDlg(string _title, string _text, string _btnText, deleFunc _ok, object _usrData = null)
    {
        GameObject obj		= Instantiate(Resources.Load("Prefabs/Dlg/DlgOk")) as GameObject;
        Transform trans		= obj.GetComponent<Transform>();
        trans.parent		= GameObject.Find("CameraUI").GetComponent<Transform>();
        trans.localPosition = new Vector3(0f, 0f, -500f);
        trans.localRotation = Quaternion.identity;
        trans.localScale	= Vector3.one;

        obj.GetComponent<DlgOk>().Init(_title, _text, _btnText, _ok, _usrData);
        NGUITools.AdjustDepth(obj, depth);
    }
    public void Init(string _title, string _text, string _btnText, deleFunc _ok, object _usrData = null)
    {
        onOpen();
        if (_ok != null)
		    mOk	= _ok;
        if (_usrData != null)
		    mUserData= _usrData;

        lblTitle.text = _title;
        lblText.text = _text;
        lblBtnText.text = _btnText;
		Util.PlaySound("msgOpen");
    }
	protected override void onClosedDlg(GameObject _closeBtn)
	{
        if (mOk != null)
        {
            mOk(mUserData);
        }
	}
}
