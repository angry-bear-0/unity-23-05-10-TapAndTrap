using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvtRound : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] UISprite _SprUserAvatar;
    [SerializeField] UISprite _SprUserRole;
    [SerializeField] UILabel _LblUserLimit;

    [SerializeField] UILabel _LblRoundLvl;
    [SerializeField] UISprite[] _TechBuffs;

    [SerializeField] PfTechSlot[] _TechSlots;

    void Start()
    {
        for (int i = 0; i < _TechSlots.Length; i++)
        {
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickButtonMenu()
    {

    }

    public void OnClickButtonControl()
    {

    }
}
