using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class LoadScene : MonoBehaviour {

    public bool CurrentState = false;
    public bool CanEnterGame = false;
    PersonMovement playermove;   //要抓PersonMovement程式碼裡面的值

    // Use this for initialization
    void Start ()
    {
        playermove = FindObjectOfType<PersonMovement>();  //要抓PersonMovement程式碼裡面的值
    }

    void Awake()
    {
        
    }
	// Update is called once per frame
	void Update ()
    {
	
	}

    void OnGUI()
    {
        if(CurrentState == true)  //如果判斷當前況狀要離開的話
        {
            //寫是否要離開角色設定畫面的提示
            GUI.Box(new Rect(Screen.width / 4, Screen.height / 4, 2 * (Screen.width / 4), 2 * (Screen.height / 4)), "確定要離開嗎?"); //視窗大小依照顯示器不同調整;  x , y , 寬 , 高

            if (GUI.Button(new Rect((Screen.width / 2) - 110, 420, 110, 25), "YES"))//按鈕YES被按下之後
            {
                CanEnterGame = true;                                                 //設定值更改 準備進入場景
                Debug.Log("載入校園場景中...");
                SceneManager.LoadScene(4);//載入場景編號4
                playermove.ForwardSpeed = 8;   //讓角色恢復移動
                playermove.BackwardSpeed = 4;  //讓角色恢復移動
            }
            if (GUI.Button(new Rect((Screen.width / 2), 420, 110, 25), "NO"))       //按鈕NO被按下之後
            {
                CurrentState = false;                                         //回到原來場景
                playermove.ForwardSpeed = 8;   //讓角色恢復移動
                playermove.BackwardSpeed = 4;  //讓角色恢復移動
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        CurrentState = true;  //啟動GUI提示
        playermove.ForwardSpeed = 0;   //讓角色靜止不動
        playermove.BackwardSpeed = 0;  //讓角色靜止不動
/*
        if (other.CompareTag("Player") && CanEnterGame == true)
        {
            Debug.Log("載入校園場景中...");
            SceneManager.LoadScene(4);//載入場景編號4
        }
*/
    } 

}
