using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class TalkNPC02_mission : MonoBehaviour {
   
    public Flowchart NPC2_Mission_Flowchart;
    public GameObject IconExclamationIcons; //把驚嘆號拉到對應的位置
    public GameObject IconExclamationIconsForMap; //把地圖驚嘆號拉到對應的位置
    public string onTriggerEnter; //名稱要和進入的NPC名稱一樣   

    public string Mission //抓fuguns裡面的值
    {
        get { return NPC2_Mission_Flowchart.GetStringVariable("Mission_Serene"); } //回傳值
        set { NPC2_Mission_Flowchart.SetStringVariable("Mission_Serene", value); }
    }
    

    // Use this for initialization

    void Awake()
    {
        
    }
    void Start ()
    {
       IconExclamationIcons = GameObject.Find("ExclamationIcons2"); //初始化抓該NPC的驚嘆號
       IconExclamationIconsForMap = GameObject.Find("NPC-02Quest");
      
        if (Loadcharacter.MissionComplete[1] == true) //如果從資料庫拉資料發現已經玩過這關
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
        
        Block targetBlock = NPC2_Mission_Flowchart.FindBlock(onTriggerEnter);//名稱要和進入的NPC名稱一樣
        if (targetBlock != null)
        {
            NPC2_Mission_Flowchart.ExecuteBlock(targetBlock);
        }
        else
        {
            Debug.LogError("找不到在" + NPC2_Mission_Flowchart.name+"裡的"+targetBlcokName+"Block"); //錯誤訊息 表示找不到相對應的對話物件
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
            if (other.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.Z))//跟NPC開始對話
            {              
                    PlayBlock(onTriggerEnter);
                    Debug.Log("碰到NPC02,且玩家TAG為Player");              
            }
        }
    }
    void OnTriggerExit(Collider other)//離開觸發
    {
       
        //Debug.Log("離開NPC01");
    }


    void MissionStart()  
    {
        if (Mission == "Ing")
        {

            Debug.Log("接受任務 任務狀態"+Mission);
            IconExclamationIcons.SetActive(false);
            MissionUI.NotCompletedMission[0].SetActive(false);
            MissionUI.ProcessingMisssion[0].SetActive(true); //UI開啟
            MissionUI.CompletedMission[0].SetActive(false);
            MissionUI.MissionView.SetActive(true);
            //InformationViewUIscript.InformationView.SetActive(true);
            MissionListUI.MissionListUIstate[0].SetActive(true);
        }
    }
    void MissionEnd()
    {
        MissionUI.NotCompletedMission[0].SetActive(false);
        MissionUI.ProcessingMisssion[0].SetActive(false);
        MissionUI.CompletedMission[0].SetActive(true);
        MissionListUI.MissionListUIPic[0].SetActive(false);
        MissionListUI.MissionListUIPic[14].SetActive(true);

    }
}
