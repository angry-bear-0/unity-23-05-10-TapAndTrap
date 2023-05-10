using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AppScnBase : MonoBehaviour
{
    [SerializeField] protected TweenAlpha _Loading;

    protected static AppScnBase mInst = null;
    public static AppScnBase inst { get { return mInst; } }

    protected int mFrmCnt = 0;

    protected void Awake()
    {
        mInst = this;
        AppAvtMgr.inst.activeScn = this;
        mFrmCnt = Time.frameCount;
    }

    protected void Start()
    {

    }
    protected void Update()
    {
        if (Time.frameCount - 2 == mFrmCnt)
            Invoke("StartScene", 1f);
    }

    public void StartScene()
    {
        Debug.Log("StartScene");
        _Loading.PlayForward();
    }

    public void ExitScene()
    {
        Debug.Log("ExitScene");
        _Loading.PlayReverse();
    }
}

