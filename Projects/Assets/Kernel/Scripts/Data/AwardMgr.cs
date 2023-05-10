using System.Collections.Generic;

public static class AwardMgr
{
	public static List<AwardInfo> infos = new  List<AwardInfo>();

    public static void Init()
	{
		if (infos.Count > 0)
			return;

		infos.Add(new AwardInfoScoreHunter(new AwardData("cdAwdTitleScoreHunter", "cdAwdDescScoreHunter",		null,							null),					PlayerEventKind.score));
		infos.Add(new AwardInfo(new AwardData("cdAwdTitleCoinCollector",		"cdAwdDescCoinCollector",	new int[] {4000, 8000, 15000},	new int[] {12, 24, 45}),	PlayerEventKind.getCoin,	true));
		infos.Add(new AwardInfo(new AwardData("cdAwdTitleStuntPerformer",		"cdAwdDescStuntPerformer",	new int[] {20, 100, 300},		new int[] {2, 5, 20}),		PlayerEventKind.stunt,		true));
		infos.Add(new AwardInfo(new AwardData("cdAwdTitlePetFancier",			"cdAwdDescPetFancier",		new int[] {2, 3, 4},			new int[] {3, 5, 7}),		PlayerEventKind.buyPet,		false));
		infos.Add(new AwardInfo(new AwardData("cdAwdTitleFashionista",			"cdAwdDescFashionista",		new int[] {2, 5, 11},			new int[] {5, 15, 45}),		PlayerEventKind.buyAvatar,	false));
		infos.Add(new AwardInfo(new AwardData("cdAwdTitleCarefulPerformer",		"cdAwdDescCarefulPerformer",new int[] {10, 30, 50},			new int[] {2, 5, 15}),		PlayerEventKind.shield,		true));
		infos.Add(new AwardInfo(new AwardData("cdAwdTitleMissionMaster",		"cdAwdDescMissionMaster",	new int[] {3, 8, 18},			new int[] {5, 12, 27}),		PlayerEventKind.missionSet,	false));
		infos.Add(new AwardInfo(new AwardData("cdAwdTitleHiLvlGamer",			"cdAwdDescHiLvlGamer",		new int[] {5, 12, 25},			new int[] {7, 15, 33}),		PlayerEventKind.levelUp,	false));
		infos.Add(new AwardInfo(new AwardData("cdAwdTitleStuntMaster",			"cdAwdDescStuntMaster",		new int[] {2, 4, 7},			new int[] {4, 7, 12}),		PlayerEventKind.buyStunt,	false));
	}

	public static void Load()
	{
		foreach (AwardInfo a in infos)
			a.Load();
	}

	public static void Save()
	{
		foreach(AwardInfo a in infos)
			a.Save();
	}

	public static void OnInit()
	{
		foreach(AwardInfo a in infos)
			a.OnInit();
	}

	public static void OnEvent(PlayerEventKind _event, int _param = 1)
	{
		foreach(AwardInfo a in infos)
			a.OnEvent(_event, _param);
	}
}
