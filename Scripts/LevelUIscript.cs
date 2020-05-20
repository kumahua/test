using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUIscript : MonoBehaviour {

    public Text LevelText;

    // Use this for initialization
    void Start ()
    {
		LevelText = GameObject.Find("LevelText").GetComponent<Text>(); //抓到對應的Text值
    }
	
	// Update is called once per frame
	void Update ()
    {
        LevelText.text = " " + Loadcharacter.LoadLevel + " ";
	}
}
