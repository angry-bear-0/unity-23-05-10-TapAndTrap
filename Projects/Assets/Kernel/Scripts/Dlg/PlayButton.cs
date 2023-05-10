using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayButton : MonoBehaviour
{

    public GameObject[] _TweenObj0;
    public GameObject[] _TweenObj1;
    public UIScrollBar _Scroll;
    public BoxCollider[] _BoxCollider;
    public BoxCollider[] _BoxCollider1;
    private Vector3 mFirstCenter = new Vector3(-40, -50, 0);
    private Vector3 mSecCenter = new Vector3(-40, -90, 0);
    private Vector3 mFirstCenter1=new Vector3(0, -50, 0);
    private Vector3 mSecCenter1 = new Vector3(0, -90, 0);
    private Vector3 mFirstSize = new Vector3(450, 100, 0);
    private Vector3 mSecSize = new Vector3(450, 200, 0);
    private Vector3 mFirstSize1 = new Vector3(70, 100, 0);
    private Vector3 mSecSize1 = new Vector3(70, 200, 0);
    private Vector3 mSecCenter2 = new Vector3(-40, -70, 0);
    private Vector3 mSecSize2 = new Vector3(450, 150, 0);
    private Vector3 mSecCenter3 = new Vector3(0, -70, 0);
    private Vector3 mSecSize3 = new Vector3(70, 150, 0);
   // public TweenButton t = null;
    // Use this for initialization
    void Start()
    {

    }

    void OnEnable()
    {
     //   _Scroll.barSize = 0.75f;
       // _Scroll.value = 0.0f;
    }
    // Update is called once per frame
    void Update()
    {

    }
    void playTween(int _index)
    {
        for (int i = 0; i < _TweenObj0.Length; i++)
        {
           
            TweenButton tween0 = _TweenObj0[i].GetComponent<TweenButton>();
            TweenButton tween1 = _TweenObj1[i].GetComponent<TweenButton>();
            if (i == _index)
            {
                if (tween0._IsTween == false)
                {
                    if (4 < _index && _index < 9)
                    {
                        tween0.InitTween();
                        tween1.InitTween();
                        _BoxCollider[i].center = mSecCenter2;
                        _BoxCollider[i].size = mSecSize2;
                        _BoxCollider1[i].center = mSecCenter3;
                        _BoxCollider1[i].size = mSecSize3;
                    }
                    else
                    {
                        tween0.InitTween();
                        tween1.InitTween();
                        _BoxCollider[i].center = mSecCenter;
                        _BoxCollider[i].size = mSecSize;
                        _BoxCollider1[i].center = mSecCenter1;
                        _BoxCollider1[i].size = mSecSize1;
                    }
                    continue;
                }
            }
            if (tween0._IsTween == true)
            {
                tween0.DeinitTween();
                tween1.DeinitTween();
                _BoxCollider[i].center = mFirstCenter;
                _BoxCollider[i].size = mFirstSize;
                _BoxCollider1[i].center = mFirstCenter1;
                _BoxCollider1[i].size = mFirstSize1;
            }
        }
    }

  /*  public void BuyBtn1()
    {
        WarriorInf warriorInf = AvtBuy._ChangePlayer.GetComponent<WarriorInf>();
        switch (AvtBuy._ItemMenuState)
        {
            case AvtBuy.ItemMenuState.Unform:
                warriorInf.ResultModelUnf(0);
                warriorInf.ResultModelUnfUpdate(GameData._UnfDegInf[0]);
                break;
            case AvtBuy.ItemMenuState.Tos:
                warriorInf.ResultModelTos(0);
                break;
            case AvtBuy.ItemMenuState.Bar:
                warriorInf.ResultModelBar(0);
                break;
            case AvtBuy.ItemMenuState.Boot:
                warriorInf.ResultModelBoot(0);
                break;
        }
    }

    public void BuyBtn2()
    {
        WarriorInf warriorInf = AvtBuy._ChangePlayer.GetComponent<WarriorInf>();
        switch (AvtBuy._ItemMenuState)
        {
            case AvtBuy.ItemMenuState.Unform:
                warriorInf.ResultModelUnf(1);
                warriorInf.ResultModelUnfUpdate(GameData._UnfDegInf[1]);
                break;
            case AvtBuy.ItemMenuState.Tos:
                warriorInf.ResultModelTos(1);
                break;
            case AvtBuy.ItemMenuState.Bar:
                warriorInf.ResultModelBar(1);
                break;
            case AvtBuy.ItemMenuState.Boot:
                warriorInf.ResultModelBoot(1);
                break;
        }
    }

    public void BuyBtn3()
    {
        WarriorInf warriorInf = AvtBuy._ChangePlayer.GetComponent<WarriorInf>();
        switch (AvtBuy._ItemMenuState)
        {
            case AvtBuy.ItemMenuState.Unform:
                warriorInf.ResultModelUnf(2);
                warriorInf.ResultModelUnfUpdate(GameData._UnfDegInf[2]);
                break;
            case AvtBuy.ItemMenuState.Tos:
                warriorInf.ResultModelTos(2);
                break;
            case AvtBuy.ItemMenuState.Bar:
                warriorInf.ResultModelBar(2);
                break;
            case AvtBuy.ItemMenuState.Boot:
                warriorInf.ResultModelBoot(2);
                break;
        }
    }
    public void BuyBtn4()
    {
        WarriorInf warriorInf = AvtBuy._ChangePlayer.GetComponent<WarriorInf>();
        switch (AvtBuy._ItemMenuState)
        {
            case AvtBuy.ItemMenuState.Unform:
                warriorInf.ResultModelUnf(3);
                warriorInf.ResultModelUnfUpdate(GameData._UnfDegInf[3]);
                break;
            case AvtBuy.ItemMenuState.Tos:
                warriorInf.ResultModelTos(3);
                break;
            case AvtBuy.ItemMenuState.Bar:
                warriorInf.ResultModelBar(3);
                break;
            case AvtBuy.ItemMenuState.Boot:
                warriorInf.ResultModelBoot(3);
                break;
        }
    }
    public void BuyBtn5()
    {
        WarriorInf warriorInf = AvtBuy._ChangePlayer.GetComponent<WarriorInf>();
        switch (AvtBuy._ItemMenuState)
        {
            case AvtBuy.ItemMenuState.Tos:
                warriorInf.ResultModelTos(4);
                break;
            case AvtBuy.ItemMenuState.Bar:
                warriorInf.ResultModelBar(4);
                break;
            case AvtBuy.ItemMenuState.Boot:
                warriorInf.ResultModelBoot(4);
                break;
        }
    }
    public void BuyBtn6()
    {
        WarriorInf warriorInf = AvtBuy._ChangePlayer.GetComponent<WarriorInf>();
        switch (AvtBuy._ItemMenuState)
        {
            case AvtBuy.ItemMenuState.Tos:
                warriorInf.ResultModelTos(5);
                break;
            case AvtBuy.ItemMenuState.Bar:
                warriorInf.ResultModelBar(5);
                break;
            case AvtBuy.ItemMenuState.Boot:
                warriorInf.ResultModelBoot(5);
                break;
        }
    }
    public void BuyBtn7()
    {
        WarriorInf warriorInf = AvtBuy._ChangePlayer.GetComponent<WarriorInf>();
        switch (AvtBuy._ItemMenuState)
        {
            case AvtBuy.ItemMenuState.Tos:
                warriorInf.ResultModelTos(6);
                break;
            case AvtBuy.ItemMenuState.Bar:
                warriorInf.ResultModelBar(6);
                break;
            case AvtBuy.ItemMenuState.Boot:
                warriorInf.ResultModelBoot(6);
                break;
        }
    }
    public void BuyBtn8()
    {
        WarriorInf warriorInf = AvtBuy._ChangePlayer.GetComponent<WarriorInf>();
        switch (AvtBuy._ItemMenuState)
        {
            case AvtBuy.ItemMenuState.Tos:
                warriorInf.ResultModelTos(7);
                break;
            case AvtBuy.ItemMenuState.Bar:
                warriorInf.ResultModelBar(7);
                break;
            case AvtBuy.ItemMenuState.Boot:
                warriorInf.ResultModelBoot(7);
                break;
        }
    }*/

    public void BtnClick(GameObject _btn)
    {
        switch (_btn.name)
        {
            case "Down0":
			case "frmScore":
                playTween(0);
              //  BuyBtn1();
                break;
            case "Down1":
                playTween(1);
               // BuyBtn2();
                break;
            case "Down2":
                playTween(2);
              //  BuyBtn3();
                break;
            case "Down3":
                playTween(3);
               // BuyBtn4();
                break;
            case "Down4":
                playTween(4);
              //  BuyBtn5();
                break;
            case "Down5":
                playTween(5);
            //    BuyBtn6();
                break;
            case "Down6":
                playTween(6);
             //   BuyBtn7();
                break;
            case "Down7":
                playTween(7);
              //  BuyBtn8();
                break;
            case "Down8":
                playTween(8);
				break;
			case "Down9":
				playTween(9);
				break;
			case "Down10":
				playTween(10);
				break;
			case "Down11":
				playTween(11);
				break;
        }
    }
}
