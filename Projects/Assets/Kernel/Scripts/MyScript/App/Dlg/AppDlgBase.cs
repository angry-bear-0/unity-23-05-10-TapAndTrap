using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void DlalogReturnDelegate(object _obj);

public class AppDlgBase : MonoBehaviour
{
    protected DlalogReturnDelegate returnDelegate;
    [SerializeField] protected GameObject _Block;

    static List<GameObject> stack = new List<GameObject>();
    
    public static int stackCount { get { return stack.Count; } }
    public static int depth { get { return stackCount * 100; } }
    public static void stackInit() { stack.Clear(); }


    private GameObject mSelectBtn = null;
    protected bool mInited = false;
    private bool mOpened = false;
    private bool mClosed = false;

    protected void Start()
    {
        runInitAnimation();
    }

    protected void Update()
    {
        if (!mOpened)
            StartCoroutine(openDlgAnimation());
    }


    virtual public void BlockInput(bool _state)
    {
        if (_Block != null)
            _Block.SetActive(_state);
    }
    virtual public void OnCloseButton(GameObject _obj)
    {
        mSelectBtn = _obj;
        if (mInited && !mClosed)
            StartCoroutine(closeDlgAnimation());
    }
    
    IEnumerator openDlgAnimation()
    {
        mOpened = true;
        runOpenAnimation();

        yield return new WaitForSecondsRealtime(0.05f);
            onOpenDlg();
            Util.SendMessageRecursively(gameObject, "PlayForward", 1);
        yield break;
    }
    IEnumerator closeDlgAnimation()
    {
        mInited = false;
        mClosed = true;
        runCloseAnimation();


        Util.SendMessageRecursively(gameObject, "PlayReverse", 1);
        yield return new WaitForSecondsRealtime(0.8f);
            onCloseDlg(mSelectBtn);
            runCloseAnimation();
            Destroy(gameObject);
        yield break;
    }

    virtual protected void onOpenDlg()
    {
        mInited = true;
    }
    virtual protected void onCloseDlg(GameObject _obj)
    {
        mInited = false;
    }

    virtual protected void runInitAnimation()
    {
        useGUILayout = false;
        foreach (Transform t in transform)
            if (t.GetComponent<UITweener>() != null)
                t.GetComponent<UITweener>().enabled = false;
    }
    virtual protected void runOpenAnimation()
    {
        //Util.PlaySound("sfxDlgOpen");
        stack.Add(gameObject);
        BlockInput(true);
    }

    virtual protected void runCloseAnimation()
    {
        //Util.PlaySound("sfxDlgClose");
        stack.Remove(gameObject);
        BlockInput(false);
    }
}
