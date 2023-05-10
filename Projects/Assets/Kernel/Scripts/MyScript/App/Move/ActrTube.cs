using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActrTube : MonoBehaviour
{
    int id = 0;
    [SerializeField] UISprite _SprSector;
    [SerializeField] Collider[] _Colliders;
    void Start()
    {
        Sprite(false);
    }

    void Update()
    {
        
    }

    public void Sprite(bool _state)
    {
        if (_state)
        {
            _SprSector.color = Color.red;
            _SprSector.alpha = 0.3f;
        }
        else
        {
            _SprSector.color = Color.blue;
            _SprSector.alpha = 0.1f;
        }
    }
    public bool IsContained (ActrBall _ball)
    {
        Collider c = _ball.GetComponentInChildren<Collider>();
        for (int i = 0; i < _Colliders.Length; i++)
        {
            if (_Colliders[i].bounds.Intersects(c.bounds))
                return true;
        }
        return false;
    }
}
