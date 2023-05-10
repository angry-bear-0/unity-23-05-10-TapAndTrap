public class ShopItem
{
	public		PriceBase   price { get { updateDynaPrice(); return mPrice;} }

	protected	string      mName;
	protected	string      mDesc;
	protected	deleFunc	mBoughtFunc = null;
	protected	PriceBase	mPrice;
	public ShopItem(PriceBase _price, string _name, string _desc)
	{
		mPrice   = _price;

		mName	= _name;
		mDesc	= _desc;
	}
	protected virtual void updateDynaPrice() { }
	public virtual int  GetCount()	{ return 1; }
	public virtual string  GetTitle()	{ return Lang.Get(mName); }
	public virtual string  GetDesc()	{ return Lang.Get(mDesc); }
	public void Buy(deleFunc _callback)
	{
		mBoughtFunc = _callback;
		updateDynaPrice();
		price.Consume(boughtProcess);
	}
	private void boughtProcess(object _price)
	{
		boughted(_price);
		if(mBoughtFunc != null)
			mBoughtFunc(_price);
	}
	protected virtual void boughted(object _price)	{ }
}
public class ShopItemShield : ShopItem
{
	public ShopItemShield() : base(new PriceCoin(3000), "Shield", "ShieldDesc") { }
	public		override int	GetCount()				{ return GD.dtShieldCnt; }
	protected	override void	boughted(object _price) { GD.dtShieldCnt++; }
}
public class ShopItemFood : ShopItem
{
	public ShopItemFood() : base(new PriceCoin(500), "Food", "FoodDesc") { }
	public override int GetCount() { return GD.dtFoodCnt; }
	protected override void boughted(object _price) { GD.dtFoodCnt++; }
}
public class ShopItemSuperFood : ShopItem
{
	public ShopItemSuperFood() : base(new PriceGold(3), "SuperFood", "SuperFoodDesc") { }
	public override int GetCount() { return GD.dtSuperFoodCnt; }
	protected override void boughted(object _price) { GD.dtSuperFoodCnt++; }
}
public class ShopItemHeadStart : ShopItem
{
	public ShopItemHeadStart() : base(new PriceCoin(2000), "HeadStart", "HeadStartDesc") { }
	public override int GetCount() { return GD.dtHeadSartCnt; }
	protected override void boughted(object _price) { GD.dtHeadSartCnt++; }
}
public class ShopItemScoreBooster : ShopItem
{
	public ShopItemScoreBooster() : base(new PriceGold(7), "ScoreBooster", "ScoreBoosterDesc") { }
	public override int GetCount() { return GD.dtScoreBoosterCnt; }
	protected override void boughted(object _price) { GD.dtScoreBoosterCnt++; }
	public override string  GetDesc()	{ return Lang.Format(mDesc, GD.dtUpgradeScoreBooster.val); }
}
public class ShopItemMission : ShopItem
{
	int nMissionIdx = 0;
	public ShopItemMission(int _missionIdx) : base(new PriceGold(15), "SkipMission", "SkipMissionDesc") { nMissionIdx = _missionIdx; }
	public override int GetCount() { return 0; }
	protected override void boughted(object _price) 
	{
		switch(nMissionIdx)
		{
		case 0:	MissionMgr.BuyMission1();	break;
		case 1: MissionMgr.BuyMission2();	break;
		case 2: MissionMgr.BuyMission3();	break;
		}
	}
	public override string  GetTitle()	{ return Lang.Format(mName, nMissionIdx + 1); }
	public override string  GetDesc()	{ return Lang.Format(mDesc, nMissionIdx + 1); }
	protected override void updateDynaPrice() 
	{
		MissionInfo mi = MissionMgr.getMision(nMissionIdx);
		if (mPrice.kind != PriceKind.coin)
			mPrice.price = mi.GetPriceByGem();
	}
}
