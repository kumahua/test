using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpeechLib;
using Fungus;

public class TTS : MonoBehaviour {

    private SpVoice voice;
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
    public string speak;
    public float mission =-1;
    public float state = -1;
    private string Insert_Listening= "http://140.115.126.115:3000/Insert_Listening?account=";

    public  bool Serene_isTalking // 選擇答案名稱-設定值給fungus
    {
        get { return Rightpic_Flowchart.GetBooleanVariable("isTalking"); } //從Fungus取值
        set { Rightpic_Flowchart.SetBooleanVariable("isTalking", value); } //設定給Fungus
    }
    public  bool Thoughtful_isTalking // 選擇答案名稱-設定值給fungus
    {
        get { return Thoughtful_NPC_Flowchart.GetBooleanVariable("isTalking"); } //從Fungus取值
        set { Thoughtful_NPC_Flowchart.SetBooleanVariable("isTalking", value); } //設定給Fungus
    }
    public  bool Subsidy_isTalking // 選擇答案名稱-設定值給fungus
    {
        get { return Subsidy_NPC_Flowchart.GetBooleanVariable("isTalking"); } //從Fungus取值
        set { Subsidy_NPC_Flowchart.SetBooleanVariable("isTalking", value); } //設定給Fungus
    }
    public  bool Purification_isTalking // 選擇答案名稱-設定值給fungus
    {
        get { return NPC04_Mission_Flowchart.GetBooleanVariable("isTalking"); } //從Fungus取值
        set { NPC04_Mission_Flowchart.SetBooleanVariable("isTalking", value); } //設定給Fungus
    }
    public  bool Detention_isTalking // 選擇答案名稱-設定值給fungus
    {
        get { return Detention_Flowchart.GetBooleanVariable("isTalking"); } //從Fungus取值
        set { Detention_Flowchart.SetBooleanVariable("isTalking", value); } //設定給Fungus
    }
    public  bool Beautify_isTalking // 選擇答案名稱-設定值給fungus
    {
        get { return NPC05_Mission_Flowchart.GetBooleanVariable("isTalking"); } //從Fungus取值
        set { NPC05_Mission_Flowchart.SetBooleanVariable("isTalking", value); } //設定給Fungus
    }
    public  bool Concentration_isTalking // 選擇答案名稱-設定值給fungus
    {
        get { return Concentration_Mission_Flowchart.GetBooleanVariable("isTalking"); } //從Fungus取值
        set { Concentration_Mission_Flowchart.SetBooleanVariable("isTalking", value); } //設定給Fungus
    }
    public  bool Ecological_isTalking // 選擇答案名稱-設定值給fungus
    {
        get { return Mission_Ecological_corridors_Flowchart.GetBooleanVariable("isTalking"); } //從Fungus取值
        set { Mission_Ecological_corridors_Flowchart.SetBooleanVariable("isTalking", value); } //設定給Fungus
    }
    public  bool Picturesque_isTalking // 選擇答案名稱-設定值給fungus
    {
        get { return Mission_Picturesque_Flowchart.GetBooleanVariable("isTalking"); } //從Fungus取值
        set { Mission_Picturesque_Flowchart.SetBooleanVariable("isTalking", value); } //設定給Fungus
    }
    public  bool Drain_isTalking // 選擇答案名稱-設定值給fungus
    {
        get { return Mission_NPC1208101711Flowchart.GetBooleanVariable("Drain_isTalking"); } //從Fungus取值
        set { Mission_NPC1208101711Flowchart.SetBooleanVariable("Drain_isTalking", value); } //設定給Fungus
    }
    public  bool Aquatic_isTalking // 選擇答案名稱-設定值給fungus
    {
        get { return Mission_NPC1208101711Flowchart.GetBooleanVariable("Aquatic_isTalking"); } //從Fungus取值
        set { Mission_NPC1208101711Flowchart.SetBooleanVariable("Aquatic_isTalking", value); } //設定給Fungus
    }
    public  bool Landscaping_isTalking // 選擇答案名稱-設定值給fungus
    {
        get { return Mission_NPC1208101711Flowchart.GetBooleanVariable("Landscaping_isTalking"); } //從Fungus取值
        set { Mission_NPC1208101711Flowchart.SetBooleanVariable("Landscaping_isTalking", value); } //設定給Fungus
    }
    public  bool Biodiversity_isTalking // 選擇答案名稱-設定值給fungus
    {
        get { return Mission_NPC1208101711Flowchart.GetBooleanVariable("Biodiversity_isTalking"); } //從Fungus取值
        set { Mission_NPC1208101711Flowchart.SetBooleanVariable("Biodiversity_isTalking", value); } //設定給Fungus
    }
    public  bool Amphibian_isTalking // 選擇答案名稱-設定值給fungus
    {
        get { return Mission_NPC1208101711Flowchart.GetBooleanVariable("Amphibian_isTalking"); } //從Fungus取值
        set { Mission_NPC1208101711Flowchart.SetBooleanVariable("Amphibian_isTalking", value); } //設定給Fungus
    }

