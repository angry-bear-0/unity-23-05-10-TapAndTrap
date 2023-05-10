using UnityEngine;
using System;
public enum JumpKind
{
	none,
	normal,
	spring,
	stunt,
	fly
}
public enum GameState
{
	home,
	play,
	dead,
	pause,
	none
}
public enum LaneIdx
{
	left,
	center,
	right,
	size
}

public enum ActionKind
{
	none,

	run,
	land,
	fall,
	stumble,
	drop,
	frighten,

	//input animation
	moveRight,
	moveLeft,
	jump,
	lower,
	saluteLeft,
	saluteRight,
	stuntHight,
	stuntGood,
	stuntNormal,

	//item animation
	safeGuard,
	pickLeft,
	pickRight,
	fly,
	spring,

	//home animation
	breath,
	rest,
	petLie,
	petSit,
	petStand,
	petLeg,
	petNeck,
	petBody,
	petEat,
	//09.29
	heroAppear,

	//other animation
	mount,
	flyDown,

	strokeNeck,
	strokeBody,
	strokeLeg,

	stop,
	cnt,
}

public class MD
{							
	public static DateTime BASE_TIME	= new DateTime(2021, 1, 1);

	public static float		playerNormalHeight	= 1f;
	public static float		playerLowHeight		= 0.5f;				
	public static bool		plrJackFree			= true;

	public static int		hpInc				= 8;				
	public static int		hpIncTm				= 8;				
	public static int		hpDec				= 10;				
	public static int		petConIdx;								
	public static int		petConPer;								
	public static int		petConHp;								
	public static int		petHpIdx;								
	public static int		petTouchInc			= 3;				
	public static int		petFeedInc			= 5;				
	public static int		petSprFeedInc;							
	public static float		petHpIncTm			= 180f;				
	public static int		petConditionGood	= 2;				
	public static int		petConditionNormal	= 1;				
	public static int		petConditionBad		= 0;				
	public static bool		petFree				= true;

	public static float		tracTm				= 5.0f;				
											   
	public static int		unitSco				= 1000;				
	public static int		ScoBoosterPrc		= 3000;				

	public static int		coinSack			= 1;				
	public static int		coinBag				= 10;				
	public static int		coinChest			= 100;				

	public static int		runCycle			= 50;				
	public static int[]		dailyGift			= { 500, 750, 1500, 2, 1 };     

	public static int		maxDifficulty		= 2;	
	public static int		maxClothes			= 3;

	public static int		iniMaxMultiplierPoint	= 20;
	public static int		stepMaxMultiplierPoint	= 5;
	public static int Reached(int n)
	{
		return (int)(Mathf.Pow((MD.unitSco * n), 2.5f));
      
	}

	public static int		getSprExp			= 100;				

	public static int		feedPrc				= 100;				
	public static int		sprFeedPrc			= 1;				
	public static int		hdStPrc				= 2000;				
	public static int		mstBoxPrc			= 500;				
														
	////mission
	public static int		_mssPassCnt			= 0;				
	public static int		mssPassPrc(int _mssPassCnt)				
												{ return (int)(1900 + _mssPassCnt * 100); }       
	public static int		curio				= 4;				   

	public static bool stuntFree = true;
				
    public static float     accel				= 0.05f;
	public static float     maxSpeed			= 18f;
	public static float		jumpNormalTm		= 1.333f;			
	public static float		jumpSkillTm			= 1.708f;
	public static float		jumpFlyTm			= 1.167f;			
	public static float		jumpSpringTm		= 1.708f;			
 	public static float		springH				= 8f;              
	public static float		flyH				= 7f;	            
	public static float		jumpH				= 1.5f;				
	public static float		leapH				= 3f;				
												
	public static float		conicRaceRadius		= 190.986f;			
	public static float		laneWidth			= 1.6f;				
	public static float		conicRaceLen		= 1200f;			
	public static int		roadSegCnt			= 6;				
	public static float		roadSegAngle		= 30;				
	public static float		roadSegLen			= 100f;				
    public static float     obsSegLen           = 50f;				
	public static float		obsSegAngle			= 15f;				
    public static int		roadSetLen          = 12;               
    public static int		roadLvCnt           = 5;                
	public static float		gravity				= -9.81f;

