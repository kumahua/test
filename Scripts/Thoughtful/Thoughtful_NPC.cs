using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class Thoughtful_NPC : MonoBehaviour {
    public Flowchart Thoughtful_NPC_Flowchart;
    public string onTriggerEnter; //名稱要和進入的NPC名稱一樣

    public GameObject seletobjecttip; //Tip文字物件
    public string objecttipname;       //Tip文字

    // public GameObject IconExclamationIcons; //把驚嘆號拉到對應的位置
    // Use this for initialization
    void Start ()
    {
        seletobjecttip = GameObject.Find(objecttipname); //Tip文字物件
        seletobjecttip.SetActive(false);                 //Tip文字物件先不啟動
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
    void PlayBlock(string targetBlcokName) //設定要撥放的對話名稱
    {

        Block targetBlock = Thoughtful_NPC_Flowchart.FindBlock(onTriggerEnter);//名稱要和進入的NPC名稱一樣
        if (targetBlock != null)
        {
            Thoughtful_NPC_Flowchart.ExecuteBlock(targetBlock);
        }
        else
        {
            Debug.LogError("找不到在" + Thoughtful_NPC_Flowchart.name + "裡的" + targetBlcokName + "Block"); //錯誤訊息 表示找不到相對應的對話物件
        }
    }
    void OnTriggerStay(Collider other) //觸發開始
    {
        PhotonView photonView = other.gameObject.GetComponent<PhotonView>(); //判斷是不是點擊的使用者
        if (photonView != null && !photonView.isMine)
        {
            return;
        }
        else
        {
            seletobjecttip.SetActive(true); //啟動
            if (other.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.Z))
            {
                PlayBlock(onTriggerEnter);
                //Debug.Log("碰到Thoughtful_NPC,且玩家TAG為Player");
            }
        }
    }
    void OnTriggerExit(Collider other)//離開觸發
    {
        seletobjecttip.SetActive(false);
    }
}
