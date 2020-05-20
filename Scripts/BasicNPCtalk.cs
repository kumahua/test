using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus; //用Fungus的東西

public class BasicNPCtalk : MonoBehaviour {
    public Flowchart Mission_Flowchart; //擺入指定的流程圖
    public string onTriggerEnter; //指定名稱要和進入的NPC(Block)名稱一樣
    public GameObject Icon; //把驚嘆號拉到對應的位置
    public string Iconstring; //驚嘆號名稱
/*
    public string Mission //抓fuguns裡面的值
    {
        get { return Mission_Flowchart.GetStringVariable("Mission_State"); } //指定到對應的欄位

    }
*/

    // Use this for initialization
    void Start ()
    {
        Icon = GameObject.Find(Iconstring);
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
    void PlayBlock(string targetBlcokName) //設定要撥放的對話名稱
    {

        Block targetBlock = Mission_Flowchart.FindBlock(onTriggerEnter);//名稱要和進入的NPC名稱一樣
        if (targetBlock != null)
        {
            Mission_Flowchart.ExecuteBlock(targetBlock);
        }
        else
        {
            Debug.LogError("找不到在" + Mission_Flowchart.name + "裡的" + targetBlcokName + "Block"); //錯誤訊息 表示找不到相對應的對話物件
        }
    }
    void OnTriggerStay(Collider other) //觸發開始
    {
        PhotonView photonView = other.gameObject.GetComponent<PhotonView>();
        if (photonView != null && !photonView.isMine) 
        {
            return;

        }
        else
        {
            if (other.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.Z))//觸發開始
            {
                PlayBlock(onTriggerEnter);
                Debug.Log("碰到NPC名稱:" + onTriggerEnter + ",且玩家TAG為Player"); //設定碰到編號NPC
            }
        }
    }
 
    void Mission_Introduce()//基礎任務函式
    {
        Icon.SetActive(false);
    }

    void Mission_IntroduceAdvance()
    {
        Icon.SetActive(false);
    }

    void Mission_Final() //任務接受後,執行函式
    {
        
    }
}
