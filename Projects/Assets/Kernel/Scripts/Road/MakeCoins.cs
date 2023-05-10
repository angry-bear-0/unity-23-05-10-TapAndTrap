using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeCoins : MonoBehaviour
{
    static public void bottomCoin(Vector3 _coinPos, Vector2 _point, int _num)
    {
        Vector3 mCoinPos = _coinPos;

        for (int i = 0; i < _num; i++)
        {
            mCoinPos.z += 2;
            float mDis = Vector2.Distance(new Vector2(mCoinPos.x, mCoinPos.z), Vector2.zero);
            mCoinPos.x += _point.x - mDis;
            mCoinPos.y = _point.y;

 //           float mAngle = -Cmm.GetAngleFromRightToVector(mCoinPos.x, mCoinPos.z);
//            Quaternion mCoinRot = Quaternion.Euler(0, mAngle, 0) * Quaternion.Euler(0,0,-20);
//            Transform  coin = Instantiate(Resources.Load("prefabs/Road/pfCoin", typeof(Transform)), mCoinPos, mCoinRot) as Transform;
        }
    }

	static public void hurdleCoin(Vector3 _beginPos) 
	{
		float mLength = Vector2.Distance(new Vector2(_beginPos.x, _beginPos.z), Vector2.zero);

		for (int i = 0; i < 6; i++) 
		{
//			float mAngle = -Cmm.GetAngleFromRightToVector(_beginPos.x, _beginPos.z);
//			Quaternion mHurdleRot = Quaternion.Euler(0, mAngle, 0) * Quaternion.Euler(0, 0, -20);
//			Transform coin = Instantiate(Resources.Load("prefabs/Road/pfCoin", typeof(Transform)), _beginPos, mHurdleRot) as Transform;

			_beginPos.z += 1.666f;
			float mDis = Vector2.Distance(new Vector2(_beginPos.x, _beginPos.z), Vector2.zero);
			_beginPos.x += mLength - mDis;
			//if (i < 4)
			//{
			//    _beginPos.y += 0.4f;
			//}
			//else
			//{
			//    _beginPos.y -= 0.4f;
			//}
		}
	}
}
