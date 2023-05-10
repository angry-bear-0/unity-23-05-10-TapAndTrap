using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PriceKind {none, coin, gold, gem, count};

public class PriceBase
{
	protected int		mVal;
	public int			price { get { return Mathf.Abs(mVal); } set { mVal = Mathf.Abs(value); } }
	public PriceKind	kind = PriceKind.none;

	public PriceBase()			{ mVal = 0;	kind = PriceKind.none;}
	public PriceBase(int _val)	{ mVal = _val; }

	public virtual	string		str			{ get { return string.Empty; } } 
	public virtual	bool		isBigDeal	{ get { return false; } } 
	public virtual	void		Consume(deleFunc _func) { }
}

public class PriceCoin : PriceBase
{
	public PriceCoin(int _val) : base(_val) { kind = PriceKind.coin; }
	public override	string		str			{ get { return mVal == 0 ? Lang.Get("ui_free") : "[D9E8EE]☆" + NGUIText.SpaceDigitString(mVal) + "[-]"; } }
	public string				bonusStr	{ get { return mVal == 0 ? "" : "+[D9E8EE]☆" + NGUIText.SpaceDigitString(mVal) + "[-]"; } }
	public override	bool		isBigDeal	{ get { return mVal >= 5000; } }
	public override	void Consume(deleFunc _func)
	{
		if (GD.dtCoins < mVal)
		{ 
			DlgOkCancel.OpenDlg(null, null, Lang.Get("uiMsgNoEnoughCoin"));
		}
		else
		{
			if (isBigDeal)
				DlgOkCancel.OpenDlg(confirmBuy, null, Lang.Format("uiMsgConfirmConsumeCoins", NGUIText.SpaceDigitString(mVal)), _func);
			else
				confirmBuy((object)_func);
		}
	}

	void confirmBuy(object _param)
	{
		GD.dtCoins -= mVal;
		deleFunc func = (deleFunc) _param;
		func(null);
	}
}
public class PriceGold : PriceBase 
{
	public PriceGold(int _val) : base(_val)	{ kind = PriceKind.gold; }
	public override	string		str			{ get { return mVal == 0 ? Lang.Get("ui_free") : "[FFD138]★" + NGUIText.SpaceDigitString(mVal) + "[-]";} }
	public override	bool		isBigDeal	{ get { return mVal >= 1; } }
	public override void Consume(deleFunc _func)
	{
		if(GD.dtGems < mVal)
		{
			DlgOkCancel.OpenDlg(null, null, Lang.Get("uiMsgNoEnoughGold"));
		}
		else
		{
			if(isBigDeal)
				DlgOkCancel.OpenDlg(confirmBuy, null, Lang.Format("uiMsgConfirmConsumeGolds", NGUIText.SpaceDigitString(mVal)), _func);
			else
				confirmBuy((object)_func);
		}
	}
	void confirmBuy(object _param)
	{
		GD.dtGems -= mVal;
		deleFunc func = (deleFunc) _param;
		func(null);
	}
}

public class PriceGem : PriceBase 
{
	public PriceGem(int _val) : base(_val)	{ kind = PriceKind.gem; }
	public override	string		str			{ get { return mVal == 0 ? Lang.Get("ui_free") : "[371CFF]☎" + NGUIText.SpaceDigitString(mVal) + "[-]"; } }
	public override	bool		isBigDeal	{ get { return mVal >= 1; } } 
}
