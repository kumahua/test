using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;
using UnityEngine.Sprites;


public class BagViewScript : MonoBehaviour
{
    public Text PlayerName, PlayerLevel, StarPoint;
    public static Text PlayerSkillPoints, PlayerAttack, PlayerSpeed, PlayerDefend, PlayerLucky;
    public Image[] BadgeIcon = new Image[6];
    public Image[] badgeprocess = new Image[6];
    public GameObject[] process = new GameObject[6];
    public GameObject[] badgeview = new GameObject[6];
    public Text[] badgename = new Text[6];
    private string GetBagUrl = "http://140.115.126.115:3000/LoadBag?account=";
    private string UpdateSkillUrl = "http://140.115.126.115:3000/UpdateSkillPoint?account=";
    public string select = null; 
    public int currentPage,tmp, badgetmp=0;
    public static int CurrentBadge, Badge_Sum = 0;// 當點擊獎章後記錄點到哪個
    public static Badges[] badge = new Badges[50];
    public Sprite HideCopperBadge, CopperBadge, SilverBadge, GoldBadge,DiamondBadge,HideDiamondBadge;
    public static float current0, current1, current2, current3, current4, current5, current6, current7, current8, current9, current10;
    public GameObject Control_Badges;

    private void Awake()
    {
        PlayerSkillPoints = GameObject.Find("PlayerSkillPoints").GetComponent<Text>();
        PlayerAttack = GameObject.Find("AttackCurrentValue").GetComponent<Text>();
        PlayerSpeed = GameObject.Find("SpeedCurrentValue").GetComponent<Text>();
        PlayerDefend = GameObject.Find("DefendCurrentValue").GetComponent<Text>();
        PlayerLucky = GameObject.Find("LuckyCurrentValue").GetComponent<Text>();
        Control_Badges = GameObject.Find("ProfileBag/Badge"); // 找控制獎章顯示的物件
        badge[0] = new Badges("完成任務", "完成學習任務 ", " 次", current0, 1, 5, 12, 14, 0);                        //Badges("Mission Accomplished", "Complete the main mission ", " times.", current0, 1, 5, 12, 14,0);              //MissionFinishBadges
        badge[1] = new Badges("獲取任務", "開始學習任務 ", " 次", current1, 1, 5, 12, 99999999,0);                   //Badges("Hit the Road", "Start the main mission ", " times.", current1, 1, 5, 12, 99999999,0);        //MissionStartBadges 
        badge[2] = new Badges("珠光寶氣", "獲得 ", " 金幣", current2, 10, 25, 65, 99999999,0);                       //Badges("Glamorous", "Collect ", " golds.", current2, 10, 25, 65, 99999999,0);     //MoneyBadges
        badge[3] = new Badges("一網打盡", "擊殺 ", " 隻怪", current3, 10, 100, 200, 99999999,0);                     //Badges("Clean Sweep", "kill ", " monsters.", current3, 10, 100, 200, 99999999,0);    //MonsterKillBadges
        badge[4] = new Badges("英聽大師", "使用 ", " 次聽力練習", current4, 8, 30, 60, 100,0);                       //Badges("Listening Master", "Use ", " times listening.", current4, 8, 30, 60, 100,0);            //ListeningBadges  
        badge[5] = new Badges("口說大師", "使用 ", " 次口說練習", current5, 10, 40, 120, 150,0);                     //Badges("Speaking Master", "Use ", " times speaking.", current5, 10, 40, 120, 150,0);          //SpeakingBadges 
        badge[6] = new Badges("能言善道", "單次準確率達90% ", " 次", 0, 3, 10, 25, 35,0);                            //Badges("Smooth Talker", "Single-time accurancy over is 90% ", " times.", 0, 3, 10, 25, 35,0);             //SingleAccuracyBadges 
        badge[7] = new Badges("完美闖關", "整個任務準確率達90% ", " 次", 0, 1, 3, 8, 99999999,0);                    //Badges("Creep before You Walk", "The entire mission accuracy rate is over 90% ", " times.", 0, 1, 3, 8, 99999999,0);        //MissionAccuracyBadges 
        badge[8] = new Badges("真金不怕火煉", "複習任務單次準確率達90% ", " 次", current8, 1, 5, 14, 99999999,0);    //Badges("True Blue Will Never Stain", "Review mission single-time accuracy rate is  over 90% ", " times.", current8, 1, 5, 14, 99999999,0);  //PracticeMissionAccuracyBadges
        badge[9] = new Badges("我是傳奇", "所有任務準確率達 ", "%.", 0 , 80, 85, 90, 95,0);                          //Badges("I Am Legend", "The accuracy rate of all mission is ", "%.", 0 , 80, 85, 90, 95,0);            //WholeMissionAccuracyBadges 
        badge[10]= new Badges("初來乍到", "使用遊戲中的各個功能 ", " 次", current10, 10, 40, 100, 99999999,0);       //Badges("Fresh Off the Boat", "Use the various functions in the game ", " times.", current10, 10, 40, 100, 99999999,0);    //FunctionClickBadges
        badge[11] = new Badges("小聰明", "查看任務提示 ", " 次", AllFunctiosTime.MissionTips, 3, 10, 15, 99999999, 0);
        badge[12] = new Badges("未雨綢繆", "查看任務列表 ", " 次", AllFunctiosTime.CheckMission, 3, 10, 15, 99999999, 0);
        badge[13] = new Badges("方向感", "查看位置提示 ", " 次", AllFunctiosTime.CheckMap, 3, 10, 15, 99999999, 0);
        badge[14] = new Badges("嘆為觀止", "查看排行榜 ", " 次", AllFunctiosTime.CheckRankList, 3, 10, 15, 99999999, 0);
        badge[15] = new Badges("查看獎章", "查看獎章列表 ", " 次", AllFunctiosTime.CheckBadgeList, 3, 10, 15, 99999999, 0);
        badge[16] = new Badges("查看發音準確率", "查看發音準確率 ", " 次", AllFunctiosTime.CheckAccuaryList, 3, 10, 15, 99999999, 0);
        badge[17] = new Badges("艱鉅任務", "學習任務失敗 ", " 次", AllFunctiosTime.LearningMissionFail, 3, 10, 15, 99999999, 0);
        badge[18] = new Badges("能力者", "獲得能力點數 ", " 次", AllFunctiosTime.Point, 3, 10, 15, 99999999, 0);
        badge[19] = new Badges("修練之路", "達成等級 ", " 次", Loadcharacter.LoadLevel, 3, 6, 10, 99999999, 0);
    }
    // Use this for initialization
    void Start()
    {
        //控制是否顯示獎章，區分有無獎章
        if (LoginScript.Reward_Status == 0)
        {
            Control_Badges.SetActive(false);
        }

        currentPage = 0;
        tmp = currentPage * 6;
        PlayerName.text = LoginScript.Account;
        StartCoroutine("GetBag");
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 6; i++)
        {
            badgeview[i].SetActive(true);
            process[i].SetActive(true);
            if ((i + tmp)<20) { 
            BadgeIcon[i].sprite = CurrentIcon(i+tmp);
            badgeprocess[i].transform.localPosition = new Vector3((-90 + 90 * (badge[i+tmp].BadgesCount / badge[i+tmp].CurrentGoal())), 0.0f, 0.0f);
            badgename[i].text = badge[i+tmp].BadgesName;
            }
            else if ((i + tmp) ==20)
            {
                if (badge[0].BadgesCount<badge[0].UnexpectedGoal)
                {
                    BadgeIcon[i].sprite = HideDiamondBadge;
                    process[i].SetActive(false);
                    badgename[i].text = "隱藏獎章";
                }
                else
                {
                    BadgeIcon[i].sprite = DiamondBadge;
                    badgeprocess[i].transform.localPosition = new Vector3(0, 0.0f, 0.0f);
                    badgename[i].text = "完成任務隱藏獎章";
                }
               
            }
            else if ((i + tmp) == 21)
            {
                if (badge[4].BadgesCount < badge[4].UnexpectedGoal)
                {
                    BadgeIcon[i].sprite = HideDiamondBadge;
                    process[i].SetActive(false);
                    badgename[i].text = "隱藏獎章";
                }
                else
                {
                    BadgeIcon[i].sprite = DiamondBadge;
                    badgeprocess[i].transform.localPosition = new Vector3(0, 0.0f, 0.0f);
                    badgename[i].text = "英聽大師隱藏獎章";
                }
            }
            else if ((i + tmp) == 22)
            {
                if (badge[5].BadgesCount < badge[5].UnexpectedGoal)
                {
                    BadgeIcon[i].sprite = HideDiamondBadge;
                    process[i].SetActive(false);
                    badgename[i].text = "隱藏獎章";
                }
                else
                {
                    BadgeIcon[i].sprite = DiamondBadge;
                    badgeprocess[i].transform.localPosition = new Vector3(0, 0.0f, 0.0f);
                    badgename[i].text = "口說大師隱藏獎章";
                }
            }
            else if ((i + tmp) == 23)
            {
                if (badge[6].BadgesCount < badge[6].UnexpectedGoal)
                {
                    BadgeIcon[i].sprite = HideDiamondBadge;
                    process[i].SetActive(false);
                    badgename[i].text = "隱藏獎章";
                }
                else
                {
                    BadgeIcon[i].sprite = DiamondBadge;
                    badgeprocess[i].transform.localPosition = new Vector3(0, 0.0f, 0.0f);
                    badgename[i].text = "能言善道隱藏獎章";
                }
            }
            else if ((i + tmp) == 24)
            {
                if (badge[9].BadgesCount < badge[9].UnexpectedGoal)
                {
                    BadgeIcon[i].sprite = HideDiamondBadge;
                    process[i].SetActive(false);
                    badgename[i].text = "隱藏獎章";
                }
                else
                {
                    BadgeIcon[i].sprite = DiamondBadge;
                    badgeprocess[i].transform.localPosition = new Vector3(0, 0.0f, 0.0f);
                    badgename[i].text = "我是傳奇隱藏獎章";
                }
            }
            else
            {
                badgeview[i].SetActive(false);
            }
        }
        Badge_Sum = 0;
        for (int i = 0; i < 20; i++)
        {
            badge[i].CurrentGoal();
            Badge_Sum += (int)badge[i].Badge_Num;
        }
        if (badgetmp != Badge_Sum)
        {
            Debug.Log("Badge_Sum" + Badge_Sum);
            badgetmp = Badge_Sum;
            DatabaseDetials.UpdateBadgesCount();
        }

