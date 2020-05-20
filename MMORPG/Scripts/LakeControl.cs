using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;

public class LakeControl : MonoBehaviour
{
    public bool ShowHPLow = false;
    public Flowchart Serene_Flowchart;
    public Flowchart NPC2_Mission_Flowchart;
    public Flowchart NPC1_Mission_Flowchart;
    public Flowchart NPC3_Mission_Flowchart;
    private string Buy_HP_Url = "http://140.115.126.160:3000/BuyHP?account=";//"http://140.115.126.160/WordofWorld/BuyHP.php"
    // public GUI視窗
    public int windowWidth = 400;   //設定離開視窗大小
    public int windowHight = 150;
    public bool[] isPick = new bool[14];

    // private 設定 GUL 視窗背景
    Rect windowRect;

    //設定Fungus裡面的數值以及存檔
    #region
    public int setfungusSereneAnswertime // Serene 設定值給fungus
    {
        get { return Serene_Flowchart.GetIntegerVariable("SereneAnswertime"); }
        set { Serene_Flowchart.SetIntegerVariable("SereneAnswertime", value); }
    }
    public string SereneMission //抓fuguns裡面的值
    {
        get { return NPC2_Mission_Flowchart.GetStringVariable("Mission_Serene"); } //回傳值
        set { NPC2_Mission_Flowchart.SetStringVariable("Mission_Serene", value); }
    }
    //--------------------------------------------------------------------------------------

    public Flowchart Thoughtful_Flowchart;
    public int setfungusThoughtfulAnswertime // 設定值給fungus
    {
        get { return Thoughtful_Flowchart.GetIntegerVariable("ThoughtfulAnswertime"); }
        set { Thoughtful_Flowchart.SetIntegerVariable("ThoughtfulAnswertime", value); }
    }
    public string ThoughtfulMission //抓fuguns裡面的值
    {
        get { return NPC1_Mission_Flowchart.GetStringVariable("Mission_Thoughtful1"); }
        set { NPC1_Mission_Flowchart.SetStringVariable("Mission_Thoughtful1", value); }
    }
    //--------------------------------------------------------------------------------------

    public Flowchart Subsidy_Flowchart;
    public int setfungusSubsidyAnswertime // 設定值給fungus
    {
        get { return Subsidy_Flowchart.GetIntegerVariable("SubsidyAnswertime"); }
        set { Subsidy_Flowchart.SetIntegerVariable("SubsidyAnswertime", value); }
    }
    public string SubsidyMission //抓fuguns裡面的值
    {
        get { return NPC3_Mission_Flowchart.GetStringVariable("Mission_Subsidy"); }
        set { NPC3_Mission_Flowchart.SetStringVariable("Mission_Subsidy", value); }

    }
    //--------------------------------------------------------------------------------------

    public Flowchart Purification_Flowchart;
    public int setfungusPurificationAnswertime // 設定值給fungus
    {
        get { return Purification_Flowchart.GetIntegerVariable("PurificationAnswertime"); }
        set { Purification_Flowchart.SetIntegerVariable("PurificationAnswertime", value); }
    }
    public string PurificationMission //抓fuguns裡面的值
    {
        get { return Purification_Flowchart.GetStringVariable("Mission_Purification"); }
        set { Purification_Flowchart.SetStringVariable("Mission_Purification", value); }

    }
    //--------------------------------------------------------------------------------------

    public Flowchart Detention_Flowchart;
    public int setfungusDetentionAnswertime // 設定值給fungus
    {
        get { return Detention_Flowchart.GetIntegerVariable("DetentionAnswertime"); }
        set { Detention_Flowchart.SetIntegerVariable("DetentionAnswertime", value); }
    }
    public string DetentionMission //抓fuguns裡面的值
    {
        get { return Detention_Flowchart.GetStringVariable("Mission_Detention"); } //指定到對應的欄位
        set { Detention_Flowchart.SetStringVariable("Mission_Detention", value); }
    }
    //--------------------------------------------------------------------------------------

    public Flowchart Beautify_Flowchart;
    public int setfungusBeautifyAnswertime // 設定值給fungus
    {
        get { return Beautify_Flowchart.GetIntegerVariable("BeautifyAnswertime"); }
        set { Beautify_Flowchart.SetIntegerVariable("BeautifyAnswertime", value); }
    }
    public string BeautifyMission //抓fuguns裡面的值
    {
        get { return Beautify_Flowchart.GetStringVariable("Mission_Beautify"); } //指定到對應的欄位
        set { Beautify_Flowchart.SetStringVariable("Mission_Beautify", value); }

    }
    //--------------------------------------------------------------------------------------

    public Flowchart Drain_Flowchart;
    public int setfungusDrainAnswertime // 設定值給fungus
    {
        get { return Drain_Flowchart.GetIntegerVariable("DrainAnswertime"); }
        set { Drain_Flowchart.SetIntegerVariable("DrainAnswertime", value); }
    }
    public string DrainMission //抓fuguns裡面的值
    {
        get { return Drain_Flowchart.GetStringVariable("Mission_Drain"); } //指定到對應的欄位
        set { Drain_Flowchart.SetStringVariable("Mission_Drain", value); }
    }
    //--------------------------------------------------------------------------------------

    public Flowchart Concentration_Flowchart;
    public int setfungusConcentrationAnswertime // 設定值給fungus
    {
        get { return Concentration_Flowchart.GetIntegerVariable("ConcentrationAnswertime"); }
        set { Concentration_Flowchart.SetIntegerVariable("ConcentrationAnswertime", value); }
    }
    public string ConcerntrationMission //抓fuguns裡面的值
    {
        get { return Concentration_Flowchart.GetStringVariable("Mission_Concerntration"); } //指定到對應的欄位
        set { Concentration_Flowchart.SetStringVariable("Mission_Concerntration", value); }
    }
    //--------------------------------------------------------------------------------------

    public Flowchart Ecologicalcorridors_Flowchart;
    public int setfungusEcologicalcorridorsAnswertime // 設定值給fungus
    {
        get { return Ecologicalcorridors_Flowchart.GetIntegerVariable("EcologicalcorridorsAnswertime"); }
        set { Ecologicalcorridors_Flowchart.SetIntegerVariable("EcologicalcorridorsAnswertime", value); }
    }
    public string EcologicalcorridorsMission //抓fuguns裡面的值
    {
        get { return Ecologicalcorridors_Flowchart.GetStringVariable("Mission_Ecological_corridors"); } //指定到對應的欄位
        set { Ecologicalcorridors_Flowchart.SetStringVariable("Mission_Ecological_corridors", value); }

    }
    //--------------------------------------------------------------------------------------

    public Flowchart Picturesque_Flowchart;
    public int setfungusPicturesqueAnswertime // 設定值給fungus
    {
        get { return Picturesque_Flowchart.GetIntegerVariable("PicturesqueAnswertime"); }
        set { Picturesque_Flowchart.SetIntegerVariable("PicturesqueAnswertime", value); }
    }
    public string PicturesqueMission //抓fuguns裡面的值
    {
        get { return Picturesque_Flowchart.GetStringVariable("Mission_Picturesque"); } //指定到對應的欄位
        set { Picturesque_Flowchart.SetStringVariable("Mission_Picturesque", value); }
    }
    //--------------------------------------------------------------------------------------

    public Flowchart Aquatic_Flowchart;
    public int setfungusAquaticAnswertime // 設定值給fungus
    {
        get { return Aquatic_Flowchart.GetIntegerVariable("AquaticAnswertime"); }
        set { Aquatic_Flowchart.SetIntegerVariable("AquaticAnswertime", value); }
    }
    public string AquaticMission //抓fuguns裡面的值
    {
        get { return Aquatic_Flowchart.GetStringVariable("Mission_Aquatic"); } //指定到對應的欄位
        set { Aquatic_Flowchart.SetStringVariable("Mission_Aquatic", value); }
    }
    //--------------------------------------------------------------------------------------

    public Flowchart landscaping_Flowchart;
    public int setfunguslandscapingAnswertime // 設定值給fungus
    {
        get { return landscaping_Flowchart.GetIntegerVariable("landscapingAnswertime"); }
        set { landscaping_Flowchart.SetIntegerVariable("landscapingAnswertime", value); }
    }
    public string LandscapingMission //抓fuguns裡面的值
    {
        get { return landscaping_Flowchart.GetStringVariable("Mission_Landscaping"); } //指定到對應的欄位
        set { landscaping_Flowchart.SetStringVariable("Mission_Landscaping", value); }
    }
    //--------------------------------------------------------------------------------------

    public Flowchart Biodiversity_Flowchart;
    public int setfungusBiodiversityAnswertime // 設定值給fungus
    {
        get { return Biodiversity_Flowchart.GetIntegerVariable("BiodiversityAnswertime"); }
        set { Biodiversity_Flowchart.SetIntegerVariable("BiodiversityAnswertime", value); }
    }
    public string BiodiversityMission //抓fuguns裡面的值
    {
        get { return Biodiversity_Flowchart.GetStringVariable("Mission_Biodiversity"); } //指定到對應的欄位
        set { Biodiversity_Flowchart.SetStringVariable("Mission_Biodiversity", value); }
    }
    //--------------------------------------------------------------------------------------

    public Flowchart Amphibian_Flowchart;
    public int setfungusAmphibianAnswertime // 設定值給fungus
    {
        get { return Amphibian_Flowchart.GetIntegerVariable("AmphibianAnswertime"); }
        set { Amphibian_Flowchart.SetIntegerVariable("AmphibianAnswertime", value); }
    }
    public string AmphibianMission //抓fuguns裡面的值
    {
        get { return Amphibian_Flowchart.GetStringVariable("Mission_Amphibian"); } //指定到對應的欄位
        set { Amphibian_Flowchart.SetStringVariable("Mission_Amphibian", value); }
    }
    public int ReviewQuestion //抓fuguns裡面的值
    {
        get { return Amphibian_Flowchart.GetIntegerVariable("Level2QNum"); } //指定到對應的欄位
        set { Amphibian_Flowchart.SetIntegerVariable("Level2QNum", value); }
    }
    

    //--------------------------------------------------------------------------------------
    #endregion
    //設定Fungus裡面的數值以及存檔

