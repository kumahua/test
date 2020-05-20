using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class DatabaseDetials : MonoBehaviour {
    
    private string Mission_Start_Url = "http://140.115.126.115:3000/Insert_Mission_Start?account="; 
    private string Mission_Fail_Url = "http://140.115.126.115:3000/Insert_Mission_Fail?account=";
    private string Insert_Ans_Url = "http://140.115.126.115:3000/Insert_Answer_State?account=";
    private static string Insert_Button_Click_Url = "http://140.115.126.115:3000/Insert_Button_click?account="; 
    private string Mission_Completed_Url = "http://140.115.126.115:3000/Insert_Mission_Completed?account=";
    private string Count_Monster_Url = "http://140.115.126.115:3000/Update_Count_Monster?account=";
    private string Count_LearningMissionAns_Url = "http://140.115.126.115:3000/Update_LearningMission_Count?account=";
    private static string Count_Transfer_Url = "http://140.115.126.115:3000/Update_Transfer_Count?account=";
    private static string Count_speaking_Url = "http://140.115.126.115:3000/Update_Speaking?account=";
    private static string Count_badges_Url = "http://140.115.126.115:3000/Update_TotalBadges?account=";
    public static int setmonster;
    
    public Flowchart ReviewFlowchart;
    public int monstercounttmp =0;
    public int MonsterCount //抓fuguns裡面的值
    {
        get { return ReviewFlowchart.GetIntegerVariable("MonsterCount"); } //指定到對應的欄位
        //set { ReviewFlowchart.SetIntegerVariable("MonsterCount", value); }
    }

    public int SetMonsterCount //抓fuguns裡面的值
    {
        get { return ReviewFlowchart.GetIntegerVariable("MonsterCount"); }
        set { ReviewFlowchart.SetIntegerVariable("MonsterCount", setmonster); }
    }

    // Use this for initialization
    void Start()
    {
        monstercounttmp = MonsterCount;
        SetMonsterCount = setmonster;     
    }

    // Update is called once per frame
    void Update()
    {
        if (MonsterCount != monstercounttmp)
        {
            monstercounttmp = MonsterCount;
            InsertMonsterCount();
        }
    }


    public void MissionStart1()
    {
        Loadcharacter.Mission_Start[1] = true;
        BagViewScript.setStartMission();
        WWWForm Form = new WWWForm();

        WWW LoginAccountWWW = new WWW(Mission_Start_Url+ LoginScript.Account + "&NPC_ID=1");
        if (LoginAccountWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
    }

    public void MissionStart2()
    {
        Loadcharacter.Mission_Start[2] = true;
        BagViewScript.setStartMission();
        WWWForm Form = new WWWForm();

        WWW LoginAccountWWW = new WWW(Mission_Start_Url + LoginScript.Account + "&NPC_ID=2");
        if (LoginAccountWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
    }

    public void MissionStart3()
    {
        Loadcharacter.Mission_Start[3] = true;
        BagViewScript.setStartMission();
        WWWForm Form = new WWWForm();

        WWW LoginAccountWWW = new WWW(Mission_Start_Url + LoginScript.Account + "&NPC_ID=3");
        if (LoginAccountWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
    }

    public void MissionStart4()
    {
        Loadcharacter.Mission_Start[4] = true;
        BagViewScript.setStartMission();
        WWWForm Form = new WWWForm();

        WWW LoginAccountWWW = new WWW(Mission_Start_Url + LoginScript.Account + "&NPC_ID=4");
        if (LoginAccountWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
    }

    public void MissionStart5()
    {
        Loadcharacter.Mission_Start[5] = true;
        BagViewScript.setStartMission();
        WWWForm Form = new WWWForm();

        WWW LoginAccountWWW = new WWW(Mission_Start_Url + LoginScript.Account + "&NPC_ID=5");
        if (LoginAccountWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
    }

    public void MissionStart6()
    {
        Loadcharacter.Mission_Start[6] = true;
        BagViewScript.setStartMission();
        WWWForm Form = new WWWForm();


        WWW LoginAccountWWW = new WWW(Mission_Start_Url + LoginScript.Account + "&NPC_ID=6");
        if (LoginAccountWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
    }

    public void MissionStart7()
    {
        Loadcharacter.Mission_Start[7] = true;
        BagViewScript.setStartMission();
        WWWForm Form = new WWWForm();

        WWW LoginAccountWWW = new WWW(Mission_Start_Url + LoginScript.Account + "&NPC_ID=7");
        if (LoginAccountWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
    }

    public void MissionStart8()
    {
        Loadcharacter.Mission_Start[8] = true;
        BagViewScript.setStartMission();
        WWWForm Form = new WWWForm();


        WWW LoginAccountWWW = new WWW(Mission_Start_Url + LoginScript.Account + "&NPC_ID=8");
        if (LoginAccountWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
    }

    public void MissionStart9()
    {
        Loadcharacter.Mission_Start[9] = true;
        BagViewScript.setStartMission();
        WWWForm Form = new WWWForm();


        WWW LoginAccountWWW = new WWW(Mission_Start_Url + LoginScript.Account + "&NPC_ID=9");
        if (LoginAccountWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
    }
    public void MissionStart10()
    {
        Loadcharacter.Mission_Start[10] = true;
        BagViewScript.setStartMission();
        WWWForm Form = new WWWForm();

        //Form.AddField("Account", LoginScript.Account);
        //Form.AddField("NPC_ID", "10");
        WWW LoginAccountWWW = new WWW(Mission_Start_Url + LoginScript.Account + "&NPC_ID=10");
        if (LoginAccountWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
    }

    public void MissionStart11()
    {
        Loadcharacter.Mission_Start[11] = true;
        BagViewScript.setStartMission();
        WWWForm Form = new WWWForm();

        //Form.AddField("Account", LoginScript.Account);
        //Form.AddField("NPC_ID", "11");
        WWW LoginAccountWWW = new WWW(Mission_Start_Url + LoginScript.Account + "&NPC_ID=11");
        if (LoginAccountWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
    }

    public void MissionStart12()
    {
        Loadcharacter.Mission_Start[12] = true;
        BagViewScript.setStartMission();
        WWWForm Form = new WWWForm();

        //Form.AddField("Account", LoginScript.Account);
        //Form.AddField("NPC_ID", "12");
        WWW LoginAccountWWW = new WWW(Mission_Start_Url + LoginScript.Account + "&NPC_ID=12");
        if (LoginAccountWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
    }

    public void MissionStart13()
    {
        Loadcharacter.Mission_Start[13] = true;
        BagViewScript.setStartMission();
        WWWForm Form = new WWWForm();

        //Form.AddField("Account", LoginScript.Account);
        //Form.AddField("NPC_ID", "13");
        WWW LoginAccountWWW = new WWW(Mission_Start_Url + LoginScript.Account + "&NPC_ID=13");
        if (LoginAccountWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
    }

    public void MissionStart14()
    {
        Loadcharacter.Mission_Start[14] = true;
        BagViewScript.setStartMission();
        WWWForm Form = new WWWForm();

        //Form.AddField("Account", LoginScript.Account);
        //Form.AddField("NPC_ID", "14");
        WWW LoginAccountWWW = new WWW(Mission_Start_Url + LoginScript.Account + "&NPC_ID=14");
        if (LoginAccountWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
    }

    public void MissionStart29()
    {
        WWWForm Form = new WWWForm();

        //Form.AddField("Account", LoginScript.Account);
        //Form.AddField("NPC_ID", "14");
        WWW LoginAccountWWW = new WWW(Mission_Start_Url + LoginScript.Account + "&NPC_ID=29");
        if (LoginAccountWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
    }
   
    public void MissionFail1()
    {
        WWWForm Form = new WWWForm();

        //Form.AddField("Account", LoginScript.Account);
        //Form.AddField("NPC_ID", "1");
        WWW LoginAccountWWW = new WWW(Mission_Fail_Url + LoginScript.Account + "&NPC_ID=1");
        if (LoginAccountWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
    }

    public void MissionFail2()
    {
        WWWForm Form = new WWWForm();

        //Form.AddField("Account", LoginScript.Account);
        //Form.AddField("NPC_ID", "2");
        WWW LoginAccountWWW = new WWW(Mission_Fail_Url + LoginScript.Account + "&NPC_ID=2");
        if (LoginAccountWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
    }

    public void MissionFail3()
    {
        WWWForm Form = new WWWForm();

        //Form.AddField("Account", LoginScript.Account);
        //Form.AddField("NPC_ID", "3");
        WWW LoginAccountWWW = new WWW(Mission_Fail_Url + LoginScript.Account + "&NPC_ID=3");
        if (LoginAccountWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
    }

    public void MissionFail4()
    {
        WWWForm Form = new WWWForm();

        //Form.AddField("Account", LoginScript.Account);
        //Form.AddField("NPC_ID", "4");
        WWW LoginAccountWWW = new WWW(Mission_Fail_Url + LoginScript.Account + "&NPC_ID=4");
        if (LoginAccountWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
    }

    public void MissionFail5()
    {
        WWWForm Form = new WWWForm();

        //Form.AddField("Account", LoginScript.Account);
        //Form.AddField("NPC_ID", "5");
        WWW LoginAccountWWW = new WWW(Mission_Fail_Url + LoginScript.Account + "&NPC_ID=5");
        if (LoginAccountWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
    }

    public void MissionFail6()
    {
        WWWForm Form = new WWWForm();

        //Form.AddField("Account", LoginScript.Account);
        //Form.AddField("NPC_ID", "6");
        WWW LoginAccountWWW = new WWW(Mission_Fail_Url + LoginScript.Account + "&NPC_ID=6");
        if (LoginAccountWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
    }

    public void MissionFail7()
    {
        WWWForm Form = new WWWForm();

        //Form.AddField("Account", LoginScript.Account);
        //Form.AddField("NPC_ID", "7");
        WWW LoginAccountWWW = new WWW(Mission_Fail_Url + LoginScript.Account + "&NPC_ID=7");
        if (LoginAccountWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
    }

    public void MissionFail8()
    {
        WWWForm Form = new WWWForm();

        //Form.AddField("Account", LoginScript.Account);
        //Form.AddField("NPC_ID", "8");
        WWW LoginAccountWWW = new WWW(Mission_Fail_Url + LoginScript.Account + "&NPC_ID=8");
        if (LoginAccountWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
    }

    public void MissionFail9()
    {
        WWWForm Form = new WWWForm();

        //Form.AddField("Account", LoginScript.Account);
        //Form.AddField("NPC_ID", "9");
        WWW LoginAccountWWW = new WWW(Mission_Fail_Url + LoginScript.Account + "&NPC_ID=9");
        if (LoginAccountWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
    }
    public void MissionFail10()
    {
        WWWForm Form = new WWWForm();

        //Form.AddField("Account", LoginScript.Account);
        //Form.AddField("NPC_ID", "10");
        WWW LoginAccountWWW = new WWW(Mission_Fail_Url + LoginScript.Account + "&NPC_ID=10");
        if (LoginAccountWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
    }

    public void MissionFail11()
    {
        WWWForm Form = new WWWForm();

        //Form.AddField("Account", LoginScript.Account);
        //Form.AddField("NPC_ID", "11");
        WWW LoginAccountWWW = new WWW(Mission_Fail_Url + LoginScript.Account + "&NPC_ID=11");
        if (LoginAccountWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
    }

    public void MissionFail12()
    {
        WWWForm Form = new WWWForm();

        //Form.AddField("Account", LoginScript.Account);
        //Form.AddField("NPC_ID", "12");
        WWW LoginAccountWWW = new WWW(Mission_Fail_Url + LoginScript.Account + "&NPC_ID=12");
        if (LoginAccountWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
    }

    public void MissionFail13()
    {
        WWWForm Form = new WWWForm();

        //Form.AddField("Account", LoginScript.Account);
        //Form.AddField("NPC_ID", "13");
        WWW LoginAccountWWW = new WWW(Mission_Fail_Url + LoginScript.Account + "&NPC_ID=13");
        if (LoginAccountWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
    }

    public void MissionFail14()
    {
        WWWForm Form = new WWWForm();

        //Form.AddField("Account", LoginScript.Account);
        //Form.AddField("NPC_ID", "14");
        WWW LoginAccountWWW = new WWW(Mission_Fail_Url + LoginScript.Account + "&NPC_ID=14");
        if (LoginAccountWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
    }

    public void InsertButtonClick1()
    {
        BagViewScript.badge[10].BadgesCount++;
        WWWForm Form = new WWWForm();

        if (TargetWordUIbutton.WordViewTittle.text != "Unknown Leter")
        {
            //Form.AddField("Account", LoginScript.Account);
            //Form.AddField("Button_ID", "1");
            WWW ButtonClickWWW = new WWW(Insert_Button_Click_Url + LoginScript.Account + "&Button_ID=1");
            if (ButtonClickWWW.error != null)
            {
                Debug.LogError("寫入錯誤");
            }
        }
    }

    public void InsertButtonClick2()
    {
        BagViewScript.badge[10].BadgesCount++;
        WWWForm Form = new WWWForm();
        if (TargetWordUIbutton.WordViewTittle.text != "Unknown Leter")
        {
            //Form.AddField("Account", LoginScript.Account);
            //Form.AddField("Button_ID", "2");
            WWW ButtonClickWWW = new WWW(Insert_Button_Click_Url + LoginScript.Account + "&Button_ID=2");
            if (ButtonClickWWW.error != null)
            {
                Debug.LogError("寫入錯誤");
            }
        }
    }

    public void InsertButtonClick3()
    {
        BagViewScript.badge[10].BadgesCount++;
        WWWForm Form = new WWWForm();
        if (TargetWordUIbutton.WordViewTittle.text != "Unknown Leter")
        {
            //Form.AddField("Account", LoginScript.Account);
            //Form.AddField("Button_ID", "3");
            WWW ButtonClickWWW = new WWW(Insert_Button_Click_Url + LoginScript.Account + "&Button_ID=3");
            if (ButtonClickWWW.error != null)
            {
                Debug.LogError("寫入錯誤");
            }
        }
    }

    public void InsertButtonClick4()
    {
        BagViewScript.badge[10].BadgesCount++;
        WWWForm Form = new WWWForm();
        if (TargetWordUIbutton.WordViewTittle.text != "Unknown Leter")
        {
            //Form.AddField("Account", LoginScript.Account);
            //Form.AddField("Button_ID", "4");
            WWW ButtonClickWWW = new WWW(Insert_Button_Click_Url + LoginScript.Account + "&Button_ID=4");
            if (ButtonClickWWW.error != null)
            {
                Debug.LogError("寫入錯誤");
            }
        }
    }

    public void InsertButtonClick5()
    {
        BagViewScript.badge[10].BadgesCount++;
        WWWForm Form = new WWWForm();
        if (TargetWordUIbutton.WordViewTittle.text != "Unknown Leter")
        {
            //Form.AddField("Account", LoginScript.Account);
            //Form.AddField("Button_ID", "5");
            WWW ButtonClickWWW = new WWW(Insert_Button_Click_Url + LoginScript.Account + "&Button_ID=5");
            if (ButtonClickWWW.error != null)
            {
                Debug.LogError("寫入錯誤");
            }
        }
    }

    public void InsertButtonClick6()
    {
        BagViewScript.badge[10].BadgesCount++;
        WWWForm Form = new WWWForm();
        if (TargetWordUIbutton.WordViewTittle.text != "Unknown Leter")
        {
            //Form.AddField("Account", LoginScript.Account);
            //Form.AddField("Button_ID", "6");
            WWW ButtonClickWWW = new WWW(Insert_Button_Click_Url + LoginScript.Account + "&Button_ID=6");
            if (ButtonClickWWW.error != null)
            {
                Debug.LogError("寫入錯誤");
            }
        }
    }

    public void InsertButtonClick7()
    {
        BagViewScript.badge[10].BadgesCount++;
        WWWForm Form = new WWWForm();
        if (TargetWordUIbutton.WordViewTittle.text != "Unknown Leter")
        {
            //Form.AddField("Account", LoginScript.Account);
            //Form.AddField("Button_ID", "7");
            WWW ButtonClickWWW = new WWW(Insert_Button_Click_Url + LoginScript.Account + "&Button_ID=7");
            if (ButtonClickWWW.error != null)
            {
                Debug.LogError("寫入錯誤");
            }
        }
    }

    public void InsertButtonClick8()
    {
        BagViewScript.badge[10].BadgesCount++;
        WWWForm Form = new WWWForm();
        if (TargetWordUIbutton.WordViewTittle.text != "Unknown Leter")
        {
            //Form.AddField("Account", LoginScript.Account);
            //Form.AddField("Button_ID", "8");
            WWW ButtonClickWWW = new WWW(Insert_Button_Click_Url + LoginScript.Account + "&Button_ID=8");
            if (ButtonClickWWW.error != null)
            {
                Debug.LogError("寫入錯誤");
            }
        }
    }

    public void InsertButtonClick9()
    {
        BagViewScript.badge[10].BadgesCount++;
        WWWForm Form = new WWWForm();
        if (TargetWordUIbutton.WordViewTittle.text != "Unknown Leter")
        {
            //Form.AddField("Account", LoginScript.Account);
            //Form.AddField("Button_ID", "9");
            WWW ButtonClickWWW = new WWW(Insert_Button_Click_Url + LoginScript.Account + "&Button_ID=9");
            if (ButtonClickWWW.error != null)
            {
                Debug.LogError("寫入錯誤");
            }
        }
    }
    public void InsertButtonClick10()
    {
        BagViewScript.badge[10].BadgesCount++;
        WWWForm Form = new WWWForm();
        if (TargetWordUIbutton.WordViewTittle.text != "Unknown Leter")
        {
            //Form.AddField("Account", LoginScript.Account);
            //Form.AddField("Button_ID", "10");
            WWW ButtonClickWWW = new WWW(Insert_Button_Click_Url + LoginScript.Account + "&Button_ID=10");
            if (ButtonClickWWW.error != null)
            {
                Debug.LogError("寫入錯誤");
            }
        }
    }

    public void InsertButtonClick11()
    {
        BagViewScript.badge[10].BadgesCount++;
        WWWForm Form = new WWWForm();
        if (TargetWordUIbutton.WordViewTittle.text != "Unknown Leter")
        {
            //Form.AddField("Account", LoginScript.Account);
            //Form.AddField("Button_ID", "11");
            WWW ButtonClickWWW = new WWW(Insert_Button_Click_Url + LoginScript.Account + "&Button_ID=11");
            if (ButtonClickWWW.error != null)
            {
                Debug.LogError("寫入錯誤");
            }
        }
    }

    public void InsertButtonClick12()
    {
        BagViewScript.badge[10].BadgesCount++;
        WWWForm Form = new WWWForm();
        if (TargetWordUIbutton.WordViewTittle.text != "Unknown Leter")
        {
            //Form.AddField("Account", LoginScript.Account);
            //Form.AddField("Button_ID", "12");
            WWW ButtonClickWWW = new WWW(Insert_Button_Click_Url + LoginScript.Account + "&Button_ID=12");
            if (ButtonClickWWW.error != null)
            {
                Debug.LogError("寫入錯誤");
            }
        }
    }

    public void InsertButtonClick13()
    {
        BagViewScript.badge[10].BadgesCount++;
        WWWForm Form = new WWWForm();
        if (TargetWordUIbutton.WordViewTittle.text != "Unknown Leter")
        {
            //Form.AddField("Account", LoginScript.Account);
            //Form.AddField("Button_ID", "13");
            WWW ButtonClickWWW = new WWW(Insert_Button_Click_Url + LoginScript.Account + "&Button_ID=13");
            if (ButtonClickWWW.error != null)
            {
                Debug.LogError("寫入錯誤");
            }
        }
    }

    public void InsertButtonClick14()
    {
        BagViewScript.badge[10].BadgesCount++;
        WWWForm Form = new WWWForm();
        if (TargetWordUIbutton.WordViewTittle.text != "Unknown Leter")
        {
            //Form.AddField("Account", LoginScript.Account);
            //Form.AddField("Button_ID", "14");
            WWW ButtonClickWWW = new WWW(Insert_Button_Click_Url + LoginScript.Account + "&Button_ID=14");
            if (ButtonClickWWW.error != null)
            {
                Debug.LogError("寫入錯誤");
            }
        }
    }

    /// <summary>
    /// 觀看任務次數
    /// </summary>
    public void InsertButtonClick15()
    {
        BagViewScript.badge[10].BadgesCount++;
        
        WWWForm Form = new WWWForm();
        WWW ButtonClickWWW = new WWW(Insert_Button_Click_Url + LoginScript.Account + "&Button_ID=15");
        if (ButtonClickWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }

        Debug.Log("觀看任務次數"+ AllFunctiosTime.CheckMission);

        BagViewScript.badge[12].BadgesCount++;
        WWW Mission = new WWW(AllFunctiosTime.CheckMissionURL);
        if (Mission.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
    }

    /// <summary>
    /// 任務提示次數
    /// </summary>
    /// 
    public void InsertButtonClick16()
    {
        BagViewScript.badge[10].BadgesCount++;
        WWWForm Form = new WWWForm();
        WWW ButtonClickWWW = new WWW(Insert_Button_Click_Url + LoginScript.Account + "&Button_ID=16");
        if (ButtonClickWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }


        BagViewScript.badge[11].BadgesCount++;

        WWW Tips = new WWW(AllFunctiosTime.MissionTipsURL);
        if (Tips.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
    }

    /// <summary>
    /// 查看地圖次數
    /// </summary>
    public void InsertButtonClick17()
    {
        BagViewScript.badge[10].BadgesCount++;
        WWWForm Form = new WWWForm();
        WWW ButtonClickWWW = new WWW(Insert_Button_Click_Url + LoginScript.Account + "&Button_ID=17");
        if (ButtonClickWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }

        BagViewScript.badge[13].BadgesCount++;
        WWW Map = new WWW(AllFunctiosTime.CheckMapURL);
        if (Map.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
    }

    /// <summary>
    /// 查看獎章次數
    /// </summary>
    public void InsertButtonClick18()
    {
        BagViewScript.badge[10].BadgesCount++;
        BagViewScript.badge[15].BadgesCount++;
        WWW Badges = new WWW(AllFunctiosTime.CheckBadgeListURL);
        if (Badges.error != null)
        {
            Debug.LogError("寫入錯誤");
        }

        WWWForm Form = new WWWForm();
        WWW ButtonClickWWW = new WWW(Insert_Button_Click_Url + LoginScript.Account + "&Button_ID=18");
        if (ButtonClickWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }

      
    }

    /// <summary>
    /// 查看排行榜
    /// </summary>
    public void InsertButtonClick19()
    {
        Debug.Log("查看排行榜");

        BagViewScript.badge[10].BadgesCount++;
        WWWForm Form = new WWWForm();
        WWW ButtonClickWWW = new WWW(Insert_Button_Click_Url + LoginScript.Account + "&Button_ID=19");
        if (ButtonClickWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }

        BagViewScript.badge[14].BadgesCount++;
        WWW Rank = new WWW(AllFunctiosTime.CheckRankListURL);
        if (Rank.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
    }
    public void InsertButtonClick20()
    {
        BagViewScript.badge[10].BadgesCount++;
        WWWForm Form = new WWWForm();
        WWW ButtonClickWWW = new WWW(Insert_Button_Click_Url + LoginScript.Account + "&Button_ID=20");
        if (ButtonClickWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
    }
    public void InsertButtonClick21()
    {
        BagViewScript.badge[10].BadgesCount++;
        WWWForm Form = new WWWForm();
        WWW ButtonClickWWW = new WWW(Insert_Button_Click_Url + LoginScript.Account + "&Button_ID=21");
        if (ButtonClickWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
    }
    public void InsertButtonClick22()
    {
        BagViewScript.badge[10].BadgesCount++;
        WWWForm Form = new WWWForm();
        WWW ButtonClickWWW = new WWW(Insert_Button_Click_Url + LoginScript.Account + "&Button_ID=22");
        if (ButtonClickWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
    }
    public void InsertButtonClick23()
    {
        BagViewScript.badge[10].BadgesCount++;
        WWWForm Form = new WWWForm();
        WWW ButtonClickWWW = new WWW(Insert_Button_Click_Url + LoginScript.Account + "&Button_ID=23");
        if (ButtonClickWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
    }
    public void InsertButtonClick24()
    {
        BagViewScript.badge[10].BadgesCount++;
        WWWForm Form = new WWWForm();
        WWW ButtonClickWWW = new WWW(Insert_Button_Click_Url + LoginScript.Account + "&Button_ID=24");
        if (ButtonClickWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
    }
    public void InsertButtonClick25()
    {
        BagViewScript.badge[10].BadgesCount++;
        WWWForm Form = new WWWForm();
        WWW ButtonClickWWW = new WWW(Insert_Button_Click_Url + LoginScript.Account + "&Button_ID=25");
        if (ButtonClickWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
    }
    public void InsertButtonClick26()
    {
        BagViewScript.badge[10].BadgesCount++;
        WWWForm Form = new WWWForm();
        WWW ButtonClickWWW = new WWW(Insert_Button_Click_Url + LoginScript.Account + "&Button_ID=26");
        if (ButtonClickWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
    }
    public void InsertButtonClick27()
    {
        BagViewScript.badge[10].BadgesCount++;
        WWWForm Form = new WWWForm();
        WWW ButtonClickWWW = new WWW(Insert_Button_Click_Url + LoginScript.Account + "&Button_ID=27");
        if (ButtonClickWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
    }
    public void InsertButtonClick28()
    {
        BagViewScript.badge[10].BadgesCount++;
        WWWForm Form = new WWWForm();
        WWW ButtonClickWWW = new WWW(Insert_Button_Click_Url + LoginScript.Account + "&Button_ID=28");
        if (ButtonClickWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
    }
    public void InsertButtonClick29()
    {
        BagViewScript.badge[10].BadgesCount++;
        WWWForm Form = new WWWForm();
        WWW ButtonClickWWW = new WWW(Insert_Button_Click_Url + LoginScript.Account + "&Button_ID=29");
        if (ButtonClickWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
    }
    public void InsertButtonClick30()
    {
        BagViewScript.badge[10].BadgesCount++;
        WWWForm Form = new WWWForm();
        WWW ButtonClickWWW = new WWW(Insert_Button_Click_Url + LoginScript.Account + "&Button_ID=30");
        if (ButtonClickWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
    }
    public void InsertButtonClick31()
    {
        BagViewScript.badge[10].BadgesCount++;
        WWWForm Form = new WWWForm();
        WWW ButtonClickWWW = new WWW(Insert_Button_Click_Url + LoginScript.Account + "&Button_ID=31");
        if (ButtonClickWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
    }
    public void InsertButtonClick32()
    {
        BagViewScript.badge[10].BadgesCount++;
        WWWForm Form = new WWWForm();
        WWW ButtonClickWWW = new WWW(Insert_Button_Click_Url + LoginScript.Account + "&Button_ID=32");
        if (ButtonClickWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
    }
    public void InsertButtonClick33()
    {
        BagViewScript.badge[10].BadgesCount++;
        WWWForm Form = new WWWForm();
        WWW ButtonClickWWW = new WWW(Insert_Button_Click_Url + LoginScript.Account + "&Button_ID=33");
        if (ButtonClickWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
    }
    public static void InsertBadgeClick()
    {
        BagViewScript.badge[10].BadgesCount++;
        WWWForm Form = new WWWForm();
        WWW ButtonClickWWW = new WWW(Insert_Button_Click_Url + LoginScript.Account + "&Button_ID="+(BagViewScript.CurrentBadge+34));
        if (ButtonClickWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
    }

    /// <summary>
    /// 查看語音排行榜
    /// </summary>
    public void InsertButtonClick50()
    {
        BagViewScript.badge[10].BadgesCount++;
        WWWForm Form = new WWWForm();
        WWW ButtonClickWWW = new WWW(Insert_Button_Click_Url + LoginScript.Account + "&Button_ID=50");
        if (ButtonClickWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }

        BagViewScript.badge[16].BadgesCount++;
        WWW AccuracyList = new WWW(AllFunctiosTime.CheckAccuaryListURL);
        if (AccuracyList.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
    }

    public void MissionCompleted1()
    {
        BagViewScript.badge[0].BadgesCount++;
        WWWForm Form = new WWWForm();

       //Form.AddField("Account", LoginScript.Account);
       // Form.AddField("Mission_Completed", "1");
        WWW LoginAccountWWW = new WWW(Mission_Completed_Url + LoginScript.Account + "&NPC_ID=1");
        if (LoginAccountWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
    }

    public void MissionCompleted2()
    {
        BagViewScript.badge[0].BadgesCount++;
        WWWForm Form = new WWWForm();

        //Form.AddField("Account", LoginScript.Account);
        //Form.AddField("Mission_Completed", "2");
        WWW LoginAccountWWW = new WWW(Mission_Completed_Url + LoginScript.Account + "&NPC_ID=2");
        if (LoginAccountWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
    }

    public void MissionCompleted3()
    {
        BagViewScript.badge[0].BadgesCount++;
        WWWForm Form = new WWWForm();

        //Form.AddField("Account", LoginScript.Account);
        //Form.AddField("Mission_Completed", "3");
        WWW LoginAccountWWW = new WWW(Mission_Completed_Url + LoginScript.Account + "&NPC_ID=3");
        if (LoginAccountWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
    }

    public void MissionCompleted4()
    {
        BagViewScript.badge[0].BadgesCount++;
        WWWForm Form = new WWWForm();

        //Form.AddField("Account", LoginScript.Account);
        //Form.AddField("Mission_Completed", "4");
        WWW LoginAccountWWW = new WWW(Mission_Completed_Url + LoginScript.Account + "&NPC_ID=4");
        if (LoginAccountWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
    }

    public void MissionCompleted5()
    {
        BagViewScript.badge[0].BadgesCount++;
        WWWForm Form = new WWWForm();

        //Form.AddField("Account", LoginScript.Account);
        //Form.AddField("Mission_Completed", "5");
        WWW LoginAccountWWW = new WWW(Mission_Completed_Url + LoginScript.Account + "&NPC_ID=5");
        if (LoginAccountWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
    }

    public void MissionCompleted6()
    {
        BagViewScript.badge[0].BadgesCount++;
        WWWForm Form = new WWWForm();

        //Form.AddField("Account", LoginScript.Account);
        //Form.AddField("Mission_Completed", "6");
        WWW LoginAccountWWW = new WWW(Mission_Completed_Url + LoginScript.Account + "&NPC_ID=6");
        if (LoginAccountWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
    }

    public void MissionCompleted7()
    {
        BagViewScript.badge[0].BadgesCount++;
        WWWForm Form = new WWWForm();

        //Form.AddField("Account", LoginScript.Account);
        //Form.AddField("Mission_Completed", "7");
        WWW LoginAccountWWW = new WWW(Mission_Completed_Url + LoginScript.Account + "&NPC_ID=7");
        if (LoginAccountWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
    }

    public void MissionCompleted8()
    {
        BagViewScript.badge[0].BadgesCount++;
        WWWForm Form = new WWWForm();

        //Form.AddField("Account", LoginScript.Account);
        //Form.AddField("Mission_Completed", "8");
        WWW LoginAccountWWW = new WWW(Mission_Completed_Url + LoginScript.Account + "&NPC_ID=8");
        if (LoginAccountWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
    }

    public void MissionCompleted9()
    {
        BagViewScript.badge[0].BadgesCount++;
        WWWForm Form = new WWWForm();

        //Form.AddField("Account", LoginScript.Account);
        //Form.AddField("Mission_Completed", "9");
        WWW LoginAccountWWW = new WWW(Mission_Completed_Url + LoginScript.Account + "&NPC_ID=9");
        if (LoginAccountWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
    }
    public void MissionCompleted10()
    {
        BagViewScript.badge[0].BadgesCount++;
        WWWForm Form = new WWWForm();

        //Form.AddField("Account", LoginScript.Account);
        //Form.AddField("Mission_Completed", "10");
        WWW LoginAccountWWW = new WWW(Mission_Completed_Url + LoginScript.Account + "&NPC_ID=10");
        if (LoginAccountWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
    }

    public void MissionCompleted11()
    {
        BagViewScript.badge[0].BadgesCount++;
        WWWForm Form = new WWWForm();

        //Form.AddField("Account", LoginScript.Account);
        //Form.AddField("Mission_Completed", "11");
        WWW LoginAccountWWW = new WWW(Mission_Completed_Url + LoginScript.Account + "&NPC_ID=11");
        if (LoginAccountWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
    }

    public void MissionCompleted12()
    {
        BagViewScript.badge[0].BadgesCount++;
        WWWForm Form = new WWWForm();

        //Form.AddField("Account", LoginScript.Account);
        //Form.AddField("Mission_Completed", "12");
        WWW LoginAccountWWW = new WWW(Mission_Completed_Url + LoginScript.Account + "&NPC_ID=12");
        if (LoginAccountWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
    }

    public void MissionCompleted13()
    {
        BagViewScript.badge[0].BadgesCount++;
        WWWForm Form = new WWWForm();

        //Form.AddField("Account", LoginScript.Account);
        //Form.AddField("Mission_Completed", "13");
        WWW LoginAccountWWW = new WWW(Mission_Completed_Url + LoginScript.Account + "&NPC_ID=13");
        if (LoginAccountWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
    }

    public void MissionCompleted14()
    {
        BagViewScript.badge[0].BadgesCount++;
        WWWForm Form = new WWWForm();

        //Form.AddField("Account", LoginScript.Account);
        //Form.AddField("Mission_Completed", "14");
        WWW LoginAccountWWW = new WWW(Mission_Completed_Url + LoginScript.Account + "&NPC_ID=14");
        if (LoginAccountWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
    }
    public void MissionCompleted29()
    {
        WWWForm Form = new WWWForm();

        //Form.AddField("Account", LoginScript.Account);
        //Form.AddField("Mission_Completed", "14");
        WWW LoginAccountWWW = new WWW(Mission_Completed_Url + LoginScript.Account + "&NPC_ID=29");
        if (LoginAccountWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
    }
   
    public void InsertMonsterCount()
    {
        BagViewScript.badge[3].BadgesCount = MonsterCount;
        WWWForm Form = new WWWForm();

        //Form.AddField("Account", LoginScript.Account);
        //Form.AddField("Count_Monster", MonsterCount);
        WWW LoginAccountWWW = new WWW(Count_Monster_Url + LoginScript.Account + "&monster=" + MonsterCount);
        if (LoginAccountWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }

    }

    public void UpdateLearningMissionAnsCount()
    {
        WWWForm Form = new WWWForm();

        //Form.AddField("Account", LoginScript.Account);
        WWW LoginAccountWWW = new WWW(Count_LearningMissionAns_Url + LoginScript.Account);
        if (LoginAccountWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }

    }

    public static void UpdateTransferCount()
    {
        WWWForm Form = new WWWForm();

        //Form.AddField("Account", LoginScript.Account);
        WWW LoginAccountWWW = new WWW(Count_Transfer_Url+ LoginScript.Account);
        if (LoginAccountWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }

    }

    public static void UpdateSpeakingCount()
    {
        WWWForm Form = new WWWForm();

        //Form.AddField("Account", LoginScript.Account);
        WWW LoginAccountWWW = new WWW(Count_speaking_Url + LoginScript.Account);
        if (LoginAccountWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }

    }

    public static void UpdateBadgesCount()
    {
        WWWForm Form = new WWWForm();

        //Form.AddField("Account", LoginScript.Account);
        WWW LoginAccountWWW = new WWW(Count_badges_Url + LoginScript.Account+"&badges="+BagViewScript.Badge_Sum);
        if (LoginAccountWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }

    }

    // 列舉任務類別
    public enum MissionStatus
    {
        Learning,
        Practice
    }

    /// <summary>
    /// 紀錄單字發音正確資料
    /// </summary>
    public void RecordVocabularyCorrectResult(MissionStatus status)
    {
        switch (status)
        {
            case MissionStatus.Learning:
                {
                    WWWForm Form = new WWWForm();
                    WWW WWW;
                    WWW = new WWW(AllFunctiosTime.LearningMissionVocabulary + LoginScript.Account + "&status=LearningVocabulary" + "&correct=1");
                    Debug.Log("紀錄答對次數");
                    if (WWW.error != null)
                    {
                        Debug.Log("紀錄答對" + WWW.error);
                        Debug.LogError("寫入錯誤");
                    }
                    break;
                }
            case MissionStatus.Practice:
                {
                    WWWForm Form = new WWWForm();
                    WWW WWW;
                    WWW = new WWW(AllFunctiosTime.LearningMissionVocabulary + LoginScript.Account + "&status=PracticeVocabulary" + "&correct=1");
                    Debug.Log("紀錄答對次數");
                    if (WWW.error != null)
                    {
                        Debug.Log("紀錄答對" + WWW.error);
                        Debug.LogError("寫入錯誤");
                    }
                    break;
                }
        }
    }

    /// <summary>
    /// 紀錄單字發音錯誤資料
    /// </summary>
    public void RecordVocabularyWrongResult(MissionStatus status)
    {
        switch (status)
        {
            case MissionStatus.Learning:
                {
                    WWWForm Form = new WWWForm();
                    WWW WWW;
                    WWW = new WWW(AllFunctiosTime.LearningMissionVocabulary + LoginScript.Account + "&status=LearningVocabulary" + "&wrong=1");
                    Debug.Log("紀錄錯誤次數");
                    if (WWW.error != null)
                    {
                        Debug.Log("紀錄錯誤" + WWW.error);
                        Debug.LogError("寫入錯誤");
                    }
                    break;
                }
            case MissionStatus.Practice:
                {
                    WWWForm Form = new WWWForm();
                    WWW WWW;
                    WWW = new WWW(AllFunctiosTime.LearningMissionVocabulary + LoginScript.Account + "&status=PracticeVocabulary" + "&wrong=1");
                    Debug.Log("紀錄錯誤次數");
                    if (WWW.error != null)
                    {
                        Debug.Log("紀錄錯誤" + WWW.error);
                        Debug.LogError("寫入錯誤");
                    }
                    break;
                }
        }
    }


    /// <summary>
    /// 數字 1~14 都是學習任務，15~28 練習任務
    /// </summary>
    public void InsertWordCorrect1()
    {
        WWWForm Form = new WWWForm();
        
        WWW LoginAccountWWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=1" + "&Mission_State=0" + "&Accuracy=100");
        if (LoginAccountWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
        RecordVocabularyCorrectResult(MissionStatus.Learning);

    }
    public void InsertWordCorrect2()
    {
        WWWForm Form = new WWWForm();

        WWW LoginAccountWWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=2" + "&Mission_State=0" + "&Accuracy=100");
        if (LoginAccountWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
        RecordVocabularyCorrectResult(MissionStatus.Learning);

    }
    public void InsertWordCorrect3()
    {
        WWWForm Form = new WWWForm();

        WWW LoginAccountWWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=3" + "&Mission_State=0" + "&Accuracy=100");
        if (LoginAccountWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
        RecordVocabularyCorrectResult(MissionStatus.Learning);

    }
    public void InsertWordCorrect4()
    {
        WWWForm Form = new WWWForm();

        WWW LoginAccountWWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=4" + "&Mission_State=0" + "&Accuracy=100");
        if (LoginAccountWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
        RecordVocabularyCorrectResult(MissionStatus.Learning);

    }
    public void InsertWordCorrect5()
    {
        WWWForm Form = new WWWForm();

        WWW LoginAccountWWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=5" + "&Mission_State=0" + "&Accuracy=100");
        if (LoginAccountWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
        RecordVocabularyCorrectResult(MissionStatus.Learning);

    }
    public void InsertWordCorrect6()
    {
        WWWForm Form = new WWWForm();

        WWW LoginAccountWWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=6" + "&Mission_State=0" + "&Accuracy=100");
        if (LoginAccountWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
        RecordVocabularyCorrectResult(MissionStatus.Learning);

    }
    public void InsertWordCorrect7()
    {
        WWWForm Form = new WWWForm();

        WWW LoginAccountWWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=7" + "&Mission_State=0" + "&Accuracy=100");
        if (LoginAccountWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
        RecordVocabularyCorrectResult(MissionStatus.Learning);

    }
    public void InsertWordCorrect8()
    {
        WWWForm Form = new WWWForm();

        WWW LoginAccountWWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=8" + "&Mission_State=0" + "&Accuracy=100");
        if (LoginAccountWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
        RecordVocabularyCorrectResult(MissionStatus.Learning);

    }
    public void InsertWordCorrect9()
    {
        WWWForm Form = new WWWForm();

        WWW LoginAccountWWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=9" + "&Mission_State=0" + "&Accuracy=100");
        if (LoginAccountWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
        RecordVocabularyCorrectResult(MissionStatus.Learning);

    }
    public void InsertWordCorrect10()
    {
        WWWForm Form = new WWWForm();

        WWW LoginAccountWWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=10" + "&Mission_State=0" + "&Accuracy=100");
        if (LoginAccountWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
        RecordVocabularyCorrectResult(MissionStatus.Learning);

    }
    public void InsertWordCorrect11()
    {
        WWWForm Form = new WWWForm();

        WWW LoginAccountWWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=11" + "&Mission_State=0" + "&Accuracy=100");
        if (LoginAccountWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
        RecordVocabularyCorrectResult(MissionStatus.Learning);

    }
    public void InsertWordCorrect12()
    {
        WWWForm Form = new WWWForm();

        WWW LoginAccountWWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=12" + "&Mission_State=0" + "&Accuracy=100");
        if (LoginAccountWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
        RecordVocabularyCorrectResult(MissionStatus.Learning);

    }
    public void InsertWordCorrect13()
    {
        WWWForm Form = new WWWForm();

        WWW LoginAccountWWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=13" + "&Mission_State=0" + "&Accuracy=100");
        if (LoginAccountWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
        RecordVocabularyCorrectResult(MissionStatus.Learning);

    }
    public void InsertWordCorrect14()
    {
        WWWForm Form = new WWWForm();

        WWW LoginAccountWWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=14" + "&Mission_State=0" + "&Accuracy=100");
        if (LoginAccountWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
        RecordVocabularyCorrectResult(MissionStatus.Learning);

    }

    public void InsertWordCorrect15()
    {
        WWWForm Form = new WWWForm();

        WWW LoginAccountWWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=15" + "&Mission_State=0" + "&Accuracy=100");
        if (LoginAccountWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
        RecordVocabularyCorrectResult(MissionStatus.Practice);

    }

    public void InsertWordCorrect16()
    {
        WWWForm Form = new WWWForm();

        WWW LoginAccountWWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=16" + "&Mission_State=0" + "&Accuracy=100");
        if (LoginAccountWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
        RecordVocabularyCorrectResult(MissionStatus.Practice);

    }

    public void InsertWordCorrect17()
    {
        WWWForm Form = new WWWForm();

        WWW LoginAccountWWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=17" + "&Mission_State=0" + "&Accuracy=100");
        if (LoginAccountWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
        RecordVocabularyCorrectResult(MissionStatus.Practice);
    }

    public void InsertWordCorrect18()
    {
        WWWForm Form = new WWWForm();

        WWW LoginAccountWWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=18" + "&Mission_State=0" + "&Accuracy=100");
        if (LoginAccountWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
        RecordVocabularyCorrectResult(MissionStatus.Practice);
    }

    public void InsertWordCorrect19()
    {
        WWWForm Form = new WWWForm();

        WWW LoginAccountWWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=19" + "&Mission_State=0" + "&Accuracy=100");
        if (LoginAccountWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
        RecordVocabularyCorrectResult(MissionStatus.Practice);
    }

    public void InsertWordCorrect20()
    {
        WWWForm Form = new WWWForm();

        WWW LoginAccountWWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=20" + "&Mission_State=0" + "&Accuracy=100");
        if (LoginAccountWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
        RecordVocabularyCorrectResult(MissionStatus.Practice);
    }

    public void InsertWordCorrect21()
    {
        WWWForm Form = new WWWForm();

        WWW LoginAccountWWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=21" + "&Mission_State=0" + "&Accuracy=100");
        if (LoginAccountWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
        RecordVocabularyCorrectResult(MissionStatus.Practice);
    }

    public void InsertWordCorrect22()
    {
        WWWForm Form = new WWWForm();

        WWW LoginAccountWWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=22" + "&Mission_State=0" + "&Accuracy=100");
        if (LoginAccountWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
        RecordVocabularyCorrectResult(MissionStatus.Practice);
    }

    public void InsertWordCorrect23()
    {
        WWWForm Form = new WWWForm();

        WWW LoginAccountWWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=23" + "&Mission_State=0" + "&Accuracy=100");
        if (LoginAccountWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
        RecordVocabularyCorrectResult(MissionStatus.Practice);
    }

    public void InsertWordCorrect24()
    {
        WWWForm Form = new WWWForm();

        WWW LoginAccountWWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=24" + "&Mission_State=0" + "&Accuracy=100");
        if (LoginAccountWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
        RecordVocabularyCorrectResult(MissionStatus.Practice);
    }

    public void InsertWordCorrect25()
    {
        WWWForm Form = new WWWForm();

        WWW LoginAccountWWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=25" + "&Mission_State=0" + "&Accuracy=100");
        if (LoginAccountWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
        RecordVocabularyCorrectResult(MissionStatus.Practice);
    }

    public void InsertWordCorrect26()
    {
        WWWForm Form = new WWWForm();

        WWW LoginAccountWWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=26" + "&Mission_State=0" + "&Accuracy=100");
        if (LoginAccountWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
        RecordVocabularyCorrectResult(MissionStatus.Practice);
    }

    public void InsertWordCorrect27()
    {
        WWWForm Form = new WWWForm();

        WWW LoginAccountWWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=27" + "&Mission_State=0" + "&Accuracy=100");
        if (LoginAccountWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
        RecordVocabularyCorrectResult(MissionStatus.Practice);
    }

    public void InsertWordCorrect28()
    {
        WWWForm Form = new WWWForm();

        WWW LoginAccountWWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=28" + "&Mission_State=0" + "&Accuracy=100");
        if (LoginAccountWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
        RecordVocabularyCorrectResult(MissionStatus.Practice);
    }

    public void InsertWordFail1()
    {
        WWWForm Form = new WWWForm();

        WWW LoginAccountWWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=1" + "&Mission_State=0" + "&Accuracy=0");
        if (LoginAccountWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
        RecordVocabularyWrongResult(MissionStatus.Learning);

    }
    public void InsertWordFail2()
    {
        WWWForm Form = new WWWForm();

        WWW LoginAccountWWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=2" + "&Mission_State=0" + "&Accuracy=0");
        if (LoginAccountWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
        RecordVocabularyWrongResult(MissionStatus.Learning);

    }
    public void InsertWordFail3()
    {
        WWWForm Form = new WWWForm();

        WWW LoginAccountWWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=3" + "&Mission_State=0" + "&Accuracy=0");
        if (LoginAccountWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
        RecordVocabularyWrongResult(MissionStatus.Learning);
    }
    public void InsertWordFail4()
    {
        WWWForm Form = new WWWForm();

        WWW LoginAccountWWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=4" + "&Mission_State=0" + "&Accuracy=0");
        if (LoginAccountWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
        RecordVocabularyWrongResult(MissionStatus.Learning);
    }
    public void InsertWordFail5()
    {
        WWWForm Form = new WWWForm();

        WWW LoginAccountWWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=5" + "&Mission_State=0" + "&Accuracy=0");
        if (LoginAccountWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
        RecordVocabularyWrongResult(MissionStatus.Learning);
    }
    public void InsertWordFail6()
    {
        WWWForm Form = new WWWForm();

        WWW LoginAccountWWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=6" + "&Mission_State=0" + "&Accuracy=0");
        if (LoginAccountWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
        RecordVocabularyWrongResult(MissionStatus.Learning);
    }
    public void InsertWordFail7()
    {
        WWWForm Form = new WWWForm();

        WWW LoginAccountWWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=7" + "&Mission_State=0" + "&Accuracy=0");
        if (LoginAccountWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
        RecordVocabularyWrongResult(MissionStatus.Learning);
    }
    public void InsertWordFail8()
    {
        WWWForm Form = new WWWForm();

        WWW LoginAccountWWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=8" + "&Mission_State=0" + "&Accuracy=0");
        if (LoginAccountWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
        RecordVocabularyWrongResult(MissionStatus.Learning);
    }
    public void InsertWordFail9()
    {
        WWWForm Form = new WWWForm();

        WWW LoginAccountWWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=9" + "&Mission_State=0" + "&Accuracy=0");
        if (LoginAccountWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
        RecordVocabularyWrongResult(MissionStatus.Learning);
    }
    public void InsertWordFail10()
    {
        WWWForm Form = new WWWForm();

        WWW LoginAccountWWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=10" + "&Mission_State=0" + "&Accuracy=0");
        if (LoginAccountWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
        RecordVocabularyWrongResult(MissionStatus.Learning);
    }
    public void InsertWordFail11()
    {
        WWWForm Form = new WWWForm();

        WWW LoginAccountWWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=11" + "&Mission_State=0" + "&Accuracy=0");
        if (LoginAccountWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
        RecordVocabularyWrongResult(MissionStatus.Learning);
    }
    public void InsertWordFail12()
    {
        WWWForm Form = new WWWForm();

        WWW LoginAccountWWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=12" + "&Mission_State=0" + "&Accuracy=0");
        if (LoginAccountWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
        RecordVocabularyWrongResult(MissionStatus.Learning);
    }
    public void InsertWordFail13()
    {
        WWWForm Form = new WWWForm();

        WWW LoginAccountWWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=13" + "&Mission_State=0" + "&Accuracy=0");
        if (LoginAccountWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
        RecordVocabularyWrongResult(MissionStatus.Learning);
    }
    public void InsertWordFail14()
    {
        WWWForm Form = new WWWForm();

        WWW LoginAccountWWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=14" + "&Mission_State=0" + "&Accuracy=0");
        if (LoginAccountWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
        RecordVocabularyWrongResult(MissionStatus.Practice);
    }

    public void InsertWordFail15()
    {
        WWWForm Form = new WWWForm();

        WWW LoginAccountWWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=15" + "&Mission_State=0" + "&Accuracy=0");
        if (LoginAccountWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
        RecordVocabularyWrongResult(MissionStatus.Practice);
    }

public void InsertWordFail16()
    {
        WWWForm Form = new WWWForm();

        WWW LoginAccountWWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=16" + "&Mission_State=0" + "&Accuracy=0");
        if (LoginAccountWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
        RecordVocabularyWrongResult(MissionStatus.Practice);
    }
    public void InsertWordFail17()
    {
        WWWForm Form = new WWWForm();

        WWW LoginAccountWWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=17" + "&Mission_State=0" + "&Accuracy=0");
        if (LoginAccountWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
        RecordVocabularyWrongResult(MissionStatus.Practice);
    }
    public void InsertWordFail18()
    {
        WWWForm Form = new WWWForm();

        WWW LoginAccountWWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=18" + "&Mission_State=0" + "&Accuracy=0");
        if (LoginAccountWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
        RecordVocabularyWrongResult(MissionStatus.Practice);
    }
    public void InsertWordFail19()
    {
        WWWForm Form = new WWWForm();

        WWW LoginAccountWWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=19" + "&Mission_State=0" + "&Accuracy=0");
        if (LoginAccountWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
        RecordVocabularyWrongResult(MissionStatus.Practice);
    }
    public void InsertWordFail20()
    {
        WWWForm Form = new WWWForm();

        WWW LoginAccountWWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=20" + "&Mission_State=0" + "&Accuracy=0");
        if (LoginAccountWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
        RecordVocabularyWrongResult(MissionStatus.Practice);
    }
    public void InsertWordFail21()
    {
        WWWForm Form = new WWWForm();

        WWW LoginAccountWWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=21" + "&Mission_State=0" + "&Accuracy=0");
        if (LoginAccountWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
        RecordVocabularyWrongResult(MissionStatus.Practice);
    }
    public void InsertWordFail22()
    {
        WWWForm Form = new WWWForm();

        WWW LoginAccountWWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=22" + "&Mission_State=0" + "&Accuracy=0");
        if (LoginAccountWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
        RecordVocabularyWrongResult(MissionStatus.Practice);
    }
    public void InsertWordFail23()
    {
        WWWForm Form = new WWWForm();

        WWW LoginAccountWWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=23" + "&Mission_State=0" + "&Accuracy=0");
        if (LoginAccountWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
        RecordVocabularyWrongResult(MissionStatus.Practice);
    }
    public void InsertWordFail24()
    {
        WWWForm Form = new WWWForm();

        WWW LoginAccountWWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=24" + "&Mission_State=0" + "&Accuracy=0");
        if (LoginAccountWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
        RecordVocabularyWrongResult(MissionStatus.Practice);
    }
    public void InsertWordFail25()
    {
        WWWForm Form = new WWWForm();

        WWW LoginAccountWWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=25" + "&Mission_State=0" + "&Accuracy=0");
        if (LoginAccountWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
        RecordVocabularyWrongResult(MissionStatus.Practice);
    }
    public void InsertWordFail26()
    {
        WWWForm Form = new WWWForm();

        WWW LoginAccountWWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=26" + "&Mission_State=0" + "&Accuracy=0");
        if (LoginAccountWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
        RecordVocabularyWrongResult(MissionStatus.Practice);
    }
    public void InsertWordFail27()
    {
        WWWForm Form = new WWWForm();

        WWW LoginAccountWWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=27" + "&Mission_State=0" + "&Accuracy=0");
        if (LoginAccountWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
        RecordVocabularyWrongResult(MissionStatus.Practice);
    }
    public void InsertWordFail28()
    {
        WWWForm Form = new WWWForm();

        WWW LoginAccountWWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=28" + "&Mission_State=0" + "&Accuracy=0");
        if (LoginAccountWWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
        RecordVocabularyWrongResult(MissionStatus.Practice);
    }
}

