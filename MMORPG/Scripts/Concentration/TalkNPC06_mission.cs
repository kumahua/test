using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus; //用Fungus的東西

public class TalkNPC06_mission : MonoBehaviour
{
    public Flowchart Mission_Flowchart; //擺入指定的流程圖
    public string onTriggerEnter; //指定名稱要和進入的NPC(Block)名稱一樣
    public GameObject IconExclamationIcons; //把驚嘆號拉到對應的位置
    public GameObject IconExclamationIconsForMap; //把地圖驚嘆號拉到對應的位置

    public string ontipname;
    public GameObject tipobject;
    public string pointername;
    public GameObject pointerobject;
    


    public string Mission //抓fuguns裡面的值
    {
        get { return Mission_Flowchart.GetStringVariable("Mission_Concerntration"); } //指定到對應的欄位
        set { Mission_Flowchart.SetStringVariable("Mission_Concerntration", value); }
    }
    public void Awake()
    {
        IconExclamationIcons = GameObject.Find("ExclamationIcons6"); //初始化抓該NPC的驚嘆號	
        IconExclamationIconsForMap = GameObject.Find("NPC-06Quest");
    }
    // Use this for initialization
    void Start()
    {
        pointerobject = GameObject.Find(pointername);
        pointerobject.SetActive(false);
        tipobject = GameObject.Find(ontipname);
        tipobject.SetActive(true);
        if (Loadcharacter.MissionComplete[8] == true) //如果從資料庫拉資料發現已經玩過這關
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
            tipobject.SetActive(false);
            if (other.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.Z))
            {
                PlayBlock(onTriggerEnter);
                Debug.Log("碰到NPC名稱:" + onTriggerEnter + ",且玩家TAG為Player"); //設定碰到編號NPC
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        PhotonView photonView = other.gameObject.GetComponent<PhotonView>();
        if (photonView != null && !photonView.isMine)
        {
            return;

        }
        else
        {
            tipobject.SetActive(true);
        }
    }
    void Mission_Concerntration() //任務接受後,執行函式
    {
        if (Mission == "Ing")//任務正在進行
        {
            IconExclamationIcons.SetActive(false);
            MissionUI.NotCompletedMission[7].SetActive(false);
            MissionUI.ProcessingMisssion[7].SetActive(true); //UI開啟
            MissionUI.CompletedMission[7].SetActive(false);
            MissionUI.MissionView.SetActive(true);
            pointerobject.SetActive(true);//開始測量的地方
            //InformationViewUIscript.InformationView.SetActive(true);
            MissionListUI.MissionListUIstate[7].SetActive(true);
        }
        if (Mission == "Done")//任務完成一部分
        {
            
            
        }
        if (Mission == "Over")//任務結束
        {
            MissionUI.NotCompletedMission[7].SetActive(false);
            MissionUI.ProcessingMisssion[7].SetActive(false); //UI開啟
            MissionUI.CompletedMission[7].SetActive(true);
            MissionListUI.MissionListUIPic[7].SetActive(false);
            MissionListUI.MissionListUIPic[21].SetActive(true);
            pointerobject.SetActive(false);
        }
    }

}
