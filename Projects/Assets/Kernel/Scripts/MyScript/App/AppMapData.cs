using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AppMapData
{
    public const int MAX_NEXT_CNT = 10;
    public int index;
    public int[] nexts = new int[MAX_NEXT_CNT];

    public AppMapData() 
    { 
        index = 0;
        for (int i = 0; i < MAX_NEXT_CNT; i++) { nexts[i] = -1; }
    }

    public AppMapData(int _index, int[] _nexts) 
    {
        index = _index;
        for (int i = 0; i < MAX_NEXT_CNT; i++) 
        { 
            nexts[i] = -1; 
        }
        Array.Copy(_nexts, nexts, Math.Min(MAX_NEXT_CNT, _nexts.Length));
    }
}
