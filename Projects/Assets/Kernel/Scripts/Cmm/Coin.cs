using UnityEngine;

public class Coin : MonoBehaviour 
{
	Transform mPRS;
	const float		MAGNET_ON_DIST = 10;
//	static Vector3	DELTA_H = new Vector3(0, 0.3f, 0);
	const float		FIRST_SPEED	= 20.0f;
	const float		ACC_SPEED	= 45.0f;
	float			mSpeed = 0;
    Vector3			mPreDir;
	AnimationState	mAsItemRot;
	Animation		mAni = null;

	// Use this for initialization
	void Start ()
	{
		mPRS = transform;
		mAni = mPRS.GetChild(0).GetComponent<Animation>();
		mAsItemRot = mAni["aniItemRot"];
	}
	public void Init(int _idx, int _length)
	{
		mAsItemRot.time = 0.9f * (float)_idx / (float)_length * mAsItemRot.length;
		mAni.Play("aniItemRot");// PlayQueued();
	}

	// Update is called once per frame
	void Update ()
	{
        if (GameMgr.gameState != GameState.play)
            return;
		
		if (!GD.dead && (GD.usingMagnet || mSpeed > 0))
			pullToMagnet();

	}

	public void reset()
	{
		transform.localPosition = Vector3.zero;
		mSpeed = 0;
	}

	void pullToMagnet()
	{
		if (GameMgr.player == null)
			return;
		Vector3 plrPos = GameMgr.playerTr.position;
		if (mSpeed <= 0)
		{
			if (plrPos.z < mPRS.position.z && (mPRS.position.z - plrPos.z) < MAGNET_ON_DIST)
				mSpeed = FIRST_SPEED;
		}

        if (mSpeed >0)
        {
            mSpeed += Time.deltaTime * ACC_SPEED;
			if (GameMgr.playerTr.position.z > mPRS.position.z)
            {
                mSpeed = 0;
            }
			Vector3 dir = plrPos - mPRS.position + Vector3.up * 0.3f;
            float dirLen = dir.magnitude;
            float speed = Mathf.Min(dirLen, mSpeed * Time.deltaTime);
            dir.Normalize();
            mPRS.position += (dir * speed);
        }
	}
}
