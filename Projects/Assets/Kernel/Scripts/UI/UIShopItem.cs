using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIShopItem : MonoBehaviour
{
	[SerializeField] protected	int			_Number;
    [SerializeField] protected	UILabel		_TxtCnt;
	[SerializeField] protected	UILabel		_TxtTitle;
	[SerializeField] protected	UILabel		_TxtDesc;
	[SerializeField] protected	GameObject	_GoGem;
	[SerializeField] protected	GameObject	_GoCoin;
	[SerializeField] protected	UILabel		_TxtPriceGem;
	[SerializeField] protected	UILabel		_TxtPriceCoin;

    void Start()
    {
        updateUI();
    }
	// Update is called once per frame
	void Update()
    {
        
    }

	public void updateUI()
	{
		ShopItem si = MD.shopItems[_Number];
		if (_TxtCnt != null)
			_TxtCnt.text	= si.GetCount().ToString();
		_TxtTitle.text	= si.GetTitle();
		_TxtDesc.text	= si.GetDesc();
		
		if (si.price.kind == PriceKind.coin)
		{
			_GoGem.SetActive(false);
			_GoCoin.SetActive(true);
			_TxtPriceCoin.text = NGUIText.SpaceDigitString(si.price.price);
		}
		else
		{
			_GoGem.SetActive(true);
			_GoCoin.SetActive(false);
			_TxtPriceGem.text = NGUIText.SpaceDigitString(si.price.price);
		}
	}

	public void onBought(object param)
	{
		DlgShop.inst.UpdateCurrencyInfo();
		Util.PlaySound("sfxDropCoin");
		updateUI();
	}
	public void OnClickBuy()
	{
		ShopItem si = MD.shopItems[_Number];
		si.Buy(onBought);
	}
}
