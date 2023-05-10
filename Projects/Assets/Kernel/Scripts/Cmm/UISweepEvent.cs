//----------------------------------------------
//            NGUI: Next-Gen UI kit
// Copyright © 2011-2016 Tasharen Entertainment
//----------------------------------------------

using UnityEngine;

/// <summary>
/// This script, when attached to a panel turns it into a scroll view.
/// You can then attach UIDragScrollView to colliders within to make it draggable.
/// </summary>

//[ExecuteInEditMode]
//[RequireComponent(typeof(UIPanel))]
//[AddComponentMenu("NGUI/Interaction/Scroll View")]
public class UISweepEvent : MonoBehaviour
{
	static public BetterList<UIScrollView> list = new BetterList<UIScrollView>();

    public GameObject target;
    public string functionName;

	public enum Movement
	{
        Up,
        Down,
        Left,
        Right,
		Horizontal,
		Vertical,
		Unrestricted,
		Custom,
	}

	/// <summary>
	/// Type of movement allowed by the scroll view.
	/// </summary>

	public Movement movement = Movement.Up;
    
	/// <summary>
	/// Whether the drag operation will be started smoothly, or if if it will be precise (but will have a noticeable "jump").
	/// </summary>

	private bool smoothDragStart = true;
    
	/// <summary>
	/// How much momentum gets applied when the press is released after dragging.
	/// </summary>

	private float momentumAmount = 35f;
    

	protected Transform mTrans;
	protected Plane mPlane;
	protected Vector3 mLastPos;
	protected bool mPressed = false;
	protected Vector3 mMomentum = Vector3.zero;
	protected Vector2 mDragStartOffset = Vector2.zero;
	protected bool mDragStarted = false;
    
  
	void Awake ()
	{
	}

	//[System.NonSerialized] bool mStarted = false;

	void OnEnable ()
	{

	}

	void Start ()
	{
        mTrans = transform;
    }
    
	/// <summary>
	/// Create a plane on which we will be performing the dragging.
	/// </summary>

	public void Press (bool pressed)
	{
		if (UICamera.currentScheme == UICamera.ControlScheme.Controller) return;

		if (smoothDragStart && pressed)
		{
			mDragStarted = false;
			mDragStartOffset = Vector2.zero;
		}

		if (enabled && NGUITools.GetActive(gameObject))
		{
			//if (!pressed && mDragID == UICamera.currentTouchID) mDragID = -10;
            
			mPressed = pressed;

			if (pressed)
			{
				// Remove all momentum on press
				mMomentum = Vector3.zero;

                
				// Remember the hit position
				mLastPos = UICamera.lastWorldPosition;

				// Create the plane to drag along
				mPlane = new Plane(mTrans.rotation * Vector3.back, mLastPos);
                

				Vector3 v = mTrans.localPosition;
				v.x = Mathf.Round(v.x);
				v.y = Mathf.Round(v.y);
				mTrans.localPosition = v;

				if (!smoothDragStart)
				{
					mDragStarted = true;
					mDragStartOffset = Vector2.zero;
				}
			}
		}
	}

	/// <summary>
	/// Drag the object along the plane.
	/// </summary>

	public void Drag ()
	{
		if (!mPressed || UICamera.currentScheme == UICamera.ControlScheme.Controller) return;
		if (enabled && NGUITools.GetActive(gameObject))
        {
			// Prevents the drag "jump". Contributed by 'mixd' from the Tasharen forums.
			if (smoothDragStart && !mDragStarted)
			{
				mDragStarted = true;
				mDragStartOffset = UICamera.currentTouch.totalDelta;
			}

			Ray ray = smoothDragStart ?
				UICamera.currentCamera.ScreenPointToRay(UICamera.currentTouch.pos - mDragStartOffset) :
				UICamera.currentCamera.ScreenPointToRay(UICamera.currentTouch.pos);

			float dist = 0f;

			if (mPlane.Raycast(ray, out dist))
			{
				Vector3 currentPos = ray.GetPoint(dist);
				Vector3 offset = currentPos - mLastPos;
				mLastPos = currentPos;

				if (offset.x != 0f || offset.y != 0f || offset.z != 0f)
				{
					offset = mTrans.InverseTransformDirection(offset);
                    if (movement == Movement.Left)
                    {
                        offset.y = 0f;
                        offset.z = 0f;
                        if (offset.x > 0) offset.x = 0;
                    }
                    else if (movement == Movement.Right)
                    {
                        offset.y = 0f;
                        offset.z = 0f;
                        if (offset.x < 0) offset.x = 0;
                    }
                    else if (movement == Movement.Up)
                    {
                        offset.z = 0f;
                        offset.x = 0f;
                        if (offset.y < 0) offset.y = 0;
                    }
                    else if (movement == Movement.Down)
                    {
                        offset.x = 0f;
                        offset.z = 0f;
                        if (offset.y > 0) offset.y = 0;
                    }
                    else if (movement == Movement.Horizontal)
					{
						offset.y = 0f;
						offset.z = 0f;
					}
					else if (movement == Movement.Vertical)
					{
						offset.x = 0f;
						offset.z = 0f;
					}
					else if (movement == Movement.Unrestricted)
					{
						offset.z = 0f;
					}
					offset = mTrans.TransformDirection(offset);
				}
                
				 mMomentum = Vector3.Lerp(mMomentum, mMomentum + offset * (0.01f * momentumAmount), 0.67f);
			}
		}
	}
    
	/// <summary>
	/// If the object should support the scroll wheel, do it.
	/// </summary>

	public void Scroll (float delta)
	{
	}

	/// <summary>
	/// Apply the dragging momentum.
	/// </summary>

	void LateUpdate ()
	{
		if (!Application.isPlaying) return;
        
		// Apply momentum
		if (!mPressed)
		{
			if (mMomentum.magnitude > 0.001f )
                target.SendMessage(functionName, gameObject, SendMessageOptions.DontRequireReceiver);
		}
	}
    
    
        
}
