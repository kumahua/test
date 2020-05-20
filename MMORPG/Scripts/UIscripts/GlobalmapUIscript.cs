using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalmapUIscript : MonoBehaviour {

    public static GameObject Globalmap;
    public static bool openandclose = false;


    // Use this for initialization
    void Start()
    {
        Globalmap = GameObject.Find("GlobalMap");
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void Fullmapopen()
    {
        switch (openandclose)
        {
            case true:
                Globalmap.SetActive(false);
                openandclose = false;            
                Debug.Log("視窗關閉!");
                break;
            case false:
                Globalmap.SetActive(true);
                openandclose = true;
                Debug.Log("視窗開啟!");
                break;
            default:

                break;
        }
    }

    public void Fullmapclose()
    {
        Globalmap.SetActive(false);
        openandclose = false;
        Debug.Log("視窗關閉!");
    }
}
