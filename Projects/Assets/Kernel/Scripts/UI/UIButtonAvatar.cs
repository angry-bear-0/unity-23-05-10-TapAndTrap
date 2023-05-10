using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonAvatar : MonoBehaviour
{
	[SerializeField] protected int			_Number;
	[SerializeField] protected GameObject	_MessageReceiver;
	[SerializeField] protected GameObject	_Selected;
	[SerializeField] protected GameObject	_Bought;
    [SerializeField] protected UISprite		_Cloth;

	public void OnClick()
	{
		_MessageReceiver.SendMessage("onBtnItem", _Number);
	}
	void initUI()
	{
		if(_Number == GD.dtHeroIdx)
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
		HeroInfo ai = GD.dtHeroInfos[_Number];
		_Cloth.spriteName = ai.data.clothes[ai.clothIdx].sprite;
		if(ai.bought[ai.clothIdx])
		{
			bool isSelected = GD.dtHeroIdx == _Number;
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
