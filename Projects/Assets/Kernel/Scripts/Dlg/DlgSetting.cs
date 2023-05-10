using System.Collections;
using UnityEngine;
public class DlgSetting : DlgBase
{
	deleMsgDlg			onMsgDlgSet;
    public GameObject   _MusicScroll;
    public GameObject   _SoundScroll;
    private string[] _MsgData;
	static public void OpenDlg(deleMsgDlg _msgDlgSet, object[] _usrData = null)
	{
		GameObject obj		= Instantiate(Resources.Load("Prefabs/Dlg/pfDlgSetting")) as GameObject;
		Transform trans		= obj.GetComponent<Transform>();
		trans.parent		= GameObject.Find("CameraUI").GetComponent<Transform>();

		trans.localPosition = Vector3.zero;
		trans.localRotation = Quaternion.identity;
		trans.localScale	= Vector3.one;
		NGUITools.AdjustDepth(obj, depth);

		DlgSetting script = obj.GetComponent<DlgSetting>();
		script.Init(_msgDlgSet, _usrData);
	}
	public void Init(deleMsgDlg _msgDlgSet, object[] _usrData)
	{
		onMsgDlgSet = _msgDlgSet;
        _MsgData = new string[2];

		_MusicScroll.GetComponent<UIScrollBar>().value = GD.dtBgmVolum;
		_SoundScroll.GetComponent<UIScrollBar>().value = GD.dtSfxVolum;
		onOpen();
	}

	public void OnChangeScrollBar(GameObject _gameObj)
	{
        _MsgData[0] = _gameObj.name;
        _MsgData[1] = _gameObj.GetComponent<UIScrollBar>().value.ToString();
        onMsgDlgSet(_MsgData);
	}
}
