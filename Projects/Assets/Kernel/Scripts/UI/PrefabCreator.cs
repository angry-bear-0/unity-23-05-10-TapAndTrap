using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabCreator : MonoBehaviour
{
	[SerializeField] protected GameObject	_Prefab;


    // Start is called before the first frame update
    void Awake()
    {
		GameObject go = GameObject.Instantiate(_Prefab, Vector3.zero, Quaternion.identity, transform) as GameObject;
		go.transform.localPosition	= Vector3.zero;
		go.transform.localRotation	= Quaternion.identity;
		go.transform.localScale		= Vector3.one;
    }

}
