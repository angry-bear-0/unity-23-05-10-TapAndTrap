using UnityEngine;

public class UIAvatar : MonoBehaviour
{
	public UISprite frameSprite = null;
	public string openEyeSprite;
	public string closeEyeSprite;
	public string talkSprite;
	public bool talking = false;
	
	
	float	mElapsedTm = 0;
	float	mActionTime = 0;
	bool	mActing = false;
	/// <summary>
	/// Activate the initial state.
	/// </summary>

	void Start()
	{
		mElapsedTm = Random.Range(0.5f, 2.0f);

		frameSprite.gameObject.SetActive(openEyeSprite.Length > 0);
		frameSprite.spriteName = openEyeSprite;
	}

	void Update()
	{
		mElapsedTm -= Time.deltaTime;
		
		if (mElapsedTm < 0)
			mActionTime -= Time.deltaTime;
			
		if (mActing && mActionTime < 0)
		{
			mActionTime = 0;
			mActing = false;
			frameSprite.gameObject.SetActive(openEyeSprite.Length > 0);
			frameSprite.spriteName = openEyeSprite;
			
			mElapsedTm = talking ? Random.Range(0.2f, 0.6f) : Random.Range(2.0f, 5.8f);
		}

		if (mElapsedTm < 0 && !mActing)		
		{
			mActionTime = Random.Range(0.2f, 0.6f);
			mActing = true;
			if (!talking || Random.Range(0, 20.0f) > 17.6f)
			{
				frameSprite.gameObject.SetActive(closeEyeSprite.Length > 0);
				frameSprite.spriteName = closeEyeSprite;
			}
			else
			{
				frameSprite.gameObject.SetActive(talkSprite.Length > 0);
				frameSprite.spriteName = talkSprite;
			}
		}
	}
	
	void Talk(bool _bTalk)
	{
		talking = _bTalk;
	}
}