    //設定複習任務存檔部分
    #region
    public static Flowchart MissionReview_Flowchart;
    public static int Serene_Cyclops //抓fuguns 怪物數量的值
    {
        get { return MissionReview_Flowchart.GetIntegerVariable("Serene_Cyclops"); } //指定到對應的欄位
        set { MissionReview_Flowchart.SetIntegerVariable("Serene_Cyclops", value); }
    }
    public static bool SereneReward //抓fuguns 怪物數量的值
    {
        get { return MissionReview_Flowchart.GetBooleanVariable("SereneReward"); } //指定到對應的欄位
        set { MissionReview_Flowchart.SetBooleanVariable("SereneReward", value); }
    }
    public static int Thoughtfu_Crab //抓fuguns 怪物數量的值
    {
        get { return MissionReview_Flowchart.GetIntegerVariable("Thoughtfu_Crab"); } //指定到對應的欄位
        set { MissionReview_Flowchart.SetIntegerVariable("Thoughtfu_Crab", value); }
    }
    public static bool ThoughtfulReward //抓fuguns 怪物數量的值
    {
        get { return MissionReview_Flowchart.GetBooleanVariable("ThoughtfulReward"); } //指定到對應的欄位
        set { MissionReview_Flowchart.SetBooleanVariable("ThoughtfulReward", value); }
    }
    public static int Subsidy_Mummy //抓fuguns 怪物數量的值
    {
        get { return MissionReview_Flowchart.GetIntegerVariable("Subsidy_Mummy"); } //指定到對應的欄位
        set { MissionReview_Flowchart.SetIntegerVariable("Subsidy_Mummy", value); }
    }
    public static bool SubsidyReward //抓fuguns 怪物數量的值
    {
        get { return MissionReview_Flowchart.GetBooleanVariable("SubsidyReward"); } //指定到對應的欄位
        set { MissionReview_Flowchart.SetBooleanVariable("SubsidyReward", value); }
    }
    public static int Purification_Bunny //抓fuguns 怪物數量的值
    {
        get { return MissionReview_Flowchart.GetIntegerVariable("Purification_Bunny"); } //指定到對應的欄位
        set { MissionReview_Flowchart.SetIntegerVariable("Purification_Bunny", value); }
    }
    public static bool PurificationReward //抓fuguns 怪物數量的值
    {
        get { return MissionReview_Flowchart.GetBooleanVariable("PurificationReward"); } //指定到對應的欄位
        set { MissionReview_Flowchart.SetBooleanVariable("PurificationReward", value); }
    }
    public static int Detention_Rabbit //抓fuguns 怪物數量的值
    {
        get { return MissionReview_Flowchart.GetIntegerVariable("Detention_Rabbit"); } //指定到對應的欄位
        set { MissionReview_Flowchart.SetIntegerVariable("Detention_Rabbit", value); }
    }
    public static bool DetentionReward //抓fuguns 怪物數量的值
    {
        get { return MissionReview_Flowchart.GetBooleanVariable("DetentionReward"); } //指定到對應的欄位
        set { MissionReview_Flowchart.SetBooleanVariable("DetentionReward", value); }
    }
    public static int Beautify_Wolfrider //抓fuguns 怪物數量的值
    {
        get { return MissionReview_Flowchart.GetIntegerVariable("Beautify_Wolfrider"); } //指定到對應的欄位
        set { MissionReview_Flowchart.SetIntegerVariable("Beautify_Wolfrider", value); }
    }
    public static bool BeautifyReward //抓fuguns 怪物數量的值
    {
        get { return MissionReview_Flowchart.GetBooleanVariable("BeautifyReward"); } //指定到對應的欄位
        set { MissionReview_Flowchart.SetBooleanVariable("BeautifyReward", value); }
    }
    public static int Drain_Dwarf //抓fuguns 怪物數量的值
    {
        get { return MissionReview_Flowchart.GetIntegerVariable("Drain_Dwarf"); } //指定到對應的欄位
        set { MissionReview_Flowchart.SetIntegerVariable("Drain_Dwarf", value); }
    }
    public static bool DrainReward //抓fuguns 怪物數量的值
    {
        get { return MissionReview_Flowchart.GetBooleanVariable("DrainReward"); } //指定到對應的欄位
        set { MissionReview_Flowchart.SetBooleanVariable("DrainReward", value); }
    }
    public static int Concentration_Mushroom //抓fuguns 怪物數量的值
    {
        get { return MissionReview_Flowchart.GetIntegerVariable("Concentration_Mushroom"); } //指定到對應的欄位
        set { MissionReview_Flowchart.SetIntegerVariable("Concentration_Mushroom", value); }
    }
    public static bool ConcentrationReward //抓fuguns 怪物數量的值
    {
        get { return MissionReview_Flowchart.GetBooleanVariable("ConcentrationReward"); } //指定到對應的欄位
        set { MissionReview_Flowchart.SetBooleanVariable("ConcentrationReward", value); }
    }
    public static int Ecologicalcorridors_Devil //抓fuguns 怪物數量的值
    {
        get { return MissionReview_Flowchart.GetIntegerVariable("Ecologicalcorridors_Devil"); } //指定到對應的欄位
        set { MissionReview_Flowchart.SetIntegerVariable("Ecologicalcorridors_Devil", value); }
    }
    public static bool Ecological_corridorsReward //抓fuguns 怪物數量的值
    {
        get { return MissionReview_Flowchart.GetBooleanVariable("Ecological_corridorsReward"); } //指定到對應的欄位
        set { MissionReview_Flowchart.SetBooleanVariable("Ecological_corridorsReward", value); }
    }
    public static int Picturesque_Bat //抓fuguns 怪物數量的值
    {
        get { return MissionReview_Flowchart.GetIntegerVariable("Picturesque_Bat"); } //指定到對應的欄位
        set { MissionReview_Flowchart.SetIntegerVariable("Picturesque_Bat", value); }
    }
    public static bool PicturesqueReward //抓fuguns 怪物數量的值
    {
        get { return MissionReview_Flowchart.GetBooleanVariable("PicturesqueReward"); } //指定到對應的欄位
        set { MissionReview_Flowchart.SetBooleanVariable("PicturesqueReward", value); }
    }
    public static int Aquatic_Slime //抓fuguns 怪物數量的值
    {
        get { return MissionReview_Flowchart.GetIntegerVariable("Aquatic_Slime"); } //指定到對應的欄位
        set { MissionReview_Flowchart.SetIntegerVariable("Aquatic_Slime", value); }
    }
    public static bool AquaticReward //抓fuguns 怪物數量的值
    {
        get { return MissionReview_Flowchart.GetBooleanVariable("AquaticReward"); } //指定到對應的欄位
        set { MissionReview_Flowchart.SetBooleanVariable("AquaticReward", value); }
    }
    public static int Landscaping_StoneMonster //抓fuguns 怪物數量的值
    {
        get { return MissionReview_Flowchart.GetIntegerVariable("Landscaping_StoneMonster"); } //指定到對應的欄位
        set { MissionReview_Flowchart.SetIntegerVariable("Landscaping_StoneMonster", value); }
    }
    public static bool LandscapingReward //抓fuguns 怪物數量的值
    {
        get { return MissionReview_Flowchart.GetBooleanVariable("LandscapingReward"); } //指定到對應的欄位
        set { MissionReview_Flowchart.SetBooleanVariable("LandscapingReward", value); }
    }
    public static int Biodiversity_Ghost //抓fuguns 怪物數量的值
    {
        get { return MissionReview_Flowchart.GetIntegerVariable("Biodiversity_Ghost"); } //指定到對應的欄位
        set { MissionReview_Flowchart.SetIntegerVariable("Biodiversity_Ghost", value); }
    }
    public static bool BiodiversityReward //抓fuguns 怪物數量的值
    {
        get { return MissionReview_Flowchart.GetBooleanVariable("BiodiversityReward"); } //指定到對應的欄位
        set { MissionReview_Flowchart.SetBooleanVariable("BiodiversityReward", value); }
    }
    public static int Amphibian_StoneMan //抓fuguns 怪物數量的值
    {
        get { return MissionReview_Flowchart.GetIntegerVariable("Amphibian_StoneMan"); } //指定到對應的欄位
        set { MissionReview_Flowchart.SetIntegerVariable("Amphibian_StoneMan", value); }
    }
    public static bool AmphibianReward //抓fuguns 怪物數量的值
    {
        get { return MissionReview_Flowchart.GetBooleanVariable("AmphibianReward"); } //指定到對應的欄位
        set { MissionReview_Flowchart.SetBooleanVariable("AmphibianReward", value); }
    }
    #endregion
    //

    //對話管理
    public static Flowchart DialogControl;

    public static bool IsTalking
    {
        get { return DialogControl.GetBooleanVariable("IsTalking"); }
    }
    //對話管理

    public void addEXP()//增加經驗值 每個任務完成
    {
        if (EXPscripts.EXP <= 100)
        {
            EXPscripts.EXP += 39; //完成遊戲的任務+17
        }
    }
    public void addSereneMoney()//獲得金幣

