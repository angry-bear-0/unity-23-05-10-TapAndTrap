using System.Collections;
using UnityEngine;

public enum MsgDlgRebirth
{
    none,
	btnRebirth,
	bg
}
public enum ParamDlgRebirth
{
	gemCnt,
	requireGemCnt,
	size
}
public class DlgRebirth : DlgBase
{
	private deleMsgDlg	onMsgDlgRebirth;
 	private object		mUsrData;

    private float		rebrithCoolTm		= 1.0f;
    public UISprite		rebrithCoolTmSprite = null;
    public UILabel		keepGemLabel		= null;
    public UILabel		requireGemLabel		= null;
	static public void OpenDlg(deleMsgDlg _onMsgPause)
	{
        GameObject obj		= Instantiate(Resources.Load("Prefabs/Dlg/pfDlgRebirth")) as GameObject;
		Transform trans		= obj.GetComponent<Transform>();
		trans.parent		= GameObject.Find("CameraUI").GetComponent<Transform>();
		trans.localPosition = Vector3.zero;
		trans.localRotation = Quaternion.identity;
		trans.localScale	= Vector3.one;

		NGUITools.AdjustDepth(obj, depth);
        DlgRebirth script = obj.GetComponent<DlgRebirth>();
		script.Init(_onMsgPause);
	}

	public void Init(deleMsgDlg _onMsgPause)
	{
		onOpen();
		onMsgDlgRebirth			= _onMsgPause;
		keepGemLabel.text       = GD.dtGems.ToString();
		requireGemLabel.text    = GD.needGemToRebirth.ToString();

	}
	protected override void onClosedDlg(GameObject _closeBtn)
	{
		if(_closeBtn == null)
		{
			onMsgDlgRebirth(MsgDlgRebirth.none);
		}
		else if(_closeBtn.name == "bg")
		{
			onMsgDlgRebirth(MsgDlgRebirth.bg);
		}
		else if(_closeBtn.name == "btnRebirth")
		{
			onMsgDlgRebirth(MsgDlgRebirth.btnRebirth);
		}
	}
	protected new void Update()
    {
		base.Update();

        if(GD.dtGems <= 0)
        {
            msgEscapeKey();
        }
		else
		{
			rebrithCoolTmSprite.fillAmount = rebrithCoolTm;
			if(rebrithCoolTm > 0)
			{
				rebrithCoolTm -= Time.deltaTime / 4;
				if(rebrithCoolTm <= 0)
				{
					msgEscapeKey();
				}
			}
		}
    }
}
