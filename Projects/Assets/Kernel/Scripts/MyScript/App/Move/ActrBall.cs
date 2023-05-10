using System;
using UnityEngine;

public class ActrBall : MonoBehaviour
{
    protected int mState = BallState.none;
    public int state { get { return mState; } set { mState = value; } }


    ActrRound mRound;
    protected Transform mTr;
    protected Transform mTrRound;
    protected Vector3 mPos = Vector3.zero;

    protected int mLevel = 0;
    protected int mBallLevel = 0;
    protected int mMapIndex = 0;

    protected AppRoundGoalData mGoalData;
    protected AppNodeInfo[] mNodeInfos;
    protected int lastNodeId = 0;
    protected int nowNodeId = 1;

    protected float mSpeed = 0.1f;

    protected float mWholeTime = 1f;
    protected float mDeltaTime = 0f;

    protected Vector3 v0 = Vector3.zero;
    protected Vector3 v1 = Vector3.zero;
    protected Vector3 v2 = Vector3.zero;
    protected Vector3 v3 = Vector3.zero;


    public void Init(ActrRound _round, int _index, int _level, int _ballLevel, int _mapIndex)
    {
        if (mBallLevel < 0 && mLevel >= AppMD.appBallsData.Length)
            return;

        state = BallState.live;

        mRound = _round;
        mTr = GetComponent<Transform>();
        mTrRound = mRound.transform;

        mLevel = _level;

        mMapIndex = _mapIndex;
        mNodeInfos = AppNodeMD.mapData[mMapIndex].nodeInfos;

        mGoalData = AppMD.appRoundGoalsData[mLevel];
        mSpeed = mGoalData.speed;

        move(1, 1);
        lastNodeId = 0;
        nowNodeId = 1;

        for (int i = 0; i < _index * 3; i++)
            updatePath();

        mTr.position = mPos + mTrRound.position;
    }


    void Update()
    {
        if (AppClient.me.state != AppState.play && AppClient.me.state != AppState.ready)
            return;

        float dt = Time.deltaTime * mSpeed;
        mDeltaTime += (AppClient.me.state == AppState.play || AppClient.me.state == AppState.ready) ? dt : 0;
        if (mDeltaTime > mWholeTime)
        {
            mDeltaTime -= mWholeTime;
            updatePath();
        }

        mPos = AppUtil.CalculateBezierPoint(mDeltaTime / mWholeTime, v0, v1, v2, v3);
        mTr.position = mPos + mTrRound.position;
    }

    
    public void Capture()
    {
        if (state == BallState.live)
            state = BallState.die;
    }

    protected void move(int  _nodeId, int _dir)
    {
        if (_nodeId >= mNodeInfos.Length) {
            return;
        }
        if (_dir > 0) {
            v0 = mNodeInfos[_nodeId].points[0];
            v1 = mNodeInfos[_nodeId].points[1];
            v2 = mNodeInfos[_nodeId].points[2];
            v3 = mNodeInfos[_nodeId].points[3];
        }
        else {
            v0 = mNodeInfos[_nodeId].points[3];
            v1 = mNodeInfos[_nodeId].points[2];
            v2 = mNodeInfos[_nodeId].points[1];
            v3 = mNodeInfos[_nodeId].points[0];
        }
    }
    protected void updatePath()
    {
        int nextNodeId = decideNextNodeIndex(nowNodeId, lastNodeId);
        lastNodeId = nowNodeId;
        nowNodeId = nextNodeId;
        
        if ((v3 == mNodeInfos[nowNodeId].points[0]) || (v0 == mNodeInfos[nowNodeId].points[3]))
            move(nowNodeId, 1);
        else
            move(nowNodeId, 0);
    }

    protected int[] lastNode = new int[10];
    protected int[] newNode = new int[10];
    
    protected string path1 = string.Empty;

    protected int decideNextNodeIndex(int _index, int _lastIndex)
    {
        AppNodeInfo nodeInfo1 = mNodeInfos[_index];
        AppNodeInfo nodeInfo0 = mNodeInfos[_lastIndex];

        int[] lastNodes1 = nodeInfo0.nodes_1;
        int[] lastNodes2 = nodeInfo0.nodes_2;
        int[] newNodes1 = nodeInfo1.nodes_1;
        int[] newNodes2 = nodeInfo1.nodes_2;

        for (int i = 0; i < AppNodeInfo.MAX_NEXT_CNT; i++)
        {
            if (newNodes1[i] == _lastIndex)
                Array.Copy(newNodes2, newNode, 10);
            if (newNodes2[i] == _lastIndex)
                Array.Copy(newNodes1, newNode, 10);

            if (lastNodes1[i] == _index)
                Array.Copy(lastNodes1, lastNode, 10);
            if (lastNodes2[i] == _index)
                Array.Copy(lastNodes2, lastNode, 10);
        }
        int sum = 0;
        for (int i = 0; i < AppNodeInfo.MAX_NEXT_CNT; i++)
        {
            if (newNode[i] == -1)
                continue;

            if (newNode[i] == _lastIndex)
            {
                newNode[i] = -1;
                continue;
            }

            int check = 0;
            for (int j = 0; j < AppNodeInfo.MAX_NEXT_CNT; j++)
            {
                if (lastNode[i] == -1)
                    continue;
                
                if (newNode[i] == lastNode[j])
                {
                    check = 1;
                    newNode[i] = -1;
                    break;
                }
            }

            if (check == 0)
                sum++;
        }

        int cnt = 0;
        int rnd = UnityEngine.Random.Range(0, sum);
        for (int i = 0; i < AppNodeInfo.MAX_NEXT_CNT; i++)
        {
            if (newNode[0] == -1)
                continue;
            if (cnt == rnd)
            {                
                path1 = string.Format("{0}, {1}", path1, newNode[i]);
                return newNode[i];
            }
            cnt++;
        }
        return 0;
    }
}
