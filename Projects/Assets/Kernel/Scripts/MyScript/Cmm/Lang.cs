using UnityEngine;
using System.Collections.Generic;

static public class Lang
{
	public const int defaultLangIdx = 0;
	public delegate void OnLocalizeDelegate();
	public static OnLocalizeDelegate onLocalize = null;

	static Dictionary<string, string> mDic = null;
	static Dictionary<string, string[]> mDicArray = new Dictionary<string, string[]>();

	static public string[]	langSurfixes = {"en", "cn"};
	static public int		curLangIdx = -1;

	static public void LoadLang(int langIdx = -1)
	{
		if(langIdx == -1)
			langIdx = defaultLangIdx;

		if(langIdx == curLangIdx)
			return;

		curLangIdx = langIdx;
		string langSurfix = langSurfixes[langIdx];

#if MR_SERVER
		TextAsset ass1 = Resources.Load("Lang/server_" + langSurfix) as TextAsset;
#else
		TextAsset ass1 = Resources.Load("Lang/client_" + langSurfix) as TextAsset;
#endif
		ByteReader reader1 = new ByteReader(ass1);
		mDic = reader1.ReadDictionary();

		//TextAsset ass2 = Resources.Load("Lang/common_" + langSurfix) as TextAsset;
		//ByteReader reader2 = new ByteReader(ass2);
		//addDic(reader2.ReadDictionary(), mDic);
		System.GC.Collect();

		UIRoot.Broadcast("OnLocalize");
		if (onLocalize != null)
			onLocalize();
	}

	static void addDic(Dictionary<string, string> _src, Dictionary<string, string> _dst)
	{
		foreach(KeyValuePair<string, string> kvp in _src)
		{
			if (!_dst.ContainsKey(kvp.Key))
				_dst.Add(kvp.Key, kvp.Value);
			else
				Debug.LogError("Localization Key already exist. key = " + kvp.Key);
		}
	}

	static public string Get(string _key)
	{
		string val;

		if(mDic == null)
			LoadLang();

		if(mDic != null && mDic.TryGetValue(_key, out val))
			return val;

#if UNITY_EDITOR
		Debug.LogWarning("Localization key not found: '" + _key + "' for language " + langSurfixes[curLangIdx]);
#endif
		return _key;
	}

	static public string[] GetArray(string _key)
	{
		string		val;
		string[]	vals;
		if(mDicArray.TryGetValue(_key, out vals))
			return vals;

		if(mDic != null && mDic.TryGetValue(_key, out val))
		{
			vals = val.Split('|');
			mDicArray.Add(_key, vals);
			return vals;
		}
#if UNITY_EDITOR
		Debug.LogWarning("Localization key not found: '" + _key + "' for language " + langSurfixes[curLangIdx]);
#endif
		return _key.Split('|');
	}
	
	static public string Format(string key, params object[] parameters) { return string.Format(Get(key), parameters); }

	static public string Get(string _key, int _idx)
	{
		string val;
		string key = _key+_idx.ToString();
		if(mDic != null && mDic.TryGetValue(key, out val))
			return val;

#if UNITY_EDITOR
		Debug.LogWarning("Localization key not found: '" + key + "' for language " + langSurfixes[curLangIdx]);
#endif
		return key;
	}
}
