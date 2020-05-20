using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus; //用Fungus的東西

public class ReviewTaskNPC : MonoBehaviour {

    public  Flowchart Mission_Flowchart; //擺入指定的流程圖
    public string onTriggerEnter; //指定名稱要和進入的NPC(Block)名稱一樣
    public GameObject Icon; //把驚嘆號拉到對應的位置
    public string Iconstring; //驚嘆號名稱
    public GameObject MapIcon;
    public string MapIconstring; //地圖的驚嘆號名稱
    public GameObject NPCPointer; //目前沒用
    public string Pointername;    //目前沒用


#region
    public  string SereneReview //抓fuguns裡面的值
    {
        get { return Mission_Flowchart.GetStringVariable("SereneReview"); } //指定到對應的欄位
        set { Mission_Flowchart.SetStringVariable("SereneReview", value); }
    }

    public  string ThoughtfulReview //抓fuguns裡面的值
    {
        get { return Mission_Flowchart.GetStringVariable("ThoughtfulReview"); } //指定到對應的欄位
        set { Mission_Flowchart.SetStringVariable("ThoughtfulReview", value); }
    }

    public  string SubsidyReview //抓fuguns裡面的值
    {
        get { return Mission_Flowchart.GetStringVariable("SubsidyReview"); } //指定到對應的欄位
        set { Mission_Flowchart.SetStringVariable("SubsidyReview", value); }
    }

    public  string PurificationReview //抓fuguns裡面的值
    {
        get { return Mission_Flowchart.GetStringVariable("PurificationReview"); } //指定到對應的欄位
        set { Mission_Flowchart.SetStringVariable("PurificationReview", value); }
    }

    public  string DetentionReview //抓fuguns裡面的值
    {
        get { return Mission_Flowchart.GetStringVariable("DetentionReview"); } //指定到對應的欄位
        set { Mission_Flowchart.SetStringVariable("DetentionReview", value); }
    }

    public  string DrainReview //抓fuguns裡面的值
    {
        get { return Mission_Flowchart.GetStringVariable("DrainReview"); } //指定到對應的欄位
        set { Mission_Flowchart.SetStringVariable("DrainReview", value); }
    }

    public  string BeautifyReview //抓fuguns裡面的值
    {
        get { return Mission_Flowchart.GetStringVariable("BeautifyReview"); } //指定到對應的欄位
        set { Mission_Flowchart.SetStringVariable("BeautifyReview", value); }
    }

    public  string ConcentrationReview //抓fuguns裡面的值
    {
        get { return Mission_Flowchart.GetStringVariable("ConcentrationReview"); } //指定到對應的欄位
        set { Mission_Flowchart.SetStringVariable("ConcentrationReview", value); }
    }

    public  string Ecological_corridorsReview //抓fuguns裡面的值
    {
        get { return Mission_Flowchart.GetStringVariable("Ecological_corridorsReview"); } //指定到對應的欄位
        set { Mission_Flowchart.SetStringVariable("Ecological_corridorsReview", value); }
    }

    public  string PicturesqueReview //抓fuguns裡面的值
    {
        get { return Mission_Flowchart.GetStringVariable("PicturesqueReview"); } //指定到對應的欄位
        set { Mission_Flowchart.SetStringVariable("PicturesqueReview", value); }
    }

    public  string AquaticReview //抓fuguns裡面的值
    {
        get { return Mission_Flowchart.GetStringVariable("AquaticReview"); } //指定到對應的欄位
        set { Mission_Flowchart.SetStringVariable("AquaticReview", value); }
    }

    public  string LandscapingReview //抓fuguns裡面的值
    {
        get { return Mission_Flowchart.GetStringVariable("LandscapingReview"); } //指定到對應的欄位
        set { Mission_Flowchart.SetStringVariable("LandscapingReview", value); }
    }

    public  string BiodiversityReview //抓fuguns裡面的值
    {
        get { return Mission_Flowchart.GetStringVariable("BiodiversityReview"); } //指定到對應的欄位
        set { Mission_Flowchart.SetStringVariable("BiodiversityReview", value); }
    }

    public  string AmphibianReview //抓fuguns裡面的值
    {
        get { return Mission_Flowchart.GetStringVariable("AmphibianReview"); } //指定到對應的欄位
        set { Mission_Flowchart.SetStringVariable("AmphibianReview", value); }
    }
#endregion

