using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonCloth : MonoBehaviour
{
	[SerializeField] protected int			_Number;
	[SerializeField] protected PnlHero	_Panel;
	[SerializeField] protected GameObject   _Selected;
	[SerializeField] protected GameObject   _Bought;
	[SerializeField] protected UISprite		_SptCloth;

    // Update is called once per frame
    void Update()
    {
        
    }

	public void OnClick()
	{
		_Panel.gameObject.SendMessage("onBtnCloth", _Number);
	}

	void updateUI()
	{
		HeroInfo ai = GD.dtHeroInfos[_Panel.curAvatar];
		if (_Number == ai.clothIdx)
		{
			GetComponent<UIToggle>().value = true;
			GetComponent<UIToggle>().Start();
			_Panel.gameObject.SendMessage("onBtnCloth", _Number);
		}

		if(ai.bought[_Number])
		{
			bool isSelected = _Number == ai.clothIdx;
			_Selected.SetActive(isSelected);
			_Bought.SetActive(!isSelected);
		}
		else
		{
			_Selected.SetActive(false);
			_Bought.SetActive(false);
		}

		_SptCloth.spriteName = ai.data.clothes[_Number].sprite;
		var sp = _SptCloth.GetAtlasSprite();
		_SptCloth.height	= 128;
		_SptCloth.width		= 128 * sp.width / sp.height;
	}
}
