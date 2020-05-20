using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMonsterScript : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void OnPickedUp(MonsterReborn item)
    {
        if (item.PickupIsMine)
        {
            Debug.Log("我擊敗怪物了,獲得經驗值!");
           // PhotonNetwork.player.AddScore(1);
        }
        else
        {
            Debug.Log("別人擊敗怪物了. 我必須加油!");
            //可能要把血量歸零 //萬一他們打到同樣的怪物
        }
    }
}
