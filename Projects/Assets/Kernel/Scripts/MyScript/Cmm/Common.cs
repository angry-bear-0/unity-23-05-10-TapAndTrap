using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// common functions
public class Cmm
{
	static Vector3 mTmp = Vector3.zero;
    static Vector2 mTmp2 = Vector2.zero;
	public static Transform CreateUIPopupTxt(string _prefab, string _txt, Vector3 _pos, Transform _parent, Color _col, bool _needAni, bool _bold)
	{
		GameObject obj = GameObject.Instantiate(Resources.Load("Prefab/" + _prefab)) as GameObject;
		Transform trans = obj.GetComponent<Transform>();
		trans.parent = _parent;
		UILabel lb = trans.Find("label").GetComponent<UILabel>();
		lb.text = _txt;
		lb.color = _col;
		if (_bold)
		{
			lb.effectStyle = UILabel.Effect.Outline;
			lb.effectColor = _col * 0.5f;
		}
		
		trans.position = _pos;
		trans.localScale = Vector3.one;
		if (!_needAni)
			trans.Find("label").GetComponent<Animation>().enabled = false;
		return trans;
	}
	//----------------------------------------------------------------------
	public static void SetPos(Transform trans, float x, float y, float z)
	{
		mTmp.x = x;
		mTmp.y = y;
		mTmp.z = z;
		trans.position = mTmp;
	}
	//----------------------------------------------------------------------
	public static void SetLocalPos(Transform trans, float x, float y, float z)
	{
		mTmp.x = x;
		mTmp.y = y;
		mTmp.z = z;
		trans.localPosition = mTmp;
	}
	//----------------------------------------------------------------------
	public static void SetLocalRot(Transform trans, Quaternion _rot)
	{
		trans.rotation = _rot;
		//trans.Rotate( Vector3.up,	30f * mSegIdx ,Space.World); //Quaternion.Euler(x, y, z) * Quaternion.Euler(0, 15 * mSegIdx, 0);//mTmp;
	}
	//----------------------------------------------------------------------
	public static void SetLocalCirclePos(Transform trans, float x, float y, float z, int segIdx)
	{
		float rDist = Mathf.Sqrt(Mathf.Pow(x, 2) + Mathf.Pow(z, 2));
		float srAngle = GetAngleFromRightToVector(x, z);

		if (segIdx == 0)
		{
			mTmp.x = x;
			mTmp.y = y;
			mTmp.z = z;
			trans.localPosition = mTmp;
		}
		else 
		{
			mTmp.x = rDist * Mathf.Cos(srAngle + 15 * segIdx);
			mTmp.y = y;
			mTmp.z = rDist * Mathf.Sin(srAngle + 15 * segIdx);
			trans.localPosition = mTmp;
		}
	}
    //----------------------------------------------------------------------
    
    //----------------------------------------------------------------------
    public static UISprite ChildUISprite(Transform _trans, string _child)
	{
		return _trans.Find(_child).GetComponent<UISprite>();
	}
	//----------------------------------------------------------------------
	public static UILabel ChildUILabel(Transform _trans, string _child)
	{
		return _trans.Find(_child).GetComponent<UILabel>();
	}
	//----------------------------------------------------------------------
	public static Collider ChildCollider(Transform _trans, string _child)
	{
		return _trans.Find(_child).GetComponent<Collider>();
	}
	//----------------------------------------------------------------------
	public static TweenPosition ChildTweenPos(Transform _trans, string _child)
	{
		return _trans.Find(_child).GetComponent<TweenPosition>();
	}
	//----------------------------------------------------------------------
	class IntPair
	{
		public int val1;
		public int val2;
		public IntPair(int a1, int a2)
		{
			val1 = a1;
			val2 = a2;
		}
	}

	private static int CompareIntPair(IntPair v1, IntPair v2)
	{
		if (v1.val1 < v2.val1)
			return 1;
		else if (v1.val1 == v2.val1)
			return 0;
		return -1;
	}

	//static LocalNotification localNotif = null;
	public static void RemoveLocalNtfy()
	{
		//if (localNotif != null)
		//{
		//	NotificationServices.CancelAllLocalNotifications();
		//	localNotif = null;
		//}
	}

	public static void AddLocalNtfy()
	{
		//if (localNotif != null)
		//	return;

		//localNotif = new LocalNotification();
		//localNotif.applicationIconBadgeNumber = 1;
		//localNotif.fireDate = System.DateTime.Now.AddSeconds(80000); //almost 23 hours 
		//localNotif.alertBody = Lang.GetText("local_notification");
		//localNotif.hasAction = true;
		//NotificationServices.ScheduleLocalNotification(localNotif);
	}

	public static void SendMessageRecursively(GameObject go, string msg, int limitDepth)
	{
		go.SendMessage(msg, SendMessageOptions.DontRequireReceiver);
        foreach (Transform child in go.transform) 
            sendMessageRecursively(child.gameObject, msg, 0, limitDepth);
    }

	static void sendMessageRecursively(GameObject go, string msg, int curDepth, int limitDepth)
	{
		go.SendMessage(msg, SendMessageOptions.DontRequireReceiver);
		if (curDepth < limitDepth)
		{
			foreach (Transform child in go.transform)
				sendMessageRecursively(child.gameObject, msg, curDepth + 1, limitDepth);
		}
	}
    static public float Smooth(float x)
    {
        return (Mathf.Sin(x * Mathf.PI - Mathf.PI / 2) + 1) / 2.0f;
    }
	public static void sendMessageColliderActive(GameObject go)
	{
		if(go.transform.childCount > 0)
		{
			for(int i = 0; i < go.transform.childCount; i++)
			{
				if(go.transform.GetChild(i).GetComponent<BoxCollider>() != null)
					go.transform.GetChild(i).GetComponent<BoxCollider>().enabled = true;
				sendMessageColliderActive(go.transform.GetChild(i).gameObject);
			}
		}
	}
    static public float GetAngleFromRightToVector(float _x, float _y)
    {
        mTmp2.x = _x;
        mTmp2.y = _y;
        float angle = Vector2.Angle(mTmp2, Vector2.right);
        if (mTmp2.y >= 0)
            return angle;
        else
            return 180 + (180 - angle);
    }
}
