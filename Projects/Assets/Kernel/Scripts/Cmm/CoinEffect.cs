using UnityEngine;
using System.Collections;

public class CoinEffect : MonoBehaviour 
{
	public bool forCache = false;
	public float destroyTm = 1;

	private Transform mPRS;
	private Vector3 mVecPos;
	// Use this for initialization
	void Start () 
	{
		if (!forCache)
		{
			GetComponent<Animation>().Play();
			mPRS = transform;
			mVecPos = GameMgr.playerTr.position;
			mVecPos.z += 3;
			mPRS.position = mVecPos;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
        //print("coinEffectGameobject" + gameObject);
		if (forCache)
			return;

		destroyTm -= Time.deltaTime;
		if (destroyTm < 0)
			Destroy(gameObject);

		mVecPos = GameMgr.playerTr.position;
		mVecPos += 3 * GameMgr.playerTr.forward;
		mPRS.position = mVecPos;
	}
}
