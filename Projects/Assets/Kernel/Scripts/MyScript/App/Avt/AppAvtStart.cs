using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppAvtStart : AppAvtBase
{
    // Start is called before the first frame update
    protected new void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected new void Update()
    {
        base.Update();
    }

    public void OnClickBtnPlay()
    {
        Debug.Log("onClickBtnPlay");
        AppAvtMgr.inst.LoadScene("scnHome");
    }

    public void OnClickBtnSetting()
    {
        AppDlgMenu.OpenDlg(handleClickSetting);
    }

    public void handleClickSetting(object _obj)
    {

    }
}

