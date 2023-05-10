using UnityEngine;
using System.Collections;

public class EffectorTxAni : Effector
{
	public string txPrefix;
	public int txCount;
	public float duaration;
	public bool loop;
	public bool autoPlay = true;
	private TxAnimator m_txAnimator;

	protected new void Awake()
	{
		base.Awake();
		m_txAnimator = new TxAnimator(txPrefix, txCount, duaration, loop);
		GetComponent<Renderer>().enabled = false;
		if (!loop && autoPlay)
			m_txAnimator.Play();
	}

	public void play()
	{
		m_txAnimator.Play();
	}

	bool CanDestroy()
	{
		return !loop && m_txAnimator.GetTexture() == null;
	}

	protected new void Update()
	{
		base.Update();

		m_txAnimator.Update();
		GetComponent<Renderer>().enabled = m_txAnimator.GetTexture() != null;
		GetComponent<Renderer>().material.mainTexture = m_txAnimator.GetTexture();//renderer.material.mainTexture = m_txAnimator.GetTexture();
	}

	protected new void Play(Transform _parent)
	{
		base.Play(_parent);
		m_txAnimator.Play();
	}
}
