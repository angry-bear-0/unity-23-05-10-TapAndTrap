public class PetData
{
	public int			hp;
	public int			baseMulti;
	public string		name;
	public int			needLvl;
	public PriceBase	price;

	public PetData(int _hp, int _mult, string _name, int _needLvl, PriceBase _price)
	{
		hp			= _hp;
		baseMulti	= _mult;
		name		= _name;
		needLvl		= _needLvl;
		price		= _price;
	}
}
public class PetInfo
{
	public PetData	data;
	public bool		bought = false;
	public PetInfo(PetData _data)
	{
		data	= _data;
		bought	= data.price == null || data.price.price <= 0;
	}
	public void Load()
	{
		bought	= ObscuredPrefs.GetBool("petboughted" + data.name, bought);
	}
	public void Save()
	{
		ObscuredPrefs.SetBool("petboughted" + data.name, bought);
	}
}