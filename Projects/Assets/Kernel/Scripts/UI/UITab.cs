using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITab : MonoBehaviour
{
	[SerializeField] protected int			_Idx = 0;
	[SerializeField] protected GameObject[]	_ActivateObjs;
	[SerializeField] protected GameObject[] _DectivateObjs;

	public int idx { get { return _Idx;} }
	
	public void ProcBtnClick()
	{
		foreach(GameObject go in _DectivateObjs)
		{
			go.SetActive(false);
		}
	}

	public void OnBtnClick()
	{
		ProcBtnClick();
		//transform.GetComponentInParent<DlgBase>().SendMessage("OnTab", _Idx);
	}

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}
}
