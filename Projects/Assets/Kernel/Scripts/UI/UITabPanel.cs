using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITabPanel : MonoBehaviour
{
	[SerializeField] protected int			_Idx = 0;
	[SerializeField] protected GameObject[]	_Panels;

	protected GameObject[]	mPanels = null;

	public int idx { get { return _Idx;} }
	
	public void OnTab(int _idx)
	{
		if (_idx == _Idx)
		{
			if (mPanels == null)
			{
				DlgBase	dlg = transform.GetComponentInParent<DlgBase>();
				mPanels = new GameObject[_Panels.Length];
				for(int i = 0; i < _Panels.Length; i ++)
				{
					mPanels[i] = GameObject.Instantiate(_Panels[i], transform.parent);
					mPanels[i].transform.localPosition = Vector3.zero;
					mPanels[i].transform.localScale = Vector3.one;
					mPanels[i].GetComponent<PanelBase>().Init(dlg);
				}
			}
			else
			{
				foreach(GameObject go in mPanels)
				{
					go.SetActive(true);
				}
			}
		}
		else if (mPanels != null)
		{
			foreach(GameObject go in mPanels)
			{
				go.SetActive(false);
			}
		}
	}

	public void OnBtnClick()
	{
		Util.SendMessageRecursively(transform.GetComponentInParent<DlgBase>().gameObject, "OnTab", (object)_Idx, 1);
	}

	void Update()
	{

	}
}
