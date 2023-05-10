using UnityEngine;
using System.Collections;

[RequireComponent(typeof(UILabel))]
[AddComponentMenu("NGUI/Tween/NumberText")]

public class TweenNumberText : MonoBehaviour
{
	public UILabel mLabel = null;

	float mOldNum;
	float mNewNum;
	float mDurationTm = 0;
	float mTime = 0;

	public bool SetNumber(float _v, float _durationTm)
	{
		if (mLabel == null)
			return false;

		mOldNum = 0;
		if (mLabel.text != "")
			mOldNum = float.Parse(mLabel.text);
		
		if (_v.Equals(0))
		{
			mLabel.text = "0";
			mDurationTm = 0;
			return false;
		}
		if (_v.Equals(mOldNum))
			return false;
		mDurationTm = Mathf.Min(100, _durationTm);
		mTime = mDurationTm;
		if (_durationTm.Equals(0))
		{
			mLabel.text = Mathf.FloorToInt(_v).ToString("");
			return false;
		}
		else
		{
			mNewNum = _v;
			return true;
		}
	}


	// Use this for initialization
	void Start()
	{
		if (mLabel == null)
			mLabel = gameObject.GetComponent<UILabel>();
	}

	// Update is called once per frame
	void Update()
	{
		if (mDurationTm > 0)
		{
			mTime -= Time.deltaTime;
			if (mTime < 0)
			{
				mDurationTm = 0;
				string s = Mathf.FloorToInt(mNewNum).ToString("0");
				mLabel.text = s;
			}
			else
			{
				float f = Mathf.Clamp01(1 - mTime / mDurationTm);
				int num = Mathf.FloorToInt(mOldNum + (mNewNum - mOldNum) * f);
				mLabel.text = num.ToString();
			}
		}
	}
}
