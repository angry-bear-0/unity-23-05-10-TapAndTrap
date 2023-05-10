using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppAvtBase : MonoBehaviour
{
    // Start is called before the first frame update
    protected AppAvtBase mInst = null;
    public AppAvtBase inst { get { return mInst; } }

    protected void Awake()
    {
        mInst = this;
        AppAvtMgr.inst.activeAvt = this;
    }

    protected void Start()
    {

    }
    
    protected void Update()
    {
        
    }

}
