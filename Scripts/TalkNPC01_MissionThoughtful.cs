using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class TalkNPC01_MissionThoughtful : MonoBehaviour {
    public Flowchart NPC1_Mission_Flowchart;
    public string onTriggerEnter; //名稱要和進入的NPC名稱一樣
    public GameObject IconExclamationIcons; //把驚嘆號拉到對應的位置
    public GameObject IconExclamationIconsForMap; //把地圖驚嘆號拉到對應的位置

    public string Mission_Thoughtful1 //抓fuguns裡面的值
    {
        get { return NPC1_Mission_Flowchart.GetStringVariable("Mission_Thoughtful1"); }
        set { NPC1_Mission_Flowchart.SetStringVariable("Mission_Thoughtful1", value); }
    }
    public void Awake()
    {
        IconExclamationIcons = GameObject.Find("ExclamationIcons1"); //初始化抓該NPC的驚嘆號
        IconExclamationIconsForMap = GameObject.Find("NPC-01Quest");
    }
    // Use this for initialization
    void Start ()
    {
     
        if (Loadcharacter.MissionComplete[2] == true)  //如果從資料庫拉資料發現已經玩過這關
        {
            IconExclamationIcons.SetActive(false);
            IconExclamationIconsForMap.SetActive(false);
        }
        else
        {
            IconExclamationIcons.SetActive(true);
            IconExclamationIconsForMap.SetActive(true);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
    void PlayBlock(string targetBlcokName) //設定要撥放的對話名稱
    {

        Block targetBlock = NPC1_Mission_Flowchart.FindBlock(onTriggerEnter);//名稱要和進入的NPC名稱一樣
        if (targetBlock != null)
        {
            NPC1_Mission_Flowchart.ExecuteBlock(targetBlock);
        }
        else
        {
            Debug.LogError("找不到在" + NPC1_Mission_Flowchart.name + "裡的" + targetBlcokName + "Block"); //錯誤訊息 表示找不到相對應的對話物件
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
            if (other.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.Z)) //按下 Z 拾取鍵盤
            {
                PlayBlock(onTriggerEnter);
                Debug.Log("碰到NPC01_Thoughtful,且玩家TAG為Player");
            }
        }
    }

    void MissionStart()
    {
        if (Mission_Thoughtful1 == "Ing")
        {
            
            Debug.Log("接受任務 任務狀態" + Mission_Thoughtful1);
            IconExclamationIcons.SetActive(false);
            MissionUI.NotCompletedMission[1].SetActive(false);
            MissionUI.ProcessingMisssion[1].SetActive(true); //UI開啟
            MissionUI.CompletedMission[1].SetActive(false);
            MissionUI.MissionView.SetActive(true);
            //InformationViewUIscript.InformationView.SetActive(true);
            MissionListUI.MissionListUIstate[1].SetActive(true);
        }
    }


    void Thoughtful_Mission() //任務與完成獲得獎勵
    {
        CharacterCreate.Exp = CharacterCreate.Exp + 5 ;
        Debug.Log("完成任務,經驗值增加" + CharacterCreate.Exp);
    }

    void Mission_End()
    {
        MissionUI.NotCompletedMission[1].SetActive(false);
        MissionUI.ProcessingMisssion[1].SetActive(false); //UI開啟
        MissionUI.CompletedMission[1].SetActive(true);
        MissionListUI.MissionListUIPic[1].SetActive(false);
        MissionListUI.MissionListUIPic[15].SetActive(true);
    }
}
