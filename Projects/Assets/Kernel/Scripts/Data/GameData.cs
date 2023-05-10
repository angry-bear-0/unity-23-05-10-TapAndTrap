using UnityEngine;
using System.Collections.Generic;
public class GD
{
	private static bool		bLoaded			= false;

	//Initial
	public static int		dtVer				= 100;			
	public static int		dtLangIdx			= -1;			
	public static bool		dtTutorialed		= false;		
	public static float		dtBgmVolum			= 1;			
	public static float		dtSfxVolum			= 1;

	//shop & item
	public static int		dtCoins             = 500000;
	public static int		dtGems              = 10000;
	public static int		dtFoodCnt			= 10;			
	public static int		dtSuperFoodCnt		= 2;
	public static int		dtShieldCnt			= 1;

	public static int		dtScoreBoosterCnt	= 0;
	public static int		dtHeadSartCnt		= 0;

	public static int       dtLevel             = 1;
	public static int       dtScore             = 0;
	public static int       dtPetHp             = 13;

	public static int		petCondition		= 0;
	public static float		petMultiplier		= 0;

	public static float		speed				= 0;			
	public static int		dist				= 0;			
	public static int		newCheers			= 0;			
	
	public static bool		usingShield			= false;
	public static int		multiplier			= 1;

	public static int		maxMultiplierPoint	= MD.iniMaxMultiplierPoint;			
	public static int		curMultiplierPoint	= 0;	
	public static int		earnedCoin			= 0;
	public static int		earnedScore			= 0;			
	
	public static bool		flying					= false;		
	public static bool		usingMagnet				= false;		
	public static bool		collided				= false;		
						
	public static int		rebirthCnt				= 0;			
	public static int		needGemToRebirth		= 1;
	public static bool		rebirthing				= false;		
	
	public static bool		dead;							

	public static List<PetInfo>				dtPetInfos		= new List<PetInfo>();
	public static int						dtPetIdx		= 0;

	public static List<StuntInfo>			dtStuntInfos	= new List<StuntInfo>();
	public static int[]						dtStuntIdxs		= new int[] {0, -1, -1};

	public static List<HeroInfo>			dtHeroInfos		= new List<HeroInfo>();
	public static int						dtHeroIdx		= 0;

	public static ShopUpgradeFly			dtUpgradeFly			= new ShopUpgradeFly();
	public static ShopUpgradeMagnet			dtUpgradeMagnet			= new ShopUpgradeMagnet();
	public static ShopUpgradeShield			dtUpgradeShield			= new ShopUpgradeShield();
	public static ShopUpgradeShieldCT		dtUpgradeShieldCT		= new ShopUpgradeShieldCT();
	public static ShopUpgradeScoreBooster	dtUpgradeScoreBooster	= new ShopUpgradeScoreBooster();
	public static ShopUpgradeBalloon		dtUpgradeBalloon		= new ShopUpgradeBalloon();
	public static ShopUpgradeDoubleCoin		dtUpgradeDoubleCoin		= new ShopUpgradeDoubleCoin();
	
	public static ShopUpgrade[]				shopUpgradeInfos		= new ShopUpgrade[] {dtUpgradeFly, dtUpgradeMagnet, dtUpgradeShield, dtUpgradeShieldCT, dtUpgradeScoreBooster, dtUpgradeBalloon, dtUpgradeDoubleCoin};

	public static int		targetHp { get {return GD.dtPetInfos[GD.dtPetIdx].data.hp; } }

