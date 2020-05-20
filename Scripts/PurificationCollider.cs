using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PurificationCollider : MonoBehaviour {
    public static GameObject title_Background;
    public static GameObject title;
    public string newScene;
    //string newString;
    // Use this for initialization
    void Start ()
    {
        title_Background = GameObject.Find("Title_Background");
        title = GameObject.Find("Title");
        Display();
        LoadScene();
        Debug.Log(newScene);
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
    public void Display()
    {
        newScene = title.GetComponent<Text>().text;
        Debug.Log(newScene);
        
    }
    public void LoadScene()
    {
        //Removes spaces from newScene text!
        //newString = newScene.Replace(" ", "");
        //Load the name of our new string
        //Application.LoadLevel(newString);
    }


    void OnTriggerEnter(Collider other) //觸發開始
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("進入淨化池區域,且玩家TAG為Player");
        }
    }
}
