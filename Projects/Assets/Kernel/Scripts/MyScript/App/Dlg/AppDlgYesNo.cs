using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppDlgYesNo : AppDlgBase
{
    [SerializeField] UILabel _LblTitle;
    [SerializeField] UILabel _LblContent;
    protected object mObject;

    public static void OpenDlg(string _title, string _text)
    {
        OpenDlg(null, _title, _text, null);
    }

    public static void OpenDlg(DlalogReturnDelegate _dele, string _title, string _text, object _obj)
    {
        GameObject obj = Instantiate(Resources.Load("Prefabs/Dlg/DlgYesNo")) as GameObject;
        Transform trans = obj.GetComponent<Transform>();
        trans.parent = GameObject.Find("CameraUI").GetComponent<Transform>();
        trans.localPosition = new Vector3(0f, 0f, -500f);
        trans.localRotation = Quaternion.identity;
        trans.localScale = Vector3.one;

        obj.GetComponent<AppDlgYesNo>().Init(_dele, _title, _text, _obj);
        NGUITools.AdjustDepth(obj, depth);
    }

    public void Init(DlalogReturnDelegate _dele, string _title, string _text, object _obj)
    {
        if (_dele != null)
            returnDelegate = _dele;
        if (_obj != null)
            mObject = _obj;

        _LblTitle.text = _title;
        _LblContent.text = _text;
    }

    override protected void onOpenDlg()
    {
        base.onOpenDlg();
    }

    override protected void onCloseDlg(GameObject _obj)
    {
        base.onCloseDlg(_obj);
        if (_obj != null)
        {
            if (returnDelegate != null && mObject != null && _obj.name == "btnYes")
                returnDelegate(mObject);
        }
    }
}