	public static void Load()
	{
		if(bLoaded)
			return;
		bLoaded = true;

		LicenseKey.Init();
		ObscuredPrefs.SetNewCryptoKey(LicenseKey.GetDeviceID("34210458329"));

		dtVer               = ObscuredPrefs.GetInt("dtVer", dtVer);
		dtLangIdx           = ObscuredPrefs.GetInt("dtLangIdx",  dtLangIdx);
		dtTutorialed        = ObscuredPrefs.GetBool("dtTutorialed",  dtTutorialed);
		dtBgmVolum          = ObscuredPrefs.GetFloat("dtBgmVolum",  dtBgmVolum);
		dtSfxVolum          = ObscuredPrefs.GetFloat("dtSfxVolum",  dtSfxVolum);
		
		dtCoins             = ObscuredPrefs.GetInt("dtCoins",  dtCoins);
		dtGems              = ObscuredPrefs.GetInt("dtGems",  dtGems);
		dtFoodCnt           = ObscuredPrefs.GetInt("dtFoodCnt",  dtFoodCnt);
		dtSuperFoodCnt      = ObscuredPrefs.GetInt("dtSuperFoodCnt",  dtSuperFoodCnt);
		dtShieldCnt         = ObscuredPrefs.GetInt("dtShieldCnt",  dtShieldCnt);
		dtScoreBoosterCnt   = ObscuredPrefs.GetInt("dtScoreBoosterCnt",  dtScoreBoosterCnt);
		dtHeadSartCnt       = ObscuredPrefs.GetInt("dtHeadSartCnt",  dtHeadSartCnt);
		
		dtLevel             = ObscuredPrefs.GetInt("dtLevel",  dtLevel);
		dtScore             = ObscuredPrefs.GetInt("dtScore",  dtScore);
		dtPetHp             = ObscuredPrefs.GetInt("dtPetHp",  dtPetHp);

		foreach(StuntData s in MD.stunt)
		{
			StuntInfo si = new StuntInfo(s);
			si.Load();
			dtStuntInfos.Add(si);
		}
		for(int i = 0; i <= MD.maxDifficulty; i ++)
			dtStuntIdxs[i] = ObscuredPrefs.GetInt("stuntIdx" + i.ToString(), dtStuntIdxs[i]);

		foreach(PetData p in MD.pet)
		{
			PetInfo pi = new PetInfo(p);
			pi.Load();
			dtPetInfos.Add(pi);
		}
		dtPetIdx = ObscuredPrefs.GetInt("petIdx", dtPetIdx);

		foreach(AvatarData a in MD.avatar)
		{
			HeroInfo ai = new HeroInfo(a);
			ai.Load();
			dtHeroInfos.Add(ai);
		}
		dtHeroIdx = ObscuredPrefs.GetInt("characterIdx", dtHeroIdx);

		foreach(ShopUpgrade su in shopUpgradeInfos)
			su.Load();

		AwardMgr.Init();
		MissionMgr.Init();
		AwardMgr.Load();
		MissionMgr.Load();
	}
	public static void Save()
	{
		if (!bLoaded)
			return;

		ObscuredPrefs.SetInt("dtVer", dtVer);
		ObscuredPrefs.SetInt("dtLangIdx", dtLangIdx);
		ObscuredPrefs.SetBool("dtTutorialed", dtTutorialed);
		ObscuredPrefs.SetFloat("dtBgmVolum", dtBgmVolum);
		ObscuredPrefs.SetFloat("dtSfxVolum", dtSfxVolum);

		ObscuredPrefs.SetInt("dtCoins", dtCoins);
		ObscuredPrefs.SetInt("dtGems", dtGems);
		ObscuredPrefs.SetInt("dtFoodCnt", dtFoodCnt);
		ObscuredPrefs.SetInt("dtSuperFoodCnt", dtSuperFoodCnt);
		ObscuredPrefs.SetInt("dtShieldCnt", dtShieldCnt);
		ObscuredPrefs.SetInt("dtScoreBoosterCnt", dtScoreBoosterCnt);
		ObscuredPrefs.SetInt("dtHeadSartCnt", dtHeadSartCnt);

		ObscuredPrefs.SetInt("dtLevel", dtLevel);
		ObscuredPrefs.SetInt("dtScore", dtScore);
		ObscuredPrefs.SetInt("dtPetHp", dtPetHp);

		foreach(StuntInfo s in dtStuntInfos)
			s.Save();

		for(int i = 0; i <= MD.maxDifficulty; i++)
			ObscuredPrefs.SetInt("stuntIdx" + i.ToString(), dtStuntIdxs[i]);

		foreach(PetInfo p in dtPetInfos)
			p.Save();
		ObscuredPrefs.SetInt("petIdx", dtPetIdx);

		foreach(HeroInfo a in dtHeroInfos)
			a.Save();
		ObscuredPrefs.SetInt("avatarIdx", dtHeroIdx);

		foreach(ShopUpgrade su in shopUpgradeInfos)
			su.Save();

		AwardMgr.Save();
		MissionMgr.Save();

		ObscuredPrefs.Save();
	}

	public static void InitGame()
	{
		earnedCoin   = 0;
		earnedScore  = 0;
		multiplier   = GD.dtPetInfos[GD.dtPetIdx].data.baseMulti + GD.dtLevel;
		curMultiplierPoint = 0;
		maxMultiplierPoint = MD.iniMaxMultiplierPoint;

		dtPetHp -= 10;
		GD.Save();
	}
	public static int GetJumpSkillIdx(float _dblUpTIme)
	{
		for(int i = GD.dtStuntIdxs.Length-1; i >= 0; i--)
		{
			if(GD.dtStuntIdxs[i] == -1)
				continue;
			if(_dblUpTIme >= GD.dtStuntInfos[GD.dtStuntIdxs[i]].data.inputTm)
				return GD.dtStuntIdxs[i];
		}
		return -1;
	}

}
