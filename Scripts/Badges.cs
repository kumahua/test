using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Badges : MonoBehaviour{
    public string BadgesName;
    public string BadgeDescribeFirst;
    public string BadgeDescribeSecond;
    public float BadgesCount; //達成目標次數計算
    public float CopperGoal;
    public float SilverGoal;
    public float GoldGoal;
    public float UnexpectedGoal;
    public float Badge_Num;
    public Badges(string n, string f, string sec, float i, float c, float s, float g, float u, float b)
    {
        BadgesName = n;
        BadgeDescribeFirst = f;
        BadgeDescribeSecond = sec;
        BadgesCount = i;
        CopperGoal = c;
        SilverGoal = s;
        GoldGoal = g;
        UnexpectedGoal = u;
        Badge_Num = b;
    }
    public float CurrentGoal()
    {
        if (BadgesCount< CopperGoal){
            return CopperGoal;
        }else if(BadgesCount >= CopperGoal && BadgesCount < SilverGoal){
            Badge_Num = 1;
            return SilverGoal;
        }
        else if(BadgesCount >= SilverGoal && BadgesCount <GoldGoal)
        {
            Badge_Num = 2;
            return GoldGoal;
        }
        else if(BadgesCount >= GoldGoal && BadgesCount < UnexpectedGoal)
        {
            Badge_Num = 3;
            return BadgesCount;
        }
        else if (BadgesCount >= UnexpectedGoal)
        {
            Badge_Num = 4;
            return BadgesCount;
        }
        else
        {
            return BadgesCount;
        }
    }

    public float ShowGoal()
    {
        if (BadgesCount < CopperGoal)
        {
            return CopperGoal;
        }
        else if (BadgesCount >= CopperGoal && BadgesCount < SilverGoal)
        {
            return SilverGoal;
        }
        else if (BadgesCount >= SilverGoal && BadgesCount < GoldGoal)
        {
            return GoldGoal;
        }
        else
        {
            return GoldGoal;
        }
    }

}
