using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Text;
using System.Security.Cryptography;

public class Util
{
	static private Vector3 mV1 = Vector3.zero, mV2 = Vector3.zero;

	static public float GetAngleFromRightToVector(Vector2 _v)
	{
		float angle = Vector2.Angle(_v, Vector2.right);
		if(_v.y >= 0)
			return angle;
		else
			return 180 + (180 - angle);
	}

	static public float GetAngleFromUpToVector(Vector2 _v)
	{
		float angle = Vector2.Angle(Vector2.up, _v);
		if(_v.x <= 0)
			return angle;
		else
			return 180 + (180 - angle);
	}

	static public bool hasPrefix(string _a, string _b)
	{
		if(_a == null || _b == null || _a == string.Empty || _a == "" || _b == string.Empty || _b == "" || _a.Length < _b.Length)
			return false;
		return _a.Substring(0, _b.Length) == _b;
	}

	//return angle [-180, 180]
	static public float GetAngleFromXZ(Vector3 _v1, Vector3 _v2)
	{
		return GetAngle(_v1.x, _v1.z, _v2.x, _v2.z);
	}

	//return is in angle range
	static public bool IsInAngleRangeFromXZ(Vector3 _v1, Vector3 _v2, float _a1, float _a2)
	{
		float a = GetAngle(_v1.x, _v1.z, _v2.x, _v2.z);
		if((_a1 > 180 || _a2 > 180) && a < 0)
			a += 360;
		else if((_a1 < -180 || _a2 < -180) && a > 0)
			a -= 360;

		return _a1 < _a2 ? (_a1 <= a && a <= _a2) : (_a2 <= a && a <= _a1);
	}

	//return angle [-180, 180]
	static public float GetAngle(float _x1, float _y1, float _x2, float _y2)
	{
		mV1.Set(_x1, 0, _y1);
		mV2.Set(_x2, 0, _y2);
		float angle = Vector3.Angle(mV1, mV2);
		return Vector3.Dot(Vector3.Cross(Vector3.up, mV1), mV2) > 0 ? angle : -angle;
	}

	static public int GetDir(float _angle)
	{
		return (((int)(_angle + 45.0f) % 360) / 90 + 1);
	}

	static public int Get8Dir(float _angle)
	{
		return (((int)(_angle + 22.5f) % 360) / 45);
	}
	static public float Smooth(float x)
	{
		return (Mathf.Sin(x * Mathf.PI - Mathf.PI / 2) + 1) / 2.0f;
	}
	static public float FloatMod(float val, float len)
	{
		float n = val / len;
		return val - ((int)n) * len;
	}

	//limit depth 0 mean self, 1 mean child, 2 mean child of child, ...
	static public void SendMessageRecursively(GameObject go, string msg, int limitDepth)
	{
		if(go == null)
			return;
		go.SendMessage(msg, SendMessageOptions.DontRequireReceiver);
		if(0 <= limitDepth)
		{
			foreach(Transform child in go.transform)
				SendMessageRecursively(child.gameObject, msg, limitDepth - 1);
		}
	}

	//limit depth 0 mean self, 1 mean child, 2 mean child of child, ...
	static public void SendMessageRecursively(GameObject go, string msg, object param, int limitDepth)
	{
		go.SendMessage(msg, param, SendMessageOptions.DontRequireReceiver);
		if(0 <= limitDepth)
		{
			foreach(Transform child in go.transform)
				SendMessageRecursively(child.gameObject, msg, param, limitDepth);
		}
	}

	static public void SetLayerRecursively(Transform _tr, int _layer)
	{
		_tr.gameObject.layer = _layer;

		foreach(Transform child in _tr.transform)
			SetLayerRecursively(child, _layer);
	}

	static public void DrawColor(UISprite _go, Color _color, int _limitDepth)
	{
		_go.color = _color;
		foreach(Transform child in _go.transform)
			DrawColor(child.GetComponent<UISprite>(), _color, 0, _limitDepth);

	}