	public static StuntData[] stunt =			{
													new StuntData("V-Fly",          "heroJumpSkill1",   new PriceCoin(0),		1, 3, 0.25f, 0),
													new StuntData("Cheerleader",    "heroJumpSkill2",   new PriceCoin(500),		2, 3, 0.25f, 0),
													new StuntData("Hip-hop",        "heroJumpSkill3",   new PriceCoin(1000),	3, 3, 0.25f, 0),
													new StuntData("Hi-Five",        "heroJumpSkill4",	new PriceCoin(2000),	5, 3, 0.25f, 0),
													new StuntData("Come-on",        "heroJumpSkill5",   new PriceCoin(4000),	7, 4, 0.20f, 1),
													new StuntData("U-Fly",          "heroJumpSkill6",   new PriceGold(40),		9, 4, 0.20f, 1),
													new StuntData("Twinkle",        "heroJumpSkill7",   new PriceCoin(6000),	12, 4, 0.20f, 1),
													new StuntData("V-Frontend",     "heroJumpSkill8",   new PriceCoin(7000),	15, 4, 0.20f, 1),
													new StuntData("I wanna Fly",    "heroJumpSkill9",   new PriceCoin(8000),	18, 5, 0.15f, 2),
													new StuntData("What a world!",  "heroJumpSkill10",  new PriceGold(90),		25, 5, 0.15f, 2),
													new StuntData("You see me?",    "heroJumpSkill11",  new PriceCoin(10000),	32, 5, 0.15f, 2),
													new StuntData("I'm KKKing",     "heroJumpSkill12",  new PriceCoin(12000),	40, 5, 0.15f, 2)
												};
	public static PetData[] pet =				{
													new PetData(200, 1,     "Manie",	0,	new PriceCoin(0)),
													new PetData(220, 3,     "Dalmien",	1,	new PriceCoin(4500)),
													new PetData(280, 7,     "Spirit",   3,	new PriceCoin(19000)),
													new PetData(320, 10,    "Royal",    5,	new PriceGold(19)),
													new PetData(400, 24,    "Zeonbra",  8,	new PriceGold(99)),
												};
	public static AvatarData[] avatar =			{
													new AvatarData("Jack",		1.17f,	new ClothData[] {	new ClothData(new PriceCoin(0),		"18_Character0-0" ),
																											new ClothData(new PriceCoin(10),	"19_Character0-1" ),
																											new ClothData(new PriceCoin(20),	"20_Character0-2" ) }),
													new AvatarData("Harumi",	1.22f,	new ClothData[] {	new ClothData(new PriceCoin(30),	"21_Character1-0" ),
																											new ClothData(new PriceGold(4),		"22_Character1-1" ) }),
													new AvatarData("Conan Reed",1.15f,	new ClothData[] {	new ClothData(new PriceCoin(50),	"23_Character2-0" ),
																											new ClothData(new PriceCoin(60),	"24_Character2-1" ),
																											new ClothData(new PriceCoin(70),	"25_Character2-2" ) }),
													new AvatarData("Angelin",	1.20f,	new ClothData[] {	new ClothData(new PriceGold(8),		"26_Character3-0" ),
																											new ClothData(new PriceCoin(90),	"27_Character3-1" ),
																											new ClothData(new PriceCoin(100),	"28_Character3-2" ) }),
													new AvatarData("Sunny",		0.95f,	new ClothData[] {	new ClothData(new PriceCoin(110),	"29_Character4-0" ),
																											new ClothData(new PriceCoin(120),	"30_Character4-1" ) }),
													new AvatarData("Liu",		1.00f,	new ClothData[] {	new ClothData(new PriceCoin(130),	"31_Character5-0" ),
																											new ClothData(new PriceCoin(140),	"32_Character5-1" ) }),
													new AvatarData("Nsue",		0.85f,	new ClothData[] {	new ClothData(new PriceCoin(150),	"33_Character6-0" ),
																											new ClothData(new PriceGold(16),	"34_Character6-1" ),
																											new ClothData(new PriceCoin(170),	"35_Character6-2" ) }),
													new AvatarData("Merche",	0.99f,	new ClothData[] {	new ClothData(new PriceCoin(180),	"36_Character7-0" ),
																											new ClothData(new PriceCoin(190),	"37_Character7-1" ),
																											new ClothData(new PriceCoin(200),   "38_Character7-2" ) }),
													new AvatarData("Nancy",     1.14f,	new ClothData[] {   new ClothData(new PriceCoin(210),	"39_Character8-0" ),
																											new ClothData(new PriceGold(22),	"40_Character8-1" ) }),
													new AvatarData("Julie",     1.21f,	new ClothData[] {   new ClothData(new PriceCoin(230),   "41_Character9-0" ),
																											new ClothData(new PriceCoin(240),   "42_Character9-1" ) }),
													new AvatarData("Miguel",    0.76f,	new ClothData[] {   new ClothData(new PriceCoin(250),   "43_Character10-0" ),
																											new ClothData(new PriceCoin(260),   "44_Character10-1" ),
																											new ClothData(new PriceGold(27),	"45_Character10-2" ) }),
													new AvatarData("Kahn",      0.82f,	new ClothData[] {   new ClothData(new PriceCoin(280),   "46_Character11" )}),
													new AvatarData("MMerYcy",   1.1f,	new ClothData[] {   new ClothData(new PriceCoin(290),	"47_Character12" )}),
												};
	public static ShopItem[] shopItems = { new ShopItemShield(), new ShopItemFood(), new ShopItemSuperFood(), new ShopItemHeadStart(), new ShopItemScoreBooster(), new ShopItemMission(0), new ShopItemMission(1), new ShopItemMission(2) };
}

