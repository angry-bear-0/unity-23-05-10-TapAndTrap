using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAniBase : MonoBehaviour 
{

	protected bool mInitedHome = false;
    protected bool mInitedGame = false;
	//Player Variables
    static public Animation	mAniPet;//animator of Player
	protected Player		mPlayer = null;
	//hero variables
    static public Animation	mAniHero;
	protected  Transform	mTrHero = null;
    protected bool			mIsHeroOnPetRoot = true;

    
    protected ActionKind mCurAction = ActionKind.none;
    protected ActionKind mPrevAction = ActionKind.none;
    
    
    
	// Use this for initialization
	void Start () 
    {
		
	}
	
	// Update is called once per frame
	void Update () 
    {

	}
    protected void changeHeroParent(bool _isOnPetRoot)
    {
        if (!_isOnPetRoot)
        {
            if (mIsHeroOnPetRoot)
            {
                mIsHeroOnPetRoot = false;
                mTrHero.parent = GameMgr.player._PetPelvise;
            }
        }
        else
        {
            if (!mIsHeroOnPetRoot)
            {
                mIsHeroOnPetRoot = true;
				mTrHero.parent = GameMgr.player._PetRoot;
            }
        }
        mTrHero.localPosition = Vector3.zero;
        mTrHero.localRotation = Quaternion.identity;
    }
}