	static public void DrawColor(UISprite _go, Color _color, int _curDepth, int _limitDepth)
	{
		if(_curDepth < _limitDepth)
		{
			foreach(Transform child in _go.transform)
				DrawColor(child.GetComponent<UISprite>(), _color, _curDepth + 1, _limitDepth);
			_go.color = _color;
		}

	}

	static public int GetMaxLongLineCharCnt(string _str)
	{
		int curPos = 0, beginPos = 0;
		int maxLen = 0;
		char[] chr = _str.ToCharArray();
		for(curPos = 0; curPos < chr.Length; curPos++)
		{
			if(chr[curPos].ToString() == "\n" || chr[curPos].ToString() == "." || chr[curPos].ToString() == "?")
			{
				int len = curPos - beginPos;
				if(maxLen < len)
					maxLen = len;

				beginPos = curPos;
			}
		}
		return maxLen;
	}

	static public void PlaySound(string _snd, float _pitch = 1, float _delay = 0, float _vol = 1)
	{
		if(_snd == null)
			return;
		AudioClip clip = Resources.Load("Sfx/" + _snd) as AudioClip;
		if(clip == null)
			return;

		GameObject go = new GameObject("_auto_play_sound");
		AudioSource source = go.AddComponent(typeof(AudioSource)) as AudioSource;
		source.clip		= clip;
		source.volume	= _vol;
		source.loop		= false;
		source.pitch	= _pitch;
		source.PlayDelayed(_delay);

		GameObject.Destroy(go, clip.length + _delay + 0.2f);
	}

	static public GameObject PlaySound3D(string _snd, Transform _parent, float _volum = 1)
	{
#if MR_SERVER
		return null;
#else
		if(_snd == null)
			return null;
		AudioClip clip = Resources.Load("Snd/" + _snd) as AudioClip;
		if(clip == null)
			return null;

		GameObject go = new GameObject("_auto_play_sound3D");
		AudioSource source = go.AddComponent(typeof(AudioSource)) as AudioSource;
		go.transform.parent = _parent;
		go.transform.localPosition = Vector3.zero;
		source.clip = clip;
		source.volume = _volum;
		source.loop = false;
		source.priority = 130;
		source.spatialBlend = 1;
		source.minDistance = 1.5f;
		source.maxDistance = 8f;
		source.rolloffMode = AudioRolloffMode.Linear;
		source.Play();
		GameObject.Destroy(go, clip.length + 0.5f);
		return null;
#endif
	}

	static Vector2 vTmp2 = Vector3.zero;
	public static Vector2 Vec2(float _x, float _y)
	{
		vTmp2.x = _x;
		vTmp2.y = _y;
		return vTmp2;
	}

	static Vector3 vTmp = Vector3.zero;
	public static Vector3 Vec3(float _x, float _y, float _z)
	{
		vTmp.x = _x;
		vTmp.y = _y;
		vTmp.z = _z;
		return vTmp;
	}

	public static float NormalAngle(float a)
	{
		if(180 < a && a < 360)
			return a - 360;
		else
			return a;
	}

	static public T InstantObj<T>(string _prefabName, Transform _parent)
	{
		UnityEngine.Object obj = Resources.Load(_prefabName);
		if(obj == null)
		{
			UnityEngine.Debug.LogError("Failed resource asset: " + _prefabName);
			return default(T);
		}
		GameObject go = GameObject.Instantiate(obj) as GameObject;

		go.transform.parent = _parent;
		SetParent(go.transform, _parent);
		go.transform.localPosition = Vector3.zero;
		go.transform.localRotation = Quaternion.identity;
		go.transform.localScale = Vector3.one;

		return go.GetComponent<T>();
	}

	static public T GetComponentInParentOrSelf<T>(Transform _t)
	{
		T tp = _t.GetComponent<T>();
		if(tp == null)
			tp = _t.GetComponentInParent<T>();
		return tp;
	}

	static public void SetParent(Transform _child, Transform _parent)
	{
		_child.parent = _parent;
		_child.localPosition = Vector3.zero;
		_child.localRotation = Quaternion.identity;
		_child.localScale = Vector3.one;
	}