    public bool Review_isTalking // 選擇答案名稱-設定值給fungus
    {
        get { return Mission_NPC1208101711Flowchart.GetBooleanVariable("Review_isTalking"); } //從Fungus取值
        set { Mission_NPC1208101711Flowchart.SetBooleanVariable("Review_isTalking", value); } //設定給Fungus
    }


    public string Serene_speak // 選擇答案名稱-設定值給fungus
    {
        get { return Rightpic_Flowchart.GetStringVariable("speak"); } //從Fungus取值
        set { Rightpic_Flowchart.SetStringVariable("speak", value); } //設定給Fungus
    }
    public string Thoughtful_speak // 選擇答案名稱-設定值給fungus
    {
        get { return Thoughtful_NPC_Flowchart.GetStringVariable("speak"); } //從Fungus取值
        set { Thoughtful_NPC_Flowchart.SetStringVariable("speak", value); } //設定給Fungus
    }
    public string Subsidy_speak // 選擇答案名稱-設定值給fungus
    {
        get { return Subsidy_NPC_Flowchart.GetStringVariable("speak"); } //從Fungus取值
        set { Subsidy_NPC_Flowchart.SetStringVariable("speak", value); } //設定給Fungus
    }
    public string Purification_speak // 選擇答案名稱-設定值給fungus
    {
        get { return NPC04_Mission_Flowchart.GetStringVariable("speak"); } //從Fungus取值
        set { NPC04_Mission_Flowchart.SetStringVariable("speak", value); } //設定給Fungus
    }
    public string Detention_speak // 選擇答案名稱-設定值給fungus
    {
        get { return Detention_Flowchart.GetStringVariable("speak"); } //從Fungus取值
        set { Detention_Flowchart.SetStringVariable("speak", value); } //設定給Fungus
    }
    public string Beautify_speak // 選擇答案名稱-設定值給fungus
    {
        get { return NPC05_Mission_Flowchart.GetStringVariable("speak"); } //從Fungus取值
        set { NPC05_Mission_Flowchart.SetStringVariable("speak", value); } //設定給Fungus
    }
    public string Concentration_speak // 選擇答案名稱-設定值給fungus
    {
        get { return Concentration_Mission_Flowchart.GetStringVariable("speak"); } //從Fungus取值
        set { Concentration_Mission_Flowchart.SetStringVariable("speak", value); } //設定給Fungus
    }
    public string Ecological_speak // 選擇答案名稱-設定值給fungus
    {
        get { return Mission_Ecological_corridors_Flowchart.GetStringVariable("speak"); } //從Fungus取值
        set { Mission_Ecological_corridors_Flowchart.SetStringVariable("speak", value); } //設定給Fungus
    }
    public string Picturesque_speak // 選擇答案名稱-設定值給fungus
    {
        get { return Mission_Picturesque_Flowchart.GetStringVariable("speak"); } //從Fungus取值
        set { Mission_Picturesque_Flowchart.SetStringVariable("speak", value); } //設定給Fungus
    }
    public string Mix_speak // 選擇答案名稱-設定值給fungus
    {
        get { return Mission_NPC1208101711Flowchart.GetStringVariable("speak"); } //從Fungus取值
        set { Mission_NPC1208101711Flowchart.SetStringVariable("speak", value); } //設定給Fungus
    }
    public string Practice_speak // 選擇答案名稱-設定值給fungus
    {
        get { return FightFlowchart.GetStringVariable("speak"); } //從Fungus取值
        set { FightFlowchart.SetStringVariable("speak", value); } //設定給Fungus
    }

