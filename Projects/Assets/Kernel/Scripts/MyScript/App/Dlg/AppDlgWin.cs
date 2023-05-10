using UnityEngine;

public class AppDlgWin : AppDlgBase
{
    [SerializeField] UILabel _LblLevel;
    [SerializeField] UILabel _LblCount;
    [SerializeField] UILabel _LblTime;
    [SerializeField] UISprite[] _SprStars;

    public static void OpenDlg()
    {
        OpenDlg(null);
    }

    public static void OpenDlg(DlalogReturnDelegate _dele)
    {
        GameObject obj = Instantiate(Resources.Load("Prefabs/Dlg/DlgWin")) as GameObject;
        Transform trans = obj.GetComponent<Transform>();
        trans.parent = GameObject.Find("CameraUI").GetComponent<Transform>();
        trans.localPosition = new Vector3(0f, 0f, -500f);
        trans.localRotation = Quaternion.identity;
        trans.localScale = Vector3.one;

        obj.GetComponent<AppDlgWin>().Init(_dele);
        NGUITools.AdjustDepth(obj, depth);
    }

    public void Init(DlalogReturnDelegate _dele)
    {
        if (_dele != null)
            returnDelegate = _dele;
        for (int i = 0; i < 3; i++)
        {
            if (i <= AppClient.me.stars[AppClient.me.lastLevel])
                _SprStars[i].spriteName = "sprIconStar_01";
            else
                _SprStars[i].spriteName = "sprIconStar_00";
        }

        _LblTime.text = string.Format("{0}s", Mathf.RoundToInt(AppClient.me.leftTime + 1));
        _LblCount.text = AppClient.me.leftCount.ToString();
    }

    protected new void Update()
    {
        base.Update();
        for (int i = 0; i < 3; i++)
        {
            if (i <= AppClient.me.stars[AppClient.me.lastLevel])
                _SprStars[i].spriteName = "sprIconStar_01";
            else
                _SprStars[i].spriteName = "sprIconStar_00";
        }

        _LblTime.text = string.Format("{0}s", Mathf.RoundToInt(AppClient.me.leftTime + 1));
        _LblCount.text = AppClient.me.leftCount.ToString();
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
                case "btnNext":
                    returnDelegate("next");
                    break;
                case "btnSetting":
                    returnDelegate("setting");
                    break;
                case "btnOut":
                    returnDelegate("out");
                    break;
                default:
                    returnDelegate("close");
                    break;
            }
        }
    }
}

