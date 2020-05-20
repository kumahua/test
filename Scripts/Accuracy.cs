using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;

public class Accuracy : MonoBehaviour {
    public static float single;
    public static float[,] accuracy = new float[14,3];
    public static float[] ReviewAccuracy = new float[14];
    public static bool isChange = false;
    public static float mission;
    public static float reviewmission;
    public static float wholemission;
    public string badge_update_url = "http://140.115.126.115:3000/Update_Badge?account=";
    private string LoadMissionStateUrl = "http://140.115.126.115:3000/LoadMissionState?account=";
    // Use this for initialization
    void Start () {
		for(int i = 0; i <14; i++)
        {
            ReviewAccuracy[i] = 0;
            for (int j=0;j<3; j++)
            {
                accuracy[i, j] = 0;
            }
        }
        //從資料庫撈語音辨識準確度資料
        StartCoroutine("LoadMissionState");
    }
	
	// Update is called once per frame
	void Update () {
        if (isChange)
        {
            mission = 0;
            wholemission = 0;
            single = 0;
            reviewmission = 0;
            for (int i = 0; i < 14; i++)
            {
                int tmp = 0;
                for (int j = 0; j < 3; j++)
                {
                    ShowAccuracy.Rate[i, j].text = accuracy[i, j].ToString("#0.00") + "%";
                    if (accuracy[i, j] >= 90)
                    {
                        tmp++;
                        single++;
                    }
                    wholemission += accuracy[i, j];
                }
                if(tmp == 3)
                {
                    mission++;
                }
                if (ReviewAccuracy[i] >= 90)
                {
                    reviewmission++;
                }
            }
            BagViewScript.badge[6].BadgesCount = single;
            BagViewScript.badge[7].BadgesCount = mission;
            BagViewScript.badge[8].BadgesCount = reviewmission;
            BagViewScript.badge[9].BadgesCount = (float)Math.Round(wholemission / 42, 2, MidpointRounding.AwayFromZero);
            isChange = false;
            WWWForm Form = new WWWForm();
            WWW LoginAccountWWW = new WWW(badge_update_url + LoginScript.Account+"&SingleAccuracy="+ single + "&MissionAccuracy=" + mission + "&PracticeMissionAccuracy=" + reviewmission + "&WholeMissionAccuracy="+ (float)Math.Round(wholemission / 42, 2, MidpointRounding.AwayFromZero) + "&MissionFinish=" + (int)BagViewScript.badge[0].BadgesCount + "&MissionStart=" + (int)BagViewScript.badge[1].BadgesCount);
            if (LoginAccountWWW.error != null)
            {
                Debug.LogError("寫入錯誤");
            }
        }
	}
    public class LoadMissionStateResult
    {
        public int Mission_ING { get; set; }
        public int Mission_State { get; set; }
        public float Accuracy { get; set; }
        public int Star { get; set; }
    }
    IEnumerator LoadMissionState()
    {
        WWWForm Form = new WWWForm();

        WWW LoadMissionWWW = new WWW(LoadMissionStateUrl + LoginScript.Account);

        yield return LoadMissionWWW;
        if (LoadMissionWWW.error != null)
        {
            Debug.LogError("Cannot connect to Login");
        }else if (LoadMissionWWW.text == "沒有這個帳號")
        {

        }
        else
        {
            string LogText = LoadMissionWWW.text;         //回傳php網頁顯示的文字
            List<LoadMissionStateResult> LoadList = JsonConvert.DeserializeObject<List<LoadMissionStateResult>>(LoadMissionWWW.text);
            LoadMissionStateResult[] results = new LoadMissionStateResult[LoadList.Count];
            for (int i = 0; i < results.Length; i++)
            {
                results[i] = LoadList[i];
                if (results[i].Mission_ING < 15)
                {
                    accuracy[results[i].Mission_ING - 1, results[i].Mission_State - 1] = results[i].Accuracy;
                    Star.Total_Star += results[i].Star; //將星星統計
                    Debug.Log(results[i].Star);
                }
                else
                {
                    ReviewAccuracy[results[i].Mission_State - 4] = results[i].Accuracy;
                }
                
            }
            Accuracy.isChange = true;
        }    
    }
}