    public int Serene_Status // 選擇答案名稱-設定值給fungus
    {
        get { return Rightpic_Flowchart.GetIntegerVariable("Status"); } //從Fungus取值
        set { Rightpic_Flowchart.SetIntegerVariable("Status", value); } //設定給Fungus
    }
    public int Thoughtful_Status // 選擇答案名稱-設定值給fungus
    {
        get { return Thoughtful_NPC_Flowchart.GetIntegerVariable("Status"); } //從Fungus取值
        set { Thoughtful_NPC_Flowchart.SetIntegerVariable("Status", value); } //設定給Fungus
    }
    public int Subsidy_Status // 選擇答案名稱-設定值給fungus
    {
        get { return Subsidy_NPC_Flowchart.GetIntegerVariable("Status"); } //從Fungus取值
        set { Subsidy_NPC_Flowchart.SetIntegerVariable("Status", value); } //設定給Fungus
    }
    public int Purification_Status // 選擇答案名稱-設定值給fungus
    {
        get { return NPC04_Mission_Flowchart.GetIntegerVariable("Status"); } //從Fungus取值
        set { NPC04_Mission_Flowchart.SetIntegerVariable("Status", value); } //設定給Fungus
    }
    public int Detention_Status // 選擇答案名稱-設定值給fungus
    {
        get { return Detention_Flowchart.GetIntegerVariable("Status"); } //從Fungus取值
        set { Detention_Flowchart.SetIntegerVariable("Status", value); } //設定給Fungus
    }
    public int Beautify_Status // 選擇答案名稱-設定值給fungus
    {
        get { return NPC05_Mission_Flowchart.GetIntegerVariable("Status"); } //從Fungus取值
        set { NPC05_Mission_Flowchart.SetIntegerVariable("Status", value); } //設定給Fungus
    }
    public int Concentration_Status // 選擇答案名稱-設定值給fungus
    {
        get { return Concentration_Mission_Flowchart.GetIntegerVariable("Status"); } //從Fungus取值
        set { Concentration_Mission_Flowchart.SetIntegerVariable("Status", value); } //設定給Fungus
    }
    public int Ecological_Status // 選擇答案名稱-設定值給fungus
    {
        get { return Mission_Ecological_corridors_Flowchart.GetIntegerVariable("Status"); } //從Fungus取值
        set { Mission_Ecological_corridors_Flowchart.SetIntegerVariable("Status", value); } //設定給Fungus
    }
    public int Picturesque_Status // 選擇答案名稱-設定值給fungus
    {
        get { return Mission_Picturesque_Flowchart.GetIntegerVariable("Status"); } //從Fungus取值
        set { Mission_Picturesque_Flowchart.SetIntegerVariable("Status", value); } //設定給Fungus
    }
    public int Drain_Status // 選擇答案名稱-設定值給fungus
    {
        get { return Mission_NPC1208101711Flowchart.GetIntegerVariable("Status"); } //從Fungus取值
        set { Mission_NPC1208101711Flowchart.SetIntegerVariable("Status", value); } //設定給Fungus
    }
    public int Aquatic_Status // 選擇答案名稱-設定值給fungus
    {
        get { return Mission_NPC1208101711Flowchart.GetIntegerVariable("Status"); } //從Fungus取值
        set { Mission_NPC1208101711Flowchart.SetIntegerVariable("Status", value); } //設定給Fungus
    }
    public int Landscaping_Status // 選擇答案名稱-設定值給fungus
    {
        get { return Mission_NPC1208101711Flowchart.GetIntegerVariable("Status"); } //從Fungus取值
        set { Mission_NPC1208101711Flowchart.SetIntegerVariable("Status", value); } //設定給Fungus
    }
    public int Biodiversity_Status // 選擇答案名稱-設定值給fungus
    {
        get { return Mission_NPC1208101711Flowchart.GetIntegerVariable("Status"); } //從Fungus取值
        set { Mission_NPC1208101711Flowchart.SetIntegerVariable("Status", value); } //設定給Fungus
    }
    public int Amphibian_Status // 選擇答案名稱-設定值給fungus
    {
        get { return Mission_NPC1208101711Flowchart.GetIntegerVariable("Status"); } //從Fungus取值
        set { Mission_NPC1208101711Flowchart.SetIntegerVariable("Status", value); } //設定給Fungus
    }

    public int Review_Status // 選擇答案名稱-設定值給fungus
    {
        get { return Mission_NPC1208101711Flowchart.GetIntegerVariable("Status"); } //從Fungus取值
        set { Mission_NPC1208101711Flowchart.SetIntegerVariable("Status", value); } //設定給Fungus
    }




    void Start()
    {
        voice = new SpVoice();
    }

