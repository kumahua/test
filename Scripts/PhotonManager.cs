using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public class PhotonManager : Photon.PunBehaviour
{
    public GameObject PersonCamera;            //第三方攝影機
    public PersonCamera Camera;                //使用Camera的Script
    public GameObject ConfirmButton;
    public int sex;

    public static PhotonManager instance;      //設為一個全域變數 連線伺服器全部場景都要使用
    public static GameObject localPlayer;      //玩家角色物件
   
    // Use this for initialization
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings("MMOGame_v1.0");    //版本名稱
        PersonCamera.SetActive(false);                         //第一次執行 之後就不會執行了
       
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
       
        PhotonNetwork.automaticallySyncScene = true;
        SceneManager.sceneLoaded += this.OnLoadCallback; //回傳新版的載入場景,舊版刪除這行
        
    }
    public void JoinGameRoom() //加入房間
    {
        RoomOptions options = new RoomOptions();
        options.MaxPlayers = 100;                                                //遊戲人數
        PhotonNetwork.JoinOrCreateRoom("Fight Room", options, null);             //房間名稱
        Debug.Log("正在進入遊戲");

        
    }

    public override void OnConnectedToMaster()
    {
         //連上 MasterServer 後,  Button (UI) 就可以顯示或是執行其它後續動作.
        Debug.Log("已連上 Master Server");
        base.OnConnectedToMaster();
        
    }
    

    public override void OnJoinedRoom()
    {
        Debug.Log("您已進入遊戲室!!");
        
        // 如果是Master Client, 即可建立/初始化,與載入遊戲場景
        if (PhotonNetwork.isMasterClient)
        {          
            PersonCamera.SetActive(true);
            PhotonNetwork.LoadLevel(4);//舊版本請將數字改為場景名稱
            //SceneManager.LoadScene(1);
            Debug.Log("第一位登入的玩家");
        }
        else
        {         
            PersonCamera.SetActive(true);
            Debug.Log("目前已經有玩家在線上!");     
        }
    }

    void OnLoadCallback(Scene scene, LoadSceneMode sceneMode) //新版的載入場景
    {
        // 若不在Photon的遊戲室內, 則網路有問題..
        if (!PhotonNetwork.inRoom)
            return;

        Debug.Log("我們已進入遊戲場景了,耶~");
        switch (sex)//用選到的名稱來判斷
        {
            case 1://選項為男生

                Debug.Log("你選到男生");
                localPlayer = PhotonNetwork.Instantiate("Male", new Vector3(0, 0, 0), Quaternion.identity, 0);//創建男性
                DontDestroyOnLoad(localPlayer);
                Camera.Target = localPlayer.transform;
                sex = 3;
                break;//每個case 要以break;結尾

            case 2://選項為女生
                Debug.Log("你選到女生");
                localPlayer = PhotonNetwork.Instantiate("Female", new Vector3(0, 0, 0), Quaternion.identity, 0);//創建女生
                DontDestroyOnLoad(localPlayer);
                Camera.Target = localPlayer.transform;
                sex = 4;
                break;//每個case 要以break;結尾

            default://以上都不成立執行預設值
                Debug.Log("不是男生也不是女生");
                break;

        }
       
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
    public void OnMaleclick()
    {
        
        Debug.Log("你選了男性");
        ConfirmButton.SetActive(true);
        sex = 1;
      
    }
    public void OnFemaleclick()
    {
        Debug.Log("你選了女性");
        ConfirmButton.SetActive(true);
        sex = 2;
    }


}

