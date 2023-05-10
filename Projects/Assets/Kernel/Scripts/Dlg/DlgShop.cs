using System.Collections;
using UnityEngine;

public class DlgShop : DlgBase 
{
	[SerializeField] protected  UITabPanel[]        _Tabs;

	[SerializeField] protected  TweenNumberText     _CoinCount;
	[SerializeField] protected  TweenNumberText     _GemCount;

	public static DlgShop inst {get; private set; } = null;
	private static int   mCurTabIdx = 0;

	// Use this for initialization
	static public void OpenDlg(int _idx = -1)
    {
        GameObject obj = Instantiate(Resources.Load("Prefabs/Dlg/pfDlgShop")) as GameObject;
        Transform trans = obj.GetComponent<Transform>();
        trans.parent = GameObject.Find("CameraUI").GetComponent<Transform>();

        trans.localPosition = Vector3.zero;
        trans.localRotation = Quaternion.identity;
        trans.localScale = Vector3.one;
        NGUITools.AdjustDepth(obj, depth);

        DlgShop script = obj.GetComponent<DlgShop>();
        script.Init(_idx);
    }
	public void Init(int _idx)
	{
		inst = this;
		if (_idx != -1)
			mCurTabIdx = _idx;
		_Tabs[mCurTabIdx].GetComponent<UIToggle>().value = true;
		_Tabs[mCurTabIdx].GetComponent<UIToggle>().Start();
		_Tabs[mCurTabIdx].OnBtnClick();

		_GemCount.SetNumber(GD.dtGems, 0.0f);
		_CoinCount.SetNumber(GD.dtCoins, 0.0f);
		onOpen();
	}

	void OnDestroy()
	{
		inst = null;
		GD.Save();
	}

	public void OnTab(int _idx)
	{
		mCurTabIdx = _idx;
	}

	public void UpdateCurrencyInfo()
	{
		_GemCount.SetNumber(GD.dtGems, 0.7f);
		_CoinCount.SetNumber(GD.dtCoins, 0.7f);
	}
}
