using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMissionElement : MonoBehaviour
{
	[SerializeField] protected int			_Number;
	[SerializeField] protected UILabel		_TxtDesc;
    [SerializeField] protected UILabel		_TxtPercent;
    [SerializeField] protected UISprite		_SliderPercent;
	[SerializeField] protected GameObject	_Check;
	
    // Start is called before the first frame update
    void Start()
    {
        updateUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	void updateUI()
	{
		MissionInfo mi = MissionMgr.getMision(_Number);
		_TxtDesc.text				= mi.desc;
		float progress				= mi.GetProgress();
		_TxtPercent.text			= Mathf.FloorToInt(progress * 100).ToString() + "%";
		_SliderPercent.fillAmount	= progress;
		_Check.SetActive(progress >= 1);
	}
}
