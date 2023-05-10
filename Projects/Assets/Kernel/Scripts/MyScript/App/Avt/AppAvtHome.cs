using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppAvtHome : AppAvtBase
{
    [SerializeField] PfRound[] _PfRounds;

    protected new void Start()
    {
        base.Start();
        for (int i = 0; i < _PfRounds.Length; i++)
            _PfRounds[i].Init(this, i);
    }

    protected new void Update()
    {
        base.Update();
    }

    public void OnClickMenu()
    {
        AppDlgMenu.OpenDlg(handleClickMenu);
    }
    public void OnClickSetting()
    {
        AppDlgSetting.OpenDlg(handleClickSetting);
    }
    public void OnClickRound(int _level)
    {
        if (_level > AppClient.me.level || _level < 0)
            return;

        AppDlgYesNo.OpenDlg(handleClickRound, AppString.APP_HOME_IN_ROUND_TITLE, AppString.APP_HOME_IN_ROUND_TEXT, _level);
    }
    
    protected void handleClickRound(object _obj)
    {
        int selectLvl = (int)_obj;
        AppAvtMgr.inst.LoadScene(AppMD.appRoundUIsData[selectLvl].scnName);
        AppClient.me.lastLevel = selectLvl;
    }
    protected void handleClickMenu(object _obj)
    {

    }
    protected void handleClickSetting(object _obj)
    {

    }
}
