using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowAccuracy : MonoBehaviour {

    public static Text[,] Rate = new Text[14,3];

    private void Awake()
    {
        Rate[0,0] = GameObject.Find("UI/UserUI/AccuracyView/ScrollView/Grid/Serene/FirstRate").GetComponent<Text>();
        Rate[0, 1] = GameObject.Find("UI/UserUI/AccuracyView/ScrollView/Grid/Serene/SecondRate").GetComponent<Text>();
        Rate[0, 2] = GameObject.Find("UI/UserUI/AccuracyView/ScrollView/Grid/Serene/ThirdRate").GetComponent<Text>();
        Rate[1, 0] = GameObject.Find("UI/UserUI/AccuracyView/ScrollView/Grid/Thoughtful/FirstRate").GetComponent<Text>();
        Rate[1, 1] = GameObject.Find("UI/UserUI/AccuracyView/ScrollView/Grid/Thoughtful/SecondRate").GetComponent<Text>();
        Rate[1, 2] = GameObject.Find("UI/UserUI/AccuracyView/ScrollView/Grid/Thoughtful/ThirdRate").GetComponent<Text>();
        Rate[2, 0] = GameObject.Find("UI/UserUI/AccuracyView/ScrollView/Grid/Subsidy/FirstRate").GetComponent<Text>();
        Rate[2, 1] = GameObject.Find("UI/UserUI/AccuracyView/ScrollView/Grid/Subsidy/SecondRate").GetComponent<Text>();
        Rate[2, 2] = GameObject.Find("UI/UserUI/AccuracyView/ScrollView/Grid/Subsidy/ThirdRate").GetComponent<Text>();
        Rate[3, 0] = GameObject.Find("UI/UserUI/AccuracyView/ScrollView/Grid/Purification/FirstRate").GetComponent<Text>();
        Rate[3, 1] = GameObject.Find("UI/UserUI/AccuracyView/ScrollView/Grid/Purification/SecondRate").GetComponent<Text>();
        Rate[3, 2] = GameObject.Find("UI/UserUI/AccuracyView/ScrollView/Grid/Purification/ThirdRate").GetComponent<Text>();
        Rate[4, 0] = GameObject.Find("UI/UserUI/AccuracyView/ScrollView/Grid/Detention/FirstRate").GetComponent<Text>();
        Rate[4, 1] = GameObject.Find("UI/UserUI/AccuracyView/ScrollView/Grid/Detention/SecondRate").GetComponent<Text>();
        Rate[4, 2] = GameObject.Find("UI/UserUI/AccuracyView/ScrollView/Grid/Detention/ThirdRate").GetComponent<Text>();
        Rate[5, 0] = GameObject.Find("UI/UserUI/AccuracyView/ScrollView/Grid/Beautify/FirstRate").GetComponent<Text>();
        Rate[5, 1] = GameObject.Find("UI/UserUI/AccuracyView/ScrollView/Grid/Beautify/SecondRate").GetComponent<Text>();
        Rate[5, 2] = GameObject.Find("UI/UserUI/AccuracyView/ScrollView/Grid/Beautify/ThirdRate").GetComponent<Text>();
        Rate[6, 0] = GameObject.Find("UI/UserUI/AccuracyView/ScrollView/Grid/Drain/FirstRate").GetComponent<Text>();
        Rate[6, 1] = GameObject.Find("UI/UserUI/AccuracyView/ScrollView/Grid/Drain/SecondRate").GetComponent<Text>();
        Rate[6, 2] = GameObject.Find("UI/UserUI/AccuracyView/ScrollView/Grid/Drain/ThirdRate").GetComponent<Text>();
        Rate[7, 0] = GameObject.Find("UI/UserUI/AccuracyView/ScrollView/Grid/Concentration/FirstRate").GetComponent<Text>();
        Rate[7, 1] = GameObject.Find("UI/UserUI/AccuracyView/ScrollView/Grid/Concentration/SecondRate").GetComponent<Text>();
        Rate[7, 2] = GameObject.Find("UI/UserUI/AccuracyView/ScrollView/Grid/Concentration/ThirdRate").GetComponent<Text>();
        Rate[8, 0] = GameObject.Find("UI/UserUI/AccuracyView/ScrollView/Grid/Ecological/FirstRate").GetComponent<Text>();
        Rate[8, 1] = GameObject.Find("UI/UserUI/AccuracyView/ScrollView/Grid/Ecological/SecondRate").GetComponent<Text>();
        Rate[8, 2] = GameObject.Find("UI/UserUI/AccuracyView/ScrollView/Grid/Ecological/ThirdRate").GetComponent<Text>();
        Rate[9, 0] = GameObject.Find("UI/UserUI/AccuracyView/ScrollView/Grid/Picturesque/FirstRate").GetComponent<Text>();
        Rate[9, 1] = GameObject.Find("UI/UserUI/AccuracyView/ScrollView/Grid/Picturesque/SecondRate").GetComponent<Text>();
        Rate[9, 2] = GameObject.Find("UI/UserUI/AccuracyView/ScrollView/Grid/Picturesque/ThirdRate").GetComponent<Text>();
        Rate[10, 0] = GameObject.Find("UI/UserUI/AccuracyView/ScrollView/Grid/Aquatic/FirstRate").GetComponent<Text>();
        Rate[10, 1] = GameObject.Find("UI/UserUI/AccuracyView/ScrollView/Grid/Aquatic/SecondRate").GetComponent<Text>();
        Rate[10, 2] = GameObject.Find("UI/UserUI/AccuracyView/ScrollView/Grid/Aquatic/ThirdRate").GetComponent<Text>();
        Rate[11, 0] = GameObject.Find("UI/UserUI/AccuracyView/ScrollView/Grid/Landscaping/FirstRate").GetComponent<Text>();
        Rate[11, 1] = GameObject.Find("UI/UserUI/AccuracyView/ScrollView/Grid/Landscaping/SecondRate").GetComponent<Text>();
        Rate[11, 2] = GameObject.Find("UI/UserUI/AccuracyView/ScrollView/Grid/Landscaping/ThirdRate").GetComponent<Text>();
        Rate[12, 0] = GameObject.Find("UI/UserUI/AccuracyView/ScrollView/Grid/Biodiversity/FirstRate").GetComponent<Text>();
        Rate[12, 1] = GameObject.Find("UI/UserUI/AccuracyView/ScrollView/Grid/Biodiversity/SecondRate").GetComponent<Text>();
        Rate[12, 2] = GameObject.Find("UI/UserUI/AccuracyView/ScrollView/Grid/Biodiversity/ThirdRate").GetComponent<Text>();
        Rate[13, 0] = GameObject.Find("UI/UserUI/AccuracyView/ScrollView/Grid/Amphibian/FirstRate").GetComponent<Text>();
        Rate[13, 1] = GameObject.Find("UI/UserUI/AccuracyView/ScrollView/Grid/Amphibian/SecondRate").GetComponent<Text>();
        Rate[13, 2] = GameObject.Find("UI/UserUI/AccuracyView/ScrollView/Grid/Amphibian/ThirdRate").GetComponent<Text>();
    }
    // Use this for initialization
    void Start () {
        for (int i = 0; i < 14; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Rate[i, j].text = Accuracy.accuracy[i, j].ToString("#0.00")+"%";
            }               
        }

        //測試更新星星數量
        //CompareAnswer.TestUploadStar();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
