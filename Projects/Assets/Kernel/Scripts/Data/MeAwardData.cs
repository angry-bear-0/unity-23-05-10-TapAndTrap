public class AwardData
{
	public string   title;
	public string   desc;
	public int[]    target;
	public int[]    prize;

	public AwardData(string _title, string _desc, int[] _target, int[] _prize)
	{
		title   = _title;
		desc    = _desc;
		target  = _target;
		prize   = _prize;
	}
}

public class AwardInfo : PlayerEventBase
{
	public AwardData	data		{ get; protected set; } = null;
	public int			stage		{ get; protected set; } = 0;
	public int			goal		{ get; protected set; } = 0;
	public int			award		{ get; protected set; } = 0;

	protected PlayerEventKind	mEventKind	= PlayerEventKind.none;
	protected bool				mClaimable	= false;

	public			bool	IsMaxStage()	{ return data.target != null && stage >= data.target.Length; }
	public virtual	bool	CanClaim()		{ return mClaimable && value >= goal && value != 0; }

	public AwardInfo(AwardData _data, PlayerEventKind _eventKind, bool _inOneRun) : base (_inOneRun)	{ data = _data; mEventKind = _eventKind;}

	public override void OnInit()
	{
		if(IsMaxStage())
			return;
		goal    = data.target[stage];
		if(mInOneRun)
			value   = 0;
		award   = data.prize[stage];
	}

	public override bool OnEvent(PlayerEventKind _event, int _param = 1)
	{
		if(mEventKind != _event)
			return false;

		if(CanClaim() || IsMaxStage())
			return true;

		value += _param;

		if(value >= goal)
			mClaimable = true;

		return true;
	}

	public int Claim() //claim award and return received gem count.
	{
		if(!CanClaim() || IsMaxStage())
			return 0;

		stage++;
		mClaimable = false;
		int claimAward = award;
		OnInit();
		value = 0;
		return claimAward;
	}

	public void Load()
	{
		stage		= ObscuredPrefs.GetInt(data.title + ".stage", stage);
		mClaimable	= ObscuredPrefs.GetBool(data.title + ".mClaimable", mClaimable);
		if (!mInOneRun)
			value = ObscuredPrefs.GetInt(data.title + ".value", value);
	}

	public void Save()
	{
		ObscuredPrefs.SetInt(data.title + ".stage", stage);
		ObscuredPrefs.SetBool(data.title + ".mClaimable", mClaimable);
		if(!mInOneRun)
			ObscuredPrefs.SetInt(data.title + ".value", value);
	}

}

public class AwardInfoScoreHunter : AwardInfo
{
	public AwardInfoScoreHunter(AwardData _data, PlayerEventKind _eventKind) : base(_data, _eventKind, true) { }

	public override	void OnInit()		
	{
		goal	= 5000 + stage * 4000;
		value	= 0;
		award	= 5 + stage;
	}
}
