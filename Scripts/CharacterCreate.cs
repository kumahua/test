using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterCreate : MonoBehaviour {
    public int sexID = 1;       //設定性別編號
    public int clothesID = 1;   //設定衣服編號
    public int pantsID = 1;     //設定褲子編號
    public int LoadshoesID = 1;     //設定鞋子編號
    public static int Level = 1;    //設定全域變數 人物等級
    public static int Hp = 100;      //設定全域變數 人物血量 
    public static int Exp = 0;      //設定全域變數 人物經驗
    public static int Money = 0;    //設定全域變數 人物金錢
    public static string status ;   //設定全域變數 人物狀態
    public int windowWidth = 400;   //設定離開視窗大小
    public int windowHight = 150;   
                         
    //設定視窗背景
    Rect windowRect;
    int windowSwitch = 0;           //切換視窗編號
    float alpha = 0;
    GameObject Player; //設定角色欄位
    private string CreateCharacterUrl = "http://140.115.126.115:3000/CreateCharacter?account=";//"http://140.115.126.160/WordofWorld/CreatCharacter.php"

    void Awake()    //初始化視窗位置
    {
        windowRect = new Rect(
            (Screen.width - windowWidth) / 2,
            (Screen.height - windowHight) / 2,
            windowWidth,
            windowHight);    
    }

    void Start ()//初始化
    {
        Player = Instantiate(Resources.Load("MaleType111", typeof(GameObject))) as GameObject; //一開始有角色提供選擇
    }
	
	// Update is called once per frame
	void Update ()
    {

    }

    public void SexIDLeft()
    {
        if (sexID == 2)
        {
            Destroy(Player);
            sexID--;
            Player = Instantiate(Resources.Load("MaleType111", typeof(GameObject))) as GameObject;
            Debug.Log("sex=1,切換至男性角色");
            sexID = 1;
            clothesID = 1;
            pantsID = 1;
            LoadshoesID = 1;
        }
    }
    public void SexIDright()
    {
        if (sexID == 1)
        {
            Destroy(Player);
            sexID++;
            Player = Instantiate(Resources.Load("FemaleType111", typeof(GameObject))) as GameObject;
            Debug.Log("sex=2,切換至女性角色");
            sexID = 2;
            clothesID = 1;
            pantsID = 1;
            LoadshoesID = 1;
        }
    }
    //男性衣服6套  褲子6套 鞋子3雙
    //女性衣服10套 褲子5套 鞋子3雙
    public void ClothesIDLeft()
    {
        if (sexID == 1) //判斷是男生
        {
            if (clothesID == 1)
            {
                clothesID++;
                Debug.Log(clothesID);
            }
            clothesID--;
            Debug.Log(clothesID);
            CallMaleResources();    
        }

        if (sexID == 2) //判斷是女生
        {
            if (clothesID == 1)
            {
                clothesID++;
            }
            clothesID--;
            Debug.Log(clothesID);
            CallFemaleResources();
        }
    }
    public void ClothesIDright()
    {
        if (sexID == 1)//判斷是男生
        {
            if (clothesID == 6)
            {
                clothesID--;
            }
            clothesID++;
            CallMaleResources();
        }
        if (sexID == 2)//判斷是女生
        {
            if (clothesID == 10)
            {
                clothesID--;
            }
            clothesID++;
            Debug.Log(clothesID);
            CallFemaleResources();
        }
    }
    public void PantsIDLeft()
    {
        switch (sexID)
        {
            case 1://男生
                if (pantsID == 1)
                {
                    pantsID++;
                }
                pantsID--;
                CallMaleResources();
                break;
            case 2://女生
                if (pantsID == 1)
                {
                    pantsID++;
                }
                pantsID--;
                CallFemaleResources();
                break;
            default:
                Debug.Log("出現這個代表判斷性別錯誤!");
                break;
        }
    }
    public void PantsIDright()
    {
        switch (sexID)
        {
            case 1://男生
                if (pantsID == 6)
                {
                    pantsID--;
                }
                pantsID++;
                CallMaleResources();
                // Debug.Log(pantsID);
                break;
            case 2://女生
                if (pantsID == 5)
                {
                    pantsID--;
                }
                pantsID++;
                CallFemaleResources();
                //Debug.Log(pantsID);
                break;
            default:
                break;
        }
    }
    public void ShoesIDLeft()
    {
        switch (sexID)
        {
            case 1://男生
                if (LoadshoesID == 1)
                {
                    LoadshoesID++;
                }
                LoadshoesID--;
                CallMaleResources();
                break;
            case 2://女生
                if (LoadshoesID == 1)
                {
                    LoadshoesID++;
                }
                LoadshoesID--;
                CallFemaleResources();
                break;
            default:
                Debug.Log("出現這個代表判斷性別錯誤!");
                break;
        }
    }
    public void ShoesIDright()
    {
        switch (sexID)
        {
            case 1://男生
                if (LoadshoesID == 3)
                {
                    LoadshoesID--;
                }
                LoadshoesID++;
                CallMaleResources();
                //Debug.Log(shoesID);
                break;
            case 2://女生
                if (LoadshoesID == 3)
                {
                    LoadshoesID--;
                }
                LoadshoesID++;
                CallFemaleResources();
                //Debug.Log(shoesID);
                break;
            default:
                Debug.Log("出現這個代表判斷性別錯誤!");
                break;
        }
    }

    //選擇角色
    #region
    public void CallMaleResources()
    {
        //--------------------------------------------------------------------------------
        if (clothesID == 1 && pantsID == 1 && LoadshoesID == 1)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("MaleType111", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 1 && pantsID == 1 && LoadshoesID == 2)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("MaleType112", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 1 && pantsID == 1 && LoadshoesID == 3)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("MaleType113", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 1 && pantsID == 2 && LoadshoesID == 1)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("MaleType121", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 1 && pantsID == 2 && LoadshoesID == 2)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("MaleType122", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 1 && pantsID == 2 && LoadshoesID == 3)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("MaleType123", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 1 && pantsID == 3 && LoadshoesID == 1)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("MaleType131", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 1 && pantsID == 3 && LoadshoesID == 2)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("MaleType132", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 1 && pantsID == 3 && LoadshoesID == 3)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("MaleType133", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 1 && pantsID == 4 && LoadshoesID == 1)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("MaleType141", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 1 && pantsID == 4 && LoadshoesID == 2)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("MaleType142", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 1 && pantsID == 4 && LoadshoesID == 3)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("MaleType143", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 1 && pantsID == 5 && LoadshoesID == 1)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("MaleType151", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 1 && pantsID == 5 && LoadshoesID == 2)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("MaleType152", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 1 && pantsID == 5 && LoadshoesID == 3)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("MaleType153", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 1 && pantsID == 6 && LoadshoesID == 1)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("MaleType161", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 1 && pantsID == 6 && LoadshoesID == 2)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("MaleType162", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 1 && pantsID == 6 && LoadshoesID == 3)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("MaleType163", typeof(GameObject))) as GameObject;
        }
        //-------------------------------------------------------------------------------------------
        if (clothesID == 2 && pantsID == 1 && LoadshoesID == 1)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("MaleType211", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 2 && pantsID == 1 && LoadshoesID == 2)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("MaleType212", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 2 && pantsID == 1 && LoadshoesID == 3)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("MaleType213", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 2 && pantsID == 2 && LoadshoesID == 1)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("MaleType221", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 2 && pantsID == 2 && LoadshoesID == 2)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("MaleType222", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 2 && pantsID == 2 && LoadshoesID == 3)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("MaleType223", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 2 && pantsID == 3 && LoadshoesID == 1)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("MaleType231", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 2 && pantsID == 3 && LoadshoesID == 2)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("MaleType232", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 2 && pantsID == 3 && LoadshoesID == 3)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("MaleType233", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 2 && pantsID == 4 && LoadshoesID == 1)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("MaleType241", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 2 && pantsID == 4 && LoadshoesID == 2)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("MaleType242", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 2 && pantsID == 4 && LoadshoesID == 3)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("MaleType243", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 2 && pantsID == 5 && LoadshoesID == 1)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("MaleType251", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 2 && pantsID == 5 && LoadshoesID == 2)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("MaleType252", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 2 && pantsID == 5 && LoadshoesID == 3)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("MaleType253", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 2 && pantsID == 6 && LoadshoesID == 1)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("MaleType261", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 2 && pantsID == 6 && LoadshoesID == 2)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("MaleType262", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 2 && pantsID == 6 && LoadshoesID == 3)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("MaleType263", typeof(GameObject))) as GameObject;
        }
        //-----------------------------------------------------------------------------------------------------------
        if (clothesID == 3 && pantsID == 1 && LoadshoesID == 1)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("MaleType311", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 3 && pantsID == 1 && LoadshoesID == 2)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("MaleType312", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 3 && pantsID == 1 && LoadshoesID == 3)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("MaleType313", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 3 && pantsID == 2 && LoadshoesID == 1)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("MaleType321", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 3 && pantsID == 2 && LoadshoesID == 2)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("MaleType322", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 3 && pantsID == 2 && LoadshoesID == 3)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("MaleType323", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 3 && pantsID == 3 && LoadshoesID == 1)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("MaleType331", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 3 && pantsID == 3 && LoadshoesID == 2)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("MaleType332", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 3 && pantsID == 3 && LoadshoesID == 3)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("MaleType333", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 3 && pantsID == 4 && LoadshoesID == 1)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("MaleType341", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 3 && pantsID == 4 && LoadshoesID == 2)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("MaleType342", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 3 && pantsID == 4 && LoadshoesID == 3)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("MaleType343", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 3 && pantsID == 5 && LoadshoesID == 1)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("MaleType351", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 3 && pantsID == 5 && LoadshoesID == 2)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("MaleType352", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 3 && pantsID == 5 && LoadshoesID == 3)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("MaleType353", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 3 && pantsID == 6 && LoadshoesID == 1)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("MaleType361", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 3 && pantsID == 6 && LoadshoesID == 2)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("MaleType362", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 3 && pantsID == 6 && LoadshoesID == 3)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("MaleType363", typeof(GameObject))) as GameObject;
        }
        //-----------------------------------------------------------------------------------------------------------
        if (clothesID == 4 && pantsID == 1 && LoadshoesID == 1)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("MaleType411", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 4 && pantsID == 1 && LoadshoesID == 2)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("MaleType412", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 4 && pantsID == 1 && LoadshoesID == 3)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("MaleType413", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 4 && pantsID == 2 && LoadshoesID == 1)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("MaleType421", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 4 && pantsID == 2 && LoadshoesID == 2)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("MaleType422", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 4 && pantsID == 2 && LoadshoesID == 3)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("MaleType423", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 4 && pantsID == 3 && LoadshoesID == 1)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("MaleType431", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 4 && pantsID == 3 && LoadshoesID == 2)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("MaleType432", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 4 && pantsID == 3 && LoadshoesID == 3)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("MaleType433", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 4 && pantsID == 4 && LoadshoesID == 1)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("MaleType441", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 4 && pantsID == 4 && LoadshoesID == 2)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("MaleType442", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 4 && pantsID == 4 && LoadshoesID == 3)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("MaleType443", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 4 && pantsID == 5 && LoadshoesID == 1)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("MaleType451", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 4 && pantsID == 5 && LoadshoesID == 2)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("MaleType452", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 4 && pantsID == 5 && LoadshoesID == 3)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("MaleType453", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 4 && pantsID == 6 && LoadshoesID == 1)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("MaleType461", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 4 && pantsID == 6 && LoadshoesID == 2)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("MaleType462", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 4 && pantsID == 6 && LoadshoesID == 3)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("MaleType463", typeof(GameObject))) as GameObject;
        }
        //-----------------------------------------------------------------------------------------------------------
        if (clothesID == 5 && pantsID == 1 && LoadshoesID == 1)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("MaleType511", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 5 && pantsID == 1 && LoadshoesID == 2)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("MaleType512", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 5 && pantsID == 1 && LoadshoesID == 3)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("MaleType513", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 5 && pantsID == 2 && LoadshoesID == 1)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("MaleType521", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 5 && pantsID == 2 && LoadshoesID == 2)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("MaleType522", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 5 && pantsID == 2 && LoadshoesID == 3)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("MaleType523", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 5 && pantsID == 3 && LoadshoesID == 1)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("MaleType531", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 5 && pantsID == 3 && LoadshoesID == 2)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("MaleType532", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 5 && pantsID == 3 && LoadshoesID == 3)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("MaleType533", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 5 && pantsID == 4 && LoadshoesID == 1)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("MaleType541", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 5 && pantsID == 4 && LoadshoesID == 2)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("MaleType542", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 5 && pantsID == 4 && LoadshoesID == 3)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("MaleType543", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 5 && pantsID == 5 && LoadshoesID == 1)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("MaleType551", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 5 && pantsID == 5 && LoadshoesID == 2)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("MaleType552", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 5 && pantsID == 5 && LoadshoesID == 3)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("MaleType553", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 5 && pantsID == 6 && LoadshoesID == 1)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("MaleType561", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 5 && pantsID == 6 && LoadshoesID == 2)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("MaleType562", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 5 && pantsID == 6 && LoadshoesID == 3)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("MaleType563", typeof(GameObject))) as GameObject;
        }
        //-----------------------------------------------------------------------------------------------------------
        if (clothesID == 6 && pantsID == 1 && LoadshoesID == 1)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("MaleType611", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 6 && pantsID == 1 && LoadshoesID == 2)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("MaleType612", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 6 && pantsID == 1 && LoadshoesID == 3)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("MaleType613", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 6 && pantsID == 2 && LoadshoesID == 1)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("MaleType621", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 6 && pantsID == 2 && LoadshoesID == 2)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("MaleType622", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 6 && pantsID == 2 && LoadshoesID == 3)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("MaleType623", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 6 && pantsID == 3 && LoadshoesID == 1)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("MaleType631", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 6 && pantsID == 3 && LoadshoesID == 2)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("MaleType632", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 6 && pantsID == 3 && LoadshoesID == 3)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("MaleType633", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 6 && pantsID == 4 && LoadshoesID == 1)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("MaleType641", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 6 && pantsID == 4 && LoadshoesID == 2)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("MaleType642", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 6 && pantsID == 4 && LoadshoesID == 3)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("MaleType643", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 6 && pantsID == 5 && LoadshoesID == 1)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("MaleType651", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 6 && pantsID == 5 && LoadshoesID == 2)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("MaleType652", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 6 && pantsID == 5 && LoadshoesID == 3)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("MaleType653", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 6 && pantsID == 6 && LoadshoesID == 1)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("MaleType661", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 6 && pantsID == 6 && LoadshoesID == 2)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("MaleType662", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 6 && pantsID == 6 && LoadshoesID == 3)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("MaleType663", typeof(GameObject))) as GameObject;
        }
        //-----------------------------------------------------------------------------------------------------------
    }
    public void CallFemaleResources()
    {
        if (clothesID == 1 && pantsID == 1 && LoadshoesID == 1)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType111", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 1 && pantsID == 1 && LoadshoesID == 2)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType112", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 1 && pantsID == 1 && LoadshoesID == 3)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType113", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 1 && pantsID == 2 && LoadshoesID == 1)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType121", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 1 && pantsID == 2 && LoadshoesID == 2)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType122", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 1 && pantsID == 2 && LoadshoesID == 3)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType123", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 1 && pantsID == 3 && LoadshoesID == 1)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType131", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 1 && pantsID == 3 && LoadshoesID == 2)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType132", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 1 && pantsID == 3 && LoadshoesID == 3)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType133", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 1 && pantsID == 4 && LoadshoesID == 1)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType141", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 1 && pantsID == 4 && LoadshoesID == 2)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType142", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 1 && pantsID == 4 && LoadshoesID == 3)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType143", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 1 && pantsID == 5 && LoadshoesID == 1)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType151", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 1 && pantsID == 5 && LoadshoesID == 2)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType152", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 1 && pantsID == 5 && LoadshoesID == 3)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType153", typeof(GameObject))) as GameObject;
        }
        //-----------------------------------------------------------------------------------------------------------------------
        if (clothesID == 2 && pantsID == 1 && LoadshoesID == 1)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType211", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 2 && pantsID == 1 && LoadshoesID == 2)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType212", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 2 && pantsID == 1 && LoadshoesID == 3)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType213", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 2 && pantsID == 2 && LoadshoesID == 1)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType221", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 2 && pantsID == 2 && LoadshoesID == 2)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType222", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 2 && pantsID == 2 && LoadshoesID == 3)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType223", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 2 && pantsID == 3 && LoadshoesID == 1)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType231", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 2 && pantsID == 3 && LoadshoesID == 2)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType232", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 2 && pantsID == 3 && LoadshoesID == 3)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType233", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 2 && pantsID == 4 && LoadshoesID == 1)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType241", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 2 && pantsID == 4 && LoadshoesID == 2)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType242", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 2 && pantsID == 4 && LoadshoesID == 3)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType243", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 2 && pantsID == 5 && LoadshoesID == 1)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType251", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 2 && pantsID == 5 && LoadshoesID == 2)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType252", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 2 && pantsID == 5 && LoadshoesID == 3)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType253", typeof(GameObject))) as GameObject;
        }
        //-----------------------------------------------------------------------------------------------------------------------
        if (clothesID == 3 && pantsID == 1 && LoadshoesID == 1)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType311", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 3 && pantsID == 1 && LoadshoesID == 2)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType312", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 3 && pantsID == 1 && LoadshoesID == 3)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType313", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 3 && pantsID == 2 && LoadshoesID == 1)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType321", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 3 && pantsID == 2 && LoadshoesID == 2)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType322", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 3 && pantsID == 2 && LoadshoesID == 3)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType323", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 3 && pantsID == 3 && LoadshoesID == 1)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType331", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 3 && pantsID == 3 && LoadshoesID == 2)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType332", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 3 && pantsID == 3 && LoadshoesID == 3)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType333", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 3 && pantsID == 4 && LoadshoesID == 1)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType341", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 3 && pantsID == 4 && LoadshoesID == 2)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType342", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 3 && pantsID == 4 && LoadshoesID == 3)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType343", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 3 && pantsID == 5 && LoadshoesID == 1)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType351", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 3 && pantsID == 5 && LoadshoesID == 2)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType352", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 3 && pantsID == 5 && LoadshoesID == 3)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType353", typeof(GameObject))) as GameObject;
        }
        //-----------------------------------------------------------------------------------------------------------------------
        if (clothesID == 4 && pantsID == 1 && LoadshoesID == 1)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType411", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 4 && pantsID == 1 && LoadshoesID == 2)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType412", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 4 && pantsID == 1 && LoadshoesID == 3)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType413", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 4 && pantsID == 2 && LoadshoesID == 1)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType421", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 4 && pantsID == 2 && LoadshoesID == 2)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType422", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 4 && pantsID == 2 && LoadshoesID == 3)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType423", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 4 && pantsID == 3 && LoadshoesID == 1)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType431", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 4 && pantsID == 3 && LoadshoesID == 2)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType432", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 4 && pantsID == 3 && LoadshoesID == 3)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType433", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 4 && pantsID == 4 && LoadshoesID == 1)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType441", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 4 && pantsID == 4 && LoadshoesID == 2)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType442", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 4 && pantsID == 4 && LoadshoesID == 3)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType443", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 4 && pantsID == 5 && LoadshoesID == 1)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType451", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 4 && pantsID == 5 && LoadshoesID == 2)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType452", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 4 && pantsID == 5 && LoadshoesID == 3)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType453", typeof(GameObject))) as GameObject;
        }
        //-----------------------------------------------------------------------------------------------------------------------
        if (clothesID == 5 && pantsID == 1 && LoadshoesID == 1)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType511", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 5 && pantsID == 1 && LoadshoesID == 2)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType512", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 5 && pantsID == 1 && LoadshoesID == 3)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType513", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 5 && pantsID == 2 && LoadshoesID == 1)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType521", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 5 && pantsID == 2 && LoadshoesID == 2)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType522", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 5 && pantsID == 2 && LoadshoesID == 3)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType523", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 5 && pantsID == 3 && LoadshoesID == 1)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType531", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 5 && pantsID == 3 && LoadshoesID == 2)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType532", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 5 && pantsID == 3 && LoadshoesID == 3)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType533", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 5 && pantsID == 4 && LoadshoesID == 1)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType541", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 5 && pantsID == 4 && LoadshoesID == 2)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType542", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 5 && pantsID == 4 && LoadshoesID == 3)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType543", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 5 && pantsID == 5 && LoadshoesID == 1)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType551", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 5 && pantsID == 5 && LoadshoesID == 2)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType552", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 5 && pantsID == 5 && LoadshoesID == 3)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType553", typeof(GameObject))) as GameObject;
        }
        //-----------------------------------------------------------------------------------------------------------------------
        if (clothesID == 6 && pantsID == 1 && LoadshoesID == 1)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType611", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 6 && pantsID == 1 && LoadshoesID == 2)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType612", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 6 && pantsID == 1 && LoadshoesID == 3)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType613", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 6 && pantsID == 2 && LoadshoesID == 1)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType621", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 6 && pantsID == 2 && LoadshoesID == 2)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType622", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 6 && pantsID == 2 && LoadshoesID == 3)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType623", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 6 && pantsID == 3 && LoadshoesID == 1)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType631", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 6 && pantsID == 3 && LoadshoesID == 2)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType632", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 6 && pantsID == 3 && LoadshoesID == 3)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType633", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 6 && pantsID == 4 && LoadshoesID == 1)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType641", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 6 && pantsID == 4 && LoadshoesID == 2)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType642", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 6 && pantsID == 4 && LoadshoesID == 3)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType643", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 6 && pantsID == 5 && LoadshoesID == 1)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType651", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 6 && pantsID == 5 && LoadshoesID == 2)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType652", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 6 && pantsID == 5 && LoadshoesID == 3)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType653", typeof(GameObject))) as GameObject;
        }
        //-----------------------------------------------------------------------------------------------------------------------
        if (clothesID == 7 && pantsID == 1 && LoadshoesID == 1)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType711", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 7 && pantsID == 1 && LoadshoesID == 2)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType712", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 7 && pantsID == 1 && LoadshoesID == 3)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType713", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 7 && pantsID == 2 && LoadshoesID == 1)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType721", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 7 && pantsID == 2 && LoadshoesID == 2)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType722", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 7 && pantsID == 2 && LoadshoesID == 3)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType723", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 7 && pantsID == 3 && LoadshoesID == 1)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType731", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 7 && pantsID == 3 && LoadshoesID == 2)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType732", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 7 && pantsID == 3 && LoadshoesID == 3)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType733", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 7 && pantsID == 4 && LoadshoesID == 1)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType741", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 7 && pantsID == 4 && LoadshoesID == 2)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType742", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 7 && pantsID == 4 && LoadshoesID == 3)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType743", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 7 && pantsID == 5 && LoadshoesID == 1)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType751", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 7 && pantsID == 5 && LoadshoesID == 2)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType752", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 7 && pantsID == 5 && LoadshoesID == 3)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType753", typeof(GameObject))) as GameObject;
        }
        //-----------------------------------------------------------------------------------------------------------------------
        if (clothesID == 8 && pantsID == 1 && LoadshoesID == 1)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType811", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 8 && pantsID == 1 && LoadshoesID == 2)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType812", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 8 && pantsID == 1 && LoadshoesID == 3)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType813", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 8 && pantsID == 2 && LoadshoesID == 1)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType821", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 8 && pantsID == 2 && LoadshoesID == 2)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType822", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 8 && pantsID == 2 && LoadshoesID == 3)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType823", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 8 && pantsID == 3 && LoadshoesID == 1)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType831", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 8 && pantsID == 3 && LoadshoesID == 2)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType832", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 8 && pantsID == 3 && LoadshoesID == 3)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType833", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 8 && pantsID == 4 && LoadshoesID == 1)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType841", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 8 && pantsID == 4 && LoadshoesID == 2)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType842", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 8 && pantsID == 4 && LoadshoesID == 3)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType843", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 8 && pantsID == 5 && LoadshoesID == 1)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType851", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 8 && pantsID == 5 && LoadshoesID == 2)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType852", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 8 && pantsID == 5 && LoadshoesID == 3)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType853", typeof(GameObject))) as GameObject;
        }
        //-----------------------------------------------------------------------------------------------------------------------
        if (clothesID == 9 && pantsID == 1 && LoadshoesID == 1)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType911", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 9 && pantsID == 1 && LoadshoesID == 2)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType912", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 9 && pantsID == 1 && LoadshoesID == 3)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType913", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 9 && pantsID == 2 && LoadshoesID == 1)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType911", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 9 && pantsID == 2 && LoadshoesID == 2)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType912", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 9 && pantsID == 2 && LoadshoesID == 3)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType913", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 9 && pantsID == 3 && LoadshoesID == 1)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType911", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 9 && pantsID == 3 && LoadshoesID == 2)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType912", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 9 && pantsID == 3 && LoadshoesID == 3)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType913", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 9 && pantsID == 4 && LoadshoesID == 1)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType911", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 9 && pantsID == 4 && LoadshoesID == 2)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType912", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 9 && pantsID == 4 && LoadshoesID == 3)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType913", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 9 && pantsID == 5 && LoadshoesID == 1)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType911", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 9 && pantsID == 5 && LoadshoesID == 2)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType912", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 9 && pantsID == 5 && LoadshoesID == 3)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType913", typeof(GameObject))) as GameObject;
        }
        //-----------------------------------------------------------------------------------------------------------------------
        if (clothesID == 10 && pantsID == 1 && LoadshoesID == 1)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType1011", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 10 && pantsID == 1 && LoadshoesID == 2)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType1012", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 10 && pantsID == 1 && LoadshoesID == 3)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType1013", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 10 && pantsID == 2 && LoadshoesID == 1)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType1021", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 10 && pantsID == 2 && LoadshoesID == 2)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType1022", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 10 && pantsID == 2 && LoadshoesID == 3)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType1023", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 10 && pantsID == 3 && LoadshoesID == 1)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType1031", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 10 && pantsID == 3 && LoadshoesID == 2)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType1032", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 10 && pantsID == 3 && LoadshoesID == 3)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType1033", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 10 && pantsID == 4 && LoadshoesID == 1)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType1041", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 10 && pantsID == 4 && LoadshoesID == 2)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType1042", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 10 && pantsID == 4 && LoadshoesID == 3)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType1043", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 10 && pantsID == 5 && LoadshoesID == 1)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType1051", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 10 && pantsID == 5 && LoadshoesID == 2)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType1052", typeof(GameObject))) as GameObject;
        }
        if (clothesID == 10 && pantsID == 5 && LoadshoesID == 3)
        {
            Destroy(Player);
            Player = Instantiate(Resources.Load("FemaleType1053", typeof(GameObject))) as GameObject;
        }
        //-----------------------------------------------------------------------------------------------------------------------
    }
    #endregion 
    //選擇角色

    public void CreatPlayer() //按鈕按下去
    {
        windowSwitch = 2;
        alpha = 0; // Init Window Alpha Color
        //Debug.Log("創建遊戲視窗顯示");
    }
    public void  Exit()  //離開按鈕按下去
    {
        windowSwitch = 1; //切換視窗
        alpha = 0; // Init Window Alpha Color
        //Debug.Log("離開遊戲視窗顯示");
    }

    void OnGUI()
    {
        if (windowSwitch == 1) //切換視窗
        {
            GUIAlphaColor_0_To_1();
            windowRect = GUI.Window(0, windowRect, QuitWindow, "Quit Window");
        }
        if (windowSwitch == 2) //切換視窗
        {
            GUIAlphaColor_0_To_1();
            windowRect = GUI.Window(0, windowRect, CreateWindow, "Create Window");
        }
    }

    void GUIAlphaColor_0_To_1() //動畫
    {
        if (alpha < 1)
        {
            alpha += Time.deltaTime;
            GUI.color = new Color(1, 1, 1, alpha);
        }
    }
    void QuitWindow(int windowID)
    {
        GUI.Label(new Rect(100, 50, 300, 30), "Are you sure you want to quit game ?");

        if (GUI.Button(new Rect(80, 110, 100, 20), "Quit"))
        {
            Application.Quit();
        }
        if (GUI.Button(new Rect(220, 110, 100, 20), "Cancel"))
        {
            windowSwitch = 0; //關掉視窗
        }

        GUI.DragWindow();
    }
    void CreateWindow(int windowID)
    {
        GUI.Label(new Rect(100, 50, 300, 30), "Are you sure you want to create the character ?");

        if (GUI.Button(new Rect(80, 110, 100, 20), "Yes"))
        {
            //執行創建角色
            Debug.Log("創建角色");
            StartCoroutine("Createcharacter");
        }
        if (GUI.Button(new Rect(220, 110, 100, 20), "Cancel"))
        {
            windowSwitch = 0; //關掉視窗
        }

        GUI.DragWindow();
    }

    //真正連資料庫Create character
    IEnumerator Createcharacter()
    {
        WWWForm Form = new WWWForm();

        //Form.AddField("Account", LoginScript.Account);    //抓註冊帳號值
        //Form.AddField("SexID", sexID); //抓值
        //Form.AddField("clothesID", clothesID); //抓值
        //Form.AddField("pantsID", pantsID); //抓值
        //Form.AddField("ShoesID", LoadshoesID); //抓值

        WWW CreateCharacterWWW = new WWW(CreateCharacterUrl+ LoginScript.Account+ "&SexId=" + sexID+ "&clothesID="+ clothesID+ "&pantsID=" + pantsID + "&shoesID="+ LoadshoesID);


        //等待php回傳給unity

        yield return CreateCharacterWWW;

        if (CreateCharacterWWW.error != null)
        {
            Debug.LogError("Cannot connect to Account Creation");
        }
        else
        {
            string CreatecharacterText = CreateCharacterWWW.text;     //回傳php網頁顯示的文字

            // Debug.Log(CreateAccountText);                       //回傳php網頁顯示的文字 , 用來測試網頁回傳甚麼動作以利我們寫程式接著要執行甚麼動作


            if (CreatecharacterText == "success")
            {
                Debug.Log("角色建立成功");
                SceneManager.LoadScene(1);
                MenuControl.UI_Menu.SetActive(true);

            }
            if (CreatecharacterText == "AccountIsUsed")
            {
                Debug.Log("錯誤請檢查");
            }
        }
    }   
}
