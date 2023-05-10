using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppNode : MonoBehaviour
{
    public int index;
    public int[] _NextIndexs;
    [SerializeField] UILabel _LblIndex;
    [SerializeField] UILabel _LblNextIndexs;

    // Start is called before the first frame update

    void Start()
    {
        _LblIndex.text = index.ToString();
        string nextNodeNames = string.Empty;
        for (int i = 0; i < _NextIndexs.Length; i++)
        {
            nextNodeNames += (_NextIndexs[i].ToString() + ",");
        }
        _LblNextIndexs.text = nextNodeNames;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