	static public void ChangeParent(Transform _oldParent, Transform _newParent)
	{
		for(int i = 0; i < _oldParent.childCount; i++)
			SetParent(_oldParent.GetChild(i), _newParent);
	}

	static public bool IsInPercent(float _p)
	{
		return UnityEngine.Random.Range(0f, 100f) < _p;
	}

	//return randome in range [min, max]
	static public int IntRandom(int min, int max)
	{
		return Mathf.RoundToInt(UnityEngine.Random.Range(min - 0.49f, max + 0.49f));
	}

	static public bool IsIn(float _val, float _min, float _max)
	{
		return _min <= _val && _val <= _max;
	}
	static public bool IsIn(int _val, int _min, int _max)
	{
		return _min <= _val && _val <= _max;
	}

	static public Vector3 GetRandomPos(BoxCollider[] colliders)
	{
		BoxCollider c = colliders[UnityEngine.Random.Range(0, colliders.Length)];
		mV1.Set(UnityEngine.Random.Range(-c.size.x / 2, +c.size.x / 2), UnityEngine.Random.Range(-c.size.y / 2, +c.size.y / 2), UnityEngine.Random.Range(-c.size.z / 2, +c.size.z / 2));
		return c.transform.position + c.transform.rotation * mV1;
	}

	static public Vector3 GetRandomPos(BoxCollider c)
	{
		mV1.Set(UnityEngine.Random.Range(-c.size.x / 2, +c.size.x / 2), UnityEngine.Random.Range(0, +c.size.y / 2), UnityEngine.Random.Range(-c.size.z / 2, +c.size.z / 2));
		return c.transform.position + c.transform.rotation * mV1;
	}

	static public bool IsInAreaRange(BoxCollider c, Vector3 _pos)
	{
		_pos = Quaternion.Inverse(c.transform.rotation) * (_pos - c.transform.position) - c.center;
		return IsIn(_pos.x, -c.size.x / 2, c.size.x / 2) && IsIn(_pos.z, -c.size.z / 2, c.size.z / 2);
	}

	//randomize [0, n-1], if zero idx = -1, index of zero will be randomized or, be set to zeroIdx.
	static public int[] randomArry(int _min, int _max, int firstIdx = -1)
	{
		List<int> lstS = new List<int>();
		for(int i = _min; i < _max; i++)
			lstS.Add(i);

		List<int> lstD = new List<int>();
		int n = lstS.Count;
		for(int i = 0; i < n - 1; i++)
		{
			int m = (int)lstS[UnityEngine.Random.Range(0, lstS.Count)];
			lstS.Remove(m);
			lstD.Add(m);
		}
		lstD.Add(lstS[0]);

		if(0 <= firstIdx && firstIdx < lstD.Count)
		{
			lstD.Remove(0);
			lstD.Insert(firstIdx, 0);
		}

		return lstD.ToArray();
	}

	static public int[] StringToIntArray(string _str, int _count)
	{
		string[] str = new string[_count];
		int[] val = new int[_count];
		char[] chr = new char[] { ',' };
		str = _str.Split(chr, _count);
		for(int i = 0; i < _count; i++)
		{
			val[i] = int.Parse(str[i]);
		}
		return val;
	}

	static public string IntArrayToString(int[] _val, int _count)
	{
		string str = string.Empty;
		str = string.Format("{0}", _val[0]);
		for(int i = 1; i < _count; i++)
		{
			str = string.Format("{0},{1}", str, _val[i]);
		}
		return str;
	}

	static public short Angle2Short(float _angle)
	{
		return (short)(FloatMod(_angle, 360) * (32760 / 360f));
	}

	static public float Short2Angle(short _short)
	{
		return 360f * _short / 32760;
	}