    // Update is called once per frame
    void Update()
    {
    //  if (Input.GetKeyDown(KeyCode.P))
    //  {
    //      voice.Pause();
    //
    //  }
    //  if (Input.GetKeyDown(KeyCode.R))
    //  {
    //      voice.Resume();
    //  }
    }
    public void Speak()
    {
        if (Serene_isTalking == true)
        {
            speak = Serene_speak;
            mission = 1;
            state = Serene_Status;
            
        }
        else if(Thoughtful_isTalking == true){
            speak = Thoughtful_speak;
            mission = 2;
            state = Thoughtful_Status;
            
        }
        else if(Subsidy_isTalking == true)
        {
            speak = Subsidy_speak;
            mission = 3;
            state = Subsidy_Status;
            
        }
        else if (Purification_isTalking == true)
        {
            speak = Purification_speak;
            mission = 4;
            state = Purification_Status;
            
        }
        else if(Detention_isTalking == true)
        {
            speak = Detention_speak;
            mission = 5;
            state = Detention_Status;
            
        }
        else if (Beautify_isTalking == true)
        {
            speak = Beautify_speak;
            mission = 6;
            state = Beautify_Status;
            
        }
        else if (Concentration_isTalking == true)
        {
            speak = Concentration_speak;
            mission = 8;
            state = Concentration_Status;
            
        }
        else if (Ecological_isTalking == true)
        {
            speak = Ecological_speak;
            mission = 9;
            state = Ecological_Status;
            
        }
        else if (Picturesque_isTalking == true)
        {
            speak = Picturesque_speak;
            mission = 10;
            state = Purification_Status;
            
        }
        else if (Drain_isTalking == true)
        {
            speak = Mix_speak;
            mission = 7;
            state = Detention_Status;
            
        }
        else if (Aquatic_isTalking == true)
        {
            speak = Mix_speak;
            mission = 11;
            state = Aquatic_Status;
            
        }
        else if (Landscaping_isTalking == true)
        {
            speak = Mix_speak;
            mission = 12;
            state = Landscaping_Status;
            
        }
        else if (Biodiversity_isTalking == true)
        {
            speak = Mix_speak;
            mission = 13;
            state = Biodiversity_Status;
            
        }
        else if (Amphibian_isTalking == true)
        {
            speak = Mix_speak;
            mission = 14;
            state = Amphibian_Status;
            
        }else if (Review_isTalking == true)
        {
            speak = Mix_speak;
            mission = 29;
            state = Review_Status;
        }
        else
        {
            speak = Practice_speak;
            if (speak == "Serene")
            {
                mission = 15;
                state = 0;
            }
            else if (speak == "You will see a serene skies and a bright blue lake out there.")
            {
                mission = 15;
                state = 1;
            }
            else if (speak == "Love helps us stay calm and serene even when things are tough.")
            {
                mission = 15;
                state = 2;
            }
            else if (speak == "This is the perfect place to slowly unwind in serene rural surroundings.")
            {
                mission = 15;
                state = 3;
            }
            else if (speak == "Thoughtful")
            {
                mission = 16;
                state = 0;
            }
            else if (speak == "The book is a thoughtful account of his journeys in Taiwan.")
            {
                mission = 16;
                state = 1;
            }
            else if (speak == "It is very thoughtful of you to bring me the book.")
            {
                mission = 16;
                state = 2;
            }
            else if (speak == "You should be more thoughtful about how to manage your time.")
            {
                mission = 16;
                state = 3;
            }
            else if (speak == "Subsidy")
            {
                mission = 17;
                state = 0;
            }
            else if (speak == "There were also pledges to soften the impact of the subsidy cuts on the poorer regions.")
            {
                mission = 17;
                state = 1;
            }
            else if (speak == "They received a subsidy in the form of a percentage of all foreign trade operations.")
            {
                mission = 17;
                state = 2;
            }
            else if (speak == "The university will gain a subsidy for research in artificial intelligence.")
            {
                mission = 17;
                state = 3;
            }
            else if (speak == "Purification")
            {
                mission = 18;
                state = 0;
            }
            else if (speak == "The water goes through three stages of purification.")
            {
                mission = 18;
                state = 1;
            }
            else if (speak == "Reading a good book may bring purification to our souls.")
            {
                mission = 18;
                state = 2;
            }
            else if (speak == "Distillation has traditionally been the major system for water purification.")
            {
                mission = 18;
                state = 3;
            }
            else if (speak == "Detention")
            {
                mission = 19;
                state = 0;
            }
            else if (speak == "The teacher kept the boys in detention after school.")
            {
                mission = 19;
                state = 1;
            }
            else if (speak == "She prefers to stay in detention rather than be released and go into exile.")
            {
                mission = 19;
                state = 2;
            }
            else if (speak == "They have been held in detention since the end of June.")
            {
                mission = 19;
                state = 3;
            }
            else if (speak == "Beautify")
            {
                mission = 20;
                state = 0;
            }
            else if (speak == "The City Council has a manifold plan to beautify the city.")
            {
                mission = 20;
                state = 1;
            }
            else if (speak == "We should spare no effort to beautify our environment.")
            {
                mission = 20;
                state = 2;
            }
            else if (speak == "Planting flowers along the boulevards will help to beautify the town.")
            {
                mission = 20;
                state = 3;
            }
            else if (speak == "Drain")
            {
                mission = 21;
                state = 0;
            }
            else if (speak == "The water will soon drain away.")
            {
                mission = 21;
                state = 1;
            }
            else if (speak == "Clogged pipes caused drain water to back up into the room.")
            {
                mission = 21;
                state = 2;
            }
            else if (speak == "The company was still going down the drain.")
            {
                mission = 21;
                state = 3;
            }
            else if (speak == "Concentration")
            {
                mission = 22;
                state = 0;
            }
            else if (speak == "There is a heavy concentration of troops in the area.")
            {
                mission = 22;
                state = 1;
            }
            else if (speak == "I knew that concentration was the first requirement for learning.")
            {
                mission = 22;
                state = 2;
            }
            else if (speak == "This book requires a great deal of concentration.")
            {
                mission = 22;
                state = 3;
            }
            else if (speak == "Ecological")
            {
                mission = 23;
                state = 0;
            }
            else if (speak == "It is an ecological disaster with no parallel anywhere else in the world.")
            {
                mission = 23;
                state = 1;
            }
            else if (speak == "The region has been declared an ecological disaster zone.")
            {
                mission = 23;
                state = 2;
            }
            else if (speak == "Fire prevents ecological succession in the open habitat where the plant grows.")
            {
                mission = 23;
                state = 3;
            }
            else if (speak == "Picturesque")
            {
                mission = 24;
                state = 0;
            }
            else if (speak == "You can see the picturesque shores beside the river.")
            {
                mission = 24;
                state = 1;
            }
            else if (speak == "Last night the scenery was striking and picturesque.")
            {
                mission = 24;
                state = 2;
            }
            else if (speak == "Last night the scenery was striking and picturesque.")
            {
                mission = 24;
                state = 3;
            }
            else if (speak == "Aquatic")
            {
                mission = 25;
                state = 0;
            }
            else if (speak == "Aquatic sports include swimming and rowing.")
            {
                mission = 25;
                state = 1;
            }
            else if (speak == "Aquatic food chains are different from terrestrial ones.")
            {
                mission = 25;
                state = 2;
            }
            else if (speak == "Certain species of aquatic animals are capable of producing physiological shocks.")
            {
                mission = 25;
                state = 3;
            }
            else if (speak == "Landscaping")
            {
                mission = 26;
                state = 0;
            }
            else if (speak == "The landowner insisted on a high standard of landscaping.")
            {
                mission = 26;
                state = 1;
            }
            else if (speak == "Landscaping will be used for leisure or irrigated as agricultural land. ")
            {
                mission = 26;
                state = 2;
            }
            else if (speak == "The flooring and landscaping will be done by the contractor.")
            {
                mission = 26;
                state = 3;
            }
            else if (speak == "Biodiversity")
            {
                mission = 27;
                state = 0;
            }
            else if (speak == "Butterflies are indicators of the biodiversity of our natural environment.")
            {
                mission = 27;
                state = 1;
            }
            else if (speak == "We are on the verge of a major biodiversity crisis.")
            {
                mission = 27;
                state = 2;
            }
            else if (speak == "The protection of biodiversity has been the focus of agricultural research for years.")
            {
                mission = 27;
                state = 3;
            }
            else if (speak == "Amphibian")
            {
                mission = 28;
                state = 0;
            }
            else if (speak == "Both the toad and frog are amphibian.")
            {
                mission = 28;
                state = 1;
            }
            else if (speak == "Amphibians live partly in water and partly on land.")
            {
                mission = 28;
                state = 2;
            }
            else if (speak == "All amphibians begin their life in water with gills and tails.")
            {
                mission = 28;
                state = 3;
            }
        }
        voice.Volume = 100; // Volume (no xml)
        voice.Rate = 0;  //   Rate (no xml)
        voice.Speak("<speak version='1.0' xmlns='http://www.w3.org/2001/10/synthesis' xml:lang='en-US'>"
                    + speak//"English One, two, three"
                           //+"<p xml:lang='zh-TW'> 這裡可以說中文</p>"
                    + "</speak>",
                    SpeechVoiceSpeakFlags.SVSFlagsAsync | SpeechVoiceSpeakFlags.SVSFIsXML);
        BagViewScript.badge[4].BadgesCount++;
        WWWForm Form = new WWWForm();
        WWW WWW = new WWW(Insert_Listening + LoginScript.Account + "&NPC_ID=" + mission + "&Status=" + state);
        if (WWW.error != null)
        {
            Debug.LogError("寫入錯誤");
        }
    }
}

    
                                                                    