using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPscripts : MonoBehaviour {

    public float MaxHP;//最高血量
    public static float HP = 100; //目前血量
    public Text HPText; //HP值顯示
    //public static bool addPower = false; //一開始不需要加能量
    //public static bool minusPower = false; //時間過太久能量要被減低唷
    public static HPscripts instance;
    private string Update_Hp_Url = "http://140.115.126.115:3000/Update_HP?account=";//"http://140.115.126.160/WordofWorld/Update_HP.php"
    public static float HpTemp;
    public static void setupHp()
    {
        HpTemp = HP;
    }

    // Use this for initialization
    void Start ()
    {
        instance = this;
    }
	
	// Update is called once per frame
	void Update ()
    {
        this.transform.localPosition = new Vector3((-350 + 350 * (HP / MaxHP)), 0.0f, 0.0f); //能量條隨著能力值改變
        HPText.text = HP + " / 100"; // 更改PowerText的內容	

        if (HP != HpTemp)
        {
            WWWForm Form = new WWWForm();
            
            //Form.AddField("Account", LoginScript.Account);
            //Form.AddField("HP",HP.ToString());
            WWW www = new WWW(Update_Hp_Url + LoginScript.Account + "&HP=" + HP.ToString());
            if (www.error != null)
            {
                Debug.LogError("寫入錯誤");
            }
            setupHp();
        }
    }
}

