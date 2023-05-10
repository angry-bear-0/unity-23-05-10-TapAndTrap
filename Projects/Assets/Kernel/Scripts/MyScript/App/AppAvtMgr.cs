using System.Collections;
//using System.Collections.Generic;
//using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AppAvtMgr : MonoBehaviour
{
    private static AppAvtMgr s_inst = null;
    public static AppAvtMgr inst
    {
        get
        {
            if (AppAvtMgr.s_inst == null)
            {
                GameObject go = new GameObject("0_AvtMgr");
                AppAvtMgr.s_inst = go.AddComponent<AppAvtMgr>();
                GameObject.DontDestroyOnLoad(go);
            }
            return AppAvtMgr.s_inst;
        }
    }

    private AppAvtBase mActiveAvt;
    private AppScnBase mActiveScn;
    public AppAvtBase activeAvt { get { return mActiveAvt; } set { mActiveAvt = value; } }
    public AppScnBase activeScn { get { return mActiveScn; } set { mActiveScn = value; } }

    private static Rect mRect = new Rect(2, 2, 300, 20);

    void OnDestroy()
    {
        AppClient.Exit();
    }

    void Start()
    {
        AppClient.Start();
    }

    void Update()
    {
        AppClient.me.Update(Time.deltaTime);
    }

    void OnGUI()
    {
        GUI.Label(mRect, "00");
    }

    public void LoadScene(string _name)
    {
        if (activeScn)
            activeScn.ExitScene();
        StartCoroutine(loadSceneCoroutine(_name));
    }
 
    protected IEnumerator loadSceneCoroutine(string _name)
    {
        yield return new WaitForSecondsRealtime(1.0f);
        SceneManager.LoadScene(_name);
        yield break;
    }
}


