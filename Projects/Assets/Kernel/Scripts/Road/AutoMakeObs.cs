using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMakeObs {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    static public void SetCorrectPosition(Transform _target, Transform _obj)
    {
       Vector3 mtPos = _target.position;
       Vector3 moPos = _obj.position;
        moPos.x = mtPos.x - 177;
        moPos.y = mtPos.y - 70;
        moPos.z = mtPos.z;
        _obj.transform.position = moPos;
    }
}
