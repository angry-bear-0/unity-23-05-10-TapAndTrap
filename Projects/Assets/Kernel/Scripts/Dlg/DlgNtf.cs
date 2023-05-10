using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DlgNtf : DlgBase 
{
    public   UILabel  mLbMssNm;
    private  bool     mIsActive     = false;
    private  float    mAppTm        = 0.0f;
    private  float    mLmtTm        = 3.0f;

    static public void OpenDlg(string _mssName)
    {
        GameObject obj = Instantiate(Resources.Load("Prefabs/Dlg/pfDlgNtf")) as GameObject;
        Transform trans = obj.GetComponent<Transform>();
        trans.parent = GameObject.Find("CameraUI").GetComponent<Transform>();

        trans.localPosition = Vector3.zero;
        trans.localRotation = Quaternion.identity;
        trans.localScale = Vector3.one;
        NGUITools.AdjustDepth(obj, depth);

        DlgNtf script = obj.GetComponent<DlgNtf>();
        script.init(_mssName);
    }

    public void init(string _mssName)
    {
        /*OnOpen();*/
        mIsActive = true;
        mAppTm = Time.time;
        mLbMssNm.text = _mssName;
    }

	// Update is called once per frame
	new void Update () 
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
        yield return new WaitForSeconds(0.5f);
        mLbMssNm.text = " ";

        Destroy(gameObject);
        yield break;
    }
}
