using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DlgMe : DlgBase
{
	[SerializeField] protected	UITabPanel[]		_Tabs;

	[SerializeField] protected  TweenNumberText		_CoinCount;
	[SerializeField] protected  TweenNumberText		_GemCount;

	public static DlgMe	inst;
	public static int	curTabIdx = 0;
	// Use this for initialization
	static public void OpenDlg()
	{
		GameObject obj = Instantiate(Resources.Load("Prefabs/Dlg/pfDlgMe")) as GameObject;

		Transform trans = obj.GetComponent<Transform>();
		trans.parent = GameObject.Find("CameraUI").GetComponent<Transform>();

		trans.localPosition = Vector3.zero;
		trans.localRotation = Quaternion.identity;
		trans.localScale = Vector3.one;
		NGUITools.AdjustDepth(obj, depth);

		DlgMe script = obj.GetComponent<DlgMe>();
		script.Init();
	}
	public void Init()
	{
		inst = this;

		_Tabs[curTabIdx].GetComponent<UIToggle>().value = true;
		_Tabs[curTabIdx].GetComponent<UIToggle>().Start();
		_Tabs[curTabIdx].OnBtnClick();

		_GemCount.SetNumber(GD.dtGems,	0.0f);
		_CoinCount.SetNumber(GD.dtCoins,	0.0f);
		onOpen();
	}

	void OnDestroy()
	{
		inst = null;
		GD.Save();
	}

	public void OnTab(int _idx)
	{
		curTabIdx = _idx;
	}

	public void UpdateCurrencyInfo()
	{
		_GemCount.SetNumber(GD.dtGems, 0.7f);
		_CoinCount.SetNumber(GD.dtCoins, 0.7f);
	}

	public void OnClickAddTreasure()
	{
		DlgShop.OpenDlg(2);
	}
}
