using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PersonCamera : Photon.PunBehaviour
{
    public static PersonCamera Camera;
   
    public Transform Target;

    public float MaximumDistance;
    public float MinimumDistance;

    public float ScrollModifier;
    public float TurnModifier;    //按下滑鼠左鍵移動鏡頭的速度
    public float RotateSpeed;     //鏡頭跟著角色移動的速度

    Transform m_CameraTransform;

    Vector3 m_LookAtPoint;
    Vector3 m_LocalForwardVector;
    float m_Distance;

    void Awake()
    {
        if (Camera != null)
        {
            DestroyImmediate(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        Camera = this;

        PhotonNetwork.automaticallySyncScene = true;
        SceneManager.sceneLoaded += this.OnLoadCallback; //回傳新版的載入場景,舊版刪除這行

    }


    void Start()
    {
        m_CameraTransform = transform.GetChild(0);
        m_LocalForwardVector = m_CameraTransform.forward;

        m_Distance = -m_CameraTransform.localPosition.z / m_CameraTransform.forward.z;
        m_Distance = Mathf.Clamp(m_Distance, MinimumDistance, MaximumDistance);
        m_LookAtPoint = m_CameraTransform.localPosition + m_LocalForwardVector * m_Distance;
    }

    void LateUpdate()
    {
        UpdateDistance();
        UpdateZoom();
        UpdatePosition();
        UpdateRotation();
        UpdateFollowRotate();
        //UpdateHitSomething(); //相機閃避障礙物
    }
    void UpdateFollowRotate()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetAxisRaw("Horizontal") < -0.1f)
        { //按下A鍵時，鏡頭會隨著角色左轉的速度水平移動
          //RotateSpeed 等於RPGMovement裡的RotateSpeed，鏡頭轉向的速度才會跟上角色移動的速度

            transform.Rotate(0, -RotateSpeed * Time.deltaTime, 0);
        }

        if (Input.GetKey(KeyCode.D) || Input.GetAxisRaw("Horizontal") > 0.1f)
        { //按下D鍵時，鏡頭會隨著角色右轉的速度水平移動

            transform.Rotate(0, RotateSpeed * Time.deltaTime, 0);
        }
    }
    void UpdateDistance()
    {
        m_Distance = Mathf.Clamp(m_Distance - Input.GetAxis("Mouse ScrollWheel") * ScrollModifier, MinimumDistance, MaximumDistance);
    }

    void UpdateZoom() //縮放
    {
        m_CameraTransform.localPosition = m_LookAtPoint - m_LocalForwardVector * m_Distance;
    }

    void UpdatePosition()
    {
        if (Target == null)
        {
            return;
        }

        transform.position = Target.transform.position;  //攝影機跟著人物移動
    }

    void UpdateRotation()//旋轉
    {
        if (Input.GetMouseButton(0) == true || Input.GetMouseButton(1) == true || Input.GetButton("Fire1") || Input.GetButton("Fire2"))
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * TurnModifier, 0); //持續按下右鍵 攝影機水平橫移
        }

        if ((Input.GetMouseButton(1) || Input.GetButton("Fire2")) && Target != null) //按下右鍵
        {
            Target.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);   //按下右鍵人物 朝向正面
             
        }
    }

    void UpdateHitSomething()//相機碰撞
    {
        RaycastHit hit;
        if (Physics.Linecast(Target.position + Vector3.up, m_CameraTransform.position,out hit))
        {
            string name = hit.collider.gameObject.tag;
            Debug.Log(name);

            if(name !="Player")//若射線碰到的東西不是相機或是玩家 就會閃避
            {
                float currentDistance = Vector3.Distance(hit.point, Target.position);
                                  
                    if (currentDistance < MaximumDistance)
                    {
                    m_CameraTransform.position = hit.point;
                    }

            }
        }
    }

    void OnLoadCallback(Scene scene, LoadSceneMode sceneMode) //新版的載入場景
    {
        
    }

    /*
    //舊版的寫法     
         void OnLevelWasLoaded(int levelNumber)
    {
        
    }

    */

}
