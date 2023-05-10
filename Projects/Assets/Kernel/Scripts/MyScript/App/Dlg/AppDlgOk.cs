using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppDlgOk : AppDlgBase
{
    [SerializeField] UILabel _LblTitle;
    [SerializeField] UILabel _LblContent;
    [SerializeField] UILabel _LblButtonText;

    public static void OpenDlg(string _title, string _text, string _btnText)
    {
        OpenDlg(null, _title, _text, _btnText);
    }

    public static void OpenDlg(DlalogReturnDelegate _dele, string _title, string _text, string _btnText)
    {
        GameObject obj = Instantiate(Resources.Load("Prefabs/Dlg/DlgOk")) as GameObject;
        Transform trans = obj.GetComponent<Transform>();
        trans.parent = GameObject.Find("CameraUI").GetComponent<Transform>();
        trans.localPosition = new Vector3(0f, 0f, -500f);
        trans.localRotation = Quaternion.identity;
        trans.localScale = Vector3.one;

        obj.GetComponent<AppDlgOk>().Init(_dele, _title, _text, _btnText);
        NGUITools.AdjustDepth(obj, depth);
    }

    public void Init(DlalogReturnDelegate _dele, string _title, string _text, string _btnText)
    {
        if (_dele != null)
            returnDelegate = _dele;

        _LblTitle.text = _title;
        _LblContent.text = _text;
        _LblButtonText.text = _btnText;
    }

    override protected void onOpenDlg()
    {
        base.onOpenDlg();
    }

    override protected void onCloseDlg(GameObject _obj)
    {
        base.onCloseDlg(_obj);
        if (returnDelegate != null && _obj != null)
        {
            returnDelegate("close");
        }
    }
}
