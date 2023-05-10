using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvtBase : MonoBehaviour
{

	[HideInInspector]public GameMgr mGameMgr;
	protected Player	mPlayer	=null;
	protected Tracker	mTracker	=null;
	// Use this for initialization
	
	public void Active(bool _needLoading, bool _needPlayer, bool _needUI3DCamera, bool _needBackground)
	{
		mGameMgr = GameMgr.inst;
		Active3D();
		mPlayer		= GameMgr.player;
		mTracker	= GameMgr.tracker;
    }
	virtual protected void Active3D()
	{

	}
  
	public void Deactive(bool _needPlayer, bool _needBackground)
	{
	}
	virtual protected void Deactive3D()
	{
	}
	virtual protected void DeactivePlayer(bool _needDel)
	{
// 		if (_needDel)
// 		{
// 			Destroy(mAvtMgr.mCsPlayer);
// 		}
	}
	virtual protected void DeactiveHero(bool _needDel)
	{
		if (_needDel)
		{
			Destroy(GameMgr.hero);
		}
	}
	virtual protected void DeactiveUI(GameObject _obj)
	{
		Destroy(_obj);
	}
	
}
