using UnityEngine;
using System.Collections;

public class MoveCamera : MonoBehaviour
{

    public float moveSpeed;          //移動速度
    public GameObject mainCamera;    //放攝影機的物件

    // Use this for initialization
    void Start()
    {
        mainCamera.transform.localPosition = new Vector3(0, 3, -5);       //攝影機座標位置
        mainCamera.transform.localRotation = Quaternion.Euler(0, 0, 0); //攝影機的面對方向

    }

    // Update is called once per frame
    void Update()
    {


    }

    void FixedUpdate()
    {
        MoveObj();

        if (Input.GetKeyDown(KeyCode.A))
        {
            ChangeView01();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            ChangeView02();
        }
    }


    void MoveObj() //移動物件
    {
        float moveAmount = Time.smoothDeltaTime * moveSpeed;
        transform.Translate(0f, 0f, moveAmount);
       // transform.Rotate(0f, 0f+0.1f, 0f);
    }



    void ChangeView01() //改變攝影機角度
    {
        transform.position = new Vector3(0, 2, 10);
        // x:0, y:1, z:52
        mainCamera.transform.localPosition = new Vector3(-8, 2, 0);
        mainCamera.transform.localRotation = Quaternion.Euler(14, 90, 0);
    }

    void ChangeView02()//改變攝影機角度
    {
        transform.position = new Vector3(0, 2, 10);
        // x:0, y:1, z:52
        mainCamera.transform.localPosition = new Vector3(0, 0, 0);
        mainCamera.transform.localRotation = Quaternion.Euler(19, 180, 0);
        moveSpeed = -20f;

    }
}