using UnityEngine;
using System.Collections;

public class MaleCustomizatipn : MonoBehaviour {
    public GameObject Male;
    public GameObject clothes;
    public GameObject clothes_a;
    public GameObject clothes_b;
    public GameObject clothes_c;
    public GameObject clothes_d;
    public GameObject clothes_e;
    public GameObject pants;
    public GameObject pants_a;
    public GameObject pants_b;
    public GameObject pants_c;
    public GameObject pants_d;
    public GameObject pants_e;
    public GameObject pants_f;
    public GameObject pants_g;
    public GameObject shoes_a;
    public GameObject shoes_b;
    public GameObject shoes_c;

    public int index = 0;
    public int index_p = 0;
    public int index_s = 0;

    // Use this for initialization
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
        //Male.transform.Rotate(0, 0.5f, 0);
    }

    public void changeclothes()
    {
        switch (index)//拿什麼東西來做判斷
        {
            case 0://選項為0
                clothes.SetActive(false);
                clothes_a.SetActive(true);
                index++;
                break;//每個case 要以break;結尾
            case 1://選項為
                clothes_a.SetActive(false);
                clothes_b.SetActive(true);
                index++;
                break;//每個case 要以break;結尾
            case 2://
                clothes_b.SetActive(false);
                clothes_c.SetActive(true);
                index++;
                break;//每個case 要以break;結尾
            case 3://
                clothes_c.SetActive(false);
                clothes_d.SetActive(true);
                index++;
                break;//每個case 要以break;結尾
            case 4://
                clothes_d.SetActive(false);
                clothes_e.SetActive(true);
                index++;
                break;//每個case 要以break;結尾
            default://以上都不成立執行預設值
                clothes_e.SetActive(false);
                clothes.SetActive(true);
                index = 0;
                break;
        }
    }

    public void changepants()
    {
        switch (index_p)//拿什麼東西來做判斷

        {
            case 0://選項為0
                pants.SetActive(false);
                pants_a.SetActive(true);
                index_p++;
                break;//每個case 要以break;結尾
            case 1://選項為
                pants_a.SetActive(false);
                pants_b.SetActive(true);
                index_p++;
                break;//每個case 要以break;結尾
            case 2://
                pants_b.SetActive(false);
                pants_c.SetActive(true);
                index_p++;
                break;//每個case 要以break;結尾
            case 3://
                pants_c.SetActive(false);
                pants_d.SetActive(true);
                index_p++;
                break;//每個case 要以break;結尾
            case 4://
                pants_d.SetActive(false);
                pants_e.SetActive(true);
                index_p++;
                break;//每個case 要以break;結尾
            case 5://
                pants_e.SetActive(false);
                pants_f.SetActive(true);
                index_p++;
                break;//每個case 要以break;結尾
            case 6://
                pants_f.SetActive(false);
                pants_g.SetActive(true);
                index_p++;
                break;//每個case 要以break;結尾
            default://以上都不成立執行預設值
                pants_g.SetActive(false);
                pants.SetActive(true);
                index_p = 0;
                break;
        }
    }

    public void changeshoes()
    {
        switch (index_s)//拿什麼東西來做判斷

        {
            case 0://選項為0

                shoes_a.SetActive(true);
                index_s++;
                break;//每個case 要以break;結尾
            case 1://選項為
                shoes_a.SetActive(false);
                shoes_b.SetActive(true);
                index_s++;
                break;//每個case 要以break;結尾
            case 2://
                shoes_b.SetActive(false);
                shoes_c.SetActive(true);
                index_s++;
                break;//每個case 要以break;結尾
            default://以上都不成立執行預設值
                shoes_c.SetActive(false);
                index_s = 0;
                break;
        }
    }
}
