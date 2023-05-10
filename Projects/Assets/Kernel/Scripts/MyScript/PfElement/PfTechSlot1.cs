using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pfTechSlot : MonoBehaviour
{
    protected int mIndex = 0;
    public int index { get { return mIndex; } set { mIndex = value; } }

    [SerializeField] UISprite _SprTech;
    [SerializeField] UISprite _SprDesc;
    [SerializeField] UISprite _SprLock;
    [SerializeField] UILabel _LblDesc;
    [SerializeField] UILabel _LblLock;
    [SerializeField] GameObject _GoParticle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {

    }
}
