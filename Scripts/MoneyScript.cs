using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;

public class MoneyScript : MonoBehaviour {

    public static int Money ; //目前金錢
    private string Update_Money_Url = "http://140.115.126.115:3000/Update_Money?account=";//"http://140.115.126.160/WordofWorld/Update_Money.php"
    public static int MoneyTemp;
    public static void setupMoney()
    {
        MoneyTemp = Money;
    }
    public Text MoneyText;

	// Use this for initialization
	void Start ()
    {
        MoneyText = GameObject.Find("MoneyText").GetComponent<Text>(); //抓到對應的Text值
    }
	
	// Update is called once per frame
	void Update ()
    {
        MoneyText.text = " " + Money + " ";
        if (Money != MoneyTemp)
        {
            BagViewScript.badge[2].BadgesCount = Money;
            WWWForm Form = new WWWForm();

            //Form.AddField("Account", LoginScript.Account);
            //Form.AddField("Money", Money);
            WWW www = new WWW(Update_Money_Url + LoginScript.Account+ "&Money=" + Money);
            if (www.error != null)
            {
                Debug.LogError("寫入錯誤");
            }
            setupMoney();
        }
    }
}
