using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public class ServerManager : Photon.PunBehaviour
{
    public GameObject PersonCamera;            //第三方攝影機
    public PersonCamera Camera;                //使用Camera的Script
    public GameObject MinimapCamera;
    public MinimapCamera MiniCamera;

    //public GameObject ConfirmButton;           //進入遊戲的按鈕
    //public GameObject UI; //9/16修正
   
    public static ServerManager instance;      //設為一個全域變數 連線伺服器全部場景都要使用
    public static GameObject Player;           //玩家角色物件
    public bool selectplayer = false;
    // Use this for initialization
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings("MMOGame_v1.0");    //版本名稱
        //PersonCamera.SetActive(false);                         //第一次執行 之後就不會執行了   
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void Awake()
    {
        if (instance != null)
        {
            DestroyImmediate(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        instance = this;

        //UI = GameObject.Find("UI"); //9/16修正
        PhotonNetwork.automaticallySyncScene = true;
        SceneManager.sceneLoaded += this.OnLoadCallback; //回傳新版的載入場景,舊版刪除這行

        //UI.SetActive(false); //9/16修正  
    }

    public override void OnConnectedToMaster()
    {
        //連上 MasterServer 後,  Button (UI) 就可以顯示或是執行其它後續動作.
        Debug.Log("已經連上遊戲伺服器");
        base.OnConnectedToMaster();
    }


    public void JoinGameRoom() //加入房間
    {
        RoomOptions options = new RoomOptions();
        options.MaxPlayers = 100;                                                //遊戲人數
        PhotonNetwork.JoinOrCreateRoom("GameRoom", options, null);             //房間名稱
        Debug.Log("創建房間中...");
        DestroyImmediate(MenuControl.UI_Menu);
        DestroyImmediate(Loadcharacter.Player);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("您已進入遊戲室!!");
        //UI.SetActive(true);//9/16修正

        // 如果是Master Client, 即可建立/初始化,與載入遊戲場景

        if (PhotonNetwork.isMasterClient)
        {          
            PersonCamera.SetActive(true);
            PhotonNetwork.LoadLevel("LakeScene");//舊版本請將數字改為場景名稱
            //SceneManager.LoadSceneAsync("LakeScene");
            Debug.Log("第一位登入的玩家");  
        }
        else
        {         
            PersonCamera.SetActive(true);
            //PhotonNetwork.LoadLevel(4);//舊版本請將數字改為場景名稱
            Debug.Log("目前已經有玩家在線上!");         
        }

        if (selectplayer == false)
        {
            if (Loadcharacter.LoadsexID == 1)
            {
                Debug.Log("載入場景,玩家為男性");
                CallMaleResources();
                DontDestroyOnLoad(Player);
                Camera.Target = Player.transform;
                MiniCamera.Target = Player.transform;
                MonsterReborn.hero = Player.transform; // 抓角色位置
                selectplayer = true;
            }
            if (Loadcharacter.LoadsexID == 2)
            {
                Debug.Log("載入場景,玩家為女性");
                CallFemaleResources();
                DontDestroyOnLoad(Player);
                Camera.Target = Player.transform;
                MiniCamera.Target = Player.transform;
                MonsterReborn.hero = Player.transform; // 抓角色位置
                selectplayer = true;
            }
        }
    }

    void OnLoadCallback(Scene scene, LoadSceneMode sceneMode) //新版的載入場景,每次載入場景都會跑這行程式碼
    {
        // 若不在Photon的遊戲室內, 則網路有問題..
        if (!PhotonNetwork.inRoom)
            return;
        
        Debug.Log("OnLoadCallback程式碼執行");
    }

    /*
    //舊版的寫法     
         void OnLevelWasLoaded(int levelNumber)
    {
        // 若不在Photon的遊戲室內, 則網路有問題..
        if (!PhotonNetwork.inRoom)
            return;

        Debug.Log("我們已進入遊戲場景了,耶~");
        localPlayer = PhotonNetwork.Instantiate("Player",new Vector3(0,0.5f,0),Quaternion.identity, 0);
        Camera.Target = localPlayer.transform;
    }

    */
    public void CallMaleResources()
    {
        //--------------------------------------------------------------------------------
        if (Loadcharacter.LoadclothesID == 1 && Loadcharacter.LoadpantsID == 1 && Loadcharacter.LoadshoesID == 1)
        {
            Player = PhotonNetwork.Instantiate("MaleType111", new Vector3(0, -11, 0), Quaternion.Euler(0,180,0) , 0);
        }
        if (Loadcharacter.LoadclothesID == 1 && Loadcharacter.LoadpantsID == 1 && Loadcharacter.LoadshoesID == 2)
        {          
            Player = PhotonNetwork.Instantiate("MaleType112", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0) , 0);
        }
        if (Loadcharacter.LoadclothesID == 1 && Loadcharacter.LoadpantsID == 1 && Loadcharacter.LoadshoesID == 3)
        {       
            Player = PhotonNetwork.Instantiate("MaleType113", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0) , 0);
        }
        if (Loadcharacter.LoadclothesID == 1 && Loadcharacter.LoadpantsID == 2 && Loadcharacter.LoadshoesID == 1)
        {
            Player = PhotonNetwork.Instantiate("MaleType121", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0) , 0);
            //Player = Instantiate(Resources.Load("MaleType121", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 1 && Loadcharacter.LoadpantsID == 2 && Loadcharacter.LoadshoesID == 2)
        {
            Player = PhotonNetwork.Instantiate("MaleType122", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("MaleType122", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 1 && Loadcharacter.LoadpantsID == 2 && Loadcharacter.LoadshoesID == 3)
        {
            Player = PhotonNetwork.Instantiate("MaleType123", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("MaleType123", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 1 && Loadcharacter.LoadpantsID == 3 && Loadcharacter.LoadshoesID == 1)
        {
            Player = PhotonNetwork.Instantiate("MaleType131", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("MaleType131", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 1 && Loadcharacter.LoadpantsID == 3 && Loadcharacter.LoadshoesID == 2)
        {
            Player = PhotonNetwork.Instantiate("MaleType132", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("MaleType132", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 1 && Loadcharacter.LoadpantsID == 3 && Loadcharacter.LoadshoesID == 3)
        {
            Player = PhotonNetwork.Instantiate("MaleType133", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("MaleType133", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 1 && Loadcharacter.LoadpantsID == 4 && Loadcharacter.LoadshoesID == 1)
        {
            Player = PhotonNetwork.Instantiate("MaleType141", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("MaleType141", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 1 && Loadcharacter.LoadpantsID == 4 && Loadcharacter.LoadshoesID == 2)
        {
            Player = PhotonNetwork.Instantiate("MaleType142", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("MaleType142", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 1 && Loadcharacter.LoadpantsID == 4 && Loadcharacter.LoadshoesID == 3)
        {
            Player = PhotonNetwork.Instantiate("MaleType143", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("MaleType143", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 1 && Loadcharacter.LoadpantsID == 5 && Loadcharacter.LoadshoesID == 1)
        {
            Player = PhotonNetwork.Instantiate("MaleType151", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("MaleType151", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 1 && Loadcharacter.LoadpantsID == 5 && Loadcharacter.LoadshoesID == 2)
        {
            Player = PhotonNetwork.Instantiate("MaleType152", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("MaleType152", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 1 && Loadcharacter.LoadpantsID == 5 && Loadcharacter.LoadshoesID == 3)
        {
            Player = PhotonNetwork.Instantiate("MaleType153", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("MaleType153", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 1 && Loadcharacter.LoadpantsID == 6 && Loadcharacter.LoadshoesID == 1)
        {
            Player = PhotonNetwork.Instantiate("MaleType161", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("MaleType161", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 1 && Loadcharacter.LoadpantsID == 6 && Loadcharacter.LoadshoesID == 2)
        {
            Player = PhotonNetwork.Instantiate("MaleType162", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("MaleType162", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 1 && Loadcharacter.LoadpantsID == 6 && Loadcharacter.LoadshoesID == 3)
        {
            Player = PhotonNetwork.Instantiate("MaleType163", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("MaleType163", typeof(GameObject))) as GameObject;
        }
        //-------------------------------------------------------------------------------------------
        if (Loadcharacter.LoadclothesID == 2 && Loadcharacter.LoadpantsID == 1 && Loadcharacter.LoadshoesID == 1)
        {
            Player = PhotonNetwork.Instantiate("MaleType211", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = PhotonNetwork.Instantiate("MaleType211", new Vector3(0, 0, 0), Quaternion.identity, 0);
        }
        if (Loadcharacter.LoadclothesID == 2 && Loadcharacter.LoadpantsID == 1 && Loadcharacter.LoadshoesID == 2)
        {
            Player = PhotonNetwork.Instantiate("MaleType212", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("MaleType212", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 2 && Loadcharacter.LoadpantsID == 1 && Loadcharacter.LoadshoesID == 3)
        {
            Player = PhotonNetwork.Instantiate("MaleType213", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("MaleType213", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 2 && Loadcharacter.LoadpantsID == 2 && Loadcharacter.LoadshoesID == 1)
        {
            Player = PhotonNetwork.Instantiate("MaleType221", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("MaleType221", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 2 && Loadcharacter.LoadpantsID == 2 && Loadcharacter.LoadshoesID == 2)
        {
            Player = PhotonNetwork.Instantiate("MaleType222", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("MaleType222", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 2 && Loadcharacter.LoadpantsID == 2 && Loadcharacter.LoadshoesID == 3)
        {
            Player = PhotonNetwork.Instantiate("MaleType223", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("MaleType223", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 2 && Loadcharacter.LoadpantsID == 3 && Loadcharacter.LoadshoesID == 1)
        {
            Player = PhotonNetwork.Instantiate("MaleType231", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("MaleType231", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 2 && Loadcharacter.LoadpantsID == 3 && Loadcharacter.LoadshoesID == 2)
        {
            Player = PhotonNetwork.Instantiate("MaleType232", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("MaleType232", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 2 && Loadcharacter.LoadpantsID == 3 && Loadcharacter.LoadshoesID == 3)
        {
            Player = PhotonNetwork.Instantiate("MaleType233", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("MaleType233", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 2 && Loadcharacter.LoadpantsID == 4 && Loadcharacter.LoadshoesID == 1)
        {
            Player = PhotonNetwork.Instantiate("MaleType241", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("MaleType241", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 2 && Loadcharacter.LoadpantsID == 4 && Loadcharacter.LoadshoesID == 2)
        {
            Player = PhotonNetwork.Instantiate("MaleType242", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("MaleType242", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 2 && Loadcharacter.LoadpantsID == 4 && Loadcharacter.LoadshoesID == 3)
        {
            Player = PhotonNetwork.Instantiate("MaleType243", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("MaleType243", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 2 && Loadcharacter.LoadpantsID == 5 && Loadcharacter.LoadshoesID == 1)
        {
            Player = PhotonNetwork.Instantiate("MaleType251", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("MaleType251", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 2 && Loadcharacter.LoadpantsID == 5 && Loadcharacter.LoadshoesID == 2)
        {
            Player = PhotonNetwork.Instantiate("MaleType252", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("MaleType252", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 2 && Loadcharacter.LoadpantsID == 5 && Loadcharacter.LoadshoesID == 3)
        {
            Player = PhotonNetwork.Instantiate("MaleType253", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("MaleType253", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 2 && Loadcharacter.LoadpantsID == 6 && Loadcharacter.LoadshoesID == 1)
        {
            Player = PhotonNetwork.Instantiate("MaleType261", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("MaleType261", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 2 && Loadcharacter.LoadpantsID == 6 && Loadcharacter.LoadshoesID == 2)
        {
            Player = PhotonNetwork.Instantiate("MaleType262", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("MaleType262", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 2 && Loadcharacter.LoadpantsID == 6 && Loadcharacter.LoadshoesID == 3)
        {
            Player = PhotonNetwork.Instantiate("MaleType263", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("MaleType263", typeof(GameObject))) as GameObject;
        }
        //-----------------------------------------------------------------------------------------------------------
        if (Loadcharacter.LoadclothesID == 3 && Loadcharacter.LoadpantsID == 1 && Loadcharacter.LoadshoesID == 1)
        {
            Player = PhotonNetwork.Instantiate("MaleType311", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("MaleType311", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 3 && Loadcharacter.LoadpantsID == 1 && Loadcharacter.LoadshoesID == 2)
        {
            Player = PhotonNetwork.Instantiate("MaleType312", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("MaleType312", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 3 && Loadcharacter.LoadpantsID == 1 && Loadcharacter.LoadshoesID == 3)
        {
            Player = PhotonNetwork.Instantiate("MaleType313", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("MaleType313", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 3 && Loadcharacter.LoadpantsID == 2 && Loadcharacter.LoadshoesID == 1)
        {
            Player = PhotonNetwork.Instantiate("MaleType321", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("MaleType321", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 3 && Loadcharacter.LoadpantsID == 2 && Loadcharacter.LoadshoesID == 2)
        {
            Player = PhotonNetwork.Instantiate("MaleType322", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("MaleType322", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 3 && Loadcharacter.LoadpantsID == 2 && Loadcharacter.LoadshoesID == 3)
        {
            Player = PhotonNetwork.Instantiate("MaleType323", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("MaleType323", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 3 && Loadcharacter.LoadpantsID == 3 && Loadcharacter.LoadshoesID == 1)
        {
            Player = PhotonNetwork.Instantiate("MaleType331", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("MaleType331", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 3 && Loadcharacter.LoadpantsID == 3 && Loadcharacter.LoadshoesID == 2)
        {
            Player = PhotonNetwork.Instantiate("MaleType332", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("MaleType332", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 3 && Loadcharacter.LoadpantsID == 3 && Loadcharacter.LoadshoesID == 3)
        {
            Player = PhotonNetwork.Instantiate("MaleType333", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("MaleType333", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 3 && Loadcharacter.LoadpantsID == 4 && Loadcharacter.LoadshoesID == 1)
        {
            Player = PhotonNetwork.Instantiate("MaleType341", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("MaleType341", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 3 && Loadcharacter.LoadpantsID == 4 && Loadcharacter.LoadshoesID == 2)
        {
            Player = PhotonNetwork.Instantiate("MaleType342", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("MaleType342", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 3 && Loadcharacter.LoadpantsID == 4 && Loadcharacter.LoadshoesID == 3)
        {
            Player = PhotonNetwork.Instantiate("MaleType343", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("MaleType343", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 3 && Loadcharacter.LoadpantsID == 5 && Loadcharacter.LoadshoesID == 1)
        {
            Player = PhotonNetwork.Instantiate("MaleType351", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("MaleType351", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 3 && Loadcharacter.LoadpantsID == 5 && Loadcharacter.LoadshoesID == 2)
        {
            Player = PhotonNetwork.Instantiate("MaleType352", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("MaleType352", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 3 && Loadcharacter.LoadpantsID == 5 && Loadcharacter.LoadshoesID == 3)
        {
            Player = PhotonNetwork.Instantiate("MaleType353", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("MaleType353", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 3 && Loadcharacter.LoadpantsID == 6 && Loadcharacter.LoadshoesID == 1)
        {
            Player = PhotonNetwork.Instantiate("MaleType361", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("MaleType361", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 3 && Loadcharacter.LoadpantsID == 6 && Loadcharacter.LoadshoesID == 2)
        {
            Player = PhotonNetwork.Instantiate("MaleType362", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("MaleType362", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 3 && Loadcharacter.LoadpantsID == 6 && Loadcharacter.LoadshoesID == 3)
        {
            Player = PhotonNetwork.Instantiate("MaleType363", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("MaleType363", typeof(GameObject))) as GameObject;
        }
        //-----------------------------------------------------------------------------------------------------------
        if (Loadcharacter.LoadclothesID == 4 && Loadcharacter.LoadpantsID == 1 && Loadcharacter.LoadshoesID == 1)
        {
            Player = PhotonNetwork.Instantiate("MaleType411", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("MaleType411", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 4 && Loadcharacter.LoadpantsID == 1 && Loadcharacter.LoadshoesID == 2)
        {
            Player = PhotonNetwork.Instantiate("MaleType412", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("MaleType412", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 4 && Loadcharacter.LoadpantsID == 1 && Loadcharacter.LoadshoesID == 3)
        {
            Player = PhotonNetwork.Instantiate("MaleType413", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("MaleType413", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 4 && Loadcharacter.LoadpantsID == 2 && Loadcharacter.LoadshoesID == 1)
        {
            Player = PhotonNetwork.Instantiate("MaleType421", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("MaleType421", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 4 && Loadcharacter.LoadpantsID == 2 && Loadcharacter.LoadshoesID == 2)
        {
            Player = PhotonNetwork.Instantiate("MaleType422", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("MaleType422", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 4 && Loadcharacter.LoadpantsID == 2 && Loadcharacter.LoadshoesID == 3)
        {
            Player = PhotonNetwork.Instantiate("MaleType423", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("MaleType423", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 4 && Loadcharacter.LoadpantsID == 3 && Loadcharacter.LoadshoesID == 1)
        {
            Player = PhotonNetwork.Instantiate("MaleType431", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("MaleType431", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 4 && Loadcharacter.LoadpantsID == 3 && Loadcharacter.LoadshoesID == 2)
        {
            Player = PhotonNetwork.Instantiate("MaleType432", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("MaleType432", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 4 && Loadcharacter.LoadpantsID == 3 && Loadcharacter.LoadshoesID == 3)
        {
            Player = PhotonNetwork.Instantiate("MaleType433", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("MaleType433", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 4 && Loadcharacter.LoadpantsID == 4 && Loadcharacter.LoadshoesID == 1)
        {
            Player = PhotonNetwork.Instantiate("MaleType441", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("MaleType441", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 4 && Loadcharacter.LoadpantsID == 4 && Loadcharacter.LoadshoesID == 2)
        {
            Player = PhotonNetwork.Instantiate("MaleType442", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("MaleType442", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 4 && Loadcharacter.LoadpantsID == 4 && Loadcharacter.LoadshoesID == 3)
        {
            Player = PhotonNetwork.Instantiate("MaleType443", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("MaleType443", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 4 && Loadcharacter.LoadpantsID == 5 && Loadcharacter.LoadshoesID == 1)
        {
            Player = PhotonNetwork.Instantiate("MaleType451", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = PhotonNetwork.Instantiate("MaleType451", new Vector3(0, 0, 0), Quaternion.identity, 0);
        }
        if (Loadcharacter.LoadclothesID == 4 && Loadcharacter.LoadpantsID == 5 && Loadcharacter.LoadshoesID == 2)
        {
            Player = PhotonNetwork.Instantiate("MaleType452", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("MaleType452", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 4 && Loadcharacter.LoadpantsID == 5 && Loadcharacter.LoadshoesID == 3)
        {
            Player = PhotonNetwork.Instantiate("MaleType453", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("MaleType453", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 4 && Loadcharacter.LoadpantsID == 6 && Loadcharacter.LoadshoesID == 1)
        {
            Player = PhotonNetwork.Instantiate("MaleType461", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("MaleType461", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 4 && Loadcharacter.LoadpantsID == 6 && Loadcharacter.LoadshoesID == 2)
        {
            Player = PhotonNetwork.Instantiate("MaleType462", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("MaleType462", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 4 && Loadcharacter.LoadpantsID == 6 && Loadcharacter.LoadshoesID == 3)
        {
            Player = PhotonNetwork.Instantiate("MaleType463", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("MaleType463", typeof(GameObject))) as GameObject;
        }
        //-----------------------------------------------------------------------------------------------------------
        if (Loadcharacter.LoadclothesID == 5 && Loadcharacter.LoadpantsID == 1 && Loadcharacter.LoadshoesID == 1)
        {
            Player = PhotonNetwork.Instantiate("MaleType511", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("MaleType511", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 5 && Loadcharacter.LoadpantsID == 1 && Loadcharacter.LoadshoesID == 2)
        {
            Player = PhotonNetwork.Instantiate("MaleType512", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("MaleType512", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 5 && Loadcharacter.LoadpantsID == 1 && Loadcharacter.LoadshoesID == 3)
        {
            Player = PhotonNetwork.Instantiate("MaleType513", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("MaleType513", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 5 && Loadcharacter.LoadpantsID == 2 && Loadcharacter.LoadshoesID == 1)
        {
            Player = PhotonNetwork.Instantiate("MaleType521", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("MaleType521", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 5 && Loadcharacter.LoadpantsID == 2 && Loadcharacter.LoadshoesID == 2)
        {
            Player = PhotonNetwork.Instantiate("MaleType522", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("MaleType522", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 5 && Loadcharacter.LoadpantsID == 2 && Loadcharacter.LoadshoesID == 3)
        {
            Player = PhotonNetwork.Instantiate("MaleType523", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("MaleType523", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 5 && Loadcharacter.LoadpantsID == 3 && Loadcharacter.LoadshoesID == 1)
        {
            Player = PhotonNetwork.Instantiate("MaleType531", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("MaleType531", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 5 && Loadcharacter.LoadpantsID == 3 && Loadcharacter.LoadshoesID == 2)
        {
            Player = PhotonNetwork.Instantiate("MaleType532", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("MaleType532", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 5 && Loadcharacter.LoadpantsID == 3 && Loadcharacter.LoadshoesID == 3)
        {
            Player = PhotonNetwork.Instantiate("MaleType533", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("MaleType533", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 5 && Loadcharacter.LoadpantsID == 4 && Loadcharacter.LoadshoesID == 1)
        {
            Player = PhotonNetwork.Instantiate("MaleType541", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("MaleType541", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 5 && Loadcharacter.LoadpantsID == 4 && Loadcharacter.LoadshoesID == 2)
        {
            Player = PhotonNetwork.Instantiate("MaleType542", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("MaleType542", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 5 && Loadcharacter.LoadpantsID == 4 && Loadcharacter.LoadshoesID == 3)
        {
            Player = PhotonNetwork.Instantiate("MaleType543", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("MaleType543", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 5 && Loadcharacter.LoadpantsID == 5 && Loadcharacter.LoadshoesID == 1)
        {
            Player = PhotonNetwork.Instantiate("MaleType551", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("MaleType551", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 5 && Loadcharacter.LoadpantsID == 5 && Loadcharacter.LoadshoesID == 2)
        {
            Player = PhotonNetwork.Instantiate("MaleType552", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("MaleType552", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 5 && Loadcharacter.LoadpantsID == 5 && Loadcharacter.LoadshoesID == 3)
        {
            Player = PhotonNetwork.Instantiate("MaleType553", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("MaleType553", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 5 && Loadcharacter.LoadpantsID == 6 && Loadcharacter.LoadshoesID == 1)
        {
            Player = PhotonNetwork.Instantiate("MaleType561", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("MaleType561", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 5 && Loadcharacter.LoadpantsID == 6 && Loadcharacter.LoadshoesID == 2)
        {
            Player = PhotonNetwork.Instantiate("MaleType562", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("MaleType562", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 5 && Loadcharacter.LoadpantsID == 6 && Loadcharacter.LoadshoesID == 3)
        {
            Player = PhotonNetwork.Instantiate("MaleType563", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("MaleType563", typeof(GameObject))) as GameObject;
        }
        //-----------------------------------------------------------------------------------------------------------
        if (Loadcharacter.LoadclothesID == 6 && Loadcharacter.LoadpantsID == 1 && Loadcharacter.LoadshoesID == 1)
        {
            Player = PhotonNetwork.Instantiate("MaleType611", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("MaleType611", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 6 && Loadcharacter.LoadpantsID == 1 && Loadcharacter.LoadshoesID == 2)
        {
            Player = PhotonNetwork.Instantiate("MaleType612", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("MaleType612", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 6 && Loadcharacter.LoadpantsID == 1 && Loadcharacter.LoadshoesID == 3)
        {
            Player = PhotonNetwork.Instantiate("MaleType613", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("MaleType613", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 6 && Loadcharacter.LoadpantsID == 2 && Loadcharacter.LoadshoesID == 1)
        {
            Player = PhotonNetwork.Instantiate("MaleType621", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("MaleType621", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 6 && Loadcharacter.LoadpantsID == 2 && Loadcharacter.LoadshoesID == 2)
        {
            Player = PhotonNetwork.Instantiate("MaleType622", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("MaleType622", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 6 && Loadcharacter.LoadpantsID == 2 && Loadcharacter.LoadshoesID == 3)
        {
            Player = PhotonNetwork.Instantiate("MaleType623", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("MaleType623", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 6 && Loadcharacter.LoadpantsID == 3 && Loadcharacter.LoadshoesID == 1)
        {
            Player = PhotonNetwork.Instantiate("MaleType631", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("MaleType631", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 6 && Loadcharacter.LoadpantsID == 3 && Loadcharacter.LoadshoesID == 2)
        {
            Player = PhotonNetwork.Instantiate("MaleType632", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("MaleType632", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 6 && Loadcharacter.LoadpantsID == 3 && Loadcharacter.LoadshoesID == 3)
        {
            Player = PhotonNetwork.Instantiate("MaleType633", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("MaleType633", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 6 && Loadcharacter.LoadpantsID == 4 && Loadcharacter.LoadshoesID == 1)
        {
            Player = PhotonNetwork.Instantiate("MaleType641", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("MaleType641", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 6 && Loadcharacter.LoadpantsID == 4 && Loadcharacter.LoadshoesID == 2)
        {
            Player = PhotonNetwork.Instantiate("MaleType642", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("MaleType642", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 6 && Loadcharacter.LoadpantsID == 4 && Loadcharacter.LoadshoesID == 3)
        {
            Player = PhotonNetwork.Instantiate("MaleType643", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("MaleType643", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 6 && Loadcharacter.LoadpantsID == 5 && Loadcharacter.LoadshoesID == 1)
        {
            Player = PhotonNetwork.Instantiate("MaleType651", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("MaleType651", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 6 && Loadcharacter.LoadpantsID == 5 && Loadcharacter.LoadshoesID == 2)
        {
            Player = PhotonNetwork.Instantiate("MaleType652", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("MaleType652", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 6 && Loadcharacter.LoadpantsID == 5 && Loadcharacter.LoadshoesID == 3)
        {
            Player = PhotonNetwork.Instantiate("MaleType653", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("MaleType653", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 6 && Loadcharacter.LoadpantsID == 6 && Loadcharacter.LoadshoesID == 1)
        {
            Player = PhotonNetwork.Instantiate("MaleType661", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("MaleType661", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 6 && Loadcharacter.LoadpantsID == 6 && Loadcharacter.LoadshoesID == 2)
        {
            Player = PhotonNetwork.Instantiate("MaleType662", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("MaleType662", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 6 && Loadcharacter.LoadpantsID == 6 && Loadcharacter.LoadshoesID == 3)
        {
            Player = PhotonNetwork.Instantiate("MaleType663", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("MaleType663", typeof(GameObject))) as GameObject;
        }
        //-----------------------------------------------------------------------------------------------------------
    }
    public void CallFemaleResources()
    {
        if (Loadcharacter.LoadclothesID == 1 && Loadcharacter.LoadpantsID == 1 && Loadcharacter.LoadshoesID == 1)
        {
            Player = PhotonNetwork.Instantiate("FemaleType111", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType111", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 1 && Loadcharacter.LoadpantsID == 1 && Loadcharacter.LoadshoesID == 2)
        {
            Player = PhotonNetwork.Instantiate("FemaleType112", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType112", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 1 && Loadcharacter.LoadpantsID == 1 && Loadcharacter.LoadshoesID == 3)
        {
            Player = PhotonNetwork.Instantiate("FemaleType113", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType113", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 1 && Loadcharacter.LoadpantsID == 2 && Loadcharacter.LoadshoesID == 1)
        {
            Player = PhotonNetwork.Instantiate("FemaleType121", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType121", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 1 && Loadcharacter.LoadpantsID == 2 && Loadcharacter.LoadshoesID == 2)
        {
            Player = PhotonNetwork.Instantiate("FemaleType122", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType122", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 1 && Loadcharacter.LoadpantsID == 2 && Loadcharacter.LoadshoesID == 3)
        {
            Player = PhotonNetwork.Instantiate("FemaleType123", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType123", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 1 && Loadcharacter.LoadpantsID == 3 && Loadcharacter.LoadshoesID == 1)
        {
            Player = PhotonNetwork.Instantiate("FemaleType131", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType131", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 1 && Loadcharacter.LoadpantsID == 3 && Loadcharacter.LoadshoesID == 2)
        {
            Player = PhotonNetwork.Instantiate("FemaleType132", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType132", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 1 && Loadcharacter.LoadpantsID == 3 && Loadcharacter.LoadshoesID == 3)
        {
            Player = PhotonNetwork.Instantiate("FemaleType133", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType133", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 1 && Loadcharacter.LoadpantsID == 4 && Loadcharacter.LoadshoesID == 1)
        {
            Player = PhotonNetwork.Instantiate("FemaleType141", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType141", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 1 && Loadcharacter.LoadpantsID == 4 && Loadcharacter.LoadshoesID == 2)
        {
            Player = PhotonNetwork.Instantiate("FemaleType142", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType142", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 1 && Loadcharacter.LoadpantsID == 4 && Loadcharacter.LoadshoesID == 3)
        {
            Player = PhotonNetwork.Instantiate("FemaleType143", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType143", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 1 && Loadcharacter.LoadpantsID == 5 && Loadcharacter.LoadshoesID == 1)
        {
            Player = PhotonNetwork.Instantiate("FemaleType151", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType151", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 1 && Loadcharacter.LoadpantsID == 5 && Loadcharacter.LoadshoesID == 2)
        {
            Player = PhotonNetwork.Instantiate("FemaleType152", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType152", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 1 && Loadcharacter.LoadpantsID == 5 && Loadcharacter.LoadshoesID == 3)
        {
            Player = PhotonNetwork.Instantiate("FemaleType153", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType153", typeof(GameObject))) as GameObject;
        }
        //-----------------------------------------------------------------------------------------------------------------------
        if (Loadcharacter.LoadclothesID == 2 && Loadcharacter.LoadpantsID == 1 && Loadcharacter.LoadshoesID == 1)
        {
            Player = PhotonNetwork.Instantiate("FemaleType211", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType211", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 2 && Loadcharacter.LoadpantsID == 1 && Loadcharacter.LoadshoesID == 2)
        {
            Player = PhotonNetwork.Instantiate("FemaleType212", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType212", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 2 && Loadcharacter.LoadpantsID == 1 && Loadcharacter.LoadshoesID == 3)
        {
            Player = PhotonNetwork.Instantiate("FemaleType213", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType213", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 2 && Loadcharacter.LoadpantsID == 2 && Loadcharacter.LoadshoesID == 1)
        {
            Player = PhotonNetwork.Instantiate("FemaleType221", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType221", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 2 && Loadcharacter.LoadpantsID == 2 && Loadcharacter.LoadshoesID == 2)
        {
            Player = PhotonNetwork.Instantiate("FemaleType222", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType222", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 2 && Loadcharacter.LoadpantsID == 2 && Loadcharacter.LoadshoesID == 3)
        {
            Player = PhotonNetwork.Instantiate("FemaleType223", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType223", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 2 && Loadcharacter.LoadpantsID == 3 && Loadcharacter.LoadshoesID == 1)
        {
            Player = PhotonNetwork.Instantiate("FemaleType231", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType231", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 2 && Loadcharacter.LoadpantsID == 3 && Loadcharacter.LoadshoesID == 2)
        {
            Player = PhotonNetwork.Instantiate("FemaleType232", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType232", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 2 && Loadcharacter.LoadpantsID == 3 && Loadcharacter.LoadshoesID == 3)
        {
            Player = PhotonNetwork.Instantiate("FemaleType233", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType233", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 2 && Loadcharacter.LoadpantsID == 4 && Loadcharacter.LoadshoesID == 1)
        {
            Player = PhotonNetwork.Instantiate("FemaleType241", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType241", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 2 && Loadcharacter.LoadpantsID == 4 && Loadcharacter.LoadshoesID == 2)
        {
            Player = PhotonNetwork.Instantiate("FemaleType242", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
           //Player = Instantiate(Resources.Load("FemaleType242", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 2 && Loadcharacter.LoadpantsID == 4 && Loadcharacter.LoadshoesID == 3)
        {
            Player = PhotonNetwork.Instantiate("FemaleType243", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType243", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 2 && Loadcharacter.LoadpantsID == 5 && Loadcharacter.LoadshoesID == 1)
        {
            Player = PhotonNetwork.Instantiate("FemaleType251", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType251", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 2 && Loadcharacter.LoadpantsID == 5 && Loadcharacter.LoadshoesID == 2)
        {
            Player = PhotonNetwork.Instantiate("FemaleType252", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType252", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 2 && Loadcharacter.LoadpantsID == 5 && Loadcharacter.LoadshoesID == 3)
        {
            Player = PhotonNetwork.Instantiate("FemaleType253", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType253", typeof(GameObject))) as GameObject;
        }
        //-----------------------------------------------------------------------------------------------------------------------
        if (Loadcharacter.LoadclothesID == 3 && Loadcharacter.LoadpantsID == 1 && Loadcharacter.LoadshoesID == 1)
        {
            Player = PhotonNetwork.Instantiate("FemaleType311", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType311", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 3 && Loadcharacter.LoadpantsID == 1 && Loadcharacter.LoadshoesID == 2)
        {
            Player = PhotonNetwork.Instantiate("FemaleType312", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType312", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 3 && Loadcharacter.LoadpantsID == 1 && Loadcharacter.LoadshoesID == 3)
        {
            Player = PhotonNetwork.Instantiate("FemaleType313", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType313", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 3 && Loadcharacter.LoadpantsID == 2 && Loadcharacter.LoadshoesID == 1)
        {
            Player = PhotonNetwork.Instantiate("FemaleType321", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType321", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 3 && Loadcharacter.LoadpantsID == 2 && Loadcharacter.LoadshoesID == 2)
        {
            Player = PhotonNetwork.Instantiate("FemaleType322", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType322", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 3 && Loadcharacter.LoadpantsID == 2 && Loadcharacter.LoadshoesID == 3)
        {
            Player = PhotonNetwork.Instantiate("FemaleType323", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType323", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 3 && Loadcharacter.LoadpantsID == 3 && Loadcharacter.LoadshoesID == 1)
        {
            Player = PhotonNetwork.Instantiate("FemaleType331", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType331", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 3 && Loadcharacter.LoadpantsID == 3 && Loadcharacter.LoadshoesID == 2)
        {
            Player = PhotonNetwork.Instantiate("FemaleType332", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType332", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 3 && Loadcharacter.LoadpantsID == 3 && Loadcharacter.LoadshoesID == 3)
        {
            Player = PhotonNetwork.Instantiate("FemaleType333", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType333", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 3 && Loadcharacter.LoadpantsID == 4 && Loadcharacter.LoadshoesID == 1)
        {
            Player = PhotonNetwork.Instantiate("FemaleType341", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType341", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 3 && Loadcharacter.LoadpantsID == 4 && Loadcharacter.LoadshoesID == 2)
        {
            Player = PhotonNetwork.Instantiate("FemaleType342", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType342", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 3 && Loadcharacter.LoadpantsID == 4 && Loadcharacter.LoadshoesID == 3)
        {
            Player = PhotonNetwork.Instantiate("FemaleType343", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType343", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 3 && Loadcharacter.LoadpantsID == 5 && Loadcharacter.LoadshoesID == 1)
        {
            Player = PhotonNetwork.Instantiate("FemaleType351", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType351", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 3 && Loadcharacter.LoadpantsID == 5 && Loadcharacter.LoadshoesID == 2)
        {
            Player = PhotonNetwork.Instantiate("FemaleType352", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType352", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 3 && Loadcharacter.LoadpantsID == 5 && Loadcharacter.LoadshoesID == 3)
        {
            Player = PhotonNetwork.Instantiate("FemaleType353", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType353", typeof(GameObject))) as GameObject;
        }
        //-----------------------------------------------------------------------------------------------------------------------
        if (Loadcharacter.LoadclothesID == 4 && Loadcharacter.LoadpantsID == 1 && Loadcharacter.LoadshoesID == 1)
        {
            Player = PhotonNetwork.Instantiate("FemaleType411", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType411", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 4 && Loadcharacter.LoadpantsID == 1 && Loadcharacter.LoadshoesID == 2)
        {
            Player = PhotonNetwork.Instantiate("FemaleType412", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType412", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 4 && Loadcharacter.LoadpantsID == 1 && Loadcharacter.LoadshoesID == 3)
        {
            Player = PhotonNetwork.Instantiate("FemaleType413", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType413", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 4 && Loadcharacter.LoadpantsID == 2 && Loadcharacter.LoadshoesID == 1)
        {
            Player = PhotonNetwork.Instantiate("FemaleType421", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType421", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 4 && Loadcharacter.LoadpantsID == 2 && Loadcharacter.LoadshoesID == 2)
        {
            Player = PhotonNetwork.Instantiate("FemaleType422", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType422", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 4 && Loadcharacter.LoadpantsID == 2 && Loadcharacter.LoadshoesID == 3)
        {
            Player = PhotonNetwork.Instantiate("FemaleType423", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType423", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 4 && Loadcharacter.LoadpantsID == 3 && Loadcharacter.LoadshoesID == 1)
        {
            Player = PhotonNetwork.Instantiate("FemaleType431", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType431", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 4 && Loadcharacter.LoadpantsID == 3 && Loadcharacter.LoadshoesID == 2)
        {
            Player = PhotonNetwork.Instantiate("FemaleType432", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType432", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 4 && Loadcharacter.LoadpantsID == 3 && Loadcharacter.LoadshoesID == 3)
        {
            Player = PhotonNetwork.Instantiate("FemaleType433", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType433", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 4 && Loadcharacter.LoadpantsID == 4 && Loadcharacter.LoadshoesID == 1)
        {
            Player = PhotonNetwork.Instantiate("FemaleType441", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType441", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 4 && Loadcharacter.LoadpantsID == 4 && Loadcharacter.LoadshoesID == 2)
        {
            Player = PhotonNetwork.Instantiate("FemaleType442", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType442", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 4 && Loadcharacter.LoadpantsID == 4 && Loadcharacter.LoadshoesID == 3)
        {
            Player = PhotonNetwork.Instantiate("FemaleType443", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType443", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 4 && Loadcharacter.LoadpantsID == 5 && Loadcharacter.LoadshoesID == 1)
        {
            Player = PhotonNetwork.Instantiate("FemaleType451", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType451", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 4 && Loadcharacter.LoadpantsID == 5 && Loadcharacter.LoadshoesID == 2)
        {
            Player = PhotonNetwork.Instantiate("FemaleType452", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType452", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 4 && Loadcharacter.LoadpantsID == 5 && Loadcharacter.LoadshoesID == 3)
        {
            Player = PhotonNetwork.Instantiate("FemaleType453", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType453", typeof(GameObject))) as GameObject;
        }
        //-----------------------------------------------------------------------------------------------------------------------
        if (Loadcharacter.LoadclothesID == 5 && Loadcharacter.LoadpantsID == 1 && Loadcharacter.LoadshoesID == 1)
        {
            Player = PhotonNetwork.Instantiate("FemaleType511", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType511", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 5 && Loadcharacter.LoadpantsID == 1 && Loadcharacter.LoadshoesID == 2)
        {
            Player = PhotonNetwork.Instantiate("FemaleType512", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType512", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 5 && Loadcharacter.LoadpantsID == 1 && Loadcharacter.LoadshoesID == 3)
        {
            Player = PhotonNetwork.Instantiate("FemaleType513", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType513", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 5 && Loadcharacter.LoadpantsID == 2 && Loadcharacter.LoadshoesID == 1)
        {
            Player = PhotonNetwork.Instantiate("FemaleType521", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType521", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 5 && Loadcharacter.LoadpantsID == 2 && Loadcharacter.LoadshoesID == 2)
        {
            Player = PhotonNetwork.Instantiate("FemaleType522", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType522", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 5 && Loadcharacter.LoadpantsID == 2 && Loadcharacter.LoadshoesID == 3)
        {
            Player = PhotonNetwork.Instantiate("FemaleType523", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType523", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 5 && Loadcharacter.LoadpantsID == 3 && Loadcharacter.LoadshoesID == 1)
        {
            Player = PhotonNetwork.Instantiate("FemaleType531", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType531", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 5 && Loadcharacter.LoadpantsID == 3 && Loadcharacter.LoadshoesID == 2)
        {
            Player = PhotonNetwork.Instantiate("FemaleType532", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType532", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 5 && Loadcharacter.LoadpantsID == 3 && Loadcharacter.LoadshoesID == 3)
        {
            Player = PhotonNetwork.Instantiate("FemaleType533", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType533", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 5 && Loadcharacter.LoadpantsID == 4 && Loadcharacter.LoadshoesID == 1)
        {
            Player = PhotonNetwork.Instantiate("FemaleType541", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType541", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 5 && Loadcharacter.LoadpantsID == 4 && Loadcharacter.LoadshoesID == 2)
        {
            Player = PhotonNetwork.Instantiate("FemaleType542", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType542", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 5 && Loadcharacter.LoadpantsID == 4 && Loadcharacter.LoadshoesID == 3)
        {
            Player = PhotonNetwork.Instantiate("FemaleType543", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType543", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 5 && Loadcharacter.LoadpantsID == 5 && Loadcharacter.LoadshoesID == 1)
        {
            Player = PhotonNetwork.Instantiate("FemaleType551", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType551", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 5 && Loadcharacter.LoadpantsID == 5 && Loadcharacter.LoadshoesID == 2)
        {
            Player = PhotonNetwork.Instantiate("FemaleType552", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType552", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 5 && Loadcharacter.LoadpantsID == 5 && Loadcharacter.LoadshoesID == 3)
        {
            Player = PhotonNetwork.Instantiate("FemaleType553", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType553", typeof(GameObject))) as GameObject;
        }
        //-----------------------------------------------------------------------------------------------------------------------
        if (Loadcharacter.LoadclothesID == 6 && Loadcharacter.LoadpantsID == 1 && Loadcharacter.LoadshoesID == 1)
        {
            Player = PhotonNetwork.Instantiate("FemaleType611", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType611", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 6 && Loadcharacter.LoadpantsID == 1 && Loadcharacter.LoadshoesID == 2)
        {
            Player = PhotonNetwork.Instantiate("FemaleType612", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType612", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 6 && Loadcharacter.LoadpantsID == 1 && Loadcharacter.LoadshoesID == 3)
        {
            Player = PhotonNetwork.Instantiate("FemaleType613", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType613", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 6 && Loadcharacter.LoadpantsID == 2 && Loadcharacter.LoadshoesID == 1)
        {
            Player = PhotonNetwork.Instantiate("FemaleType621", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType621", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 6 && Loadcharacter.LoadpantsID == 2 && Loadcharacter.LoadshoesID == 2)
        {
            Player = PhotonNetwork.Instantiate("FemaleType622", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType622", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 6 && Loadcharacter.LoadpantsID == 2 && Loadcharacter.LoadshoesID == 3)
        {
            Player = PhotonNetwork.Instantiate("FemaleType623", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType623", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 6 && Loadcharacter.LoadpantsID == 3 && Loadcharacter.LoadshoesID == 1)
        {
            Player = PhotonNetwork.Instantiate("FemaleType631", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType631", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 6 && Loadcharacter.LoadpantsID == 3 && Loadcharacter.LoadshoesID == 2)
        {
            Player = PhotonNetwork.Instantiate("FemaleType632", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType632", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 6 && Loadcharacter.LoadpantsID == 3 && Loadcharacter.LoadshoesID == 3)
        {
            Player = PhotonNetwork.Instantiate("FemaleType633", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType633", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 6 && Loadcharacter.LoadpantsID == 4 && Loadcharacter.LoadshoesID == 1)
        {
            Player = PhotonNetwork.Instantiate("FemaleType641", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType641", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 6 && Loadcharacter.LoadpantsID == 4 && Loadcharacter.LoadshoesID == 2)
        {
            Player = PhotonNetwork.Instantiate("FemaleType642", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType642", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 6 && Loadcharacter.LoadpantsID == 4 && Loadcharacter.LoadshoesID == 3)
        {
            Player = PhotonNetwork.Instantiate("FemaleType643", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType643", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 6 && Loadcharacter.LoadpantsID == 5 && Loadcharacter.LoadshoesID == 1)
        {
            Player = PhotonNetwork.Instantiate("FemaleType651", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType651", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 6 && Loadcharacter.LoadpantsID == 5 && Loadcharacter.LoadshoesID == 2)
        {
            Player = PhotonNetwork.Instantiate("FemaleType652", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType652", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 6 && Loadcharacter.LoadpantsID == 5 && Loadcharacter.LoadshoesID == 3)
        {
            Player = PhotonNetwork.Instantiate("FemaleType653", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType653", typeof(GameObject))) as GameObject;
        }
        //-----------------------------------------------------------------------------------------------------------------------
        if (Loadcharacter.LoadclothesID == 7 && Loadcharacter.LoadpantsID == 1 && Loadcharacter.LoadshoesID == 1)
        {
            Player = PhotonNetwork.Instantiate("FemaleType711", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType711", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 7 && Loadcharacter.LoadpantsID == 1 && Loadcharacter.LoadshoesID == 2)
        {
            Player = PhotonNetwork.Instantiate("FemaleType712", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType712", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 7 && Loadcharacter.LoadpantsID == 1 && Loadcharacter.LoadshoesID == 3)
        {
            Player = PhotonNetwork.Instantiate("FemaleType713", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType713", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 7 && Loadcharacter.LoadpantsID == 2 && Loadcharacter.LoadshoesID == 1)
        {
            Player = PhotonNetwork.Instantiate("FemaleType721", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType721", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 7 && Loadcharacter.LoadpantsID == 2 && Loadcharacter.LoadshoesID == 2)
        {
            Player = PhotonNetwork.Instantiate("FemaleType722", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType722", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 7 && Loadcharacter.LoadpantsID == 2 && Loadcharacter.LoadshoesID == 3)
        {
            Player = PhotonNetwork.Instantiate("FemaleType723", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType723", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 7 && Loadcharacter.LoadpantsID == 3 && Loadcharacter.LoadshoesID == 1)
        {
            Player = PhotonNetwork.Instantiate("FemaleType731", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType731", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 7 && Loadcharacter.LoadpantsID == 3 && Loadcharacter.LoadshoesID == 2)
        {
            Player = PhotonNetwork.Instantiate("FemaleType732", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType732", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 7 && Loadcharacter.LoadpantsID == 3 && Loadcharacter.LoadshoesID == 3)
        {
            Player = PhotonNetwork.Instantiate("FemaleType733", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType733", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 7 && Loadcharacter.LoadpantsID == 4 && Loadcharacter.LoadshoesID == 1)
        {
            Player = PhotonNetwork.Instantiate("FemaleType741", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType741", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 7 && Loadcharacter.LoadpantsID == 4 && Loadcharacter.LoadshoesID == 2)
        {
            Player = PhotonNetwork.Instantiate("FemaleType742", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType742", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 7 && Loadcharacter.LoadpantsID == 4 && Loadcharacter.LoadshoesID == 3)
        {
            Player = PhotonNetwork.Instantiate("FemaleType743", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType743", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 7 && Loadcharacter.LoadpantsID == 5 && Loadcharacter.LoadshoesID == 1)
        {
            Player = PhotonNetwork.Instantiate("FemaleType751", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType751", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 7 && Loadcharacter.LoadpantsID == 5 && Loadcharacter.LoadshoesID == 2)
        {
            Player = PhotonNetwork.Instantiate("FemaleType752", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType752", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 7 && Loadcharacter.LoadpantsID == 5 && Loadcharacter.LoadshoesID == 3)
        {
            Player = PhotonNetwork.Instantiate("FemaleType753", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType753", typeof(GameObject))) as GameObject;
        }
        //-----------------------------------------------------------------------------------------------------------------------
        if (Loadcharacter.LoadclothesID == 8 && Loadcharacter.LoadpantsID == 1 && Loadcharacter.LoadshoesID == 1)
        {
            Player = PhotonNetwork.Instantiate("FemaleType811", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType811", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 8 && Loadcharacter.LoadpantsID == 1 && Loadcharacter.LoadshoesID == 2)
        {
            Player = PhotonNetwork.Instantiate("FemaleType812", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType812", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 8 && Loadcharacter.LoadpantsID == 1 && Loadcharacter.LoadshoesID == 3)
        {
            Player = PhotonNetwork.Instantiate("FemaleType813", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType813", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 8 && Loadcharacter.LoadpantsID == 2 && Loadcharacter.LoadshoesID == 1)
        {
            Player = PhotonNetwork.Instantiate("FemaleType821", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType821", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 8 && Loadcharacter.LoadpantsID == 2 && Loadcharacter.LoadshoesID == 2)
        {
            Player = PhotonNetwork.Instantiate("FemaleType822", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType822", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 8 && Loadcharacter.LoadpantsID == 2 && Loadcharacter.LoadshoesID == 3)
        {
            Player = PhotonNetwork.Instantiate("FemaleType823", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType823", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 8 && Loadcharacter.LoadpantsID == 3 && Loadcharacter.LoadshoesID == 1)
        {
            Player = PhotonNetwork.Instantiate("FemaleType831", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType831", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 8 && Loadcharacter.LoadpantsID == 3 && Loadcharacter.LoadshoesID == 2)
        {
            Player = PhotonNetwork.Instantiate("FemaleType832", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType832", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 8 && Loadcharacter.LoadpantsID == 3 && Loadcharacter.LoadshoesID == 3)
        {
            Player = PhotonNetwork.Instantiate("FemaleType833", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType833", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 8 && Loadcharacter.LoadpantsID == 4 && Loadcharacter.LoadshoesID == 1)
        {
            Player = PhotonNetwork.Instantiate("FemaleType841", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType841", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 8 && Loadcharacter.LoadpantsID == 4 && Loadcharacter.LoadshoesID == 2)
        {
            Player = PhotonNetwork.Instantiate("FemaleType842", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType842", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 8 && Loadcharacter.LoadpantsID == 4 && Loadcharacter.LoadshoesID == 3)
        {
            Player = PhotonNetwork.Instantiate("FemaleType843", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType843", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 8 && Loadcharacter.LoadpantsID == 5 && Loadcharacter.LoadshoesID == 1)
        {
            Player = PhotonNetwork.Instantiate("FemaleType851", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType851", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 8 && Loadcharacter.LoadpantsID == 5 && Loadcharacter.LoadshoesID == 2)
        {
            Player = PhotonNetwork.Instantiate("FemaleType852", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType852", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 8 && Loadcharacter.LoadpantsID == 5 && Loadcharacter.LoadshoesID == 3)
        {
            Player = PhotonNetwork.Instantiate("FemaleType853", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType853", typeof(GameObject))) as GameObject;
        }
        //-----------------------------------------------------------------------------------------------------------------------
        if (Loadcharacter.LoadclothesID == 9 && Loadcharacter.LoadpantsID == 1 && Loadcharacter.LoadshoesID == 1)
        {
            Player = PhotonNetwork.Instantiate("FemaleType911", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType911", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 9 && Loadcharacter.LoadpantsID == 1 && Loadcharacter.LoadshoesID == 2)
        {
            Player = PhotonNetwork.Instantiate("FemaleType912", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType912", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 9 && Loadcharacter.LoadpantsID == 1 && Loadcharacter.LoadshoesID == 3)
        {
            Player = PhotonNetwork.Instantiate("FemaleType913", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType913", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 9 && Loadcharacter.LoadpantsID == 2 && Loadcharacter.LoadshoesID == 1)
        {
            Player = PhotonNetwork.Instantiate("FemaleType911", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType911", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 9 && Loadcharacter.LoadpantsID == 2 && Loadcharacter.LoadshoesID == 2)
        {
            Player = PhotonNetwork.Instantiate("FemaleType912", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType912", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 9 && Loadcharacter.LoadpantsID == 2 && Loadcharacter.LoadshoesID == 3)
        {
            Player = PhotonNetwork.Instantiate("FemaleType913", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType913", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 9 && Loadcharacter.LoadpantsID == 3 && Loadcharacter.LoadshoesID == 1)
        {
            Player = PhotonNetwork.Instantiate("FemaleType911", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType911", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 9 && Loadcharacter.LoadpantsID == 3 && Loadcharacter.LoadshoesID == 2)
        {
            Player = PhotonNetwork.Instantiate("FemaleType912", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType912", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 9 && Loadcharacter.LoadpantsID == 3 && Loadcharacter.LoadshoesID == 3)
        {
            Player = PhotonNetwork.Instantiate("FemaleType913", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType913", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 9 && Loadcharacter.LoadpantsID == 4 && Loadcharacter.LoadshoesID == 1)
        {
            Player = PhotonNetwork.Instantiate("FemaleType911", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType911", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 9 && Loadcharacter.LoadpantsID == 4 && Loadcharacter.LoadshoesID == 2)
        {
            Player = PhotonNetwork.Instantiate("FemaleType912", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType912", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 9 && Loadcharacter.LoadpantsID == 4 && Loadcharacter.LoadshoesID == 3)
        {
            Player = PhotonNetwork.Instantiate("FemaleType913", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType913", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 9 && Loadcharacter.LoadpantsID == 5 && Loadcharacter.LoadshoesID == 1)
        {
            Player = PhotonNetwork.Instantiate("FemaleType911", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType911", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 9 && Loadcharacter.LoadpantsID == 5 && Loadcharacter.LoadshoesID == 2)
        {
            Player = PhotonNetwork.Instantiate("FemaleType912", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType912", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 9 && Loadcharacter.LoadpantsID == 5 && Loadcharacter.LoadshoesID == 3)
        {
            Player = PhotonNetwork.Instantiate("FemaleType913", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType913", typeof(GameObject))) as GameObject;
        }
        //-----------------------------------------------------------------------------------------------------------------------
        if (Loadcharacter.LoadclothesID == 10 && Loadcharacter.LoadpantsID == 1 && Loadcharacter.LoadshoesID == 1)
        {
            Player = PhotonNetwork.Instantiate("FemaleType1011", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType1011", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 10 && Loadcharacter.LoadpantsID == 1 && Loadcharacter.LoadshoesID == 2)
        {
            Player = PhotonNetwork.Instantiate("FemaleType1012", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType1012", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 10 && Loadcharacter.LoadpantsID == 1 && Loadcharacter.LoadshoesID == 3)
        {
            Player = PhotonNetwork.Instantiate("FemaleType1013", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType1013", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 10 && Loadcharacter.LoadpantsID == 2 && Loadcharacter.LoadshoesID == 1)
        {
            Player = PhotonNetwork.Instantiate("FemaleType1021", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType1021", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 10 && Loadcharacter.LoadpantsID == 2 && Loadcharacter.LoadshoesID == 2)
        {
            Player = PhotonNetwork.Instantiate("FemaleType1022", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType1022", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 10 && Loadcharacter.LoadpantsID == 2 && Loadcharacter.LoadshoesID == 3)
        {
            Player = PhotonNetwork.Instantiate("FemaleType1023", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType1023", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 10 && Loadcharacter.LoadpantsID == 3 && Loadcharacter.LoadshoesID == 1)
        {
            Player = PhotonNetwork.Instantiate("FemaleType1031", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType1031", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 10 && Loadcharacter.LoadpantsID == 3 && Loadcharacter.LoadshoesID == 2)
        {
            Player = PhotonNetwork.Instantiate("FemaleType1032", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType1032", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 10 && Loadcharacter.LoadpantsID == 3 && Loadcharacter.LoadshoesID == 3)
        {
            Player = PhotonNetwork.Instantiate("FemaleType1033", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType1033", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 10 && Loadcharacter.LoadpantsID == 4 && Loadcharacter.LoadshoesID == 1)
        {
            Player = PhotonNetwork.Instantiate("FemaleType1041", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType1041", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 10 && Loadcharacter.LoadpantsID == 4 && Loadcharacter.LoadshoesID == 2)
        {
            Player = PhotonNetwork.Instantiate("FemaleType1042", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType1042", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 10 && Loadcharacter.LoadpantsID == 4 && Loadcharacter.LoadshoesID == 3)
        {
            Player = PhotonNetwork.Instantiate("FemaleType1043", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType1043", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 10 && Loadcharacter.LoadpantsID == 5 && Loadcharacter.LoadshoesID == 1)
        {
            Player = PhotonNetwork.Instantiate("FemaleType1051", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType1051", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 10 && Loadcharacter.LoadpantsID == 5 && Loadcharacter.LoadshoesID == 2)
        {
            Player = PhotonNetwork.Instantiate("FemaleType1052", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType1052", typeof(GameObject))) as GameObject;
        }
        if (Loadcharacter.LoadclothesID == 10 && Loadcharacter.LoadpantsID == 5 && Loadcharacter.LoadshoesID == 3)
        {
            Player = PhotonNetwork.Instantiate("FemaleType1053", new Vector3(0, -11, 0), Quaternion.Euler(0, 180, 0), 0);
            //Player = Instantiate(Resources.Load("FemaleType1053", typeof(GameObject))) as GameObject;
        }
        //-----------------------------------------------------------------------------------------------------------------------
    }
}