    {
        if (setfungusSereneAnswertime > 0)
        {
            switch (setfungusSereneAnswertime)
            {
                case 1:
                    MoneyScript.Money += 5; //一次就答對                                                 
                    break;
                case 2:
                    MoneyScript.Money += 4; //二次就答對                                    
                    break;
                case 3:
                    MoneyScript.Money += 3; //三次就答對                                  
                    break;
                case 4:
                    MoneyScript.Money += 2; //四次就答對                                  
                    break;
                case 5:
                    MoneyScript.Money += 1; //五次就答對                                  
                    break;
                default:                   
                    break;
            }
            Debug.Log("Serene作答次數是" + setfungusSereneAnswertime + "次");
        }
    }
    public void addThoughtfulMoney()//獲得金幣
    {
        if (setfungusThoughtfulAnswertime > 0)
        {
            switch (setfungusThoughtfulAnswertime)
            {
                case 1:
                    MoneyScript.Money += 5; //一次就答對                                                 
                    break;
                case 2:
                    MoneyScript.Money += 4; //二次就答對                                    
                    break;
                case 3:
                    MoneyScript.Money += 3; //三次就答對                                  
                    break;
                case 4:
                    MoneyScript.Money += 2; //四次就答對                                  
                    break;
                case 5:
                    MoneyScript.Money += 1; //五次就答對                                  
                    break;
                default:
                    break;
            }
        }
    }
    public void addSubsidyMoney()//獲得金幣
    {
        if (setfungusSubsidyAnswertime > 0)
        {
            switch (setfungusSubsidyAnswertime)
            {
                case 1:
                    MoneyScript.Money += 5; //一次就答對                                                 
                    break;
                case 2:
                    MoneyScript.Money += 4; //二次就答對                                    
                    break;
                case 3:
                    MoneyScript.Money += 3; //三次就答對                                  
                    break;
                case 4:
                    MoneyScript.Money += 2; //四次就答對                                  
                    break;
                case 5:
                    MoneyScript.Money += 1; //五次就答對                                  
                    break;
                default:
                    break;
            }
        }
    }
    public void addPurificationMoney()//獲得金幣
    {
        if (setfungusPurificationAnswertime > 0)
        {
            switch (setfungusPurificationAnswertime)
            {
                case 1:
                    MoneyScript.Money += 5; //一次就答對                                                 
                    break;
                case 2:
                    MoneyScript.Money += 4; //二次就答對                                    
                    break;
                case 3:
                    MoneyScript.Money += 3; //三次就答對                                  
                    break;
                case 4:
                    MoneyScript.Money += 2; //四次就答對                                  
                    break;
                case 5:
                    MoneyScript.Money += 1; //五次就答對                                  
                    break;
                default:
                    break;
            }
            Debug.Log("Purification作答次數是" + setfungusPurificationAnswertime + "次");
        }
    }
    public void addDetentionMoney()//獲得金幣
    {
        if (setfungusDetentionAnswertime > 0)
        {
            switch (setfungusDetentionAnswertime)
            {
                case 1:
                    MoneyScript.Money += 5; //一次就答對                                                 
                    break;
                case 2:
                    MoneyScript.Money += 4; //二次就答對                                    
                    break;
                case 3:
                    MoneyScript.Money += 3; //三次就答對                                  
                    break;
                case 4:
                    MoneyScript.Money += 2; //四次就答對                                  
                    break;
                case 5:
                    MoneyScript.Money += 1; //五次就答對                                  
                    break;
                default:
                    break;
            }
            Debug.Log("Detention作答次數是" + setfungusDetentionAnswertime + "次");
        }
    } //只有兩個選擇
    public void addBeautifyMoney()//獲得金幣
    {
        if (setfungusBeautifyAnswertime > 0)
        {
            switch (setfungusBeautifyAnswertime)
            {
                case 1:
                    MoneyScript.Money += 5; //一次就答對                                                 
                    break;
                case 2:
                    MoneyScript.Money += 4; //二次就答對                                    
                    break;
                case 3:
                    MoneyScript.Money += 3; //三次就答對                                  
                    break;
                case 4:
                    MoneyScript.Money += 2; //四次就答對                                  
                    break;
                case 5:
                    MoneyScript.Money += 1; //五次就答對                                  
                    break;
                default:
                    break;
            }
            Debug.Log("Beautify作答次數是" + setfungusBeautifyAnswertime + "次");
        }
    }  
    //只有兩個選擇
    public void addDrainMoney()//獲得金幣        //只有兩個選擇
    {
        if (setfungusDrainAnswertime > 0)
        {
            switch (setfungusDrainAnswertime)
            {
                case 1:
                    MoneyScript.Money += 5; //一次就答對                                                 
                    break;
                case 2:
                    MoneyScript.Money += 4; //二次就答對                                    
                    break;
                case 3:
                    MoneyScript.Money += 3; //三次就答對                                  
                    break;
                case 4:
                    MoneyScript.Money += 2; //四次就答對                                  
                    break;
                case 5:
                    MoneyScript.Money += 1; //五次就答對                                  
                    break;
                default:
                    break;
            }
            Debug.Log("Drain作答次數是" + setfungusDrainAnswertime + "次");
        }
    }
    public void addConcentrationMoney()//獲得金幣  //只有兩個選擇
    {
        if (setfungusConcentrationAnswertime > 0)
        {
            switch (setfungusConcentrationAnswertime)
            {
                case 1:
                    MoneyScript.Money += 5; //一次就答對                                                 
                    break;
                case 2:
                    MoneyScript.Money += 4; //二次就答對                                    
                    break;
                case 3:
                    MoneyScript.Money += 3; //三次就答對                                  
                    break;
                case 4:
                    MoneyScript.Money += 2; //四次就答對                                  
                    break;
                case 5:
                    MoneyScript.Money += 1; //五次就答對                                  
                    break;
                default:
                    break;
            }
            Debug.Log("Concentration作答次數是" + setfungusConcentrationAnswertime + "次");
        }
    }
    public void addEcologicalcorridorsMoney()//獲得金幣
    {
        if (setfungusEcologicalcorridorsAnswertime > 0)
        {
            switch (setfungusEcologicalcorridorsAnswertime)
            {
                case 1:
                    MoneyScript.Money += 5; //一次就答對                                                 
                    break;
                case 2:
                    MoneyScript.Money += 4; //二次就答對                                    
                    break;
                case 3:
                    MoneyScript.Money += 3; //三次就答對                                  
                    break;
                case 4:
                    MoneyScript.Money += 2; //四次就答對                                  
                    break;
                case 5:
                    MoneyScript.Money += 1; //五次就答對                                  
                    break;
                default:
                    break;
            }
        }
        Debug.Log("Ecologicalcorridors作答次數是" + setfungusEcologicalcorridorsAnswertime + "次");
    }
    public void addPicturesqueMoney()//獲得金幣
    {
        if (setfungusPicturesqueAnswertime > 0)
        {
            switch (setfungusPicturesqueAnswertime)
            {
                case 1:
                    MoneyScript.Money += 5; //一次就答對                                                 
                    break;
                case 2:
                    MoneyScript.Money += 4; //二次就答對                                    
                    break;
                case 3:
                    MoneyScript.Money += 3; //三次就答對                                  
                    break;
                case 4:
                    MoneyScript.Money += 2; //四次就答對                                  
                    break;
                case 5:
                    MoneyScript.Money += 1; //五次就答對                                  
                    break;
                default:
                    break;
            }
        }
        Debug.Log("Picturesque作答次數是" + setfungusPicturesqueAnswertime + "次");
    }
    public void addAquaticMoney()//獲得金幣
    {
        if (setfungusAquaticAnswertime > 0)
        {
            switch (setfungusAquaticAnswertime)
            {
                case 1:
                    MoneyScript.Money += 5; //一次就答對                                                 
                    break;
                case 2:
                    MoneyScript.Money += 4; //二次就答對                                    
                    break;
                case 3:
                    MoneyScript.Money += 3; //三次就答對                                  
                    break;
                case 4:
                    MoneyScript.Money += 2; //四次就答對                                  
                    break;
                case 5:
                    MoneyScript.Money += 1; //五次就答對                                  
                    break;
                default:
                    break;
            }
        }
        Debug.Log("Aquatic作答次數是" + setfungusAquaticAnswertime + "次");
    }
    public void addlandscapingMoney()//獲得金幣
    {
        if (setfunguslandscapingAnswertime > 0)
        {
            switch (setfunguslandscapingAnswertime)
            {
                case 1:
                    MoneyScript.Money += 5; //一次就答對                                                 
                    break;
                case 2:
                    MoneyScript.Money += 4; //二次就答對                                    
                    break;
                case 3:
                    MoneyScript.Money += 3; //三次就答對                                  
                    break;
                case 4:
                    MoneyScript.Money += 2; //四次就答對                                  
                    break;
                case 5:
                    MoneyScript.Money += 1; //五次就答對                                  
                    break;
                default:
                    break;
            }
        }
        Debug.Log("Landscaoing作答次數是" + setfunguslandscapingAnswertime + "次");
    }
    public void addBiodiversityMoney()//獲得金幣
    {
        if (setfungusBiodiversityAnswertime > 0)
        {
            switch (setfungusBiodiversityAnswertime)
            {
                case 1:
                    MoneyScript.Money += 5; //一次就答對                                                 
                    break;
                case 2:
                    MoneyScript.Money += 4; //二次就答對                                    
                    break;
                case 3:
                    MoneyScript.Money += 3; //三次就答對                                  
                    break;
                case 4:
                    MoneyScript.Money += 2; //四次就答對                                  
                    break;
                case 5:
                    MoneyScript.Money += 1; //五次就答對                                  
                    break;
                default:
                    break;
            }
        }
        Debug.Log("Biodiversity作答次數是" + setfungusBiodiversityAnswertime + "次");
    }
    public void addAmphibianMoney()//獲得金幣
    {
        if (setfungusAmphibianAnswertime > 0)
        {
            switch (setfungusAmphibianAnswertime)
            {
                case 1:
                    MoneyScript.Money += 5; //一次就答對                                                 
                    break;
                case 2:
                    MoneyScript.Money += 4; //二次就答對                                    
                    break;
                case 3:
                    MoneyScript.Money += 3; //三次就答對                                  
                    break;
                case 4:
                    MoneyScript.Money += 2; //四次就答對                                  
                    break;
                case 5:
                    MoneyScript.Money += 1; //五次就答對                                  
                    break;
                default:
                    break;
            }
        }
        Debug.Log("Amphibian作答次數是" + setfungusAmphibianAnswertime + "次");
    }


    public void RightAnswer() //Level 2 的答對
    {
        MoneyScript.Money += 5;
    }
    public void WrongAnswer() //Level 2 的答錯
    {
        HPscripts.HP -= 15 - int.Parse(BagViewScript.PlayerDefend.text);

    }

    /// <summary>
    /// 在這邊紀錄選對選錯物品次數
    /// </summary>
    public void Right_WrongAnswer()
    {
        HPscripts.HP -= 10 - int.Parse(BagViewScript.PlayerDefend.text); //選到對的物品但是選錯答案扣血量-5

        WWWForm Form = new WWWForm();
        WWW WWW;
        WWW = new WWW(AllFunctiosTime.LearningMissionVocabulary + LoginScript.Account + "&status=PickWrongObject" + "&wrong=1");
        Debug.Log("紀錄選錯次數");
        if (WWW.error != null)
        {
            Debug.Log("紀錄選錯" + WWW.error);
            Debug.LogError("寫入錯誤");
        }
    }
    public void Wrong_RightAnswer()
    {
        HPscripts.HP -= 15 - int.Parse(BagViewScript.PlayerDefend.text); //選到對的物品但是選錯答案扣血量-10

        WWWForm Form = new WWWForm();
        WWW WWW;
        WWW = new WWW(AllFunctiosTime.LearningMissionVocabulary + LoginScript.Account + "&status=PickWrongObject" + "&wrong=1");
        Debug.Log("紀錄選錯次數");
        if (WWW.error != null)
        {
            Debug.Log("紀錄選錯" + WWW.error);
            Debug.LogError("寫入錯誤");
        }
    }
    public void Wrong_WrongAnswer()
    {
        HPscripts.HP -= 15; //未用到

    }

    public void PickCorrectObject()
    {      
        WWWForm Form = new WWWForm();
        WWW WWW;
        WWW = new WWW(AllFunctiosTime.LearningMissionVocabulary + LoginScript.Account + "&status=PickCorrectObject" + "&correct=1");
        Debug.Log("紀錄正確次數");
        if (WWW.error != null)
        {
            Debug.Log("紀錄選對" + WWW.error);
            Debug.LogError("寫入錯誤");
        }
    }


