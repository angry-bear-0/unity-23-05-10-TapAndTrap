using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DlgMgr : MonoBehaviour
{
    public static DlgMgr MInst;
    void Awake()
    {
        MInst = this.GetComponent<DlgMgr>();
    }
    public DlgMgr dlgMgr
    {
        get 
        {
            return MInst;
        }
    }
    public void DlgSettingManager(object _userData)
    {
        string[] evtname = (string[])_userData;
        switch (evtname[0])
        {
            case "MusicScroll":
                GD.dtBgmVolum = float.Parse(evtname[1]);
                break;
            case "SoundScroll":
                GD.dtSfxVolum = float.Parse(evtname[1]);
                break;
        }
        GD.Save();
    }

}