        if (PlayerLevel.text.ToString()!= Badge_Sum.ToString())
        {
            StartCoroutine("GetBag");
        }
    }

    public void setNextPage()
    {
        if (currentPage < 8) {
            currentPage++;
            tmp = 6 * currentPage;
        }       
    }

    public void setBackPage()
    {
        if (currentPage>0)
        {
            currentPage--;
            tmp = 6 * currentPage;
        }
    }

    IEnumerator GetBag()
    {
        WWWForm Form = new WWWForm();

        WWW GetBagWWW = new WWW(GetBagUrl + LoginScript.Account);

        yield return GetBagWWW;

        if (GetBagWWW.error != null)
        {
            Debug.LogError("Cannot connect to Database");
        }
        else
        {
            string LogText = GetBagWWW.text;         //回傳php網頁顯示的文字
            List<LoadBagResult> LoadCharacterList = JsonConvert.DeserializeObject<List<LoadBagResult>>(GetBagWWW.text);
            LoadBagResult result = LoadCharacterList[0];
            string[] LogTextSplit = LogText.Split(':'); //存放陣列

            PlayerAttack.text = result.Attack_Level.ToString();
            PlayerSpeed.text = result.Speed_Level.ToString();
            PlayerDefend.text = result.Defend_Level.ToString();
            PlayerLucky.text = result.Lucky_Level.ToString();
            PlayerLevel.text = result.TotalBadges.ToString();
            PlayerSkillPoints.text = (result.TotalBadges - result.Attack_Level- result.Speed_Level- result.Defend_Level- result.Lucky_Level).ToString();

            //紀錄能力點數 (獎章)
            badge[18].BadgesCount = result.Attack_Level + result.Speed_Level + result.Defend_Level + result.Lucky_Level+ result.TotalBadges;
         
            //StarPoint.text = Star.Total_Star.ToString(); // 從Class "Star"拿全域變數 星星數，而星星資料是從 Accuracy.cs的 LoadMissionState()方法撈出來的
        }
    }

    public void setSelect0()
    {
        if (int.Parse(PlayerSkillPoints.text) > 0) {
            select = "Attack_Level";
            PlayerAttack.text = (int.Parse(PlayerAttack.text) + 1).ToString();
            StartCoroutine("UpdateSkill");
            PlayerSkillPoints.text = (int.Parse(PlayerSkillPoints.text)-1).ToString();
        }
        
    }

    public void setSelect1()
    {
        if (int.Parse(PlayerSkillPoints.text) > 0)
        {
            select = "Speed_Level";
            PlayerSpeed.text = (int.Parse(PlayerSpeed.text) + 1).ToString();
            StartCoroutine("UpdateSkill");
            PlayerSkillPoints.text = (int.Parse(PlayerSkillPoints.text) - 1).ToString();
        }

    }

    public void setSelect2()
    {
        if (int.Parse(PlayerSkillPoints.text) > 0)
        {
            select = "Defend_Level";
            PlayerDefend.text = (int.Parse(PlayerDefend.text) + 1).ToString();
            StartCoroutine("UpdateSkill");
            PlayerSkillPoints.text = (int.Parse(PlayerSkillPoints.text) - 1).ToString();
        }
    }

    public void setSelect3()
    {
        if (int.Parse(PlayerSkillPoints.text) > 0)
        {
            select = "Lucky_Level";
            PlayerLucky.text = (int.Parse(PlayerLucky.text) + 1).ToString(); ;
            StartCoroutine("UpdateSkill");
            PlayerSkillPoints.text = (int.Parse(PlayerSkillPoints.text) - 1).ToString();
        }
    }

    IEnumerator UpdateSkill()
    {
        WWWForm Form = new WWWForm();

        if (select != null)
        {
            WWW UpdateSkillWWW = new WWW(UpdateSkillUrl + LoginScript.Account+ "&select="+select);

            yield return UpdateSkillWWW;

            if (UpdateSkillWWW.error != null)
            {
                Debug.LogError("Cannot connect to Database");
            }  
        }
    }

    public class LoadBagResult
    {
        public int Attack_Level { get; set; }
        public int Speed_Level { get; set; }
        public int Defend_Level { get; set; }
        public int Lucky_Level { get; set; }
        public int TotalBadges { get; set; }
    }

    public static void setStartMission()
    {
        int starttmp = 0;
        for (int i = 0; i < 15; i++)
        {
            if (Loadcharacter.Mission_Start[i])
            {
                starttmp++;
            }
        }
        badge[1].BadgesCount = starttmp;
    }

    public Sprite CurrentIcon(int i)
    {
        if (badge[i].BadgesCount < badge[i].CopperGoal)
        {
            return HideCopperBadge;
        }
        else if (badge[i].BadgesCount >= badge[i].CopperGoal && badge[i].BadgesCount < badge[i].SilverGoal)
        {
            return CopperBadge;
        }
        else if (badge[i].BadgesCount >= badge[i].SilverGoal && badge[i].BadgesCount < badge[i].GoldGoal)
        {
            return SilverBadge;
        }
        else
        {
            return GoldBadge;
        }
    }
    public void CurrentBadge0()
    {
        BadgeDetailScript.select = 0;
        CurrentBadge = tmp +0;
        DatabaseDetials.InsertBadgeClick();
    }
    public void CurrentBadge1()
    {
        BadgeDetailScript.select = 0;
        CurrentBadge = tmp +1;
        DatabaseDetials.InsertBadgeClick();
    }
    public void CurrentBadge2()
    {
        BadgeDetailScript.select = 0;
        CurrentBadge = tmp +2;
        DatabaseDetials.InsertBadgeClick();
    }
    public void CurrentBadge3()
    {
        BadgeDetailScript.select = 0;
        CurrentBadge = tmp +3;
        DatabaseDetials.InsertBadgeClick();
    }
    public void CurrentBadge4()
    {
        BadgeDetailScript.select = 0;
        CurrentBadge = tmp +4;
        DatabaseDetials.InsertBadgeClick();
    }
    public void CurrentBadge5()
    {
        BadgeDetailScript.select = 0;
        CurrentBadge = tmp +5;
        DatabaseDetials.InsertBadgeClick();
    }
}