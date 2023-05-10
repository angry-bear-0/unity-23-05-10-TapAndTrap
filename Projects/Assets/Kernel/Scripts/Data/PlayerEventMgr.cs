using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEventMgr : MonoBehaviour
{
    public static PlayerEventMgr inst {get; private set;}

    // Start is called before the first frame update
    void Start()
    {
        inst = this;

		GD.Load();
		OnInit();
    }

	public void OnInit()
	{
		AwardMgr.OnInit();
		MissionMgr.OnInit();
	}

	public void OnEvent(PlayerEventKind _event, int _param = 1)
	{
		AwardMgr.OnEvent(_event, _param);
        MissionMgr.OnEvent(_event, _param);
	}
}
