using UnityEngine;
using System.Collections;

public class SndFader
{
	AudioSource bgm;
	float SND_START_TM  = 0.8f;
	float mSndStartTm   = 0;

	float SND_STOP_TM   = 0.8f;
	float mSndStopTm    = 0;
	float mSndVolume    = 0;
	bool bPause         = false;


	public SndFader(AudioSource _bgm, float startDelay, float endDelay, bool isBgm)
	{
		bgm = _bgm;
		SND_START_TM = startDelay;
		SND_STOP_TM = endDelay;
		mSndVolume = GD.dtBgmVolum;
		bgm.ignoreListenerVolume = isBgm;
	}

	public void Play()
	{
		mSndStopTm = 0;
		bgm.Play();
		bgm.volume = 0;
		mSndStartTm = SND_START_TM;
	}

	public void Stop()
	{
		bPause = false;
		mSndStartTm = 0;
		mSndStopTm = SND_STOP_TM;
	}

	public void Stop(float fadeTm)
	{
		bPause = false;
		mSndStartTm = 0;
		SND_STOP_TM = fadeTm;
		mSndStopTm = SND_STOP_TM;
	}

	public void Pause()
	{
		bPause = true;
		mSndStartTm = 0;
		mSndStopTm = SND_STOP_TM;
	}

    public void SizeControl(float nSize)
    {
        bPause = false;
        mSndVolume = nSize;
        bgm.volume = nSize;
    }

    public float GetVolumeSize()
    {
        bPause = false;
        return bgm.volume;
    }

	public void Update () 
	{
		if (mSndStartTm > 0)
		{
			mSndStartTm -= Time.deltaTime;
			bgm.volume = Mathf.Lerp(mSndVolume, 0, mSndStartTm / SND_START_TM);
		}
		else if (mSndStopTm > 0)
		{
			mSndStopTm -= Time.deltaTime;
			bgm.volume = Mathf.Lerp(0, mSndVolume, mSndStopTm / SND_STOP_TM);
			if (mSndStopTm < 0)
			{
				if (bPause)
					bgm.Pause();
				else
					bgm.Stop();
			}
		}
	}
}
