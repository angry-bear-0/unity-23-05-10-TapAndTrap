using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DlgMission : DlgBase
{
	protected AvtHome mParent = null;
	// Use this for initialization
    static public void OpenDlg(AvtHome _parent)
    {
        GameObject obj = Instantiate(Resources.Load("Prefabs/Dlg/pfDlgMission")) as GameObject;
        Transform trans = obj.GetComponent<Transform>();
        trans.parent = GameObject.Find("CameraUI").GetComponent<Transform>();

        trans.localPosition = Vector3.zero;
        trans.localRotation = Quaternion.identity;
        trans.localScale = Vector3.one;
		NGUITools.AdjustDepth(obj, depth);

        DlgMission script = obj.GetComponent<DlgMission>();
        script.Init(_parent);
    }
    public void Init(AvtHome _parent)
    {
        onOpen();

		mParent = _parent;
    }
    public void OnClickBtn(GameObject _gameObj)
    {
        switch (_gameObj.name)
        {
            case "btnClose":
			case "btnHome":
                msgEscapeKey();
                break;
            case "btnStartRun":
                mParent.Play();
                msgEscapeKey();
                break;
        }
    }
}
