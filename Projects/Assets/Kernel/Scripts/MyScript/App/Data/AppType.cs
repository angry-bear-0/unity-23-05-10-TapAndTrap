using UnityEngine;
using System;

public class AppState
{
    public const int none = -1;
    public const int start = 0;
    public const int home = 1;
    public const int ready = 2;
    public const int play = 3;
    public const int result = 4;
    public const int die = 5;
    public const int win = 6;
    public const int pause = 4;
}

public class RoundType
{
    public const int none = -1;  
    public const int onlyCount = 0;
    public const int onlyTime = 1;
    public const int both = 2;
    public const int Count = 3;
}

public class BallState
{
    public const int none = -1;
    public const int live = 0;
    public const int die = 1;
    public const int count = 2;
}

public class AppRoundUIData
{
    public int index;
    public string name;
    public string scnName;
    public string spriteName0;
    public string spriteName1;
    public bool descState;

    public AppRoundUIData(int _index, string _name, string _scnName, string _spriteName0, string _spriteName1, bool _descState)
    {
        index = _index;
        name = _name;
        scnName = _scnName;
        spriteName0 = _spriteName0;
        spriteName1 = _spriteName1;
        descState = _descState; 
    }
}

public class AppRoundGoalData
{
    public int index;
    public int roundType;
    public int limitCount;
    public float limitTime;
    public float speed;
    public int[] goals = new int[3];

    public AppRoundGoalData(int _index, int _roundType, int _limitCount, float _limitTime, float _speed, int[] _goals)
    {
        index = _index;
        roundType = _roundType;
        limitCount = _limitCount;
        limitTime = _limitTime;
        speed = _speed;
        goals = _goals;
    }
}

public class AppRoundData
{
    public int index;
    public string pfName;
    public int ballCnt;
    public int mapIndex;
    public AppRoundData(int _index, string _pfName, int _ballCnt, int _mapIndex)
    {
        index = _index;
        pfName = _pfName;
        ballCnt = _ballCnt;
        mapIndex = _mapIndex;
    }
}

public class AppBallData
{
    public int index;
    public string spriteName;
    public AppBallData(int _index, string _spriteName)
    {
        index = _index;
        spriteName = _spriteName;
    }
}

public class AppTechData
{
    public int index;
    public string name;
    public string spriteName;
    public bool lockState;
    public bool descState;
    public AppTechData(int _index, string _name, string _spriteName, bool _lockState, bool _descState)
    {
        index = _index;
        name = _name;
        spriteName = _spriteName;
        lockState = _lockState;
        descState = _descState;
    }
}


