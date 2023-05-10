using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonPet : MonoBehaviour
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
		if(_Number == GD.dtPetIdx)
		{
			GetComponent<UIToggle>().value = true;
			GetComponent<UIToggle>().Start();
			_MessageReceiver.SendMessage("onBtnItem", _Number);
			transform.parent.GetComponent<UIScrollView>().MoveRelative(new Vector3(-150f*_Number, 0, 0));
		}
		updateUI();
	}

	void updateUI()
	{
		PetInfo pi = GD.dtPetInfos[_Number];
		if(pi.bought)
		{
			bool isSelected = GD.dtPetIdx == _Number;
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
