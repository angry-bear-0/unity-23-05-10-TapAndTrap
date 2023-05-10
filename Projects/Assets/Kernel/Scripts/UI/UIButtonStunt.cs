using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonStunt : MonoBehaviour
{
	[SerializeField] protected int			_Number;
	[SerializeField] protected GameObject	_MessageReceiver;
	[SerializeField] protected GameObject	_Selected;
	[SerializeField] protected GameObject	_Bought;

	public void OnClick()
	{
		_MessageReceiver.SendMessage("onBtnItem", _Number);
	}

	void initUI()
	{
		if(_Number == GD.dtStuntIdxs[2] || -1 == GD.dtStuntIdxs[2] && _Number == GD.dtStuntIdxs[1] || -1 == GD.dtStuntIdxs[2] && -1 == GD.dtStuntIdxs[1] && _Number == GD.dtStuntIdxs[0])
		{
			GetComponent<UIToggle>().value = true;
			GetComponent<UIToggle>().Start();
			_MessageReceiver.SendMessage("onBtnItem", _Number);
			transform.parent.GetComponent<UIScrollView>().MoveRelative(new Vector3(-120f*_Number, 0, 0));
		}
		updateUI();
	}

	void updateUI()
	{
		StuntInfo si = GD.dtStuntInfos[_Number];
		if(si.bought)
		{
			bool isSelected = GD.dtStuntIdxs[si.data.difficulty] == _Number;
			_Selected.SetActive(isSelected);
			_Bought.SetActive(!isSelected);
		}
		else
		{
			_Selected.SetActive(false);
			_Bought.SetActive(false);
		}
	}
}
