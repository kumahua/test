using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InformationViewUIscript : MonoBehaviour {

    public static GameObject InformationView;
    public bool openandclose = false;

    // Use this for initialization
    void Start ()
    {
        InformationView = GameObject.Find("InformationView");
        InformationView.SetActive(false);
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void InformationViewopen()
    {
        switch (openandclose)
        {
            case true:
                InformationView.SetActive(false);
                openandclose = false;
                Debug.Log("視窗關閉!");
                break;
            case false:
                InformationView.SetActive(true);
                openandclose = true;
                Debug.Log("視窗開啟!");
                break;
            default:

                break;
        }
    }

    public void InformationViewclose()
    {
        InformationView.SetActive(false);
        openandclose = false;
        Debug.Log("視窗關閉!");
    }

    public void InformationViewOKClick()
    {
        InformationView.SetActive(false);
        openandclose = false;
        Debug.Log("視窗關閉!");
    }
}
