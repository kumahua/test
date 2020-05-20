using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class TalkNPC03_mission : MonoBehaviour {
    public Flowchart NPC3_Mission_Flowchart;
    public string onTriggerEnter; //名稱要和進入的NPC名稱一樣
    public GameObject IconExclamationIcons; //把驚嘆號拉到對應的位置
    public GameObject IconExclamationIconsForMap; //把地圖驚嘆號拉到對應的位置

    public GameObject OldmanTip;
    public string OldmanTipname;

    public string Mission_Subsidy //抓fuguns裡面的值
    {
        get { return NPC3_Mission_Flowchart.GetStringVariable("Mission_Subsidy"); }
        set { NPC3_Mission_Flowchart.SetStringVariable("Mission_Subsidy", value); }

    }
    public void Awake()
    {
        IconExclamationIcons = GameObject.Find("ExclamationIcons3"); //初始化抓該NPC的驚嘆號
        IconExclamationIconsForMap = GameObject.Find("NPC-03Quest");
    }
    // Use this for initialization
    void Start ()
    {
        OldmanTip = GameObject.Find(OldmanTipname);
        OldmanTip.SetActive(false);

        if (Loadcharacter.MissionComplete[3] == true) //如果從資料庫拉資料發現已經玩過這關
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

        Block targetBlock = NPC3_Mission_Flowchart.FindBlock(onTriggerEnter);//名稱要和進入的NPC名稱一樣
        if (targetBlock != null)
        {
            NPC3_Mission_Flowchart.ExecuteBlock(targetBlock);
        }
        else
        {
            Debug.LogError("找不到在" + NPC3_Mission_Flowchart.name + "裡的" + targetBlcokName + "Block"); //錯誤訊息 表示找不到相對應的對話物件
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

            if (other.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.Z ))
            {
                PlayBlock(onTriggerEnter);
                Debug.Log("碰到NPC03,且玩家TAG為Player");
            }
        }
    }

    void Mission_Start()
    {
        if (Mission_Subsidy == "Ing")
        {
            Debug.Log("接受任務 任務狀態" + Mission_Subsidy);
            IconExclamationIcons.SetActive(false);
            MissionUI.NotCompletedMission[2].SetActive(false);
            MissionUI.ProcessingMisssion[2].SetActive(true); //UI開啟
            MissionUI.CompletedMission[2].SetActive(false);
            //InformationViewUIscript.InformationView.SetActive(true);
            MissionUI.MissionView.SetActive(true);
            MissionListUI.MissionListUIstate[2].SetActive(true);

        }
    }
    void Mission_End()
    {
        MissionUI.NotCompletedMission[2].SetActive(false);
        MissionUI.ProcessingMisssion[2].SetActive(false); //UI開啟
        MissionUI.CompletedMission[2].SetActive(true);
        MissionListUI.MissionListUIPic[2].SetActive(false);
        MissionListUI.MissionListUIPic[16].SetActive(true);
    }
    void ShowOldmanpointer()
    {
        if (Mission_Subsidy == "Ing")
        {
            OldmanTip.SetActive(true);
        }
        if (Mission_Subsidy == "Done")
        {
            OldmanTip.SetActive(false);
        }
    }
}
