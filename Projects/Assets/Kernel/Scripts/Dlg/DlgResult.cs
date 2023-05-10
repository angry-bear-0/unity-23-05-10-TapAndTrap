using UnityEngine;
using System.Collections;

public class DlgResult : DlgBase
{
	[SerializeField] protected	Transform		_Pivot3D;
	[SerializeField] protected	UILabel			_TxtGem;
	[SerializeField] protected	TweenNumberText	_TxtCoin;
	[SerializeField] protected	UILabel			_TxtDist;
	[SerializeField] protected	UILabel			_TxtMultiplier;
	[SerializeField] protected	UILabel			_TxtScore;
	[SerializeField] protected	TweenNumberText	_TxtAddCoin;

	protected GameObject mGoPet		= null;
	protected GameObject mGoHero	= null;

	protected Animation mAniPet		= null;
	protected Animation mAniHero	= null;

	public static void OpenDlg()
    {
        GameObject obj		= Instantiate(Resources.Load("Prefabs/Dlg/pfDlgResult")) as GameObject;
        Transform trans		= obj.GetComponent<Transform>();
        trans.parent		= GameObject.Find("CameraUI").GetComponent<Transform>();

        trans.localPosition = Vector3.zero;
        trans.localRotation = Quaternion.identity;
        trans.localScale	= Vector3.one;

        NGUITools.AdjustDepth(obj, depth);
        DlgResult script = obj.GetComponent<DlgResult>();
        script.Init();
    }
    void Init()
    {
        onOpen();
		_TxtGem.text		= GD.dtGems.ToString();
		_TxtDist.text		= NGUIText.SpaceDigitString((int) GD.dist) + "m";
		_TxtMultiplier.text	= "X" + GD.multiplier.ToString();
		_TxtScore.text		= GD.earnedCoin.ToString();
		_TxtCoin.SetNumber(GD.dtCoins, 0);
		_TxtAddCoin.SetNumber(0, 0);
		
		if (GD.earnedCoin > 0)
		{
			GD.dtCoins += GD.earnedCoin;
			_TxtCoin.SetNumber(GD.dtCoins, 3);
			_TxtAddCoin.SetNumber(GD.earnedCoin, 3);
			Util.PlaySound("sfxDropCoin");
		}

		if (GD.dtScore < GD.earnedScore)
		{
			//KJH TODO: Update scoreboard.
		}
		update3DModels();
		if(MissionMgr.Completed())
		{
			MissionMgr.DoNextMissionSet();
			GD.dtLevel++;
			PlayerEventMgr.inst.OnEvent(PlayerEventKind.missionSet, 1);
			DlgOkCancel.OpenDlg(null, null, Lang.Get("uiMsgLevelup"));
		}
	}


	private void update3DModels()
	{
		if(mGoPet != null)
			Destroy(mGoPet);

		if(mGoHero != null)
			Destroy(mGoHero);

		mGoPet = Instantiate(Resources.Load("Prefabs/Character/Pet/petSimple")) as GameObject;
		mGoPet.GetComponent<Player>().enabled = false;
		mGoPet.transform.parent          = _Pivot3D;
		mGoPet.transform.localPosition   = Vector3.zero;
		mGoPet.transform.localRotation   = Quaternion.identity;
		mGoPet.transform.localScale      = Vector3.one;
		mGoPet.transform.GetChild(0).GetComponent<SkinnedMeshRenderer>().material.mainTexture = GameMgr.inst._PetTx[GD.dtPetIdx];
		mGoPet.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material.mainTexture = GameMgr.inst._PetTx[GD.dtPetIdx];
		mAniPet = mGoPet.GetComponent<Animation>();

		//create avatar
		mGoHero   = Instantiate(Resources.Load("Prefabs/Character/Hero/Hero" + (GD.dtHeroIdx).ToString())) as GameObject;
		mGoHero.transform.parent         = mGoPet.GetComponent<Player>()._PetPelvise;
		mGoHero.transform.localPosition  = Vector3.zero;
		mGoHero.transform.localRotation  = Quaternion.identity;
		mGoHero.transform.localScale     = Vector3.one;
		for(int i = 0; i < GD.dtHeroInfos[GD.dtHeroIdx].data.clothes.Length; i++)
			mGoHero.transform.GetChild(i).gameObject.SetActive(i == GD.dtHeroInfos[GD.dtHeroIdx].clothIdx);

		mAniHero = mGoHero.GetComponent<Animation>();
	}
	protected new void Update()
	{
		base.Update();
		if(mAniHero == null)
			return;

		if(!mAniPet.isPlaying)
		{
			mAniPet.Play("petRun");

			if (!mAniHero.isPlaying)
			{
				if (Util.IsInPercent(20))
					mAniHero.CrossFade("heroRunSkill" + Util.IntRandom(1,4).ToString(), 0.1f);
				else
					mAniHero.CrossFade("heroRun", 0.1f);
			}
		}
	}

	protected override void onClosedDlg(GameObject _closeBtn)
	{
		GameMgr.inst.GoAvtHome();
	}
}

