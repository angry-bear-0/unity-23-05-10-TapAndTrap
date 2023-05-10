using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameMgr : MonoBehaviour 
{
	static public GameMgr		inst		{ get; private set; }	= null;
	static public GameState		gameState = GameState.none;
	static public Player		player		{get; private set; } = null;
	static public Transform		playerTr	{get; private set; } = null;
	static public GameObject	hero		{get; private set; } = null;
	static public Transform		heroTr		{get; private set; } = null;
	static public Tracker		tracker		{get; private set; } = null;
	static public Transform		trackerTr	{get; private set; } = null;
	static public InputMgr		inputMgr	{get; private set; } = null;
	static public CamMgr		cameraMgr	{get { return inst._CamMgr; } }

	public AniCurve				_AniCurve;
	public Camera				_MainCam;
	public GameObject			_InputHome;
	public Shader				_NormalShader;
	public Shader				_SfSkinShader;
	public GameObject			_Barrel;
    public Animation			_GrpLight;
    public Texture[]			_PetTx;
    public AudioSource          _BgmGame;
	[SerializeField] protected   CamMgr	_CamMgr = null;
	
	private PlayerHomeAni	mPlayerHomeAni = null;

	void Awake()
    {
		QualitySettings.vSyncCount = 0;
		Application.targetFrameRate = 32;
		QualitySettings.SetQualityLevel(1);
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
        GD.Load();
        UpdateCharacter();
		
		//_Player = GameObject.FindGameObjectWithTag("Player");
        tracker		= GameObject.FindGameObjectWithTag("Tracker").GetComponent<Tracker>();
		trackerTr	= tracker.transform;
		inputMgr	= InputMgr.Create();
		inst		= this;
        
	}

    // Use this for initialization
    void Start ()
    {
        GoAvtHome();
	}
	// Update is called once per frame
	void Update ()
    {
        _BgmGame.volume = GD.dtBgmVolum;
		if(!_BgmGame.isPlaying)
		{
		    _BgmGame.Play();
		}
	}
    public void GoAvtGame()
    {
		gameState = GameState.play;
		//_GrpLight.Play("aniLightStartRun");
        AvtGame.Create(true, true, true, true);

		if(AvtHome.inst != null)
			AvtHome.inst.Close();
    }
    public void GoAvtHome()
    {
		gameState = GameState.home;
		//_GrpLight.Play("aniLightEndRun");
        AvtHome.Create(true, true, true, true);
		if(AvtGame.instance != null)
			AvtGame.instance.Close();
	}
    public void GoAvtMe()
    {
    }
    public void GoAvtPreview()
    {
    }
    public void GoAvtResult()
    {
    }

    public void UpdateCharacter()
    {
		if (player == null)
		{
			GameObject pet = Instantiate(Resources.Load("Prefabs/Character/Pet/pet00_0")) as GameObject;
			player	= pet.GetComponent<Player>();
			playerTr= player.transform;
			mPlayerHomeAni = pet.GetComponent<PlayerHomeAni>();
			mPlayerHomeAni.Init = false;
		}

		player.transform.GetChild(0).GetComponent<SkinnedMeshRenderer>().material.mainTexture = _PetTx[GD.dtPetIdx];
		player.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material.mainTexture = _PetTx[GD.dtPetIdx];

		if(hero)
			Destroy(hero);

		hero	= Instantiate(Resources.Load("Prefabs/Character/Hero/Hero" + (GD.dtHeroIdx).ToString())) as GameObject;
		heroTr	= hero.transform;
		heroTr.parent = player._PetRoot;
        for (int i = 0; i < MD.avatar[GD.dtHeroIdx].clothes.Length; i++)
            heroTr.GetChild(i).gameObject.SetActive(GD.dtHeroInfos[GD.dtHeroIdx].clothIdx == i);
		mPlayerHomeAni.InitComponent();
    }
}
