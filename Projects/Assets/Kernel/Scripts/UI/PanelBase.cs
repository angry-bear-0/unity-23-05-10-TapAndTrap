using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelBase : MonoBehaviour
{
	protected DlgBase mDlg;

	virtual public void Init(DlgBase _dlgParent)
	{
		mDlg = _dlgParent;
		mDlg.onCloseDelegate += closeDelegate;
		NGUITools.AdjustDepth(gameObject, mDlg.GetComponent<UIPanel>().depth);
	}

	virtual protected void onClosedDlg()	{ }

	protected void closeDelegate(GameObject _goBtn)
	{
		mDlg.onCloseDelegate -= closeDelegate;
		onClosedDlg();
	}
}
