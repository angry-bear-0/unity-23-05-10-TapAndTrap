using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppDlgSetting : AppDlgBase
{
    public static void OpenDlg()
    {
        OpenDlg(null);
    }

    public static void OpenDlg(DlalogReturnDelegate _dele)
    {
        GameObject obj = Instantiate(Resources.Load("Prefabs/Dlg/DlgSetting")) as GameObject;
        Transform trans = obj.GetComponent<Transform>();
        trans.parent = GameObject.Find("CameraUI").GetComponent<Transform>();
        trans.localPosition = new Vector3(0f, 0f, -500f);
        trans.localRotation = Quaternion.identity;
        trans.localScale = Vector3.one;

        obj.GetComponent<AppDlgSetting>().Init(_dele);
        NGUITools.AdjustDepth(obj, depth);
    }

    public void Init(DlalogReturnDelegate _dele)
    {
        if (_dele != null)
            returnDelegate = _dele;
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
            switch (_obj.name)
            {
                case "btnResume":
                    returnDelegate("resume");
                    break;
                case "btnRestart":
                    returnDelegate("restart");
                    break;
                case "btnSetting":
                    returnDelegate("setting");
                    break;
                case "btnOut":
                    returnDelegate("out");
                    break;
                case "btnExit":
                    returnDelegate("exit");
                    break;
                case "btnClose":
                    returnDelegate("close");
                    break;
                default: break;
            }
        }
    }
}

