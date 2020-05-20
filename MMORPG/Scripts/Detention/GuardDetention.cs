using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus; //用Fungus的東西

public class GuardDetention : MonoBehaviour {
    public Flowchart Mission_Flowchart; //擺入指定的流程圖
    public string onTriggerEnter; //指定名稱要和進入的NPC(Block)名稱一樣
    public GameObject Fence;

    public GameObject Vicky;
    public GameObject Vickytip;

    public GameObject seletobjecttip; //Tip文字物件
    public string objecttipname;       //Tip文字

    public string Mission //抓fuguns裡面的值
    {
        get { return Mission_Flowchart.GetStringVariable("Mission_Detention"); } //指定到對應的欄位

    }

    // Use this for initialization
    void Start ()
    {
        seletobjecttip = GameObject.Find(objecttipname);
        seletobjecttip.SetActive(false);

        Vicky = GameObject.Find("Detention_Mission_NPC");
        Vickytip = GameObject.Find("VickyTip");
    }
	
	// Update is called once per frame
	void Update () {
		
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
            Vickytip.SetActive(false);
            if (other.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.Z))
            {
                PlayBlock(onTriggerEnter);
                //Debug.Log("碰到NPC名稱:" + onTriggerEnter + ",且玩家TAG為Player"); //設定碰到編號NPC
            }
        }
    }

    void OnTriggerExit(Collider other)//離開觸發
    {
       
        seletobjecttip.SetActive(false);
        Vickytip.SetActive(true);
    }

    void Mission_Fenceclose()
    {
        Fence.SetActive(false);
    }

    void Mission_Vicky()
    {
        Vicky.SetActive(false);

    }


}
