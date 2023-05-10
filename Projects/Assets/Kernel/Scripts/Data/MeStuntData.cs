public class StuntData
{
	public string		name;
	public string		ani;
	public PriceBase	price;
	public int			needLvl;
	public int			cheer;
	public float		inputTm;
	public int			difficulty;

	public StuntData(string _name, string _ani, PriceBase _price, int _needLvl, int _cheer, float _inputTm, int _difficulty)
	{
		name		= _name;
		ani			= _ani;
		price		= _price;
		needLvl		= _needLvl;
		cheer		= _cheer;
		inputTm		= _inputTm;
		difficulty	= _difficulty;
	}
}

public class StuntInfo
{
	public StuntData data;
	public bool bought = false;
	public StuntInfo(StuntData _data)
	{
		data = _data;
		bought = data.price == null || data.price.price <= 0;
	}
	public void Load()
	{
		bought = ObscuredPrefs.GetBool("stuntboughted" + data.name, bought);
	}
	public void Save()
	{
		ObscuredPrefs.SetBool("stuntboughted" + data.name, bought);
	}
}