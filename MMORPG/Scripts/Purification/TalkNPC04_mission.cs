using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class TalkNPC04_mission : MonoBehaviour {
    public Flowchart NPC4_Mission_Flowchart;
    public string onTriggerEnter; //名稱要和進入的NPC名稱一樣
    public GameObject IconExclamationIcons; //把驚嘆號拉到對應的位置
    public GameObject IconExclamationIconsForMap; //把地圖驚嘆號拉到對應的位置
                                                  
    public string Mission //抓fuguns裡面的值
    {
        get { return NPC4_Mission_Flowchart.GetStringVariable("Mission_Purification"); }
        set { NPC4_Mission_Flowchart.SetStringVariable("Mission_Purification", value); }

    }
    public void Awake()
    {
        IconExclamationIcons = GameObject.Find("ExclamationIcons4"); //初始化抓該NPC的驚嘆號
        IconExclamationIconsForMap = GameObject.Find("NPC-04Quest");
    }
    void Start ()
    {
       
        if (Loadcharacter.MissionComplete[4] == true) //如果從資料庫拉資料發現已經玩過這關
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

        Block targetBlock = NPC4_Mission_Flowchart.FindBlock(onTriggerEnter);//名稱要和進入的NPC名稱一樣
        if (targetBlock != null)
        {
            NPC4_Mission_Flowchart.ExecuteBlock(targetBlock);
        }
        else
        {
            Debug.LogError("找不到在" + NPC4_Mission_Flowchart.name + "裡的" + targetBlcokName + "Block"); //錯誤訊息 表示找不到相對應的對話物件
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
            if (other.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.Z))
            {
                PlayBlock(onTriggerEnter);
                Debug.Log("碰到NPC04,且玩家TAG為Player");
            }
        }
    }

    void Mission_Purfifcation()
    {
        if (Mission == "Ing")
        {
            IconExclamationIcons.SetActive(false);
            MissionUI.NotCompletedMission[3].SetActive(false);
            MissionUI.ProcessingMisssion[3].SetActive(true); //UI開啟
            MissionUI.CompletedMission[3].SetActive(false);
            MissionUI.MissionView.SetActive(true);
            //InformationViewUIscript.InformationView.SetActive(true);
            MissionListUI.MissionListUIstate[3].SetActive(true);
        }
        if (Mission == "Done")
        {
            MissionUI.NotCompletedMission[3].SetActive(false);
            MissionUI.ProcessingMisssion[3].SetActive(false); //UI開啟
            MissionUI.CompletedMission[3].SetActive(true);
            MissionListUI.MissionListUIPic[3].SetActive(false);
            MissionListUI.MissionListUIPic[17].SetActive(true);
        }
    }
    void Mission_End()
    {
        MissionUI.ProcessingMisssion[3].SetActive(false);
    }

}
