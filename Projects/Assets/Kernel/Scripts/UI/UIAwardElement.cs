using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAwardElement : MonoBehaviour
{
	[SerializeField] protected int			_Number;
	[SerializeField] protected UILabel		_TxtTitle;
	[SerializeField] protected UILabel		_TxtDesc;
	[SerializeField] protected UILabel		_TxtPrize;
	[SerializeField] protected GameObject	_BtnClaim;
	[SerializeField] protected GameObject	_BtnClaimed;
	[SerializeField] protected GameObject	_BtnProgress;
    [SerializeField] protected UILabel		_TxtPercent;
    [SerializeField] protected UISprite		_SliderPercent;
	[SerializeField] protected GameObject[]	_IconPrizes;


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
		AwardInfo info	= AwardMgr.infos[_Number];
		_TxtTitle.text	= Lang.Get(info.data.title);
		_TxtDesc.text	= Lang.Format(info.data.desc, info.goal);
		_TxtPrize.text	= NGUIText.SpaceDigitString(info.award);

		for (int i = 0; i < _IconPrizes.Length; i ++)
		{
			int curStep = Mathf.Min(_IconPrizes.Length-1, info.stage);
			_IconPrizes[i].SetActive(i == curStep);
		}
		if (info.IsMaxStage())
		{
			_BtnClaimed.SetActive(true);
			_BtnClaim.SetActive(false);
			_BtnProgress.SetActive(false);
		}
		else
		{
			_BtnClaimed.SetActive(false);
			if (info.CanClaim())
			{
				_BtnClaim.SetActive(true);
				_BtnProgress.SetActive(false);
			}
			else
			{
				_BtnClaim.SetActive(false);
				_BtnProgress.SetActive(true);
				float progress = (float)info.value / info.goal;
				_TxtPercent.text = Mathf.FloorToInt(progress * 100).ToString() + "%";
				_SliderPercent.fillAmount = progress;
			}
		}
	}

	public void onClickClaim()
	{
		AwardInfo info	= AwardMgr.infos[_Number];
		int prize = info.Claim();
		if (prize <= 0)
			return;
		GD.dtGems += prize;
		updateUI();
		DlgMe.inst.UpdateCurrencyInfo();
	}
}
