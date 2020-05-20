using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetWordUIbutton : MonoBehaviour {
    //宣告UI
    #region
    public static Button ActionSlot_Serene;
    public static Text SereneText;
    public static Image Serenelock;

    public static Button ActionSlot_Thoughtful;
    public static Text ThoughtfulText;
    public static Image Thoughtfullock;

    public static Button ActionSlot_Subsidy;
    public static Text SubsidyText;
    public static Image Subsidylock;

    public static Button ActionSlot_Beautify;
    public static Text BeautifyText;
    public static Image Beautifylock;

    public static Button ActionSlot_Purification;
    public static Text PurificationText;
    public static Image Purificationlock;

    public static Button ActionSlot_Drain;
    public static Text DrainText;
    public static Image Drainlock;

    public static Button ActionSlot_Concerntration;
    public static Text ConcerntrationText;
    public static Image Concerntrationlock;

    public static Button ActionSlot_Landscaping;
    public static Text LandscapingText;
    public static Image Landscapinglock;

    public static Button ActionSlot_Eologicalcorridors;
    public static Text EologicalcorridorsText;
    public static Image Eologicalcorridorslock;

    public static Button ActionSlot_Picturesque;
    public static Text PicturesqueText;
    public static Image Picturesquelock;

    public static Button ActionSlot_Detention;
    public static Text DetentionText;
    public static Image Detentionlock;

    public static Button ActionSlot_Biodiversity;
    public static Text BiodiversityText;
    public static Image Biodiversitylock;

    public static Button ActionSlot_Aquatic;
    public static Text AquaticText;
    public static Image Aquaticlock;

    public static Button ActionSlot_Amphibian;
    public static Text AmphibianText;
    public static Image Amphibianlock;
    #endregion

    //宣告單字意思的View
    public static GameObject WordView;
    public static Text WordViewTittle;
    public static Text WordViewText;

    public static bool openandclose = false;

  
    void Awake()
    {
        #region
        ActionSlot_Serene = GameObject.Find("ActionSlot_Serene").GetComponent<Button>();
        SereneText = GameObject.Find("SereneText").GetComponent<Text>();
        Serenelock = GameObject.Find("Serenelock").GetComponent<Image>();
        ActionSlot_Serene.interactable = false;
        SereneText.enabled = false;

        ActionSlot_Thoughtful = GameObject.Find("ActionSlot_Thoughtful").GetComponent<Button>();
        ThoughtfulText = GameObject.Find("ThoughtfulText").GetComponent<Text>();
        Thoughtfullock = GameObject.Find("Thoughtfullock").GetComponent<Image>();
        ActionSlot_Thoughtful.interactable = false;
        ThoughtfulText.enabled = false;

        ActionSlot_Subsidy = GameObject.Find("ActionSlot_Subsidy").GetComponent<Button>();
        SubsidyText = GameObject.Find("SubsidyText").GetComponent<Text>();
        Subsidylock = GameObject.Find("Subsidylock").GetComponent<Image>();
        ActionSlot_Subsidy.interactable = false;
        SubsidyText.enabled = false;

        ActionSlot_Beautify = GameObject.Find("ActionSlot_Beautify").GetComponent<Button>();
        BeautifyText = GameObject.Find("BeautifyText").GetComponent<Text>();
        Beautifylock = GameObject.Find("Beautifylock").GetComponent<Image>();
        ActionSlot_Beautify.interactable = false;
        BeautifyText.enabled = false;

        ActionSlot_Purification = GameObject.Find("ActionSlot_Purification").GetComponent<Button>();
        PurificationText = GameObject.Find("PurificationText").GetComponent<Text>();
        Purificationlock = GameObject.Find("Purificationlock").GetComponent<Image>();
        ActionSlot_Purification.interactable = false;
        PurificationText.enabled = false;

        ActionSlot_Drain = GameObject.Find("ActionSlot_Drain").GetComponent<Button>();
        DrainText = GameObject.Find("DrainText").GetComponent<Text>();
        Drainlock = GameObject.Find("Drainlock").GetComponent<Image>();
        ActionSlot_Drain.interactable = false;
        DrainText.enabled = false;

        ActionSlot_Concerntration = GameObject.Find("ActionSlot_Concerntration").GetComponent<Button>();
        ConcerntrationText = GameObject.Find("ConcerntrationText").GetComponent<Text>();
        Concerntrationlock = GameObject.Find("Concerntrationlock").GetComponent<Image>();
        ActionSlot_Concerntration.interactable = false;
        ConcerntrationText.enabled = false;

        ActionSlot_Landscaping = GameObject.Find("ActionSlot_Landscaping").GetComponent<Button>();
        LandscapingText = GameObject.Find("LandscapingText").GetComponent<Text>();
        Landscapinglock = GameObject.Find("Landscapinglock").GetComponent<Image>();
        ActionSlot_Landscaping.interactable = false;
        LandscapingText.enabled = false;

        ActionSlot_Eologicalcorridors = GameObject.Find("ActionSlot_Eologicalcorridors").GetComponent<Button>();
        EologicalcorridorsText = GameObject.Find("EologicalcorridorsText").GetComponent<Text>();
        Eologicalcorridorslock = GameObject.Find("Eologicalcorridorslock").GetComponent<Image>();
        ActionSlot_Eologicalcorridors.interactable = false;
        EologicalcorridorsText.enabled = false;

        ActionSlot_Picturesque = GameObject.Find("ActionSlot_Picturesque").GetComponent<Button>();
        PicturesqueText = GameObject.Find("PicturesqueText").GetComponent<Text>();
        Picturesquelock = GameObject.Find("Picturesquelock").GetComponent<Image>();
        ActionSlot_Picturesque.interactable = false;
        PicturesqueText.enabled = false;

        ActionSlot_Detention = GameObject.Find("ActionSlot_Detention").GetComponent<Button>();
        DetentionText = GameObject.Find("DetentionText").GetComponent<Text>();
        Detentionlock = GameObject.Find("Detentionlock").GetComponent<Image>();
        ActionSlot_Detention.interactable = false;
        DetentionText.enabled = false;

        ActionSlot_Biodiversity = GameObject.Find("ActionSlot_Biodiversity").GetComponent<Button>();
        BiodiversityText = GameObject.Find("BiodiversityText").GetComponent<Text>();
        Biodiversitylock = GameObject.Find("Biodiversitylock").GetComponent<Image>();
        ActionSlot_Biodiversity.interactable = false;
        BiodiversityText.enabled = false;

        ActionSlot_Aquatic = GameObject.Find("ActionSlot_Aquatic").GetComponent<Button>();
        AquaticText = GameObject.Find("AquaticText").GetComponent<Text>();
        Aquaticlock = GameObject.Find("Aquaticlock").GetComponent<Image>();
        ActionSlot_Aquatic.interactable = false;
        AquaticText.enabled = false;

        ActionSlot_Amphibian = GameObject.Find("ActionSlot_Amphibian").GetComponent<Button>();
        AmphibianText = GameObject.Find("AmphibianText").GetComponent<Text>();
        Amphibianlock = GameObject.Find("Amphibianlock").GetComponent<Image>();
        ActionSlot_Amphibian.interactable = false;
        AmphibianText.enabled = false;
        #endregion

        WordView = GameObject.Find("WordView");
        WordViewTittle = GameObject.Find("WordViewTittle").GetComponent<Text>(); //如果直接接上Getcomponent 就是帶她直接找那個物件裡面
        WordViewText = GameObject.Find("WordViewText").GetComponent<Text>();
        WordView.SetActive(false);


    }
    // Use this for initialization
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ClickSerene()//啟動單字卡,改成複習任務的敘述,點擊開始載入
    {
        //加入一個判斷,判斷是否執行過複習任務
        switch (openandclose)
        {
            case false:  
                WordViewTittle.text = "Serene";
                WordViewText.text = "<size=30>"+"Serene 寧靜的、祥和的"+ "</size>" + "\n" + "\n" + "Description: Peaceful and calm." + "\n" + "Sentence: The girl’s face is serene and peaceful."; //改成要玩家可以去接複習任務的判斷
                WordView.SetActive(true);     
                openandclose = true;              
                break;
            case true:              
                WordView.SetActive(false);
                openandclose = false;
                break;
            default:

                break;   
        }
    }
    public void ClickThoughtful()
    {
        switch (openandclose)
        {
            case false:
                WordViewTittle.text = "Thoughtful";
                WordViewText.text = "<size=30>" + "Thoughtful 沉思的、替人著想的" + "</size>" + "\n" + "\n" + "Description: Carefully considering things; quiet because you are thinking about something." + "\n" + "Sentence: He pondered over the matter, and fell into a thoughtful silence."; //改成要玩家可以去接複習任務的判斷
                WordView.SetActive(true);            
                openandclose = true;
                break;
            case true:
                WordView.SetActive(false);
                openandclose = false;
                break;
            default:

                break;
    }
}
    public void ClickSubsidy()
    {
        switch (openandclose)
        {
            case false:
                WordViewTittle.text = "Subsidy";
                WordViewText.text = "<size=30>" + "Subsidy 補助；補助金" + "</size>" + "\n" + "\n" + "Description: Paid by a government or other organization in order to help an industry or business, or to pay for a public service." + "\n" + "Sentence: The company received a substantial government subsidy, which will be used for constructing the new office building.";
                WordView.SetActive(true);
                openandclose = true;
                break;
            case true:
                WordView.SetActive(false);
                openandclose = false;
                break;
            default:

                break;
        }
    }
    public void ClickBeautify()
    {
        switch (openandclose)
        {
            case false:
                WordViewTittle.text = "Beautify";
                WordViewText.text = "<size=30>" + "Beautify 美化" + "</size>" + "\n" + "\n" + "Description: To improve the appearance of someone or something." + "\n" + "Sentence: My neighbors grow lots of plants to beautify their backyard.";
                WordView.SetActive(true);
                openandclose = true;
                break;
            case true:
                WordView.SetActive(false);
                openandclose = false;
               break;
        }
}
    public void ClickPurification()
    {
        switch (openandclose)
        {
            case false:
                WordViewTittle.text = "Purification";
                WordViewText.text = "<size=30>" + "Purification 淨化" + "</size>" + "\n" + "\n" + "Description: The act of removing harmful substances from something." + "\n" + "Sentence:  I always bring water purification tablets when I go camping."; //改成要玩家可以去接複習任務的判斷
                WordView.SetActive(true);      
                openandclose = true;
                break;
            case true:
                WordView.SetActive(false);
                openandclose = false;
                break;
            default:
                break;
        }
    }
    public void ClickDrain()
    {
        switch (openandclose)
        {
            case false:
                WordViewTittle.text = "Drain";
                WordViewText.text = "<size=30>" + "Drain 排水" + "</size>" + "\n" + "\n" + "Description: Cause the water or other liquid to run out." + "\n" + "\n" + "Sentence: This swimming pool is drained and cleaned every month.";
                WordView.SetActive(true);         
                openandclose = true;
                break;
            case true:
                WordView.SetActive(false);
                openandclose = false;
                break;
            default:
                break;
    }
        
    }
    public void ClickConcerntration()
    {
        switch (openandclose)
        {
            case false:
                WordViewTittle.text = "Concerntration";
                WordViewText.text = "<size=30>" + "Concerntration 濃度" + "</size>" + "\n" + "\n" + "Description: The relative amount of a particular substance contained within a solution or mixture or in a particular volume of space." + "\n" + "Sentence: High concerntration of toxic elements were found in the polluted areas.";
                WordView.SetActive(true);    
                openandclose = true;
                break;
            case true:
                WordView.SetActive(false);
                openandclose = false;
                break;
            default:
                break;
        }
    }
    public void ClickLandscaping()
    {
        switch (openandclose)
        {
            case false:
                WordViewTittle.text = "Landscaping";
                WordViewText.text = "<size=30>" + "Landscaping 造景" + "</size>" + "\n" + "\n" + "Description: To improve the appearance of (an area of land, a highway, etc.), as by planting trees, or grass." + "\n" + "Sentence: This castle boasts of unique landscaping designs.";
                WordView.SetActive(true);
                openandclose = true;
                break;
            case true:
                WordView.SetActive(false);
                openandclose = false;
                        break;
            default:

                break;
    }
}
    public void ClickEologicalcorridors()
    {
        switch (openandclose)
        {
            case false:
                WordViewTittle.text = "Eological corridors";
                WordViewText.text = "<size=30>" + "Eological Corridors 生態走廊" + "</size>" + "\n" + "\n" + "Description: A functional zone of passage between several natural zones for a group of species dependent on a single environment." + "\n" + "Sentence: Voluntary action by landowners, in cooperation with the park and the county, is helping to restrict small-lot subdivisions, maintain eological corridors, and minimize any harmful impact on the environment.";
                WordView.SetActive(true);        
                openandclose = true;
                break;
            case true:
                WordView.SetActive(false);
                openandclose = false;
                break;
            default:

                break;
        }
    }
    public void ClickPicturesque()
    {
        switch (openandclose)
        {
            case false:
                WordViewTittle.text = "Picturesque";
                WordViewText.text = "<size=30>" + "Picturesque 風景如畫的；圖畫般的；別具一格的" + " </size>" + "\n" + "\n" + "Description: Visually attractive, especially in a charming or pretty style, as if resembling or suitable for a painting." + "\n" + "Sentence: New England is rightly noted for its picturesque country inns, friendly guest houses and pleasant bed and delicious food.";
                WordView.SetActive(true);
                openandclose = true;
                break;
            case true:
                WordView.SetActive(false);
                openandclose = false;
                break;
            default:

                break;
        }
    }
    public void ClickDetention()
    {
        switch (openandclose)
        {
            case false:
                WordViewTittle.text = "Detention";
                WordViewText.text = "<size=30>" + "Detention 拘留、滯留" + "</size>" + "\n" + "\n" + "Description: Is a state when someone is arrested or put into prison, especially for political." + "\n" + "Sentence: John was held in detention for 24 hours for drunk driving.";
                WordView.SetActive(true);
                openandclose = true;
                break;
            case true:
                WordView.SetActive(false);
                openandclose = false;
                break;
            default:

                break;
        }
    }
    public void ClickBiodiversity()
    {
        switch (openandclose)
        {
            case false:
                WordViewTittle.text = "Biodiversity";
                WordViewText.text = "<size=30>" + "Biodiversity 生物多樣性" + "</size>" + "\n" + "\n" + "Description: The variety of life in the world or in a particular area." + "\n" + "Sentence: The mining project threatens one of the world’s richest areas of biodiversity.";
                WordView.SetActive(true);     
                openandclose = true;
                break;
            case true:
                WordView.SetActive(false);
                openandclose = false;
                break;
            default:

                break;
        }
    }
    public void ClickAquatic()
    {
        switch (openandclose)
        {
            case false:
                WordViewTittle.text = "Aquatic";
                WordViewText.text = "<size=30>" + "Aquatic 水生的" + "</size>" + "\n" + "\n" + "Description: Growing or living in or near water" + "\n" + "Sentence: he blue whale and sperm whale are the largest mammals among the aquatic animals.";
                WordView.SetActive(true);       
                openandclose = true;
                break;
            case true:
                WordView.SetActive(false);
                openandclose = false;
                break;
            default:

                break;
        }
    }
    public void ClickAmphibian()
    {
        switch (openandclose)
        {
            case false:
                WordViewTittle.text = "Amphibian";
                WordViewText.text = "<size=30>" + "Amphibian 兩棲類動物" + "</size>" + "\n" + "\n" + "Description: A cold-blooded animal, such as a frog, that lives both on land and in water but must produce its eggs in water." + "\n" + "Sentence: In contrast to some species, amphibian are unable to produce thermal energy through their metabolic activity.";
                WordView.SetActive(true);            
                openandclose = true;
                break;

            case true:
                WordView.SetActive(false);
                openandclose = false;
                break;
            default:

                break;
        }
    }
    public void CloseView()
    {
        openandclose = false;
        WordView.SetActive(false);
        //這裡最好要加入一個行為 單字卡
    }

}
