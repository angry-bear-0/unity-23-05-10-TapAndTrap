using UnityEngine;
public class InputGame: MonoBehaviour 
{
	bool mInit = false;
	private Player mPlayer;
    private void init()
    {
		if(mInit)
			return;
		mInit = true;
		GameMgr.inputMgr.SetSendModule(onInputGame, InputMode.game);
		mPlayer = GameMgr.player;
    }
	// Use this for initialization
	void Start () {
	}

	private void onInputGame(object _inputKind, object _lastPos)
	{
		mPlayer.OnInputGame((InputKind)_inputKind);
	}
	// Update is called once per frame
	void Update () 
	{
		init();
	}
}
