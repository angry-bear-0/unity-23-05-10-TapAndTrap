//----------------------------------------------
//            NGUI: Next-Gen UI kit
// Copyright © 2011-2016 Tasharen Entertainment
//----------------------------------------------

using UnityEngine;
using System.Collections.Generic;
/// <summary>
/// Tween the widget's size.
/// </summary>

//[RequireComponent(typeof(UIWidget))]
//[AddComponentMenu("NGUI/Tween/Tween Height")]
public class AniCurve : MonoBehaviour
{
	public AnimationCurve _AcJump		= new AnimationCurve(new Keyframe(0f, 0f, 0f, 1f), new Keyframe(1f, 1f, 1f, 0f));
	public AnimationCurve _AcJumpSkill	= new AnimationCurve(new Keyframe(0f, 0f, 0f, 1f), new Keyframe(1f, 1f, 1f, 0f));
	public AnimationCurve _AcSpring		= new AnimationCurve(new Keyframe(0f, 0f, 0f, 1f), new Keyframe(1f, 1f, 1f, 0f));
	public AnimationCurve _AcFly		= new AnimationCurve(new Keyframe(0f, 0f, 0f, 1f), new Keyframe(1f, 1f, 1f, 0f));
    

    public float GetValue(float _time, JumpKind _jumpKind) 
	{
		float fResult = 0;
		if (_jumpKind == JumpKind.fly)
		{
			fResult = _AcFly.Evaluate(_time);
		}
		else if (_jumpKind == JumpKind.normal)
		{
			fResult = _AcJump.Evaluate(_time);
		}
		else if (_jumpKind == JumpKind.stunt)
		{
			fResult = _AcJumpSkill.Evaluate(_time);
		}
		else if (_jumpKind == JumpKind.spring)
		{
			fResult = _AcSpring.Evaluate(_time);
		}

		return fResult;
    }
	
}
