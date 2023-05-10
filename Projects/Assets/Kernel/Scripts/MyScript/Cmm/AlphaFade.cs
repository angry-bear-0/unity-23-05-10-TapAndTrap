using UnityEngine;
using System.Collections;

//[ExecuteInEditMode]

public class AlphaFade : MonoBehaviour {

	public float alpha;
	Material	mMaterial;
	Color		mColor;
	// Use this for initialization
	void Start () 
	{
		mMaterial = GetComponent<Renderer>().material;
		mColor = new Color(1, 1, 1, alpha);
		transform.Rotate(0, 0, Random.Range(0.0f, 360.0f));
	}
	
	// Update is called once per frame
	void Update () 
	{
		mColor.a = alpha;
		mMaterial.SetColor("_Color", mColor);
	}
}
