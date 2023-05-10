using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PfTechSlot : MonoBehaviour
{

    [SerializeField] UISprite _SprTech;
    [SerializeField] UISprite _SprDesc;
    [SerializeField] UISprite _SprLock;
    [SerializeField] UILabel _LblDesc;
    [SerializeField] UILabel _LblLock;
    [SerializeField] GameObject _GoParticle;

    protected AppAvtRound mAvtInst;
    protected int mIndex = 0;
    public int index { get { return mIndex; } set { mIndex = value; } }

    public void Init (AppAvtRound _avtInst, int _index) 
    {
        if (_index < 0 && _index >= AppMD.APP_MAX_TECH_CNT)
            return;
        index = _index;


        AppTechData appTechData = AppMD.appTechsData[_index];
        _SprTech.spriteName = appTechData.spriteName;

        _LblLock.enabled = false;
        _LblDesc.enabled = false;

        _SprLock.enabled = appTechData.lockState;
        _SprDesc.enabled = appTechData.descState;
    }

    public void OnClick()
    {
        mAvtInst.OnClickTech(index);
    }
}
