using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionListUI : MonoBehaviour {

    //public bool MissionListButtonClick = false;
   
    // public
    public int windowWidth = 400;   //設定離開視窗大小
    public int windowHight = 150;

    // private                         //設定視窗背景
    Rect windowRect;
    int windowSwitch = 0;              //切換視窗編號
    float alpha = 0;

    #region
    public static GameObject[] MissionListUIPic = new GameObject[28];
    //0-27依序MissionList擺入 MissionListUIPic[14]開始就是複習任務Serene
    public static GameObject[] MissionListUIstate = new GameObject[28];
    //這是顯示任務是否執行中
    #endregion


    void Awake()    //初始化視窗位置
    {
        windowRect = new Rect(
            (Screen.width - windowWidth) / 2,
            (Screen.height - windowHight) / 2,
            windowWidth,
            windowHight);
        MissionListUIPic[0] = GameObject.Find("Mission01NPC");//serene
        MissionListUIPic[1] = GameObject.Find("Mission02NPC");//thoughtful
        MissionListUIPic[2] = GameObject.Find("Mission03NPC");//subsidy
        MissionListUIPic[3] = GameObject.Find("Mission04NPC");//purifiction
        MissionListUIPic[4] = GameObject.Find("Mission05NPC");//detention
        MissionListUIPic[5] = GameObject.Find("Mission06NPC");//beautify
        MissionListUIPic[6] = GameObject.Find("Mission07NPC");//drain
        MissionListUIPic[7] = GameObject.Find("Mission08NPC");//concentration
        MissionListUIPic[8] = GameObject.Find("Mission09NPC");//ecological corridor
        MissionListUIPic[9] = GameObject.Find("Mission10NPC");//picturesque
        MissionListUIPic[10] = GameObject.Find("Mission11NPC");//aquatic
        MissionListUIPic[11] = GameObject.Find("Mission12NPC");//landscaping
        MissionListUIPic[12] = GameObject.Find("Mission13NPC");//biodiversity
        MissionListUIPic[13] = GameObject.Find("Mission14NPC");//amphibian
        MissionListUIPic[14] = GameObject.Find("Mission16NPC");
        MissionListUIPic[15] = GameObject.Find("Mission17NPC");
        MissionListUIPic[16] = GameObject.Find("Mission18NPC");
        MissionListUIPic[17] = GameObject.Find("Mission19NPC");
        MissionListUIPic[18] = GameObject.Find("Mission20NPC");
        MissionListUIPic[19] = GameObject.Find("Mission21NPC");
        MissionListUIPic[20] = GameObject.Find("Mission22NPC");
        MissionListUIPic[21] = GameObject.Find("Mission23NPC");
        MissionListUIPic[22] = GameObject.Find("Mission24NPC");
        MissionListUIPic[23] = GameObject.Find("Mission25NPC");
        MissionListUIPic[24] = GameObject.Find("Mission26NPC");
        MissionListUIPic[25] = GameObject.Find("Mission27NPC");
        MissionListUIPic[26] = GameObject.Find("Mission28NPC");
        MissionListUIPic[27] = GameObject.Find("Mission29NPC");

        MissionListUIstate[0] = GameObject.Find("Text01");
        MissionListUIstate[1] = GameObject.Find("Text02");
        MissionListUIstate[2] = GameObject.Find("Text03");
        MissionListUIstate[3] = GameObject.Find("Text04");
        MissionListUIstate[4] = GameObject.Find("Text05");
        MissionListUIstate[5] = GameObject.Find("Text06");
        MissionListUIstate[6] = GameObject.Find("Text07");
        MissionListUIstate[7] = GameObject.Find("Text08");
        MissionListUIstate[8] = GameObject.Find("Text09");
        MissionListUIstate[9] = GameObject.Find("Text10");
        MissionListUIstate[10] = GameObject.Find("Text11");
        MissionListUIstate[11] = GameObject.Find("Text12");
        MissionListUIstate[12] = GameObject.Find("Text13");
        MissionListUIstate[13] = GameObject.Find("Text14");
        MissionListUIstate[14] = GameObject.Find("Text16");
        MissionListUIstate[15] = GameObject.Find("Text17");
        MissionListUIstate[16] = GameObject.Find("Text18");
        MissionListUIstate[17] = GameObject.Find("Text19");
        MissionListUIstate[18] = GameObject.Find("Text20");
        MissionListUIstate[19] = GameObject.Find("Text21");
        MissionListUIstate[20] = GameObject.Find("Text22");
        MissionListUIstate[21] = GameObject.Find("Text23");
        MissionListUIstate[22] = GameObject.Find("Text24");
        MissionListUIstate[23] = GameObject.Find("Text25");
        MissionListUIstate[24] = GameObject.Find("Text26");
        MissionListUIstate[25] = GameObject.Find("Text27");
        MissionListUIstate[26] = GameObject.Find("Text28");
        MissionListUIstate[27] = GameObject.Find("Text29");
      
        for (int i=14; i<28; i++)
        {
            MissionListUIPic[i].SetActive(true);         
        }
        for (int x=0; x<28;x++)
        {
            MissionListUIstate[x].SetActive(false);
        }
    }

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
    void OnGUI()
    {
        if (windowSwitch <= 29 && windowSwitch >0) //切換視窗
        {
            GUIAlphaColor_0_To_1();
            windowRect = GUI.Window(0, windowRect, CreateWindow, "Confirm Window");
        }     
    }

    void CreateWindow(int windowID)
    {
        GUI.Label(new Rect(100, 50, 300, 30), "Are you sure to select this mission?");

        if (GUI.Button(new Rect(80, 110, 100, 20), "Yes"))
        {
            DatabaseDetials.UpdateTransferCount();
            //執行移動到NPC前面
            switch(windowSwitch)
            {
                case 1:
                    Debug.Log("Serene Npc的位置!" + PersonMovement.MissionPosition);
                    PersonMovement.MissionPosition[1] = true;
                    windowSwitch = 0; //關掉視窗
                    break;
                case 2:
                    Debug.Log("Thoughtful Npc的位置!" + PersonMovement.MissionPosition);
                    PersonMovement.MissionPosition[2] = true;
                    windowSwitch = 0; //關掉視窗
                    break;
                case 3:
                    Debug.Log("Subsidy Npc的位置!" + PersonMovement.MissionPosition);
                    PersonMovement.MissionPosition[3] = true;
                    windowSwitch = 0; //關掉視窗
                    break;
                case 4:
                    Debug.Log("Purificaiton Npc的位置!" + PersonMovement.MissionPosition);
                    PersonMovement.MissionPosition[4] = true;
                    windowSwitch = 0; //關掉視窗
                    break;
                case 5:
                    Debug.Log("Detention Npc的位置!" + PersonMovement.MissionPosition);
                    PersonMovement.MissionPosition[5] = true;
                    windowSwitch = 0; //關掉視窗
                    break;
                case 6:
                    Debug.Log("Beautify Npc的位置!" + PersonMovement.MissionPosition);
                    PersonMovement.MissionPosition[6] = true;
                    windowSwitch = 0; //關掉視窗
                    break;
                case 7:
                    Debug.Log("Drain Npc的位置!" + PersonMovement.MissionPosition);
                    PersonMovement.MissionPosition[7] = true;
                    windowSwitch = 0; //關掉視窗
                    break;
                case 8:
                    Debug.Log("Concentration Npc的位置!" + PersonMovement.MissionPosition);
                    PersonMovement.MissionPosition[8] = true;
                    windowSwitch = 0; //關掉視窗
                    break;
                case 9:
                    Debug.Log("Ecological corridors Npc的位置!" + PersonMovement.MissionPosition);
                    PersonMovement.MissionPosition[9] = true;
                    windowSwitch = 0; //關掉視窗
                    break;
                case 10:
                    Debug.Log("Picturesque Npc的位置!" + PersonMovement.MissionPosition);
                    PersonMovement.MissionPosition[10] = true;
                    windowSwitch = 0; //關掉視窗
                    break;
                case 11:
                    Debug.Log("Aquatic Npc的位置!" + PersonMovement.MissionPosition);
                    PersonMovement.MissionPosition[11] = true;
                    windowSwitch = 0; //關掉視窗
                    break;
                case 12:
                    Debug.Log("Landscaping Npc的位置!" + PersonMovement.MissionPosition);
                    PersonMovement.MissionPosition[12] = true;
                    windowSwitch = 0; //關掉視窗
                    break;
                case 13:
                    Debug.Log("Biodiversity Npc的位置!" + PersonMovement.MissionPosition);
                    PersonMovement.MissionPosition[13] = true;
                    windowSwitch = 0; //關掉視窗
                    break;
                case 14:
                    Debug.Log("Amphibian Npc的位置!" + PersonMovement.MissionPosition);
                    PersonMovement.MissionPosition[14] = true;
                    windowSwitch = 0; //關掉視窗
                    break;
                case 15:
                    Debug.Log("Amphibian Npc的位置!" + PersonMovement.MissionPosition);
                    PersonMovement.MissionPosition[15] = true;
                    windowSwitch = 0; //關掉視窗
                    break;
                case 16:
                    Debug.Log("SereneR Npc的位置!" + PersonMovement.MissionPosition);
                    PersonMovement.MissionPosition[16] = true;
                    windowSwitch = 0; //關掉視窗
                    break;
                case 17:
                    Debug.Log("ThoughtfulR Npc的位置!" + PersonMovement.MissionPosition);
                    PersonMovement.MissionPosition[17] = true;
                    windowSwitch = 0; //關掉視窗
                    break;
                case 18:
                    Debug.Log("SubsidyR Npc的位置!" + PersonMovement.MissionPosition);
                    PersonMovement.MissionPosition[18] = true;
                    windowSwitch = 0; //關掉視窗
                    break;
                case 19:
                    Debug.Log("PurificaitonR Npc的位置!" + PersonMovement.MissionPosition);
                    PersonMovement.MissionPosition[19] = true;
                    windowSwitch = 0; //關掉視窗
                    break;
                case 20:
                    Debug.Log("DetentionReview Npc的位置!" + PersonMovement.MissionPosition);
                    PersonMovement.MissionPosition[20] = true;
                    windowSwitch = 0; //關掉視窗
                    break;
                case 21:
                    Debug.Log("BeautifyReview Npc的位置!" + PersonMovement.MissionPosition);
                    PersonMovement.MissionPosition[21] = true;
                    windowSwitch = 0; //關掉視窗
                    break;
                case 22:
                    Debug.Log("DrainReview Npc的位置!" + PersonMovement.MissionPosition);
                    PersonMovement.MissionPosition[22] = true;
                    windowSwitch = 0; //關掉視窗
                    break;
                case 23:
                    Debug.Log("ConcentrationReview Npc的位置!" + PersonMovement.MissionPosition);
                    PersonMovement.MissionPosition[23] = true;
                    windowSwitch = 0; //關掉視窗
                    break;
                case 24:
                    Debug.Log("Ecological_corridorsReview Npc的位置!" + PersonMovement.MissionPosition);
                    PersonMovement.MissionPosition[24] = true;
                    windowSwitch = 0; //關掉視窗
                    break;
                case 25:
                    Debug.Log("PicturesqueReview Npc的位置!" + PersonMovement.MissionPosition);
                    PersonMovement.MissionPosition[25] = true;
                    windowSwitch = 0; //關掉視窗
                    break;
                case 26:
                    Debug.Log("AquaticReview Npc的位置!" + PersonMovement.MissionPosition);
                    PersonMovement.MissionPosition[26] = true;
                    windowSwitch = 0; //關掉視窗
                    break;
                case 27:
                    Debug.Log("LandscapingReview Npc的位置!" + PersonMovement.MissionPosition);
                    PersonMovement.MissionPosition[27] = true;
                    windowSwitch = 0; //關掉視窗
                    break;
                case 28:
                    Debug.Log("BiodiversityReview Npc的位置!"+ PersonMovement.MissionPosition);
                    PersonMovement.MissionPosition[28] = true;
                    windowSwitch = 0; //關掉視窗
                    break;
                case 29:
                    Debug.Log("AmphibianReview Npc的位置!"+ PersonMovement.MissionPosition);
                    PersonMovement.MissionPosition[29] = true;
                    windowSwitch = 0; //關掉視窗
                    break;
                default:
                    break;
            }
            
        }
        if (GUI.Button(new Rect(220, 110, 100, 20), "Cancel"))
        {
            windowSwitch = 0; //關掉視窗
        }

        GUI.DragWindow();
    }

    void GUIAlphaColor_0_To_1() //動畫
    {
        if (alpha < 1)
        {
            alpha += Time.deltaTime;
            GUI.color = new Color(1, 1, 1, alpha);
        }
    }

    public void Click_Review_Button()
    {
        windowSwitch = 15; //切換視窗
        alpha = 0; // Init Window Alpha Color
        //Debug.Log("點到按鈕了!");
    }

    public void Click_Thoughtful_Button()
    {
        windowSwitch = 2; //切換視窗
        alpha = 0; // Init Window Alpha Color
        //Debug.Log("點到按鈕了!");
    }
    public void Click_ThoughtfulR_Button()
    {
        windowSwitch = 17; //切換視窗
        alpha = 0; // Init Window Alpha Color
    }
    public void Click_Serene_Button()
    {
        windowSwitch = 1; //切換視窗
        alpha = 0; // Init Window Alpha Color
    }
    public void Click_SereneR_Button()
    {
        windowSwitch = 16; //切換視窗
        alpha = 0; // Init Window Alpha Color
    }
    public void Click_Subsidy_Button()
    {
        windowSwitch = 3; //切換視窗
        alpha = 0; // Init Window Alpha Color
    }
    public void Click_SubsidyR_Button()
    {
        windowSwitch = 18; //切換視窗
        alpha = 0; // Init Window Alpha Color
    }
    public void Click_Purification_Button()
    {
        windowSwitch = 4; //切換視窗
        alpha = 0; // Init Window Alpha Color
    }
    public void Click_PurificationR_Button()
    {
        windowSwitch = 19; //切換視窗
        alpha = 0; // Init Window Alpha Color
    }
    public void Click_Detention_Button()
    {
        windowSwitch = 5; //切換視窗
        alpha = 0; // Init Window Alpha Color
    }
    public void Click_DetentionR_Button()
    {
        windowSwitch = 20; //切換視窗
        alpha = 0; // Init Window Alpha Color
    }
    public void Click_Beautify_Button()
    {
        windowSwitch = 6; //切換視窗
        alpha = 0; // Init Window Alpha Color
    }
    public void Click_BeautifyR_Button()
    {
        windowSwitch = 21; //切換視窗
        alpha = 0; // Init Window Alpha Color
    }
    public void Click_Drain_Button()
    {
        windowSwitch = 7; //切換視窗
        alpha = 0; // Init Window Alpha Color
    }
    public void Click_DrainR_Button()
    {
        windowSwitch = 22; //切換視窗
        alpha = 0; // Init Window Alpha Color
    }
    public void Click_Concentration_Button()
    {
        windowSwitch = 8; //切換視窗
        alpha = 0; // Init Window Alpha Color
    }
    public void Click_ConcentrationR_Button()
    {
        windowSwitch = 23; //切換視窗
        alpha = 0; // Init Window Alpha Color
    }
    public void Click_Landscaping_Button()
    {
        windowSwitch = 12; //切換視窗
        alpha = 0; // Init Window Alpha Color
    }
    public void Click_LandscapingR_Button()
    {
        windowSwitch = 27; //切換視窗
        alpha = 0; // Init Window Alpha Color
    }
    public void Click_Biodiversity_Button()
    {
        windowSwitch = 13; //切換視窗
        alpha = 0; // Init Window Alpha Color
    }
    public void Click_BiodiversityR_Button()
    {
        windowSwitch = 28; //切換視窗
        alpha = 0; // Init Window Alpha Color
    }
    public void Click_Picturesque_Button()
    {
        windowSwitch = 10; //切換視窗
        alpha = 0; // Init Window Alpha Color

    }
    public void Click_PicturesqueR_Button()
    {
        windowSwitch = 25; //切換視窗
        alpha = 0; // Init Window Alpha Color
    }
    public void Click_EcologicalCorridors_Button()
    {
        windowSwitch = 9; //切換視窗
        alpha = 0; // Init Window Alpha Color
    }
    public void Click_EcologicalCorridorsR_Button()
    {
        windowSwitch = 24; //切換視窗
        alpha = 0; // Init Window Alpha Color
    }
    public void Click_Aquatic_Button()
    {
        windowSwitch = 11; //切換視窗
        alpha = 0; // Init Window Alpha Color
    }
    public void Click_AquaticR_Button()
    {
        windowSwitch = 26; //切換視窗
        alpha = 0; // Init Window Alpha Color
    }
    public void Click_Amphibian_Button()
    {
        windowSwitch = 14; //切換視窗
        alpha = 0; // Init Window Alpha Color
    }
    public void Click_AmphibianR_Button()
    {
        windowSwitch = 29; //切換視窗
        alpha = 0; // Init Window Alpha Color
    }

}