	//순서정렬된 배렬에서 반분탐색법으로 배렬에서 주어진 값에 제일 가까운 작은 값을 가지는 색인번호를 되돌린다.
	static public int findIndex(float _val, float[] _ary)
	{
		int min = 0;
		int max = _ary.Length - 1;
		if(_val <= _ary[0])
			return 0;
		if(_val >= _ary[_ary.Length - 1])
			return _ary.Length - 1;

		int mid = 0;
		while(min + 1 < max)
		{
			mid = (max + min) / 2;
			if(_val == _ary[mid])
				return mid;
			else if(_val < _ary[mid])
				max = mid;
			else if(_val > _ary[mid])
				min = mid;
		}
		return min;
	}
	//순서정렬된 배렬에서 반분탐색법으로 배렬에서 주어진 값에 제일 가까운 작은 값을 가지는 색인번호를 되돌린다.
	static public int findIndex(int _val, int[] _ary)
	{
		int min = 0;
		int max = _ary.Length - 1;
		if(_val <= _ary[0])
			return 0;
		if(_val >= _ary[_ary.Length - 1])
			return _ary.Length - 1;

		int mid = 0;
		while(min + 1 < max)
		{
			mid = (max + min) / 2;
			if(_val == _ary[mid])
				return mid;
			else if(_val < _ary[mid])
				max = mid;
			else if(_val > _ary[mid])
				min = mid;
		}
		return min;
	}

	static public int TimeToIntValue(DateTime _time)
	{
		TimeSpan ts = _time - MD.BASE_TIME;
		return (int)(ts.TotalSeconds);
	}

	static private TimeSpan timeSpan = new TimeSpan();
	static private DateTime dateTime = new DateTime();

	static public DateTime IntToTimeValue(int _value)
	{
		timeSpan = TimeSpan.FromSeconds(_value);
		dateTime = MD.BASE_TIME + timeSpan;
		return dateTime;
	}

	static public string getMd5Hash(string input)
	{
		// Create a new instance of the MD5CryptoServiceProvider object.
		MD5 md5Hasher = MD5.Create();

		// Convert the input string to a byte array and compute the hash.
		byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));

		// Create a new Stringbuilder to collect the bytes
		// and create a string.
		StringBuilder sBuilder = new StringBuilder();

		// Loop through each byte of the hashed data 
		// and format each one as a hexadecimal string.
		for(int i = 0; i < data.Length; i++)
		{
			sBuilder.Append(data[i].ToString("x2"));
		}

		// Return the hexadecimal string.
		return sBuilder.ToString();
	}

	// Verify a hash against a string.
	static public bool verifyMd5Hash(string input, string hash)
	{
		// Hash the input.
		string hashOfInput = getMd5Hash(input);

		// Create a StringComparer an comare the hashes.
		StringComparer comparer = StringComparer.OrdinalIgnoreCase;

		if(0 == comparer.Compare(hashOfInput, hash))
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	static public int compareDown(float _first, float _second)
	{
		int result = _second.CompareTo(_first);//내리정렬
		return result;
		//if (_first == null)
		//{
		//    if (_second == null)
		//        return 0;
		//    else
		//        return -1;
		//}
		//else
		//{
		//    if (_second == null)
		//        return 1;
		//    else
		//    {
		//        int result = _second.CompareTo(_first);//내리정렬
		//        return result;
		//    }
		//}
	}

	static public int compareUp(float _first, float _second)
	{
		int result = _first.CompareTo(_second);
		return result;
	}

	static public int getIndex(object[] _array, object _obj)
	{
		for(int idx = 0; idx < _array.Length; idx++)
		{
			if(_array[idx] == _obj)
				return idx;
		}
		return -1;
	}

	public static void CreateMultiDirectory(string _sPath, bool _isContainedFileName)
	{
		if(!_isContainedFileName)
			System.IO.Directory.CreateDirectory(_sPath);
		else
			System.IO.Directory.CreateDirectory(_sPath.Substring(0, _sPath.LastIndexOf('/')));
	}

	public static void SetPosRot(Transform _trSrc, Transform _trDst)
	{
		_trDst.position = _trSrc.position;
		_trDst.rotation = _trSrc.rotation;
	}

	public static Color Uint2Col(uint _color)
	{
		Color c;
		c.b = ((_color) & 0xFF) / 255f;
		c.g = ((_color >> 8) & 0xFF) / 255f;
		c.r = ((_color >> 16) & 0xFF) / 255f;
		c.a = ((_color >> 24) & 0xFF) / 255f;
		return c;
	}
}