    /// <summary>
    /// 學習任務整個失敗
    /// </summary>
    public void RecordLearningMissionFail()
    {    
        WWW learningmissionfail = new WWW(AllFunctiosTime.LearningMissionFailURL);
        if (learningmissionfail.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
        Debug.Log("記錄學習任務整個失敗");
    }


public void HPbelowzero() //萬一血量低於0
    {
        if (HPscripts.HP <= 10)
        {
            ShowHPLow = true;
            //停止動作
        }
        else
        {
            ShowHPLow = false;
            //可以動作
        }
    }

    public void ShowSerene() //完成學習任務後
    {
            switch (TargetWordUIbutton.openandclose)
            {
                case false:
                    TargetWordUIbutton.WordViewTittle.text = "Serene";
                    TargetWordUIbutton.WordViewText.text = "<size=30>" + "Serene 寧靜的、祥和的" + "</size>" + "\n" + "\n" + "Description: Peaceful and calm." + "\n" + "Sentence: The girl’s face is serene and peaceful.";
                    TargetWordUIbutton.WordView.SetActive(true);
                    TargetWordUIbutton.openandclose = true;
                    TargetWordUIbutton.ActionSlot_Serene.interactable = true; //解鎖
                    TargetWordUIbutton.Serenelock.enabled = false; //大鎖圖示不見
                    TargetWordUIbutton.SereneText.enabled = true;  //單字文字出現
                    //TargetWordUIbutton.WordBadgeIconCopper.SetActive(true);//銅牌
                    //TargetWordUIbutton.WordBadgeIconGold.SetActive(false);//金牌
                break;
                case true:
                    TargetWordUIbutton.WordView.SetActive(false);
                    TargetWordUIbutton.openandclose = false;
                    break;
                default:

                    break;
            }
        }
    /*public void ShowSereneMeaning() //完成複習任務後
    {
        switch (TargetWordUIbutton.openandclose)
        {
            case false:
                TargetWordUIbutton.WordViewTittle.text = "Serene";
                TargetWordUIbutton.WordViewText.text = "<size=30>" + "Serene 寧靜的、祥和的" + "</size>" + "\n" + "\n" + "Description: Peaceful and calm." + "\n" + "Sentence: The girl’s face is serene and peaceful.";
                TargetWordUIbutton.WordView.SetActive(true);
                //TargetWordUIbutton.WordBadgeIconCopper.SetActive(false);
                //TargetWordUIbutton.WordBadgeIconGold.SetActive(true);
                TargetWordUIbutton.openandclose = true;
                TargetWordUIbutton.ActionSlot_Serene.interactable = true; //解鎖
                TargetWordUIbutton.Serenelock.enabled = false; //大鎖圖示不見
                TargetWordUIbutton.SereneText.enabled = true;  //單字文字出現
                //TargetWordUIbutton.WordBadgeIconCopper.SetActive(false);//銅牌
                //TargetWordUIbutton.WordBadgeIconGold.SetActive(true);//金牌
                break;
            case true:
                TargetWordUIbutton.WordView.SetActive(false);
                TargetWordUIbutton.openandclose = false;
                break;
            default:

                break;
        }
    }

    public void ShowThoughtfulMeaning()
    {
        switch (TargetWordUIbutton.openandclose)
        {
            case false:
                TargetWordUIbutton.WordViewTittle.text = "Thoughtful";
                TargetWordUIbutton.WordViewText.text = "<size=30>" + "Thoughtful 沉思的、替人著想的" + "</size>" + "\n" + "\n" + "Carefully considering things; quiet because you are thinking about something." + "\n" + "Sentence: He pondered over the matter, and fell into a thoughtful silence.";
                TargetWordUIbutton.WordView.SetActive(true);
                TargetWordUIbutton.openandclose = true;
                TargetWordUIbutton.ActionSlot_Thoughtful.interactable = true; //解鎖
                TargetWordUIbutton.Thoughtfullock.enabled = false; //大鎖圖示不見
                TargetWordUIbutton.ThoughtfulText.enabled = true;  //單字文字出現
                //TargetWordUIbutton.WordBadgeIconCopper.SetActive(false);//銅牌
                //TargetWordUIbutton.WordBadgeIconGold.SetActive(true);//金牌
                break;
            case true:
                TargetWordUIbutton.WordView.SetActive(false);
                TargetWordUIbutton.openandclose = false;
                break;
            default:

                break;
        }
    }
    */
    public void ShowThoughtful()
    {
        switch (TargetWordUIbutton.openandclose)
        {
            case false:
                TargetWordUIbutton.WordViewTittle.text = "Thoughtful";
                TargetWordUIbutton.WordViewText.text = "<size=30>" + "Thoughtful 沉思的、替人著想的" + "</size>" + "\n" + "\n" + "Description:Carefully considering things; quiet because you are thinking about something.";
                TargetWordUIbutton.WordView.SetActive(true);
                TargetWordUIbutton.openandclose = true;
                TargetWordUIbutton.ActionSlot_Thoughtful.interactable = true; //解鎖
                TargetWordUIbutton.Thoughtfullock.enabled = false; //大鎖圖示不見
                TargetWordUIbutton.ThoughtfulText.enabled = true;  //單字文字出現
                //TargetWordUIbutton.WordBadgeIconCopper.SetActive(true);//銅牌
                //TargetWordUIbutton.WordBadgeIconGold.SetActive(false);//金牌
                break;
            case true:
                TargetWordUIbutton.WordView.SetActive(false);
                TargetWordUIbutton.openandclose = false;
                break;
            default:

                break;
        }
    }

    /*public void ShowSubsidyMeaning()
    {
        switch (TargetWordUIbutton.openandclose)
        {
            case false:
                TargetWordUIbutton.WordViewTittle.text = "Subsidy";
                TargetWordUIbutton.WordViewText.text = "<size=30>" + "Subsidy 補助；補助金" + "</size>" + "\n" + "\n" + "Description: Paid by a government or other organization in order to help an industry or business, or to pay for a public service." + "\n" + "Sentence: The company received a substantial government subsidy, which will be used for constructing the new office building.";
                TargetWordUIbutton.WordView.SetActive(true);
                TargetWordUIbutton.openandclose = true;
                TargetWordUIbutton.ActionSlot_Subsidy.interactable = true; //解鎖
                TargetWordUIbutton.Subsidylock.enabled = false; //大鎖圖示不見
                TargetWordUIbutton.SubsidyText.enabled = true;  //單字文字出現
                //TargetWordUIbutton.WordBadgeIconCopper.SetActive(false);//銅牌
                //TargetWordUIbutton.WordBadgeIconGold.SetActive(true);//金牌
                break;
            case true:
                TargetWordUIbutton.WordView.SetActive(false);
                TargetWordUIbutton.openandclose = false;
                break;
            default:

                break;
        }
    }*/
    public void ShowSubsidy()
    {
        switch (TargetWordUIbutton.openandclose)
        {
            case false:
                TargetWordUIbutton.WordViewTittle.text = "Subsidy";
                TargetWordUIbutton.WordViewText.text = "<size=30>" + "Subsidy 補助；補助金" + "</size>" + "\n" + "\n" + "Description: Paid by a government or other organization in order to help an industry or business, or to pay for a public service." + "\n" + "Sentence: The company received a substantial government subsidy, which will be used for constructing the new office building.";
                TargetWordUIbutton.WordView.SetActive(true);
                TargetWordUIbutton.openandclose = true;
                TargetWordUIbutton.ActionSlot_Subsidy.interactable = true; //解鎖
                TargetWordUIbutton.Subsidylock.enabled = false; //大鎖圖示不見
                TargetWordUIbutton.SubsidyText.enabled = true;  //單字文字出現
                //TargetWordUIbutton.WordBadgeIconCopper.SetActive(true);//銅牌
                //TargetWordUIbutton.WordBadgeIconGold.SetActive(false);//金牌
                break;
            case true:
                TargetWordUIbutton.WordView.SetActive(false);
                TargetWordUIbutton.openandclose = false;
                break;
            default:

                break;
        }
    }

    /*public void ShowBeautifyMeaning()//Beautify 美化
    {
        switch (TargetWordUIbutton.openandclose)
        {
            case false:
                TargetWordUIbutton.WordViewTittle.text = "Beautify";
                TargetWordUIbutton.WordViewText.text = "<size=30>" + "Beautify 美化" + "</size>" + "\n" + "\n" + "Description: To improve the appearance of someone or something." + "\n" + "Sentence: My neighbors grow lots of plants to beautify their backyard.";
                TargetWordUIbutton.WordView.SetActive(true);
                TargetWordUIbutton.openandclose = true;
                TargetWordUIbutton.ActionSlot_Beautify.interactable = true; //解鎖
                TargetWordUIbutton.Beautifylock.enabled = false; //大鎖圖示不見
                TargetWordUIbutton.BeautifyText.enabled = true;  //單字文字出現
                //TargetWordUIbutton.WordBadgeIconCopper.SetActive(false);//銅牌
                //TargetWordUIbutton.WordBadgeIconGold.SetActive(true);//金牌
                break;
            case true:
                TargetWordUIbutton.WordView.SetActive(false);
                TargetWordUIbutton.openandclose = false;
                break;
            default:

                break;
        }
    }*/
    public void ShowBeautify()
    {
        switch (TargetWordUIbutton.openandclose)
        {
            case false:
                TargetWordUIbutton.WordViewTittle.text = "Beautify";
                TargetWordUIbutton.WordViewText.text = "<size=30>" + "Beautify 美化" + "</size>" + "\n" + "\n" + "Description: To improve the appearance of someone or something." + "\n" + "Sentence: My neighbors grow lots of plants to beautify their backyard.";
                TargetWordUIbutton.WordView.SetActive(true);
                TargetWordUIbutton.openandclose = true;
                TargetWordUIbutton.ActionSlot_Beautify.interactable = true; //解鎖
                TargetWordUIbutton.Beautifylock.enabled = false; //大鎖圖示不見
                TargetWordUIbutton.BeautifyText.enabled = true;  //單字文字出現
                //TargetWordUIbutton.WordBadgeIconCopper.SetActive(true);//銅牌
                //TargetWordUIbutton.WordBadgeIconGold.SetActive(false);//金牌
                break;
            case true:
                TargetWordUIbutton.WordView.SetActive(false);
                TargetWordUIbutton.openandclose = false;
                break;
            default:

                break;
        }
    }

    /*public void ShowPurificationMeaning()
    {
        switch (TargetWordUIbutton.openandclose)
        {
            case false:
                TargetWordUIbutton.WordViewTittle.text = "Purification";
                TargetWordUIbutton.WordViewText.text = "<size=30>" + "Purification 淨化" + "</size>" + "\n" + "\n" + "Description: The act of removing harmful substances from something." + "\n" + "Sentence:  I always bring water purification tablets when I go camping.";
                TargetWordUIbutton.WordView.SetActive(true);
                TargetWordUIbutton.openandclose = true;
                TargetWordUIbutton.ActionSlot_Purification.interactable = true; //解鎖
                TargetWordUIbutton.Purificationlock.enabled = false; //大鎖圖示不見
                TargetWordUIbutton.PurificationText.enabled = true;  //單字文字出現
                //TargetWordUIbutton.WordBadgeIconCopper.SetActive(false);//銅牌
                //TargetWordUIbutton.WordBadgeIconGold.SetActive(true);//金牌
                break;
            case true:
                TargetWordUIbutton.WordView.SetActive(false);
                TargetWordUIbutton.openandclose = false;
                break;
            default:

                break;
        }
    }*/
    public void ShowPurification()
    {
        switch (TargetWordUIbutton.openandclose)
        {
            case false:
                TargetWordUIbutton.WordViewTittle.text = "Purification";
                TargetWordUIbutton.WordViewText.text = "<size=30>" + "Purification 淨化" + "</size>" + "\n" + "\n" + "Description: The act of removing harmful substances from something." + "\n" + "Sentence:  I always bring water purification tablets when I go camping.";
                TargetWordUIbutton.WordView.SetActive(true);
                TargetWordUIbutton.openandclose = true;
                TargetWordUIbutton.ActionSlot_Purification.interactable = true; //解鎖
                TargetWordUIbutton.Purificationlock.enabled = false; //大鎖圖示不見
                TargetWordUIbutton.PurificationText.enabled = true;  //單字文字出現
                //TargetWordUIbutton.WordBadgeIconCopper.SetActive(true);//銅牌
                //TargetWordUIbutton.WordBadgeIconGold.SetActive(false);//金牌
                break;
            case true:
                TargetWordUIbutton.WordView.SetActive(false);
                TargetWordUIbutton.openandclose = false;
                break;
            default:

                break;
        }
    }

    /*public void ShowDrainMeaning()
    {
        switch (TargetWordUIbutton.openandclose)
        {
            case false:
                TargetWordUIbutton.WordViewTittle.text = "Drain";
                TargetWordUIbutton.WordViewText.text = "<size=30>" + "Drain 排水" + "</size>" + "\n" + "\n" + "Description: Cause the water or other liquid to run out." + "\n"  + "Sentence: This swimming pool is drained and cleaned every month.";
                TargetWordUIbutton.WordView.SetActive(true);
                TargetWordUIbutton.openandclose = true;
                TargetWordUIbutton.ActionSlot_Drain.interactable = true; //解鎖
                TargetWordUIbutton.Drainlock.enabled = false; //大鎖圖示不見
                TargetWordUIbutton.DrainText.enabled = true;  //單字文字出現
                //TargetWordUIbutton.WordBadgeIconCopper.SetActive(false);//銅牌
                //TargetWordUIbutton.WordBadgeIconGold.SetActive(true);//金牌
                break;
            case true:
                TargetWordUIbutton.WordView.SetActive(false);
                TargetWordUIbutton.openandclose = false;
                break;
            default:

                break;
        }
    }*/
    public void ShowDrain()
    {
        switch (TargetWordUIbutton.openandclose)
        {
            case false:
                TargetWordUIbutton.WordViewTittle.text = "Drain";
                TargetWordUIbutton.WordViewText.text = "<size=30>" + "Drain 排水" + "</size>" + "\n" + "\n" + "Description: Cause the water or other liquid to run out." + "\n" + "Sentence: This swimming pool is drained and cleaned every month.";
                TargetWordUIbutton.WordView.SetActive(true);
                TargetWordUIbutton.openandclose = true;
                TargetWordUIbutton.ActionSlot_Drain.interactable = true; //解鎖
                TargetWordUIbutton.Drainlock.enabled = false; //大鎖圖示不見
                TargetWordUIbutton.DrainText.enabled = true;  //單字文字出現
                //TargetWordUIbutton.WordBadgeIconCopper.SetActive(true);//銅牌
                //TargetWordUIbutton.WordBadgeIconGold.SetActive(false);//金牌
                break;
            case true:
                TargetWordUIbutton.WordView.SetActive(false);
                TargetWordUIbutton.openandclose = false;
                break;
            default:

                break;
        }
    }

    /*public void ShowConcerntrationMeaning()
    {
        switch (TargetWordUIbutton.openandclose)
        {
            case false:
                TargetWordUIbutton.WordViewTittle.text = "Concerntration";
                TargetWordUIbutton.WordViewText.text = "<size=30>" + "Concerntration 濃度" + "</size>" + "\n" + "\n" + "Description: The relative amount of a particular substance contained within a solution or mixture or in a particular volume of space." + "\n" + "Sentence: High concerntration of toxic elements were found in the polluted areas.";
                TargetWordUIbutton.WordView.SetActive(true);
                TargetWordUIbutton.openandclose = true;
                TargetWordUIbutton.ActionSlot_Concerntration.interactable = true; //解鎖
                TargetWordUIbutton.Concerntrationlock.enabled = false; //大鎖圖示不見
                TargetWordUIbutton.ConcerntrationText.enabled = true;  //單字文字出現
                //TargetWordUIbutton.WordBadgeIconCopper.SetActive(false);//銅牌
                //TargetWordUIbutton.WordBadgeIconGold.SetActive(true);//金牌
                break;
            case true:
                TargetWordUIbutton.WordView.SetActive(false);
                TargetWordUIbutton.openandclose = false;
                break;
            default:

                break;
        }
    }*/
    public void ShowConcerntration()
    {
        switch (TargetWordUIbutton.openandclose)
        {
            case false:
                TargetWordUIbutton.WordViewTittle.text = "Concerntration";
                TargetWordUIbutton.WordViewText.text = "<size=30>" + "Concerntration 濃度" + "</size>" + "\n" + "\n" + "Description: The relative amount of a particular substance contained within a solution or mixture or in a particular volume of space." + "\n" + "Sentence: High concerntration of toxic elements were found in the polluted areas.";
                TargetWordUIbutton.WordView.SetActive(true);
                TargetWordUIbutton.openandclose = true;
                TargetWordUIbutton.ActionSlot_Concerntration.interactable = true; //解鎖
                TargetWordUIbutton.Concerntrationlock.enabled = false; //大鎖圖示不見
                TargetWordUIbutton.ConcerntrationText.enabled = true;  //單字文字出現
                //TargetWordUIbutton.WordBadgeIconCopper.SetActive(true);//銅牌
                //TargetWordUIbutton.WordBadgeIconGold.SetActive(false);//金牌
                break;
            case true:
                TargetWordUIbutton.WordView.SetActive(false);
                TargetWordUIbutton.openandclose = false;
                break;
            default:

                break;
        }
    }

    /*public void ShowLandscapingMeaning()
    {
        switch (TargetWordUIbutton.openandclose)
        {
            case false:
                TargetWordUIbutton.WordViewTittle.text = "Landscaping";
                TargetWordUIbutton.WordViewText.text = "<size=30>" + "Landscaping 造景" + "</size>" + "\n" + "\n" + "Description: To improve the appearance of (an area of land, a highway, etc.), as by planting trees, or grass." + "\n" + "Sentence: This castle boasts of unique landscaping designs.";
                TargetWordUIbutton.WordView.SetActive(true);
                TargetWordUIbutton.openandclose = true;
                TargetWordUIbutton.ActionSlot_Landscaping.interactable = true; //解鎖
                TargetWordUIbutton.Landscapinglock.enabled = false; //大鎖圖示不見
                TargetWordUIbutton.LandscapingText.enabled = true;  //單字文字出現
                //TargetWordUIbutton.WordBadgeIconCopper.SetActive(false);//銅牌
                //TargetWordUIbutton.WordBadgeIconGold.SetActive(true);//金牌
                break;
            case true:
                TargetWordUIbutton.WordView.SetActive(false);
                TargetWordUIbutton.openandclose = false;
                break;
            default:

                break;
        }
    }*/
    public void ShowLandscaping()
    {
        switch (TargetWordUIbutton.openandclose)
        {
            case false:
                TargetWordUIbutton.WordViewTittle.text = "Landscaping";
                TargetWordUIbutton.WordViewText.text = "<size=30>" + "Landscaping 造景" + "</size>" + "\n" + "\n" + "Description: To improve the appearance of (an area of land, a highway, etc.), as by planting trees, or grass." + "\n" + "Sentence: This castle boasts of unique landscaping designs.";
                TargetWordUIbutton.WordView.SetActive(true);
                TargetWordUIbutton.openandclose = true;
                TargetWordUIbutton.ActionSlot_Landscaping.interactable = true; //解鎖
                TargetWordUIbutton.Landscapinglock.enabled = false; //大鎖圖示不見
                TargetWordUIbutton.LandscapingText.enabled = true;  //單字文字出現
                //TargetWordUIbutton.WordBadgeIconCopper.SetActive(true);//銅牌
                //TargetWordUIbutton.WordBadgeIconGold.SetActive(false);//金牌
                break;
            case true:
                TargetWordUIbutton.WordView.SetActive(false);
                TargetWordUIbutton.openandclose = false;
                break;
            default:

                break;
        }
    }

    /*public void ShowEologicalcorridorsMeaning()
    {
        switch (TargetWordUIbutton.openandclose)
        {
            case false:
                TargetWordUIbutton.WordViewTittle.text = "Eological corridors";
                TargetWordUIbutton.WordViewText.text = "<size=30>" + "Eological Corridors 生態走廊" + "</size>" + "\n" + "\n" + "Description: A functional zone of passage between several natural zones for a group of species dependent on a single environment." + "\n"  + "Sentence: Voluntary action by landowners, in cooperation with the park and the county, is helping to restrict small-lot subdivisions, maintain eological corridors, and minimize any harmful impact on the environment.";
                TargetWordUIbutton.WordView.SetActive(true);
                TargetWordUIbutton.openandclose = true;
                TargetWordUIbutton.ActionSlot_Eologicalcorridors.interactable = true; //解鎖
                TargetWordUIbutton.Eologicalcorridorslock.enabled = false; //大鎖圖示不見
                TargetWordUIbutton.EologicalcorridorsText.enabled = true;  //單字文字出現
                //TargetWordUIbutton.WordBadgeIconCopper.SetActive(false);//銅牌
                //TargetWordUIbutton.WordBadgeIconGold.SetActive(true);//金牌
                break;
            case true:
                TargetWordUIbutton.WordView.SetActive(false);
                TargetWordUIbutton.openandclose = false;
                break;
            default:

                break;
        }
    }*/
    public void ShowEologicalcorridors()
    {
        switch (TargetWordUIbutton.openandclose)
        {
            case false:
                TargetWordUIbutton.WordViewTittle.text = "Eological Corridors";
                TargetWordUIbutton.WordViewText.text = "<size=30>" + "Eological Corridors 生態走廊" + "</size>" + "\n" + "\n" + "Description: A functional zone of passage between several natural zones for a group of species dependent on a single environment." + "\n" + "Sentence: Voluntary action by landowners, in cooperation with the park and the county, is helping to restrict small-lot subdivisions, maintain eological corridors, and minimize any harmful impact on the environment.";
                TargetWordUIbutton.WordView.SetActive(true);
                TargetWordUIbutton.openandclose = true;
                TargetWordUIbutton.ActionSlot_Eologicalcorridors.interactable = true; //解鎖
                TargetWordUIbutton.Eologicalcorridorslock.enabled = false; //大鎖圖示不見
                TargetWordUIbutton.EologicalcorridorsText.enabled = true;  //單字文字出現
                //TargetWordUIbutton.WordBadgeIconCopper.SetActive(true);//銅牌
                //TargetWordUIbutton.WordBadgeIconGold.SetActive(false);//金牌
                break;
            case true:
                TargetWordUIbutton.WordView.SetActive(false);
                TargetWordUIbutton.openandclose = false;
                break;
            default:

                break;
        }
    }

    /*public void ShowPicturesqueMeaning()
    {
        switch (TargetWordUIbutton.openandclose)
        {
            case false:
                TargetWordUIbutton.WordViewTittle.text = "Picturesque";
                TargetWordUIbutton.WordViewText.text = "<size=30>" + "Picturesque 風景如畫的；圖畫般的；別具一格的" + " </size>" + "\n" + "\n" + "Description: Visually attractive, especially in a charming or pretty style, as if resembling or suitable for a painting." + "\n"  + "Sentence: New England is rightly noted for its picturesque country inns, friendly guest houses and pleasant bed and delicious food.";
                TargetWordUIbutton.WordView.SetActive(true);
                TargetWordUIbutton.openandclose = true;
                TargetWordUIbutton.ActionSlot_Picturesque.interactable = true; //解鎖
                TargetWordUIbutton.Picturesquelock.enabled = false; //大鎖圖示不見
                TargetWordUIbutton.PicturesqueText.enabled = true;  //單字文字出現
                //TargetWordUIbutton.WordBadgeIconCopper.SetActive(false);//銅牌
                //TargetWordUIbutton.WordBadgeIconGold.SetActive(true);//金牌
                break;
            case true:
                TargetWordUIbutton.WordView.SetActive(false);
                TargetWordUIbutton.openandclose = false;
                break;
            default:

                break;
        }
    }*/
    public void ShowPicturesque()
    {
        switch (TargetWordUIbutton.openandclose)
        {
            case false:
                TargetWordUIbutton.WordViewTittle.text = "Picturesque";
                TargetWordUIbutton.WordViewText.text = "<size=30>" + "Picturesque 風景如畫的；圖畫般的；別具一格的" + "</size>" + "\n" + "\n" + "Description: Visually attractive, especially in a charming or pretty style, as if resembling or suitable for a painting." + "\n" + "Sentence: New England is rightly noted for its picturesque country inns, friendly guest houses and pleasant bed and delicious food.";
                TargetWordUIbutton.WordView.SetActive(true);
                TargetWordUIbutton.openandclose = true;
                TargetWordUIbutton.ActionSlot_Picturesque.interactable = true; //解鎖
                TargetWordUIbutton.Picturesquelock.enabled = false; //大鎖圖示不見
                TargetWordUIbutton.PicturesqueText.enabled = true;  //單字文字出現
                //TargetWordUIbutton.WordBadgeIconCopper.SetActive(true);//銅牌
                //TargetWordUIbutton.WordBadgeIconGold.SetActive(false);//金牌
                break;
            case true:
                TargetWordUIbutton.WordView.SetActive(false);
                TargetWordUIbutton.openandclose = false;
                break;
            default:

                break;
        }
    }

    /*public void ShowDetentionMeaning()
    {
        switch (TargetWordUIbutton.openandclose)
        {
            case false:
                TargetWordUIbutton.WordViewTittle.text = "Detention";
                TargetWordUIbutton.WordViewText.text = "<size=30>" + "Detention 拘留、滯留" + "</size>" + "\n" + "\n" + "Description: Is a state when someone is arrested or put into prison, especially for political." + "\n"  + "Sentence: John was held in detention for 24 hours for drunk driving.";
                TargetWordUIbutton.WordView.SetActive(true);
                TargetWordUIbutton.openandclose = true;
                TargetWordUIbutton.ActionSlot_Detention.interactable = true; //解鎖
                TargetWordUIbutton.Detentionlock.enabled = false; //大鎖圖示不見
                TargetWordUIbutton.DetentionText.enabled = true;  //單字文字出現
                //TargetWordUIbutton.WordBadgeIconCopper.SetActive(false);//銅牌
                //TargetWordUIbutton.WordBadgeIconGold.SetActive(true);//金牌
                break;
            case true:
                TargetWordUIbutton.WordView.SetActive(false);
                TargetWordUIbutton.openandclose = false;
                break;
            default:

                break;
        }
    }*/
    public void ShowDetention()
    {
        switch (TargetWordUIbutton.openandclose)
        {
            case false:
                TargetWordUIbutton.WordViewTittle.text = "Detention";
                TargetWordUIbutton.WordViewText.text = "<size=30>" + "Detention 拘留、滯留" + "</size>" + "\n" + "\n" + "Description: Is a state when someone is arrested or put into prison, especially for political." + "\n" + "Sentence: John was held in detention for 24 hours for drunk driving.";
                TargetWordUIbutton.WordView.SetActive(true);
                TargetWordUIbutton.openandclose = true;
                TargetWordUIbutton.ActionSlot_Detention.interactable = true; //解鎖
                TargetWordUIbutton.Detentionlock.enabled = false; //大鎖圖示不見
                TargetWordUIbutton.DetentionText.enabled = true;  //單字文字出現
                //TargetWordUIbutton.WordBadgeIconCopper.SetActive(true);//銅牌
                //TargetWordUIbutton.WordBadgeIconGold.SetActive(false);//金牌
                break;
            case true:
                TargetWordUIbutton.WordView.SetActive(false);
                TargetWordUIbutton.openandclose = false;
                break;
            default:

                break;
        }
    }

    /*public void ShowBiodiversityMeaning()
    {
        switch (TargetWordUIbutton.openandclose)
        {
            case false:
                TargetWordUIbutton.WordViewTittle.text = "Biodiversity";
                TargetWordUIbutton.WordViewText.text = "<size=30>" + "Biodiversity 生物多樣性" + "</size>" + "\n" + "\n" + "Description: The variety of life in the world or in a particular area." + "\n" + "Sentence: The mining project threatens one of the world’s richest areas of biodiversity.";
                TargetWordUIbutton.WordView.SetActive(true);
                TargetWordUIbutton.openandclose = true;
                TargetWordUIbutton.ActionSlot_Biodiversity.interactable = true; //解鎖
                TargetWordUIbutton.Biodiversitylock.enabled = false; //大鎖圖示不見
                TargetWordUIbutton.BiodiversityText.enabled = true;  //單字文字出現
                //TargetWordUIbutton.WordBadgeIconCopper.SetActive(false);//銅牌
                //TargetWordUIbutton.WordBadgeIconGold.SetActive(true);//金牌
                break;
            case true:

                TargetWordUIbutton.WordView.SetActive(false);
                TargetWordUIbutton.openandclose = false;
                break;
            default:

                break;
        }
    }*/
    public void ShowBiodiversity()
    {
        switch (TargetWordUIbutton.openandclose)
        {
            case false:
                TargetWordUIbutton.WordViewTittle.text = "Biodiversity";
                TargetWordUIbutton.WordViewText.text = "<size=30>" + "Biodiversity 生物多樣性" + "</size>" + "\n" + "\n" + "Description: The variety of life in the world or in a particular area." + "\n" + "Sentence: The mining project threatens one of the world’s richest areas of biodiversity.";
                TargetWordUIbutton.WordView.SetActive(true);
                TargetWordUIbutton.openandclose = true;
                TargetWordUIbutton.ActionSlot_Biodiversity.interactable = true; //解鎖
                TargetWordUIbutton.Biodiversitylock.enabled = false; //大鎖圖示不見
                TargetWordUIbutton.BiodiversityText.enabled = true;  //單字文字出現
                //TargetWordUIbutton.WordBadgeIconCopper.SetActive(true);//銅牌
                //TargetWordUIbutton.WordBadgeIconGold.SetActive(false);//金牌
                break;
            case true:

                TargetWordUIbutton.WordView.SetActive(false);
                TargetWordUIbutton.openandclose = false;
                break;
            default:

                break;
        }
    }

    /*public void ShowAquaticMeaning()
    {
        switch (TargetWordUIbutton.openandclose)
        {
            case false:
                TargetWordUIbutton.WordViewTittle.text = "Aquatic";
                TargetWordUIbutton.WordViewText.text = "<size=30>" + "Aquatic 水生的" + "</size>" + "\n" + "\n" + "Description: Growing or living in or near water" + "\n" + "Sentence: he blue whale and sperm whale are the largest mammals among the aquatic animals.";
                TargetWordUIbutton.WordView.SetActive(true);
                TargetWordUIbutton.openandclose = true;
                TargetWordUIbutton.ActionSlot_Aquatic.interactable = true; //解鎖
                TargetWordUIbutton.Aquaticlock.enabled = false; //大鎖圖示不見
                TargetWordUIbutton.AquaticText.enabled = true;  //單字文字出現
                //TargetWordUIbutton.WordBadgeIconCopper.SetActive(false);//銅牌
                //TargetWordUIbutton.WordBadgeIconGold.SetActive(true);//金牌
                break;
            case true:
                TargetWordUIbutton.WordView.SetActive(false);
                TargetWordUIbutton.openandclose = false;
                break;
            default:

                break;
        }
    }*/
    public void ShowAquatic()
    {
        switch (TargetWordUIbutton.openandclose)
        {
            case false:
                TargetWordUIbutton.WordViewTittle.text = "Aquatic";
                TargetWordUIbutton.WordViewText.text = "<size=30>" + "Aquatic 水生的" + "</size>" + "\n" + "\n" + "Description: Growing or living in or near water" + "\n" + "Sentence: he blue whale and sperm whale are the largest mammals among the aquatic animals.";
                TargetWordUIbutton.WordView.SetActive(true);
                TargetWordUIbutton.openandclose = true;
                TargetWordUIbutton.ActionSlot_Aquatic.interactable = true; //解鎖
                TargetWordUIbutton.Aquaticlock.enabled = false; //大鎖圖示不見
                TargetWordUIbutton.AquaticText.enabled = true;  //單字文字出現
                //TargetWordUIbutton.WordBadgeIconCopper.SetActive(true);//銅牌
                //TargetWordUIbutton.WordBadgeIconGold.SetActive(false);//金牌
                break;
            case true:
                TargetWordUIbutton.WordView.SetActive(false);
                TargetWordUIbutton.openandclose = false;
                break;
            default:

                break;
        }
    }

    /*public void ShowAmphibianMeaning()
    {
        switch (TargetWordUIbutton.openandclose)
        {
            case false:
                TargetWordUIbutton.WordViewTittle.text = "Amphibian";
                TargetWordUIbutton.WordViewText.text = "<size=30>" + "Amphibian 兩棲類動物" + "</size>" + "\n" + "\n" + "Description: A cold-blooded animal, such as a frog, that lives both on land and in water but must produce its eggs in water." + "\n" + "Sentence: In contrast to some species, amphibian are unable to produce thermal energy through their metabolic activity.";
                TargetWordUIbutton.WordView.SetActive(true);
                TargetWordUIbutton.openandclose = true;
                TargetWordUIbutton.ActionSlot_Amphibian.interactable = true; //解鎖
                TargetWordUIbutton.Amphibianlock.enabled = false; //大鎖圖示不見
                TargetWordUIbutton.AmphibianText.enabled = true;  //單字文字出現
                //TargetWordUIbutton.WordBadgeIconCopper.SetActive(false);//銅牌
                //TargetWordUIbutton.WordBadgeIconGold.SetActive(true);//金牌
                break;
            case true:
                TargetWordUIbutton.WordView.SetActive(false);
                TargetWordUIbutton.openandclose = false;
                break;
            default:

                break;
        }
    }*/
    public void ShowAmphibian()
    {
        switch (TargetWordUIbutton.openandclose)
        {
            case false:
                TargetWordUIbutton.WordViewTittle.text = "Amphibian";
                TargetWordUIbutton.WordViewText.text = "<size=30>" + "Amphibian 兩棲類動物" + "</size>" + "\n" + "\n" + "Description: A cold-blooded animal, such as a frog, that lives both on land and in water but must produce its eggs in water." + "\n" + "Sentence: In contrast to some species, amphibian are unable to produce thermal energy through their metabolic activity.";
                TargetWordUIbutton.WordView.SetActive(true);
                TargetWordUIbutton.openandclose = true;
                TargetWordUIbutton.ActionSlot_Amphibian.interactable = true; //解鎖
                TargetWordUIbutton.Amphibianlock.enabled = false; //大鎖圖示不見
                TargetWordUIbutton.AmphibianText.enabled = true;  //單字文字出現
                //TargetWordUIbutton.WordBadgeIconCopper.SetActive(true);//銅牌
                //TargetWordUIbutton.WordBadgeIconGold.SetActive(false);//金牌
                break;
            case true:
                TargetWordUIbutton.WordView.SetActive(false);
                TargetWordUIbutton.openandclose = false;
                break;
            default:

                break;
        }
    }


    void Awake()
    {
        DialogControl = GameObject.Find("DialogControlFlowchart").GetComponent<Flowchart>(); //設定對話管理器

        windowRect = new Rect(
          (Screen.width - windowWidth) / 2,
          (Screen.height - windowHight) / 2,
          windowWidth,
          windowHight);
    }

    // Use this for initialization
    void Start()
    {
        for(int i = 0; i < isPick.Length; i++)
        {
            isPick[i] = false;
        }
        MissionReview_Flowchart = GameObject.Find("FightFlowchart").GetComponent<Flowchart>();
        //Learn完成任務
        //一開始載入遊戲判斷他是不是有完成過任務
        if (Loadcharacter.MissionComplete[1] == true) //Serene完成任務
        {
            SereneMission = "Done";
            TargetWordUIbutton.ActionSlot_Serene.interactable = true; //解鎖
            TargetWordUIbutton.Serenelock.enabled = false; //大鎖圖示不見
            TargetWordUIbutton.SereneText.enabled = true;  //單字文字出現
            MissionListUI.MissionListUIPic[0].SetActive(false);
            MissionListUI.MissionListUIPic[14].SetActive(true);
        }
        if (Loadcharacter.MissionComplete[2] == true) //Thoughtful完成任務
        {
            ThoughtfulMission = "Done";
            TargetWordUIbutton.ActionSlot_Thoughtful.interactable = true; //解鎖
            TargetWordUIbutton.Thoughtfullock.enabled = false; //大鎖圖示不見
            TargetWordUIbutton.ThoughtfulText.enabled = true;  //單字文字出現
            MissionListUI.MissionListUIPic[1].SetActive(false);
            MissionListUI.MissionListUIPic[15].SetActive(true);
        }
        if (Loadcharacter.MissionComplete[3] == true) //Subsidy完成任務
        {
            SubsidyMission = "Done";
            TargetWordUIbutton.ActionSlot_Subsidy.interactable = true; //解鎖
            TargetWordUIbutton.Subsidylock.enabled = false; //大鎖圖示不見
            TargetWordUIbutton.SubsidyText.enabled = true;  //單字文字出現
            MissionListUI.MissionListUIPic[2].SetActive(false);
            MissionListUI.MissionListUIPic[16].SetActive(true);
        }
        if (Loadcharacter.MissionComplete[4] == true) //Purification完成任務
        {
            PurificationMission = "Over";
            TargetWordUIbutton.ActionSlot_Purification.interactable = true; //解鎖
            TargetWordUIbutton.Purificationlock.enabled = false; //大鎖圖示不見
            TargetWordUIbutton.PurificationText.enabled = true;  //單字文字出現
            MissionListUI.MissionListUIPic[3].SetActive(false);
            MissionListUI.MissionListUIPic[17].SetActive(true);
        }
        if (Loadcharacter.MissionComplete[5] == true) //Detention完成任務
        {
            DetentionMission = "Over";
            TargetWordUIbutton.ActionSlot_Detention.interactable = true; //解鎖
            TargetWordUIbutton.Detentionlock.enabled = false; //大鎖圖示不見
            TargetWordUIbutton.DetentionText.enabled = true;  //單字文字出現
            MissionListUI.MissionListUIPic[4].SetActive(false);
            MissionListUI.MissionListUIPic[18].SetActive(true);
        }
        if (Loadcharacter.MissionComplete[6] == true) //Beautify完成任務
        {
            BeautifyMission = "Over";
            TargetWordUIbutton.ActionSlot_Beautify.interactable = true; //解鎖
            TargetWordUIbutton.Beautifylock.enabled = false; //大鎖圖示不見
            TargetWordUIbutton.BeautifyText.enabled = true;  //單字文字出現
            MissionListUI.MissionListUIPic[5].SetActive(false);
            MissionListUI.MissionListUIPic[19].SetActive(true);
        }
        if (Loadcharacter.MissionComplete[7] == true) //Drain完成任務
        {
            DrainMission = "Over";
            TargetWordUIbutton.ActionSlot_Drain.interactable = true; //解鎖
            TargetWordUIbutton.Drainlock.enabled = false; //大鎖圖示不見
            TargetWordUIbutton.DrainText.enabled = true;  //單字文字出現
            MissionListUI.MissionListUIPic[6].SetActive(false);
            MissionListUI.MissionListUIPic[20].SetActive(true);
        }
        if (Loadcharacter.MissionComplete[8] == true) //Concentration完成任務
        {
            ConcerntrationMission = "Over";
            TargetWordUIbutton.ActionSlot_Concerntration.interactable = true; //解鎖
            TargetWordUIbutton.Concerntrationlock.enabled = false; //大鎖圖示不見
            TargetWordUIbutton.ConcerntrationText.enabled = true;  //單字文字出現
            MissionListUI.MissionListUIPic[7].SetActive(false);
            MissionListUI.MissionListUIPic[21].SetActive(true);
        }
        if (Loadcharacter.MissionComplete[9] == true) //Ecological corridors完成任務
        {
            EcologicalcorridorsMission = "Over";
            TargetWordUIbutton.ActionSlot_Eologicalcorridors.interactable = true; //解鎖
            TargetWordUIbutton.Eologicalcorridorslock.enabled = false; //大鎖圖示不見
            TargetWordUIbutton.EologicalcorridorsText.enabled = true;  //單字文字出現
            MissionListUI.MissionListUIPic[8].SetActive(false);
            MissionListUI.MissionListUIPic[22].SetActive(true);
        }
        if (Loadcharacter.MissionComplete[10] == true) //Picturesque完成任務
        {
            PicturesqueMission = "Over";
            TargetWordUIbutton.ActionSlot_Picturesque.interactable = true; //解鎖
            TargetWordUIbutton.Picturesquelock.enabled = false; //大鎖圖示不見
            TargetWordUIbutton.PicturesqueText.enabled = true;  //單字文字出現
            MissionListUI.MissionListUIPic[9].SetActive(false);
            MissionListUI.MissionListUIPic[23].SetActive(true);
        }
        if (Loadcharacter.MissionComplete[11] == true) //Aquatic完成任務
        {
            AquaticMission = "Over";
            TargetWordUIbutton.ActionSlot_Aquatic.interactable = true; //解鎖
            TargetWordUIbutton.Aquaticlock.enabled = false; //大鎖圖示不見
            TargetWordUIbutton.AquaticText.enabled = true;  //單字文字出現
            MissionListUI.MissionListUIPic[10].SetActive(false);
            MissionListUI.MissionListUIPic[24].SetActive(true);
        }
        if (Loadcharacter.MissionComplete[12] == true) //Landscaping完成任務
        {
            LandscapingMission = "Over";
            TargetWordUIbutton.ActionSlot_Landscaping.interactable = true; //解鎖
            TargetWordUIbutton.Landscapinglock.enabled = false; //大鎖圖示不見
            TargetWordUIbutton.LandscapingText.enabled = true;  //單字文字出現
            MissionListUI.MissionListUIPic[11].SetActive(false);
            MissionListUI.MissionListUIPic[25].SetActive(true);
        }
        if (Loadcharacter.MissionComplete[13] == true) //Biodiversity完成任務
        {
            BiodiversityMission = "Over";
            TargetWordUIbutton.ActionSlot_Biodiversity.interactable = true; //解鎖
            TargetWordUIbutton.Biodiversitylock.enabled = false; //大鎖圖示不見
            TargetWordUIbutton.BiodiversityText.enabled = true;  //單字文字出現
            MissionListUI.MissionListUIPic[12].SetActive(false);
            MissionListUI.MissionListUIPic[26].SetActive(true);
        }
        if (Loadcharacter.MissionComplete[14] == true) //Amphibian完成任務
        {
            AmphibianMission = "Over";
            TargetWordUIbutton.ActionSlot_Amphibian.interactable = true; //解鎖
            TargetWordUIbutton.Amphibianlock.enabled = false; //大鎖圖示不見
            TargetWordUIbutton.AmphibianText.enabled = true;  //單字文字出現
            MissionListUI.MissionListUIPic[13].SetActive(false);
            MissionListUI.MissionListUIPic[27].SetActive(true);
        }
        
        //Review完成任務
        //if (Loadcharacter.MissionComplete[16] == true) 
        //{
        //    //Serene_Cyclops = 4; //設定起始數量為4
        //    SereneReward = true;
        //    //UI要改成單字卡的意思
        //    //TargetWordUIbutton.WordViewTittle.text = "Serene"; //單字標題
        //    //TargetWordUIbutton.WordViewText.text = "Serene 寧靜的、祥和的"; //單字內容
        //    TargetWordUIbutton.ActionSlot_Serene.interactable = true; //解鎖
        //    TargetWordUIbutton.Serenelock.enabled = false; //大鎖圖示不見
        //    TargetWordUIbutton.SereneText.enabled = true;  //單字文字出現                                                          
        //}
        //if (Loadcharacter.MissionComplete[17] == true)
        //{
        //    //Thoughtfu_Crab = 4; //設定起始數量為4
        //    ThoughtfulReward = true;
        //    //UI要改成單字卡的意思
        //    //TargetWordUIbutton.WordViewTittle.text = "Thoughtful";
        //    //TargetWordUIbutton.WordViewText.text = "Thoughtful 沉思的、替人著想的";
        //    TargetWordUIbutton.ActionSlot_Thoughtful.interactable = true; //解鎖
        //    TargetWordUIbutton.Thoughtfullock.enabled = false; //大鎖圖示不見
        //    TargetWordUIbutton.ThoughtfulText.enabled = true;  //單字文字出現
        //}
        //if (Loadcharacter.MissionComplete[18] == true)
        //{
        //    //Subsidy_Mummy = 4; //設定起始數量為4
        //    SubsidyReward = true;
        //                       //UI要改成單字卡的意思
        //    //TargetWordUIbutton.WordViewTittle.text = "Subsidy";
        //    //TargetWordUIbutton.WordViewText.text = "Subsidy 補助；補助金";
        //    TargetWordUIbutton.ActionSlot_Subsidy.interactable = true; //解鎖
        //    TargetWordUIbutton.Subsidylock.enabled = false; //大鎖圖示不見
        //    TargetWordUIbutton.SubsidyText.enabled = true;  //單字文字出現
        //}
        //if (Loadcharacter.MissionComplete[19] == true)
        //{
        //    //Purification_Bunny = 4; //設定起始數量為4
        //    PurificationReward = true;            //UI要改成單字卡的意思
        //    //TargetWordUIbutton.WordViewTittle.text = "Purification";
        //    //TargetWordUIbutton.WordViewText.text = "Purification 淨化";
        //    TargetWordUIbutton.ActionSlot_Purification.interactable = true; //解鎖
        //    TargetWordUIbutton.Purificationlock.enabled = false; //大鎖圖示不見
        //    TargetWordUIbutton.PurificationText.enabled = true;  //單字文字出現
        //}
        //if (Loadcharacter.MissionComplete[20] == true)
        //{
        //    //Detention_Rabbit = 4; //設定起始數量為4
        //    DetentionReward = true;
        //                          //UI要改成單字卡的意思
        //    //TargetWordUIbutton.WordViewTittle.text = "Detention";
        //    //TargetWordUIbutton.WordViewText.text = "Detention 拘留、滯留";
        //    TargetWordUIbutton.ActionSlot_Detention.interactable = true; //解鎖
        //    TargetWordUIbutton.Detentionlock.enabled = false; //大鎖圖示不見
        //    TargetWordUIbutton.DetentionText.enabled = true;  //單字文字出現
        //}
        //if (Loadcharacter.MissionComplete[21] == true)
        //{
        //    //Beautify_Wolfrider = 4; //設定起始數量為4
        //    BeautifyReward = true;
        //    //UI要改成單字卡的意思
        //    //TargetWordUIbutton.WordViewTittle.text = "Beautify";
        //    //TargetWordUIbutton.WordViewText.text = "Beautify 美化";
        //    TargetWordUIbutton.ActionSlot_Beautify.interactable = true; //解鎖
        //    TargetWordUIbutton.Beautifylock.enabled = false; //大鎖圖示不見
        //    TargetWordUIbutton.BeautifyText.enabled = true;  //單字文字出現
        //}
        //if (Loadcharacter.MissionComplete[22] == true)
        //{
        //    //Drain_Dwarf = 4; //設定起始數量為4
        //    DrainReward = true;
        //    //UI要改成單字卡的意思
        //    //TargetWordUIbutton.WordViewTittle.text = "Drain";
        //    //TargetWordUIbutton.WordViewText.text = "Drain 排水";
        //    TargetWordUIbutton.ActionSlot_Drain.interactable = true; //解鎖
        //    TargetWordUIbutton.Drainlock.enabled = false; //大鎖圖示不見
        //    TargetWordUIbutton.DrainText.enabled = true;  //單字文字出現
        //}
        //if (Loadcharacter.MissionComplete[23] == true)
        //{
        //    //Concentration_Mushroom = 4; //設定起始數量為4
        //    ConcentrationReward = true;
        //    //UI要改成單字卡的意思
        //    //TargetWordUIbutton.WordViewTittle.text = "Concerntration";
        //    //TargetWordUIbutton.WordViewText.text = "Concentration 濃度";
        //    TargetWordUIbutton.ActionSlot_Concerntration.interactable = true; //解鎖
        //    TargetWordUIbutton.Concerntrationlock.enabled = false; //大鎖圖示不見
        //    TargetWordUIbutton.ConcerntrationText.enabled = true;  //單字文字出現
        //}
        //if (Loadcharacter.MissionComplete[24] == true)
        //{
        //    //Ecologicalcorridors_Devil = 4; //設定起始數量為4
        //    Ecological_corridorsReward = true;
        //    //UI要改成單字卡的意思
        //    //TargetWordUIbutton.WordViewTittle.text = "Eologicalcorridors";
        //    //TargetWordUIbutton.WordViewText.text = "Eologicalcorridors 生態走廊";
        //    TargetWordUIbutton.ActionSlot_Eologicalcorridors.interactable = true; //解鎖
        //    TargetWordUIbutton.Eologicalcorridorslock.enabled = false; //大鎖圖示不見
        //    TargetWordUIbutton.EologicalcorridorsText.enabled = true;  //單字文字出現
        //}
        //if (Loadcharacter.MissionComplete[25] == true)
        //{
        //    //Picturesque_Bat = 4; //設定起始數量為4
        //    PicturesqueReward = true;
        //    //UI要改成單字卡的意思
        //    //TargetWordUIbutton.WordViewTittle.text = "Picturesque";
        //    //TargetWordUIbutton.WordViewText.text = "Picturesque 風景如畫的；圖畫般的；別具一格的";
        //    TargetWordUIbutton.ActionSlot_Picturesque.interactable = true; //解鎖
        //    TargetWordUIbutton.Picturesquelock.enabled = false; //大鎖圖示不見
        //    TargetWordUIbutton.PicturesqueText.enabled = true;  //單字文字出現
        //}
        //if (Loadcharacter.MissionComplete[26] == true)
        //{
        //    //Aquatic_Slime = 4; //設定起始數量為4
        //    AquaticReward = true;
        //    //UI要改成單字卡的意思
        //    //TargetWordUIbutton.WordViewTittle.text = "Aquatic";
        //    //TargetWordUIbutton.WordViewText.text = "Aquatic 水生的";
        //    TargetWordUIbutton.ActionSlot_Aquatic.interactable = true; //解鎖
        //    TargetWordUIbutton.Aquaticlock.enabled = false; //大鎖圖示不見
        //    TargetWordUIbutton.AquaticText.enabled = true;  //單字文字出現
        //}
        //if (Loadcharacter.MissionComplete[27] == true)
        //{
        //    //Landscaping_StoneMonster = 4; //設定起始數量為4
        //    LandscapingReward = true;
        //    //UI要改成單字卡的意思
        //    //TargetWordUIbutton.WordViewTittle.text = "Landscaping";
        //    //TargetWordUIbutton.WordViewText.text = "Landscaping 造景";
        //    TargetWordUIbutton.ActionSlot_Landscaping.interactable = true; //解鎖
        //    TargetWordUIbutton.Landscapinglock.enabled = false; //大鎖圖示不見
        //    TargetWordUIbutton.LandscapingText.enabled = true;  //單字文字出現
        //}
        //if (Loadcharacter.MissionComplete[28] == true)
        //{
        //    //Biodiversity_Ghost = 4; //設定起始數量為4
        //    BiodiversityReward = true;
        //    //UI要改成單字卡的意思
        //    //TargetWordUIbutton.WordViewTittle.text = "Biodiversity";
        //    //TargetWordUIbutton.WordViewText.text = "Biodiversity 生物多樣性";
        //    TargetWordUIbutton.ActionSlot_Biodiversity.interactable = true; //解鎖
        //    TargetWordUIbutton.Biodiversitylock.enabled = false; //大鎖圖示不見
        //    TargetWordUIbutton.BiodiversityText.enabled = true;  //單字文字出現
        //}
        //if (Loadcharacter.MissionComplete[29] == true)
        //{
        //    //Amphibian_StoneMan = 4; //設定起始數量為4
        //    AmphibianReward = true;
        //    //UI要改成單字卡的意思
        //    //TargetWordUIbutton.WordViewTittle.text = "Amphibian";
        //    //TargetWordUIbutton.WordViewText.text = "Amphibian 兩棲類動物";
        //    TargetWordUIbutton.ActionSlot_Amphibian.interactable = true; //解鎖
        //    TargetWordUIbutton.Amphibianlock.enabled = false; //大鎖圖示不見
        //    TargetWordUIbutton.AmphibianText.enabled = true;  //單字文字出現
        //}

    }

    // Update is called once per frame
    void Update()
    {
        HPbelowzero();
    }

    void OnGUI()
    {
        if (ShowHPLow == true)
        {
            /*
            GUI.Box(new Rect(Screen.width / 4, Screen.height / 4, 2 * (Screen.width / 4), 2 * (Screen.height / 4)), "Warning");
            if (GUI.Button(new Rect((Screen.width / 2) - 55, (Screen.height / 2) + 1 * (Screen.height / 6), 110, 25), "Cost 3 gold to buy the HP"))//按鈕YES被按下之後
            {
                Debug.Log("扣金幣換取血量");
                HPscripts.HP = 100;
                MoneyScript.Money -= 3;
                WWWForm Form = new WWWForm();

                Form.AddField("Account", LoginScript.Account);
                WWW LoginAccountWWW = new WWW(Buy_HP_Url, Form);
                if (LoginAccountWWW.error != null)
                {
                    Debug.LogError("寫入錯誤");
                }
            }
            GUI.Label(new Rect((Screen.width / 2) - 90, (Screen.height / 2), 220, 30), "You are running out of the HP");
            */

            windowRect = GUI.Window(0, windowRect, LowHpWindow, "LowHp Warnimg");

            
        }
    }
    
    void LowHpWindow(int windowID)
    {
       
        GUI.Label(new Rect(50, 50, 300, 40), "You are running out of power,please use 3 gold to recover !");

        if (GUI.Button(new Rect(155, 110, 100, 20), "Yes")) //按鈕YES被按下之後
        {
            //執行血量置換
            Debug.Log("扣金幣換取血量");
            HPscripts.HP = 100;
            MoneyScript.Money -= 3;
            WWWForm Form = new WWWForm();

            //Form.AddField("Account", LoginScript.Account);
            WWW LoginAccountWWW = new WWW(Buy_HP_Url + LoginScript.Account);
            if (LoginAccountWWW.error != null)
            {
                Debug.LogError("寫入錯誤");
            }
        }

        GUI.DragWindow();
    }
    
    public void RandReview()
    {
        int num = Random.Range(0, 14);
        if (isPick[num])
        {
            RandReview();
        }
        else
        {
            isPick[num] = true;
            ReviewQuestion = num+1;
        }
        
    }

}
