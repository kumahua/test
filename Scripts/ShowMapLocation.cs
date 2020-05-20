using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowMapLocation : MonoBehaviour {

    public string onselectmaplocation;
    public GameObject Selectmaplocation;

  
    
    // Use this for initialization
    void Start ()
    {
        Selectmaplocation = GameObject.Find(onselectmaplocation);
        Selectmaplocation.SetActive(false);
    }

	
	// Update is called once per frame
	void Update ()
    {

    }

    void OnTriggerStay(Collider other) //待在觸發裡面會持續判斷
    {
        PhotonView photonView = other.gameObject.GetComponent<PhotonView>(); //判斷是不是點擊的使用者
        if (photonView != null && !photonView.isMine)
        {
            return;
        }
        else
        {
            
            if (other.gameObject.CompareTag("Player"))
            {
                
                if (Input.GetKey(KeyCode.M))
                {
                    GlobalmapUIscript.Globalmap.SetActive(true);
                    GlobalmapUIscript.openandclose = true;
                    Selectmaplocation.SetActive(true);
                    Debug.Log("視窗開啟!");
                }
            }
        }
    }
    void OnTriggerExit(Collider other)//離開觸發
    {
        
        GlobalmapUIscript.openandclose = false;
        Selectmaplocation.SetActive(false);
     

    }
}
