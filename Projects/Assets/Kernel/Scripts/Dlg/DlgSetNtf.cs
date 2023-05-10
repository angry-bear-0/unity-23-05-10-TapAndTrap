using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DlgSetNtf : DlgBase 
{
    public  UILabel     mLbMulti;
    private bool        mIsActive   = false;
    private float       mAppTm      = 0.0f;
    private float       mLmtTm      = 3.0f;

    static public void OpenDlg(string _multiX)
    {
        GameObject obj = Instantiate(Resources.Load("Prefabs/Dlg/pfDlgSetNtf")) as GameObject;
        Transform trans = obj.GetComponent<Transform>();
        trans.parent = GameObject.Find("CameraUI").GetComponent<Transform>();

        trans.localPosition = Vector3.zero;
        trans.localRotation = Quaternion.identity;
        trans.localScale = Vector3.one;
        NGUITools.AdjustDepth(obj, depth);

        DlgSetNtf script = obj.GetComponent<DlgSetNtf>();
        script.init(_multiX);
    }

    public void init(string _multiX)
    {
        /*OnOpen();*/
        mIsActive = true;
        mAppTm = Time.time;
        mLbMulti.text = _multiX;
    }

    // Update is called once per frame
    new void Update()
    {
        if (mIsActive)
        {
            if (Time.time - mAppTm > mLmtTm)
            {
                StartCoroutine(CloseDlgRoutin());
            }
        }
    }
    IEnumerator CloseDlgRoutin()
    {
        /*OnClose();*/
        Cmm.SendMessageRecursively(gameObject, "PlayReverse", 2);
        yield return new WaitForSeconds(2f);
        mLbMulti.text = " ";
        Destroy(gameObject);
        yield break;
    }
}
