using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MissionUI : MonoBehaviour {
    public static GameObject MissionView;
    public Text Context;
    //宣告任務物件
#region
    public static GameObject[] ProcessingMisssion = new GameObject[14];              //進行中的任務 

    public static GameObject[] NotCompletedMission = new GameObject[14];

    public static GameObject [] CompletedMission = new GameObject[14];

    /*public static GameObject Serene_R;
    public static GameObject Thoughtful_R;
    public static GameObject Subsidy_R;
    public static GameObject Purification_R;
    public static GameObject Dention_R;
    public static GameObject Beautify_R;
    public static GameObject Drain_R;
    public static GameObject Concentration_R;
    public static GameObject Ecologicalcorridors_R;
    public static GameObject Picturesque_R;
    public static GameObject Aquatic_R;
    public static GameObject Landscaping_R;
    public static GameObject Biodiversity_R;
    public static GameObject Amphibian_R;
    */
    public static GameObject Finaltask;
    #endregion

    //宣告提示物件
    #region
    public GameObject RightpicturePointer;
    public GameObject WpicturePointer1;
    public GameObject WpicturePointer2;

    //public GameObject
    
#endregion

    public bool openandclose = false;
    private int tipcount = 3;

    // Use this for initialization
    void Start()
    {
        MissionView = GameObject.Find("MissionView");

        ProcessingMisssion[0] = GameObject.Find("Mission01");
        ProcessingMisssion[1] = GameObject.Find("Mission02");
        ProcessingMisssion[2] = GameObject.Find("Mission03");
        ProcessingMisssion[3] = GameObject.Find("Mission04");
        ProcessingMisssion[4] = GameObject.Find("Mission05");
        ProcessingMisssion[5] = GameObject.Find("Mission06");
        ProcessingMisssion[6] = GameObject.Find("Mission07");
        ProcessingMisssion[7] = GameObject.Find("Mission08");
        ProcessingMisssion[8] = GameObject.Find("Mission09");
        ProcessingMisssion[9] = GameObject.Find("Mission10");
        ProcessingMisssion[10] = GameObject.Find("Mission11");
        ProcessingMisssion[11] = GameObject.Find("Mission12");
        ProcessingMisssion[12] = GameObject.Find("Mission13");
        ProcessingMisssion[13] = GameObject.Find("Mission14");        
        //Finaltask = GameObject.Find("Mission15");
        //Finaltask.SetActive(false);

        NotCompletedMission[0] = GameObject.Find("NotCompletedMission01");
        NotCompletedMission[1] = GameObject.Find("NotCompletedMission02");
        NotCompletedMission[2] = GameObject.Find("NotCompletedMission03");
        NotCompletedMission[3] = GameObject.Find("NotCompletedMission04");
        NotCompletedMission[4] = GameObject.Find("NotCompletedMission05");
        NotCompletedMission[5] = GameObject.Find("NotCompletedMission06");
        NotCompletedMission[6] = GameObject.Find("NotCompletedMission07");
        NotCompletedMission[7] = GameObject.Find("NotCompletedMission08");
        NotCompletedMission[8] = GameObject.Find("NotCompletedMission09");
        NotCompletedMission[9] = GameObject.Find("NotCompletedMission10");
        NotCompletedMission[10] = GameObject.Find("NotCompletedMission11");
        NotCompletedMission[11] = GameObject.Find("NotCompletedMission12");
        NotCompletedMission[12] = GameObject.Find("NotCompletedMission13");
        NotCompletedMission[13] = GameObject.Find("NotCompletedMission14");

        CompletedMission[0] = GameObject.Find("CompletedMission01");
        CompletedMission[1] = GameObject.Find("CompletedMission02");
        CompletedMission[2] = GameObject.Find("CompletedMission03");
        CompletedMission[3] = GameObject.Find("CompletedMission04");
        CompletedMission[4] = GameObject.Find("CompletedMission05");
        CompletedMission[5] = GameObject.Find("CompletedMission06");
        CompletedMission[6] = GameObject.Find("CompletedMission07");
        CompletedMission[7] = GameObject.Find("CompletedMission08");
        CompletedMission[8] = GameObject.Find("CompletedMission09");
        CompletedMission[9] = GameObject.Find("CompletedMission10");
        CompletedMission[10] = GameObject.Find("CompletedMission11");
        CompletedMission[11] = GameObject.Find("CompletedMission12");
        CompletedMission[12] = GameObject.Find("CompletedMission13");
        CompletedMission[13] = GameObject.Find("CompletedMission14");

        MissionView.SetActive(false);

        RightpicturePointer.SetActive(false);
        WpicturePointer1.SetActive(false);
        WpicturePointer2.SetActive(false);
        for (int i = 0; i < 14; i++)
        {
            NotCompletedMission[i].SetActive(true);
            ProcessingMisssion[i].SetActive(false);
            CompletedMission[i].SetActive(false);
        }
        for(int i = 0; i < 14; i++)
        {
            if (Loadcharacter.MissionComplete[i + 1] == true)
            {
                NotCompletedMission[i].SetActive(false);
                ProcessingMisssion[i].SetActive(false);
                CompletedMission[i].SetActive(true);
            }
        }

    } 
    // Update is called once per frame
    void Update ()
    {
        Tipscount();//判斷使用提示次數

    }

    public void Close()
    {
        MissionView.SetActive(false);
        openandclose = false;
        Context.text = "Click the Mission.";
        Debug.Log("視窗關閉!");
    }
    public void Open()
    {
        switch (openandclose)
        {
            case true:
                MissionView.SetActive(false);
                openandclose = false;
                Context.text = "提示會幫助你完成任務" + "\n" + "使用3次提示花費1金幣" + "\n" + "免費提示有 " + tipcount + " 次";
                Debug.Log("視窗關閉!");
                break;
            case false:
                MissionView.SetActive(true);
                openandclose = true;
                Context.text = "提示會幫助你完成任務" + "\n" + "使用3次提示花費1金幣" + "\n" + "免費提示有 " + tipcount + " 次";
                Debug.Log("視窗開啟!");
                break;
            default:
                
                break;
        }
    }
    void Tipscount()
    {
        if (tipcount == -1)
        {
            MoneyScript.Money -= 1;          
            tipcount = 3;
            
        }
    }

    public void SereneButtonClick()//直接點出那個地方的位置
    {
        //Context.text = "The picture about Serene is in the Wood house(Using map) and near the door. Observe the picture and choose the correct description of Serene.";
        Context.text = "關於 [Serene] 的圖片，就在 Wood House 裡面(可使用[地圖]找到)並且靠近門旁邊.";
        RightpicturePointer.SetActive(true);
        WpicturePointer1.SetActive(true);
        WpicturePointer2.SetActive(true);
        tipcount -= 1;
        //新增解任務的區域在地圖上
    }
    public void Serene_RButtonClick() //顯示任務內容
    {
        //Context.text = "Help Npc to kill 3 Cyclops and answer the question correctly. Cyclops are near the Npc. He will give you the reward as retrun." + "\n" +"You already defeat"+ LakeControl.Serene_Cyclops+ "Cyclops";
        //Context.text = "幫助 NPC 擊敗 3 隻 Cyclops並且回答問題(初次作答就答對會額外獲得獎勵). Cyclops 就在NPC附近,趕緊去擊敗他們吧!" + "\n" + "你已經擊敗了" + LakeControl.Serene_Cyclops + "隻 Cyclops";
        //tipcount -= 1;
    }
    public void ThoughtfulButtonClick()
    {
        //Context.text = "Find the man is sitting on the view platform and observe his behavior. From observe his behavior, choose the correct description of Thoughtful";
        Context.text = "在 View platform(可使用地圖找到) 找到坐在地板上的男人並且觀察他的動作[Thoughtful]";
        //新增解任務的區域在地圖上
        tipcount -= 1;
    }
    public void Thoughtful_RButtonClick() //顯示任務內容
    {
        //Context.text = "Help Npc to kill 3 Crabs and answer the question correctly. Crabs are near the Npc. He will give you the reward as retrun." + "\n" + "You already defeat" + LakeControl.Thoughtfu_Crab + "Crabs";
        //Context.text = "幫助 NPC 擊敗 3 隻 Crabs 並且回答問題(初次作答就答對會額外獲得獎勵). Crabs 就在NPC附近,趕緊去擊敗他們吧!" + "\n" + "你已經擊敗了" + LakeControl.Thoughtfu_Crab + "隻 Crabs";
        //tipcount -= 1;
    }
    public void SubsidyButtonClick()
    {
        //Context.text = "'Subsidy' is placed on the right side of Subsidy_NPC. Observe the Subsidy and choose the correct description of Subsidy. Finally, take the Subsidy to the old man who is dancing nearby the ecological pond.(Using map) ";
        Context.text = "[Subsidy] 放在 Subsidy_NPC 的右邊. 觀察 [Subsidy] 的外觀. 接著再把 [Subsidy] 拿給在 Ecological pond(使用地圖尋找) 附近跳舞的老人.";
        //新增解任務的區域在地圖上
        tipcount -= 1;
    }
    public void Subsidy_RButtonClick() //顯示任務內容
    {
        //Context.text = "Help Npc to kill 3 Mummies and answer the question correctly. Mummies are near the Npc. He will give you the reward as retrun." + "\n" + "You already defeat" + LakeControl.Subsidy_Mummy + "Mummies";
        //Context.text = "幫助 NPC 擊敗 3 隻 Mummies 並且回答問題(初次作答就答對會額外獲得獎勵). Mummies 就在NPC附近,趕緊去擊敗他們吧!" + "\n" + "你已經擊敗了" + LakeControl.Subsidy_Mummy + "隻 Mummies";
        //tipcount -= 1;
    }
    public void PurificationButtonClick()
    {
        //Context.text = "Some of the bananas in the banana garden are poisonous(color in red). Find them out and have them go through 'Purification'. Observe the change after you purify the red bananas.";
        Context.text = "在 Banana garden(可使用地圖找到) 裡面有一些香蕉中毒了(顏色變成紅色). 找到其中一個中毒的香蕉 使他們 [Purification]. 當香蕉顏色從紅轉綠後(變正常),觀察這個過程. ";
        //新增解任務的區域在地圖上
        tipcount -= 1;
    }
    public void Purification_RButtonClick() //顯示任務內容
    {
        //Context.text = "Help Npc to kill 3 Bunny and answer the question correctly. Bunny are near the Npc. He will give you the reward as retrun." + "\n" + "You already defeat" + LakeControl.Purification_Bunny + "Bunny";
        //Context.text = "幫助 NPC 擊敗 3 隻 Bunny 並且回答問題(初次作答就答對會額外獲得獎勵). Bunny 就在NPC附近,趕緊去擊敗他們吧!" + "\n" + "你已經擊敗了" + LakeControl.Purification_Bunny + "隻 Bunny";
        //tipcount -= 1;
    }
    public void DetentionButtonClick()
    {
        //Context.text = "Vicky has been held in 'Detention'by guard with 24 hours for drunk driving. Guard is in the tent area. Talk to the guard and observe the state of Vicky.";
        Context.text = "Vicky因為酒駕,被一個在 Tent area(使用地圖查看) 的警衛給 [Detention] 了起來. 觀察Vicky的處境後 與警衛對話.";
        tipcount -= 1;

    }
    public void Detention_RButtonClick() //顯示任務內容
    {
        //Context.text = "Help Npc to kill 3 Rabbits and answer the question correctly. Rabbits are near the Npc. He will give you the reward as retrun." + "\n" + "You already defeat" + LakeControl.Detention_Rabbit + "Rabbits";
        //Context.text = "幫助 NPC 擊敗 3 隻 Rabbits 並且回答問題(初次作答就答對會額外獲得獎勵). Rabbits 就在NPC附近,趕緊去擊敗他們吧!" + "\n" + "你已經擊敗了" + LakeControl.Detention_Rabbit + "隻 Rabbits";
        //tipcount -= 1;
    }
    public void BeautifyButtonClick()
    {
        //Context.text = "The trash behind you that can damage the landscape. Observe the change after you beautify the trash and pronounce word and sentences.";
        Context.text = "在你後面的垃圾會傷害環境. 請 [Beautify] 這個垃圾.";
        tipcount -= 1;
    }
    public void Beautify_RButtonClick() //顯示任務內容
    {
        //Context.text = "Help Npc to kill 3 Orc Wolfriders and answer the question correctly. Orc Wolfriders are near the Npc. He will give you the reward as retrun." + "\n" + "You already defeat" + LakeControl.Beautify_Wolfrider + "Orc Wolfriders";
        //Context.text = "幫助 NPC 擊敗 3 隻 Orc Wolfriders 並且回答問題(初次作答就答對會額外獲得獎勵). Orc Wolfriders 就在NPC附近,趕緊去擊敗他們吧!" + "\n" + "你已經擊敗了" + LakeControl.Beautify_Wolfrider + "隻 Orc Wolfriders";
        //tipcount -= 1;
    }
    public void DrainButtonClick()
    {
        //Context.text = "Go to the Ecological house (Using map) to talk to the man in suit and turn off those washing machines. Observe what the washing machine is doing [Drain]";
        Context.text = "到 Ecological house(可使用地圖找到) 跟一個西裝男性對話並關閉那些洗衣機. 觀察洗衣機正在做的事情 [Drain] 許多汙水.";
        tipcount -= 1;
    }
    public void Drain_RButtonClick() //顯示任務內容
    {
        //Context.text = "Help Npc to kill 3 'Dwarfs' and answer the question correctly. Dwarfs are near the Npc. He will give you the reward as retrun." + "\n" + "You already defeat" + LakeControl.Drain_Dwarf + "Dwarfs";
       // Context.text = "幫助 NPC 擊敗 3 隻 Dwarfs 並且回答問題(初次作答就答對會額外獲得獎勵). Dwarfs 就在NPC附近,趕緊去擊敗他們吧!" + "\n" + "你已經擊敗了" + LakeControl.Drain_Dwarf + "隻 Dwarfs";
        //tipcount -= 1;
    }
    public void ConcentrationButtonClick()
    {
        //Context.text = "The color of part of purification pond has changed.(The concentration of dirty water is getting high) Go to the place where is dark color of purification pond and choose the correct meaning of concentration.";
        Context.text = "部分 Purification pond(可使用地圖) 的顏色已經改變.(汙水的 [Concentration] 越來越高) 前往汙染嚴重的地區測量水的 [Concentration].";
        tipcount -= 1;
    }
    public void Concentration_RButtonClick() //顯示任務內容
    {
        //Context.text = "Help Npc to kill 3 'Mushrooms' and answer the question correctly. Mushrooms are near the Npc. He will give you the reward as retrun." + "\n" + "You already defeat" + LakeControl.Concentration_Mushroom + "Mushrooms";
        //Context.text = "幫助 NPC 擊敗 3 個 Mushrooms 並且回答問題(初次作答就答對會額外獲得獎勵). Mushrooms 就在NPC附近,趕緊去擊敗他們吧!" + "\n" + "你已經擊敗了" + LakeControl.Concentration_Mushroom + "個 Mushrooms";
        //tipcount -= 1;
    }
    public void EcologicalcorridorsButtonClick()
    {
        //Context.text = "The picture about Ecological corridors is in tent area. Observe the picture and pronounce word and sentences.";
        Context.text = "關於 [Ecological corridors] 的圖片在 Tent area(使用地圖) 的其中一個帳篷裡面. 觀察圖片並找出 [Ecological corridors] 的圖片";
        tipcount -= 1;
    }
    public void Ecologicalcorridors_RButtonClick() //顯示任務內容
    {
        //Context.text = "Help Npc to kill 3 'Devils' and answer the question correctly. Devils are near the Npc. He will give you the reward as retrun." + "\n" + "You already defeat" + LakeControl.Ecologicalcorridors_Devil + "Devils";
        //Context.text = "幫助 NPC 擊敗 3 隻 Devils 並且回答問題(初次作答就答對會額外獲得獎勵). Devils 就在NPC附近,趕緊去擊敗他們吧!" + "\n" + "你已經擊敗了" + LakeControl.Ecologicalcorridors_Devil + "隻 Devils";
        //tipcount -= 1;
    }
    public void PicturesqueButtonClick()
    {
        //Context.text = "The Picturesque picture is on the left side of Picturesque_NPC. Observe the Picturesque picture and pronounce word and sentences. ";
        Context.text = "關於 [Picturesque] 的圖片就在 Picturesque_NPC 左手邊. 找到圖片後請觀察圖片的情境並選出最符合[Picturesque].";
        tipcount -= 1;
    }
    public void Picturesque_RButtonClick() //顯示任務內容
    {
        //Context.text = "Help Npc to kill 3 'Bats' and answer the question correctly. Bats are near the Npc. He will give you the reward as retrun." + "\n" + "You already defeat" + LakeControl.Picturesque_Bat + "Bats";
        //Context.text = "幫助 NPC 擊敗 3 隻 Bats 並且回答問題(初次作答就答對會額外獲得獎勵). Bats 就在NPC附近,趕緊去擊敗他們吧!" + "\n" + "你已經擊敗了" + LakeControl.Picturesque_Bat + "隻 Bats";
        //tipcount -= 1;
    }
    public void AquaticButtonClick()
    {
        //Context.text = "Aquatic plants such as narcissus and lotus, growing in the pound which is around the big rock. Find it and pronounce word and sentences.";
        Context.text = "[Aquatic] 植物像是水仙或是蓮花, 生長在靠近 Big rock(使用地圖) 的水池裡. 找到並觀察植物的生長環境.";
        tipcount -= 1;
    }
    public void Aquatic_RButtonClick() //顯示任務內容
    {
        //Context.text = "Help Npc to kill 3 Slimes and answer the question correctly. Slimes are near the Npc. He will give you the reward as retrun." + "\n" + "You already defeat" + LakeControl.Aquatic_Slime + "Slimes";
        //Context.text = "幫助 NPC 擊敗 3 隻 Slimes 並且回答問題(初次作答就答對會額外獲得獎勵). Slimes 就在NPC附近,趕緊去擊敗他們吧!" + "\n" + "你已經擊敗了" + LakeControl.Aquatic_Slime + "隻 Slimes";
        //tipcount -= 1;
    }
    public void LandscapingButtonClick()
    {
        //Context.text = "Landscaping is a thing to increase biodiversity and create a place with more green-housing,like a potted plant. You will find it in the Purification house.(Using map)";
        Context.text = "[Landscaping] 是一個物品可以增進生態或是讓更建築物更綠化,像是盆栽. 你會在 Purification house (使用地圖) 找到他.";
        tipcount -= 1;
    }
    public void Landscaping_RButtonClick() //顯示任務內容
    {
        //Context.text = "Help Npc to kill 3 Stonemonsters and answer the question correctly. Stonemonsters are near the Npc. He will give you the reward as retrun." + "\n" + "You already defeat" + LakeControl.Landscaping_StoneMonster + "Stonemonsters";
        //Context.text = "幫助 NPC 擊敗 3 隻 Stonemonsters 並且回答問題(初次作答就答對會額外獲得獎勵). Stonemonsters 就在NPC附近,趕緊去擊敗他們吧!" + "\n" + "你已經擊敗了" + LakeControl.Landscaping_StoneMonster + "隻 Stonemonsters";
        //tipcount -= 1;
    }
    public void BiodiversityButtonClick()
    {
        //Context.text = "Find the box in the fenced area which has plenty of species.(Biodiversity)";
        Context.text = "在 Hill(使用地圖) 上找到擁有 [Biodiversity] 的Fence area(可使用地圖找到),並找尋裡面的盒子.";
        tipcount -= 1;
    }
    public void Biodiversity_RButtonClick() //顯示任務內容
    {
        //Context.text = "Help Npc to kill 3 Ghosts and answer the question correctly. Ghosts are near the Npc. He will give you the reward as retrun." + "\n" + "You already defeat" + LakeControl.Biodiversity_Ghost + "Ghosts";
        //Context.text = "幫助 NPC 擊敗 3 隻 Ghosts 並且回答問題(初次作答就答對會額外獲得獎勵). Ghosts 就在NPC附近,趕緊去擊敗他們吧!" + "\n" + "你已經擊敗了" + LakeControl.Biodiversity_Ghost + "隻 Ghosts";
        // tipcount -= 1;
    }
    public void AmphibianButtonClick()
    {
        //Context.text = "The poisonous frog is an Amphibian animal. Go to the tent which is on the hill. Observe the Amphibian animal and choose the correct meaning of Amphibian.";
        Context.text = "有毒的青蛙是一種 [Amphibian] 動物,在Hill上的帳篷(可使用地圖找到)裡面有一隻有毒的青蛙.";
        tipcount -= 1;
    }
    public void Amphibian_RButtonClick() //顯示任務內容
    {
        //Context.text = "Help Npc to kill 3 Stonemans and answer the question correctly. Stonemans are near the Npc. He will give you the reward as retrun." + "\n" + "You already defeat" + LakeControl.Amphibian_StoneMan + "Stonemans";
        //Context.text = "幫助 NPC 擊敗 3 隻 Stonemans 並且回答問題(初次作答就答對會額外獲得獎勵). Stonemans 就在NPC附近,趕緊去擊敗他們吧!" + "\n" + "你已經擊敗了" + LakeControl.Amphibian_StoneMan + "隻 Stonemans";
        //tipcount -= 1;
    }
    public void FinalmissionButtonClick()
    {
        Context.text = "The Npc in orange has final task for you. Please go find her when you complete all the tasks.";
    }
}
