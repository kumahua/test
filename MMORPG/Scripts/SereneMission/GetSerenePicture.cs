using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class GetSerenePicture : MonoBehaviour {
    public Flowchart Rightpic_Flowchart;
    
    public string onTriggerEnter; //名稱要和進入的NPC名稱一樣
    bool pickuprightpic = false;


    public GameObject selectpic;    //設定一個物件,可以通用
    public string onselectpicname;

    public GameObject seletobjecttip; //Tip文字物件
    public string objecttipname;       //Tip文字

    public string setfungusselectpicname // 選擇答案名稱-設定值給fungus
    {
        get { return Rightpic_Flowchart.GetStringVariable("selectpicname"); } //從Fungus取值
        set { Rightpic_Flowchart.SetStringVariable("selectpicname", value); } //設定給Fungus
    }
    


    // Use this for initialization
    void Start ()
    {
        selectpic = GameObject.Find(onselectpicname);   //抓每個物件的值

        seletobjecttip = GameObject.Find(objecttipname);
        seletobjecttip.SetActive(false);
        
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
    
    void PlayBlock(string targetBlcokName) //設定要撥放的對話名稱
    {

        Block targetBlock = Rightpic_Flowchart.FindBlock(onTriggerEnter);//名稱要和進入的NPC名稱一樣
        if (targetBlock != null)
        {
            Rightpic_Flowchart.ExecuteBlock(targetBlock);
        }
        else
        {
            Debug.LogError("找不到在" + Rightpic_Flowchart.name + "裡的" + targetBlcokName + "Block"); //錯誤訊息 表示找不到相對應的對話物件
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
                pickuprightpic = true;
                if (Input.GetKey(KeyCode.Z) && pickuprightpic == true)
                {                 
                        PlayBlock(onTriggerEnter);
                        setfungusselectpicname = onselectpicname;       // 設定值給fungus                      
                }
            }
        }
    }
    void OnTriggerExit(Collider other)//離開觸發
    {
        pickuprightpic = false;
        seletobjecttip.SetActive(false);
        Debug.Log("離開拾取範圍");
    }

    void ReturnMission()
    {
        Debug.Log("關閉選擇圖片");
        selectpic.SetActive(false);
        seletobjecttip.SetActive(false);
    }

}
