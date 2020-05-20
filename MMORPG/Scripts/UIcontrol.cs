using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIcontrol : MonoBehaviour {
    //打開MissionList
    public GameObject MissionGlobal;
    public GameObject MissionJingsi;
    public GameObject TopicGrid;
    public bool openandclose = false;
    public bool openandclose2 = false;


    // Use this for initialization
    void Start ()
    {
        MissionJingsi = GameObject.Find("JingsilakeNPCGrid");//順序不能亂
        MissionJingsi.SetActive(false);                      //順序不能亂
        TopicGrid = GameObject.Find("TopicGrid");            //順序不能亂
        MissionGlobal = GameObject.Find("MissionGlobal");    //順序不能亂
        MissionGlobal.SetActive(false); //玩家一進去遊戲就可以選擇任務

        
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
    public void OpenGlobal()
    {
        switch (openandclose)
        {
            case true://關閉視窗
                MissionGlobal.SetActive(false);
                TopicGrid.SetActive(false);
                MissionJingsi.SetActive(false);
                openandclose = false;
                openandclose2 = false;
                //Context.text = "Click the Mission.";
                Debug.Log("視窗關閉!");
                break;
            case false: //打開視窗
                MissionGlobal.SetActive(true);
                TopicGrid.SetActive(true);
                openandclose = true;                         
                //Context.text = "Click the Mission.";
                Debug.Log("視窗開啟!");
                break;
            default:

                break;
        }
    }
    public void CloseGlobal()
    {
        MissionJingsi.SetActive(false);
        MissionGlobal.SetActive(false);
        openandclose = false;
        openandclose2 = false;
        Debug.Log("視窗關閉!");
    }

    public void OpenJingsiLakemission() //只能用兩個單元 三個單元要改參數
    {
        switch (openandclose2)
        {
            case true:  //關閉主視窗
                MissionJingsi.SetActive(false);
                TopicGrid.SetActive(true);
                openandclose2 = false;
                //Context.text = "Click the Mission.";
                Debug.Log("主題視窗開啟!");
                break;
            case false: //打開主視窗
                MissionJingsi.SetActive(true);
                TopicGrid.SetActive(false);
                openandclose2 = true;
                //Context.text = "Click the Mission.";
                Debug.Log("主題視窗關閉!");
                break;
            default:

                break;
        }
    }
    
}
