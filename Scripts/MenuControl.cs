using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuControl : MonoBehaviour {

    public static GameObject UI_Menu;
    public GameObject ConfirmButton;           //進入遊戲的按鈕

    public static MenuControl instance;
    // Use this for initialization
    void Start ()
    {
        if (instance != null)
        {
            DestroyImmediate(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        instance = this;

        ConfirmButton = GameObject.Find("Enter");
        UI_Menu = GameObject.Find("UI_Menu");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
