using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadRes : MonoBehaviour
{
	public static RoadRes	MInst;
	static public RoadRes	instance { get { return MInst; } }

	public	Transform[]		Roads;

	public  Transform[]		CartStand;
    public	Transform[]		CartTroupe;
    public	Transform[]		CartLadder;
	public	Transform[]		RunStand;
	public	Transform[]		RuntTroupe;
	public  Transform[]		HurdleUp;
    public	Transform[]		HurdleDown;
    public	Transform[]		HurdleMiddle;
	public  Transform[]		FlagPole2;
	public	Transform[]		FlagPole3;
	public	Transform[]		FlagPole4;
	public  Transform[]		SwingBob;
	public  Transform[]		Coins;
	public  Transform[]		Item;
	public	Transform[]		Balloon;
	public	Transform[]		Ball;
	[HideInInspector]
	private int[]			mObsIdx;

	[HideInInspector]
	public Transform[][]	Obs			= new Transform[(int)ObsKind.size][];

	private int				mRoadIdx= 0;
    private GameObject		mGoPlayer = null;
	void Awake()
	{
		MInst = this;
		
	}
	public void InitHome()
	{
		mRoadIdx	= 0;
		Vector3		vPos = new Vector3();
		for(int nIdx = 0; nIdx < Roads.Length; nIdx++ )
		{
			vPos.z = nIdx * 100f + 53.7f;
			Roads[nIdx].position = vPos;
        }

		for (int nIdx = 0; nIdx < (int)ObsKind.size; nIdx++)
		{
			mObsIdx[nIdx] = 0;
		}
    }

	public void InitGame()
	{
		mObsIdx = new int[(int)ObsKind.size];
		Obs[(int)ObsKind.cartstand]		= CartStand;
		Obs[(int)ObsKind.carttroupe]	= CartTroupe;//Tanks;
		Obs[(int)ObsKind.runtroupe]		= RuntTroupe;//HurdleUp;
		Obs[(int)ObsKind.runstand]		= RunStand;//FlagPole;
		Obs[(int)ObsKind.cartladder]	= CartLadder;//SwingBob;
		Obs[(int)ObsKind.hurdleup]		= HurdleUp;
		Obs[(int)ObsKind.hurdlemiddle]	= HurdleMiddle;
		Obs[(int)ObsKind.hurdledown]	= HurdleDown;
		Obs[(int)ObsKind.balloon]		= Balloon;
		Obs[(int)ObsKind.ball]			= Ball;
		Obs[(int)ObsKind.flagPole2]		= FlagPole2;
		Obs[(int)ObsKind.flagPole3]		= FlagPole3;
		Obs[(int)ObsKind.flagPole4]		= FlagPole4;
		Obs[(int)ObsKind.swingBob]		= SwingBob;
		Obs[(int)ObsKind.coin]			= Coins;
		Obs[(int)ObsKind.item]			= Item;
		for (int nIdx = 0; nIdx < (int)ObsKind.size; nIdx++)
		{
			mObsIdx[nIdx] = -1;
		}
	}
	// Use this for initialization
	void start()
	{
		MInst = this;
	}
	// Update is called once per frame
	void Update()
	{
		if(!mGoPlayer)
			mGoPlayer = GameMgr.player.gameObject;

	}
	public static Transform GetRoad()
	{
		if (MInst != null)
			return MInst.getRoad();
		else
			return null;
	}
	Transform getRoad()
	{
		Transform road = Roads[mRoadIdx];
		mRoadIdx = (mRoadIdx + 1) % Roads.Length;
		return road;
	}

	public static Transform GetObs(ObsKind _obskind)
	{
		if (MInst != null)
			return MInst.getObs(_obskind);
		else return null;
	}
	Transform getObs(ObsKind _kind)
	{

		for (int i = 0; i < Obs[(int)_kind].Length; i++)
		{
			if (Obs[(int)_kind][i].position.z < (mGoPlayer.transform.position.z - 5)/*Obs[(int)_kind][i].localPosition == Vector3.zero*/)
			{
				return Obs[(int)_kind][i];
			}
		}
		//print(_kind.ToString() +  "No Enough");
		return null;
	}

	public static Transform GetItem(ItemKind _kind)
	{
		if (MInst != null)
			return MInst.getItem(_kind);
		else return null;
	}
	Transform getItem(ItemKind _kind)
	{
        //int nkind = (int)_kind - 1;
		Transform item = null;
		for(int i = 0; i < Obs[(int)ObsKind.item].Length; i++)
		{
			if (Obs[(int)ObsKind.item][i].position.z < mGoPlayer.transform.position.z - 5/*Obs[(int)ObsKind.item][i].localPosition == Vector3.zero*/)
			{
				if(_kind == ItemKind.fly && Obs[(int)ObsKind.item][i].gameObject.name == "pfItmFly")
					return Obs[(int)ObsKind.item][i];
				if (_kind == ItemKind.balloon && Obs[(int)ObsKind.item][i].gameObject.name == "pfItmBalloon")
					return Obs[(int)ObsKind.item][i];
				if (_kind == ItemKind.magnet && Obs[(int)ObsKind.item][i].gameObject.name == "pfItmMagnet")
					return Obs[(int)ObsKind.item][i];
				if (_kind == ItemKind.shield && Obs[(int)ObsKind.item][i].gameObject.name == "pfItmShield")
					return Obs[(int)ObsKind.item][i];
				if (_kind == ItemKind.spring && Obs[(int)ObsKind.item][i].gameObject.name == "pfItmSpring")
					return Obs[(int)ObsKind.item][i];
			}

		}
		//print("No Enough" + _kind);
		return item;
	}

	public static Transform GetCoin(int _rbcoinCnt)
	{
		if (MInst != null)
			return MInst.getCoin(_rbcoinCnt);
		else
			return null;
	}

	Transform getCoin(int _rbcoinCnt)
	{
		for (int i = 0; i < Coins.Length; i++)
		{
			if (Coins[i].position.z < mGoPlayer.transform.position.z - 5/* Coins[i].localPosition == Vector3.zero*/)
			{
				Coin coin = Coins[i].GetComponent<Coin>();
				coin.reset();
				coin.Init(i, _rbcoinCnt);
				return Coins[i];
			}
		}
		//print("No Coins");
		return Coins[0];
	}
}
