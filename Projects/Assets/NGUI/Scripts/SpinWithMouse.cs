using UnityEngine;

[AddComponentMenu("NGUI/Examples/Spin With Mouse")]
public class SpinWithMouse : MonoBehaviour
{	
	public float speed = 1f;	
	Transform mTrans;

	void Start ()
	{
		mTrans = transform;
	}

	void Update ()
	{
        mTrans.localRotation = Quaternion.Euler(0f, speed * Time.deltaTime, 0f) * mTrans.localRotation;
	}	
}