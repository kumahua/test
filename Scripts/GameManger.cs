using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManger : Photon.PunBehaviour
{
    //singleton
    //單例模式
    public static GameManger instance;
    public static GameObject localPlayer;      //玩家角色物件

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else if (this != instance)
        {
            Destroy(gameObject);
        }
        SceneManager.sceneLoaded += this.OnLoadCallback; //回傳新版的載入場景,舊版刪除這行
    }
    void Start()
    {

    }
    void Update()
    {

    }

    //抓其他值到GameManger
    /*
    Gamemanger gameManger
    void Awake()
    {
         gameManger = FindObjectOfType<GameManger>(); //這行是找到對的值到所要的地方 
    }  
    gameManger.x(所要的值) + = 10;

    //在manger裡面
    public int x (設定的值)
    */
    void OnLoadCallback(Scene scene, LoadSceneMode sceneMode) //新版的載入場景
    {
       
    }


}
