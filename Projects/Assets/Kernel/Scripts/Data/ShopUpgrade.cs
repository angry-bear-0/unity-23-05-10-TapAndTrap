public class ShopUpgrade
{
	protected   string      mName;
	protected   string      mDesc;
	protected	PriceBase[]	mPrices = null;
	protected	float		mIniVal = 0;
	protected	float		mStepVal = 0;
	protected   deleFunc    mBoughtFunc = null;
	public		float		val { get { return mIniVal + mStepVal * level; } }
	public		PriceBase	price { get { return  mPrices[level]; } }
	public		int			level {get; protected set;} = 0;
	public		bool		isMaxLevel	{ get {return level >= mPrices.Length; } }
	public		int			maxLevel	{ get {return mPrices.Length; } }
	public ShopUpgrade(string _name, string _desc, float _iniVal, float _stepVal, PriceBase[] _prices)
	{
		mName		= _name;
		mDesc		= _desc;
		mPrices		= _prices;
		mIniVal		= _iniVal;
		mStepVal	= _stepVal;
	}
	public void Load()
	{
		level  = ObscuredPrefs.GetInt("ShopUpgrade.level" + mName, level);
	}
	public void Save()
	{
		ObscuredPrefs.SetInt("ShopUpgrade.level" + mName, level);
	}
	public void Buy(deleFunc _callback)
	{
		mBoughtFunc = _callback;
		if (isMaxLevel)
			return;
		mPrices[level].Consume(boughtProcess);
	}
	private void boughtProcess(object _price)
	{
		level ++;
		if(mBoughtFunc != null)
			mBoughtFunc(_price);
	}
	public virtual string GetTitle() { return Lang.Get(mName); }
	public virtual string GetDesc() { return Lang.Format(mDesc, val, mStepVal); }
}
public class ShopUpgradeFly : ShopUpgrade
{
	public ShopUpgradeFly(): base("FlyingUpgrade", "FlyingUpgradeDesc", 6, 2,
		new PriceBase[] {new PriceCoin(3000), new PriceCoin(4500), new PriceCoin(6750), new PriceCoin(10000), new PriceGold(70), new PriceGold(110) }) { }
}
public class ShopUpgradeMagnet : ShopUpgrade
{
	public ShopUpgradeMagnet() : base("MagnetUpgrade", "MagnetUpgradeDesc", 7, 2,
		new PriceBase[] { new PriceCoin(4000), new PriceCoin(6000), new PriceCoin(9000), new PriceCoin(13500), new PriceGold(100), new PriceGold(150) }) { }
}
public class ShopUpgradeShield : ShopUpgrade
{
	public ShopUpgradeShield() : base("ShieldUpgrade", "ShieldUpgradeDesc", 5, 1,
		new PriceBase[] { new PriceCoin(2000), new PriceCoin(3000), new PriceCoin(4500), new PriceCoin(6750), new PriceGold(50), new PriceGold(75) }) { }
}
public class ShopUpgradeShieldCT : ShopUpgrade
{
	public ShopUpgradeShieldCT() : base("ShieldUpgradeCoolTime", "ShieldUpgradeCoolTimeDesc", 30, -2,
		new PriceBase[] { new PriceCoin(2000), new PriceCoin(3000), new PriceCoin(4500), new PriceCoin(6750), new PriceGold(50), new PriceGold(75) }) { }
}
public class ShopUpgradeScoreBooster : ShopUpgrade
{
	public ShopUpgradeScoreBooster() : base("ScoreBoosterUpgrade", "ScoreBoosterUpgradeDesc", 2, 1,
		new PriceBase[] { new PriceCoin(5000), new PriceGold(37), new PriceGold(56), new PriceGold(84), new PriceGold(126), new PriceGold(190) }) { }
}
public class ShopUpgradeBalloon : ShopUpgrade
{
	public ShopUpgradeBalloon() : base("BalloonUpgrade", "BalloonUpgradeDesc", 6, 2,
		new PriceBase[] { new PriceCoin(2000), new PriceCoin(3000), new PriceCoin(4500), new PriceCoin(6750), new PriceGold(50), new PriceGold(75) }) { }
}
public class ShopUpgradeDoubleCoin : ShopUpgrade
{
	public ShopUpgradeDoubleCoin() : base("DoubleCoinUpgrade", "DoubleCoinUpgradeDesc", 7, 3,
		new PriceBase[] { new PriceCoin(2000), new PriceCoin(3000), new PriceGold(22), new PriceGold(34), new PriceGold(50), new PriceGold(75) }) { }
}