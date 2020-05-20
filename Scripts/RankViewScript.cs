using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;


public class RankViewScript : MonoBehaviour {

    public bool openandclose = false;
    public GameObject RankView;
    public string RankViewName;
    public int select = -1;
    private int tempselect = -1;
    public Text RankScoreTittle;
    public Text Title;
    public Text[] RankScore = new Text[11];
    public Text[] RankTittle = new Text[11];
    public Text[] RankName = new Text[11];
    private string RankUrl = "null";
    // Use this for initialization
    void Start ()
    {
        RankView = GameObject.Find(RankViewName);
        RankView.SetActive(false);
    }
	

	// Update is called once per frame
	void Update ()
    {
       
    }

    public void Close()
    {
        RankView.SetActive(false);
        openandclose = false;
        Debug.Log("視窗關閉!");
    }
    public void Open()
    {
        switch (openandclose)
        {
            case true:
                if (tempselect != select)
                {
                    StartCoroutine("GetRank");
                    tempselect = select;
                }
                else {
                    RankView.SetActive(false);
                    openandclose = false;
                    //Context.text = "Click the Mission.";
                    Debug.Log("視窗關閉!");
                }
                break;
            case false:
                RankView.SetActive(true);
                openandclose = true;
                StartCoroutine("GetRank");
                tempselect = select;
                //Context.text = "Click the Mission.";
                Debug.Log("視窗開啟!");
                break;
            default:

                break;
        }
    }

    IEnumerator GetRank()
    {
        WWWForm Form = new WWWForm();

        WWW GetRankWWW = new WWW(RankUrl+ LoginScript.Account);

        yield return GetRankWWW;

        if (GetRankWWW.error != null)
        {
            Debug.LogError("Cannot connect to Database");
        }
        else
        {
            string LogText = GetRankWWW.text;         //回傳php網頁顯示的文字
            if(select == 0)
            {
                List<getLevelRank> getLevelRankList = JsonConvert.DeserializeObject<List<getLevelRank>>(GetRankWWW.text);
                getLevelRank[] result = new getLevelRank[getLevelRankList.Count];
                for (int i = 0; i < RankName.Length; i++)
                {
                    RankTittle[i].text = "";
                    RankName[i].text = "";
                    RankScore[i].text = "";
                }
                for (int i = 0; i < result.Length; i++)
                {
                    result[i] = getLevelRankList[i];
                    if(i!= result.Length - 1) {
                        RankTittle[i].text = (i+1).ToString();
                        RankName[i].text = result[i].Account;
                        RankScore[i].text = result[i].lv.ToString();
                    }
                    else
                    {
                        RankTittle[i].text = "你的分數:";
                        RankName[i].text = result[i].Account;
                        RankScore[i].text = result[i].lv.ToString();
                    }
                }
            }
            else if(select == 1)
            {
                List<getMoneyRank> getLevelRankList = JsonConvert.DeserializeObject<List<getMoneyRank>>(GetRankWWW.text);
                getMoneyRank[] result = new getMoneyRank[getLevelRankList.Count];
                for (int i = 0; i < RankName.Length; i++)
                {
                    RankTittle[i].text = "";
                    RankName[i].text = "";
                    RankScore[i].text = "";
                }
                for (int i = 0; i < result.Length; i++)
                {
                    result[i] = getLevelRankList[i];
                    if (i != result.Length - 1)
                    {
                        RankTittle[i].text = (i+1).ToString();
                        RankName[i].text = result[i].Account;
                        RankScore[i].text = result[i].Money.ToString();
                    }
                    else
                    {
                        RankTittle[i].text = "你的分數:";
                        RankName[i].text = result[i].Account;
                        RankScore[i].text = result[i].Money.ToString();
                    }
                }
            }
            else if (select == 2)
            {
                List<getKillRank> getLevelRankList = JsonConvert.DeserializeObject<List<getKillRank>>(GetRankWWW.text);
                getKillRank[] result = new getKillRank[getLevelRankList.Count];
                for (int i = 0; i < RankName.Length; i++)
                {
                    RankTittle[i].text = "";
                    RankName[i].text = "";
                    RankScore[i].text = "";
                }
                for (int i = 0; i < result.Length; i++)
                {
                    result[i] = getLevelRankList[i];
                    if (i != result.Length - 1)
                    {
                        RankTittle[i].text = (i+1).ToString();
                        RankName[i].text = result[i].Account;
                        RankScore[i].text = result[i].MonsterKill.ToString();
                    }
                    else
                    {
                        RankTittle[i].text = "你的分數:";
                        RankName[i].text = result[i].Account;
                        RankScore[i].text = result[i].MonsterKill.ToString();
                    }
                }
            }
            else if (select == 3)
            {
                List<getLearningRank> getLevelRankList = JsonConvert.DeserializeObject<List<getLearningRank>>(GetRankWWW.text);
                getLearningRank[] result = new getLearningRank[getLevelRankList.Count];
                for (int i = 0; i < RankName.Length; i++)
                {
                    RankTittle[i].text = "";
                    RankName[i].text = "";
                    RankScore[i].text = "";
                }
                for (int i = 0; i < result.Length; i++)
                {
                    result[i] = getLevelRankList[i];
                    if (i != result.Length - 1)
                    {
                        RankTittle[i].text = (i+1).ToString();
                        RankName[i].text = result[i].Account;
                        RankScore[i].text = result[i].LearningMission_count.ToString();
                    }
                    else
                    {
                        RankTittle[i].text = "你的分數:";
                        RankName[i].text = result[i].Account;
                        RankScore[i].text = result[i].LearningMission_count.ToString();
                    }
                }
            }
            else if (select == 4)
            {
                List<getReviewRank> getLevelRankList = JsonConvert.DeserializeObject<List<getReviewRank>>(GetRankWWW.text);
                getReviewRank[] result = new getReviewRank[getLevelRankList.Count];
                for (int i = 0; i < RankName.Length; i++)
                {
                    RankTittle[i].text = "";
                    RankName[i].text = "";
                    RankScore[i].text = "";
                }
                for (int i = 0; i < result.Length; i++)
                {
                    result[i] = getLevelRankList[i];
                    if (i != result.Length - 1)
                    {
                        RankTittle[i].text = (i+1).ToString();
                        RankName[i].text = result[i].Account;
                        RankScore[i].text = result[i].ReviewMission_count.ToString();
                    }
                    else
                    {
                        RankTittle[i].text = "你的分數:";
                        RankName[i].text = result[i].Account;
                        RankScore[i].text = result[i].ReviewMission_count.ToString();
                    }
                }
            }
            else if (select == 5)
            {
                List<getBadgeRank> getLevelRankList = JsonConvert.DeserializeObject<List<getBadgeRank>>(GetRankWWW.text);
                getBadgeRank[] result = new getBadgeRank[getLevelRankList.Count];
                for (int i = 0; i < RankName.Length; i++)
                {
                    RankTittle[i].text = "";
                    RankName[i].text = "";
                    RankScore[i].text = "";
                }
                for (int i = 0; i < result.Length; i++)
                {
                    result[i] = getLevelRankList[i];
                    if (i != result.Length - 1)
                    {
                        RankTittle[i].text = (i + 1).ToString();
                        RankName[i].text = result[i].Account;
                        RankScore[i].text = result[i].TotalBadges.ToString();
                    }
                    else
                    {
                        RankTittle[i].text = "你的分數:";
                        RankName[i].text = result[i].Account;
                        RankScore[i].text = result[i].TotalBadges.ToString();
                    }
                }
            }
        }
    }

