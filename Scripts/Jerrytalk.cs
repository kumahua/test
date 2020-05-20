using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Jerrytalk : Photon.PunBehaviour
{ 

    bool currentstate=false;

    // Use this for initialization
    void Awake()
    {       
      
    }

    void Start ()
    {
        


    }
	void OnGUI()
    {
       

        if (currentstate == true)
        {
            GUI.Box(new Rect(Screen.width / 4, Screen.height / 4, 2 * (Screen.width / 4), 2 * (Screen.height / 4)), "是否前往靜思湖挑戰??");
            if (GUI.Button(new Rect((Screen.width / 2) - 110, 420, 110, 25), "YES"))//按鈕YES被按下之後
            {
                //設定值更改 準備進入場景

                Debug.Log("載入校園場景中...");

               if (PhotonNetwork.inRoom)
                {
                    SceneManager.LoadScene(3);
                }
               else
                {
                    return;
                }

                //playermove.ForwardSpeed = 8;   //讓角色恢復移動
                //playermove.BackwardSpeed = 4;  //讓角色恢復移動
            }
            if (GUI.Button(new Rect((Screen.width / 2), 420, 110, 25), "NO"))       //按鈕NO被按下之後
            {
                currentstate = false;                                         //回到原來場景
                //playermove.ForwardSpeed = 8;   //讓角色恢復移動
                //playermove.BackwardSpeed = 4;  //讓角色恢復移動
            }
        }
    }
	// Update is called once per frame
	void Update ()
    {
        
    }
    void OnTriggerStay(Collider other)
    {
        PhotonView photonView = other.gameObject.GetComponent<PhotonView>();

        if (photonView != null && !photonView.isMine)
        {
            return;

        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                currentstate = true;
                Debug.Log("本人觸發");
            }
        }
        
        

    }
    
}
