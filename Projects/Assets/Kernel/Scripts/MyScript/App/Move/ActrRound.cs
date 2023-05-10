using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActrRound : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] UISprite[] _sprMask;
    [SerializeField] UISprite _sprTop;
    [SerializeField] ActrBall[] _balls;
    [SerializeField] UISprite _sprBtm;

    protected int mLevel = 0;
    protected int mBallLevel = 0;

    AppBallData mBallData = null;
    AppRoundData mRoundData = null;

    protected UISprite mSelectedMask = null;
    protected float mEffectTm = 0;
    public void Init(int _level)
    {
        mLevel = _level;
        if (mLevel < 0 && mLevel >= AppMD.appRoundUIsData.Length)
            return;

        mRoundData = AppMD.appRoundsData[mLevel];

        for (int i = 0; i < _balls.Length; i++)
        {
            if (i < mRoundData.ballCnt)
                _balls[i].Init(this, i, mLevel, mBallLevel, mRoundData.mapIndex);
            else
                _balls[i].gameObject.SetActive(false);        

        }
    }

    private void Update()
    {
        float dt = Time.deltaTime;

        if (AppClient.me.state == AppState.play)
        {
            procMouseUpdate(Input.mousePosition);

            int cnt = 0;
            for (int i = 0; i < mRoundData.ballCnt; i++)
            {
                if (_balls[i].state == BallState.live)
                    _balls[i].gameObject.SetActive(true);
                else if (_balls[i].state == BallState.die)
                    _balls[i].gameObject.SetActive(false);

                if (_balls[i].state != BallState.die)
                    cnt++;
            }

            if (cnt == 0)
            {
                AppClient.me.state = AppState.result;
            }
        }
        
        if (mEffectTm < 0)
        {
            if (mSelectedMask != null)
                mSelectedMask.alpha = 0f;
        }
        mEffectTm -= dt;
    }

    protected void procMouseUpdate(Vector2 pos)
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            if (hit.collider != null && hit.collider.GetComponent<PolygonCollider2D>() != null)
            {
                if (AppClient.me.leftCount > 0 && AppClient.me.state == AppState.play)
                    AppClient.me.leftCount--;
                
                for (int i = 0; i < mRoundData.ballCnt; i++)
                {
                    if (_balls[i] == null)
                        continue;
                    PolygonCollider2D slideCollider = hit.collider.GetComponent<PolygonCollider2D>();
                    CircleCollider2D ballCollider = _balls[i].GetComponent<CircleCollider2D>();
                    bool isContained = IsCircleContainedByPolygon(ballCollider, slideCollider);
                    if (isContained)
                    {
                        if (_balls[i].state == BallState.live)
                            _balls[i].Capture();                                                
                    }
                }

                if (mSelectedMask)
                    mSelectedMask.alpha = 0;

                mSelectedMask = Util.GetComponentInParentOrSelf<UISprite>(hit.collider.transform);
                mSelectedMask.color = Color.blue;
                mSelectedMask.alpha = 0.8f;
                mEffectTm = 1f;
            }
        }
    }

    Vector2 tempVec2 = Vector2.zero;
    bool IsCircleContainedByPolygon(CircleCollider2D circle, PolygonCollider2D polygon)
    {

        tempVec2.x = circle.transform.localPosition.x - transform.localPosition.x;
        tempVec2.y = circle.transform.localPosition.y - transform.localPosition.y;

        Vector2 center = tempVec2 + circle.offset;
        Vector2[] points = polygon.GetPath(0);

        int i, j = points.Length - 1;
        bool isInside = false;

        for (i = 0; i < points.Length; i++)
        {
            if ((points[i].y < center.y && points[j].y >= center.y || points[j].y < center.y && points[i].y >= center.y) &&
                (points[i].x <= center.x || points[j].x <= center.x))
            {
                isInside ^= (points[i].x + (center.y - points[i].y) / (points[j].y - points[i].y) * (points[j].x - points[i].x) < center.x);
            }

            j = i;
        }

        return isInside;
    }


}