    // Use this for initialization
    void Start ()
    {
        Mission_Flowchart = GameObject.Find("FightFlowchart").GetComponent<Flowchart>();
        Icon = GameObject.Find(Iconstring);
        //Icon.SetActive(false);
        MapIcon = GameObject.Find(MapIconstring);
        //MapIcon.SetActive(false);
        NPCPointer = GameObject.Find(Pointername); //完成的引導
        NPCPointer.SetActive(false);               //設定先不顯示
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
    void PlayBlock(string targetBlcokName) //設定要撥放的對話名稱
    {

        Block targetBlock = Mission_Flowchart.FindBlock(onTriggerEnter);//名稱要和進入的NPC名稱一樣
        if (targetBlock != null)
        {
            Mission_Flowchart.ExecuteBlock(targetBlock);
        }
        else
        {
            Debug.LogError("找不到在" + Mission_Flowchart.name + "裡的" + targetBlcokName + "Block"); //錯誤訊息 表示找不到相對應的對話物件
        }
    }
    void OnTriggerStay(Collider other) //觸發開始
    {
        PhotonView photonView = other.gameObject.GetComponent<PhotonView>();
        if (photonView != null && !photonView.isMine)
        {
            return;

        }
        else
        {
           
            if (other.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.Z))
            {
                PlayBlock(onTriggerEnter);
                
                Debug.Log("碰到NPC名稱:" + onTriggerEnter + ",且玩家TAG為Player"); //設定碰到編號NPC
            }
        }
    }
    void OnTriggerExit(Collider other)//離開觸發
    {
      
    }
    void Mission_SereneReview() //複習任務任務
    {
        if (SereneReview == "None")
        {
            Icon.SetActive(true);
            //MissionUI.Serene_R.SetActive(false);   //任務內容的提示UI關閉
            //MapIcon.SetActive(true);
        }
        if (SereneReview == "Ing")
        {
            Icon.SetActive(false);
            //MapIcon.SetActive(false);
            //MissionUI.Serene_R.SetActive(true);    //任務內容的提示UI開啟
            //MissionUI.MissionView.SetActive(true); //任務內容UI開啟
        }
        if (SereneReview == "Done")
        {
            //MissionUI.Serene_R.SetActive(false);   //任務內容的提示UI關閉
        }
        
    }
    void Mission_ThoughtfulReview() //複習任務任務
    {
        if (ThoughtfulReview == "None")
        {
            Icon.SetActive(true);
            //MissionUI.Thoughtful_R.SetActive(false);   //任務內容的提示UI關閉
        }
        if (ThoughtfulReview == "Ing")
        {
            Icon.SetActive(false);
            //MissionUI.Thoughtful_R.SetActive(true);    //任務內容的提示UI開啟
            //MissionUI.MissionView.SetActive(true); //任務內容UI開啟
        }
        if (ThoughtfulReview == "Done")
        {
            //MissionUI.Thoughtful_R.SetActive(false);   //任務內容的提示UI關閉
        }

    }
    void Mission_SubsidyReview() //複習任務任務
    {
        if (SubsidyReview == "None")
        {
            Icon.SetActive(true);
            //MissionUI.Subsidy_R.SetActive(false);   //任務內容的提示UI開啟
        }
        if (SubsidyReview == "Ing")
        {
            Icon.SetActive(false);
            //MissionUI.Subsidy_R.SetActive(true);    //任務內容的提示UI開啟
            //MissionUI.MissionView.SetActive(true); //任務內容UI開啟
        }
        if (SubsidyReview == "Done")
        {
            //MissionUI.Subsidy_R.SetActive(false);   //任務內容的提示UI開啟
        }

    }
    void Mission_PurificationReview() //複習任務任務
    {
        if (PurificationReview == "None")
        {
            Icon.SetActive(true);
            //MissionUI.Purification_R.SetActive(false);   //任務內容的提示UI開啟
        }
        if (PurificationReview == "Ing")
        {
            Icon.SetActive(false);
            //MissionUI.Purification_R.SetActive(true);    //任務內容的提示UI開啟
            //MissionUI.MissionView.SetActive(true); //任務內容UI開啟
        }
        if (PurificationReview == "Done")
        {
            //MissionUI.Purification_R.SetActive(false);   //任務內容的提示UI開啟
        }

    }
    void Mission_DetentionReview() //複習任務任務
    {
        if (DetentionReview == "None")
        {
            Icon.SetActive(true);
            //MissionUI.Dention_R.SetActive(false);   //任務內容的提示UI開啟
        }
        if (DetentionReview == "Ing")
        {
            Icon.SetActive(false);
            //MissionUI.Dention_R.SetActive(true);    //任務內容的提示UI開啟
            //MissionUI.MissionView.SetActive(true); //任務內容UI開啟
        }
        if (DetentionReview == "Done")
        {
            //MissionUI.Dention_R.SetActive(false);   //任務內容的提示UI開啟
        }

    }
    void Mission_BeautifyReview() //複習任務任務
    {
        if (BeautifyReview == "None")
        {
            Icon.SetActive(true);
            //MissionUI.Beautify_R.SetActive(false);   //任務內容的提示UI開啟
        }
        if (BeautifyReview == "Ing")
        {
            Icon.SetActive(false);
            //MissionUI.Beautify_R.SetActive(true);    //任務內容的提示UI開啟
            //MissionUI.MissionView.SetActive(true); //任務內容UI開啟
        }
        if (BeautifyReview == "Done")
        {
            //MissionUI.Beautify_R.SetActive(false);   //任務內容的提示UI開啟
        }

    }
    void Mission_DrainReview() //複習任務任務
    {
        if (DrainReview == "None")
        {
            Icon.SetActive(true);
            //MissionUI.Drain_R.SetActive(false);   //任務內容的提示UI開啟
        }
        if (DrainReview == "Ing")
        {
            Icon.SetActive(false);
            //MissionUI.Drain_R.SetActive(true);    //任務內容的提示UI開啟
            //MissionUI.MissionView.SetActive(true); //任務內容UI開啟
        }
        if (DrainReview == "Done")
        {
            //MissionUI.Drain_R.SetActive(false);   //任務內容的提示UI開啟
        }

    }
    void Mission_ConcentrationReview() //複習任務任務
    {
        if (ConcentrationReview == "None")
        {
            Icon.SetActive(true);
            //MissionUI.Concentration_R.SetActive(false);   //任務內容的提示UI開啟
        }
        if (ConcentrationReview == "Ing")
        {
            Icon.SetActive(false);
            //MissionUI.Concentration_R.SetActive(true);    //任務內容的提示UI開啟
            //MissionUI.MissionView.SetActive(true); //任務內容UI開啟
        }
        if (ConcentrationReview == "Done")
        {
            //MissionUI.Concentration_R.SetActive(false);   //任務內容的提示UI開啟
        }

    }
    void Mission_Ecological_corridorsReview() //複習任務任務
    {
        if (Ecological_corridorsReview == "None")
        {
            Icon.SetActive(true);
            //MissionUI.Ecologicalcorridors_R.SetActive(false);   //任務內容的提示UI開啟
        }
        if (Ecological_corridorsReview == "Ing")
        {
            Icon.SetActive(false);
            //MissionUI.Ecologicalcorridors_R.SetActive(true);    //任務內容的提示UI開啟
            //MissionUI.MissionView.SetActive(true); //任務內容UI開啟
        }
        if (Ecological_corridorsReview == "Done")
        {
            //MissionUI.Ecologicalcorridors_R.SetActive(false);   //任務內容的提示UI開啟
        }

    }
    void Mission_PicturesqueReview() //複習任務任務
    {
        if (PicturesqueReview == "None")
        {
            Icon.SetActive(true);
            //MissionUI.Picturesque_R.SetActive(false);   //任務內容的提示UI開啟
        }
        if (PicturesqueReview == "Ing")
        {
            Icon.SetActive(false);
            //MissionUI.Picturesque_R.SetActive(true);    //任務內容的提示UI開啟
            //MissionUI.MissionView.SetActive(true); //任務內容UI開啟
        }
        if (PicturesqueReview == "Done")
        {
            //MissionUI.Picturesque_R.SetActive(false);   //任務內容的提示UI開啟
        }

    }
    void Mission_AquaticReview() //複習任務任務
    {
        if (AquaticReview == "None")
        {
            Icon.SetActive(true);
            //MissionUI.Aquatic_R.SetActive(false);   //任務內容的提示UI開啟
        }
        if (AquaticReview == "Ing")
        {
            Icon.SetActive(false);
            //MissionUI.Aquatic_R.SetActive(true);    //任務內容的提示UI開啟
            //MissionUI.MissionView.SetActive(true); //任務內容UI開啟
        }
        if (AquaticReview == "Done")
        {
            //MissionUI.Aquatic_R.SetActive(false);   //任務內容的提示UI開啟
        }

    }
    void Mission_LandscapingReview() //複習任務任務
    {
        if (LandscapingReview == "None")
        {
            Icon.SetActive(true);
            //MissionUI.Landscaping_R.SetActive(false);   //任務內容的提示UI開啟
        }
        if (LandscapingReview == "Ing")
        {
            Icon.SetActive(false);
            //MissionUI.Landscaping_R.SetActive(true);    //任務內容的提示UI開啟
            //MissionUI.MissionView.SetActive(true); //任務內容UI開啟
        }
        if (LandscapingReview == "Done")
        {
            //MissionUI.Landscaping_R.SetActive(false);   //任務內容的提示UI開啟
        }

    }
    void Mission_BiodiversityReview() //複習任務任務
    {
        if (BiodiversityReview == "None")
        {
            Icon.SetActive(true);
            //MissionUI.Biodiversity_R.SetActive(false);   //任務內容的提示UI開啟
        }
        if (BiodiversityReview == "Ing")
        {
            Icon.SetActive(false);
            //MissionUI.Biodiversity_R.SetActive(true);    //任務內容的提示UI開啟
            //MissionUI.MissionView.SetActive(true); //任務內容UI開啟
        }
        if (BiodiversityReview == "Done")
        {
            //MissionUI.Biodiversity_R.SetActive(false);   //任務內容的提示UI開啟
        }

    }
    void Mission_AmphibianReview() //複習任務任務
    {
        if (AmphibianReview == "None")
        {
            Icon.SetActive(true);
            //MissionUI.Amphibian_R.SetActive(false);   //任務內容的提示UI開啟
        }
        if (AmphibianReview == "Ing")
        {
            Icon.SetActive(false);
            //MissionUI.Amphibian_R.SetActive(true);    //任務內容的提示UI開啟
            //MissionUI.MissionView.SetActive(true); //任務內容UI開啟
        }
        if (AmphibianReview == "Done")
        {
            //MissionUI.Amphibian_R.SetActive(false);   //任務內容的提示UI開啟
        }

    }
}
