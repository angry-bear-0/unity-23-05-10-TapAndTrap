using UnityEngine;
using System.Collections;

public class TweenButton : MonoBehaviour {
    [HideInInspector]
    public bool _IsTween = false;
    Transform mTrans;
    Transform mParrent;
	// Use this for initialization
	void Start () {
        if (mTrans == null)
            mTrans = transform;
        if (mParrent == null)
            mParrent = mTrans.parent;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void InitTween()
    {
        StartCoroutine(InitTweenRoutin());
    }

    IEnumerator InitTweenRoutin()
    {
        foreach (Transform child in mParrent)
        {
            if (child != mTrans)
            {
                TweenButton button = child.GetComponent<TweenButton>();
                if (button._IsTween == true)
                {
                    button.DeinitTween();
                    yield return new WaitForSecondsRealtime(0.25f);
                }
            }
        }
        UITopOn();
        Util.SendMessageRecursively(gameObject, "Play", 3);
        _IsTween = true;
        yield break;
    }

    public void DeinitTween()
    {
        Util.SendMessageRecursively(gameObject, "PlayReverse", 3);
        _IsTween = false;
    }

    UIScrollView mScrollView;

    public SpringPanel.OnFinished onFinished;

    public float springStrength = 8f;

    void UITopOn()
    {
        if (mScrollView == null)
        {
            mScrollView = NGUITools.FindInParents<UIScrollView>(gameObject);

            if (mScrollView == null)
            {
                Debug.LogWarning(GetType() + " requires " + typeof(UIScrollView) + " on a parent object in order to work", this);
                enabled = false;
                return;
            }
        }
        if (mScrollView != null && mScrollView.panel != null)
        {
            Vector3[] corners = mScrollView.panel.worldCorners;
            Vector3 panelCenter = corners[2];
            Transform panelTrans = mScrollView.panel.cachedTransform;

            // Figure out the difference between the chosen child and the panel's center in local coordinates
            Vector3 cp = panelTrans.InverseTransformPoint(mTrans.position);
            Vector3 cc = panelTrans.InverseTransformPoint(panelCenter);
            Vector3 localOffset = cp - cc;

            // Offset shouldn't occur if blocked
            if (!mScrollView.canMoveHorizontally) localOffset.x = 0f;
            if (!mScrollView.canMoveVertically) localOffset.y = 0f;
            localOffset.z = 0f;


            // Spring the panel to this calculated position
            SpringPanel.Begin(mScrollView.panel.cachedGameObject,
                panelTrans.localPosition - localOffset, springStrength).onFinished = onFinished;
        }
    }
    
}
