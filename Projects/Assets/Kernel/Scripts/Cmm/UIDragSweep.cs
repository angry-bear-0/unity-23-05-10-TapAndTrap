//----------------------------------------------
//            NGUI: Next-Gen UI kit
// Copyright © 2011-2016 Tasharen Entertainment
//----------------------------------------------

using UnityEngine;
using System.Collections;

/// <summary>
/// Allows dragging of the specified scroll view by mouse or touch.
/// </summary>

[AddComponentMenu("NGUI/Interaction/Drag Sweap")]
public class UIDragSweep : MonoBehaviour
{
	/// <summary>
	/// Reference to the scroll view that will be dragged by the script.
	/// </summary>

	//public UIScrollView sweepEvent;
    public UISweepEvent sweepEvent;
 	// Legacy functionality, kept for backwards compatibility. Use 'sweepEvent' instead.
	[HideInInspector][SerializeField] UISweepEvent draggablePanel;

	Transform mTrans;
	UISweepEvent mSweep;
	bool mAutoFind = false;
	bool mStarted = false;

	/// <summary>
	/// Automatically find the scroll view if possible.
	/// </summary>

	void OnEnable ()
	{
		mTrans = transform;

		// Auto-upgrade
		if (sweepEvent == null && draggablePanel != null)
		{
			sweepEvent = draggablePanel;
			draggablePanel = null;
		}

		if (mStarted && (mAutoFind || mSweep == null))
			FindsweepEvent();
	}

	/// <summary>
	/// Find the scroll view.
	/// </summary>

	void Start ()
	{
		mStarted = true;
		FindsweepEvent();
	}

	/// <summary>
	/// Find the scroll view to work with.
	/// </summary>

	void FindsweepEvent ()
	{
		// If the scroll view is on a parent, don't try to remember it (as we want it to be dynamic in case of re-parenting)
		UISweepEvent sv = NGUITools.FindInParents<UISweepEvent>(mTrans);

		if (sweepEvent == null || (mAutoFind && sv != sweepEvent))
		{
			sweepEvent = sv;
			mAutoFind = true;
		}
		else if (sweepEvent == sv)
		{
			mAutoFind = true;
		}
		mSweep = sweepEvent;
	}

	[System.NonSerialized] bool mPressed = false;

	/// <summary>
	/// Stop the active dragging operation.
	/// </summary>

	void OnDisable ()
	{
		if (mPressed && mSweep != null && mSweep.GetComponentInChildren<UIWrapContent>() == null)
		{
			mSweep.Press(false);
			mSweep = null;
		}
	}

	/// <summary>
	/// Create a plane on which we will be performing the dragging.
	/// </summary>

	void OnPress (bool pressed)
	{
		mPressed = pressed;

		// If the scroll view has been set manually, don't try to find it again
		if (mAutoFind && mSweep != sweepEvent)
		{
			mSweep = sweepEvent;
			mAutoFind = false;
		}

		if (sweepEvent && enabled && NGUITools.GetActive(gameObject))
		{
			sweepEvent.Press(pressed);
			
			if (!pressed && mAutoFind)
			{
				sweepEvent = NGUITools.FindInParents<UISweepEvent>(mTrans);
				mSweep = sweepEvent;
			}
		}
	}

	/// <summary>
	/// Drag the object along the plane.
	/// </summary>

	void OnDrag (Vector2 delta)
	{
        if (sweepEvent && NGUITools.GetActive(this))
        	sweepEvent.Drag();
    }

	/// <summary>
	/// If the object should support the scroll wheel, do it.
	/// </summary>

	void OnScroll (float delta)
	{
	}

	/// <summary>
	/// Pan the scroll view.
	/// </summary>

	public void OnPan (Vector2 delta)
	{

	}
}
