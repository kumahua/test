using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class Beautify_mission : MonoBehaviour {
    public Flowchart SelectobjFlowchart;
    public string onTriggerEnter; //名稱要和進入的NPC名稱(Block)一樣
    bool Selectobj = false;
    public GameObject selectobject;    //設定一個物件,可以通用
    public GameObject selectobject1;    //設定一個物件,可以通用
    public GameObject selectobject2;    //設定一個物件,可以通用
    public string onselectobjname;
    public string onselectobjname1;
    public string onselectobjname2;

    public GameObject seletobjecttip; //Tip文字物件
    public string objecttipname;       //Tip文字


    public string setfungusselectobjname // 設定值給fungus()
    {
        get { return SelectobjFlowchart.GetStringVariable("selectobjname"); }
        set { SelectobjFlowchart.SetStringVariable("selectobjname", value); }
    }

    public string setfungusselectobjname1 // 設定值給fungus ()
    {
        get { return SelectobjFlowchart.GetStringVariable("selectobjname1"); }
        set { SelectobjFlowchart.SetStringVariable("selectobjname1", value); }
    }
    public string setfungusselectobjname2 // 設定值給fungus ()
    {
        get { return SelectobjFlowchart.GetStringVariable("selectobjname2"); }
        set { SelectobjFlowchart.SetStringVariable("selectobjname2", value); }
    }


    // Use this for initialization
    void Start () {
        selectobject = GameObject.Find(onselectobjname);    //垃圾
        selectobject1 = GameObject.Find(onselectobjname1);  //怪物
        selectobject2 = GameObject.Find(onselectobjname2);  //花
        if (selectobject1 != null)
        {
            selectobject1.SetActive(false); //完整出現
        }
        if (selectobject2 != null)
        {
            selectobject2.SetActive(false); //完整出現
        }

        seletobjecttip = GameObject.Find(objecttipname);
        seletobjecttip.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void PlayBlock(string targetBlcokName) //設定要撥放的對話名稱
    {

        Block targetBlock = SelectobjFlowchart.FindBlock(onTriggerEnter);//名稱要和進入的NPC名稱一樣
        if (targetBlock != null)
        {
            SelectobjFlowchart.ExecuteBlock(targetBlock);
        }
        else
        {
            Debug.LogError("找不到在" + SelectobjFlowchart.name + "裡的" + targetBlcokName + "Block"); //錯誤訊息 表示找不到相對應的對話物件
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
                Selectobj = true;
                if (Input.GetKey(KeyCode.Z) && Selectobj == true)
                {
                    PlayBlock(onTriggerEnter);
                    setfungusselectobjname = onselectobjname;       // 設定值給fungus
                    setfungusselectobjname1 = onselectobjname1;
                    setfungusselectobjname2 = onselectobjname2;
                }
            }
        }
    }
    void OnTriggerExit(Collider other)//離開觸發
    {
        Selectobj = false;
        seletobjecttip.SetActive(false); //提示關閉
    }

    void TrashshowPlanthide()
    {
        selectobject.SetActive(true); //垃圾
        selectobject2.SetActive(false); //花
    }
    void TrashhidePlantshow()
    {
        selectobject.SetActive(false); //垃圾
        selectobject2.SetActive(true); //花
        
    }
}

