using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AppNodeInfo
{
    public const int MAX_NEXT_CNT = 10;
    public int index;
    public int[] nodes_1 = new int[MAX_NEXT_CNT] { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 };
    public int[] nodes_2 = new int[MAX_NEXT_CNT] { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 };

    public Vector3[] points = new Vector3[4];
    public AppNodeInfo()
    {
        index = 0;
        for (int i = 0; i < 4; i++)
            points[i] = Vector3.zero;
    }

    public AppNodeInfo(int _index, int[] _nodes_1, int[] _nodes_2, Vector3[] _points)
    {
        index = _index;
        for (int i = 0; i < _nodes_1.Length; i++)
            nodes_1[i] = _nodes_1[i];
        for (int i = 0; i < _nodes_2.Length; i++)
            nodes_2[i] = _nodes_2[i];

        Array.Copy(_points, points, 4);
    }
}

public class AppMapInfo
{
    public const int MAX_NODE_CNT = 50;
    public int level;
    public int nodeSize;
    public float radius;
    public AppNodeInfo[] nodeInfos = new AppNodeInfo[MAX_NODE_CNT];

    public AppMapInfo()
    {
        level = 0;
        nodeSize = 0;
        radius = 0;
    }
    
    public AppMapInfo(int _level, int _size, float _radius, AppNodeInfo[] _nodeInfos)
    {
        level = _level;
        nodeSize = _size;
        radius = _radius;
        for (int i = 0; i < MAX_NODE_CNT && i < _nodeInfos.Length; i++)
            nodeInfos[i] = _nodeInfos[i];
    }
}