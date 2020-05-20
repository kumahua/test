using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingViewUIscript : MonoBehaviour {

    public GameObject SettingView;
    public bool openandclose = false;

    // Use this for initialization
    void Start ()
    {
        SettingView = GameObject.Find("SettingView");
        SettingView.SetActive(false);

    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
    public void SettingViewopen()
    {
        switch (openandclose)
        {
            case true:
                SettingView.SetActive(false);
                openandclose = false;
                Debug.Log("視窗關閉!");
                break;
            case false:
                SettingView.SetActive(true);
                openandclose = true;
                Debug.Log("視窗開啟!");
                break;
            default:

                break;
        }
    }

    public void SettingViewclose()
    {
        SettingView.SetActive(false);
        openandclose = false;
        Debug.Log("視窗關閉!");
    }

    public void SettingSaveClick()
    {

    }
}
