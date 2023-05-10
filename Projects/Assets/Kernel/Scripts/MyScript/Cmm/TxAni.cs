using UnityEngine;
using System.Collections;


public class TxAnimator
{
	private Texture2D[] m_TXs;
	private int m_nCnt		= 0;
	private float m_fCurTm	= 0;
	private float m_fDuration	= 0;
	private bool m_bLoop	= false;
	private bool m_bPlaying	= false;
	private int m_nTxIdx		= 0;
	
	public TxAnimator(string _txPrefix, int _frmCnt, float _tm, bool _loop_play)
	{
		m_nCnt		= _frmCnt;
		m_fDuration = _tm;
		m_bPlaying	= _loop_play;
		m_bLoop		= _loop_play;
		if (_loop_play)
			m_fCurTm = Random.Range(0, m_fDuration);
			
		m_TXs = new Texture2D[m_nCnt];
		for (int n = 0; n < m_nCnt; n ++)
		{
			string txName = _txPrefix + n.ToString("D2");
			m_TXs[n] = Resources.Load("Textures/" + txName) as Texture2D;
			
			if (m_TXs[n] == null)
				Debug.Log("ERROR: no found ani texture:" + txName);
		}
	}
	
	// play once
	public void Play()
	{
		m_bLoop		= false;
		m_bPlaying	= true;
		m_fCurTm	= 0;
	}
	//play looply
	void Play(bool play)
	{
		m_bLoop		= true;
		m_bPlaying	= play;
		m_fCurTm	= 0;
	}
		
	public void Update()
	{
		if (!m_bPlaying)
			return;
			
		m_fCurTm += Time.deltaTime;
		
		if (m_fCurTm > m_fDuration)
		{
			if (m_bLoop)
				m_fCurTm -= m_fDuration;
			else
			{
				m_bPlaying = false;
			}
		}
		
		m_nTxIdx = Mathf.RoundToInt(m_fCurTm / (m_fDuration/m_nCnt)) % m_nCnt;
	}
	
	public Texture2D GetTexture()
	{
		if (m_bPlaying)
			return m_TXs[m_nTxIdx];
			
		return null;
	}
}