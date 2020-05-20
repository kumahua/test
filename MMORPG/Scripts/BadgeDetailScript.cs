using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BadgeDetailScript : MonoBehaviour {
    public Text BadgeName,BadgeDescribe, CurrentProcess,UnexpectedBadgename,UnexpectedBadgedetail, UnexpectedProcess;
    public Image CurrentBadge, CopperBadge, SilverBadge, GoldBadge, BadgeProcess, UnexpectedBadge, UnexpectedBadgeProcess;
    public Sprite HideCopperBadge, HideSilverBadge, HideGoldBadge, CopperBadgeIcon, SilverBadgeIcon, GoldBadgeIcon, DiamondBadgeIcon, HideDiamondBadge;
    public Sprite []Icons = new Sprite[4];
    public GameObject badgeList, text, BadgeName_obj, BadgeDescribe_obj, UnexpectedBadgename_obj, UnexpectedBadgedetail_obj, UnexpectedBadge_obj, CurrentBadge_obj, UnexpectedProcess_obj;
    public static int select = 0;

    // Use this for initialization
    void Start () {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (BagViewScript.CurrentBadge < 20)
        {
            if (select == 0)
            {
                BadgeName_obj.SetActive(true);
                BadgeDescribe_obj.SetActive(true);
                CurrentBadge_obj.SetActive(true);
                badgeList.SetActive(true);
                text.SetActive(true);
                UnexpectedBadge_obj.SetActive(false);
                UnexpectedBadgename_obj.SetActive(false);
                UnexpectedBadgedetail_obj.SetActive(false);
                BadgeName.text = BagViewScript.badge[BagViewScript.CurrentBadge].BadgesName;
                BadgeDescribe.text = BagViewScript.badge[BagViewScript.CurrentBadge].BadgeDescribeFirst + BagViewScript.badge[BagViewScript.CurrentBadge].ShowGoal() + BagViewScript.badge[BagViewScript.CurrentBadge].BadgeDescribeSecond;
                CurrentProcess.text = "" + BagViewScript.badge[BagViewScript.CurrentBadge].BadgesCount + "/" + BagViewScript.badge[BagViewScript.CurrentBadge].ShowGoal();
                CurrentBadge.sprite = CurrentIcon(BagViewScript.CurrentBadge)[0];
                CopperBadge.sprite = CurrentIcon(BagViewScript.CurrentBadge)[1];
                SilverBadge.sprite = CurrentIcon(BagViewScript.CurrentBadge)[2];
                GoldBadge.sprite = CurrentIcon(BagViewScript.CurrentBadge)[3];
                BadgeProcess.transform.localPosition = new Vector3((-150 + 150 * (BagViewScript.badge[BagViewScript.CurrentBadge].BadgesCount / BagViewScript.badge[BagViewScript.CurrentBadge].CurrentGoal())), 0.0f, 0.0f);
            }
            else if (select == 1)
            {
                BadgeName.text = BagViewScript.badge[BagViewScript.CurrentBadge].BadgesName;
                BadgeDescribe.text = BagViewScript.badge[BagViewScript.CurrentBadge].BadgeDescribeFirst + BagViewScript.badge[BagViewScript.CurrentBadge].CopperGoal + BagViewScript.badge[BagViewScript.CurrentBadge].BadgeDescribeSecond;
                CurrentProcess.text = "" + BagViewScript.badge[BagViewScript.CurrentBadge].BadgesCount + "/" + BagViewScript.badge[BagViewScript.CurrentBadge].CopperGoal;
                CurrentBadge.sprite = CurrentIcon(BagViewScript.CurrentBadge)[1];
                CopperBadge.sprite = CurrentIcon(BagViewScript.CurrentBadge)[1];
                SilverBadge.sprite = CurrentIcon(BagViewScript.CurrentBadge)[2];
                GoldBadge.sprite = CurrentIcon(BagViewScript.CurrentBadge)[3];
                BadgeProcess.transform.localPosition = new Vector3((-150 + 150 * (CopperCount() / BagViewScript.badge[BagViewScript.CurrentBadge].CopperGoal)), 0.0f, 0.0f);
            }
            else if (select == 2)
            {
                BadgeName.text = BagViewScript.badge[BagViewScript.CurrentBadge].BadgesName;
                BadgeDescribe.text = BagViewScript.badge[BagViewScript.CurrentBadge].BadgeDescribeFirst + BagViewScript.badge[BagViewScript.CurrentBadge].SilverGoal + BagViewScript.badge[BagViewScript.CurrentBadge].BadgeDescribeSecond;
                CurrentProcess.text = "" + BagViewScript.badge[BagViewScript.CurrentBadge].BadgesCount + "/" + BagViewScript.badge[BagViewScript.CurrentBadge].SilverGoal;
                CurrentBadge.sprite = CurrentIcon(BagViewScript.CurrentBadge)[2];
                CopperBadge.sprite = CurrentIcon(BagViewScript.CurrentBadge)[1];
                SilverBadge.sprite = CurrentIcon(BagViewScript.CurrentBadge)[2];
                GoldBadge.sprite = CurrentIcon(BagViewScript.CurrentBadge)[3];
                BadgeProcess.transform.localPosition = new Vector3((-150 + 150 * (SilverCount() / BagViewScript.badge[BagViewScript.CurrentBadge].SilverGoal)), 0.0f, 0.0f);
            }
            else if (select == 3)
            {
                BadgeName.text = BagViewScript.badge[BagViewScript.CurrentBadge].BadgesName;
                BadgeDescribe.text = BagViewScript.badge[BagViewScript.CurrentBadge].BadgeDescribeFirst + BagViewScript.badge[BagViewScript.CurrentBadge].GoldGoal + BagViewScript.badge[BagViewScript.CurrentBadge].BadgeDescribeSecond;
                CurrentProcess.text = "" + BagViewScript.badge[BagViewScript.CurrentBadge].BadgesCount + "/" + BagViewScript.badge[BagViewScript.CurrentBadge].GoldGoal;
                CurrentBadge.sprite = CurrentIcon(BagViewScript.CurrentBadge)[3];
                CopperBadge.sprite = CurrentIcon(BagViewScript.CurrentBadge)[1];
                SilverBadge.sprite = CurrentIcon(BagViewScript.CurrentBadge)[2];
                GoldBadge.sprite = CurrentIcon(BagViewScript.CurrentBadge)[3];
                BadgeProcess.transform.localPosition = new Vector3((-150 + 150 * (GoldCount() / BagViewScript.badge[BagViewScript.CurrentBadge].GoldGoal)), 0.0f, 0.0f);
            }
        }
        else if (BagViewScript.CurrentBadge == 20)
        {

            UnexpectedBadge_obj.SetActive(true);
            UnexpectedBadgename_obj.SetActive(true);
            UnexpectedBadgedetail_obj.SetActive(true);
            badgeList.SetActive(false);
            text.SetActive(false);
            BadgeName_obj.SetActive(false);
            BadgeDescribe_obj.SetActive(false);
            CurrentBadge_obj.SetActive(false);
            if (BagViewScript.badge[0].BadgesCount < BagViewScript.badge[0].UnexpectedGoal)
            {
                UnexpectedProcess_obj.SetActive(false);
                UnexpectedBadgename.text = "隱藏獎章";
                UnexpectedBadgedetail.text = "這是隱藏獎章\n透過完成遊戲就有機會獲得!!";
                UnexpectedBadge.sprite = HideDiamondBadge;
                
            }
            else
            {
                UnexpectedProcess_obj.SetActive(true);
                UnexpectedBadgename.text = "完成任務隱藏獎章";
                UnexpectedBadgedetail.text = BagViewScript.badge[0].BadgeDescribeFirst + BagViewScript.badge[0].UnexpectedGoal + BagViewScript.badge[0].BadgeDescribeSecond;
                UnexpectedBadgeProcess.transform.localPosition = new Vector3(0, 0.0f, 0.0f);
                UnexpectedProcess.text = "14/14";
                UnexpectedBadge.sprite = DiamondBadgeIcon;
            }

        }
        else if (BagViewScript.CurrentBadge == 21)
        {
            UnexpectedBadge_obj.SetActive(true);
            UnexpectedBadgename_obj.SetActive(true);
            UnexpectedBadgedetail_obj.SetActive(true);
            badgeList.SetActive(false);
            text.SetActive(false);
            BadgeName_obj.SetActive(false);
            BadgeDescribe_obj.SetActive(false);
            CurrentBadge_obj.SetActive(false);
            if (BagViewScript.badge[4].BadgesCount < BagViewScript.badge[4].UnexpectedGoal)
            {
                UnexpectedProcess_obj.SetActive(false);
                UnexpectedBadgename.text = "隱藏獎章";
                UnexpectedBadgedetail.text = "這是隱藏獎章\n透過完成遊戲就有機會獲得!!";
                UnexpectedBadge.sprite = HideDiamondBadge;
            }
            else
            {
                UnexpectedProcess_obj.SetActive(true);
                UnexpectedBadgename.text = "英聽大師隱藏獎章";
                UnexpectedBadgedetail.text = BagViewScript.badge[4].BadgeDescribeFirst + BagViewScript.badge[4].UnexpectedGoal + BagViewScript.badge[4].BadgeDescribeSecond;
                UnexpectedBadgeProcess.transform.localPosition = new Vector3(0, 0.0f, 0.0f);
                UnexpectedProcess.text = "160/160";
                UnexpectedBadge.sprite = DiamondBadgeIcon;
            }
        }
        else if (BagViewScript.CurrentBadge == 22)
        {
            UnexpectedBadge_obj.SetActive(true);
            UnexpectedBadgename_obj.SetActive(true);
            UnexpectedBadgedetail_obj.SetActive(true);
            badgeList.SetActive(false);
            text.SetActive(false);
            BadgeName_obj.SetActive(false);
            BadgeDescribe_obj.SetActive(false);
            CurrentBadge_obj.SetActive(false);
            if (BagViewScript.badge[5].BadgesCount < BagViewScript.badge[5].UnexpectedGoal)
            {
                UnexpectedProcess_obj.SetActive(false);
                UnexpectedBadgename.text = "隱藏獎章";
                UnexpectedBadgedetail.text = "這是隱藏獎章\n透過完成遊戲就有機會獲得!!";
                UnexpectedBadge.sprite = HideDiamondBadge;
            }
            else
            {
                UnexpectedProcess_obj.SetActive(true);
                UnexpectedBadgename.text = "口說大師隱藏獎章";
                UnexpectedBadgedetail.text = BagViewScript.badge[5].BadgeDescribeFirst + BagViewScript.badge[5].UnexpectedGoal + BagViewScript.badge[5].BadgeDescribeSecond;
                UnexpectedBadgeProcess.transform.localPosition = new Vector3(0, 0.0f, 0.0f);
                UnexpectedProcess.text = "200/200";
                UnexpectedBadge.sprite = DiamondBadgeIcon;
            }
        }
        else if (BagViewScript.CurrentBadge == 23)
        {
            UnexpectedBadge_obj.SetActive(true);
            UnexpectedBadgename_obj.SetActive(true);
            UnexpectedBadgedetail_obj.SetActive(true);
            badgeList.SetActive(false);
            text.SetActive(false);
            BadgeName_obj.SetActive(false);
            BadgeDescribe_obj.SetActive(false);
            CurrentBadge_obj.SetActive(false);
            if (BagViewScript.badge[6].BadgesCount < BagViewScript.badge[6].UnexpectedGoal)
            {
                UnexpectedProcess_obj.SetActive(false);
                UnexpectedBadgename.text = "隱藏獎章";
                UnexpectedBadgedetail.text = "這是隱藏獎章\n透過完成遊戲就有機會獲得!!";
                UnexpectedBadge.sprite = HideDiamondBadge;
            }
            else
            {
                UnexpectedProcess_obj.SetActive(true);
                UnexpectedBadgename.text = "能言善道隱藏獎章";
                UnexpectedBadgedetail.text = BagViewScript.badge[6].BadgeDescribeFirst + BagViewScript.badge[6].UnexpectedGoal + BagViewScript.badge[6].BadgeDescribeSecond;
                UnexpectedBadgeProcess.transform.localPosition = new Vector3(0, 0.0f, 0.0f);
                UnexpectedProcess.text = "56/56";
                UnexpectedBadge.sprite = DiamondBadgeIcon;
            }
        }
        else if (BagViewScript.CurrentBadge == 24)
        {
            UnexpectedBadge_obj.SetActive(true);
            UnexpectedBadgename_obj.SetActive(true);
            UnexpectedBadgedetail_obj.SetActive(true);
            badgeList.SetActive(false);
            text.SetActive(false);
            BadgeName_obj.SetActive(false);
            BadgeDescribe_obj.SetActive(false);
            CurrentBadge_obj.SetActive(false);
            if (BagViewScript.badge[9].BadgesCount < BagViewScript.badge[9].UnexpectedGoal)
            {
                UnexpectedProcess_obj.SetActive(false);
                UnexpectedBadgename.text = "隱藏獎章";
                UnexpectedBadgedetail.text = "這是隱藏獎章\n透過完成遊戲就有機會獲得!!";
                UnexpectedBadge.sprite = HideDiamondBadge;
            }
            else
            {
                UnexpectedProcess_obj.SetActive(true);
                UnexpectedBadgename.text = "我是傳奇隱藏獎章";
                UnexpectedBadgedetail.text = BagViewScript.badge[9].BadgeDescribeFirst + BagViewScript.badge[9].UnexpectedGoal + BagViewScript.badge[9].BadgeDescribeSecond;
                UnexpectedBadgeProcess.transform.localPosition = new Vector3(0, 0.0f, 0.0f);
                UnexpectedProcess.text = "95/95";
                UnexpectedBadge.sprite = DiamondBadgeIcon;
            }
        }

    }

    
    public Sprite[] CurrentIcon(int i)
    {
        if (BagViewScript.badge[i].BadgesCount < BagViewScript.badge[i].CopperGoal)
        {
            Icons[0] = HideCopperBadge;
            Icons[1] = HideCopperBadge;
            Icons[2] = HideSilverBadge;
            Icons[3] = HideGoldBadge;
            return Icons;
        }
        else if (BagViewScript.badge[i].BadgesCount >= BagViewScript.badge[i].CopperGoal && BagViewScript.badge[i].BadgesCount < BagViewScript.badge[i].SilverGoal)
        {
            Icons[0] = HideSilverBadge;
            Icons[1] = CopperBadgeIcon;
            Icons[2] = HideSilverBadge;
            Icons[3] = HideGoldBadge;
            return Icons;
        }
        else if (BagViewScript.badge[i].BadgesCount >= BagViewScript.badge[i].SilverGoal && BagViewScript.badge[i].BadgesCount < BagViewScript.badge[i].GoldGoal)
        {   
            Icons[0] = HideGoldBadge;
            Icons[1] = CopperBadgeIcon;
            Icons[2] = SilverBadgeIcon;
            Icons[3] = HideGoldBadge;
            return Icons;
        }
        else
        {
            Icons[0] = GoldBadgeIcon;
            Icons[1] = CopperBadgeIcon;
            Icons[2] = SilverBadgeIcon;
            Icons[3] = GoldBadgeIcon;
            return Icons;
        }
    }
    float CopperCount()
    {
        if(BagViewScript.badge[BagViewScript.CurrentBadge].BadgesCount> BagViewScript.badge[BagViewScript.CurrentBadge].CopperGoal)
        {
            return BagViewScript.badge[BagViewScript.CurrentBadge].CopperGoal;
        }
        else
        {
            return BagViewScript.badge[BagViewScript.CurrentBadge].BadgesCount;
        }
    }
    float SilverCount()
    {
        if (BagViewScript.badge[BagViewScript.CurrentBadge].BadgesCount > BagViewScript.badge[BagViewScript.CurrentBadge].SilverGoal)
        {
            return BagViewScript.badge[BagViewScript.CurrentBadge].SilverGoal;
        }
        else
        {
            return BagViewScript.badge[BagViewScript.CurrentBadge].BadgesCount;
        }
    }
    float GoldCount()
    {
        if (BagViewScript.badge[BagViewScript.CurrentBadge].BadgesCount > BagViewScript.badge[BagViewScript.CurrentBadge].GoldGoal)
        {
            return BagViewScript.badge[BagViewScript.CurrentBadge].GoldGoal;
        }
        else
        {
            return BagViewScript.badge[BagViewScript.CurrentBadge].BadgesCount;
        }
    }
    public void select0()
    {
        select = 0;
    }
    public void select1()
    {
        select = 1;
    }
    public void select2()
    {
        select = 2;
    }
    public void select3()
    {
        select = 3;
    }
}
