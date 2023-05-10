using System.Collections;
using UnityEngine;
public enum MsgDlgFood
{
	btnFood,
	btnSuper,
	btnAdd
}
public enum ParamDlgFood
{
	supFood,
	food,
	size
}
public class DlgFood: DlgBase 
{
	private deleMsgDlg	onMsgDlg;

	[SerializeField] protected  UILabel		_TxtFoodCnt;
	[SerializeField] protected  UILabel		_TxtSupFoodCnt;
    static public void OpenDlg(deleMsgDlg _msgDlgFood)
    {
        GameObject obj		= Instantiate(Resources.Load("Prefabs/Dlg/pfDlgFood")) as GameObject;
        Transform trans		= obj.transform;
        trans.parent		= GameObject.Find("CameraUI").GetComponent<Transform>();
        trans.localPosition = Vector3.zero;
        trans.localRotation = Quaternion.identity;
        trans.localScale	= Vector3.one;

        NGUITools.AdjustDepth(obj, depth);
		DlgFood script = obj.GetComponent<DlgFood>();
        script.Init(_msgDlgFood);
    }

    public void Init(deleMsgDlg _msgDlgFood)
    {
        onOpen();
		onMsgDlg = _msgDlgFood;
		_TxtFoodCnt.text    = NGUIText.SpaceDigitString(GD.dtFoodCnt);
		_TxtSupFoodCnt.text = NGUIText.SpaceDigitString(GD.dtSuperFoodCnt);
	}

    public void OnClickBtn(GameObject _gameObj)
    {
        switch (_gameObj.name)
        {
		case "btnClose":
			msgEscapeKey();
			break;

		case "btnAdd":
			onMsgDlg(MsgDlgFood.btnAdd);
			break;

		case "btnFood":
			onMsgDlg(MsgDlgFood.btnFood);
			_TxtFoodCnt.text = NGUIText.SpaceDigitString(GD.dtFoodCnt);
			break;

		case "btnSuper":
			onMsgDlg(MsgDlgFood.btnSuper);
			_TxtSupFoodCnt.text = NGUIText.SpaceDigitString(GD.dtSuperFoodCnt);
			break;
		}
    }
}
