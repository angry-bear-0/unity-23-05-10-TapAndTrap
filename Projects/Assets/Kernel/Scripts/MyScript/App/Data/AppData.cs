using UnityEngine;
using System;

public class AppMD
{
    public static int APP_MAX_ROUND_CNT = 5;
    public static int APP_AVAILABLE_ROUND_CNT = 50;
    public static float APP_LIVE_TIME = 300;
    public static int APP_LIVE_COUNT = 20;

    public static float APP_POINT_TIME = 20;
    public static float APP_POINT_COUNT = 20;

    public static AppRoundUIData[] appRoundUIsData =
    {
        new AppRoundUIData(0, "00", "scnGame00", "frmButtonRoundClose_01", "frmButtonRoundOpen_01", true),
        new AppRoundUIData(1, "01", "scnGame00", "frmButtonRoundClose_02", "frmButtonRoundOpen_02", true),
        new AppRoundUIData(2, "02", "scnGame00", "frmButtonRoundClose_03", "frmButtonRoundOpen_03", false),
        new AppRoundUIData(3, "03", "scnGame00", "frmButtonRoundClose_04", "frmButtonRoundOpen_04", false),
        new AppRoundUIData(4, "04", "scnGame00", "frmButtonRoundClose_05", "frmButtonRoundOpen_05", false),
        new AppRoundUIData(5, "01", "scnGame00", "frmButtonRoundClose_01", "frmButtonRoundOpen_01", false),
    };

    public static AppRoundGoalData[] appRoundGoalsData =
    {
        new AppRoundGoalData(0, RoundType.both, 12, 60f, 1.0f, new int[]{500, 800, 1200 } ),
        new AppRoundGoalData(1, RoundType.both, 12, 50f, 1.1f, new int[]{500, 800, 1200 } ),
        new AppRoundGoalData(2, RoundType.both, 10, 50f, 1.2f, new int[]{500, 800, 1200 } ),
        new AppRoundGoalData(3, RoundType.both, 10, 40f, 1.3f, new int[]{500, 800, 1200 } ),
        new AppRoundGoalData(4, RoundType.both, 8,  40f, 1.4f, new int[]{500, 800, 1200 } ),
        new AppRoundGoalData(5, RoundType.both, 8,  30f, 1.4f, new int[]{500, 800, 1200 } ),
    };

    public static AppRoundData[] appRoundsData =
    {
        new AppRoundData(0, "Prefabs/Rounds/round05", 1, 3),
        new AppRoundData(1, "Prefabs/Rounds/round06", 1, 2),
        new AppRoundData(2, "Prefabs/Rounds/round05", 2, 3),
        new AppRoundData(3, "Prefabs/Rounds/round06", 2, 2),
        new AppRoundData(4, "Prefabs/Rounds/round05", 3, 3),
        new AppRoundData(5, "Prefabs/Rounds/round06", 3, 2),
    };

    public static AppBallData[] appBallsData =
    {
        new AppBallData(0, "sprBall00"),
        new AppBallData(1, "sprBall01"),
        new AppBallData(2, "sprBall00"),
        new AppBallData(3, "sprBall01"),
        new AppBallData(4, "sprBall00"),
        new AppBallData(4, "sprBall01"),
    };

    public static int APP_MAX_TECH_CNT = 3;
    public static AppTechData[] appTechsData = {
        new AppTechData(0, "00", "sprTech01", true, false),
        new AppTechData(1, "01", "sprTech02", true, false),
        new AppTechData(2, "02", "sprTech03", true, false),
    };
}