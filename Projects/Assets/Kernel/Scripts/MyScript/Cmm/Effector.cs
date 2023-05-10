using UnityEngine;
using System.Collections;


public class Effector : MonoBehaviour
{
	private bool m_played = false;
	private Transform m_parent;
	private Vector3 m_deltaPos;
	private Transform me;

	protected void Awake() 
	{
		me = transform;
	}

	bool CanDestroy()
	{
		return false;
	}

	protected void Update() 
	{
		if (m_played && CanDestroy())
			Destroy(gameObject);

		if (m_parent)
			me.position = m_parent.position + m_deltaPos;
	}

	protected void Play(Transform _parent)
	{
		m_parent	= _parent;
		m_deltaPos	= me.position - m_parent.position;
		m_played	= true;
	}
}