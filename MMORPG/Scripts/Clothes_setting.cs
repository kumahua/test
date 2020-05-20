using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Clothes_setting : MonoBehaviour
{
    PhotonManager photonManger;
    public static Clothes_setting instance;
    int clothesindex = 0;
    int pantsindex = 0;
    int shoesindex = 0;
    int haircutindex = 0;
    public Button ChangeHair;
    GameObject Player; //角色
    GameObject Haircut; //髮型
    //衣服
    GameObject No1_clothes;
    GameObject No2_clothes;
    GameObject No3_clothes;
    GameObject No4_clothes;
    GameObject No5_clothes;
    GameObject No6_clothes;
    GameObject No7_clothes;
    GameObject No8_clothes;
    GameObject No9_clothes;
    GameObject No10_clothes;
    GameObject No11_clothes;
    //褲子
    GameObject No1_pants;
    GameObject No2_pants;
    GameObject No3_pants;
    GameObject No4_pants;
    GameObject No5_pants;
    GameObject No6_pants;
    GameObject No7_pants;
    //鞋子
    GameObject No1_shoes;
    GameObject No2_shoes;
    GameObject No3_shoes;

    void Awake()
    {
        if (instance != null)
        {
            instance = this;
            DestroyImmediate(this);
            return;
        }
        DontDestroyOnLoad(this);
        instance = this;
    }

        // Use this for initialization
        void Start() //初始值設定
    {

        photonManger = FindObjectOfType<PhotonManager>();

        if (photonManger.sex == 3)//如果角色是男生
        {
            //Player = GameObject.FindWithTag("Player");
            //髮型
            Haircut = GameObject.Find("bb_male_haircut");
            Haircut.SetActive(false);
            //衣服
            No1_clothes = GameObject.Find("hoodie_blue");
            No1_clothes.SetActive(false);
            No2_clothes = GameObject.Find("hoodie_blueWhite");
            No2_clothes.SetActive(false);
            No3_clothes = GameObject.Find("hoodie_grey");
            No3_clothes.SetActive(false);
            No4_clothes = GameObject.Find("jacket_hive");
            No4_clothes.SetActive(false);
            No5_clothes = GameObject.Find("male_tanktop_yellow");
            No5_clothes.SetActive(false);
            No6_clothes = GameObject.Find("tshirt_white");
            No6_clothes.SetActive(true);
            //褲子
            No1_pants = GameObject.Find("shorts_hive");
            No1_pants.SetActive(false);
            No2_pants = GameObject.Find("shorts_white");
            No2_pants.SetActive(false);
            No3_pants = GameObject.Find("sportpants_alt_black");
            No3_pants.SetActive(false);
            No4_pants = GameObject.Find("sportpants_blueWhite");
            No4_pants.SetActive(false);
            No5_pants = GameObject.Find("sweatpants_black");
            No5_pants.SetActive(false);
            No6_pants = GameObject.Find("swimwear_granit");
            No6_pants.SetActive(false);
            No7_pants = GameObject.Find("sportpants_grey");
            No7_pants.SetActive(true);
            //鞋子
            No1_shoes = GameObject.Find("shoe_low_white");
            No1_shoes.SetActive(false);
            No2_shoes = GameObject.Find("shoes_tall_turquoise");
            No2_shoes.SetActive(false);
            No3_shoes = GameObject.Find("shoes_tall");
            No3_shoes.SetActive(true);

        }
        if (photonManger.sex == 4)//如果角色是女生
        {
            //Player = GameObject.FindWithTag("Player");
            //衣服
            No1_clothes = GameObject.Find("jacket_hive");
            No1_clothes.SetActive(false);
            No2_clothes = GameObject.Find("dress_tennis_granit");
            No2_clothes.SetActive(false);
            No3_clothes = GameObject.Find("Hoodie_turquoise");
            No3_clothes.SetActive(false);
            No4_clothes = GameObject.Find("sportswear_sweater_granit");
            No4_clothes.SetActive(false);
            No5_clothes = GameObject.Find("sportswear_top");
            No5_clothes.SetActive(false);
            No6_clothes = GameObject.Find("sportswear_top_granit");
            No6_clothes.SetActive(false);
            No7_clothes = GameObject.Find("tanktop_whiteBlackStraps");
            No7_clothes.SetActive(false);
            No8_clothes = GameObject.Find("tanktop_yellow");
            No8_clothes.SetActive(false);
            No9_clothes = GameObject.Find("tanktop_zebra");
            No9_clothes.SetActive(false);
            No10_clothes = GameObject.Find("swimwear_black_top");
            No10_clothes.SetActive(false);
            No11_clothes = GameObject.Find("tshirt_turquoise");
            No11_clothes.SetActive(true);

            //褲子
            No1_pants = GameObject.Find("shorts_turquoise");
            No1_pants.SetActive(false);
            No2_pants = GameObject.Find("tights_stripe");
            No2_pants.SetActive(false);
            No3_pants = GameObject.Find("tights_gray");
            No3_pants.SetActive(false);
            No4_pants = GameObject.Find("sportwear_pants_granit");
            No4_pants.SetActive(false);
            No5_pants = GameObject.Find("green_tights");
            No5_pants.SetActive(false);
            No6_pants = GameObject.Find("colors_top_bottom");
            No6_pants.SetActive(false);
            No7_pants = GameObject.Find("tights_purple");
            No7_pants.SetActive(true);
            //鞋子
            No1_shoes = GameObject.Find("shoes_tall_white");
            No1_shoes.SetActive(false);
            No2_shoes = GameObject.Find("shoes_tall_turquoise");
            No2_shoes.SetActive(false);
            No3_shoes = GameObject.Find("shoe_low_white");
            No3_shoes.SetActive(true);
        }






    }

    // Update is called once per frame
    void Update()
    {

    }

    public void changeclothes() //衣服
    {
        if (photonManger.sex == 3) //如果是男生
        {
            switch (clothesindex)//拿什麼東西來做判斷
            {
                case 0://選項為0
                       //No11_clothes.SetActive(true);
                    clothesindex++;
                    break;//每個case 要以break;結尾
                case 1://選項為
                    No6_clothes.SetActive(false);
                    No1_clothes.SetActive(true);
                    clothesindex++;
                    break;//每個case 要以break;結尾
                case 2://
                    No1_clothes.SetActive(false);
                    No2_clothes.SetActive(true);
                    clothesindex++;
                    break;//每個case 要以break;結尾
                case 3://
                    No2_clothes.SetActive(false);
                    No3_clothes.SetActive(true);
                    clothesindex++;
                    break;//每個case 要以break;結尾
                case 4://
                    No3_clothes.SetActive(false);
                    No4_clothes.SetActive(true);
                    clothesindex++;
                    break;//每個case 要以break;結尾
                case 5://
                    No4_clothes.SetActive(false);
                    No5_clothes.SetActive(true);
                    clothesindex++;
                    break;//每個case 要以break;結尾
                default://以上都不成立執行預設值
                    No5_clothes.SetActive(false);
                    No6_clothes.SetActive(true);
                    clothesindex = 0;
                    clothesindex++;
                    break;
            }
        }
            if (photonManger.sex == 4) //如果是女生
        {
            switch (clothesindex)//拿什麼東西來做判斷
            {
                case 0://選項為0
                       //No11_clothes.SetActive(true);
                    clothesindex++;
                    break;//每個case 要以break;結尾
                case 1://選項為
                    No11_clothes.SetActive(false);
                    No1_clothes.SetActive(true);
                    clothesindex++;
                    break;//每個case 要以break;結尾
                case 2://
                    No1_clothes.SetActive(false);
                    No2_clothes.SetActive(true);
                    clothesindex++;
                    break;//每個case 要以break;結尾
                case 3://
                    No2_clothes.SetActive(false);
                    No3_clothes.SetActive(true);
                    clothesindex++;
                    break;//每個case 要以break;結尾
                case 4://
                    No3_clothes.SetActive(false);
                    No4_clothes.SetActive(true);
                    clothesindex++;
                    break;//每個case 要以break;結尾
                case 5://
                    No4_clothes.SetActive(false);
                    No5_clothes.SetActive(true);
                    clothesindex++;
                    break;//每個case 要以break;結尾
                case 6://
                    No5_clothes.SetActive(false);
                    No6_clothes.SetActive(true);
                    clothesindex++;
                    break;//每個case 要以break;結尾
                case 7://
                    No6_clothes.SetActive(false);
                    No7_clothes.SetActive(true);
                    clothesindex++;
                    break;//每個case 要以break;結尾
                case 8://
                    No7_clothes.SetActive(false);
                    No8_clothes.SetActive(true);
                    clothesindex++;
                    break;//每個case 要以break;結尾
                case 9://
                    No8_clothes.SetActive(false);
                    No9_clothes.SetActive(true);
                    clothesindex++;
                    break;//每個case 要以break;結尾
                case 10://
                    No9_clothes.SetActive(false);
                    No10_clothes.SetActive(true);
                    clothesindex++;
                    break;//每個case 要以break;結尾
                default://以上都不成立執行預設值
                    No10_clothes.SetActive(false);
                    No11_clothes.SetActive(true);
                    clothesindex = 0;
                    clothesindex++;
                    break;
            }
        }
    }
    public void changepants()   //褲子
    {
        if (photonManger.sex == 3) //如果是男生
        {
            switch (pantsindex)//拿什麼東西來做判斷
            {
                case 0://選項為0
                    pantsindex++;
                    break;//每個case 要以break;結尾
                case 1://選項為
                    No7_pants.SetActive(false);
                    No1_pants.SetActive(true);
                    pantsindex++;
                    break;//每個case 要以break;結尾
                case 2://
                    No1_pants.SetActive(false);
                    No2_pants.SetActive(true);
                    pantsindex++;
                    break;//每個case 要以break;結尾
                case 3://
                    No2_pants.SetActive(false);
                    No3_pants.SetActive(true);
                    pantsindex++;
                    break;//每個case 要以break;結尾
                case 4://
                    No3_pants.SetActive(false);
                    No4_pants.SetActive(true);
                    pantsindex++;
                    break;//每個case 要以break;結尾
                case 5://
                    No4_pants.SetActive(false);
                    No5_pants.SetActive(true);
                    pantsindex++;
                    break;//每個case 要以break;結尾
                case 6://
                    No5_pants.SetActive(false);
                    No6_pants.SetActive(true);
                    pantsindex++;
                    break;//每個case 要以break;結尾      
                default://以上都不成立執行預設值
                    No6_pants.SetActive(false);
                    No7_pants.SetActive(true);
                    pantsindex = 0;
                    pantsindex++;
                    break;
            }
        }
        if (photonManger.sex == 4) //如果是女生
        {
            switch (pantsindex)//拿什麼東西來做判斷
            {
                case 0://選項為0
                    pantsindex++;
                    break;//每個case 要以break;結尾
                case 1://選項為
                    No7_pants.SetActive(false);
                    No1_pants.SetActive(true);
                    pantsindex++;
                    break;//每個case 要以break;結尾
                case 2://
                    No1_pants.SetActive(false);
                    No2_pants.SetActive(true);
                    pantsindex++;
                    break;//每個case 要以break;結尾
                case 3://
                    No2_pants.SetActive(false);
                    No3_pants.SetActive(true);
                    pantsindex++;
                    break;//每個case 要以break;結尾
                case 4://
                    No3_pants.SetActive(false);
                    No4_pants.SetActive(true);
                    pantsindex++;
                    break;//每個case 要以break;結尾
                case 5://
                    No4_pants.SetActive(false);
                    No5_pants.SetActive(true);
                    pantsindex++;
                    break;//每個case 要以break;結尾
                case 6://
                    No5_pants.SetActive(false);
                    No6_pants.SetActive(true);
                    pantsindex++;
                    break;//每個case 要以break;結尾      
                default://以上都不成立執行預設值
                    No6_pants.SetActive(false);
                    No7_pants.SetActive(true);
                    pantsindex = 0;
                    pantsindex++;
                    break;
            }
        }
    }
    public void changeshoes()   //鞋子
    {
        if (photonManger.sex == 3) //如果是男生
        {
            switch (shoesindex)//拿什麼東西來做判斷
            {
                case 0://選項為0
                    shoesindex++;
                    break;//每個case 要以break;結尾
                case 1://選項為
                    No3_shoes.SetActive(false);
                    No1_shoes.SetActive(true);
                    shoesindex++;
                    break;//每個case 要以break;結尾
                case 2://
                    No1_shoes.SetActive(false);
                    No2_shoes.SetActive(true);
                    shoesindex++;
                    break;//每個case 要以break;結尾  
                default://以上都不成立執行預設值
                    No2_shoes.SetActive(false);
                    No3_shoes.SetActive(true);
                    shoesindex = 0;
                    shoesindex++;
                    break;
            }
        }
        if (photonManger.sex == 4) //如果是女生
        {
            switch (shoesindex)//拿什麼東西來做判斷
            {
                case 0://選項為0
                    shoesindex++;
                    break;//每個case 要以break;結尾
                case 1://選項為
                    No3_shoes.SetActive(false);
                    No1_shoes.SetActive(true);
                    shoesindex++;
                    break;//每個case 要以break;結尾
                case 2://
                    No1_shoes.SetActive(false);
                    No2_shoes.SetActive(true);
                    shoesindex++;
                    break;//每個case 要以break;結尾  
                default://以上都不成立執行預設值
                    No2_shoes.SetActive(false);
                    No3_shoes.SetActive(true);
                    shoesindex = 0;
                    shoesindex++;
                    break;
            }
        }
    }
    public void changehair()
    {
        if (photonManger.sex == 3)
        {
            switch (haircutindex)//拿什麼東西來做判斷
            {
                case 0://選項為0
                    Haircut.SetActive(false);
                    haircutindex++;
                    break;//每個case 要以break;結尾
                default://以上都不成立執行預設值
                    Haircut.SetActive(true);
                   haircutindex = 0;              
                    break;
            }
            
        }
    }
}
