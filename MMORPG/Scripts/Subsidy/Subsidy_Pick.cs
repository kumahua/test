using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class Subsidy_Pick : MonoBehaviour {
    public Flowchart Rightpicobj_Flowchart;
    public string onTriggerEnter; //名稱要和進入的NPC名稱一樣
    bool pickupobj = false;
    public GameObject selectobject;    //設定一個物件,可以通用
    public string onselectobjname;
    public GameObject  seletobjecttip; //Tip文字物件
    public string objecttipname;       //Tip文字




    public string setfungusselectobjname // 設定值給fungus 
    {
        get { return Rightpicobj_Flowchart.GetStringVariable("selectobjname"); }
        set { Rightpicobj_Flowchart.SetStringVariable("selectobjname", value); }
    }

    // Use this for initialization
    void Start ()
    {
        selectobject = GameObject.Find(onselectobjname);
        seletobjecttip = GameObject.Find(objecttipname);
        seletobjecttip.SetActive(false);
    }

   
  

    // Update is called once per frame
    void Update ()
    {
		
	}

    void PlayBlock(string targetBlcokName) //設定要撥放的對話名稱
    {

        Block targetBlock = Rightpicobj_Flowchart.FindBlock(onTriggerEnter);//名稱要和進入的NPC名稱一樣
        if (targetBlock != null)
        {
            Rightpicobj_Flowchart.ExecuteBlock(targetBlock);
        }
        else
        {
            Debug.LogError("找不到在" + Rightpicobj_Flowchart.name + "裡的" + targetBlcokName + "Block"); //錯誤訊息 表示找不到相對應的對話物件
        }


    }

    void OnTriggerStay(Collider other) //待在觸發裡面會持續判斷
    {
        PhotonView photonView = other.gameObject.GetComponent<PhotonView>(); //判斷是不是點擊的使用者
        if (photonView != null && !photonView.isMine)
        {
            return;
        }
        else
        {
            seletobjecttip.SetActive(true);
            if (other.gameObject.CompareTag("Player"))
            {
               pickupobj = true;
                if (Input.GetKey(KeyCode.Z) && pickupobj == true)
                {
                    PlayBlock(onTriggerEnter);
                    setfungusselectobjname = onselectobjname;       // 設定值給fungus

                }
            }
        }

    }
    void OnTriggerExit(Collider other)//離開觸發
    {
        pickupobj = false;
        seletobjecttip.SetActive(false);
        //Debug.Log("離開拾取範圍");

    }

    void ReturnMission()  //關閉選擇的物件
    {
        //Debug.Log("關閉選擇物件");
        selectobject.SetActive(false);
        seletobjecttip.SetActive(false);
    }

}
