using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllFunctiosTime : MonoBehaviour {

    public static int LearningMissionFail;
    public static int Point;
    public static int GetLevel;
    public static int MissionTips;
    public static int CheckMission;
    public static int CheckMap;
    public static int CheckRankList;
    public static int CheckBadgeList;
    public static int CheckAccuaryList;
    public static string GetAllFunctionsTimeURL = "http://140.115.126.115:3000/getAllFunctionsTime?account="+ LoginScript.Account;
    public static string LearningMissionFailURL = "http://140.115.126.115:3000/updateSpecificFunctionTime?account=" + LoginScript.Account + "&database_value=LearningMissionFail";
    public static string GetLevelURL = "http://140.115.126.115:3000/updateSpecificFunctionTime?account=" + LoginScript.Account + "&database_value=GetLevel";
    public static string PointURL = "http://140.115.126.115:3000/updateSpecificFunctionTime?account=" + LoginScript.Account + "&database_value=Point";
    public static string MissionTipsURL = "http://140.115.126.115:3000/updateSpecificFunctionTime?account=" + LoginScript.Account + "&database_value=MissionTips";
    public static string CheckMissionURL = "http://140.115.126.115:3000/updateSpecificFunctionTime?account=" + LoginScript.Account + "&database_value=CheckMission";
    public static string CheckMapURL = "http://140.115.126.115:3000/updateSpecificFunctionTime?account=" + LoginScript.Account + "&database_value=CheckMap";
    public static string CheckRankListURL = "http://140.115.126.115:3000/updateSpecificFunctionTime?account=" + LoginScript.Account + "&database_value=CheckRankList";
    public static string CheckBadgeListURL = "http://140.115.126.115:3000/updateSpecificFunctionTime?account=" + LoginScript.Account + "&database_value=CheckBadgeList";
    public static string CheckAccuaryListURL = "http://140.115.126.115:3000/updateSpecificFunctionTime?account=" + LoginScript.Account + "&database_value=CheckAccuaryList";
    public static string LearningMissionSentence = "http://140.115.126.115:3000/RecordResult?account=";
    public static string LearningMissionVocabulary = "http://140.115.126.115:3000/RecordVocabulary?account=";

}
