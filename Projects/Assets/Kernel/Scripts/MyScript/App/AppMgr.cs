using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppMgr : MonoBehaviour
{
    static public AppMgr inst { get; private set; } = null;
    static public int appState = AppState.none;

    public AudioSource _BgmGame;

    void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
