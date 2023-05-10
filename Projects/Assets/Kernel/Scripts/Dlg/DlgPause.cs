using System.Collections;
using UnityEngine;

public enum MsgDlgPause
{
	btnClose,
	btnResume,
	btnGoHome,
	btnSet
}
public class DlgPause : DlgBase
{
	deleMsgDlg			onMsgDlgPause;

	static public void OpenDlg(deleMsgDlg _onMsgPause)
	{
        GameObject obj			= Instantiate(Resources.Load("Prefabs/Dlg/pfDlgPause")) as GameObject;
		Transform trans			= obj.GetComponent<Transform>();
		trans.parent			= GameObject.Find("CameraUI").GetComponent<Transform>();
		trans.localPosition		= Vector3.zero;
		trans.localRotation		= Quaternion.identity;
		trans.localScale		= Vector3.one;

		NGUITools.AdjustDepth(obj, depth);
        DlgPause script = obj.GetComponent<DlgPause>();
        script.Init(_onMsgPause);

	}
    public void Init(deleMsgDlg _onMsgPause)
	{
		onOpen();

        onMsgDlgPause = _onMsgPause;

	}
	public void OnClickSetting()
	{
		onMsgDlgPause(MsgDlgPause.btnSet);
	}
	protected override void onClosedDlg(GameObject _closeBtn)
	{
		if (_closeBtn == null || _closeBtn.name == "btnClose" || _closeBtn.name == "btnResume")
			onMsgDlgPause(MsgDlgPause.btnResume);
		else if (_closeBtn.name == "btnSmallHome")
			onMsgDlgPause(MsgDlgPause.btnGoHome);
	}
}
