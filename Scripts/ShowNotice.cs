using UnityEngine;
using System.Collections;

public class ShowNotice : MonoBehaviour {


    public float TurnModifier;//水平位移
    public Transform movemenucamera; //設定人物選單的攝影機移動

    // Use this for initialization
    void Start ()
    {
        movemenucamera = transform.GetChild(0); //取得攝影機在子物件裡面
        
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        MoveCamera();

    }

    void OnMouseDown()
    {
        switch (gameObject.name)//用選到的名稱來判斷
        {
            case "Person"://選項為機器人

                Debug.Log("你選到機器人");
                break;//每個case 要以break;結尾

            case "Worker"://選項為工人
                Debug.Log("你選到工人");
                break;//每個case 要以break;結尾
           
            default://以上都不成立執行預設值
                Debug.Log("你還沒選到角色");
                break;
        }

    }

    public void MoveCamera()
    {

        if (Input.GetMouseButton(0) == true || Input.GetMouseButton(1) == true )
        {
            //有執行
            transform.Rotate(0, Input.GetAxis("Mouse X") * TurnModifier, 0); //持續按下右鍵 攝影機旋轉
        }
    }

}
