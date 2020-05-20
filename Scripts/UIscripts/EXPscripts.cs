using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EXPscripts : MonoBehaviour {

    public float MaxEXP;//最高血量
    public static float EXP; //目前血量
    public Text EXPText; //HP值顯示
    private string Update_Exp_Url = "http://140.115.126.115:3000/Update_EXP?account=";//"http://140.115.126.160/WordofWorld/Update_EXP.php"
    private string Update_Level_Url = "http://140.115.126.115:3000/Update_Level?account=";//"http://140.115.126.160/WordofWorld/Update_Level.php"
    public static float ExpTemp;
    public static void setupExp()
    {
        ExpTemp = EXP;
    }

    public static EXPscripts instance;

    // Use this for initialization
    void Start ()
    {
        instance = this;
        EXPText = GameObject.Find("ExpText").GetComponent<Text>(); //抓到對應的Text值
    }
	
	// Update is called once per frame
	void Update ()
    {
        this.transform.localPosition = new Vector2((-300 + 300 * (EXP / MaxEXP)), 0.0f); //血量條跟隨血量變化	
        EXPText.text = EXP +"%";
        if (EXP >= 100)
        {
            EXP = EXP - 100;
            Loadcharacter.LoadLevel += 1; //等級提升
            BagViewScript.badge[19].BadgesCount++; // 把值傳到獎章 (達成等級)
        }
        if (EXP != ExpTemp)
        {
            WWWForm Form = new WWWForm();

            //Form.AddField("Account", LoginScript.Account);
            //Form.AddField("EXP", EXP.ToString());
            WWW www = new WWW(Update_Exp_Url + LoginScript.Account+ "&EXP=" + EXP.ToString());
            if (www.error != null)
            {
                Debug.LogError("寫入錯誤");
            }
            setupExp();
        }
        if (Loadcharacter.LoadLevel != Loadcharacter.LevelTemp)
        {
            WWWForm Form = new WWWForm();

            //Form.AddField("Account", LoginScript.Account);
            //Form.AddField("Level", Loadcharacter.LoadLevel.ToString());
            WWW www = new WWW(Update_Level_Url + LoginScript.Account + "&level=" + Loadcharacter.LoadLevel);
            if (www.error != null)
            {
                Debug.LogError("寫入錯誤");
            }
            Loadcharacter.setupLevel();
        }
    }  
}
