using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class CompareAnswer : MonoBehaviour{

    public Flowchart Rightpic_Flowchart;
    public Flowchart Thoughtful_NPC_Flowchart;
    public Flowchart Subsidy_NPC_Flowchart;
    public Flowchart NPC04_Mission_Flowchart;
    public Flowchart Detention_Flowchart;
    public Flowchart NPC05_Mission_Flowchart;
    public Flowchart Concentration_Mission_Flowchart;
    public Flowchart Mission_Ecological_corridors_Flowchart;
    public Flowchart Mission_Picturesque_Flowchart;
    public Flowchart Mission_NPC1208101711Flowchart;
    public Flowchart FightFlowchart;
    private string Insert_Ans_Url = "http://140.115.126.115:3000/Insert_Answer_State?account=";
    public string Serene_get_result // 選擇答案名稱-設定值給fungus
    {
        get { return Rightpic_Flowchart.GetStringVariable("get_result"); } //從Fungus取值
        set { Rightpic_Flowchart.SetStringVariable("get_result", value); } //設定給Fungus
    }
    public string Thoughtful_get_result // 選擇答案名稱-設定值給fungus
    {
        get { return Thoughtful_NPC_Flowchart.GetStringVariable("get_result"); } //從Fungus取值
        set { Thoughtful_NPC_Flowchart.SetStringVariable("get_result", value); } //設定給Fungus
    }
    public string Subsidy_get_result // 選擇答案名稱-設定值給fungus
    {
        get { return Subsidy_NPC_Flowchart.GetStringVariable("get_result"); } //從Fungus取值
        set { Subsidy_NPC_Flowchart.SetStringVariable("get_result", value); } //設定給Fungus
    }
    public string Purification_get_result // 選擇答案名稱-設定值給fungus
    {
        get { return NPC04_Mission_Flowchart.GetStringVariable("get_result"); } //從Fungus取值
        set { NPC04_Mission_Flowchart.SetStringVariable("get_result", value); } //設定給Fungus
    }
    public string Detention_get_result // 選擇答案名稱-設定值給fungus
    {
        get { return Detention_Flowchart.GetStringVariable("get_result"); } //從Fungus取值
        set { Detention_Flowchart.SetStringVariable("get_result", value); } //設定給Fungus
    }
    public string Beautify_get_result // 選擇答案名稱-設定值給fungus
    {
        get { return NPC05_Mission_Flowchart.GetStringVariable("get_result"); } //從Fungus取值
        set { NPC05_Mission_Flowchart.SetStringVariable("get_result", value); } //設定給Fungus
    }
    public string Concentration_get_result // 選擇答案名稱-設定值給fungus
    {
        get { return Concentration_Mission_Flowchart.GetStringVariable("get_result"); } //從Fungus取值
        set { Concentration_Mission_Flowchart.SetStringVariable("get_result", value); } //設定給Fungus
    }
    public string Ecological_get_result // 選擇答案名稱-設定值給fungus
    {
        get { return Mission_Ecological_corridors_Flowchart.GetStringVariable("get_result"); } //從Fungus取值
        set { Mission_Ecological_corridors_Flowchart.SetStringVariable("get_result", value); } //設定給Fungus
    }
    public string Picturesque_get_result // 選擇答案名稱-設定值給fungus
    {
        get { return Mission_Picturesque_Flowchart.GetStringVariable("get_result"); } //從Fungus取值
        set { Mission_Picturesque_Flowchart.SetStringVariable("get_result", value); } //設定給Fungus
    }
    public string Mix_get_result // 選擇答案名稱-設定值給fungus
    {
        get { return Mission_NPC1208101711Flowchart.GetStringVariable("get_result"); } //從Fungus取值
        set { Mission_NPC1208101711Flowchart.SetStringVariable("get_result", value); } //設定給Fungus
    }

    /// <summary>
    /// 測試更新星星數量
    /// </summary>
    public static void TestUploadStar()
    {
        string Insert_Ans_Url = "http://140.115.126.115:3000/Insert_Answer_State?account=";

        WWW WWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=1" + "&Mission_State=1" + "&Accuracy=" + 99 + "&Star=" + Star.JudgePerformance_ReturnStar((float)99));
        if (WWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
        else
        {
            Debug.Log("更新星星成功");
        }
    }

    // 列舉任務類別
    public enum MissionStatus
    {
        Learning, 
        Practice, 
        Review   
    }


    /// <summary>
    /// 紀錄學習任務例句答對與答錯次數
    /// </summary>
    public void CountResult(string word, float rate, MissionStatus status)
    {
        if (rate >= 80)
        {
            switch (status)
            {
                case MissionStatus.Learning:
                    {
                        WWWForm Form = new WWWForm();
                        WWW WWW;
                        WWW = new WWW(AllFunctiosTime.LearningMissionSentence + LoginScript.Account + "&status=LearningSentence" + "&correct=1" + "&accuracy=" + rate);
                        Debug.Log("紀錄答對次數");
                        if (WWW.error != null)
                        {
                            Debug.Log("紀錄答對" + WWW.error);
                            Debug.LogError("寫入錯誤");
                        }
                    }
                    break;
                case MissionStatus.Practice:
                    {
                        WWWForm Form = new WWWForm();
                        WWW WWW;
                        WWW = new WWW(AllFunctiosTime.LearningMissionSentence + LoginScript.Account + "&status=PracticeSentence" + "&correct=1" + "&accuracy=" + rate);
                        Debug.Log("紀錄答對次數");
                        if (WWW.error != null)
                        {
                            Debug.Log("紀錄答對" + WWW.error);
                            Debug.LogError("寫入錯誤");
                        }
                    }
                    break;
                case MissionStatus.Review:
                    {
                        WWWForm Form = new WWWForm();
                        WWW WWW;
                        WWW = new WWW(AllFunctiosTime.LearningMissionSentence + LoginScript.Account + "&status=ReviewSentence" + "&correct=1" + "&accuracy=" + rate);
                        Debug.Log("紀錄答對次數");
                        if (WWW.error != null)
                        {
                            Debug.Log("紀錄答對" + WWW.error);
                            Debug.LogError("寫入錯誤");
                        }
                    }
                    break;
            }
        }
        else
        {
            switch (status)
            {
                case MissionStatus.Learning:
                    {
                        WWWForm Form = new WWWForm();
                        WWW WWW;
                        WWW = new WWW(AllFunctiosTime.LearningMissionSentence + LoginScript.Account + "&status=LearningSentence" + "&wrong=1" + "&accuracy=" + rate);
                        Debug.Log("紀錄答錯次數");
                        if (WWW.error != null)
                        {
                            Debug.Log("紀錄答錯" + WWW.error);
                            Debug.LogError("寫入錯誤");
                        }
                    }
                    break;
                case MissionStatus.Practice:
                    {
                        WWWForm Form = new WWWForm();
                        WWW WWW;
                        WWW = new WWW(AllFunctiosTime.LearningMissionSentence + LoginScript.Account + "&status=PracticeSentence" + "&wrong=1" + "&accuracy=" + rate);
                        Debug.Log("紀錄錯對次數");
                        if (WWW.error != null)
                        {
                            Debug.Log("紀錄錯對" + WWW.error);
                            Debug.LogError("寫入錯誤");
                        }
                    }
                    break;
                case MissionStatus.Review:
                    {
                        WWWForm Form = new WWWForm();
                        WWW WWW;
                        WWW = new WWW(AllFunctiosTime.LearningMissionSentence + LoginScript.Account + "&status=ReviewSentence" + "&wrong=1" + "&accuracy=" + rate);
                        Debug.Log("紀錄錯對次數");
                        if (WWW.error != null)
                        {
                            Debug.Log("紀錄錯對" + WWW.error);
                            Debug.LogError("寫入錯誤");
                        }
                    }
                    break;
            }
        } 
    }

    public void SimilaritySerene1()
    {
        StringCompute stringcompute1 = new StringCompute();
        stringcompute1.SpeedyCompute(Serene_get_result, "you will see a serene skies and a bright blue lake out there");    // 计算相似度， 不记录比较时间
        decimal rate = stringcompute1.ComputeResult.Rate;         // 相似度百分之几，完全匹配相似度为1
        rate = rate * 100;
        Rightpic_Flowchart.SetStringVariable("Similarity_percentage", rate.ToString("#0.00")+"%");
        Rightpic_Flowchart.SetFloatVariable("Similarity", (float)rate);
        if ((float)rate > Accuracy.accuracy[0, 0])
        {
            Accuracy.accuracy[0, 0] = (float)rate;
            Accuracy.isChange = true;            
        }
            WWWForm Form = new WWWForm();
            WWW WWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=1" + "&Mission_State=1" + "&Accuracy=" + (float)rate+ "&Star="+Star.JudgePerformance_ReturnStar((float)rate));
            if (WWW.error != null)
            {
                Debug.LogError("寫入錯誤");
            }

        CountResult("You will see a serene skies and a bright blue lake out there", (float)rate, MissionStatus.Learning);
        
    }
    public void SimilaritySerene2()
    {
        StringCompute stringcompute1 = new StringCompute();
        stringcompute1.SpeedyCompute(Serene_get_result, "love helps us stay calm and serene even when things are tough");    // 计算相似度， 不记录比较时间
        decimal rate = stringcompute1.ComputeResult.Rate;         // 相似度百分之几，完全匹配相似度为1
        rate = rate * 100;
        Rightpic_Flowchart.SetStringVariable("Similarity_percentage", rate.ToString("#0.00") + "%");
        Rightpic_Flowchart.SetFloatVariable("Similarity", (float)rate);
        if ((float)rate > Accuracy.accuracy[0, 1])
        {
            Accuracy.accuracy[0, 1] = (float)rate;
            Accuracy.isChange = true;
        }
        WWWForm Form = new WWWForm();
        WWW WWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=1" + "&Mission_State=2" + "&Accuracy=" + (float)rate + "&Star=" + Star.JudgePerformance_ReturnStar((float)rate));
        if (WWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }

        CountResult("Love helps us stay calm and serene even when things are tough", (float)rate, MissionStatus.Learning);
    }
    public void SimilaritySerene3()
    {
        StringCompute stringcompute1 = new StringCompute();
        stringcompute1.SpeedyCompute(Serene_get_result, "this is the perfect place to slowly unwind in serene rural surroundings");    // 计算相似度， 不记录比较时间
        decimal rate = stringcompute1.ComputeResult.Rate;         // 相似度百分之几，完全匹配相似度为1
        rate = rate * 100;
        Rightpic_Flowchart.SetStringVariable("Similarity_percentage", rate.ToString("#0.00") + "%");
        Rightpic_Flowchart.SetFloatVariable("Similarity", (float)rate);
        if ((float)rate > Accuracy.accuracy[0, 2])
        {
            Accuracy.accuracy[0, 2] = (float)rate;
            Accuracy.isChange = true;
        }
        WWWForm Form = new WWWForm();
        WWW WWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=1" + "&Mission_State=3" + "&Accuracy=" + (float)rate + "&Star=" + Star.JudgePerformance_ReturnStar((float)rate));
        if (WWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }

        CountResult("This is the perfect place to slowly unwind in serene rural surroundings", (float)rate, MissionStatus.Learning);
    }
    public void SimilarityThoughtful1()
    {
        StringCompute stringcompute1 = new StringCompute();
        stringcompute1.SpeedyCompute(Thoughtful_get_result, "the book is a thoughtful account of his journeys in taiwan");    // 计算相似度， 不记录比较时间
        decimal rate = stringcompute1.ComputeResult.Rate;         // 相似度百分之几，完全匹配相似度为1
        rate = rate * 100;
        Thoughtful_NPC_Flowchart.SetStringVariable("Similarity_percentage", rate.ToString("#0.00") + "%");
        Thoughtful_NPC_Flowchart.SetFloatVariable("Similarity", (float)rate);
        if ((float)rate > Accuracy.accuracy[1, 0])
        {
            Accuracy.accuracy[1, 0] = (float)rate;
            Accuracy.isChange = true;
        }
        WWWForm Form = new WWWForm();
        WWW WWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=2" + "&Mission_State=1" + "&Accuracy=" + (float)rate + "&Star=" + Star.JudgePerformance_ReturnStar((float)rate));
        if (WWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }

        CountResult("The book is a thoughtful account of his journeys in taiwan", (float)rate, MissionStatus.Learning);
    }
    public void SimilarityThoughtful2()
    {
        StringCompute stringcompute1 = new StringCompute();
        stringcompute1.SpeedyCompute(Thoughtful_get_result, "it is very thoughtful of you to bring me the book");    // 计算相似度， 不记录比较时间
        decimal rate = stringcompute1.ComputeResult.Rate;         // 相似度百分之几，完全匹配相似度为1
        rate = rate * 100;
        Thoughtful_NPC_Flowchart.SetStringVariable("Similarity_percentage", rate.ToString("#0.00") + "%");
        Thoughtful_NPC_Flowchart.SetFloatVariable("Similarity", (float)rate);
        if ((float)rate > Accuracy.accuracy[1, 1])
        {
            Accuracy.accuracy[1, 1] = (float)rate;
            Accuracy.isChange = true;
        }
        WWWForm Form = new WWWForm();
        WWW WWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=2" + "&Mission_State=2" + "&Accuracy=" + (float)rate + "&Star=" + Star.JudgePerformance_ReturnStar((float)rate));
        if (WWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }

        CountResult("It is very thoughtful of you to bring me the book", (float)rate, MissionStatus.Learning);
    }
    public void SimilarityThoughtful3()
    {
        StringCompute stringcompute1 = new StringCompute();
        stringcompute1.SpeedyCompute(Thoughtful_get_result, "you should be more thoughtful about how to manage your time");    // 计算相似度， 不记录比较时间
        decimal rate = stringcompute1.ComputeResult.Rate;         // 相似度百分之几，完全匹配相似度为1
        rate = rate * 100;
        Thoughtful_NPC_Flowchart.SetStringVariable("Similarity_percentage", rate.ToString("#0.00") + "%");
        Thoughtful_NPC_Flowchart.SetFloatVariable("Similarity", (float)rate);
        if ((float)rate > Accuracy.accuracy[1, 2])
        {
            Accuracy.accuracy[1, 2] = (float)rate;
            Accuracy.isChange = true;
        }
        WWWForm Form = new WWWForm();
        WWW WWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=2" + "&Mission_State=3" + "&Accuracy=" + (float)rate + "&Star=" + Star.JudgePerformance_ReturnStar((float)rate));
        if (WWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }

        CountResult("You should be more thoughtful about how to manage your time", (float)rate, MissionStatus.Learning);
    }
    public void SimilaritySubsidy1()
    {
        StringCompute stringcompute1 = new StringCompute();
        stringcompute1.SpeedyCompute(Subsidy_get_result, "there were also pledges to soften the impact of the subsidy cuts on the poorer regions");    // 计算相似度， 不记录比较时间
        decimal rate = stringcompute1.ComputeResult.Rate;         // 相似度百分之几，完全匹配相似度为1
        rate = rate * 100;
        Subsidy_NPC_Flowchart.SetStringVariable("Similarity_percentage", rate.ToString("#0.00") + "%");
        Subsidy_NPC_Flowchart.SetFloatVariable("Similarity", (float)rate);
        if ((float)rate > Accuracy.accuracy[2, 0])
        {
            Accuracy.accuracy[2, 0] = (float)rate;
            Accuracy.isChange = true;
        }
        WWWForm Form = new WWWForm();
        WWW WWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=3" + "&Mission_State=1" + "&Accuracy=" + (float)rate + "&Star=" + Star.JudgePerformance_ReturnStar((float)rate));
        if (WWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }

        CountResult("There were also pledges to soften the impact of the subsidy cuts on the poorer regions", (float)rate, MissionStatus.Learning);
    }
    public void SimilaritySubsidy2()
    {
        StringCompute stringcompute1 = new StringCompute();
        stringcompute1.SpeedyCompute(Subsidy_get_result, "they received a subsidy in the form of a percentage of all foreign trade operations");    // 计算相似度， 不记录比较时间
        decimal rate = stringcompute1.ComputeResult.Rate;         // 相似度百分之几，完全匹配相似度为1
        rate = rate * 100;
        Subsidy_NPC_Flowchart.SetStringVariable("Similarity_percentage", rate.ToString("#0.00") + "%");
        Subsidy_NPC_Flowchart.SetFloatVariable("Similarity", (float)rate);
        if ((float)rate > Accuracy.accuracy[2, 1])
        {
            Accuracy.accuracy[2,1] = (float)rate;
            Accuracy.isChange = true;
        }
        WWWForm Form = new WWWForm();
        WWW WWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=3" + "&Mission_State=2" + "&Accuracy=" + (float)rate + "&Star=" + Star.JudgePerformance_ReturnStar((float)rate));
        if (WWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }

        CountResult("They received a subsidy in the form of a percentage of all foreign trade operations", (float)rate, MissionStatus.Learning);
    }
    public void SimilaritySubsidy3()
    {
        StringCompute stringcompute1 = new StringCompute();
        stringcompute1.SpeedyCompute(Subsidy_get_result, "the university will gain a subsidy for research in artificial intelligence");    // 计算相似度， 不记录比较时间
        decimal rate = stringcompute1.ComputeResult.Rate;         // 相似度百分之几，完全匹配相似度为1
        rate = rate * 100;
        Subsidy_NPC_Flowchart.SetStringVariable("Similarity_percentage", rate.ToString("#0.00") + "%");
        if ((float)rate > Accuracy.accuracy[2,2])
        {
            Accuracy.accuracy[2,2] = (float)rate;
            Accuracy.isChange = true;
        }
        Subsidy_NPC_Flowchart.SetFloatVariable("Similarity", (float)rate);
        WWWForm Form = new WWWForm();
        WWW WWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=3" + "&Mission_State=3" + "&Accuracy=" + (float)rate + "&Star=" + Star.JudgePerformance_ReturnStar((float)rate));
        if (WWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }

        CountResult("The university will gain a subsidy for research in artificial intelligence", (float)rate, MissionStatus.Learning);
    }
    public void SimilarityPurification1()
    {
        StringCompute stringcompute1 = new StringCompute();
        stringcompute1.SpeedyCompute(Purification_get_result, "the water goes through three stages of purification");    // 计算相似度， 不记录比较时间
        decimal rate = stringcompute1.ComputeResult.Rate;         // 相似度百分之几，完全匹配相似度为1
        rate = rate * 100;
        NPC04_Mission_Flowchart.SetStringVariable("Similarity_percentage", rate.ToString("#0.00") + "%");
        NPC04_Mission_Flowchart.SetFloatVariable("Similarity", (float)rate);
        if ((float)rate > Accuracy.accuracy[3,0])
        {
            Accuracy.accuracy[3,0] = (float)rate;
            Accuracy.isChange = true;
        }
        WWWForm Form = new WWWForm();
        WWW WWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=4" + "&Mission_State=1" + "&Accuracy=" + (float)rate + "&Star=" + Star.JudgePerformance_ReturnStar((float)rate));
        if (WWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }

        CountResult("The water goes through three stages of purification", (float)rate, MissionStatus.Learning);
    }
    public void SimilarityPurification2()
    {
        StringCompute stringcompute1 = new StringCompute();
        stringcompute1.SpeedyCompute(Purification_get_result, "reading a good book may bring purification to our souls");    // 计算相似度， 不记录比较时间
        decimal rate = stringcompute1.ComputeResult.Rate;         // 相似度百分之几，完全匹配相似度为1
        rate = rate * 100;
        NPC04_Mission_Flowchart.SetStringVariable("Similarity_percentage", rate.ToString("#0.00") + "%");
        NPC04_Mission_Flowchart.SetFloatVariable("Similarity", (float)rate);
        if ((float)rate > Accuracy.accuracy[3,1])
        {
            Accuracy.accuracy[3,1] = (float)rate;
            Accuracy.isChange = true;
        }
        WWWForm Form = new WWWForm();
        WWW WWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=4" + "&Mission_State=2" + "&Accuracy=" + (float)rate + "&Star=" + Star.JudgePerformance_ReturnStar((float)rate));
        if (WWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }

        CountResult("Reading a good book may bring purification to our souls", (float)rate, MissionStatus.Learning);
    }
    public void SimilarityPurification3()
    {
        StringCompute stringcompute1 = new StringCompute();
        stringcompute1.SpeedyCompute(Purification_get_result, "distillation has traditionally been the major system for water purification");    // 计算相似度， 不记录比较时间
        decimal rate = stringcompute1.ComputeResult.Rate;         // 相似度百分之几，完全匹配相似度为1
        rate = rate * 100;
        NPC04_Mission_Flowchart.SetStringVariable("Similarity_percentage", rate.ToString("#0.00") + "%");
        NPC04_Mission_Flowchart.SetFloatVariable("Similarity", (float)rate);
        if ((float)rate > Accuracy.accuracy[3, 2])
        {
            Accuracy.accuracy[3, 2] = (float)rate;
            Accuracy.isChange = true;
        }
        WWWForm Form = new WWWForm();
        WWW WWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=4" + "&Mission_State=3" + "&Accuracy=" + (float)rate + "&Star=" + Star.JudgePerformance_ReturnStar((float)rate));
        if (WWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }

        CountResult("Distillation has traditionally been the major system for water purification", (float)rate, MissionStatus.Learning);
    }
    public void SimilarityDetention1()
    {
        StringCompute stringcompute1 = new StringCompute();
        stringcompute1.SpeedyCompute(Detention_get_result, "the teacher kept the boys in detention after school");    // 计算相似度， 不记录比较时间
        decimal rate = stringcompute1.ComputeResult.Rate;         // 相似度百分之几，完全匹配相似度为1
        rate = rate * 100;
        Detention_Flowchart.SetStringVariable("Similarity_percentage", rate.ToString("#0.00") + "%");
        Detention_Flowchart.SetFloatVariable("Similarity", (float)rate);
        if ((float)rate > Accuracy.accuracy[4,0])
        {
            Accuracy.accuracy[4, 0] = (float)rate;
            Accuracy.isChange = true;
        }
        WWWForm Form = new WWWForm();
        WWW WWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=5" + "&Mission_State=1" + "&Accuracy=" + (float)rate + "&Star=" + Star.JudgePerformance_ReturnStar((float)rate));
        if (WWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }

        CountResult("The teacher kept the boys in detention after school", (float)rate, MissionStatus.Learning);
    }
    public void SimilarityDetention2()
    {
        StringCompute stringcompute1 = new StringCompute();
        stringcompute1.SpeedyCompute(Detention_get_result, "she prefers to stay in detention rather than be released and go into exile");    // 计算相似度， 不记录比较时间
        decimal rate = stringcompute1.ComputeResult.Rate;         // 相似度百分之几，完全匹配相似度为1
        rate = rate * 100;
        Detention_Flowchart.SetStringVariable("Similarity_percentage", rate.ToString("#0.00") + "%");
        Detention_Flowchart.SetFloatVariable("Similarity", (float)rate);
        if ((float)rate > Accuracy.accuracy[4,1])
        {
            Accuracy.accuracy[4,1] = (float)rate;
            Accuracy.isChange = true;
        }
        WWWForm Form = new WWWForm();
        WWW WWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=5" + "&Mission_State=2" + "&Accuracy=" + (float)rate + "&Star=" + Star.JudgePerformance_ReturnStar((float)rate));
        if (WWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }

        CountResult("She prefers to stay in detention rather than be released and go into exile", (float)rate, MissionStatus.Learning);
    }
    public void SimilarityDetention3()
    {
        StringCompute stringcompute1 = new StringCompute();
        stringcompute1.SpeedyCompute(Detention_get_result, "they have been held in detention since the end of june");    // 计算相似度， 不记录比较时间
        decimal rate = stringcompute1.ComputeResult.Rate;         // 相似度百分之几，完全匹配相似度为1
        rate = rate * 100;
        Detention_Flowchart.SetStringVariable("Similarity_percentage", rate.ToString("#0.00") + "%");
        Detention_Flowchart.SetFloatVariable("Similarity", (float)rate);
        if ((float)rate > Accuracy.accuracy[4,2])
        {
            Accuracy.accuracy[4,2] = (float)rate;
            Accuracy.isChange = true;
        }
        WWWForm Form = new WWWForm();
        WWW WWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=5" + "&Mission_State=3" + "&Accuracy=" + (float)rate + "&Star=" + Star.JudgePerformance_ReturnStar((float)rate));
        if (WWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }

        CountResult("They have been held in detention since the end of june", (float)rate, MissionStatus.Learning);
    }
    public void SimilarityBeautify1()
    {
        StringCompute stringcompute1 = new StringCompute();
        stringcompute1.SpeedyCompute(Beautify_get_result, "the City Council has a manifold plan to beautify the city");    // 计算相似度， 不记录比较时间
        decimal rate = stringcompute1.ComputeResult.Rate;         // 相似度百分之几，完全匹配相似度为1
        rate = rate * 100;
        NPC05_Mission_Flowchart.SetStringVariable("Similarity_percentage", rate.ToString("#0.00") + "%");
        NPC05_Mission_Flowchart.SetFloatVariable("Similarity", (float)rate);
        if ((float)rate > Accuracy.accuracy[5,0])
        {
            Accuracy.accuracy[5,0] = (float)rate;
            Accuracy.isChange = true;
        }
        WWWForm Form = new WWWForm();
        WWW WWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=6" + "&Mission_State=1" + "&Accuracy=" + (float)rate + "&Star=" + Star.JudgePerformance_ReturnStar((float)rate));
        if (WWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }

        CountResult("The City Council has a manifold plan to beautify the city", (float)rate, MissionStatus.Learning);
    }
    public void SimilarityBeautify2()
    {
        StringCompute stringcompute1 = new StringCompute();
        stringcompute1.SpeedyCompute(Beautify_get_result, "we should spare no effort to beautify our environment");    // 计算相似度， 不记录比较时间
        decimal rate = stringcompute1.ComputeResult.Rate;         // 相似度百分之几，完全匹配相似度为1
        rate = rate * 100;
        NPC05_Mission_Flowchart.SetStringVariable("Similarity_percentage", rate.ToString("#0.00") + "%");
        NPC05_Mission_Flowchart.SetFloatVariable("Similarity", (float)rate);
        if ((float)rate > Accuracy.accuracy[5,1])
        {
            Accuracy.accuracy[5,1] = (float)rate;
            Accuracy.isChange = true;
        }
        WWWForm Form = new WWWForm();
        WWW WWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=6" + "&Mission_State=2" + "&Accuracy=" + (float)rate + "&Star=" + Star.JudgePerformance_ReturnStar((float)rate));
        if (WWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }

        CountResult("We should spare no effort to beautify our environment", (float)rate, MissionStatus.Learning);
    }
    public void SimilarityBeautify3()
    {
        StringCompute stringcompute1 = new StringCompute();
        stringcompute1.SpeedyCompute(Beautify_get_result, "planting flowers along the boulevards will help to beautify the town");    // 计算相似度， 不记录比较时间
        decimal rate = stringcompute1.ComputeResult.Rate;         // 相似度百分之几，完全匹配相似度为1
        rate = rate * 100;
        NPC05_Mission_Flowchart.SetStringVariable("Similarity_percentage", rate.ToString("#0.00") + "%");
        NPC05_Mission_Flowchart.SetFloatVariable("Similarity", (float)rate);
        if ((float)rate > Accuracy.accuracy[5,2])
        {
            Accuracy.accuracy[5,2] = (float)rate;
            Accuracy.isChange = true;
        }
        WWWForm Form = new WWWForm();
        WWW WWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=6" + "&Mission_State=3" + "&Accuracy=" + (float)rate + "&Star=" + Star.JudgePerformance_ReturnStar((float)rate));
        if (WWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }

        CountResult("Planting flowers along the boulevards will help to beautify the town", (float)rate, MissionStatus.Learning);
    }
    public void SimilarityDrain1()
    {
        StringCompute stringcompute1 = new StringCompute();
        stringcompute1.SpeedyCompute(Mix_get_result, "the water will soon drain away");    // 计算相似度， 不记录比较时间
        decimal rate = stringcompute1.ComputeResult.Rate;         // 相似度百分之几，完全匹配相似度为1
        rate = rate * 100;
        Mission_NPC1208101711Flowchart.SetStringVariable("Similarity_percentage", rate.ToString("#0.00") + "%");
        Mission_NPC1208101711Flowchart.SetFloatVariable("Similarity", (float)rate);
        if ((float)rate > Accuracy.accuracy[6,0])
        {
            Accuracy.accuracy[6,0] = (float)rate;
            Accuracy.isChange = true;
        }
        WWWForm Form = new WWWForm();
        WWW WWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=7" + "&Mission_State=1" + "&Accuracy=" + (float)rate + "&Star=" + Star.JudgePerformance_ReturnStar((float)rate));
        if (WWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }

        CountResult("The water will soon drain away", (float)rate, MissionStatus.Learning);
    }
    public void SimilarityDrain2()
    {
        StringCompute stringcompute1 = new StringCompute();
        stringcompute1.SpeedyCompute(Mix_get_result, "clogged pipes caused drain water to back up into the room");    // 计算相似度， 不记录比较时间
        decimal rate = stringcompute1.ComputeResult.Rate;         // 相似度百分之几，完全匹配相似度为1
        rate = rate * 100;
        Mission_NPC1208101711Flowchart.SetStringVariable("Similarity_percentage", rate.ToString("#0.00") + "%");
        Mission_NPC1208101711Flowchart.SetFloatVariable("Similarity", (float)rate);
        if ((float)rate > Accuracy.accuracy[6,1])
        {
            Accuracy.accuracy[6,1] = (float)rate;
            Accuracy.isChange = true;
        }
        WWWForm Form = new WWWForm();
        WWW WWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=7" + "&Mission_State=2" + "&Accuracy=" + (float)rate + "&Star=" + Star.JudgePerformance_ReturnStar((float)rate));
        if (WWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }

        CountResult("Clogged pipes caused drain water to back up into the room", (float)rate, MissionStatus.Learning);
    }
    public void SimilarityDrain3()
    {
        StringCompute stringcompute1 = new StringCompute();
        stringcompute1.SpeedyCompute(Mix_get_result, "the company was still going down the drain");    // 计算相似度， 不记录比较时间
        decimal rate = stringcompute1.ComputeResult.Rate;         // 相似度百分之几，完全匹配相似度为1
        rate = rate * 100;
        Mission_NPC1208101711Flowchart.SetStringVariable("Similarity_percentage", rate.ToString("#0.00") + "%");
        Mission_NPC1208101711Flowchart.SetFloatVariable("Similarity", (float)rate);
        if ((float)rate > Accuracy.accuracy[6,2])
        {
            Accuracy.accuracy[6,2] = (float)rate;
            Accuracy.isChange = true;
        }
        WWWForm Form = new WWWForm();
        WWW WWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=7" + "&Mission_State=3" + "&Accuracy=" + (float)rate + "&Star=" + Star.JudgePerformance_ReturnStar((float)rate));
        if (WWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }

        CountResult("The company was still going down the drain", (float)rate, MissionStatus.Learning);
    }
    public void SimilarityConcentration1()
    {
        StringCompute stringcompute1 = new StringCompute();
        stringcompute1.SpeedyCompute(Concentration_get_result, "there is a heavy concentration of troops in the area");    // 计算相似度， 不记录比较时间
        decimal rate = stringcompute1.ComputeResult.Rate;         // 相似度百分之几，完全匹配相似度为1
        rate = rate * 100;
        Concentration_Mission_Flowchart.SetStringVariable("Similarity_percentage", rate.ToString("#0.00") + "%");
        Concentration_Mission_Flowchart.SetFloatVariable("Similarity", (float)rate);
        if ((float)rate > Accuracy.accuracy[7,0])
        {
            Accuracy.accuracy[7,0] = (float)rate;
            Accuracy.isChange = true;
        }
        WWWForm Form = new WWWForm();
        WWW WWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=8" + "&Mission_State=1" + "&Accuracy=" + (float)rate + "&Star=" + Star.JudgePerformance_ReturnStar((float)rate));
        if (WWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }

        CountResult("There is a heavy concentration of troops in the area", (float)rate, MissionStatus.Learning);
    }
    public void SimilarityConcentration2()
    {
        StringCompute stringcompute1 = new StringCompute();
        stringcompute1.SpeedyCompute(Concentration_get_result, "i knew that concentration was the first requirement for learning");    // 计算相似度， 不记录比较时间
        decimal rate = stringcompute1.ComputeResult.Rate;         // 相似度百分之几，完全匹配相似度为1
        rate = rate * 100;
        Concentration_Mission_Flowchart.SetStringVariable("Similarity_percentage", rate.ToString("#0.00") + "%");
        Concentration_Mission_Flowchart.SetFloatVariable("Similarity", (float)rate);
        if ((float)rate > Accuracy.accuracy[7,1])
        {
            Accuracy.accuracy[7,1] = (float)rate;
            Accuracy.isChange = true;
        }
        WWWForm Form = new WWWForm();
        WWW WWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=8" + "&Mission_State=2" + "&Accuracy=" + (float)rate + "&Star=" + Star.JudgePerformance_ReturnStar((float)rate));
        if (WWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }

        CountResult("I knew that concentration was the first requirement for learning", (float)rate, MissionStatus.Learning);
    }
    public void SimilarityConcentration3()
    {
        StringCompute stringcompute1 = new StringCompute();
        stringcompute1.SpeedyCompute(Concentration_get_result, "this book requires a great deal of concentration");    // 计算相似度， 不记录比较时间
        decimal rate = stringcompute1.ComputeResult.Rate;         // 相似度百分之几，完全匹配相似度为1
        rate = rate * 100;
        Concentration_Mission_Flowchart.SetStringVariable("Similarity_percentage", rate.ToString("#0.00") + "%");
        Concentration_Mission_Flowchart.SetFloatVariable("Similarity", (float)rate);
        if ((float)rate > Accuracy.accuracy[7,2])
        {
            Accuracy.accuracy[7,2] = (float)rate;
            Accuracy.isChange = true;
        }
        WWWForm Form = new WWWForm();
        WWW WWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=8" + "&Mission_State=3" + "&Accuracy=" + (float)rate + "&Star=" + Star.JudgePerformance_ReturnStar((float)rate));
        if (WWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }

        CountResult("This book requires a great deal of concentration", (float)rate, MissionStatus.Learning);
    }
    public void SimilarityEcological1()
    {
        StringCompute stringcompute1 = new StringCompute();
        stringcompute1.SpeedyCompute(Ecological_get_result, "it is an ecological disaster with no parallel anywhere else in the world");    // 计算相似度， 不记录比较时间
        decimal rate = stringcompute1.ComputeResult.Rate;         // 相似度百分之几，完全匹配相似度为1
        rate = rate * 100;
        Mission_Ecological_corridors_Flowchart.SetStringVariable("Similarity_percentage", rate.ToString("#0.00") + "%");
        Mission_Ecological_corridors_Flowchart.SetFloatVariable("Similarity", (float)rate);
        if ((float)rate > Accuracy.accuracy[8,0])
        {
            Accuracy.accuracy[8,0] = (float)rate;
            Accuracy.isChange = true;
        }
        WWWForm Form = new WWWForm();
        WWW WWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=9" + "&Mission_State=1" + "&Accuracy=" + (float)rate + "&Star=" + Star.JudgePerformance_ReturnStar((float)rate));
        if (WWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }

        CountResult("It is an ecological disaster with no parallel anywhere else in the world", (float)rate, MissionStatus.Learning);
    }
    public void SimilarityEcological2()
    {
        StringCompute stringcompute1 = new StringCompute();
        stringcompute1.SpeedyCompute(Ecological_get_result, "the region has been declared an ecological disaster zone");    // 计算相似度， 不记录比较时间
        decimal rate = stringcompute1.ComputeResult.Rate;         // 相似度百分之几，完全匹配相似度为1
        rate = rate * 100;
        Mission_Ecological_corridors_Flowchart.SetStringVariable("Similarity_percentage", rate.ToString("#0.00") + "%");
        Mission_Ecological_corridors_Flowchart.SetFloatVariable("Similarity", (float)rate);
        if ((float)rate > Accuracy.accuracy[8,1])
        {
            Accuracy.accuracy[8,1] = (float)rate;
            Accuracy.isChange = true;
        }

        WWWForm Form = new WWWForm();
        WWW WWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=9" + "&Mission_State=2" + "&Accuracy=" + (float)rate + "&Star=" + Star.JudgePerformance_ReturnStar((float)rate));
        Debug.Log("紀錄");
        if (WWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }

        CountResult("The region has been declared an ecological disaster zone", (float)rate, MissionStatus.Learning);


    }
    public void SimilarityEcological3()
    {
        StringCompute stringcompute1 = new StringCompute();
        stringcompute1.SpeedyCompute(Ecological_get_result, "fire prevents ecological succession in the open habitat where the plant grows");    // 计算相似度， 不记录比较时间
        decimal rate = stringcompute1.ComputeResult.Rate;         // 相似度百分之几，完全匹配相似度为1
        rate = rate * 100;
        Mission_Ecological_corridors_Flowchart.SetStringVariable("Similarity_percentage", rate.ToString("#0.00") + "%");
        Mission_Ecological_corridors_Flowchart.SetFloatVariable("Similarity", (float)rate);
        if ((float)rate > Accuracy.accuracy[8,2])
        {
            Accuracy.accuracy[8,2] = (float)rate;
            Accuracy.isChange = true;
        }
        WWWForm Form = new WWWForm();
        WWW WWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=9" + "&Mission_State=3" + "&Accuracy=" + (float)rate + "&Star=" + Star.JudgePerformance_ReturnStar((float)rate));
        if (WWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }

        CountResult("Fire prevents ecological succession in the open habitat where the plant grows", (float)rate, MissionStatus.Learning);
    }
    public void SimilarityPicturesque1()
    {
        StringCompute stringcompute1 = new StringCompute();
        stringcompute1.SpeedyCompute(Picturesque_get_result, "you can see the picturesque shores beside the river");    // 计算相似度， 不记录比较时间
        decimal rate = stringcompute1.ComputeResult.Rate;         // 相似度百分之几，完全匹配相似度为1
        rate = rate * 100;
        Mission_Picturesque_Flowchart.SetStringVariable("Similarity_percentage", rate.ToString("#0.00") + "%");
        Mission_Picturesque_Flowchart.SetFloatVariable("Similarity", (float)rate);
        if ((float)rate > Accuracy.accuracy[9,0])
        {
            Accuracy.accuracy[9,0] = (float)rate;
            Accuracy.isChange = true;
        }
        WWWForm Form = new WWWForm();
        WWW WWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=10" + "&Mission_State=1" + "&Accuracy=" + (float)rate + "&Star=" + Star.JudgePerformance_ReturnStar((float)rate));
        if (WWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }

        CountResult("You can see the picturesque shores beside the river", (float)rate, MissionStatus.Learning);
    }
    public void SimilarityPicturesque2()
    {
        StringCompute stringcompute1 = new StringCompute();
        stringcompute1.SpeedyCompute(Picturesque_get_result, "last night the scenery was striking and picturesque");    // 计算相似度， 不记录比较时间
        decimal rate = stringcompute1.ComputeResult.Rate;         // 相似度百分之几，完全匹配相似度为1
        rate = rate * 100;
        Mission_Picturesque_Flowchart.SetStringVariable("Similarity_percentage", rate.ToString("#0.00") + "%");
        Mission_Picturesque_Flowchart.SetFloatVariable("Similarity", (float)rate);
        if ((float)rate > Accuracy.accuracy[9,1])
        {
            Accuracy.accuracy[9,1] = (float)rate;
            Accuracy.isChange = true;
        }
        WWWForm Form = new WWWForm();
        WWW WWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=10" + "&Mission_State=2" + "&Accuracy=" + (float)rate + "&Star=" + Star.JudgePerformance_ReturnStar((float)rate));
        if (WWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }

        CountResult("Last night the scenery was striking and picturesque", (float)rate, MissionStatus.Learning);
    }
    public void SimilarityPicturesque3()
    {
        StringCompute stringcompute1 = new StringCompute();
        stringcompute1.SpeedyCompute(Picturesque_get_result, "i was impressed by the picturesque style of this building");    // 计算相似度， 不记录比较时间
        decimal rate = stringcompute1.ComputeResult.Rate;         // 相似度百分之几，完全匹配相似度为1
        rate = rate * 100;
        Mission_Picturesque_Flowchart.SetStringVariable("Similarity_percentage", rate.ToString("#0.00") + "%");
        Mission_Picturesque_Flowchart.SetFloatVariable("Similarity", (float)rate);
        if ((float)rate > Accuracy.accuracy[9,2])
        {
            Accuracy.accuracy[9,2] = (float)rate;
            Accuracy.isChange = true;
        }
        WWWForm Form = new WWWForm();
        WWW WWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=10" + "&Mission_State=3" + "&Accuracy=" + (float)rate + "&Star=" + Star.JudgePerformance_ReturnStar((float)rate));
        if (WWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }

        CountResult("I was impressed by the picturesque style of this building", (float)rate, MissionStatus.Learning);
    }
    public void SimilarityAquatic1()
    {
        StringCompute stringcompute1 = new StringCompute();
        stringcompute1.SpeedyCompute(Mix_get_result, "aquatic sports include swimming and rowing");    // 计算相似度， 不记录比较时间
        decimal rate = stringcompute1.ComputeResult.Rate;         // 相似度百分之几，完全匹配相似度为1
        rate = rate * 100;
        Mission_NPC1208101711Flowchart.SetStringVariable("Similarity_percentage", rate.ToString("#0.00") + "%");
        Mission_NPC1208101711Flowchart.SetFloatVariable("Similarity", (float)rate);
        if ((float)rate > Accuracy.accuracy[10,0])
        {
            Accuracy.accuracy[10,0] = (float)rate;
            Accuracy.isChange = true;
        }
        WWWForm Form = new WWWForm();
        WWW WWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=11" + "&Mission_State=1" + "&Accuracy=" + (float)rate + "&Star=" + Star.JudgePerformance_ReturnStar((float)rate));
        if (WWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }

        CountResult("Aquatic sports include swimming and rowing", (float)rate, MissionStatus.Learning);
    }
    public void SimilarityAquatic2()
    {
        StringCompute stringcompute1 = new StringCompute();
        stringcompute1.SpeedyCompute(Mix_get_result, "aquatic food chains are different from terrestrial ones");    // 计算相似度， 不记录比较时间
        decimal rate = stringcompute1.ComputeResult.Rate;         // 相似度百分之几，完全匹配相似度为1
        rate = rate * 100;
        Mission_NPC1208101711Flowchart.SetStringVariable("Similarity_percentage", rate.ToString("#0.00") + "%");
        Mission_NPC1208101711Flowchart.SetFloatVariable("Similarity", (float)rate);
        if ((float)rate > Accuracy.accuracy[10,1])
        {
            Accuracy.accuracy[10,1] = (float)rate;
            Accuracy.isChange = true;
        }
        WWWForm Form = new WWWForm();
        WWW WWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=11" + "&Mission_State=2" + "&Accuracy=" + (float)rate + "&Star=" + Star.JudgePerformance_ReturnStar((float)rate));
        if (WWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }

        CountResult("Aquatic food chains are different from terrestrial ones", (float)rate, MissionStatus.Learning);
    }
    public void SimilarityAquatic3()
    {
        StringCompute stringcompute1 = new StringCompute();
        stringcompute1.SpeedyCompute(Mix_get_result, "certain species of aquatic animals are capable of producing physiological shocks");    // 计算相似度， 不记录比较时间
        decimal rate = stringcompute1.ComputeResult.Rate;         // 相似度百分之几，完全匹配相似度为1
        rate = rate * 100;
        Mission_NPC1208101711Flowchart.SetStringVariable("Similarity_percentage", rate.ToString("#0.00") + "%");
        Mission_NPC1208101711Flowchart.SetFloatVariable("Similarity", (float)rate);
        if ((float)rate > Accuracy.accuracy[10,2])
        {
            Accuracy.accuracy[10,2] = (float)rate;
            Accuracy.isChange = true;
        }
        WWWForm Form = new WWWForm();
        WWW WWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=11" + "&Mission_State=3" + "&Accuracy=" + (float)rate + "&Star=" + Star.JudgePerformance_ReturnStar((float)rate));
        if (WWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }

        CountResult("Certain species of aquatic animals are capable of producing physiological shocks", (float)rate, MissionStatus.Learning);
    }
    public void SimilarityLandscaping1()
    {
        StringCompute stringcompute1 = new StringCompute();
        stringcompute1.SpeedyCompute(Mix_get_result, "the landowner insisted on a high standard of landscaping");    // 计算相似度， 不记录比较时间
        decimal rate = stringcompute1.ComputeResult.Rate;         // 相似度百分之几，完全匹配相似度为1
        rate = rate * 100;
        Mission_NPC1208101711Flowchart.SetStringVariable("Similarity_percentage", rate.ToString("#0.00") + "%");
        Mission_NPC1208101711Flowchart.SetFloatVariable("Similarity", (float)rate);
        if ((float)rate > Accuracy.accuracy[11,0])
        {
            Accuracy.accuracy[11,0] = (float)rate;
            Accuracy.isChange = true;
        }
        WWWForm Form = new WWWForm();
        WWW WWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=12" + "&Mission_State=1" + "&Accuracy=" + (float)rate + "&Star=" + Star.JudgePerformance_ReturnStar((float)rate));
        if (WWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }

        CountResult("The landowner insisted on a high standard of landscaping", (float)rate, MissionStatus.Learning);
    }
    public void SimilarityLandscaping2()
    {
        StringCompute stringcompute1 = new StringCompute();
        stringcompute1.SpeedyCompute(Mix_get_result, "landscaping will be used for leisure or irrigated as agricultural land");    // 计算相似度， 不记录比较时间
        decimal rate = stringcompute1.ComputeResult.Rate;         // 相似度百分之几，完全匹配相似度为1
        rate = rate * 100;
        Mission_NPC1208101711Flowchart.SetStringVariable("Similarity_percentage", rate.ToString("#0.00") + "%");
        Mission_NPC1208101711Flowchart.SetFloatVariable("Similarity", (float)rate);
        if ((float)rate > Accuracy.accuracy[11,1])
        {
            Accuracy.accuracy[11,1] = (float)rate;
            Accuracy.isChange = true;
        }
        WWWForm Form = new WWWForm();
        WWW WWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=12" + "&Mission_State=2" + "&Accuracy=" + (float)rate + "&Star=" + Star.JudgePerformance_ReturnStar((float)rate));
        if (WWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }

        CountResult("Landscaping will be used for leisure or irrigated as agricultural land", (float)rate, MissionStatus.Learning);
    }
    public void SimilarityLandscaping3()
    {
        StringCompute stringcompute1 = new StringCompute();
        stringcompute1.SpeedyCompute(Mix_get_result, "the flooring and landscaping will be done by the contractor");    // 计算相似度， 不记录比较时间
        decimal rate = stringcompute1.ComputeResult.Rate;         // 相似度百分之几，完全匹配相似度为1
        rate = rate * 100;
        Mission_NPC1208101711Flowchart.SetStringVariable("Similarity_percentage", rate.ToString("#0.00") + "%");
        Mission_NPC1208101711Flowchart.SetFloatVariable("Similarity", (float)rate);
        if ((float)rate > Accuracy.accuracy[11,2])
        {
            Accuracy.accuracy[11,2] = (float)rate;
            Accuracy.isChange = true;
        }
        WWWForm Form = new WWWForm();
        WWW WWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=12" + "&Mission_State=3" + "&Accuracy=" + (float)rate + "&Star=" + Star.JudgePerformance_ReturnStar((float)rate));
        if (WWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }

        CountResult("The flooring and landscaping will be done by the contractor", (float)rate, MissionStatus.Learning);
    }
    public void SimilarityBiodiversity1()
    {
        StringCompute stringcompute1 = new StringCompute();
        stringcompute1.SpeedyCompute(Mix_get_result, "butterflies are indicators of the biodiversity of our natural environment");    // 计算相似度， 不记录比较时间
        decimal rate = stringcompute1.ComputeResult.Rate;         // 相似度百分之几，完全匹配相似度为1
        rate = rate * 100;
        Mission_NPC1208101711Flowchart.SetStringVariable("Similarity_percentage", rate.ToString("#0.00") + "%");
        Mission_NPC1208101711Flowchart.SetFloatVariable("Similarity", (float)rate);
        if ((float)rate > Accuracy.accuracy[12,0])
        {
            Accuracy.accuracy[12,0] = (float)rate;
            Accuracy.isChange = true;
        }
        WWWForm Form = new WWWForm();
        WWW WWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=13" + "&Mission_State=1" + "&Accuracy=" + (float)rate + "&Star=" + Star.JudgePerformance_ReturnStar((float)rate));
        if (WWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }

        CountResult("Butterflies are indicators of the biodiversity of our natural environment", (float)rate, MissionStatus.Learning);
    }
    public void SimilarityBiodiversity2()
    {
        StringCompute stringcompute1 = new StringCompute();
        stringcompute1.SpeedyCompute(Mix_get_result, "we are on the verge of a major biodiversity crisis");    // 计算相似度， 不记录比较时间
        decimal rate = stringcompute1.ComputeResult.Rate;         // 相似度百分之几，完全匹配相似度为1
        rate = rate * 100;
        Mission_NPC1208101711Flowchart.SetStringVariable("Similarity_percentage", rate.ToString("#0.00") + "%");
        Mission_NPC1208101711Flowchart.SetFloatVariable("Similarity", (float)rate);
        if ((float)rate > Accuracy.accuracy[12,1])
        {
            Accuracy.accuracy[12,1] = (float)rate;
            Accuracy.isChange = true;
        }
        WWWForm Form = new WWWForm();
        WWW WWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=13" + "&Mission_State=2" + "&Accuracy=" + (float)rate + "&Star=" + Star.JudgePerformance_ReturnStar((float)rate));
        if (WWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }

        CountResult("We are on the verge of a major biodiversity crisis", (float)rate, MissionStatus.Learning);
    }
    public void SimilarityBiodiversity3()
    {
        StringCompute stringcompute1 = new StringCompute();
        stringcompute1.SpeedyCompute(Mix_get_result, "the protection of biodiversity has been  the focus of agricultural research for years");    // 计算相似度， 不记录比较时间
        decimal rate = stringcompute1.ComputeResult.Rate;         // 相似度百分之几，完全匹配相似度为1
        rate = rate * 100;
        Mission_NPC1208101711Flowchart.SetStringVariable("Similarity_percentage", rate.ToString("#0.00") + "%");
        Mission_NPC1208101711Flowchart.SetFloatVariable("Similarity", (float)rate);
        if ((float)rate > Accuracy.accuracy[12,2])
        {
            Accuracy.accuracy[12,2] = (float)rate;
            Accuracy.isChange = true;
        }
        WWWForm Form = new WWWForm();
        WWW WWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=13" + "&Mission_State=3" + "&Accuracy=" + (float)rate + "&Star=" + Star.JudgePerformance_ReturnStar((float)rate));
        if (WWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }

        CountResult("The protection of biodiversity has been  the focus of agricultural research for years", (float)rate, MissionStatus.Learning);
    }
    public void SimilarityAmphibian1()
    {
        StringCompute stringcompute1 = new StringCompute();
        stringcompute1.SpeedyCompute(Mix_get_result, "both the toad and frog are amphibian");    // 计算相似度， 不记录比较时间
        decimal rate = stringcompute1.ComputeResult.Rate;         // 相似度百分之几，完全匹配相似度为1
        rate = rate * 100;
        Mission_NPC1208101711Flowchart.SetStringVariable("Similarity_percentage", rate.ToString("#0.00") + "%");
        Mission_NPC1208101711Flowchart.SetFloatVariable("Similarity", (float)rate);
        if ((float)rate > Accuracy.accuracy[13,0])
        {
            Accuracy.accuracy[13,0] = (float)rate;
            Accuracy.isChange = true;
        }
        WWWForm Form = new WWWForm();
        WWW WWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=14" + "&Mission_State=1" + "&Accuracy=" + (float)rate + "&Star=" + Star.JudgePerformance_ReturnStar((float)rate));
        if (WWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }

        CountResult("Both the toad and frog are amphibian", (float)rate, MissionStatus.Learning);
    }
    public void SimilarityAmphibian2()
    {
        StringCompute stringcompute1 = new StringCompute();
        stringcompute1.SpeedyCompute(Mix_get_result, "amphibians live partly in water and partly on land");    // 计算相似度， 不记录比较时间
        decimal rate = stringcompute1.ComputeResult.Rate;         // 相似度百分之几，完全匹配相似度为1
        rate = rate * 100;
        Mission_NPC1208101711Flowchart.SetStringVariable("Similarity_percentage", rate.ToString("#0.00") + "%");
        Mission_NPC1208101711Flowchart.SetFloatVariable("Similarity", (float)rate);
        if ((float)rate > Accuracy.accuracy[13,1])
        {
            Accuracy.accuracy[13,1] = (float)rate;
            Accuracy.isChange = true;
        }
        WWWForm Form = new WWWForm();
        WWW WWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=14" + "&Mission_State=2" + "&Accuracy=" + (float)rate + "&Star=" + Star.JudgePerformance_ReturnStar((float)rate));
        if (WWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }

        CountResult("Amphibians live partly in water and partly on land", (float)rate, MissionStatus.Learning);
    }
    public void SimilarityAmphibian3()
    {
        StringCompute stringcompute1 = new StringCompute();
        stringcompute1.SpeedyCompute(Mix_get_result, "all amphibians begin their life in water with gills and tails");    // 计算相似度， 不记录比较时间
        decimal rate = stringcompute1.ComputeResult.Rate;         // 相似度百分之几，完全匹配相似度为1
        rate = rate * 100;
        Mission_NPC1208101711Flowchart.SetStringVariable("Similarity_percentage", rate.ToString("#0.00") + "%");
        Mission_NPC1208101711Flowchart.SetFloatVariable("Similarity", (float)rate);
        if ((float)rate > Accuracy.accuracy[13,2])
        {
            Accuracy.accuracy[13,2] = (float)rate;
            Accuracy.isChange = true;
        }
        WWWForm Form = new WWWForm();
        WWW WWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=14" + "&Mission_State=3" + "&Accuracy=" + (float)rate + "&Star=" + Star.JudgePerformance_ReturnStar((float)rate));
        if (WWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }

        CountResult("All amphibians begin their life in water with gills and tails", (float)rate, MissionStatus.Learning);
    }
    public void PracticeSimilaritySerene1()
    {
        StringCompute stringcompute1 = new StringCompute();
        stringcompute1.SpeedyCompute(Serene_get_result, "you will see a serene skies and a bright blue lake out there");    // 计算相似度， 不记录比较时间
        decimal rate = stringcompute1.ComputeResult.Rate;         // 相似度百分之几，完全匹配相似度为1
        rate = rate * 100;
        FightFlowchart.SetStringVariable("Similarity_percentage", rate.ToString("#0.00") + "%");
        FightFlowchart.SetFloatVariable("Similarity", (float)rate);
        if ((float)rate > Accuracy.accuracy[0,0])
        {
            Accuracy.accuracy[0,0] = (float)rate;
            Accuracy.isChange = true;
        }
        WWWForm Form = new WWWForm();
        WWW WWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=15" + "&Mission_State=1" + "&Accuracy=" + (float)rate + "&Star=" + Star.JudgePerformance_ReturnStar((float)rate));
        if (WWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }

        CountResult("You will see a serene skies and a bright blue lake out there", (float)rate, MissionStatus.Practice);
    }
    public void PracticeSimilaritySerene2()
    {
        StringCompute stringcompute1 = new StringCompute();
        stringcompute1.SpeedyCompute(Serene_get_result, "love helps us stay calm and serene even when things are tough");    // 计算相似度， 不记录比较时间
        decimal rate = stringcompute1.ComputeResult.Rate;         // 相似度百分之几，完全匹配相似度为1
        rate = rate * 100;
        FightFlowchart.SetStringVariable("Similarity_percentage", rate.ToString("#0.00") + "%");
        FightFlowchart.SetFloatVariable("Similarity", (float)rate);
        if ((float)rate > Accuracy.accuracy[0,1])
        {
            Accuracy.accuracy[0,1] = (float)rate;
            Accuracy.isChange = true;
        }
        WWWForm Form = new WWWForm();
        WWW WWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=15" + "&Mission_State=2" + "&Accuracy=" + (float)rate + "&Star=" + Star.JudgePerformance_ReturnStar((float)rate));
        if (WWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }

        CountResult("Love helps us stay calm and serene even when things are tough", (float)rate, MissionStatus.Practice);
    }
    public void PracticeSimilaritySerene3()
    {
        StringCompute stringcompute1 = new StringCompute();
        stringcompute1.SpeedyCompute(Serene_get_result, "this is the perfect place to slowly unwind in serene rural surroundings");    // 计算相似度， 不记录比较时间
        decimal rate = stringcompute1.ComputeResult.Rate;         // 相似度百分之几，完全匹配相似度为1
        rate = rate * 100;
        FightFlowchart.SetStringVariable("Similarity_percentage", rate.ToString("#0.00") + "%");
        FightFlowchart.SetFloatVariable("Similarity", (float)rate);
        if ((float)rate > Accuracy.accuracy[0,2])
        {
            Accuracy.accuracy[0,2] = (float)rate;
            Accuracy.isChange = true;
        }
        WWWForm Form = new WWWForm();
        WWW WWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=15" + "&Mission_State=3" + "&Accuracy=" + (float)rate + "&Star=" + Star.JudgePerformance_ReturnStar((float)rate));
        if (WWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }

        CountResult("This is the perfect place to slowly unwind in serene rural surroundings", (float)rate, MissionStatus.Practice);
    }
    public void PracticeSimilarityThoughtful1()
    {
        StringCompute stringcompute1 = new StringCompute();
        stringcompute1.SpeedyCompute(Thoughtful_get_result, "the book is a thoughtful account of his journeys in taiwan");    // 计算相似度， 不记录比较时间
        decimal rate = stringcompute1.ComputeResult.Rate;         // 相似度百分之几，完全匹配相似度为1
        rate = rate * 100;
        FightFlowchart.SetStringVariable("Similarity_percentage", rate.ToString("#0.00") + "%");
        FightFlowchart.SetFloatVariable("Similarity", (float)rate);
        if ((float)rate > Accuracy.accuracy[1,0])
        {
            Accuracy.accuracy[1,0] = (float)rate;
            Accuracy.isChange = true;
        }
        WWWForm Form = new WWWForm();
        WWW WWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=16" + "&Mission_State=1" + "&Accuracy=" + (float)rate + "&Star=" + Star.JudgePerformance_ReturnStar((float)rate));
        if (WWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }

        CountResult("The book is a thoughtful account of his journeys in taiwan", (float)rate,MissionStatus.Practice);
    }
    public void PracticeSimilarityThoughtful2()
    {
        StringCompute stringcompute1 = new StringCompute();
        stringcompute1.SpeedyCompute(Thoughtful_get_result, "it is very thoughtful of you to bring me the book");    // 计算相似度， 不记录比较时间
        decimal rate = stringcompute1.ComputeResult.Rate;         // 相似度百分之几，完全匹配相似度为1
        rate = rate * 100;
        FightFlowchart.SetStringVariable("Similarity_percentage", rate.ToString("#0.00") + "%");
        FightFlowchart.SetFloatVariable("Similarity", (float)rate);
        if ((float)rate > Accuracy.accuracy[1,1])
        {
            Accuracy.accuracy[1,1] = (float)rate;
            Accuracy.isChange = true;
        }
        WWWForm Form = new WWWForm();
        WWW WWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=16" + "&Mission_State=2" + "&Accuracy=" + (float)rate + "&Star=" + Star.JudgePerformance_ReturnStar((float)rate));
        if (WWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }

        CountResult("It is very thoughtful of you to bring me the book", (float)rate, MissionStatus.Practice);
    }
    public void PracticeSimilarityThoughtful3()
    {
        StringCompute stringcompute1 = new StringCompute();
        stringcompute1.SpeedyCompute(Thoughtful_get_result, "you should be more thoughtful about how to manage your time");    // 计算相似度， 不记录比较时间
        decimal rate = stringcompute1.ComputeResult.Rate;         // 相似度百分之几，完全匹配相似度为1
        rate = rate * 100;
        FightFlowchart.SetStringVariable("Similarity_percentage", rate.ToString("#0.00") + "%");
        FightFlowchart.SetFloatVariable("Similarity", (float)rate);
        if ((float)rate > Accuracy.accuracy[1,2])
        {
            Accuracy.accuracy[1,2] = (float)rate;
            Accuracy.isChange = true;
        }
        WWWForm Form = new WWWForm();
        WWW WWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=16" + "&Mission_State=3" + "&Accuracy=" + (float)rate + "&Star=" + Star.JudgePerformance_ReturnStar((float)rate));
        if (WWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }

        CountResult("You should be more thoughtful about how to manage your time", (float)rate, MissionStatus.Practice);
    }
    public void PracticeSimilaritySubsidy1()
    {
        StringCompute stringcompute1 = new StringCompute();
        stringcompute1.SpeedyCompute(Subsidy_get_result, "there were also pledges to soften the impact of the subsidy cuts on the poorer regions");    // 计算相似度， 不记录比较时间
        decimal rate = stringcompute1.ComputeResult.Rate;         // 相似度百分之几，完全匹配相似度为1
        rate = rate * 100;
        FightFlowchart.SetStringVariable("Similarity_percentage", rate.ToString("#0.00") + "%");
        FightFlowchart.SetFloatVariable("Similarity", (float)rate);
        if ((float)rate > Accuracy.accuracy[2,0])
        {
            Accuracy.accuracy[2,0] = (float)rate;
            Accuracy.isChange = true;
        }
        WWWForm Form = new WWWForm();
        WWW WWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=17" + "&Mission_State=1" + "&Accuracy=" + (float)rate + "&Star=" + Star.JudgePerformance_ReturnStar((float)rate));
        if (WWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }

        CountResult("There were also pledges to soften the impact of the subsidy cuts on the poorer regions", (float)rate, MissionStatus.Practice);
    }
    public void PracticeSimilaritySubsidy2()
    {
        StringCompute stringcompute1 = new StringCompute();
        stringcompute1.SpeedyCompute(Subsidy_get_result, "they received a subsidy in the form of a percentage of all foreign trade operations");    // 计算相似度， 不记录比较时间
        decimal rate = stringcompute1.ComputeResult.Rate;         // 相似度百分之几，完全匹配相似度为1
        rate = rate * 100;
        FightFlowchart.SetStringVariable("Similarity_percentage", rate.ToString("#0.00") + "%");
        FightFlowchart.SetFloatVariable("Similarity", (float)rate);
        if ((float)rate > Accuracy.accuracy[2,1])
        {
            Accuracy.accuracy[2,1] = (float)rate;
            Accuracy.isChange = true;
        }
        WWWForm Form = new WWWForm();
        WWW WWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=17" + "&Mission_State=2" + "&Accuracy=" + (float)rate + "&Star=" + Star.JudgePerformance_ReturnStar((float)rate));
        if (WWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }

        CountResult("They received a subsidy in the form of a percentage of all foreign trade operations", (float)rate, MissionStatus.Practice);
    }
    public void PracticeSimilaritySubsidy3()
    {
        StringCompute stringcompute1 = new StringCompute();
        stringcompute1.SpeedyCompute(Subsidy_get_result, "the university will gain a subsidy for research in artificial intelligence");    // 计算相似度， 不记录比较时间
        decimal rate = stringcompute1.ComputeResult.Rate;         // 相似度百分之几，完全匹配相似度为1
        rate = rate * 100;
        FightFlowchart.SetStringVariable("Similarity_percentage", rate.ToString("#0.00") + "%");
        FightFlowchart.SetFloatVariable("Similarity", (float)rate); WWWForm Form = new WWWForm();
        if ((float)rate > Accuracy.accuracy[2,2])
        {
            Accuracy.accuracy[2,2] = (float)rate;
            Accuracy.isChange = true;
        }
        WWW WWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=17" + "&Mission_State=3" + "&Accuracy=" + (float)rate + "&Star=" + Star.JudgePerformance_ReturnStar((float)rate));
        if (WWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }

        CountResult("The university will gain a subsidy for research in artificial intelligence", (float)rate, MissionStatus.Practice);
    }
    public void PracticeSimilarityPurification1()
    {
        StringCompute stringcompute1 = new StringCompute();
        stringcompute1.SpeedyCompute(Purification_get_result, "the water goes through three stages of purification");    // 计算相似度， 不记录比较时间
        decimal rate = stringcompute1.ComputeResult.Rate;         // 相似度百分之几，完全匹配相似度为1
        rate = rate * 100;
        FightFlowchart.SetStringVariable("Similarity_percentage", rate.ToString("#0.00") + "%");
        FightFlowchart.SetFloatVariable("Similarity", (float)rate); WWWForm Form = new WWWForm();
        if ((float)rate > Accuracy.accuracy[3,0])
        {
            Accuracy.accuracy[3,0] = (float)rate;
            Accuracy.isChange = true;
        }
        WWW WWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=18" + "&Mission_State=1" + "&Accuracy=" + (float)rate + "&Star=" + Star.JudgePerformance_ReturnStar((float)rate));
        if (WWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }

        CountResult("The water goes through three stages of purification", (float)rate, MissionStatus.Practice);
    }
    public void PracticeSimilarityPurification2()
    {
        StringCompute stringcompute1 = new StringCompute();
        stringcompute1.SpeedyCompute(Purification_get_result, "reading a good book may bring purification to our souls");    // 计算相似度， 不记录比较时间
        decimal rate = stringcompute1.ComputeResult.Rate;         // 相似度百分之几，完全匹配相似度为1
        rate = rate * 100;
        FightFlowchart.SetStringVariable("Similarity_percentage", rate.ToString("#0.00") + "%");
        if ((float)rate > Accuracy.accuracy[3,1])
        {
            Accuracy.accuracy[3,1] = (float)rate;
            Accuracy.isChange = true;
        }
        FightFlowchart.SetFloatVariable("Similarity", (float)rate); WWWForm Form = new WWWForm();
        WWW WWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=18" + "&Mission_State=2" + "&Accuracy=" + (float)rate + "&Star=" + Star.JudgePerformance_ReturnStar((float)rate));
        if (WWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }

        CountResult("Reading a good book may bring purification to our souls", (float)rate, MissionStatus.Practice);
    }
    public void PracticeSimilarityPurification3()
    {
        StringCompute stringcompute1 = new StringCompute();
        stringcompute1.SpeedyCompute(Purification_get_result, "distillation has traditionally been the major system for water purification");    // 计算相似度， 不记录比较时间
        decimal rate = stringcompute1.ComputeResult.Rate;         // 相似度百分之几，完全匹配相似度为1
        rate = rate * 100;
        FightFlowchart.SetStringVariable("Similarity_percentage", rate.ToString("#0.00") + "%");
        FightFlowchart.SetFloatVariable("Similarity", (float)rate);
        if ((float)rate > Accuracy.accuracy[3,2])
        {
            Accuracy.accuracy[3,2] = (float)rate;
            Accuracy.isChange = true;
        }
        WWWForm Form = new WWWForm();
        WWW WWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=18" + "&Mission_State=3" + "&Accuracy=" + (float)rate + "&Star=" + Star.JudgePerformance_ReturnStar((float)rate));
        if (WWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }

        CountResult("Distillation has traditionally been the major system for water purification", (float)rate, MissionStatus.Practice);
    }
    public void PracticeSimilarityDetention1()
    {
        StringCompute stringcompute1 = new StringCompute();
        stringcompute1.SpeedyCompute(Detention_get_result, "the teacher kept the boys in detention after school");    // 计算相似度， 不记录比较时间
        decimal rate = stringcompute1.ComputeResult.Rate;         // 相似度百分之几，完全匹配相似度为1
        rate = rate * 100;
        FightFlowchart.SetStringVariable("Similarity_percentage", rate.ToString("#0.00") + "%");
        FightFlowchart.SetFloatVariable("Similarity", (float)rate);
        if ((float)rate > Accuracy.accuracy[4,0])
        {
            Accuracy.accuracy[4,0] = (float)rate;
            Accuracy.isChange = true;
        }
        WWWForm Form = new WWWForm();
        WWW WWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=19" + "&Mission_State=1" + "&Accuracy=" + (float)rate + "&Star=" + Star.JudgePerformance_ReturnStar((float)rate));
        if (WWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }

        CountResult("The teacher kept the boys in detention after school", (float)rate, MissionStatus.Practice);
    }
    public void PracticeSimilarityDetention2()
    {
        StringCompute stringcompute1 = new StringCompute();
        stringcompute1.SpeedyCompute(Detention_get_result, "she prefers to stay in detention rather than be released and go into exile");    // 计算相似度， 不记录比较时间
        decimal rate = stringcompute1.ComputeResult.Rate;         // 相似度百分之几，完全匹配相似度为1
        rate = rate * 100;
        FightFlowchart.SetStringVariable("Similarity_percentage", rate.ToString("#0.00") + "%");
        FightFlowchart.SetFloatVariable("Similarity", (float)rate);
        if ((float)rate > Accuracy.accuracy[4,1])
        {
            Accuracy.accuracy[4,1] = (float)rate;
            Accuracy.isChange = true;
        }
        WWWForm Form = new WWWForm();
        WWW WWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=19" + "&Mission_State=2" + "&Accuracy=" + (float)rate + "&Star=" + Star.JudgePerformance_ReturnStar((float)rate));
        if (WWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }

        CountResult("She prefers to stay in detention rather than be released and go into exile", (float)rate, MissionStatus.Practice);
    }
    public void PracticeSimilarityDetention3()
    {
        StringCompute stringcompute1 = new StringCompute();
        stringcompute1.SpeedyCompute(Detention_get_result, "they have been held in detention since the end of june");    // 计算相似度， 不记录比较时间
        decimal rate = stringcompute1.ComputeResult.Rate;         // 相似度百分之几，完全匹配相似度为1
        rate = rate * 100;
        FightFlowchart.SetStringVariable("Similarity_percentage", rate.ToString("#0.00") + "%");
        FightFlowchart.SetFloatVariable("Similarity", (float)rate);
        if ((float)rate > Accuracy.accuracy[4,2])
        {
            Accuracy.accuracy[4,2] = (float)rate;
            Accuracy.isChange = true;
        }
        WWWForm Form = new WWWForm();
        WWW WWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=19" + "&Mission_State=3" + "&Accuracy=" + (float)rate + "&Star=" + Star.JudgePerformance_ReturnStar((float)rate));
        if (WWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }

        CountResult("They have been held in detention since the end of june", (float)rate, MissionStatus.Practice);
    }
    public void PracticeSimilarityBeautify1()
    {
        StringCompute stringcompute1 = new StringCompute();
        stringcompute1.SpeedyCompute(Beautify_get_result, "the City Council has a manifold plan to beautify the city");    // 计算相似度， 不记录比较时间
        decimal rate = stringcompute1.ComputeResult.Rate;         // 相似度百分之几，完全匹配相似度为1
        rate = rate * 100;
        FightFlowchart.SetStringVariable("Similarity_percentage", rate.ToString("#0.00") + "%");
        FightFlowchart.SetFloatVariable("Similarity", (float)rate);
        if ((float)rate > Accuracy.accuracy[5,0])
        {
            Accuracy.accuracy[5,0] = (float)rate;
            Accuracy.isChange = true;
        }
        WWWForm Form = new WWWForm();
        WWW WWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=20" + "&Mission_State=1" + "&Accuracy=" + (float)rate + "&Star=" + Star.JudgePerformance_ReturnStar((float)rate));
        if (WWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }

        CountResult("The City Council has a manifold plan to beautify the city", (float)rate, MissionStatus.Practice);
    }
    public void PracticeSimilarityBeautify2()
    {
        StringCompute stringcompute1 = new StringCompute();
        stringcompute1.SpeedyCompute(Beautify_get_result, "we should spare no effort to beautify our environment");    // 计算相似度， 不记录比较时间
        decimal rate = stringcompute1.ComputeResult.Rate;         // 相似度百分之几，完全匹配相似度为1
        rate = rate * 100;
        FightFlowchart.SetStringVariable("Similarity_percentage", rate.ToString("#0.00") + "%");
        FightFlowchart.SetFloatVariable("Similarity", (float)rate);
        if ((float)rate > Accuracy.accuracy[5,1])
        {
            Accuracy.accuracy[5,1] = (float)rate;
            Accuracy.isChange = true;
        }
        WWWForm Form = new WWWForm();
        WWW WWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=20" + "&Mission_State=2" + "&Accuracy=" + (float)rate + "&Star=" + Star.JudgePerformance_ReturnStar((float)rate));
        if (WWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }

        CountResult("We should spare no effort to beautify our environment", (float)rate, MissionStatus.Practice);
    }
    public void PracticeSimilarityBeautify3()
    {
        StringCompute stringcompute1 = new StringCompute();
        stringcompute1.SpeedyCompute(Beautify_get_result, "planting flowers along the boulevards will help to beautify the town");    // 计算相似度， 不记录比较时间
        decimal rate = stringcompute1.ComputeResult.Rate;         // 相似度百分之几，完全匹配相似度为1
        rate = rate * 100;
        FightFlowchart.SetStringVariable("Similarity_percentage", rate.ToString("#0.00") + "%");
        FightFlowchart.SetFloatVariable("Similarity", (float)rate);
        if ((float)rate > Accuracy.accuracy[5,2])
        {
            Accuracy.accuracy[5,2] = (float)rate;
            Accuracy.isChange = true;
        }
        WWWForm Form = new WWWForm();
        WWW WWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=20" + "&Mission_State=3" + "&Accuracy=" + (float)rate + "&Star=" + Star.JudgePerformance_ReturnStar((float)rate));
        if (WWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }

        CountResult("Planting flowers along the boulevards will help to beautify the town", (float)rate, MissionStatus.Practice);
    }
    public void PracticeSimilarityDrain1()
    {
        StringCompute stringcompute1 = new StringCompute();
        stringcompute1.SpeedyCompute(Mix_get_result, "the water will soon drain away");    // 计算相似度， 不记录比较时间
        decimal rate = stringcompute1.ComputeResult.Rate;         // 相似度百分之几，完全匹配相似度为1
        rate = rate * 100;
        FightFlowchart.SetStringVariable("Similarity_percentage", rate.ToString("#0.00") + "%");
        FightFlowchart.SetFloatVariable("Similarity", (float)rate);
        if ((float)rate > Accuracy.accuracy[6,0])
        {
            Accuracy.accuracy[6,0] = (float)rate;
            Accuracy.isChange = true;
        }
        WWWForm Form = new WWWForm();
        WWW WWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=21" + "&Mission_State=1" + "&Accuracy=" + (float)rate + "&Star=" + Star.JudgePerformance_ReturnStar((float)rate));
        if (WWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }

        CountResult("The water will soon drain away", (float)rate, MissionStatus.Practice);
    }
    public void PracticeSimilarityDrain2()
    {
        StringCompute stringcompute1 = new StringCompute();
        stringcompute1.SpeedyCompute(Mix_get_result, "clogged pipes caused drain water to back up into the room");    // 计算相似度， 不记录比较时间
        decimal rate = stringcompute1.ComputeResult.Rate;         // 相似度百分之几，完全匹配相似度为1
        rate = rate * 100;
        FightFlowchart.SetStringVariable("Similarity_percentage", rate.ToString("#0.00") + "%");
        FightFlowchart.SetFloatVariable("Similarity", (float)rate);
        if ((float)rate > Accuracy.accuracy[6,1])
        {
            Accuracy.accuracy[6,1] = (float)rate;
            Accuracy.isChange = true;
        }
        WWWForm Form = new WWWForm();
        WWW WWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=21" + "&Mission_State=2" + "&Accuracy=" + (float)rate + "&Star=" + Star.JudgePerformance_ReturnStar((float)rate));
        if (WWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }

        CountResult("Clogged pipes caused drain water to back up into the room", (float)rate, MissionStatus.Practice);
    }
    public void PracticeSimilarityDrain3()
    {
        StringCompute stringcompute1 = new StringCompute();
        stringcompute1.SpeedyCompute(Mix_get_result, "the company was still going down the drain");    // 计算相似度， 不记录比较时间
        decimal rate = stringcompute1.ComputeResult.Rate;         // 相似度百分之几，完全匹配相似度为1
        rate = rate * 100;
        FightFlowchart.SetStringVariable("Similarity_percentage", rate.ToString("#0.00") + "%");
        FightFlowchart.SetFloatVariable("Similarity", (float)rate);
        if ((float)rate > Accuracy.accuracy[6,2])
        {
            Accuracy.accuracy[6,2] = (float)rate;
            Accuracy.isChange = true;
        }
        WWWForm Form = new WWWForm();
        WWW WWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=21" + "&Mission_State=3" + "&Accuracy=" + (float)rate + "&Star=" + Star.JudgePerformance_ReturnStar((float)rate));
        if (WWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }

        CountResult("The company was still going down the drain", (float)rate, MissionStatus.Practice);
    }
    public void PracticeSimilarityConcentration1()
    {
        StringCompute stringcompute1 = new StringCompute();
        stringcompute1.SpeedyCompute(Concentration_get_result, "there is a heavy concentration of troops in the area");    // 计算相似度， 不记录比较时间
        decimal rate = stringcompute1.ComputeResult.Rate;         // 相似度百分之几，完全匹配相似度为1
        rate = rate * 100;
        FightFlowchart.SetStringVariable("Similarity_percentage", rate.ToString("#0.00") + "%");
        FightFlowchart.SetFloatVariable("Similarity", (float)rate);
        if ((float)rate > Accuracy.accuracy[7,0])
        {
            Accuracy.accuracy[7,0] = (float)rate;
            Accuracy.isChange = true;
        }
        WWWForm Form = new WWWForm();
        WWW WWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=22" + "&Mission_State=1" + "&Accuracy=" + (float)rate + "&Star=" + Star.JudgePerformance_ReturnStar((float)rate));
        if (WWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }

        CountResult("There is a heavy concentration of troops in the area", (float)rate, MissionStatus.Practice);
    }
    public void PracticeSimilarityConcentration2()
    {
        StringCompute stringcompute1 = new StringCompute();
        stringcompute1.SpeedyCompute(Concentration_get_result, "i knew that concentration was the first requirement for learning");    // 计算相似度， 不记录比较时间
        decimal rate = stringcompute1.ComputeResult.Rate;         // 相似度百分之几，完全匹配相似度为1
        rate = rate * 100;
        FightFlowchart.SetStringVariable("Similarity_percentage", rate.ToString("#0.00") + "%");
        FightFlowchart.SetFloatVariable("Similarity", (float)rate);
        if ((float)rate > Accuracy.accuracy[7,1])
        {
            Accuracy.accuracy[7,1] = (float)rate;
            Accuracy.isChange = true;
        }
        WWWForm Form = new WWWForm();
        WWW WWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=22" + "&Mission_State=2" + "&Accuracy=" + (float)rate + "&Star=" + Star.JudgePerformance_ReturnStar((float)rate));
        if (WWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }

        CountResult("I knew that concentration was the first requirement for learning", (float)rate, MissionStatus.Practice);
    }
    public void PracticeSimilarityConcentration3()
    {
        StringCompute stringcompute1 = new StringCompute();
        stringcompute1.SpeedyCompute(Concentration_get_result, "this book requires a great deal of concentration");    // 计算相似度， 不记录比较时间
        decimal rate = stringcompute1.ComputeResult.Rate;         // 相似度百分之几，完全匹配相似度为1
        rate = rate * 100;
        FightFlowchart.SetStringVariable("Similarity_percentage", rate.ToString("#0.00") + "%");
        FightFlowchart.SetFloatVariable("Similarity", (float)rate);
        if ((float)rate > Accuracy.accuracy[7,2])
        {
            Accuracy.accuracy[7,2] = (float)rate;
            Accuracy.isChange = true;
        }
        WWWForm Form = new WWWForm();
        WWW WWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=22" + "&Mission_State=3" + "&Accuracy=" + (float)rate + "&Star=" + Star.JudgePerformance_ReturnStar((float)rate));
        if (WWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }

        CountResult("This book requires a great deal of concentration", (float)rate, MissionStatus.Practice);
    }
    public void PracticeSimilarityEcological1()
    {
        StringCompute stringcompute1 = new StringCompute();
        stringcompute1.SpeedyCompute(Ecological_get_result, "it is an ecological disaster with no parallel anywhere else in the world");    // 计算相似度， 不记录比较时间
        decimal rate = stringcompute1.ComputeResult.Rate;         // 相似度百分之几，完全匹配相似度为1
        rate = rate * 100;
        FightFlowchart.SetStringVariable("Similarity_percentage", rate.ToString("#0.00") + "%");
        FightFlowchart.SetFloatVariable("Similarity", (float)rate);
        if ((float)rate > Accuracy.accuracy[8,0])
        {
            Accuracy.accuracy[8,0] = (float)rate;
            Accuracy.isChange = true;
        }
        WWWForm Form = new WWWForm();
        WWW WWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=23" + "&Mission_State=1" + "&Accuracy=" + (float)rate + "&Star=" + Star.JudgePerformance_ReturnStar((float)rate));
        if (WWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }

        CountResult("It is an ecological disaster with no parallel anywhere else in the world", (float)rate, MissionStatus.Practice);
    }
    public void PracticeSimilarityEcological2()
    {
        StringCompute stringcompute1 = new StringCompute();
        stringcompute1.SpeedyCompute(Ecological_get_result, "the region has been declared an ecological disaster zone");    // 计算相似度， 不记录比较时间
        decimal rate = stringcompute1.ComputeResult.Rate;         // 相似度百分之几，完全匹配相似度为1
        rate = rate * 100;
        FightFlowchart.SetStringVariable("Similarity_percentage", rate.ToString("#0.00") + "%");
        FightFlowchart.SetFloatVariable("Similarity", (float)rate);
        if ((float)rate > Accuracy.accuracy[8,1])
        {
            Accuracy.accuracy[8,1] = (float)rate;
            Accuracy.isChange = true;
        }
        WWWForm Form = new WWWForm();
        WWW WWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=23" + "&Mission_State=2" + "&Accuracy=" + (float)rate + "&Star=" + Star.JudgePerformance_ReturnStar((float)rate));
        if (WWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }

        CountResult("The region has been declared an ecological disaster zone", (float)rate, MissionStatus.Practice);
    }
    public void PracticeSimilarityEcological3()
    {
        StringCompute stringcompute1 = new StringCompute();
        stringcompute1.SpeedyCompute(Ecological_get_result, "fire prevents ecological succession in the open habitat where the plant grows");    // 计算相似度， 不记录比较时间
        decimal rate = stringcompute1.ComputeResult.Rate;         // 相似度百分之几，完全匹配相似度为1
        rate = rate * 100;
        FightFlowchart.SetStringVariable("Similarity_percentage", rate.ToString("#0.00") + "%");
        FightFlowchart.SetFloatVariable("Similarity", (float)rate);
        if ((float)rate > Accuracy.accuracy[8,2])
        {
            Accuracy.accuracy[8,2] = (float)rate;
            Accuracy.isChange = true;
        }
        WWWForm Form = new WWWForm();
        WWW WWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=23" + "&Mission_State=3" + "&Accuracy=" + (float)rate + "&Star=" + Star.JudgePerformance_ReturnStar((float)rate));
        if (WWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }

        CountResult("Fire prevents ecological succession in the open habitat where the plant grows", (float)rate, MissionStatus.Practice);
    }
    public void PracticeSimilarityPicturesque1()
    {
        StringCompute stringcompute1 = new StringCompute();
        stringcompute1.SpeedyCompute(Picturesque_get_result, "you can see the picturesque shores beside the river");    // 计算相似度， 不记录比较时间
        decimal rate = stringcompute1.ComputeResult.Rate;         // 相似度百分之几，完全匹配相似度为1
        rate = rate * 100;
        FightFlowchart.SetStringVariable("Similarity_percentage", rate.ToString("#0.00") + "%");
        FightFlowchart.SetFloatVariable("Similarity", (float)rate);
        if ((float)rate > Accuracy.accuracy[9,0])
        {
            Accuracy.accuracy[9,0] = (float)rate;
            Accuracy.isChange = true;
        }
        WWWForm Form = new WWWForm();
        WWW WWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=24" + "&Mission_State=1" + "&Accuracy=" + (float)rate + "&Star=" + Star.JudgePerformance_ReturnStar((float)rate));
        if (WWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }

        CountResult("You can see the picturesque shores beside the river", (float)rate, MissionStatus.Practice);
    }
    public void PracticeSimilarityPicturesque2()
    {
        StringCompute stringcompute1 = new StringCompute();
        stringcompute1.SpeedyCompute(Picturesque_get_result, "last night the scenery was striking and picturesque");    // 计算相似度， 不记录比较时间
        decimal rate = stringcompute1.ComputeResult.Rate;         // 相似度百分之几，完全匹配相似度为1
        rate = rate * 100;
        FightFlowchart.SetStringVariable("Similarity_percentage", rate.ToString("#0.00") + "%");
        FightFlowchart.SetFloatVariable("Similarity", (float)rate);
        if ((float)rate > Accuracy.accuracy[9,1])
        {
            Accuracy.accuracy[9,1] = (float)rate;
            Accuracy.isChange = true;
        }
        WWWForm Form = new WWWForm();
        WWW WWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=24" + "&Mission_State=2" + "&Accuracy=" + (float)rate + "&Star=" + Star.JudgePerformance_ReturnStar((float)rate));
        if (WWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }

        CountResult("Last night the scenery was striking and picturesque", (float)rate, MissionStatus.Practice);
    }
    public void PracticeSimilarityPicturesque3()
    {
        StringCompute stringcompute1 = new StringCompute();
        stringcompute1.SpeedyCompute(Picturesque_get_result, "i was impressed by the picturesque style of this building");    // 计算相似度， 不记录比较时间
        decimal rate = stringcompute1.ComputeResult.Rate;         // 相似度百分之几，完全匹配相似度为1
        rate = rate * 100;
        FightFlowchart.SetStringVariable("Similarity_percentage", rate.ToString("#0.00") + "%");
        FightFlowchart.SetFloatVariable("Similarity", (float)rate);
        if ((float)rate > Accuracy.accuracy[9,2])
        {
            Accuracy.accuracy[9,2] = (float)rate;
            Accuracy.isChange = true;
        }
        WWWForm Form = new WWWForm();
        WWW WWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=24" + "&Mission_State=3" + "&Accuracy=" + (float)rate + "&Star=" + Star.JudgePerformance_ReturnStar((float)rate));
        if (WWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }

        CountResult("I was impressed by the picturesque style of this building", (float)rate, MissionStatus.Practice);
    }

    public void PracticeSimilarityAquatic1()
    {
        StringCompute stringcompute1 = new StringCompute();
        stringcompute1.SpeedyCompute(Mix_get_result, "aquatic sports include swimming and rowing");    // 计算相似度， 不记录比较时间
        decimal rate = stringcompute1.ComputeResult.Rate;         // 相似度百分之几，完全匹配相似度为1
        rate = rate * 100;
        FightFlowchart.SetStringVariable("Similarity_percentage", rate.ToString("#0.00") + "%");
        FightFlowchart.SetFloatVariable("Similarity", (float)rate);
        if ((float)rate > Accuracy.accuracy[10,0])
        {
            Accuracy.accuracy[10,0] = (float)rate;
            Accuracy.isChange = true;
        }
        WWWForm Form = new WWWForm();
        WWW WWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=25" + "&Mission_State=1" + "&Accuracy=" + (float)rate + "&Star=" + Star.JudgePerformance_ReturnStar((float)rate));
        if (WWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }

        CountResult("Aquatic sports include swimming and rowing", (float)rate, MissionStatus.Practice);
    }
    public void PracticeSimilarityAquatic2()
    {
        StringCompute stringcompute1 = new StringCompute();
        stringcompute1.SpeedyCompute(Mix_get_result, "aquatic food chains are different from terrestrial ones");    // 计算相似度， 不记录比较时间
        decimal rate = stringcompute1.ComputeResult.Rate;         // 相似度百分之几，完全匹配相似度为1
        rate = rate * 100;
        FightFlowchart.SetStringVariable("Similarity_percentage", rate.ToString("#0.00") + "%");
        FightFlowchart.SetFloatVariable("Similarity", (float)rate);
        if ((float)rate > Accuracy.accuracy[10,1])
        {
            Accuracy.accuracy[10,1] = (float)rate;
            Accuracy.isChange = true;
        }
        WWWForm Form = new WWWForm();
        WWW WWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=25" + "&Mission_State=2" + "&Accuracy=" + (float)rate + "&Star=" + Star.JudgePerformance_ReturnStar((float)rate));
        if (WWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }

        CountResult("Aquatic food chains are different from terrestrial ones", (float)rate, MissionStatus.Practice);
    }
    public void PracticeSimilarityAquatic3()
    {
        StringCompute stringcompute1 = new StringCompute();
        stringcompute1.SpeedyCompute(Mix_get_result, "certain species of aquatic animals are capable of producing physiological shocks");    // 计算相似度， 不记录比较时间
        decimal rate = stringcompute1.ComputeResult.Rate;         // 相似度百分之几，完全匹配相似度为1
        rate = rate * 100;
        FightFlowchart.SetStringVariable("Similarity_percentage", rate.ToString("#0.00") + "%");
        FightFlowchart.SetFloatVariable("Similarity", (float)rate);
        if ((float)rate > Accuracy.accuracy[10,2])
        {
            Accuracy.accuracy[10,2] = (float)rate;
            Accuracy.isChange = true;
        }
        WWWForm Form = new WWWForm();
        WWW WWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=25" + "&Mission_State=3" + "&Accuracy=" + (float)rate + "&Star=" + Star.JudgePerformance_ReturnStar((float)rate));
        if (WWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }

        CountResult("Certain species of aquatic animals are capable of producing physiological shocks", (float)rate, MissionStatus.Practice);
    }
    public void PracticeSimilarityLandscaping1()
    {
        StringCompute stringcompute1 = new StringCompute();
        stringcompute1.SpeedyCompute(Mix_get_result, "the landowner insisted on a high standard of landscaping");    // 计算相似度， 不记录比较时间
        decimal rate = stringcompute1.ComputeResult.Rate;         // 相似度百分之几，完全匹配相似度为1
        rate = rate * 100;
        FightFlowchart.SetStringVariable("Similarity_percentage", rate.ToString("#0.00") + "%");
        FightFlowchart.SetFloatVariable("Similarity", (float)rate);
        if ((float)rate > Accuracy.accuracy[11,0])
        {
            Accuracy.accuracy[11,0] = (float)rate;
            Accuracy.isChange = true;
        }
        WWWForm Form = new WWWForm();
        WWW WWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=26" + "&Mission_State=1" + "&Accuracy=" + (float)rate + "&Star=" + Star.JudgePerformance_ReturnStar((float)rate));
        if (WWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }

        CountResult("The landowner insisted on a high standard of landscaping", (float)rate, MissionStatus.Practice);
    }
    public void PracticeSimilarityLandscaping2()
    {
        StringCompute stringcompute1 = new StringCompute();
        stringcompute1.SpeedyCompute(Mix_get_result, "landscaping will be used for leisure or irrigated as agricultural land");    // 计算相似度， 不记录比较时间
        decimal rate = stringcompute1.ComputeResult.Rate;         // 相似度百分之几，完全匹配相似度为1
        rate = rate * 100;
        FightFlowchart.SetStringVariable("Similarity_percentage", rate.ToString("#0.00") + "%");
        FightFlowchart.SetFloatVariable("Similarity", (float)rate);
        if ((float)rate > Accuracy.accuracy[11,1])
        {
            Accuracy.accuracy[11,1] = (float)rate;
            Accuracy.isChange = true;
        }
        WWWForm Form = new WWWForm();
        WWW WWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=26" + "&Mission_State=2" + "&Accuracy=" + (float)rate + "&Star=" + Star.JudgePerformance_ReturnStar((float)rate));
        if (WWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }

        CountResult("Landscaping will be used for leisure or irrigated as agricultural land", (float)rate, MissionStatus.Practice);
    }
    public void PracticeSimilarityLandscaping3()
    {
        StringCompute stringcompute1 = new StringCompute();
        stringcompute1.SpeedyCompute(Mix_get_result, "the flooring and landscaping will be done by the contractor");    // 计算相似度， 不记录比较时间
        decimal rate = stringcompute1.ComputeResult.Rate;         // 相似度百分之几，完全匹配相似度为1
        rate = rate * 100;
        FightFlowchart.SetStringVariable("Similarity_percentage", rate.ToString("#0.00") + "%");
        FightFlowchart.SetFloatVariable("Similarity", (float)rate);
        if ((float)rate > Accuracy.accuracy[11,2])
        {
            Accuracy.accuracy[11,2] = (float)rate;
            Accuracy.isChange = true;
        }
        WWWForm Form = new WWWForm();
        WWW WWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=26" + "&Mission_State=3" + "&Accuracy=" + (float)rate + "&Star=" + Star.JudgePerformance_ReturnStar((float)rate));
        if (WWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }

        CountResult("The flooring and landscaping will be done by the contractor", (float)rate, MissionStatus.Practice);
    }
    public void PracticeSimilarityBiodiversity1()
    {
        StringCompute stringcompute1 = new StringCompute();
        stringcompute1.SpeedyCompute(Mix_get_result, "butterflies are indicators of the biodiversity of our natural environment");    // 计算相似度， 不记录比较时间
        decimal rate = stringcompute1.ComputeResult.Rate;         // 相似度百分之几，完全匹配相似度为1
        rate = rate * 100;
        FightFlowchart.SetStringVariable("Similarity_percentage", rate.ToString("#0.00") + "%");
        FightFlowchart.SetFloatVariable("Similarity", (float)rate);
        if ((float)rate > Accuracy.accuracy[12,0])
        {
            Accuracy.accuracy[12,0] = (float)rate;
            Accuracy.isChange = true;
        }
        WWWForm Form = new WWWForm();
        WWW WWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=27" + "&Mission_State=1" + "&Accuracy=" + (float)rate + "&Star=" + Star.JudgePerformance_ReturnStar((float)rate));
        if (WWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }

        CountResult("Butterflies are indicators of the biodiversity of our natural environment", (float)rate, MissionStatus.Practice);
    }
    public void PracticeSimilarityBiodiversity2()
    {
        StringCompute stringcompute1 = new StringCompute();
        stringcompute1.SpeedyCompute(Mix_get_result, "we are on the verge of a major biodiversity crisis");    // 计算相似度， 不记录比较时间
        decimal rate = stringcompute1.ComputeResult.Rate;         // 相似度百分之几，完全匹配相似度为1
        rate = rate * 100;
        FightFlowchart.SetStringVariable("Similarity_percentage", rate.ToString("#0.00") + "%");
        FightFlowchart.SetFloatVariable("Similarity", (float)rate);
        if ((float)rate > Accuracy.accuracy[12,1])
        {
            Accuracy.accuracy[12,1] = (float)rate;
            Accuracy.isChange = true;
        }
        WWWForm Form = new WWWForm();
        WWW WWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=27" + "&Mission_State=2" + "&Accuracy=" + (float)rate + "&Star=" + Star.JudgePerformance_ReturnStar((float)rate));
        if (WWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }

        CountResult("We are on the verge of a major biodiversity crisis", (float)rate, MissionStatus.Practice);
    }
    public void PracticeSimilarityBiodiversity3()
    {
        StringCompute stringcompute1 = new StringCompute();
        stringcompute1.SpeedyCompute(Mix_get_result, "the protection of biodiversity has been  the focus of agricultural research for years");    // 计算相似度， 不记录比较时间
        decimal rate = stringcompute1.ComputeResult.Rate;         // 相似度百分之几，完全匹配相似度为1
        rate = rate * 100;
        FightFlowchart.SetStringVariable("Similarity_percentage", rate.ToString("#0.00") + "%");
        FightFlowchart.SetFloatVariable("Similarity", (float)rate);
        if ((float)rate > Accuracy.accuracy[12,2])
        {
            Accuracy.accuracy[12,2] = (float)rate;
            Accuracy.isChange = true;
        }
        WWWForm Form = new WWWForm();
        WWW WWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=27" + "&Mission_State=3" + "&Accuracy=" + (float)rate + "&Star=" + Star.JudgePerformance_ReturnStar((float)rate));
        if (WWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }

        CountResult("The protection of biodiversity has been  the focus of agricultural research for years", (float)rate, MissionStatus.Practice);
    }
    public void PracticeSimilarityAmphibian1()
    {
        StringCompute stringcompute1 = new StringCompute();
        stringcompute1.SpeedyCompute(Mix_get_result, "both the toad and frog are amphibian");    // 计算相似度， 不记录比较时间
        decimal rate = stringcompute1.ComputeResult.Rate;         // 相似度百分之几，完全匹配相似度为1
        rate = rate * 100;
        FightFlowchart.SetStringVariable("Similarity_percentage", rate.ToString("#0.00") + "%");
        FightFlowchart.SetFloatVariable("Similarity", (float)rate);
        if ((float)rate > Accuracy.accuracy[13,0])
        {
            Accuracy.accuracy[13,0] = (float)rate;
            Accuracy.isChange = true;
        }
        WWWForm Form = new WWWForm();
        WWW WWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=28" + "&Mission_State=1" + "&Accuracy=" + (float)rate + "&Star=" + Star.JudgePerformance_ReturnStar((float)rate));
        if (WWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }

        CountResult("Both the toad and frog are amphibian", (float)rate, MissionStatus.Practice);
    }
    public void PracticeSimilarityAmphibian2()
    {
        StringCompute stringcompute1 = new StringCompute();
        stringcompute1.SpeedyCompute(Mix_get_result, "amphibians live partly in water and partly on land");    // 计算相似度， 不记录比较时间
        decimal rate = stringcompute1.ComputeResult.Rate;         // 相似度百分之几，完全匹配相似度为1
        rate = rate * 100;
        FightFlowchart.SetStringVariable("Similarity_percentage", rate.ToString("#0.00") + "%");
        FightFlowchart.SetFloatVariable("Similarity", (float)rate);
        if ((float)rate > Accuracy.accuracy[13,1])
        {
            Accuracy.accuracy[13,1] = (float)rate;
            Accuracy.isChange = true;
        }
        WWWForm Form = new WWWForm();
        WWW WWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=28" + "&Mission_State=2" + "&Accuracy=" + (float)rate + "&Star=" + Star.JudgePerformance_ReturnStar((float)rate));
        if (WWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }

        CountResult("Amphibians live partly in water and partly on land", (float)rate, MissionStatus.Practice);
    }
    public void PracticeSimilarityAmphibian3()
    {
        StringCompute stringcompute1 = new StringCompute();
        stringcompute1.SpeedyCompute(Mix_get_result, "all amphibians begin their life in water with gills and tails");    // 计算相似度， 不记录比较时间
        decimal rate = stringcompute1.ComputeResult.Rate;         // 相似度百分之几，完全匹配相似度为1
        rate = rate * 100;
        FightFlowchart.SetStringVariable("Similarity_percentage", rate.ToString("#0.00") + "%");
        FightFlowchart.SetFloatVariable("Similarity", (float)rate);
        if ((float)rate > Accuracy.accuracy[13,2])
        {
            Accuracy.accuracy[13,2] = (float)rate;
            Accuracy.isChange = true;
        }
        WWWForm Form = new WWWForm();
        WWW WWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=28" + "&Mission_State=3" + "&Accuracy=" + (float)rate + "&Star=" + Star.JudgePerformance_ReturnStar((float)rate));
        if (WWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }

        CountResult("All amphibians begin their life in water with gills and tails", (float)rate, MissionStatus.Practice);
    }

    public void ReviewSimilaritySerene()
    {
        StringCompute stringcompute1 = new StringCompute();
        stringcompute1.SpeedyCompute(Mix_get_result, "this is the perfect place to slowly unwind in serene rural surroundings");    // 计算相似度， 不记录比较时间
        decimal rate = stringcompute1.ComputeResult.Rate;         // 相似度百分之几，完全匹配相似度为1
        rate = rate * 100;
        Mission_NPC1208101711Flowchart.SetStringVariable("Similarity_percentage", rate.ToString("#0.00") + "%");
        Mission_NPC1208101711Flowchart.SetFloatVariable("Similarity", (float)rate);
        if ((float)rate > Accuracy.ReviewAccuracy[0])
        {
            Accuracy.ReviewAccuracy[0] = (float)rate;
            Accuracy.isChange = true;
        }
        WWWForm Form = new WWWForm();
        WWW WWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=29" + "&Mission_State=4" + "&Accuracy=" + (float)rate + "&Star=" + Star.JudgePerformance_ReturnStar((float)rate));
        if (WWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }

        CountResult("This is the perfect place to slowly unwind in serene rural surroundings", (float)rate, MissionStatus.Review);
    }

    public void ReviewSimilarityThoughtful()
    {
        StringCompute stringcompute1 = new StringCompute();
        stringcompute1.SpeedyCompute(Mix_get_result, "you should be more thoughtful about how to manage your time");    // 计算相似度， 不记录比较时间
        decimal rate = stringcompute1.ComputeResult.Rate;         // 相似度百分之几，完全匹配相似度为1
        rate = rate * 100;
        Mission_NPC1208101711Flowchart.SetStringVariable("Similarity_percentage", rate.ToString("#0.00") + "%");
        Mission_NPC1208101711Flowchart.SetFloatVariable("Similarity", (float)rate);
        if ((float)rate > Accuracy.ReviewAccuracy[1])
        {
            Accuracy.ReviewAccuracy[1] = (float)rate;
            Accuracy.isChange = true;
        }
        WWWForm Form = new WWWForm();
        WWW WWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=29" + "&Mission_State=5" + "&Accuracy=" + (float)rate + "&Star=" + Star.JudgePerformance_ReturnStar((float)rate));
        if (WWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }

        CountResult("You should be more thoughtful about how to manage your time", (float)rate, MissionStatus.Review);
    }

    public void ReviewSimilaritySubsidy()
    {
        StringCompute stringcompute1 = new StringCompute();
        stringcompute1.SpeedyCompute(Mix_get_result, "there were also pledges to soften the impact of the subsidy cuts on the poorer regions");    // 计算相似度， 不记录比较时间
        decimal rate = stringcompute1.ComputeResult.Rate;         // 相似度百分之几，完全匹配相似度为1
        rate = rate * 100;
        Mission_NPC1208101711Flowchart.SetStringVariable("Similarity_percentage", rate.ToString("#0.00") + "%");
        Mission_NPC1208101711Flowchart.SetFloatVariable("Similarity", (float)rate);
        if ((float)rate > Accuracy.ReviewAccuracy[2])
        {
            Accuracy.ReviewAccuracy[2] = (float)rate;
            Accuracy.isChange = true;
        }
        WWWForm Form = new WWWForm();
        WWW WWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=29" + "&Mission_State=6" + "&Accuracy=" + (float)rate + "&Star=" + Star.JudgePerformance_ReturnStar((float)rate));
        if (WWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }

        CountResult("There were also pledges to soften the impact of the subsidy cuts on the poorer regions", (float)rate, MissionStatus.Review);
    }

    public void ReviewSimilarityPurification()
    {
        StringCompute stringcompute1 = new StringCompute();
        stringcompute1.SpeedyCompute(Mix_get_result, "distillation has traditionally been the major system for water purification");    // 计算相似度， 不记录比较时间
        decimal rate = stringcompute1.ComputeResult.Rate;         // 相似度百分之几，完全匹配相似度为1
        rate = rate * 100;
        Mission_NPC1208101711Flowchart.SetStringVariable("Similarity_percentage", rate.ToString("#0.00") + "%");
        Mission_NPC1208101711Flowchart.SetFloatVariable("Similarity", (float)rate);
        if ((float)rate > Accuracy.ReviewAccuracy[3])
        {
            Accuracy.ReviewAccuracy[3] = (float)rate;
            Accuracy.isChange = true;
        }
        WWWForm Form = new WWWForm();
        WWW WWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=29" + "&Mission_State=7" + "&Accuracy=" + (float)rate + "&Star=" + Star.JudgePerformance_ReturnStar((float)rate));
        if (WWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }

        CountResult("Distillation has traditionally been the major system for water purification", (float)rate, MissionStatus.Review);
    }
    
    public void ReviewSimilarityDetention()
    {
        StringCompute stringcompute1 = new StringCompute();
        stringcompute1.SpeedyCompute(Mix_get_result, "she prefers to stay in detention rather than be released and go into exile");    // 计算相似度， 不记录比较时间
        decimal rate = stringcompute1.ComputeResult.Rate;         // 相似度百分之几，完全匹配相似度为1
        rate = rate * 100;
        Mission_NPC1208101711Flowchart.SetStringVariable("Similarity_percentage", rate.ToString("#0.00") + "%");
        Mission_NPC1208101711Flowchart.SetFloatVariable("Similarity", (float)rate);
        if ((float)rate > Accuracy.ReviewAccuracy[4])
        {
            Accuracy.ReviewAccuracy[4] = (float)rate;
            Accuracy.isChange = true;
        }
        WWWForm Form = new WWWForm();
        WWW WWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=29" + "&Mission_State=8" + "&Accuracy=" + (float)rate + "&Star=" + Star.JudgePerformance_ReturnStar((float)rate));
        if (WWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }

        CountResult("She prefers to stay in detention rather than be released and go into exile", (float)rate, MissionStatus.Review);
    }
    
    public void ReviewSimilarityBeautify()
    {
        StringCompute stringcompute1 = new StringCompute();
        stringcompute1.SpeedyCompute(Mix_get_result, "the City Council has a manifold plan to beautify the city");    // 计算相似度， 不记录比较时间
        decimal rate = stringcompute1.ComputeResult.Rate;         // 相似度百分之几，完全匹配相似度为1
        rate = rate * 100;
        Mission_NPC1208101711Flowchart.SetStringVariable("Similarity_percentage", rate.ToString("#0.00") + "%");
        Mission_NPC1208101711Flowchart.SetFloatVariable("Similarity", (float)rate);
        if ((float)rate > Accuracy.ReviewAccuracy[5])
        {
            Accuracy.ReviewAccuracy[5] = (float)rate;
            Accuracy.isChange = true;
        }
        WWWForm Form = new WWWForm();
        WWW WWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=29" + "&Mission_State=9" + "&Accuracy=" + (float)rate + "&Star=" + Star.JudgePerformance_ReturnStar((float)rate));
        if (WWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }

        CountResult("The City Council has a manifold plan to beautify the city", (float)rate, MissionStatus.Review);
    }
    
    public void ReviewSimilarityDrain()
    {
        StringCompute stringcompute1 = new StringCompute();
        stringcompute1.SpeedyCompute(Mix_get_result, "clogged pipes caused drain water to back up into the room");    // 计算相似度， 不记录比较时间
        decimal rate = stringcompute1.ComputeResult.Rate;         // 相似度百分之几，完全匹配相似度为1
        rate = rate * 100;
        Mission_NPC1208101711Flowchart.SetStringVariable("Similarity_percentage", rate.ToString("#0.00") + "%");
        Mission_NPC1208101711Flowchart.SetFloatVariable("Similarity", (float)rate);
        if ((float)rate > Accuracy.ReviewAccuracy[6])
        {
            Accuracy.ReviewAccuracy[6] = (float)rate;
            Accuracy.isChange = true;
        }
        WWWForm Form = new WWWForm();
        WWW WWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=29" + "&Mission_State=10" + "&Accuracy=" + (float)rate + "&Star=" + Star.JudgePerformance_ReturnStar((float)rate));
        if (WWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }

        CountResult("Clogged pipes caused drain water to back up into the room", (float)rate, MissionStatus.Review);
    }
    
    public void ReviewSimilarityConcentration()
    {
        StringCompute stringcompute1 = new StringCompute();
        stringcompute1.SpeedyCompute(Mix_get_result, "i knew that concentration was the first requirement for learning");    // 计算相似度， 不记录比较时间
        decimal rate = stringcompute1.ComputeResult.Rate;         // 相似度百分之几，完全匹配相似度为1
        rate = rate * 100;
        Mission_NPC1208101711Flowchart.SetStringVariable("Similarity_percentage", rate.ToString("#0.00") + "%");
        Mission_NPC1208101711Flowchart.SetFloatVariable("Similarity", (float)rate);
        if ((float)rate > Accuracy.ReviewAccuracy[7])
        {
            Accuracy.ReviewAccuracy[7] = (float)rate;
            Accuracy.isChange = true;
        }
        WWWForm Form = new WWWForm();
        WWW WWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=29" + "&Mission_State=11" + "&Accuracy=" + (float)rate + "&Star=" + Star.JudgePerformance_ReturnStar((float)rate));
        if (WWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }

        CountResult("I knew that concentration was the first requirement for learning", (float)rate, MissionStatus.Review);
    }
    
    public void ReviewSimilarityEcological()
    {
        StringCompute stringcompute1 = new StringCompute();
        stringcompute1.SpeedyCompute(Mix_get_result, "it is an ecological disaster with no parallel anywhere else in the world");    // 计算相似度， 不记录比较时间
        decimal rate = stringcompute1.ComputeResult.Rate;         // 相似度百分之几，完全匹配相似度为1
        rate = rate * 100;
        Mission_NPC1208101711Flowchart.SetStringVariable("Similarity_percentage", rate.ToString("#0.00") + "%");
        Mission_NPC1208101711Flowchart.SetFloatVariable("Similarity", (float)rate);
        if ((float)rate > Accuracy.ReviewAccuracy[8])
        {
            Accuracy.ReviewAccuracy[8] = (float)rate;
            Accuracy.isChange = true;
        }
        WWWForm Form = new WWWForm();
        WWW WWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=29" + "&Mission_State=12" + "&Accuracy=" + (float)rate + "&Star=" + Star.JudgePerformance_ReturnStar((float)rate));
        if (WWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }

        CountResult("It is an ecological disaster with no parallel anywhere else in the world", (float)rate, MissionStatus.Review);
    }

    public void ReviewSimilarityPicturesque()
    {
        StringCompute stringcompute1 = new StringCompute();
        stringcompute1.SpeedyCompute(Mix_get_result, "last night the scenery was striking and picturesque");    // 计算相似度， 不记录比较时间
        decimal rate = stringcompute1.ComputeResult.Rate;         // 相似度百分之几，完全匹配相似度为1
        rate = rate * 100;
        Mission_NPC1208101711Flowchart.SetStringVariable("Similarity_percentage", rate.ToString("#0.00") + "%");
        Mission_NPC1208101711Flowchart.SetFloatVariable("Similarity", (float)rate);
        if ((float)rate > Accuracy.ReviewAccuracy[9])
        {
            Accuracy.ReviewAccuracy[9] = (float)rate;
            Accuracy.isChange = true;
        }
        WWWForm Form = new WWWForm();
        WWW WWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=29" + "&Mission_State=13" + "&Accuracy=" + (float)rate + "&Star=" + Star.JudgePerformance_ReturnStar((float)rate));
        if (WWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }

        CountResult("Last night the scenery was striking and picturesque", (float)rate, MissionStatus.Review);
    }
    
    public void ReviewSimilarityAquatic()
    {
        StringCompute stringcompute1 = new StringCompute();
        stringcompute1.SpeedyCompute(Mix_get_result, "certain species of aquatic animals are capable of producing physiological shocks");    // 计算相似度， 不记录比较时间
        decimal rate = stringcompute1.ComputeResult.Rate;         // 相似度百分之几，完全匹配相似度为1
        rate = rate * 100;
        Mission_NPC1208101711Flowchart.SetStringVariable("Similarity_percentage", rate.ToString("#0.00") + "%");
        Mission_NPC1208101711Flowchart.SetFloatVariable("Similarity", (float)rate);
        if ((float)rate > Accuracy.ReviewAccuracy[10])
        {
            Accuracy.ReviewAccuracy[10] = (float)rate;
            Accuracy.isChange = true;
        }
        WWWForm Form = new WWWForm();
        WWW WWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=29" + "&Mission_State=14" + "&Accuracy=" + (float)rate + "&Star=" + Star.JudgePerformance_ReturnStar((float)rate));
        if (WWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }

        CountResult("Certain species of aquatic animals are capable of producing physiological shocks", (float)rate, MissionStatus.Review);
    }
    
    public void ReviewSimilarityLandscaping()
    {
        StringCompute stringcompute1 = new StringCompute();
        stringcompute1.SpeedyCompute(Mix_get_result, "landscaping will be used for leisure or irrigated as agricultural land");    // 计算相似度， 不记录比较时间
        decimal rate = stringcompute1.ComputeResult.Rate;         // 相似度百分之几，完全匹配相似度为1
        rate = rate * 100;
        Mission_NPC1208101711Flowchart.SetStringVariable("Similarity_percentage", rate.ToString("#0.00") + "%");
        Mission_NPC1208101711Flowchart.SetFloatVariable("Similarity", (float)rate);
        if ((float)rate > Accuracy.ReviewAccuracy[11])
        {
            Accuracy.ReviewAccuracy[11] = (float)rate;
            Accuracy.isChange = true;
        }
        WWWForm Form = new WWWForm();
        WWW WWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=29" + "&Mission_State=15" + "&Accuracy=" + (float)rate + "&Star=" + Star.JudgePerformance_ReturnStar((float)rate));
        if (WWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }

        CountResult("Landscaping will be used for leisure or irrigated as agricultural land", (float)rate, MissionStatus.Review);
    }

    public void ReviewSimilarityBiodiversity()
    {
        StringCompute stringcompute1 = new StringCompute();
        stringcompute1.SpeedyCompute(Mix_get_result, "the protection of biodiversity has been  the focus of agricultural research for years");    // 计算相似度， 不记录比较时间
        decimal rate = stringcompute1.ComputeResult.Rate;         // 相似度百分之几，完全匹配相似度为1
        rate = rate * 100;
        Mission_NPC1208101711Flowchart.SetStringVariable("Similarity_percentage", rate.ToString("#0.00") + "%");
        Mission_NPC1208101711Flowchart.SetFloatVariable("Similarity", (float)rate);
        if ((float)rate > Accuracy.ReviewAccuracy[12])
        {
            Accuracy.ReviewAccuracy[12] = (float)rate;
            Accuracy.isChange = true;
        }
        WWWForm Form = new WWWForm();
        WWW WWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=29" + "&Mission_State=16" + "&Accuracy=" + (float)rate + "&Star=" + Star.JudgePerformance_ReturnStar((float)rate));
        if (WWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }

        CountResult("The protection of biodiversity has been  the focus of agricultural research for years", (float)rate, MissionStatus.Review);
    }
    
    public void ReviewSimilarityAmphibian()
    {
        StringCompute stringcompute1 = new StringCompute();
        stringcompute1.SpeedyCompute(Mix_get_result, "all amphibians begin their life in water with gills and tails");    // 计算相似度， 不记录比较时间
        decimal rate = stringcompute1.ComputeResult.Rate;         // 相似度百分之几，完全匹配相似度为1
        rate = rate * 100;
        Mission_NPC1208101711Flowchart.SetStringVariable("Similarity_percentage", rate.ToString("#0.00") + "%");
        Mission_NPC1208101711Flowchart.SetFloatVariable("Similarity", (float)rate);
        if ((float)rate > Accuracy.ReviewAccuracy[13])
        {
            Accuracy.ReviewAccuracy[13] = (float)rate;
            Accuracy.isChange = true;
        }
        WWWForm Form = new WWWForm();
        WWW WWW = new WWW(Insert_Ans_Url + LoginScript.Account + "&NPC_ID=29" + "&Mission_State=17" + "&Accuracy=" + (float)rate + "&Star=" + Star.JudgePerformance_ReturnStar((float)rate));
        if (WWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }

        CountResult("All amphibians begin their life in water with gills and tails", (float)rate, MissionStatus.Review);
    }
}


