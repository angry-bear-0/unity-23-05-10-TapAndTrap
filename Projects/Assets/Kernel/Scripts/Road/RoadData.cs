using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ObsKind
{
	cartstand, carttroupe, runtroupe, runstand, cartladder, hurdleup, hurdlemiddle, hurdledown, balloon, ball, flagPole2,
	flagPole3, flagPole4, swingBob,coin ,item, size
};
public enum ItemKind
{
	none, balloon, fly, magnet, shield, spring, /*plane,
	mysterBox, superMysteryBox, gem, coinBag, megaHeadStart,
	multiPler, leap, scr2x, */size
};
public enum ItemForWeek
{
    snowman, redleaves, icecream, flower, size
};
public struct ObsInfo
{
    public ObsKind kind;
    public Vector3 pos;
    public ObsInfo(ObsKind _kind, Vector3 _pos)
    {
        kind = _kind;
        pos = _pos;
    }
}
public struct Items
{
    public ItemKind Itemkind;
    public Vector3 pos;
    
    public Items(ItemKind _itemkind, Vector3 _pos)
    {
        Itemkind = _itemkind;
        pos = _pos;
    }
}
public struct Itemfws
{
    public ItemForWeek Itemfw;
    public Vector3 pos;
    public Itemfws(ItemForWeek _itemfw, Vector3 _pos)
    {
        Itemfw = _itemfw;
        pos = _pos;
    }
}
public struct Coins
{
    public Vector3 pos;
    public Coins(Vector3 _pos)
    {
        pos = _pos;
    }
}
public struct JumpCoins
{
	public Vector3 pos;
	public JumpCoins(Vector3 _pos)
	{
		pos = _pos;
	}
}
public struct RoadBlock
{
    public Items[]		rbItems;
    public ObsInfo[]	rbObsInfo;
    public Itemfws[]	rbItemfws;
    public Coins[]		rbCoinPos;
	public JumpCoins[]	rbJumpCoins;
    public RoadBlock(Items[] _items, ObsInfo[] _obsin, Itemfws[] _fws, Coins[] _coinpos, JumpCoins[] _jumpPos)
    {
        rbItems = _items;
        rbObsInfo = _obsin;
        rbItemfws = _fws;
        rbCoinPos = _coinpos;
		rbJumpCoins = _jumpPos;
    }
}
public class RoadData
{
	public static RoadBlock[] lv0 = 
	{
        //0-0
        new RoadBlock(null, null,  null,
		new Coins[] {
				new Coins(new Vector3(1.600000f, 0.500000f, 5.310000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 1.310000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 3.310000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 9.309999f)),
				new Coins(new Vector3(1.600000f, 0.500000f, 11.310000f)),	new Coins(new Vector3(0.800000f, 0.500000f, 11.850000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 12.850000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 16.850000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 7.310000f)),	new Coins(new Vector3(0.800000f, 0.500000f, 4.310000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 20.850000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 22.850000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 14.850000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 18.850000f)),}, null),
       //0-1
     new RoadBlock(null, null,  null,
		new Coins[] {
				new Coins(new Vector3(0.000000f, 0.500000f, 4.865970f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 6.865970f)),	new Coins(new Vector3(0.000000f, 0.500000f, 2.865970f)),	new Coins(new Vector3(-0.800000f, 0.500000f, 7.865970f)),
				new Coins(new Vector3(-1.600000f, 0.500000f, 8.865970f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 10.865970f)),	new Coins(new Vector3(-0.800000f, 0.500000f, 11.865970f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 12.865970f)),	new Coins(new Vector3(0.000000f, 0.500000f, 16.865970f)),	new Coins(new Vector3(0.000000f, 0.500000f, 14.865970f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 18.865970f)),	new Coins(new Vector3(0.800000f, 0.500000f, 19.865970f)),	new Coins(new Vector3(1.600000f, 0.500000f, 20.865970f)),
				new Coins(new Vector3(1.600000f, 0.500000f, 22.865970f)),	new Coins(new Vector3(0.800000f, 0.500000f, 23.865970f)),	new Coins(new Vector3(0.000000f, 0.500000f, 26.865970f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 28.865970f)),	new Coins(new Vector3(0.000000f, 0.500000f, 24.865970f)),}, null),
       //0-2
     new RoadBlock(null, null,  null,
		new Coins[] {
				new Coins(new Vector3(1.600000f, 0.500000f, 17.000000f)),
				new Coins(new Vector3(-1.600000f, 0.500000f, 15.000000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 19.000000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 15.000000f)),
				new Coins(new Vector3(1.600000f, 0.500000f, 35.000000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 21.000000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 35.000000f)),
				new Coins(new Vector3(1.600000f, 0.500000f, 23.000000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 15.000000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 35.000000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 17.000000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 19.000000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 21.000000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 23.000000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 17.000000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 19.000000f)),
				new Coins(new Vector3(-1.600000f, 0.500000f, 21.000000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 23.000000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 37.000000f)),
				new Coins(new Vector3(1.600000f, 0.500000f, 39.000000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 41.000000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 43.000000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 37.000000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 39.000000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 41.000000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 43.000000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 37.000000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 39.000000f)),
				new Coins(new Vector3(-1.600000f, 0.500000f, 41.000000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 43.000000f)),}, null),
       //0-3
       new RoadBlock(null, 
		new ObsInfo[] {
				new ObsInfo(ObsKind.balloon, new Vector3(-0.800000f, 0.000000f, 22.000000f)),}, null,
		new Coins[] {
				new Coins(new Vector3(-1.600000f, 0.500000f, 16.000000f)),
				new Coins(new Vector3(-1.600000f, 0.500000f, 18.000000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 14.000000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 32.000000f)),
				new Coins(new Vector3(-1.600000f, 0.500000f, 12.000000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 34.000000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 36.000000f)),
				new Coins(new Vector3(1.600000f, 0.500000f, 38.000000f)),	new Coins(new Vector3(0.800000f, 0.500000f, 40.000000f)),	new Coins(new Vector3(-0.800000f, 0.500000f, 20.000000f)),}, null),
       //0-4
       new RoadBlock(null, 
		new ObsInfo[] {
				new ObsInfo(ObsKind.balloon, new Vector3(0.800000f, 0.000000f, 22.000000f)),}, null,
		new Coins[] {
				new Coins(new Vector3(-1.600000f, 0.500000f, 34.000000f)),
				new Coins(new Vector3(1.600000f, 0.500000f, 12.000000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 32.000000f)),	new Coins(new Vector3(-0.800000f, 0.500000f, 40.000000f)),
				new Coins(new Vector3(-1.600000f, 0.500000f, 38.000000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 18.000000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 14.000000f)),
				new Coins(new Vector3(0.800000f, 0.500000f, 20.000000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 36.000000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 15.980000f)),}, null),
       
      //0-5
      new RoadBlock(null, 
		new ObsInfo[] {
				new ObsInfo(ObsKind.balloon, new Vector3(0.800000f, 0.000000f, 10.840000f)),}, null,
		new Coins[] {
				new Coins(new Vector3(1.600000f, 0.500000f, 16.740000f)),
				new Coins(new Vector3(0.800000f, 0.500000f, 25.740000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 18.740000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 14.740000f)),
				new Coins(new Vector3(1.600000f, 0.500000f, 24.740000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 22.740000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 20.740000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 26.740000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 28.740000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 30.740000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 32.740000f)),}, null),
      //0-6
    new RoadBlock(null, 
		new ObsInfo[] {
				new ObsInfo(ObsKind.balloon, new Vector3(-0.800000f, 0.000000f, 10.450000f)),}, null,
		new Coins[] {
				new Coins(new Vector3(-1.600000f, 0.500000f, 22.598360f)),
				new Coins(new Vector3(-1.600000f, 0.500000f, 14.598360f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 20.598360f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 18.598360f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 30.598360f)),	new Coins(new Vector3(0.000000f, 0.500000f, 32.598360f)),	new Coins(new Vector3(0.000000f, 0.500000f, 26.598360f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 24.598360f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 16.598360f)),	new Coins(new Vector3(0.000000f, 0.500000f, 28.598360f)),}, null),
     //0-7
     new RoadBlock(null, null,  null,
		new Coins[] {
				new Coins(new Vector3(0.000000f, 0.500000f, 11.830000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 9.810000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 7.830000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 1.830000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 5.830000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 3.830000f)),},
		new JumpCoins[] {
				new JumpCoins( new Vector3(-1.600000f, 0.500000f, 21.970000f)),
				new JumpCoins(new Vector3(1.600000f, 0.500000f, 21.970000f)),}),
    };
    public static RoadBlock[] lv1 = 
	{
       //1-0
    new RoadBlock(
		new Items[] {
				new Items(ItemKind.balloon, new Vector3(0.000000f, 0.000000f, 25.000000f))},
		new ObsInfo[] {
				new ObsInfo(ObsKind.carttroupe, new Vector3(-1.600000f, 0.000000f, 4.000000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(1.600000f, 0.000000f, 14.200000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(1.600000f, 0.000000f, 29.000000f)),
				new ObsInfo(ObsKind.cartladder, new Vector3(1.600000f, 0.000000f, 25.330000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(1.600000f, 0.000000f, 11.000000f)),
				new ObsInfo(ObsKind.hurdlemiddle, new Vector3(0.000000f, 0.000000f, 20.000000f)),}, null,
		new Coins[] {
				new Coins(new Vector3(0.000000f, 0.500000f, 14.500000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 16.500000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 21.000000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 23.000000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 29.000000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 10.500000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 12.500000f)),
				new Coins(new Vector3(-0.800000f, 0.500000f, 13.500000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 31.000000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 33.000000f)),
				new Coins(new Vector3(0.800000f, 0.500000f, 34.000000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 35.000000f)),	new Coins(new Vector3(1.500000f, 0.500000f, 37.000000f)),
				new Coins(new Vector3(1.500000f, 0.500000f, 39.000000f)),}, null),
      //1-1
     new RoadBlock(
		new Items[] {
				new Items(ItemKind.fly, new Vector3(-1.600000f, 0.000000f, 7.150000f))},
		new ObsInfo[] {
				new ObsInfo(ObsKind.carttroupe, new Vector3(-1.600000f, 0.000000f, 3.350000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(0.000000f, 0.000000f, 11.960000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(0.000000f, 0.000000f, 41.860000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(0.000000f, 0.000000f, 15.160000f)),}, null,
		new Coins[] {
				new Coins(new Vector3(0.000000f, 0.500000f, 2.250000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 6.250000f)),	new Coins(new Vector3(-0.800000f, 0.500000f, 8.250000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 12.250000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 4.250000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 10.250000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 18.250000f)),
				new Coins(new Vector3(-1.600000f, 0.500000f, 14.250000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 16.250000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 22.560000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 26.560000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 24.560000f)),	new Coins(new Vector3(-0.800000f, 0.500000f, 27.560000f)),
				new Coins(new Vector3(-1.600000f, 0.500000f, 30.560000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 28.560000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 16.250000f)),
				new Coins(new Vector3(1.600000f, 0.500000f, 18.560000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 32.560000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 22.560000f)),
				new Coins(new Vector3(1.600000f, 0.500000f, 20.560000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 28.560000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 30.560000f)),
				new Coins(new Vector3(1.600000f, 0.500000f, 26.560000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 24.560000f)),}, null),
      
      //1-2 fly
new RoadBlock(
		new Items[] {
				new Items(ItemKind.magnet, new Vector3(0.000000f, 1.500000f, 16.020000f))},
		new ObsInfo[] {
				new ObsInfo(ObsKind.cartladder, new Vector3(1.600000f, 0.000000f, 23.550000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(1.600000f, 0.000000f, 5.000000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(1.600000f, 0.000000f, 27.220000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(1.600000f, 0.000000f, 30.420000f)),
				new ObsInfo(ObsKind.hurdlemiddle, new Vector3(0.000000f, 0.000000f, 21.220000f)),
				new ObsInfo(ObsKind.hurdlemiddle, new Vector3(-1.600000f, 0.000000f, 23.000000f)),}, null,
		new Coins[] {
				new Coins(new Vector3(0.000000f, 0.500000f, 15.820000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 17.820000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 19.820000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 21.820000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 29.820000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 11.820000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 31.820000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 33.820000f)),	new Coins(new Vector3(-0.800000f, 0.500000f, 34.820000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 13.820000f)),
				new Coins(new Vector3(0.800000f, 0.500000f, 14.820000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 35.820000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 37.820000f)),},
		new JumpCoins[] {
				new JumpCoins( new Vector3(-1.600000f, 0.500000f, 22.620000f)),}),
      //1-3 fly
     new RoadBlock(
		new Items[] {
				new Items(ItemKind.shield, new Vector3(0.000000f, 1.500000f, 8.000000f))},
		new ObsInfo[] {
				new ObsInfo(ObsKind.carttroupe, new Vector3(1.600000f, 0.000000f, 5.000000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(0.000000f, 0.000000f, 39.200000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(0.000000f, 0.000000f, 14.490000f)),
				new ObsInfo(ObsKind.hurdlemiddle, new Vector3(-1.600000f, 0.000000f, 24.200000f)),
				new ObsInfo(ObsKind.hurdlemiddle, new Vector3(-1.600000f, 0.000000f, 6.000000f)),}, null,
		new Coins[] {
				new Coins(new Vector3(0.000000f, 0.500000f, 34.200000f)),
				new Coins(new Vector3(-0.800000f, 0.500000f, 35.200000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 36.200000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 38.200000f)),
				new Coins(new Vector3(1.600000f, 0.500000f, 17.200000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 19.200000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 15.200000f)),
				new Coins(new Vector3(0.800000f, 0.500000f, 20.200000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 23.200000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 25.200000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 21.200000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 27.200000f)),},
		new JumpCoins[] {
				new JumpCoins( new Vector3(-1.600000f, 0.500000f, 23.805000f)),}),
      //1-4
     new RoadBlock(
		new Items[] {
				new Items(ItemKind.spring, new Vector3(-1.600000f, 0.000000f, 7.500000f))},
		new ObsInfo[] {
				new ObsInfo(ObsKind.carttroupe, new Vector3(0.000000f, 0.000000f, 5.750000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(1.600000f, 0.000000f, 30.000000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(1.600000f, 0.000000f, 33.200000f)),
				new ObsInfo(ObsKind.cartladder, new Vector3(0.000000f, 0.000000f, 2.070000f)),
				new ObsInfo(ObsKind.cartladder, new Vector3(1.600000f, 0.000000f, 26.320000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(0.000000f, 0.000000f, 8.950000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(-1.600000f, 0.000000f, 19.150000f)),
				new ObsInfo(ObsKind.hurdlemiddle, new Vector3(-1.600000f, 0.000000f, 31.530000f)),
				new ObsInfo(ObsKind.hurdlemiddle, new Vector3(1.600000f, 0.000000f, 16.520000f)),}, null,
		new Coins[] {
				new Coins(new Vector3(0.000000f, 0.500000f, 33.500000f)),
				new Coins(new Vector3(-0.800000f, 0.500000f, 34.500000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 35.500000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 37.500000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 24.430000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 22.430000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 16.430000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 18.430000f)),	new Coins(new Vector3(0.000000f, 2.500000f, 5.360000f)),	new Coins(new Vector3(0.000000f, 2.500000f, 7.360000f)),
				new Coins(new Vector3(0.000000f, 2.500000f, 9.360000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 19.500000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 13.500000f)),
				new Coins(new Vector3(1.600000f, 0.500000f, 9.500000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 23.500000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 17.500000f)),
				new Coins(new Vector3(1.600000f, 0.500000f, 11.500000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 21.500000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 15.500000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 28.430000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 20.430000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 26.430000f)),
				new Coins(new Vector3(-1.600000f, 0.500000f, 39.500000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 41.500000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 43.500000f)),}, null),
      //1-5 fly
	new RoadBlock(
		new Items[] {
				new Items(ItemKind.balloon, new Vector3(-1.600000f, 2.000000f, 11.090000f))},
		new ObsInfo[] {
				new ObsInfo(ObsKind.carttroupe, new Vector3(-1.600000f, 0.000000f, 10.590000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(-1.600000f, 0.000000f, 13.790000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(-1.600000f, 0.000000f, 7.390000f)),
				new ObsInfo(ObsKind.cartladder, new Vector3(-1.600000f, 0.000000f, 3.700000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(1.600000f, 0.000000f, 10.790000f)),
				new ObsInfo(ObsKind.hurdlemiddle, new Vector3(1.600000f, 0.000000f, 27.060000f)),}, null,
		new Coins[] {
				new Coins(new Vector3(0.000000f, 0.500000f, 28.390000f)),
				new Coins(new Vector3(-0.800000f, 0.500000f, 29.390000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 34.390000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 30.390000f)),
				new Coins(new Vector3(-1.600000f, 2.500000f, 8.090000f)),	new Coins(new Vector3(-1.600000f, 2.500000f, 10.090000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 12.190000f)),
				new Coins(new Vector3(-1.600000f, 2.500000f, 6.090000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 16.190000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 14.190000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 18.190000f)),	new Coins(new Vector3(0.800000f, 0.500000f, 19.190000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 36.390000f)),
				new Coins(new Vector3(-1.600000f, 0.500000f, 32.390000f)),},
		new JumpCoins[] {
				new JumpCoins( new Vector3(1.600000f, 0.500000f, 26.640000f)),}),
      //1-6
    new RoadBlock(
		new Items[] {
				new Items(ItemKind.fly, new Vector3(0.000000f, 0.000000f, 28.690000f))},
		new ObsInfo[] {
				new ObsInfo(ObsKind.carttroupe, new Vector3(-1.600000f, 0.000000f, 6.250000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(-1.600000f, 0.000000f, 23.640000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(-1.600000f, 0.000000f, 9.450000f)),
				new ObsInfo(ObsKind.cartladder, new Vector3(-1.600000f, 0.000000f, 19.970000f)),
				new ObsInfo(ObsKind.cartladder, new Vector3(-1.600000f, 0.000000f, 2.573000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(0.000000f, 0.000000f, 32.580000f)),
				new ObsInfo(ObsKind.balloon, new Vector3(0.800000f, 0.000000f, 14.690000f)),}, null,
		new Coins[] {
				new Coins(new Vector3(-0.100000f, 0.500000f, 26.690000f)),
				new Coins(new Vector3(-0.800000f, 0.500000f, 27.690000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 28.690000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 30.690000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 7.690000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 3.690000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 9.690001f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 11.690000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 5.690000f)),	new Coins(new Vector3(-0.800000f, 0.500000f, 12.690000f)),
				new Coins(new Vector3(-1.600000f, 0.500000f, 15.690000f)),	new Coins(new Vector3(-0.800000f, 0.500000f, 16.690000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 13.690000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 19.690000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 17.690000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 21.690000f)),}, null),
      //1-7
     new RoadBlock(
		new Items[] {
				new Items(ItemKind.magnet, new Vector3(0.000000f, 0.000000f, 9.350000f))},
		new ObsInfo[] {
				new ObsInfo(ObsKind.carttroupe, new Vector3(1.600000f, 0.000000f, 7.270000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(-1.600000f, 0.000000f, 36.620000f)),
				new ObsInfo(ObsKind.hurdlemiddle, new Vector3(-1.600000f, 0.000000f, 5.900000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(1.600000f, 0.000000f, 27.710000f)),}, null,
		new Coins[] {
				new Coins(new Vector3(1.600000f, 0.500000f, 16.200000f)),
				new Coins(new Vector3(1.600000f, 0.500000f, 20.200000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 18.200000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 12.200000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 32.200000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 24.200000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 14.200000f)),
				new Coins(new Vector3(1.600000f, 0.500000f, 22.200000f)),	new Coins(new Vector3(0.800000f, 0.500000f, 25.200000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 26.200000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 28.200000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 34.200000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 30.200000f)),
				new Coins(new Vector3(-1.600000f, 0.500000f, 4.200000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 2.200000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 6.200000f)),
				new Coins(new Vector3(-1.600000f, 0.500000f, 8.200000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 10.200000f)),}, null),
      //1-8
      new RoadBlock(
		new Items[] {
				new Items(ItemKind.shield, new Vector3(-1.600000f, 0.000000f, 17.000000f))},
		new ObsInfo[] {
				new ObsInfo(ObsKind.carttroupe, new Vector3(-1.600000f, 0.000000f, 6.390000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(1.600000f, 0.000000f, 35.500000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(1.600000f, 0.000000f, 11.000000f)),
				new ObsInfo(ObsKind.hurdlemiddle, new Vector3(0.000000f, 0.000000f, 17.500000f)),}, null,
		new Coins[] {
				new Coins(new Vector3(1.600000f, 0.500000f, 29.500000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 8.000000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 4.000000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 2.000000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 6.000000f)),	new Coins(new Vector3(-0.800000f, 0.500000f, 9.000000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 10.000000f)),
				new Coins(new Vector3(-1.600000f, 0.500000f, 12.000000f)),	new Coins(new Vector3(-0.800000f, 0.500000f, 13.000000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 20.000000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 18.000000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 14.000000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 16.000000f)),
				new Coins(new Vector3(1.600000f, 0.500000f, 25.500000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 23.500000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 27.500000f)),
				new Coins(new Vector3(1.600000f, 0.500000f, 31.500000f)),}, null),
      //1-9
    new RoadBlock(
		new Items[] {
				new Items(ItemKind.spring, new Vector3(1.600000f, 0.000000f, 33.600000f))},
		new ObsInfo[] {
				new ObsInfo(ObsKind.carttroupe, new Vector3(-1.600000f, 0.000000f, 10.600000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(0.000000f, 0.000000f, 10.600000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(0.000000f, 0.000000f, 36.200000f)),
				new ObsInfo(ObsKind.balloon, new Vector3(0.800000f, 0.000000f, 25.600000f)),}, null,
		new Coins[] {
				new Coins(new Vector3(0.000000f, 0.500000f, 4.600000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 6.600000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 2.600000f)),	new Coins(new Vector3(0.800000f, 0.500000f, 7.600000f)),
				new Coins(new Vector3(1.600000f, 0.500000f, 10.600000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 16.600000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 14.600000f)),
				new Coins(new Vector3(1.600000f, 0.500000f, 12.600000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 8.600000f)),	new Coins(new Vector3(0.800000f, 0.500000f, 17.600000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 18.600000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 22.600000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 20.600000f)),
				new Coins(new Vector3(-0.800000f, 0.500000f, 23.600000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 30.600000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 26.600000f)),
				new Coins(new Vector3(-1.600000f, 0.500000f, 24.600000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 28.600000f)),}, null),
      //1-10
	};
    public static RoadBlock[] lv2 =
	{
        //2-0 fly
       new RoadBlock(
		new Items[] {
				new Items(ItemKind.balloon, new Vector3(1.600000f, 0.000000f, 20.460000f))},
		new ObsInfo[] {
				new ObsInfo(ObsKind.carttroupe, new Vector3(0.000000f, 0.000000f, 13.260000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(0.000000f, 0.000000f, 16.460000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(1.600000f, 0.000000f, 31.260000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(-1.600000f, 0.000000f, 26.250000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(-1.600000f, 0.000000f, 29.450000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(0.000000f, 0.000000f, 41.800000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(-1.600000f, 0.000000f, 38.600000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(0.000000f, 0.000000f, 38.600000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(-1.600000f, 0.000000f, 41.800000f)),
				new ObsInfo(ObsKind.hurdlemiddle, new Vector3(-1.600000f, 0.000000f, 15.260000f)),
				new ObsInfo(ObsKind.hurdlemiddle, new Vector3(0.000000f, 0.000000f, 28.160000f)),
				new ObsInfo(ObsKind.hurdlemiddle, new Vector3(1.600000f, 0.000000f, 15.260000f)),}, null,
		new Coins[] {
				new Coins(new Vector3(0.000000f, 0.500000f, 2.260000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 8.260000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 6.260000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 4.260000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 22.860000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 28.860000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 32.860000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 26.860000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 24.860000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 30.860000f)),
				new Coins(new Vector3(1.600000f, 0.500000f, 36.860000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 40.860000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 34.860000f)),
				new Coins(new Vector3(1.600000f, 0.500000f, 38.860000f)),	new Coins(new Vector3(0.800000f, 0.500000f, 33.860000f)),},
		new JumpCoins[] {
				new JumpCoins( new Vector3(-1.600000f, 0.500000f, 14.920000f)),
				new JumpCoins(new Vector3(1.600000f, 0.500000f, 14.890000f)),}),
      //2-1 fly
	new RoadBlock(
		new Items[] {
				new Items(ItemKind.fly, new Vector3(1.600000f, 0.000000f, 48.080000f))},
		new ObsInfo[] {
				new ObsInfo(ObsKind.carttroupe, new Vector3(-1.600000f, 0.000000f, 2.000000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(1.600000f, 0.000000f, 6.700000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(1.600000f, 0.000000f, 25.270000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(1.600000f, 0.000000f, 3.500000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(1.600000f, 0.000000f, 31.670000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(1.600000f, 0.000000f, 22.070000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(1.600000f, 0.000000f, 28.470000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(-1.600000f, 0.000000f, 18.720000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(-1.600000f, 0.000000f, 41.620000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(-1.600000f, 0.000000f, 44.820000f)),
				new ObsInfo(ObsKind.cartladder, new Vector3(1.600000f, 0.000000f, 18.390000f)),
				new ObsInfo(ObsKind.hurdlemiddle, new Vector3(0.000000f, 0.000000f, 22.320000f)),
				new ObsInfo(ObsKind.hurdlemiddle, new Vector3(-1.600000f, 0.000000f, 33.120000f)),}, null,
		new Coins[] {
				new Coins(new Vector3(-1.600000f, 0.500000f, 8.320000f)),
				new Coins(new Vector3(-1.600000f, 0.500000f, 10.320000f)),	new Coins(new Vector3(-1.600000f, 2.500000f, 41.360000f)),	new Coins(new Vector3(-1.600000f, 2.500000f, 43.360000f)),
				new Coins(new Vector3(-1.600000f, 2.500000f, 45.360000f)),	new Coins(new Vector3(1.600000f, 2.500000f, 22.020000f)),	new Coins(new Vector3(1.600000f, 2.500000f, 24.020000f)),
				new Coins(new Vector3(1.600000f, 2.500000f, 28.020000f)),	new Coins(new Vector3(1.600000f, 2.500000f, 26.020000f)),	new Coins(new Vector3(-0.800000f, 0.500000f, 11.320000f)),},
		new JumpCoins[] {
				new JumpCoins( new Vector3(-0.030000f, 0.330000f, 21.790000f)),
				new JumpCoins(new Vector3(0.000000f, 0.500000f, -0.020000f)),}),
       //2-2 fly
   new RoadBlock(
		new Items[] {
				new Items(ItemKind.magnet, new Vector3(1.600000f, 0.000000f, 48.860000f))},
		new ObsInfo[] {
				new ObsInfo(ObsKind.carttroupe, new Vector3(-1.600000f, 0.000000f, 4.330000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(1.600000f, 0.000000f, 6.460000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(1.600000f, 0.000000f, 35.300000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(1.600000f, 0.000000f, 9.660000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(1.600000f, 0.000000f, 28.900000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(1.600000f, 0.000000f, 32.100000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(-1.600000f, 0.000000f, 35.300000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(-1.600000f, 0.000000f, 28.900000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(-1.600000f, 0.000000f, 32.100000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(1.600000f, 0.000000f, 12.860000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(-1.600000f, 0.000000f, 7.530000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(0.000000f, 0.000000f, 30.200000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(0.000000f, 0.000000f, 33.400000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(0.000000f, 0.000000f, 36.600000f)),
				new ObsInfo(ObsKind.cartladder, new Vector3(1.600000f, 0.000000f, 25.220000f)),
				new ObsInfo(ObsKind.cartladder, new Vector3(-1.600000f, 0.000000f, 25.220000f)),
				new ObsInfo(ObsKind.hurdlemiddle, new Vector3(0.000000f, 0.000000f, 19.000000f)),
				new ObsInfo(ObsKind.hurdlemiddle, new Vector3(0.000000f, 0.000000f, 44.800000f)),}, null,
		new Coins[] {
				new Coins(new Vector3(0.000000f, 0.500000f, 8.670000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 4.670000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 6.670000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 27.690000f)),
				new Coins(new Vector3(1.600000f, 0.500000f, 31.690000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 33.690000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 29.690000f)),
				new Coins(new Vector3(-1.600000f, 2.500000f, 27.690000f)),	new Coins(new Vector3(-1.600000f, 2.500000f, 29.690000f)),	new Coins(new Vector3(-1.600000f, 2.500000f, 31.690000f)),
				new Coins(new Vector3(-1.600000f, 2.500000f, 33.690000f)),	new Coins(new Vector3(-1.600000f, 2.500000f, 35.690000f)),	new Coins(new Vector3(0.000000f, 2.500000f, 29.720000f)),
				new Coins(new Vector3(0.000000f, 2.500000f, 37.720000f)),	new Coins(new Vector3(0.000000f, 2.500000f, 31.720000f)),	new Coins(new Vector3(0.000000f, 2.500000f, 33.720000f)),
				new Coins(new Vector3(0.000000f, 2.500000f, 35.720000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 40.910000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 42.910000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 44.910000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 46.910000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 40.910000f)),
				new Coins(new Vector3(-1.600000f, 0.500000f, 42.910000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 44.910000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 46.910000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 2.670000f)),},
		new JumpCoins[] {
				new JumpCoins( new Vector3(0.000000f, 0.500000f, 6.668000f)),
				new JumpCoins(new Vector3(1.600000f, 2.500000f, 36.660000f)),}),
       //2-3 fly
     new RoadBlock(
		new Items[] {
				new Items(ItemKind.shield, new Vector3(0.000000f, 0.000000f, 25.530000f))},
		new ObsInfo[] {
				new ObsInfo(ObsKind.carttroupe, new Vector3(0.000000f, 0.000000f, 10.400000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(0.000000f, 0.000000f, 7.200000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(-1.600000f, 0.000000f, 39.530000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(-1.600000f, 0.000000f, 33.130000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(-1.600000f, 0.000000f, 36.330000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(-1.600000f, 0.000000f, 29.930000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(1.600000f, 0.000000f, 9.430000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(1.600000f, 0.000000f, 6.230000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(1.600000f, 0.000000f, 18.330000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(1.600000f, 0.000000f, 21.530000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(0.000000f, 0.000000f, 34.260000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(0.000000f, 0.000000f, 31.060000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(1.600000f, 0.000000f, 44.600000f)),
				new ObsInfo(ObsKind.cartladder, new Vector3(-1.600000f, 0.000000f, 26.250000f)),
				new ObsInfo(ObsKind.hurdlemiddle, new Vector3(-1.600000f, 0.000000f, 8.500000f)),
				new ObsInfo(ObsKind.hurdlemiddle, new Vector3(1.600000f, 0.000000f, 32.100000f)),}, null,
		new Coins[] {
				new Coins(new Vector3(0.000000f, 0.500000f, 19.000000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 17.000000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 21.000000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 23.000000f)),
				new Coins(new Vector3(-1.600000f, 2.500000f, 29.400000f)),	new Coins(new Vector3(-1.600000f, 2.500000f, 31.400000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 45.730000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 41.730000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 43.730000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 39.730000f)),
				new Coins(new Vector3(1.600000f, 0.500000f, 34.590000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 30.590000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 28.590000f)),
				new Coins(new Vector3(1.600000f, 0.500000f, 32.590000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 36.590000f)),},
		new JumpCoins[] {
				new JumpCoins( new Vector3(-1.600000f, 2.500000f, 35.250000f)),
				new JumpCoins(new Vector3(-1.600000f, 0.500000f, 8.230000f)),}),
      //2-4 fly
    new RoadBlock(
		new Items[] {
				new Items(ItemKind.magnet, new Vector3(0.000000f, 0.000000f, 2.890000f))},
		new ObsInfo[] {
				new ObsInfo(ObsKind.cartstand, new Vector3(0.000000f, 0.000000f, 15.310000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(1.600000f, 0.000000f, 17.210000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(-1.600000f, 0.000000f, 7.610000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(0.000000f, 0.000000f, 12.110000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(0.000000f, 0.000000f, 8.910000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(-1.600000f, 0.000000f, 14.010000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(-1.600000f, 0.000000f, 10.810000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(1.600000f, 0.000000f, 10.810000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(1.600000f, 0.000000f, 7.610000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(0.000000f, 0.000000f, 39.870000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(0.000000f, 0.000000f, 33.470000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(0.000000f, 0.000000f, 36.670000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(0.000000f, 0.000000f, 21.710000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(-1.600000f, 0.000000f, 20.410000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(-1.600000f, 0.000000f, 17.210000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(1.600000f, 0.000000f, 20.410000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(1.600000f, 0.000000f, 14.010000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(0.000000f, 0.000000f, 18.510000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(1.600000f, 0.000000f, 35.110000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(1.600000f, 0.000000f, 38.310000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(1.600000f, 0.000000f, 31.910000f)),
				new ObsInfo(ObsKind.cartladder, new Vector3(0.000000f, 0.000000f, 5.220000f)),
				new ObsInfo(ObsKind.cartladder, new Vector3(1.600000f, 0.000000f, 28.240000f)),
				new ObsInfo(ObsKind.hurdlemiddle, new Vector3(-1.600000f, 0.000000f, 34.790000f)),}, null,
		new Coins[] {
				new Coins(new Vector3(0.000000f, 2.500000f, 12.010000f)),
				new Coins(new Vector3(0.000000f, 2.500000f, 16.010000f)),	new Coins(new Vector3(0.000000f, 2.500000f, 20.010000f)),	new Coins(new Vector3(0.000000f, 2.500000f, 10.010000f)),
				new Coins(new Vector3(-1.600000f, 2.500000f, 11.180000f)),	new Coins(new Vector3(-1.600000f, 2.500000f, 19.180000f)),	new Coins(new Vector3(-1.600000f, 2.500000f, 9.180000f)),
				new Coins(new Vector3(-1.600000f, 2.500000f, 15.180000f)),	new Coins(new Vector3(1.600000f, 2.500000f, 9.180000f)),	new Coins(new Vector3(1.600000f, 2.500000f, 11.280000f)),
				new Coins(new Vector3(1.600000f, 2.500000f, 13.180000f)),	new Coins(new Vector3(1.600000f, 2.500000f, 15.180000f)),	new Coins(new Vector3(1.600000f, 2.500000f, 17.180000f)),
				new Coins(new Vector3(1.600000f, 2.500000f, 19.180000f)),	new Coins(new Vector3(-1.600000f, 2.500000f, 13.180000f)),	new Coins(new Vector3(-1.600000f, 2.500000f, 17.180000f)),
				new Coins(new Vector3(0.000000f, 2.500000f, 18.010000f)),	new Coins(new Vector3(0.000000f, 2.500000f, 14.010000f)),	new Coins(new Vector3(1.600000f, 2.500000f, 31.110000f)),
				new Coins(new Vector3(1.600000f, 2.500000f, 33.110000f)),	new Coins(new Vector3(1.600000f, 2.500000f, 35.110000f)),	new Coins(new Vector3(1.600000f, 2.500000f, 37.110000f)),
				new Coins(new Vector3(1.600000f, 2.500000f, 39.110000f)),},
		new JumpCoins[] {
				new JumpCoins( new Vector3(-1.600000f, 0.500000f, 34.210000f)),}),
    //2-5
    new RoadBlock(
		new Items[] {
				new Items(ItemKind.spring, new Vector3(1.600000f, 0.000000f, 35.000000f))},
		new ObsInfo[] {
				new ObsInfo(ObsKind.cartstand, new Vector3(0.000000f, 0.000000f, 17.310000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(1.600000f, 0.000000f, 12.810000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(-1.600000f, 0.000000f, 16.010000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(0.000000f, 0.000000f, 7.710000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(-1.600000f, 0.000000f, 6.410000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(-1.600000f, 0.000000f, 19.210000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(1.600000f, 0.000000f, 6.410000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(1.600000f, 0.000000f, 9.610000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(0.000000f, 0.000000f, 34.910000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(1.600000f, 0.000000f, 16.010000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(0.000000f, 0.000000f, 10.910000f)),
				new ObsInfo(ObsKind.cartladder, new Vector3(-1.600000f, 0.000000f, 26.430000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(0.000000f, 0.000000f, 20.510000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(0.000000f, 0.000000f, 14.110000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(-1.600000f, 0.000000f, 30.110000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(-1.600000f, 0.000000f, 39.710000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(-1.600000f, 0.000000f, 36.510000f)),
				new ObsInfo(ObsKind.hurdlemiddle, new Vector3(1.600000f, 0.000000f, 33.690000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(1.600000f, 0.000000f, 19.210000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(0.000000f, 0.000000f, 31.710000f)),
				new ObsInfo(ObsKind.cartladder, new Vector3(0.000000f, 0.000000f, 3.990000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(-1.600000f, 0.000000f, 33.310000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(-1.600000f, 0.000000f, 12.810000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(-1.600000f, 0.000000f, 9.610000f)),}, null,
		new Coins[] {
				new Coins(new Vector3(0.000000f, 2.500000f, 17.090000f)),
				new Coins(new Vector3(0.000000f, 2.500000f, 9.090000f)),	new Coins(new Vector3(0.000000f, 2.500000f, 13.090000f)),	new Coins(new Vector3(0.000000f, 2.500000f, 19.090000f)),
				new Coins(new Vector3(0.000000f, 2.500000f, 7.090000f)),	new Coins(new Vector3(0.000000f, 2.500000f, 11.090000f)),	new Coins(new Vector3(-1.600000f, 2.500000f, 16.910000f)),
				new Coins(new Vector3(-1.600000f, 2.500000f, 12.910000f)),	new Coins(new Vector3(-1.600000f, 2.500000f, 10.910000f)),	new Coins(new Vector3(0.000000f, 2.500000f, 15.090000f)),
				new Coins(new Vector3(-1.600000f, 2.500000f, 14.910000f)),	new Coins(new Vector3(-1.600000f, 2.500000f, 8.910000f)),	new Coins(new Vector3(1.600000f, 2.500000f, 12.910000f)),
				new Coins(new Vector3(1.600000f, 2.500000f, 14.910000f)),	new Coins(new Vector3(1.600000f, 2.500000f, 16.910000f)),	new Coins(new Vector3(1.600000f, 2.500000f, 10.910000f)),
				new Coins(new Vector3(1.600000f, 2.500000f, 8.910000f)),	new Coins(new Vector3(-1.600000f, 2.500000f, 31.410000f)),	new Coins(new Vector3(-1.600000f, 2.500000f, 29.410000f)),
				new Coins(new Vector3(-1.600000f, 2.500000f, 35.410000f)),	new Coins(new Vector3(-1.600000f, 2.500000f, 33.410000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 43.200000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 41.200000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 47.200000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 39.200000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 45.200000f)),}, null),
     //2-6 fly
    new RoadBlock(
		new Items[] {
				new Items(ItemKind.balloon, new Vector3(1.600000f, 2.000000f, 36.840000f))},
		new ObsInfo[] {
				new ObsInfo(ObsKind.carttroupe, new Vector3(0.000000f, 0.000000f, 10.530000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(0.000000f, 0.000000f, 7.330000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(-1.600000f, 0.000000f, 33.040000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(-1.600000f, 0.000000f, 29.840000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(-1.600000f, 0.000000f, 36.240000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(1.600000f, 0.000000f, 33.040000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(1.600000f, 0.000000f, 36.240000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(1.600000f, 0.000000f, 29.840000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(1.600000f, 0.000000f, 18.040000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(1.600000f, 0.000000f, 21.240000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(1.600000f, 0.000000f, 9.240000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(1.600000f, 0.000000f, 6.040000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(0.000000f, 0.000000f, 34.810000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(0.000000f, 0.000000f, 31.610000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(0.000000f, 0.000000f, 38.010000f)),
				new ObsInfo(ObsKind.hurdlemiddle, new Vector3(-1.600000f, 0.000000f, 9.040000f)),
				new ObsInfo(ObsKind.hurdlemiddle, new Vector3(0.000000f, 0.000000f, 45.750000f)),
				new ObsInfo(ObsKind.cartladder, new Vector3(-1.600000f, 0.000000f, 26.161000f)),}, null,
		new Coins[] {
				new Coins(new Vector3(1.600000f, 2.500000f, 5.240000f)),
				new Coins(new Vector3(1.600000f, 2.500000f, 7.240000f)),	new Coins(new Vector3(1.600000f, 2.500000f, 9.240000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 19.140000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 17.140000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 15.140000f)),	new Coins(new Vector3(-0.800000f, 0.500000f, 20.140000f)),
				new Coins(new Vector3(-1.600000f, 0.500000f, 21.140000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 23.140000f)),	new Coins(new Vector3(-1.600000f, 2.500000f, 29.140000f)),
				new Coins(new Vector3(-1.600000f, 2.500000f, 31.140000f)),	new Coins(new Vector3(-1.600000f, 2.500000f, 33.140000f)),	new Coins(new Vector3(-1.600000f, 2.500000f, 35.140000f)),
				new Coins(new Vector3(-1.600000f, 2.500000f, 37.140000f)),},
		new JumpCoins[] {
				new JumpCoins( new Vector3(-1.600000f, 0.500000f, 8.770000f)),}),
    //2-7 fly
	new RoadBlock(
		new Items[] {
				new Items(ItemKind.fly, new Vector3(0.000000f, 0.000000f, 4.000000f))},
		new ObsInfo[] {
				new ObsInfo(ObsKind.cartstand, new Vector3(0.000000f, 0.000000f, 38.010000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(1.600000f, 0.000000f, 9.240000f)),
				new ObsInfo(ObsKind.hurdlemiddle, new Vector3(0.000000f, 0.000000f, 45.750000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(1.600000f, 0.000000f, 6.040000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(1.600000f, 0.000000f, 33.040000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(0.000000f, 0.000000f, 10.530000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(0.000000f, 0.000000f, 31.610000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(1.600000f, 0.000000f, 12.440000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(0.000000f, 0.000000f, 34.810000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(0.000000f, 0.000000f, 7.330000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(1.600000f, 0.000000f, 36.240000f)),
				new ObsInfo(ObsKind.hurdlemiddle, new Vector3(-1.600000f, 0.000000f, 9.040000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(1.600000f, 0.000000f, 29.840000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(-1.600000f, 0.000000f, 33.040000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(-1.600000f, 0.000000f, 36.240000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(1.600000f, 0.000000f, 15.640000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(-1.600000f, 0.000000f, 29.840000f)),
				new ObsInfo(ObsKind.cartladder, new Vector3(-1.600000f, 0.000000f, 26.160000f)),
				new ObsInfo(ObsKind.cartladder, new Vector3(1.600000f, 0.000000f, 26.160000f)),}, null,
		new Coins[] {
				new Coins(new Vector3(-1.600000f, 2.500000f, 31.140000f)),
				new Coins(new Vector3(1.600000f, 2.500000f, 9.240000f)),	new Coins(new Vector3(1.600000f, 2.500000f, 5.240000f)),	new Coins(new Vector3(-1.600000f, 2.500000f, 33.140000f)),
				new Coins(new Vector3(-1.600000f, 2.500000f, 35.140000f)),	new Coins(new Vector3(1.600000f, 2.500000f, 7.240000f)),	new Coins(new Vector3(-1.600000f, 2.500000f, 29.140000f)),
				new Coins(new Vector3(-1.600000f, 2.500000f, 37.140000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 17.140000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 21.140000f)),
				new Coins(new Vector3(-0.800000f, 0.500000f, 20.140000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 23.140000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 15.140000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 19.140000f)),},
		new JumpCoins[] {
				new JumpCoins( new Vector3(-1.600000f, 0.500000f, 8.720000f)),}),
    //2-8
        new RoadBlock(
		new Items[] {
				new Items(ItemKind.magnet, new Vector3(0.000000f, 1.500000f, 28.500000f))},
		new ObsInfo[] {
				new ObsInfo(ObsKind.runtroupe, new Vector3(0.000000f, 0.000000f, 13.800000f)),
				new ObsInfo(ObsKind.runtroupe, new Vector3(0.000000f, 0.000000f, 17.000000f)),
				new ObsInfo(ObsKind.runtroupe, new Vector3(0.000000f, 0.000000f, 10.600000f)),
				new ObsInfo(ObsKind.runtroupe, new Vector3(0.000000f, 0.000000f, 47.600000f)),
				new ObsInfo(ObsKind.runtroupe, new Vector3(0.000000f, 0.000000f, 44.400000f)),
				new ObsInfo(ObsKind.runtroupe, new Vector3(0.000000f, 0.000000f, 41.200000f)),
				new ObsInfo(ObsKind.runstand, new Vector3(-1.600000f, 0.000000f, 26.670000f)),
				new ObsInfo(ObsKind.runstand, new Vector3(-1.600000f, 0.000000f, 29.870000f)),
				new ObsInfo(ObsKind.runstand, new Vector3(1.600000f, 0.000000f, 29.870000f)),
				new ObsInfo(ObsKind.runstand, new Vector3(1.600000f, 0.000000f, 26.670000f)),
				new ObsInfo(ObsKind.ball, new Vector3(1.600000f, 0.000000f, 13.560000f)),
				new ObsInfo(ObsKind.ball, new Vector3(-1.600000f, 0.000000f, 13.560000f)),
				new ObsInfo(ObsKind.hurdlemiddle, new Vector3(1.600000f, 0.000000f, 45.030000f)),
				new ObsInfo(ObsKind.hurdlemiddle, new Vector3(-1.600000f, 0.000000f, 45.030000f)),}, null,
		new Coins[] {
				new Coins(new Vector3(-1.600000f, 0.500000f, 18.340000f)),
				new Coins(new Vector3(-1.600000f, 0.500000f, 20.340000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 22.340000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 24.340000f)),
				new Coins(new Vector3(1.600000f, 0.500000f, 18.340000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 20.340000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 22.340000f)),
				new Coins(new Vector3(1.600000f, 0.500000f, 24.340000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 8.410000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 4.410000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 2.410000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 6.410000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 45.190000f)),
				new Coins(new Vector3(-1.600000f, 0.500000f, 41.190000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 43.190000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 47.190000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 32.670000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 38.670000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 34.670000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 36.670000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 45.190000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 43.190000f)),
				new Coins(new Vector3(1.600000f, 0.500000f, 47.190000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 41.190000f)),}, null),
    //2-9
        new RoadBlock(
		new Items[] {
				new Items(ItemKind.shield, new Vector3(0.000000f, 2.000000f, 44.530000f))},
		new ObsInfo[] {
				new ObsInfo(ObsKind.carttroupe, new Vector3(-1.600000f, 0.000000f, 39.580000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(-1.600000f, 0.000000f, 45.980000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(-1.600000f, 0.000000f, 42.780000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(-1.600000f, 0.000000f, 36.380000f)),
				new ObsInfo(ObsKind.runtroupe, new Vector3(0.000000f, 0.000000f, 14.570000f)),
				new ObsInfo(ObsKind.runtroupe, new Vector3(0.000000f, 0.000000f, 11.370000f)),
				new ObsInfo(ObsKind.runtroupe, new Vector3(0.000000f, 0.000000f, 25.970000f)),
				new ObsInfo(ObsKind.runtroupe, new Vector3(0.000000f, 0.000000f, 29.170000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(1.600000f, 0.000000f, 42.780000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(1.600000f, 0.000000f, 45.980000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(1.600000f, 0.000000f, 36.380000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(1.600000f, 0.000000f, 39.580000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(0.000000f, 0.000000f, 36.230000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(0.000000f, 0.000000f, 39.430000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(0.000000f, 0.000000f, 42.630000f)),
				new ObsInfo(ObsKind.cartladder, new Vector3(1.600000f, 0.000000f, 32.710000f)),
				new ObsInfo(ObsKind.cartladder, new Vector3(-1.600000f, 0.000000f, 32.710000f)),}, null,
		new Coins[] {
				new Coins(new Vector3(1.600000f, 2.500000f, 35.680000f)),
				new Coins(new Vector3(-1.600000f, 2.500000f, 41.680000f)),	new Coins(new Vector3(1.600000f, 2.500000f, 37.680000f)),	new Coins(new Vector3(1.600000f, 2.500000f, 39.680000f)),
				new Coins(new Vector3(1.600000f, 2.500000f, 41.680000f)),	new Coins(new Vector3(1.600000f, 2.500000f, 43.680000f)),	new Coins(new Vector3(1.600000f, 2.500000f, 45.680000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 23.350000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 21.350000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 19.350000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 17.350000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 4.670000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 2.670000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 8.670000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 6.670000f)),	new Coins(new Vector3(-1.600000f, 2.500000f, 39.680000f)),
				new Coins(new Vector3(-1.600000f, 2.500000f, 43.680000f)),	new Coins(new Vector3(-1.600000f, 2.500000f, 35.680000f)),	new Coins(new Vector3(-1.600000f, 2.500000f, 45.680000f)),
				new Coins(new Vector3(-1.600000f, 2.500000f, 37.680000f)),}, null),
    //2-10
        new RoadBlock(
		new Items[] {
				new Items(ItemKind.spring, new Vector3(0.000000f, 0.000000f, 12.560000f))},
		new ObsInfo[] {
				new ObsInfo(ObsKind.runtroupe, new Vector3(-1.600000f, 0.000000f, 9.870000f)),
				new ObsInfo(ObsKind.runtroupe, new Vector3(-1.600000f, 0.000000f, 13.070000f)),
				new ObsInfo(ObsKind.runtroupe, new Vector3(1.600000f, 0.000000f, 25.070000f)),
				new ObsInfo(ObsKind.runtroupe, new Vector3(1.600000f, 0.000000f, 21.870000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(0.000000f, 0.000000f, 35.270000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(0.000000f, 0.000000f, 41.670000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(0.000000f, 0.000000f, 32.070000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(0.000000f, 0.000000f, 38.470000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(-1.600000f, 0.000000f, 35.270000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(-1.600000f, 0.000000f, 41.670000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(-1.600000f, 0.000000f, 32.070000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(-1.600000f, 0.000000f, 38.470000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(1.600000f, 0.000000f, 32.470000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(1.600000f, 0.000000f, 35.670000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(1.600000f, 0.000000f, 38.870000f)),
				new ObsInfo(ObsKind.cartladder, new Vector3(-1.600000f, 0.000000f, 28.390000f)),
				new ObsInfo(ObsKind.cartladder, new Vector3(0.000000f, 0.000000f, 28.390000f)),}, null,
		new Coins[] {
				new Coins(new Vector3(0.000000f, 2.500000f, 38.040000f)),
				new Coins(new Vector3(0.000000f, 2.500000f, 36.040000f)),	new Coins(new Vector3(0.000000f, 2.500000f, 40.040000f)),	new Coins(new Vector3(0.000000f, 2.500000f, 42.040000f)),
				new Coins(new Vector3(0.000000f, 2.500000f, 32.040000f)),	new Coins(new Vector3(0.000000f, 2.500000f, 34.040000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 6.070000f)),
				new Coins(new Vector3(-1.600000f, 0.500000f, 8.070000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 2.070000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 4.070000f)),
				new Coins(new Vector3(1.600000f, 0.500000f, 19.550000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 17.550000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 15.550000f)),
				new Coins(new Vector3(1.600000f, 0.500000f, 13.550000f)),	new Coins(new Vector3(-1.600000f, 2.500000f, 34.040000f)),	new Coins(new Vector3(-1.600000f, 2.500000f, 36.040000f)),
				new Coins(new Vector3(-1.600000f, 2.500000f, 38.040000f)),	new Coins(new Vector3(-1.600000f, 2.500000f, 32.040000f)),	new Coins(new Vector3(-1.600000f, 2.500000f, 42.040000f)),
				new Coins(new Vector3(-1.600000f, 2.500000f, 40.040000f)),}, null),
     //2-11 fly
        new RoadBlock(
		new Items[] {
				new Items(ItemKind.balloon, new Vector3(1.600000f, 0.000000f, 38.980000f))},
		new ObsInfo[] {
				new ObsInfo(ObsKind.runtroupe, new Vector3(0.000000f, 0.000000f, 29.080000f)),
				new ObsInfo(ObsKind.runtroupe, new Vector3(0.000000f, 0.000000f, 32.280000f)),
				new ObsInfo(ObsKind.runtroupe, new Vector3(0.000000f, 0.000000f, 43.680000f)),
				new ObsInfo(ObsKind.runtroupe, new Vector3(0.000000f, 0.000000f, 46.880000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(1.600000f, 0.000000f, 11.640000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(1.600000f, 0.000000f, 14.840000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(1.600000f, 0.000000f, 18.040000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(1.600000f, 0.000000f, 8.440000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(0.000000f, 0.000000f, 7.080000f)),
				new ObsInfo(ObsKind.hurdlemiddle, new Vector3(-1.600000f, 0.000000f, 6.870000f)),
				new ObsInfo(ObsKind.ball, new Vector3(1.600000f, 0.000000f, 33.000000f)),
				new ObsInfo(ObsKind.cartladder, new Vector3(1.600000f, 0.000000f, 4.760000f)),}, null,
		new Coins[] {
				new Coins(new Vector3(1.600000f, 2.500000f, 8.240000f)),
				new Coins(new Vector3(1.600000f, 2.500000f, 10.240000f)),	new Coins(new Vector3(1.600000f, 2.500000f, 12.240000f)),	new Coins(new Vector3(1.600000f, 2.500000f, 14.240000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 14.980000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 16.980000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 18.980000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 20.980000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 22.980000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 24.980000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 35.080000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 37.080000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 39.080000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 41.080000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 26.980000f)),},
		new JumpCoins[] {
				new JumpCoins( new Vector3(-1.683000f, 0.500000f, 6.485000f)),}),
    //2-12
        new RoadBlock(
		new Items[] {
				new Items(ItemKind.fly, new Vector3(0.000000f, 0.000000f, 32.650000f))},
		new ObsInfo[] {
				new ObsInfo(ObsKind.carttroupe, new Vector3(1.600000f, 0.000000f, 5.430000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(0.000000f, 0.000000f, 15.630000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(0.000000f, 0.000000f, 12.430000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(1.600000f, 0.000000f, 28.500000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(-1.600000f, 0.000000f, 26.070000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(0.000000f, 0.000000f, 42.530000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(-1.600000f, 0.000000f, 39.330000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(0.000000f, 0.000000f, 39.330000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(-1.600000f, 0.000000f, 42.530000f)),
				new ObsInfo(ObsKind.hurdlemiddle, new Vector3(-1.600000f, 0.000000f, 14.190000f)),
				new ObsInfo(ObsKind.ball, new Vector3(0.000000f, 0.000000f, 9.000000f)),}, null,
		new Coins[] {
				new Coins(new Vector3(-1.600000f, 0.500000f, 5.530000f)),
				new Coins(new Vector3(-1.600000f, 0.500000f, 7.530000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 9.530000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 11.530000f)),
				new Coins(new Vector3(-1.600000f, 0.500000f, 13.530000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 15.530000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 17.530000f)),
				new Coins(new Vector3(-1.600000f, 0.500000f, 19.530000f)),	new Coins(new Vector3(-0.800000f, 0.500000f, 20.530000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 21.530000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 27.530000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 23.530000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 25.530000f)),
				new Coins(new Vector3(1.600000f, 0.500000f, 21.830000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 19.830000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 17.830000f)),
				new Coins(new Vector3(1.600000f, 0.500000f, 23.830000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 15.830000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 31.600000f)),
				new Coins(new Vector3(1.600000f, 0.500000f, 33.600000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 35.600000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 37.600000f)),
				new Coins(new Vector3(1.600000f, 0.500000f, 39.600000f)),}, null),
    //2-13
        new RoadBlock(
		new Items[] {
				new Items(ItemKind.magnet, new Vector3(0.000000f, 2.000000f, 12.550000f))},
		new ObsInfo[] {
				new ObsInfo(ObsKind.carttroupe, new Vector3(-1.600000f, 0.000000f, 29.350000f)),
				new ObsInfo(ObsKind.cartladder, new Vector3(1.600000f, 0.000000f, 3.665000f)),
				new ObsInfo(ObsKind.cartladder, new Vector3(-1.600000f, 0.000000f, 3.665000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(1.600000f, 0.000000f, 38.750000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(1.600000f, 0.000000f, 32.350000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(1.600000f, 0.000000f, 35.550000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(-1.600000f, 0.000000f, 7.350000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(-1.600000f, 0.000000f, 13.750000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(-1.600000f, 0.000000f, 10.550000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(0.000000f, 0.000000f, 8.850000f)),
				new ObsInfo(ObsKind.hurdlemiddle, new Vector3(-1.600000f, 0.000000f, 23.290000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(0.000000f, 0.000000f, 15.250000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(1.600000f, 0.000000f, 45.050000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(0.000000f, 0.000000f, 12.050000f)),
				new ObsInfo(ObsKind.ball, new Vector3(0.000000f, 0.000000f, 46.000000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(1.600000f, 0.000000f, 13.750000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(1.600000f, 0.000000f, 10.550000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(1.600000f, 0.000000f, 7.350000f)),}, null,
		new Coins[] {
				new Coins(new Vector3(-1.600000f, 2.500000f, 8.950000f)),
				new Coins(new Vector3(-1.600000f, 2.500000f, 10.950000f)),	new Coins(new Vector3(-1.600000f, 2.500000f, 12.950000f)),	new Coins(new Vector3(-1.600000f, 2.500000f, 6.950000f)),
				new Coins(new Vector3(1.600000f, 2.500000f, 8.950000f)),	new Coins(new Vector3(1.600000f, 2.500000f, 6.950000f)),	new Coins(new Vector3(1.600000f, 2.500000f, 10.950000f)),
				new Coins(new Vector3(1.600000f, 2.500000f, 12.950000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 16.550000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 24.550000f)),
				new Coins(new Vector3(-1.600000f, 0.500000f, 22.550000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 18.550000f)),	new Coins(new Vector3(-0.800000f, 0.500000f, 25.550000f)),
				new Coins(new Vector3(-1.600000f, 0.500000f, 20.550000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 20.550000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 34.550000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 30.550000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 26.550000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 28.550000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 22.550000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 18.550000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 32.550000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 24.550000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 48.350000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 42.350000f)),
				new Coins(new Vector3(-1.600000f, 0.500000f, 44.350000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 40.350000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 46.350000f)),}, null),
    //2-14
        new RoadBlock(
		new Items[] {
				new Items(ItemKind.shield, new Vector3(-1.600000f, 2.000000f, 14.610000f))},
		new ObsInfo[] {
				new ObsInfo(ObsKind.carttroupe, new Vector3(0.000000f, 0.000000f, 26.970000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(0.000000f, 0.000000f, 30.170000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(-1.600000f, 0.000000f, 14.310000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(-1.600000f, 0.000000f, 7.910000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(-1.600000f, 0.000000f, 11.110000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(1.600000f, 0.000000f, 40.810000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(0.000000f, 0.000000f, 6.640000f)),
				new ObsInfo(ObsKind.cartladder, new Vector3(-1.600000f, 0.000000f, 4.240000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(0.000000f, 0.000000f, 9.840000f)),
				new ObsInfo(ObsKind.hurdlemiddle, new Vector3(-1.600000f, 0.000000f, 30.640000f)),
				new ObsInfo(ObsKind.ball, new Vector3(1.600000f, 0.000000f, 3.700000f)),
				new ObsInfo(ObsKind.ball, new Vector3(1.600000f, 0.000000f, 28.370000f)),}, null,
		new Coins[] {
				new Coins(new Vector3(-1.600000f, 2.500000f, 11.610000f)),
				new Coins(new Vector3(-1.600000f, 2.500000f, 7.610000f)),	new Coins(new Vector3(-1.600000f, 2.500000f, 13.610000f)),	new Coins(new Vector3(-1.600000f, 2.500000f, 9.610000f)),
				new Coins(new Vector3(1.600000f, 0.500000f, 8.940001f)),	new Coins(new Vector3(1.600000f, 0.500000f, 12.940000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 6.940000f)),
				new Coins(new Vector3(1.600000f, 0.500000f, 10.940000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 4.940000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 21.140000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 19.140000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 17.140000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 15.140000f)),
				new Coins(new Vector3(-0.800000f, 0.500000f, 22.140000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 31.140000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 29.140000f)),
				new Coins(new Vector3(-1.600000f, 0.500000f, 23.140000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 27.140000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 25.140000f)),
				new Coins(new Vector3(-1.600000f, 0.500000f, 33.140000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 37.900000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 41.900000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 39.900000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 45.900000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 43.900000f)),}, null),
    //2-15
        new RoadBlock(
		new Items[] {
				new Items(ItemKind.spring, new Vector3(0.000000f, 0.000000f, 19.490000f))},
		new ObsInfo[] {
				new ObsInfo(ObsKind.runtroupe, new Vector3(0.000000f, 0.000000f, 7.290000f)),
				new ObsInfo(ObsKind.runtroupe, new Vector3(0.000000f, 0.000000f, 4.090000f)),
				new ObsInfo(ObsKind.runtroupe, new Vector3(0.000000f, 0.000000f, 31.590000f)),
				new ObsInfo(ObsKind.runtroupe, new Vector3(0.000000f, 0.000000f, 34.790000f)),
				new ObsInfo(ObsKind.runstand, new Vector3(-1.600000f, 0.000000f, 19.890000f)),
				new ObsInfo(ObsKind.runstand, new Vector3(-1.600000f, 0.000000f, 16.690000f)),
				new ObsInfo(ObsKind.runstand, new Vector3(1.600000f, 0.000000f, 45.590000f)),
				new ObsInfo(ObsKind.hurdlemiddle, new Vector3(0.000000f, 0.000000f, 43.910000f)),
				new ObsInfo(ObsKind.ball, new Vector3(1.600000f, 0.000000f, 7.790000f)),
				new ObsInfo(ObsKind.ball, new Vector3(1.600000f, 0.000000f, 40.000000f)),}, null,
		new Coins[] {
				new Coins(new Vector3(-1.600000f, 0.500000f, 5.590000f)),
				new Coins(new Vector3(-1.600000f, 0.500000f, 7.590000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 9.590000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 11.590000f)),
				new Coins(new Vector3(-1.600000f, 0.500000f, 13.590000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 13.790000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 15.790000f)),
				new Coins(new Vector3(1.600000f, 0.500000f, 17.790000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 19.790000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 21.790000f)),
				new Coins(new Vector3(1.600000f, 0.500000f, 23.790000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 25.790000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 27.790000f)),
				new Coins(new Vector3(1.600000f, 0.500000f, 29.790000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 33.390000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 35.390000f)),
				new Coins(new Vector3(-1.600000f, 0.500000f, 37.390000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 29.390000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 31.390000f)),}, null),

	};
    public static RoadBlock[] lv3 =
	{
        //3-0 fly
                new RoadBlock(
		new Items[] {
				new Items(ItemKind.balloon, new Vector3(0.000000f, 0.000000f, 22.490000f))},
		new ObsInfo[] {
				new ObsInfo(ObsKind.carttroupe, new Vector3(1.600000f, 0.000000f, 9.480000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(1.600000f, 0.000000f, 6.280000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(1.600000f, 0.000000f, 15.880000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(0.000000f, 0.000000f, 9.300000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(1.600000f, 0.000000f, 12.680000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(1.600000f, 0.000000f, 26.930000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(1.600000f, 0.000000f, 36.530000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(1.600000f, 0.000000f, 33.330000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(1.600000f, 0.000000f, 30.130000f)),
				new ObsInfo(ObsKind.cartladder, new Vector3(1.600000f, 0.000000f, 23.252000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(0.000000f, 0.000000f, 28.850000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(-1.600000f, 0.000000f, 38.060000f)),
				new ObsInfo(ObsKind.hurdlemiddle, new Vector3(0.000000f, 0.000000f, 16.350000f)),
				new ObsInfo(ObsKind.hurdlemiddle, new Vector3(-1.600000f, 0.000000f, 27.470000f)),
				new ObsInfo(ObsKind.ball, new Vector3(0.000000f, 0.000000f, 48.000000f)),}, null,
		new Coins[] {
				new Coins(new Vector3(-0.800000f, 0.500000f, 6.580000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 5.100000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 3.100000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 8.540000f)),
				new Coins(new Vector3(-1.600000f, 0.500000f, 10.540000f)),	new Coins(new Vector3(-0.800000f, 0.500000f, 12.720000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 14.610000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 16.610000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 18.610000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 35.210000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 39.210000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 37.210000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 33.210000f)),},
		new JumpCoins[] {
				new JumpCoins( new Vector3(1.600000f, 2.500000f, 36.380000f)),
				new JumpCoins(new Vector3(-1.600000f, 0.500000f, 27.140000f)),}),
        //3-1 fly
            new RoadBlock(
		new Items[] {
				new Items(ItemKind.fly, new Vector3(0.000000f, 0.000000f, 43.540000f))},
		new ObsInfo[] {
				new ObsInfo(ObsKind.carttroupe, new Vector3(1.600000f, 0.000000f, 12.580000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(1.600000f, 0.000000f, 9.430000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(1.600000f, 0.000000f, 6.280000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(0.000000f, 0.000000f, 7.850000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(1.600000f, 0.000000f, 15.730000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(-1.600000f, 0.000000f, 29.690000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(-1.600000f, 0.000000f, 36.090000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(-1.600000f, 0.000000f, 26.490000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(-1.600000f, 0.000000f, 32.890000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(0.000000f, 0.000000f, 28.920000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(1.600000f, 0.000000f, 40.440000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(0.000000f, 0.000000f, 25.720000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(-1.600000f, 0.000000f, 14.800000f)),
				new ObsInfo(ObsKind.hurdlemiddle, new Vector3(0.000000f, 0.000000f, 16.350000f)),
				new ObsInfo(ObsKind.hurdlemiddle, new Vector3(1.600000f, 0.000000f, 27.910000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(1.600000f, 0.000000f, 37.240000f)),
				new ObsInfo(ObsKind.cartladder, new Vector3(-1.600000f, 0.000000f, 22.800000f)),
				new ObsInfo(ObsKind.ball, new Vector3(0.000000f, 0.000000f, 48.000000f)),}, null,
		new Coins[] {
				new Coins(new Vector3(0.000000f, 0.500000f, 18.610000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 4.580000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 2.580000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 16.610000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 14.610000f)),	new Coins(new Vector3(-1.600000f, 2.500000f, 25.960000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 36.060000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 40.060000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 38.060000f)),	new Coins(new Vector3(-1.600000f, 2.500000f, 27.960000f)),
				new Coins(new Vector3(-1.600000f, 2.500000f, 29.960000f)),	new Coins(new Vector3(-1.600000f, 2.500000f, 31.960000f)),},
		new JumpCoins[] {
				new JumpCoins( new Vector3(1.600000f, 0.500000f, 27.560000f)),}),
        //3-2
            new RoadBlock(null, 
		new ObsInfo[] {
				new ObsInfo(ObsKind.carttroupe, new Vector3(0.000000f, 0.000000f, 8.910000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(0.000000f, 0.000000f, 5.710000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(-1.600000f, 0.000000f, 34.530000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(-1.600000f, 0.000000f, 31.330000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(-1.600000f, 0.000000f, 28.130000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(-1.600000f, 0.000000f, 37.730000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(1.600000f, 0.000000f, 7.630000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(1.600000f, 0.000000f, 4.430000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(1.600000f, 0.000000f, 19.520000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(1.600000f, 0.000000f, 16.320000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(0.000000f, 0.000000f, 30.230000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(1.600000f, 0.000000f, 42.000000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(0.000000f, 0.000000f, 33.430000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(1.600000f, 0.000000f, 45.200000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(-1.600000f, 0.000000f, 15.920000f)),
				new ObsInfo(ObsKind.hurdlemiddle, new Vector3(-1.600000f, 0.000000f, 7.530000f)),
				new ObsInfo(ObsKind.hurdlemiddle, new Vector3(1.600000f, 0.000000f, 32.030000f)),
				new ObsInfo(ObsKind.hurdlemiddle, new Vector3(0.000000f, 0.000000f, 17.940000f)),
				new ObsInfo(ObsKind.cartladder, new Vector3(-1.600000f, 0.000000f, 24.447000f)),}, null,
		new Coins[] {
				new Coins(new Vector3(-1.600000f, 0.500000f, 10.560000f)),
				new Coins(new Vector3(-1.600000f, 0.500000f, 2.560000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 8.559999f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 12.560000f)),
				new Coins(new Vector3(-1.600000f, 0.500000f, 4.560000f)),	new Coins(new Vector3(-0.800000f, 0.500000f, 13.670000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 18.670000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 22.670000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 26.670000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 24.670000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 20.670000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 16.670000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 14.670000f)),
				new Coins(new Vector3(-1.600000f, 2.500000f, 31.970000f)),	new Coins(new Vector3(-1.600000f, 2.500000f, 33.970000f)),	new Coins(new Vector3(-1.600000f, 2.500000f, 27.970000f)),
				new Coins(new Vector3(-1.600000f, 2.500000f, 29.970000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 42.760000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 38.760000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 40.760000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 44.760000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 6.560000f)),}, null),
        //3-3
            new RoadBlock(
		new Items[] {
				new Items(ItemKind.magnet, new Vector3(0.000000f, 2.000000f, 10.020000f))},
		new ObsInfo[] {
				new ObsInfo(ObsKind.cartstand, new Vector3(0.000000f, 0.000000f, 19.200000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(1.600000f, 0.000000f, 8.330000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(-1.600000f, 0.000000f, 8.330000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(0.000000f, 0.000000f, 9.600000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(0.000000f, 0.000000f, 22.400000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(-1.600000f, 0.000000f, 21.130000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(-1.600000f, 0.000000f, 14.730000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(1.600000f, 0.000000f, 17.930000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(1.600000f, 0.000000f, 14.730000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(-1.600000f, 0.000000f, 38.860000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(-1.600000f, 0.000000f, 42.010000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(0.000000f, 0.000000f, 16.000000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(-1.600000f, 0.000000f, 17.930000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(1.600000f, 0.000000f, 21.130000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(1.600000f, 0.000000f, 11.530000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(-1.600000f, 0.000000f, 11.530000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(0.000000f, 0.000000f, 12.800000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(0.000000f, 0.000000f, 40.330000f)),
				new ObsInfo(ObsKind.cartladder, new Vector3(0.000000f, 0.000000f, 5.880000f)),
				new ObsInfo(ObsKind.swingBob, new Vector3(0.000000f, 0.000000f, 30.310000f)),}, null,
		new Coins[] {
				new Coins(new Vector3(-1.600000f, 0.500000f, 32.310000f)),
				new Coins(new Vector3(-1.600000f, 0.500000f, 30.310000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 30.310000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 36.310000f)),
				new Coins(new Vector3(-1.600000f, 0.500000f, 34.310000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 36.310000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 32.310000f)),
				new Coins(new Vector3(1.600000f, 0.500000f, 40.310000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 44.310000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 38.310000f)),
				new Coins(new Vector3(1.600000f, 0.500000f, 34.310000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 42.310000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 46.310000f)),
				new Coins(new Vector3(0.000000f, 2.500000f, 13.150000f)),	new Coins(new Vector3(0.000000f, 2.500000f, 9.110000f)),	new Coins(new Vector3(1.600000f, 2.500000f, 9.110000f)),
				new Coins(new Vector3(-1.600000f, 2.500000f, 9.110000f)),	new Coins(new Vector3(0.000000f, 2.500000f, 11.150000f)),	new Coins(new Vector3(0.000000f, 2.500000f, 19.150000f)),
				new Coins(new Vector3(0.000000f, 2.500000f, 15.150000f)),	new Coins(new Vector3(1.600000f, 2.500000f, 19.110000f)),	new Coins(new Vector3(1.600000f, 2.500000f, 15.110000f)),
				new Coins(new Vector3(1.600000f, 2.500000f, 13.110000f)),	new Coins(new Vector3(1.600000f, 2.500000f, 11.110000f)),	new Coins(new Vector3(-1.600000f, 2.500000f, 15.110000f)),
				new Coins(new Vector3(-1.600000f, 2.500000f, 19.110000f)),	new Coins(new Vector3(-1.600000f, 2.500000f, 17.110000f)),	new Coins(new Vector3(-1.600000f, 2.500000f, 13.110000f)),
				new Coins(new Vector3(-1.600000f, 2.500000f, 11.110000f)),	new Coins(new Vector3(-1.600000f, 2.500000f, 21.110000f)),	new Coins(new Vector3(1.600000f, 2.500000f, 17.110000f)),
				new Coins(new Vector3(1.600000f, 2.500000f, 21.110000f)),	new Coins(new Vector3(0.000000f, 2.500000f, 21.150000f)),	new Coins(new Vector3(0.000000f, 2.500000f, 17.150000f)),
				new Coins(new Vector3(0.000000f, 2.500000f, 23.150000f)),}, null),
        //3-4
            new RoadBlock(
		new Items[] {
				new Items(ItemKind.fly, new Vector3(0.000000f, 0.000000f, 25.540000f))},
		new ObsInfo[] {
				new ObsInfo(ObsKind.cartstand, new Vector3(0.000000f, 0.000000f, 14.700000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(1.600000f, 0.000000f, 10.310000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(-1.600000f, 0.000000f, 16.710000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(0.000000f, 0.000000f, 8.300000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(0.000000f, 0.000000f, 11.500000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(-1.600000f, 0.000000f, 7.110000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(-1.600000f, 0.000000f, 10.310000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(1.600000f, 0.000000f, 7.110000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(1.600000f, 0.000000f, 16.710000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(-1.600000f, 0.000000f, 37.960000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(-1.600000f, 0.000000f, 41.110000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(0.000000f, 0.000000f, 17.900000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(-1.600000f, 0.000000f, 13.510000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(1.600000f, 0.000000f, 13.510000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(1.600000f, 0.000000f, 40.280000f)),
				new ObsInfo(ObsKind.cartladder, new Vector3(0.000000f, 0.000000f, 4.600000f)),
				new ObsInfo(ObsKind.swingBob, new Vector3(0.000000f, 0.000000f, 29.150000f)),}, null,
		new Coins[] {
				new Coins(new Vector3(-1.600000f, 0.500000f, 34.310000f)),
				new Coins(new Vector3(-1.600000f, 0.500000f, 32.310000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 34.310000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 32.310000f)),
				new Coins(new Vector3(1.600000f, 0.500000f, 30.310000f)),	new Coins(new Vector3(0.000000f, 2.500000f, 15.900000f)),	new Coins(new Vector3(0.000000f, 2.500000f, 9.900000f)),
				new Coins(new Vector3(0.000000f, 2.500000f, 11.900000f)),	new Coins(new Vector3(0.000000f, 2.500000f, 13.900000f)),	new Coins(new Vector3(1.600000f, 2.500000f, 11.900000f)),
				new Coins(new Vector3(1.600000f, 2.500000f, 17.900000f)),	new Coins(new Vector3(1.600000f, 2.500000f, 13.900000f)),	new Coins(new Vector3(1.600000f, 2.500000f, 15.900000f)),
				new Coins(new Vector3(-1.600000f, 2.500000f, 9.900000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 30.310000f)),	new Coins(new Vector3(-1.600000f, 2.500000f, 15.900000f)),
				new Coins(new Vector3(-1.600000f, 2.500000f, 11.900000f)),	new Coins(new Vector3(0.000000f, 2.500000f, 7.900000f)),	new Coins(new Vector3(1.600000f, 2.500000f, 7.900000f)),
				new Coins(new Vector3(-1.600000f, 2.500000f, 7.900000f)),	new Coins(new Vector3(-1.600000f, 2.500000f, 17.900000f)),	new Coins(new Vector3(-1.600000f, 2.500000f, 13.900000f)),
				new Coins(new Vector3(1.600000f, 2.500000f, 9.900000f)),	new Coins(new Vector3(0.000000f, 2.500000f, 17.900000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 44.310000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 46.310000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 38.310000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 36.310000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 42.310000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 34.310000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 32.310000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 40.310000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 30.310000f)),}, null),
        //3-5
        new RoadBlock(
		new Items[] {
				new Items(ItemKind.balloon, new Vector3(-1.600000f, 0.000000f, 23.620000f))},
		new ObsInfo[] {
				new ObsInfo(ObsKind.carttroupe, new Vector3(0.000000f, 0.000000f, 7.670000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(0.000000f, 0.000000f, 4.470000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(1.600000f, 0.000000f, 30.130000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(1.600000f, 0.000000f, 33.330000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(1.600000f, 0.000000f, 26.930000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(1.600000f, 0.000000f, 36.530000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(1.600000f, 0.000000f, 4.470000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(1.600000f, 0.000000f, 7.670000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(1.600000f, 0.000000f, 16.220000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(1.600000f, 0.000000f, 13.020000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(-1.600000f, 0.000000f, 17.460000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(0.000000f, 0.000000f, 45.740000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(-1.600000f, 0.000000f, 38.830000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(0.000000f, 0.000000f, 26.930000f)),
				new ObsInfo(ObsKind.hurdlemiddle, new Vector3(-1.600000f, 0.000000f, 7.530000f)),
				new ObsInfo(ObsKind.hurdlemiddle, new Vector3(0.000000f, 0.000000f, 16.530000f)),
				new ObsInfo(ObsKind.hurdlemiddle, new Vector3(-1.600000f, 0.000000f, 27.260000f)),
				new ObsInfo(ObsKind.cartladder, new Vector3(1.600000f, 0.000000f, 23.250000f)),}, null,
		new Coins[] {
				new Coins(new Vector3(0.000000f, 0.500000f, 15.500000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 13.500000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 17.500000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 21.500000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 19.500000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 23.500000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 37.810000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 31.810000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 33.810000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 39.810000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 35.810000f)),},
		new JumpCoins[] {
				new JumpCoins( new Vector3(-1.750000f, 0.390000f, 6.980000f)),}),
    //3-6
        new RoadBlock(
		new Items[] {
				new Items(ItemKind.fly, new Vector3(0.000000f, 0.000000f, 44.190000f))},
		new ObsInfo[] {
				new ObsInfo(ObsKind.runtroupe, new Vector3(0.000000f, 0.000000f, 10.100000f)),
				new ObsInfo(ObsKind.runtroupe, new Vector3(0.000000f, 0.000000f, 13.150000f)),
				new ObsInfo(ObsKind.runtroupe, new Vector3(0.000000f, 0.000000f, 34.430000f)),
				new ObsInfo(ObsKind.runtroupe, new Vector3(0.000000f, 0.000000f, 37.460000f)),
				new ObsInfo(ObsKind.runstand, new Vector3(-1.600000f, 0.000000f, 21.640000f)),
				new ObsInfo(ObsKind.runstand, new Vector3(-1.600000f, 0.000000f, 24.830000f)),
				new ObsInfo(ObsKind.runstand, new Vector3(1.600000f, 0.000000f, 24.830000f)),
				new ObsInfo(ObsKind.runstand, new Vector3(1.600000f, 0.000000f, 21.640000f)),
				new ObsInfo(ObsKind.ball, new Vector3(1.600000f, 0.000000f, 11.540000f)),
				new ObsInfo(ObsKind.ball, new Vector3(-1.600000f, 0.000000f, 11.540000f)),
				new ObsInfo(ObsKind.ball, new Vector3(1.600000f, 0.000000f, 35.750000f)),
				new ObsInfo(ObsKind.ball, new Vector3(-1.600000f, 0.000000f, 35.750000f)),
				new ObsInfo(ObsKind.hurdlemiddle, new Vector3(1.600000f, 0.000000f, 44.190000f)),
				new ObsInfo(ObsKind.hurdlemiddle, new Vector3(-1.600000f, 0.000000f, 44.190000f)),}, null,
		new Coins[] {
				new Coins(new Vector3(0.000000f, 0.500000f, 1.890000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 7.890000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 3.890000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 5.890000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 27.870000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 31.870000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 29.870000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 25.870000f)),}, null),
    //3-7
        new RoadBlock(null, 
		new ObsInfo[] {
				new ObsInfo(ObsKind.runtroupe, new Vector3(0.000000f, 0.000000f, 9.220000f)),
				new ObsInfo(ObsKind.runtroupe, new Vector3(0.000000f, 0.000000f, 12.420000f)),
				new ObsInfo(ObsKind.runtroupe, new Vector3(0.000000f, 0.000000f, 26.580000f)),
				new ObsInfo(ObsKind.runtroupe, new Vector3(0.000000f, 0.000000f, 23.380000f)),
				new ObsInfo(ObsKind.runstand, new Vector3(0.000000f, 0.000000f, 33.080000f)),
				new ObsInfo(ObsKind.runstand, new Vector3(0.000000f, 0.000000f, 36.260000f)),
				new ObsInfo(ObsKind.runstand, new Vector3(0.000000f, 0.000000f, 39.440000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(1.600000f, 0.000000f, 39.430000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(-1.600000f, 0.000000f, 42.630000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(1.600000f, 0.000000f, 36.230000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(1.600000f, 0.000000f, 42.630000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(1.600000f, 0.000000f, 33.030000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(-1.600000f, 0.000000f, 33.030000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(-1.600000f, 0.000000f, 39.430000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(-1.600000f, 0.000000f, 36.230000f)),
				new ObsInfo(ObsKind.cartladder, new Vector3(1.600000f, 0.000000f, 29.350000f)),
				new ObsInfo(ObsKind.cartladder, new Vector3(-1.600000f, 0.000000f, 29.350000f)),
				new ObsInfo(ObsKind.ball, new Vector3(1.600000f, 0.000000f, 10.780000f)),
				new ObsInfo(ObsKind.ball, new Vector3(-1.600000f, 0.000000f, 10.780000f)),
				new ObsInfo(ObsKind.ball, new Vector3(1.600000f, 0.000000f, 24.700000f)),
				new ObsInfo(ObsKind.ball, new Vector3(-1.600000f, 0.000000f, 24.700000f)),}, null,
		new Coins[] {
				new Coins(new Vector3(1.600000f, 2.500000f, 31.900000f)),
				new Coins(new Vector3(-1.600000f, 2.500000f, 31.900000f)),	new Coins(new Vector3(1.600000f, 2.500000f, 39.900000f)),	new Coins(new Vector3(1.600000f, 2.500000f, 33.900000f)),
				new Coins(new Vector3(1.600000f, 2.500000f, 41.900000f)),	new Coins(new Vector3(1.600000f, 2.500000f, 37.900000f)),	new Coins(new Vector3(-1.600000f, 2.500000f, 33.900000f)),
				new Coins(new Vector3(-1.600000f, 2.500000f, 41.900000f)),	new Coins(new Vector3(-1.600000f, 2.500000f, 37.900000f)),	new Coins(new Vector3(1.600000f, 2.500000f, 35.900000f)),
				new Coins(new Vector3(-1.600000f, 2.500000f, 35.900000f)),	new Coins(new Vector3(-1.600000f, 2.500000f, 39.900000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 14.940000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 16.940000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 18.940000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 20.940000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 4.480000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 6.480000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 2.480000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 0.480000f)),}, null),
    //3-8
        new RoadBlock(
		new Items[] {
				new Items(ItemKind.shield, new Vector3(0.000000f, 0.000000f, 11.520000f))},
		new ObsInfo[] {
				new ObsInfo(ObsKind.runtroupe, new Vector3(-1.600000f, 0.000000f, 11.310000f)),
				new ObsInfo(ObsKind.runtroupe, new Vector3(-1.600000f, 0.000000f, 8.110000f)),
				new ObsInfo(ObsKind.runtroupe, new Vector3(1.600000f, 0.000000f, 22.820000f)),
				new ObsInfo(ObsKind.runtroupe, new Vector3(1.600000f, 0.000000f, 19.620000f)),
				new ObsInfo(ObsKind.runstand, new Vector3(1.600000f, 0.000000f, 36.140000f)),
				new ObsInfo(ObsKind.runstand, new Vector3(1.600000f, 0.000000f, 32.940000f)),
				new ObsInfo(ObsKind.runstand, new Vector3(1.600000f, 0.000000f, 29.740000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(0.000000f, 0.000000f, 39.340000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(-1.600000f, 0.000000f, 32.940000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(0.000000f, 0.000000f, 32.940000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(0.000000f, 0.000000f, 36.140000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(0.000000f, 0.000000f, 29.740000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(-1.600000f, 0.000000f, 29.740000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(-1.600000f, 0.000000f, 39.340000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(-1.600000f, 0.000000f, 36.140000f)),
				new ObsInfo(ObsKind.cartladder, new Vector3(0.000000f, 0.000000f, 26.060000f)),
				new ObsInfo(ObsKind.cartladder, new Vector3(-1.600000f, 0.000000f, 26.060000f)),
				new ObsInfo(ObsKind.hurdlemiddle, new Vector3(-1.600000f, 0.000000f, 20.450000f)),
				new ObsInfo(ObsKind.ball, new Vector3(0.000000f, 0.000000f, 9.420000f)),
				new ObsInfo(ObsKind.ball, new Vector3(0.000000f, 0.000000f, 21.060000f)),}, null,
		new Coins[] {
				new Coins(new Vector3(0.000000f, 2.500000f, 29.030000f)),
				new Coins(new Vector3(-1.600000f, 2.500000f, 29.030000f)),	new Coins(new Vector3(0.000000f, 2.500000f, 39.030000f)),	new Coins(new Vector3(0.000000f, 2.500000f, 33.030000f)),
				new Coins(new Vector3(0.000000f, 2.500000f, 31.030000f)),	new Coins(new Vector3(0.000000f, 2.500000f, 37.030000f)),	new Coins(new Vector3(-1.600000f, 2.500000f, 35.030000f)),
				new Coins(new Vector3(-1.600000f, 2.500000f, 31.030000f)),	new Coins(new Vector3(-1.600000f, 2.500000f, 37.030000f)),	new Coins(new Vector3(-1.600000f, 2.500000f, 39.030000f)),
				new Coins(new Vector3(-1.600000f, 2.500000f, 33.030000f)),	new Coins(new Vector3(0.000000f, 2.500000f, 35.030000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 0.310000f)),
				new Coins(new Vector3(-1.600000f, 0.500000f, 2.310000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 4.310000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 6.310000f)),
				new Coins(new Vector3(1.600000f, 0.500000f, 15.080000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 17.080000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 13.080000f)),
				new Coins(new Vector3(1.600000f, 0.500000f, 11.080000f)),}, null),
       //3-9 fly
        new RoadBlock(
		new Items[] {
				new Items(ItemKind.spring, new Vector3(0.000000f, 0.000000f, 29.120000f))},
		new ObsInfo[] {
				new ObsInfo(ObsKind.carttroupe, new Vector3(1.600000f, 0.000000f, 8.410000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(1.600000f, 0.000000f, 11.610000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(-1.600000f, 0.000000f, 11.610000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(-1.600000f, 0.000000f, 8.410000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(1.600000f, 0.000000f, 42.120000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(0.000000f, 0.000000f, 9.410000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(0.000000f, 0.000000f, 12.610000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(-1.600000f, 0.000000f, 42.120000f)),
				new ObsInfo(ObsKind.hurdlemiddle, new Vector3(-1.600000f, 0.000000f, 22.710000f)),
				new ObsInfo(ObsKind.hurdlemiddle, new Vector3(1.600000f, 0.000000f, 22.710000f)),
				new ObsInfo(ObsKind.ball, new Vector3(0.000000f, 0.000000f, 24.410000f)),
				new ObsInfo(ObsKind.swingBob, new Vector3(0.000000f, 0.000000f, 21.970000f)),
				new ObsInfo(ObsKind.swingBob, new Vector3(0.000000f, 0.000000f, 36.050000f)),
				new ObsInfo(ObsKind.cartladder, new Vector3(1.600000f, 0.000000f, 4.740000f)),
				new ObsInfo(ObsKind.cartladder, new Vector3(-1.600000f, 0.000000f, 4.740000f)),}, null,
		new Coins[] {
				new Coins(new Vector3(-1.600000f, 2.500000f, 11.160000f)),
				new Coins(new Vector3(-1.600000f, 2.500000f, 9.160000f)),	new Coins(new Vector3(-1.600000f, 2.500000f, 7.160000f)),	new Coins(new Vector3(1.600000f, 2.500000f, 7.160000f)),
				new Coins(new Vector3(1.600000f, 2.500000f, 11.160000f)),	new Coins(new Vector3(1.600000f, 2.500000f, 9.160000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 41.600000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 45.600000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 39.600000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 47.600000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 43.600000f)),},
		new JumpCoins[] {
				new JumpCoins( new Vector3(-1.600000f, 0.500000f, 22.250000f)),
				new JumpCoins(new Vector3(1.600000f, 0.500000f, 22.380000f)),}),
        //3-10
            new RoadBlock(
		new Items[] {
				new Items(ItemKind.magnet, new Vector3(0.000000f, 0.000000f, 6.540000f))},
		new ObsInfo[] {
				new ObsInfo(ObsKind.flagPole4, new Vector3(0.000000f, 0.000000f, 25.560000f)),
				new ObsInfo(ObsKind.runstand, new Vector3(1.600000f, 0.000000f, 25.410000f)),
				new ObsInfo(ObsKind.runtroupe, new Vector3(-1.600000f, 0.000000f, 12.180000f)),
				new ObsInfo(ObsKind.runtroupe, new Vector3(-1.600000f, 0.000000f, 36.570000f)),}, null,
		new Coins[] {
				new Coins(new Vector3(0.000000f, 0.500000f, 10.330000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 22.100000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 26.100000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 28.100000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 24.100000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 40.130000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 34.130000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 38.130000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 36.130000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 16.330000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 14.330000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 12.330000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 8.030000f)),
				new Coins(new Vector3(1.600000f, 0.500000f, 4.030000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 10.030000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 6.030000f)),}, null),
        //3-11
            new RoadBlock(
		new Items[] {
				new Items(ItemKind.fly, new Vector3(0.000000f, 0.000000f, 18.539940f))},
		new ObsInfo[] {
				new ObsInfo(ObsKind.runtroupe, new Vector3(0.000000f, 0.000000f, 10.100000f)),
				new ObsInfo(ObsKind.runtroupe, new Vector3(0.000000f, 0.000000f, 13.300000f)),
				new ObsInfo(ObsKind.runtroupe, new Vector3(0.000000f, 0.000000f, 38.510000f)),
				new ObsInfo(ObsKind.runtroupe, new Vector3(0.000000f, 0.000000f, 41.710000f)),
				new ObsInfo(ObsKind.runstand, new Vector3(-1.600000f, 0.000000f, 24.690000f)),
				new ObsInfo(ObsKind.runstand, new Vector3(1.600000f, 0.000000f, 24.690000f)),
				new ObsInfo(ObsKind.ball, new Vector3(1.600000f, 0.000000f, 11.540000f)),
				new ObsInfo(ObsKind.ball, new Vector3(-1.600000f, 0.000000f, 11.540000f)),
				new ObsInfo(ObsKind.ball, new Vector3(1.600000f, 0.000000f, 35.750000f)),
				new ObsInfo(ObsKind.ball, new Vector3(-1.600000f, 0.000000f, 35.750000f)),
				new ObsInfo(ObsKind.hurdlemiddle, new Vector3(1.600000f, 0.000000f, 44.190000f)),
				new ObsInfo(ObsKind.hurdlemiddle, new Vector3(-1.600000f, 0.000000f, 44.190000f)),}, null,
		new Coins[] {
				new Coins(new Vector3(0.000000f, 0.500000f, 3.890000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 7.890000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 5.890000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 1.890000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 27.870000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 25.870000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 29.870000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 31.870000f)),}, null),
        //3-12
            new RoadBlock(
		new Items[] {
				new Items(ItemKind.shield, new Vector3(1.600000f, 0.000000f, 33.410000f))},
		new ObsInfo[] {
				new ObsInfo(ObsKind.runtroupe, new Vector3(0.000000f, 0.000000f, 10.740000f)),
				new ObsInfo(ObsKind.runstand, new Vector3(-1.600000f, 0.000000f, 23.070000f)),
				new ObsInfo(ObsKind.runstand, new Vector3(-1.600000f, 0.000000f, 26.270000f)),
				new ObsInfo(ObsKind.runstand, new Vector3(1.600000f, 0.000000f, 47.250000f)),
				new ObsInfo(ObsKind.runstand, new Vector3(1.600000f, 0.000000f, 44.050000f)),
				new ObsInfo(ObsKind.flagPole2, new Vector3(0.000000f, 0.000000f, 25.300000f)),
				new ObsInfo(ObsKind.ball, new Vector3(0.000000f, 0.000000f, 25.120000f)),
				new ObsInfo(ObsKind.runtroupe, new Vector3(0.000000f, 0.000000f, 7.540000f)),}, null,
		new Coins[] {
				new Coins(new Vector3(1.600000f, 0.500000f, 2.600000f)),
				new Coins(new Vector3(1.600000f, 0.500000f, 10.600000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 6.600000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 4.600000f)),
				new Coins(new Vector3(1.600000f, 0.500000f, 8.600000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 12.560000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 6.560000f)),
				new Coins(new Vector3(-1.600000f, 0.500000f, 14.560000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 10.560000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 8.559999f)),
				new Coins(new Vector3(-1.600000f, 0.500000f, 16.560000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 26.800000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 22.800000f)),
				new Coins(new Vector3(1.600000f, 0.500000f, 24.800000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 20.800000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 28.800000f)),
				new Coins(new Vector3(-1.600000f, 0.500000f, 38.960000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 32.960000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 40.960000f)),
				new Coins(new Vector3(-1.600000f, 0.500000f, 34.960000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 36.960000f)),}, null),

      //3-13
            new RoadBlock(
		new Items[] {
				new Items(ItemKind.spring, new Vector3(-1.600000f, 0.000000f, 48.070000f))},
		new ObsInfo[] {
				new ObsInfo(ObsKind.runtroupe, new Vector3(1.600000f, 0.000000f, 7.620000f)),
				new ObsInfo(ObsKind.runtroupe, new Vector3(1.600000f, 0.000000f, 10.820000f)),
				new ObsInfo(ObsKind.ball, new Vector3(-1.600000f, 0.000000f, 18.890000f)),
				new ObsInfo(ObsKind.ball, new Vector3(1.600000f, 0.000000f, 30.900000f)),
				new ObsInfo(ObsKind.ball, new Vector3(-1.600000f, 0.000000f, 40.150000f)),
				new ObsInfo(ObsKind.ball, new Vector3(1.600000f, 0.000000f, 48.080000f)),}, null,
		new Coins[] {
				new Coins(new Vector3(1.600000f, 0.500000f, 14.650000f)),
				new Coins(new Vector3(-1.600000f, 0.500000f, 21.650000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 22.650000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 16.650000f)),
				new Coins(new Vector3(1.600000f, 0.500000f, 18.650000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 20.650000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 25.650000f)),
				new Coins(new Vector3(-1.600000f, 0.500000f, 27.650000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 31.650000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 23.650000f)),
				new Coins(new Vector3(-1.600000f, 0.500000f, 29.650000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 36.240000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 32.240000f)),
				new Coins(new Vector3(1.600000f, 0.500000f, 40.240000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 34.240000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 38.240000f)),}, null),

	};
    public static RoadBlock[] lv4 =
	{
        //4-0
            new RoadBlock(
		new Items[] {
				new Items(ItemKind.magnet, new Vector3(-1.600000f, 0.000000f, 34.830000f))},
		new ObsInfo[] {
				new ObsInfo(ObsKind.flagPole3, new Vector3(0.000000f, 0.000000f, 29.150000f)),
				new ObsInfo(ObsKind.ball, new Vector3(1.600000f, 0.000000f, 26.110000f)),
				new ObsInfo(ObsKind.ball, new Vector3(1.600000f, 0.000000f, 42.710000f)),
				new ObsInfo(ObsKind.runstand, new Vector3(-1.600000f, 0.000000f, 14.430000f)),
				new ObsInfo(ObsKind.runstand, new Vector3(-1.600000f, 0.000000f, 30.210000f)),
				new ObsInfo(ObsKind.hurdledown, new Vector3(-1.600000f, 0.000000f, 6.100000f)),
				new ObsInfo(ObsKind.hurdledown, new Vector3(1.600000f, 0.000000f, 6.100000f)),}, null,
		new Coins[] {
				new Coins(new Vector3(0.000000f, 0.500000f, 18.240000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 22.240000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 20.240000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 24.240000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 16.240000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 32.750000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 40.750000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 38.750000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 36.750000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 34.750000f)),}, null),
       // 4-1
            new RoadBlock(
		new Items[] {
				new Items(ItemKind.balloon, new Vector3(-1.600000f, 2.000000f, 35.386000f))},
		new ObsInfo[] {
				new ObsInfo(ObsKind.cartstand, new Vector3(0.000000f, 0.000000f, 29.680000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(1.600000f, 0.000000f, 40.730000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(0.000000f, 0.000000f, 43.420000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(1.600000f, 0.000000f, 43.930000f)),
				new ObsInfo(ObsKind.cartladder, new Vector3(-1.600000f, 0.000000f, 24.640000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(-1.600000f, 0.000000f, 28.310000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(-1.600000f, 0.000000f, 31.510000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(-1.600000f, 0.000000f, 34.710000f)),
				new ObsInfo(ObsKind.hurdlemiddle, new Vector3(1.600000f, 0.000000f, 31.730000f)),
				new ObsInfo(ObsKind.hurdledown, new Vector3(0.000000f, 0.000000f, 20.700000f)),
				new ObsInfo(ObsKind.swingBob, new Vector3(0.000000f, 0.000000f, 11.940000f)),
				new ObsInfo(ObsKind.swingBob, new Vector3(0.000000f, 0.000000f, 4.580000f)),}, null,
		new Coins[] {
				new Coins(new Vector3(-1.600000f, 0.500000f, 17.640000f)),
				new Coins(new Vector3(-1.600000f, 0.500000f, 15.640000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 19.640000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 21.640000f)),
				new Coins(new Vector3(1.600000f, 0.500000f, 24.040000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 32.040000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 28.040000f)),
				new Coins(new Vector3(1.600000f, 0.500000f, 30.040000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 26.040000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 42.730000f)),
				new Coins(new Vector3(-1.600000f, 0.500000f, 44.730000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 46.730000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 48.730000f)),}, null),
      //4-2
            new RoadBlock(
		new Items[] {
				new Items(ItemKind.fly, new Vector3(1.600000f, 0.000000f, 36.080000f))},
		new ObsInfo[] {
				new ObsInfo(ObsKind.cartstand, new Vector3(0.000000f, 0.000000f, 29.680000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(0.000000f, 0.000000f, 32.880000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(0.000000f, 0.000000f, 39.280000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(0.000000f, 0.000000f, 36.080000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(-1.600000f, 0.000000f, 31.460000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(-1.600000f, 0.000000f, 34.660000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(-1.600000f, 0.000000f, 37.860000f)),
				new ObsInfo(ObsKind.carttroupe, new Vector3(-1.600000f, 0.000000f, 28.260000f)),
				new ObsInfo(ObsKind.hurdlemiddle, new Vector3(1.600000f, 0.000000f, 31.730000f)),
				new ObsInfo(ObsKind.hurdlemiddle, new Vector3(1.600000f, 0.000000f, 42.450000f)),
				new ObsInfo(ObsKind.hurdledown, new Vector3(0.000000f, 0.000000f, 20.080000f)),
				new ObsInfo(ObsKind.swingBob, new Vector3(0.000000f, 0.000000f, 15.220000f)),
				new ObsInfo(ObsKind.swingBob, new Vector3(0.000000f, 0.000000f, 7.150000f)),
				new ObsInfo(ObsKind.cartladder, new Vector3(-1.600000f, 0.000000f, 24.580000f)),}, null,
		new Coins[] {
				new Coins(new Vector3(-1.600000f, 0.500000f, 15.640000f)),
				new Coins(new Vector3(-1.600000f, 0.500000f, 17.640000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 21.640000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 19.640000f)),
				new Coins(new Vector3(1.600000f, 0.500000f, 28.040000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 26.040000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 32.040000f)),
				new Coins(new Vector3(1.600000f, 0.500000f, 24.040000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 30.040000f)),},
		new JumpCoins[] {
				new JumpCoins( new Vector3(1.600000f, 0.500000f, 34.040000f)),}),

       // 4-3
            new RoadBlock(
		new Items[] {
				new Items(ItemKind.shield, new Vector3(0.000000f, 0.000000f, 17.600000f))},
		new ObsInfo[] {
				new ObsInfo(ObsKind.runtroupe, new Vector3(-1.600000f, 0.000000f, 10.010000f)),
				new ObsInfo(ObsKind.runtroupe, new Vector3(-1.600000f, 0.000000f, 13.210000f)),
				new ObsInfo(ObsKind.runtroupe, new Vector3(1.600000f, 0.000000f, 34.710000f)),
				new ObsInfo(ObsKind.runtroupe, new Vector3(1.600000f, 0.000000f, 37.910000f)),
				new ObsInfo(ObsKind.runstand, new Vector3(-1.600000f, 0.000000f, 21.640000f)),
				new ObsInfo(ObsKind.runstand, new Vector3(-1.600000f, 0.000000f, 24.840000f)),
				new ObsInfo(ObsKind.runstand, new Vector3(1.600000f, 0.000000f, 21.640000f)),
				new ObsInfo(ObsKind.runstand, new Vector3(1.600000f, 0.000000f, 24.840000f)),
				new ObsInfo(ObsKind.ball, new Vector3(1.600000f, 0.000000f, 17.960000f)),
				new ObsInfo(ObsKind.ball, new Vector3(0.000000f, 0.000000f, 15.300000f)),
				new ObsInfo(ObsKind.ball, new Vector3(0.000000f, 0.000000f, 40.660000f)),
				new ObsInfo(ObsKind.ball, new Vector3(-1.600000f, 0.000000f, 37.060000f)),
				new ObsInfo(ObsKind.ball, new Vector3(0.000000f, 0.000000f, 23.990000f)),
				new ObsInfo(ObsKind.hurdlemiddle, new Vector3(1.600000f, 0.000000f, 44.920000f)),
				new ObsInfo(ObsKind.hurdlemiddle, new Vector3(0.000000f, 0.000000f, 44.920000f)),}, null,
		new Coins[] {
				new Coins(new Vector3(0.000000f, 0.500000f, 1.890000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 7.890000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 5.890000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 3.890000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 25.870000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 31.870000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 29.870000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 27.870000f)),}, null),
      //4-4
        new RoadBlock(
		new Items[] {
				new Items(ItemKind.magnet, new Vector3(0.000000f, 0.000000f, 39.810000f))},
		new ObsInfo[] {
				new ObsInfo(ObsKind.runtroupe, new Vector3(0.000000f, 0.000000f, 4.370000f)),
				new ObsInfo(ObsKind.runtroupe, new Vector3(0.000000f, 0.000000f, 7.570000f)),
				new ObsInfo(ObsKind.runtroupe, new Vector3(0.000000f, 0.000000f, 16.990000f)),
				new ObsInfo(ObsKind.balloon, new Vector3(-0.800000f, 0.000000f, 37.070000f)),
				new ObsInfo(ObsKind.ball, new Vector3(1.600000f, 0.000000f, 2.000000f)),
				new ObsInfo(ObsKind.runtroupe, new Vector3(0.000000f, 0.000000f, 20.190000f)),
				new ObsInfo(ObsKind.ball, new Vector3(-1.600000f, 0.000000f, 21.250000f)),
				new ObsInfo(ObsKind.ball, new Vector3(1.600000f, 0.000000f, 21.250000f)),
				new ObsInfo(ObsKind.ball, new Vector3(-1.600000f, 0.000000f, 2.000000f)),}, null,
		new Coins[] {
				new Coins(new Vector3(-1.600000f, 0.500000f, 7.310000f)),
				new Coins(new Vector3(-1.600000f, 0.500000f, 5.310000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 9.309999f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 11.310000f)),
				new Coins(new Vector3(-1.600000f, 0.500000f, 3.310000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 5.310000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 11.310000f)),
				new Coins(new Vector3(1.600000f, 0.500000f, 9.309999f)),	new Coins(new Vector3(1.600000f, 0.500000f, 3.310000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 7.310000f)),
				new Coins(new Vector3(-1.600000f, 0.500000f, 28.290000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 26.290000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 32.290000f)),
				new Coins(new Vector3(-1.600000f, 0.500000f, 30.290000f)),	new Coins(new Vector3(-0.800000f, 0.500000f, 34.290000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 40.180000f)),
				new Coins(new Vector3(1.600000f, 0.500000f, 42.180000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 46.180000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 44.180000f)),
				new Coins(new Vector3(1.600000f, 0.500000f, 48.180000f)),}, null),
      //4-5
            new RoadBlock(
		new Items[] {
				new Items(ItemKind.balloon, new Vector3(-1.600000f, 0.000000f, 38.653000f))},
		new ObsInfo[] {
				new ObsInfo(ObsKind.runtroupe, new Vector3(1.600000f, 0.000000f, 4.380000f)),
				new ObsInfo(ObsKind.runtroupe, new Vector3(1.600000f, 0.000000f, 7.550000f)),
				new ObsInfo(ObsKind.runtroupe, new Vector3(-1.600000f, 0.000000f, 16.860000f)),
				new ObsInfo(ObsKind.runtroupe, new Vector3(-1.600000f, 0.000000f, 19.950000f)),
				new ObsInfo(ObsKind.balloon, new Vector3(0.800000f, 0.000000f, 37.360000f)),}, null,
		new Coins[] {
				new Coins(new Vector3(-1.600000f, 0.500000f, 5.310000f)),
				new Coins(new Vector3(-1.600000f, 0.500000f, 3.310000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 7.310000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 3.310000f)),
				new Coins(new Vector3(-1.600000f, 0.500000f, 9.309999f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 11.310000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 26.660000f)),
				new Coins(new Vector3(-1.600000f, 0.500000f, 42.810000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 7.310000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 11.310000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 5.310000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 9.309999f)),	new Coins(new Vector3(1.600000f, 0.500000f, 28.660000f)),
				new Coins(new Vector3(1.600000f, 0.500000f, 30.660000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 32.660000f)),	new Coins(new Vector3(0.800000f, 0.500000f, 34.110000f)),
				new Coins(new Vector3(-1.600000f, 0.500000f, 44.810000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 40.810000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 46.810000f)),}, null),
      //4-6 fly
            new RoadBlock(
		new Items[] {
				new Items(ItemKind.shield, new Vector3(0.000000f, 0.000000f, 27.170000f))},
		new ObsInfo[] {
				new ObsInfo(ObsKind.cartstand, new Vector3(1.600000f, 0.000000f, 39.540000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(0.000000f, 0.000000f, 6.610000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(1.600000f, 0.000000f, 6.610000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(-1.600000f, 0.000000f, 39.540000f)),
				new ObsInfo(ObsKind.hurdlemiddle, new Vector3(-1.600000f, 0.000000f, 19.240180f)),
				new ObsInfo(ObsKind.hurdlemiddle, new Vector3(1.600000f, 0.000000f, 19.240180f)),
				new ObsInfo(ObsKind.ball, new Vector3(0.000000f, 0.000000f, 17.120000f)),
				new ObsInfo(ObsKind.ball, new Vector3(0.000000f, 0.000000f, 25.430000f)),
				new ObsInfo(ObsKind.swingBob, new Vector3(0.000000f, 0.000000f, 30.080000f)),}, null,
		new Coins[] {
				new Coins(new Vector3(0.000000f, 0.500000f, 35.370000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 37.370000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 45.370000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 43.370000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 47.370000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 39.370000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 41.370000f)),},
		new JumpCoins[] {
				new JumpCoins( new Vector3(-1.600000f, 0.500000f, 18.970000f)),
				new JumpCoins(new Vector3(1.600000f, 0.500000f, 19.060000f)),}),
     //4-7
        new RoadBlock(
		new Items[] {
				new Items(ItemKind.fly, new Vector3(0.000000f, 0.000000f, 43.280000f))},
		new ObsInfo[] {
				new ObsInfo(ObsKind.cartstand, new Vector3(1.600000f, 0.000000f, 40.170000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(0.000000f, 0.000000f, 5.350000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(1.600000f, 0.000000f, 5.350000f)),
				new ObsInfo(ObsKind.cartstand, new Vector3(0.000000f, 0.000000f, 40.170000f)),
				new ObsInfo(ObsKind.hurdlemiddle, new Vector3(-1.600000f, 0.000000f, 19.570000f)),
				new ObsInfo(ObsKind.hurdlemiddle, new Vector3(1.600000f, 0.000000f, 19.570000f)),
				new ObsInfo(ObsKind.swingBob, new Vector3(0.000000f, 0.000000f, 32.390000f)),
				new ObsInfo(ObsKind.swingBob, new Vector3(0.000000f, 0.000000f, 27.880000f)),
				new ObsInfo(ObsKind.ball, new Vector3(0.000000f, 0.000000f, 15.240000f)),
				new ObsInfo(ObsKind.ball, new Vector3(0.000000f, 0.000000f, 25.020000f)),}, null,
		new Coins[] {
				new Coins(new Vector3(-1.600000f, 0.500000f, 37.370000f)),
				new Coins(new Vector3(-1.600000f, 0.500000f, 41.370000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 43.370000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 45.370000f)),
				new Coins(new Vector3(-1.600000f, 0.500000f, 39.370000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 47.370000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 35.370000f)),},
		new JumpCoins[] {
				new JumpCoins( new Vector3(1.600000f, 0.500000f, 19.330000f)),
				new JumpCoins(new Vector3(-1.600000f, 0.500000f, 19.360000f)),}),
     // 4-8
            new RoadBlock(
		new Items[] {
				new Items(ItemKind.spring, new Vector3(0.000000f, 0.000000f, 42.146000f))},
		new ObsInfo[] {
				new ObsInfo(ObsKind.runtroupe, new Vector3(0.000000f, 0.000000f, 13.300000f)),
				new ObsInfo(ObsKind.runtroupe, new Vector3(0.000000f, 0.000000f, 10.100000f)),
				new ObsInfo(ObsKind.runstand, new Vector3(-1.600000f, 0.000000f, 21.640000f)),
				new ObsInfo(ObsKind.runstand, new Vector3(-1.600000f, 0.000000f, 24.840000f)),
				new ObsInfo(ObsKind.runstand, new Vector3(1.600000f, 0.000000f, 24.840000f)),
				new ObsInfo(ObsKind.runstand, new Vector3(1.600000f, 0.000000f, 21.640000f)),
				new ObsInfo(ObsKind.swingBob, new Vector3(0.000000f, 0.000000f, 37.230000f)),
				new ObsInfo(ObsKind.hurdledown, new Vector3(1.600000f, 0.000000f, 45.940000f)),
				new ObsInfo(ObsKind.hurdledown, new Vector3(0.000000f, 0.000000f, 45.940000f)),
				new ObsInfo(ObsKind.ball, new Vector3(1.600000f, 0.000000f, 11.540000f)),
				new ObsInfo(ObsKind.ball, new Vector3(-1.600000f, 0.000000f, 11.540000f)),
				new ObsInfo(ObsKind.ball, new Vector3(0.000000f, 0.000000f, 33.760000f)),}, null,
		new Coins[] {
				new Coins(new Vector3(0.000000f, 0.500000f, 1.890000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 3.890000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 5.890000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 7.890000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 22.450000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 18.450000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 16.450000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 24.450000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 20.450000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 33.140000f)),
				new Coins(new Vector3(1.600000f, 0.500000f, 31.140000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 35.140000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 39.140000f)),
				new Coins(new Vector3(-1.600000f, 0.500000f, 31.140000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 33.140000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 37.140000f)),
				new Coins(new Vector3(-1.600000f, 0.500000f, 41.140000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 35.140000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 39.140000f)),
				new Coins(new Vector3(1.600000f, 0.500000f, 37.140000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 41.140000f)),}, null),
     // 4-9
            new RoadBlock(
		new Items[] {
				new Items(ItemKind.fly, new Vector3(0.000000f, 0.000000f, 1.587000f))},
		new ObsInfo[] {
				new ObsInfo(ObsKind.runtroupe, new Vector3(-1.600000f, 0.000000f, 8.170000f)),
				new ObsInfo(ObsKind.runtroupe, new Vector3(-1.600000f, 0.000000f, 4.970000f)),
				new ObsInfo(ObsKind.runtroupe, new Vector3(1.600000f, 0.000000f, 12.850000f)),
				new ObsInfo(ObsKind.runtroupe, new Vector3(1.600000f, 0.000000f, 16.050000f)),
				new ObsInfo(ObsKind.runstand, new Vector3(-1.600000f, 0.000000f, 24.460000f)),
				new ObsInfo(ObsKind.runstand, new Vector3(-1.600000f, 0.000000f, 21.260000f)),
				new ObsInfo(ObsKind.runstand, new Vector3(1.600000f, 0.000000f, 33.900000f)),
				new ObsInfo(ObsKind.runstand, new Vector3(1.600000f, 0.000000f, 41.950000f)),
				new ObsInfo(ObsKind.runstand, new Vector3(1.600000f, 0.000000f, 45.150000f)),
				new ObsInfo(ObsKind.runstand, new Vector3(1.600000f, 0.000000f, 30.700000f)),
				new ObsInfo(ObsKind.flagPole2, new Vector3(0.000000f, 0.000000f, 33.320000f)),
				new ObsInfo(ObsKind.ball, new Vector3(-1.600000f, 0.000000f, 43.380000f)),}, null,
		new Coins[] {
				new Coins(new Vector3(0.000000f, 0.500000f, 11.350000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 13.350000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 17.350000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 15.350000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 25.810000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 27.810000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 37.810000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 29.810000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 31.810000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 33.810000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 35.810000f)),}, null),
        //4-10
            new RoadBlock(
		new Items[] {
				new Items(ItemKind.magnet, new Vector3(1.600000f, 0.000000f, 26.980000f))},
		new ObsInfo[] {
				new ObsInfo(ObsKind.runtroupe, new Vector3(1.600000f, 0.000000f, 10.820000f)),
				new ObsInfo(ObsKind.runtroupe, new Vector3(1.600000f, 0.000000f, 7.620000f)),
				new ObsInfo(ObsKind.runtroupe, new Vector3(0.000000f, 0.000000f, 10.820000f)),
				new ObsInfo(ObsKind.runtroupe, new Vector3(0.000000f, 0.000000f, 7.620000f)),
				new ObsInfo(ObsKind.flagPole3, new Vector3(0.000000f, 0.000000f, 32.800000f)),
				new ObsInfo(ObsKind.ball, new Vector3(-1.600000f, 0.000000f, 17.460000f)),
				new ObsInfo(ObsKind.ball, new Vector3(1.600000f, 0.000000f, 47.390000f)),
				new ObsInfo(ObsKind.ball, new Vector3(-1.600000f, 0.000000f, 31.790000f)),}, null,
		new Coins[] {
				new Coins(new Vector3(0.000000f, 0.500000f, 20.190000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 26.190000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 24.190000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 22.190000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 28.190000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 30.190000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 41.940000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 35.940000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 43.940000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 39.940000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 37.940000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 45.940000f)),}, null),
        // 4-11
            new RoadBlock(
		new Items[] {
				new Items(ItemKind.shield, new Vector3(-1.600000f, 0.000000f, 27.260000f))},
		new ObsInfo[] {
				new ObsInfo(ObsKind.runtroupe, new Vector3(-1.600000f, 0.000000f, 6.600000f)),
				new ObsInfo(ObsKind.runtroupe, new Vector3(-1.600000f, 0.000000f, 9.800000f)),
				new ObsInfo(ObsKind.runstand, new Vector3(1.600000f, 0.000000f, 22.640000f)),
				new ObsInfo(ObsKind.runstand, new Vector3(1.600000f, 0.000000f, 46.460000f)),
				new ObsInfo(ObsKind.runstand, new Vector3(1.600000f, 0.000000f, 25.840000f)),
				new ObsInfo(ObsKind.ball, new Vector3(-1.600000f, 0.000000f, 44.000000f)),
				new ObsInfo(ObsKind.ball, new Vector3(-1.600000f, 0.000000f, 35.260000f)),
				new ObsInfo(ObsKind.flagPole4, new Vector3(0.000000f, 0.000000f, 26.960000f)),}, null,
		new Coins[] {
				new Coins(new Vector3(0.000000f, 0.500000f, 15.020000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 13.020000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 17.020000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 26.320000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 11.020000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 22.320000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 30.320000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 24.320000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 28.320000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 40.170000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 34.170000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 38.170000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 42.170000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 36.170000f)),}, null),
	};

	//flycoin
    public static RoadBlock[] FlyCoin =
	{
		//flycoin 1
		    new RoadBlock(null, null,  null,
		new Coins[] {
				new Coins(new Vector3(0.000000f, 0.500000f, 2.346461f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 4.346461f)),	new Coins(new Vector3(-0.800000f, 0.500000f, 5.360000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 6.490000f)),
				new Coins(new Vector3(-1.600000f, 0.500000f, 10.490000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 8.490000f)),	new Coins(new Vector3(-0.800000f, 0.500000f, 11.850000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 15.030000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 17.030000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 13.030000f)),
				new Coins(new Vector3(-0.800000f, 0.500000f, 18.390000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 23.530000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 19.530000f)),
				new Coins(new Vector3(-1.600000f, 0.500000f, 21.530000f)),	new Coins(new Vector3(-0.800000f, 0.500000f, 24.920000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 28.080000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 30.080000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 26.080000f)),	new Coins(new Vector3(0.800000f, 0.500000f, 31.460000f)),
				new Coins(new Vector3(1.600000f, 0.500000f, 38.610000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 34.610000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 36.610000f)),
				new Coins(new Vector3(1.600000f, 0.500000f, 32.610000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 41.110000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 43.270000f)),
				new Coins(new Vector3(1.600000f, 0.500000f, 45.400000f)),	new Coins(new Vector3(0.800000f, 0.500000f, 46.660000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 47.860000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 49.860000f)),}, null),

		//flycoin 2
		        new RoadBlock(null, null,  null,
		new Coins[] {
				new Coins(new Vector3(-1.600000f, 0.500000f, 6.346461f)),
				new Coins(new Vector3(-1.600000f, 0.500000f, 4.346461f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 2.346461f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 8.346460f)),
				new Coins(new Vector3(-0.800000f, 0.500000f, 9.540000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 14.530000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 16.530000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 10.530000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 12.530000f)),	new Coins(new Vector3(0.800000f, 0.500000f, 17.810000f)),
				new Coins(new Vector3(1.600000f, 0.500000f, 24.910000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 18.910000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 20.910000f)),
				new Coins(new Vector3(1.600000f, 0.500000f, 22.910000f)),	new Coins(new Vector3(0.800000f, 0.500000f, 26.260000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 31.300000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 29.300000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 27.300000f)),	new Coins(new Vector3(0.800000f, 0.500000f, 32.730000f)),
				new Coins(new Vector3(1.600000f, 0.500000f, 38.020000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 36.020000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 34.020000f)),
				new Coins(new Vector3(1.600000f, 0.500000f, 40.020000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 42.020000f)),	new Coins(new Vector3(0.800000f, 0.500000f, 43.650000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 44.710000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 48.710000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 50.710000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 46.710000f)),}, null),

		//flycoin 3
		        new RoadBlock(null, null,  null,
		new Coins[] {
				new Coins(new Vector3(-1.600000f, 0.500000f, 4.368861f)),
				new Coins(new Vector3(-1.600000f, 0.500000f, 2.368861f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 6.368861f)),	new Coins(new Vector3(-0.800000f, 0.500000f, 7.400000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 8.380000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 12.380000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 10.380000f)),
				new Coins(new Vector3(0.800000f, 0.500000f, 13.500000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 18.500000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 20.500000f)),
				new Coins(new Vector3(1.600000f, 0.500000f, 16.500000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 14.500000f)),	new Coins(new Vector3(0.800000f, 0.500000f, 21.850000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 28.850000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 22.850000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 26.850000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 24.850000f)),	new Coins(new Vector3(0.800000f, 0.500000f, 30.100000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 31.150000f)),
				new Coins(new Vector3(1.600000f, 0.500000f, 33.150000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 35.150000f)),	new Coins(new Vector3(0.800000f, 0.500000f, 36.180000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 39.250000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 45.250000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 47.250000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 43.250000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 37.250000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 41.250000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 49.250000f)),}, null),

		//flycoin 4
		        new RoadBlock(null, null,  null,
		new Coins[] {
				new Coins(new Vector3(-1.600000f, 0.500000f, 14.405940f)),
				new Coins(new Vector3(-1.600000f, 0.500000f, 4.405936f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 10.405940f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 12.405940f)),
				new Coins(new Vector3(-1.600000f, 0.500000f, 16.405940f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 6.405936f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 8.405935f)),
				new Coins(new Vector3(-0.800000f, 0.500000f, 18.100000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 21.500000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 25.500000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 29.500000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 19.500000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 23.500000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 27.500000f)),	new Coins(new Vector3(0.800000f, 0.500000f, 31.200000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 42.500000f)),
				new Coins(new Vector3(1.600000f, 0.500000f, 46.500000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 48.500000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 34.500000f)),
				new Coins(new Vector3(1.600000f, 0.500000f, 38.500000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 36.500000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 50.500000f)),
				new Coins(new Vector3(1.600000f, 0.500000f, 44.500000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 40.500000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 32.500000f)),
				new Coins(new Vector3(0.800000f, 0.500000f, 51.920000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 53.320000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 55.320000f)),}, null),
		//flycoin5
		        new RoadBlock(null, null,  null,
		new Coins[] {
				new Coins(new Vector3(0.000000f, 0.500000f, 2.800000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, -1.200000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 0.800000f)),	new Coins(new Vector3(0.800000f, 0.500000f, 3.900000f)),
				new Coins(new Vector3(1.600000f, 0.500000f, 8.960000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 6.960000f)),	new Coins(new Vector3(1.600000f, 0.500000f, 4.960000f)),
				new Coins(new Vector3(0.800000f, 0.500000f, 10.070000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 13.290000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 11.290000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 15.290000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 17.290000f)),	new Coins(new Vector3(-0.800000f, 0.500000f, 18.660000f)),
				new Coins(new Vector3(-1.600000f, 0.500000f, 23.930000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 21.930000f)),	new Coins(new Vector3(-1.600000f, 0.500000f, 19.930000f)),
				new Coins(new Vector3(-0.800000f, 0.500000f, 25.270000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 40.420000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 44.420000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 46.420000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 34.420000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 38.420000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 32.420000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 28.420000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 26.420000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 36.420000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 42.420000f)),	new Coins(new Vector3(0.000000f, 0.500000f, 30.420000f)),
				new Coins(new Vector3(0.000000f, 0.500000f, 48.420000f)),}, null),
    };

}