    public class getLevelRank
    {
        public string Account { get; set; }
        public int lv { get; set; }
    }

    public class getKillRank
    {
        public string Account { get; set; }
        public int MonsterKill { get; set; }
    }

    public class getMoneyRank
    {
        public string Account { get; set; }
        public int Money { get; set; }
    }
    public class getLearningRank
    {
        public string Account { get; set; }
        public int LearningMission_count { get; set; }
    }
    public class getReviewRank
    {
        public string Account { get; set; }
        public int ReviewMission_count { get; set; }
    }
    public class getBadgeRank
    {
        public string Account { get; set; }
        public int TotalBadges { get; set; }
    }

    public void setSelect0()
    {
        select = 0;
        RankUrl = "http://140.115.126.115:3000/getLevelRank?account=";//http://140.115.126.160/WordofWorld/getLevelRank.php
        RankScoreTittle.text = "等級"; 
        Title.text = "等級排行";
        for (int i = 0; i <11; i++)
        {
            RankTittle[i].text ="";
            RankName[i].text = "";
            RankScore[i].text = "";
        }
    }

    public void setSelect1()
    {
        select = 1;
        RankUrl = "http://140.115.126.115:3000/getMonyRank?account=";// "http://140.115.126.160/WordofWorld/getRank.php"
        RankScoreTittle.text = "金幣";
        Title.text = "金幣排行";
        for (int i = 0; i < 11; i++)
        {
            RankTittle[i].text = "";
            RankName[i].text = "";
            RankScore[i].text = "";
        }

    }

    public void setSelect2()
    {
        select = 2;
        RankUrl = "http://140.115.126.115:3000/getKillRank?account="; //http://140.115.126.160/WordofWorld/getKillRank.php
        RankScoreTittle.text = "擊殺數";
        Title.text = "擊殺怪物排行";
        for (int i = 0; i < 11; i++)
        {
            RankTittle[i].text = "";
            RankName[i].text = "";
            RankScore[i].text = "";
        }
    }

    public void setSelect3()
    {
        select = 3;
        RankUrl = "http://140.115.126.115:3000/getLearningRank?account="; //http://140.115.126.160/WordofWorld/getLearningRank.php
        RankScoreTittle.text = "學習次數";
        RankScoreTittle.resizeTextForBestFit = true;
        Title.text = "學習排行";
        for (int i = 0; i < 11; i++)
        {
            RankTittle[i].text = "";
            RankName[i].text = "";
            RankScore[i].text = "";
        }
    }

    public void setSelect4()
    {
        select = 4;
        RankUrl = "http://140.115.126.115:3000/getReviewRank?account="; //http://140.115.126.160/WordofWorld/getReviewRank.php
        RankScoreTittle.text = "Review";
        Title.text = "ReviewRank";
        for (int i = 0; i < 11; i++)
        {
            RankTittle[i].text = "";
            RankName[i].text = "";
            RankScore[i].text = "";
        }
    }

    public void setSelect5()
    {
        select = 5;
        RankUrl = "http://140.115.126.115:3000/getBadgesRank?account=";
        RankScoreTittle.text = "獎章數";
        Title.text = "獎章排行";
        for (int i = 1; i < 11; i++)
        {
            RankTittle[i].text = "";
            RankName[i].text = "";
            RankScore[i].text = "";
        }
    }

    public void setSelect6()
    {
        select = 6;
        RankUrl = "";
        RankScoreTittle.text = "Fight";
        Title.text = "FightRank";
        for (int i = 1; i < 11; i++)
        {
            RankTittle[i].text = "";
            RankName[i - 1].text = "";
            RankScore[i - 1].text = "";
        }
    }
}


