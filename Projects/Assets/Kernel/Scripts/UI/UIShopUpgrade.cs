using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIShopUpgrade : MonoBehaviour
{
	[SerializeField] protected  int         _Number;
	[SerializeField] protected  UILabel     _TxtTitle;
	[SerializeField] protected  UILabel     _TxtDesc;
	[SerializeField] protected  GameObject  _GoGem;
	[SerializeField] protected  GameObject  _GoCoin;
	[SerializeField] protected  GameObject  _GoMaxLevel;
	[SerializeField] protected  UILabel     _TxtPriceGem;
	[SerializeField] protected  UILabel     _TxtPriceCoin;
	[SerializeField] protected  GameObject[] _GoLevels;

	// Start is called before the first frame update
	void Start()
    {
		updateUI();
    }

	public void updateUI()
	{
		ShopUpgrade su = GD.shopUpgradeInfos[_Number];
		_TxtTitle.text  = su.GetTitle();
		_TxtDesc.text   = su.GetDesc();

		if (su.isMaxLevel)
		{
			_GoGem.SetActive(false);
			_GoCoin.SetActive(false);
			_GoMaxLevel.SetActive(true);
		}
		else
		{
			_GoMaxLevel.SetActive(false);
			if(su.price.kind == PriceKind.coin)
			{
				_GoGem.SetActive(false);
				_GoCoin.SetActive(true);
				_TxtPriceCoin.text = NGUIText.SpaceDigitString(su.price.price);
			}
			else
			{
				_GoGem.SetActive(true);
				_GoCoin.SetActive(false);
				_TxtPriceGem.text = NGUIText.SpaceDigitString(su.price.price);
			}
		}
		
		if (_GoLevels.Length != su.maxLevel)
			Debug.LogError("Price not equal with UI element count");
		
		for (int i = 0; i < _GoLevels.Length; i ++)
			_GoLevels[i].SetActive(i < su.level);
	}

	public void onBought(object param)
	{
		DlgShop.inst.UpdateCurrencyInfo();
		Util.PlaySound("sfxDropCoin");
		updateUI();
	}
	public void OnClickBuy()
	{
		ShopUpgrade su = GD.shopUpgradeInfos[_Number];
		su.Buy(onBought);
	}
}
