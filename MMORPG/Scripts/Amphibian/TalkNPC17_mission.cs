using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus; //用Fungus的東西

public class TalkNPC17_mission : MonoBehaviour {

    public Flowchart Mission_Flowchart; //擺入指定的流程圖
    public string onTriggerEnter; //指定名稱要和進入的NPC(Block)名稱一樣
    public GameObject IconExclamationIcons; //把驚嘆號拉到對應的位置
    public GameObject IconExclamationIconsForMap; //把地圖驚嘆號拉到對應的位置

    public GameObject selectAmphibianobject;    //設定一個物件,可以通用
    public string onselectAmphibianobjname;

    public GameObject seletobjecttip; //Tip文字物件
    public string objecttipname;       //Tip文字

    public string setfungusselectAmphibianobjname // 設定值給fungus(中毒香蕉)
    {
        get { return Mission_Flowchart.GetStringVariable("selectAmphibianobjname"); }
        set { Mission_Flowchart.SetStringVariable("selectAmphibianobjname", value); }
    }

    public string Mission //抓fuguns裡面的值
    {
        get { return Mission_Flowchart.GetStringVariable("Mission_Amphibian"); } //指定到對應的欄位
        set { Mission_Flowchart.SetStringVariable("Mission_Amphibian", value); }

    }
    public void Awake()
    {
        IconExclamationIcons = GameObject.Find("ExclamationIcons17"); //初始化抓該NPC的驚嘆號	
        IconExclamationIconsForMap = GameObject.Find("NPC-17Quest");
    }
    // Use this for initialization
    void Start()
    {
        selectAmphibianobject = GameObject.Find(onselectAmphibianobjname);
        seletobjecttip = GameObject.Find(objecttipname);
        seletobjecttip.SetActive(false);
        if (Loadcharacter.MissionComplete[14] == true) //如果從資料庫拉資料發現已經玩過這關
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
    void Update()
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
            seletobjecttip.SetActive(true);
            if (other.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.Z))
            {
                PlayBlock(onTriggerEnter);
                setfungusselectAmphibianobjname = onselectAmphibianobjname;
                Debug.Log("碰到NPC名稱:" + onTriggerEnter + ",且玩家TAG為Player"); //設定碰到編號NPC
            }
        }
    }

    void OnTriggerExit(Collider other)//離開觸發
    {

        seletobjecttip.SetActive(false);

    }

    void Mission_Amphibian() //任務接受後,執行函式
    {
        if (Mission == "Ing")
        {
            IconExclamationIcons.SetActive(false);
            MissionUI.NotCompletedMission[13].SetActive(false);
            MissionUI.ProcessingMisssion[13].SetActive(true); //UI開啟
            MissionUI.CompletedMission[13].SetActive(false);
            MissionUI.MissionView.SetActive(true);
            //InformationViewUIscript.InformationView.SetActive(true);
            MissionListUI.MissionListUIstate[13].SetActive(true);
        }
        if (Mission == "Done")
        {
            MissionUI.NotCompletedMission[13].SetActive(false);
            MissionUI.ProcessingMisssion[13].SetActive(false); //UI開啟
            MissionUI.CompletedMission[13].SetActive(true);
            MissionListUI.MissionListUIPic[13].SetActive(false);
            MissionListUI.MissionListUIPic[27].SetActive(true);
        }
    }
    void ReturnMission()
    {
        Debug.Log("關閉選擇物件");
       selectAmphibianobject.SetActive(false); //有毒消失
    
    }
}
