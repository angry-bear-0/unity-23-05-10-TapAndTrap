using System.Collections.Generic;
using UnityEngine;
public class ClothData
{
	public PriceBase	price;
	public string		sprite;
	public ClothData(PriceBase _price, string _sprite)
	{
		price	= _price;
		sprite	= _sprite;
	}
}
public class AvatarData
{
	public string		name;
	public ClothData[]	clothes;
	public float		pitch = 1.0f;
	public AvatarData(string _name, float _pitch, ClothData[] _clothes)
	{
		name	= _name;
		clothes	= _clothes;
		pitch	= _pitch;
	}
}

public class HeroInfo
{
	public AvatarData	data;
	public List<bool>	bought = new List<bool>();
	public int			clothIdx = 0;

	public HeroInfo(AvatarData _data)
	{
		data = _data;
		foreach(ClothData c in _data.clothes)
			bought.Add(c.price == null || c.price.price <= 0);
	}
	public void Load()
	{
		clothIdx = ObscuredPrefs.GetInt("chaClochID" + data.name, clothIdx);
		for(int i = 0; i < bought.Count; i ++)
			bought[i] = ObscuredPrefs.GetBool("cha" + data.name + i.ToString(), bought[i]);
	}
	public void Save()
	{
		ObscuredPrefs.SetInt("chaClochID" + data.name, clothIdx);
		for(int i = 0; i < bought.Count; i++)
			ObscuredPrefs.SetBool("cha" + data.name + i.ToString(), bought[i]);
	}
}