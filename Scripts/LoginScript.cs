using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginScript : Photon.PunBehaviour//MonoBehaviour
{
    #region variables  
    //宣告變數都在這裡
    public static int Reward_Status;
    public static string Account = "";
    public static string Password = "";
    public string CurrentMenu = "Login";
    private string CreatAccountUrl = "http://140.115.126.115:3000/register?account=";
    private string LoginUrl = "http://140.115.126.115:3000/login?account=";
    private string ConfirmAccount = "";
    private string ConfirmPassword = "";
    private string CAccount = "";          //CreatAccount的Account欄位 
    private string CPassword = "";         //CreatAccount的Password欄位 

    Rect windowRect;
    int windowSwitch = -1;              //切換視窗編號
    float alpha = 0;
    public int windowWidth = 400;   //設定離開視窗大小
    public int windowHight = 150;
    #endregion
    // Use this for initialization
    void Start ()
    {
        windowRect = new Rect(
            (Screen.width - windowWidth) / 2,
            (Screen.height - windowHight) / 2,
            windowWidth,
            windowHight);
    }

    //圖形介面功能
    void OnGUI()
    {
        if (CurrentMenu == "Login")
        {
            LoginGUI();           //啟動Login函式
        }
        else if (CurrentMenu == "CreatAccount")
        {
            CreatAccountGUI();    //啟動CreatAccount函式
        }
        if (windowSwitch != -1) //切換視窗
        {
            GUIAlphaColor_0_To_1();
            windowRect = GUI.Window(0, windowRect, CreateWindow, "Confirm Window");
        }
    }
    void CreateWindow(int windowID)
    {
        if(windowSwitch == 0){
            GUI.Label(new Rect(150, 50, 300, 30), "帳號或密碼不一樣.");
        }
        else if (windowSwitch == 1)
        {
            GUI.Label(new Rect(40, 50, 400, 30), "This account has already been used. Please try again.");
        }
        else if (windowSwitch == 2)
        {
            GUI.Label(new Rect(100, 50, 400, 30), "Wrong password please try again.");
        }
        else if (windowSwitch == 3)
        {
            GUI.Label(new Rect(80, 50, 400, 30), "This account doesn't exist. Please try again.");
        }

        if (GUI.Button(new Rect(130, 110, 130, 20), "Cancel"))
        {
            windowSwitch = -1; //關掉視窗
        }
        GUI.DragWindow();
    }

    void GUIAlphaColor_0_To_1() //動畫
    {
        if (alpha < 1)
        {
            alpha += Time.deltaTime;
            GUI.color = new Color(1, 1, 1, alpha);
        }
    }

    // Update is called once per frame
    void Update ()
    {
	
	}

    #region Custom methods

    //登入GUL,建立登入視窗
    void LoginGUI()
    {
        GUI.Box(new Rect(Screen.width / 4, Screen.height / 4, 2 * (Screen.width / 4), 2 * (Screen.height / 4)), "Login"); //視窗大小依照顯示器不同調整;  x , y , 寬 , 高

        //if (GUI.Button(new Rect((Screen.width / 2) - 110, 420, 110, 25), "Creat Account"))//按鈕CreatAccount被按下之後
        //{
        //    CurrentMenu = "CreatAccount";                                                 //顯示註冊頁面
        //}
        if (GUI.Button(new Rect((Screen.width / 2)-55, 420, 110, 25), "登入"))       //按鈕Login被按下之後
        {
            StartCoroutine("LoginAccount");      
            //連線開始
        }

        GUI.Label(new Rect((Screen.width / 2) - 110, (Screen.height / 2) - (Screen.height / 8), 220, 23), "帳號:");
        Account = GUI.TextField(new Rect((Screen.width / 2) - 110, (Screen.height / 2) - (Screen.height / 8) + 25, 220, 23), Account);
        GUI.Label(new Rect((Screen.width / 2) - 110, (Screen.height / 2) - (Screen.height / 8) + 50, 220, 23), "密碼:");
        Password = GUI.PasswordField(new Rect((Screen.width / 2) - 110, (Screen.height / 2) - (Screen.height / 8) + 75, 220, 23), Password, "*"[0], 25);

    }

    //建立帳戶
    void CreatAccountGUI()
    {
        GUI.Box(new Rect(Screen.width / 4, Screen.height / 4, 2 * (Screen.width / 4), 2 * (Screen.height / 4)), "Creat Account");

        if (GUI.Button(new Rect((Screen.width / 2) - 110, 475, 110, 25), "Creat Account"))
        {
            if (ConfirmPassword == CPassword && ConfirmAccount == CAccount)
            {
                StartCoroutine("CreateAccount");
            }
            else
            {
                windowSwitch = 0; //切換視窗
                alpha = 0;
                Debug.Log("帳號密碼不一樣");
            }
        }
        if (GUI.Button(new Rect((Screen.width / 2), 475, 110, 25), "Back"))
        {
            CurrentMenu = "Login";
        }

        GUI.Label(new Rect((Screen.width / 2) - 110, 250, 220, 23), "Account:");
        CAccount = GUI.TextField(new Rect((Screen.width / 2) - 110, 275, 220, 23), CAccount);
        GUI.Label(new Rect((Screen.width / 2) - 110, 300, 220, 23), "Password:");
        CPassword = GUI.TextField(new Rect((Screen.width / 2) - 110, 325, 220, 23), CPassword);

        GUI.Label(new Rect((Screen.width / 2) - 110, 350, 220, 23), "Confirm Account:");
        ConfirmAccount = GUI.TextField(new Rect((Screen.width / 2) - 110, 370, 220, 23), ConfirmAccount);
        GUI.Label(new Rect((Screen.width / 2) - 110, 400, 220, 23), "Confirm Password:");
        ConfirmPassword = GUI.TextField(new Rect((Screen.width / 2) - 110, 425, 220, 23), ConfirmPassword);
    }
    #endregion


    public class Accounts
    {
        public string Account { get; set; }
        public string Password { get; set; }
        public int Reward_Status { get; set; }
    }

    #region CoRoutines
    //真正連資料庫Create account，已經未使用
    IEnumerator CreateAccount()
    {
        WWWForm Form = new WWWForm();

        //Form.AddField("Account", CAccount);    //抓註冊帳號值
        //Form.AddField("Password", CPassword); //抓註冊密碼值

        WWW CreateAccountWWW = new WWW(CreatAccountUrl+CAccount+ "&password=" + CPassword);

        //等待php回傳給unity

        yield return CreateAccountWWW;

        if (CreateAccountWWW.error != null)
        {
            Debug.LogError("Cannot connect to Account Creation");
        }
        else
        {
            string CreateAccountText = CreateAccountWWW.text;     //回傳php網頁顯示的文字

            // Debug.Log(CreateAccountText);                       //回傳php網頁顯示的文字 , 用來測試網頁回傳甚麼動作以利我們寫程式接著要執行甚麼動作

            if (CreateAccountText == "success")
            {
                Debug.Log("Success: Account Created");
                CurrentMenu = "Login";
            }
            if (CreateAccountText == "AccountIsUsed")
            {
                Debug.Log("Account Already Used");
                windowSwitch = 1; //切換視窗
                alpha = 0;
            }
        }
    }

    IEnumerator LoginAccount()
    {
        WWWForm Form = new WWWForm();

        //Form.AddField("Account", Account);
        //Form.AddField("Password", Password);

        WWW LoginAccountWWW = new WWW(LoginUrl+Account+"&password="+Password);

        yield return LoginAccountWWW;

        if (LoginAccountWWW.error != null)
        {
            Debug.LogError("Cannot connect to Login");
        }
        else
        {
            try
            {
                List<Accounts> account_list = JsonConvert.DeserializeObject<List<Accounts>>(LoginAccountWWW.text);
                Accounts database_account = account_list[0];

                if (database_account.Account == Account && database_account.Password == Password)
                {
                    Debug.Log("Get the value of reward status" + database_account.Reward_Status);
                    Reward_Status = database_account.Reward_Status;
                    SceneManager.LoadScene(1);//載入場景
                }
                else
                {
                    windowSwitch = 2; //帳號密碼錯誤 切換視窗
                    alpha = 0;
                }
            }
            catch (Exception e)
            {
                windowSwitch = 2; //帳號密碼錯誤 切換視窗
                alpha = 0;
            }
        }
    }
    #endregion
}
