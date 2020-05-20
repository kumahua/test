using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(CharacterController))]
public class PersonMovement : Photon.MonoBehaviour
{
    

    public string Playeraccount = LoginScript.Account; //玩家帳號

    public float ForwardSpeed;            //前進速度
    public float BackwardSpeed;           //後退速度
    public float StrafeSpeed;             //轟炸速度(參考)
    public float RotateSpeed;             //旋轉速度

    public Transform Role;
    public Transform LocalRole;
    public static bool[] MissionPosition = new bool[30];

    public bool reset = false;
    private GUIStyle guiStyle = new GUIStyle();

    CharacterController m_CharacterController; //初始抓值設定
    Vector3 m_LastPosition;
    Animator m_Animator;
    PhotonView m_PhotonView;
    PhotonTransformView m_TransformView;
    
    float m_AnimatorSpeed;
    Vector3 m_CurrentMovement;
    Vector3 m_CurrentPosition;
    float m_CurrentTurnSpeed;

    // Use this for initialization
    void Start()  //初始設定 去設定角色的值
    {
        m_CharacterController = GetComponent<CharacterController>(); //抓角色控制到程式碼裡面
        m_Animator = GetComponent<Animator>();
        m_PhotonView = GetComponent<PhotonView>();
        m_TransformView = GetComponent<PhotonTransformView>();

        Role = gameObject.transform.Find("Role");
        LocalRole = gameObject.transform.Find("FullmapRole");
        if (photonView != null && !photonView.isMine)
        {
            Role.gameObject.SetActive(false);//關閉紅色
            LocalRole.gameObject.SetActive(true); //開啟藍色
            //return;
        }
        else
        {
            Role.gameObject.SetActive(true);//開啟紅色
            LocalRole.gameObject.SetActive(false); //關閉藍色
        }
        
        for (int i = 0; i < 30; i++)
        {
            MissionPosition[i] = false;
        }

    }

    void OnGUI()
    {
        if (reset)
        {
            resetGUI();           //啟動Login函式
        }
    }

    // Update is called once per frame
    void Update ()
    {
        if (m_PhotonView.isMine == true && PhotonNetwork.connected == true) //連線成功並且是使用自己的角色
        {            
            ResetSpeedValues();

            UpdateRotateMovement();

            UpdateForwardMovement();
            UpdateBackwardMovement();
            UpdateStrafeMovement();

            UpdatePickupAction();
            UpdateMagicAction();

            MoveCharacterController();
            ApplyGravityToCharacterController();

            ApplySynchronizedValues();
            UpdatePlayerPosition();
        }
        
        UpdateAnimation();
    }

    void UpdateAnimation()
    {
        Vector3 movementVector = transform.position - m_LastPosition;

        float speed = Vector3.Dot(movementVector.normalized, transform.forward);
        float direction = Vector3.Dot(movementVector.normalized, transform.right);

        if (Mathf.Abs(speed) < 0.2f)
        {
            speed = 0f;
        }

        if (speed > 0.6f)
        {
            speed = 1f;
            direction = 0f;
        }

        if (speed >= 0f)
        {
            if (Mathf.Abs(direction) > 0.7f)
            {
                speed = 1f;
            }
        }

        m_AnimatorSpeed = Mathf.MoveTowards(m_AnimatorSpeed, speed, Time.deltaTime * 5f);

        m_Animator.SetFloat("Speed", m_AnimatorSpeed);
        m_Animator.SetFloat("Direction", direction);
       

        m_LastPosition = transform.position;
    }
    void ResetSpeedValues()
    {
        m_CurrentMovement = Vector3.zero;
        m_CurrentTurnSpeed = 0;
    }

    void ApplySynchronizedValues()
    {
        m_TransformView.SetSynchronizedValues(m_CurrentMovement, m_CurrentTurnSpeed);
    }

    void ApplyGravityToCharacterController()
    {
        m_CharacterController.Move(transform.up * Time.deltaTime * -9.81f);
    }

    void MoveCharacterController()
    {
        m_CharacterController.Move(m_CurrentMovement * Time.deltaTime);
    }

    void UpdateForwardMovement() //前進
    {
        bool ForwardMove = Input.GetKey(KeyCode.W);     //設定按下按鈕傳值
        m_Animator.SetBool("ForwardMove", ForwardMove); //設定動畫
       
        if ((ForwardMove || Input.GetAxisRaw("Vertical") > 0.1f) && !LakeControl.IsTalking && HPscripts.HP >10)
        {
            m_Animator.SetBool("ForwardMove", true);
            m_CurrentMovement = transform.forward * (ForwardSpeed + int.Parse(BagViewScript.PlayerSpeed.text)) ; //前進速度 分配點數
            m_CurrentPosition = transform.position;
            if (m_CurrentPosition.y < -14)
            {
                transform.position = new Vector3(0, -11.5f, 0);
                HPscripts.HP -= 20;
                reset = true;
            }
            //Debug.Log("當前位置:"+m_CurrentPosition);
        }
        else
        {
            m_Animator.SetBool("ForwardMove", false);
        }
    }

    void UpdateBackwardMovement() //後退
    {
        bool BackwardMove = Input.GetKey(KeyCode.S);
        m_Animator.SetBool("BackwardMove", BackwardMove);

        if ((BackwardMove || Input.GetAxisRaw("Vertical") < -0.1f) && !LakeControl.IsTalking && HPscripts.HP > 10)
        {
            m_Animator.SetBool("BackwardMove", true);
            m_CurrentMovement = -transform.forward * (BackwardSpeed + int.Parse(BagViewScript.PlayerSpeed.text)); //分配點數
            m_CurrentPosition = transform.position;
            if (m_CurrentPosition.y < -14)
            {
                transform.position = new Vector3(0, -11.5f, 0);
                HPscripts.HP -= 20;
                reset = true;
            }
            //Debug.Log("當前位置:" + m_CurrentPosition);
        }
        else
        {
            m_Animator.SetBool("BackwardMove", false);
        }
    }

    void UpdateStrafeMovement() //向左右橫移
    {
        bool StrafeMovementLeft = Input.GetKey(KeyCode.Q);
        bool StrafeMovementRight = Input.GetKey(KeyCode.E);
        m_Animator.SetBool("StrafeMovementLeft", StrafeMovementLeft);
        m_Animator.SetBool("StrafeMovementRight", StrafeMovementRight);

        if (StrafeMovementLeft && !LakeControl.IsTalking)
        {
            m_Animator.SetBool("StrafeMovementLeft", true);
            m_CurrentMovement = -transform.right * StrafeSpeed;
            m_CurrentPosition = transform.position;
            if (m_CurrentPosition.y < -14)
            {
                transform.position = new Vector3(0, -11.5f, 0);
                reset = true;
                HPscripts.HP -= 20;
            }
            //Debug.Log("當前位置:" + m_CurrentPosition);
        }

        if (StrafeMovementRight && !LakeControl.IsTalking && HPscripts.HP > 10)
        {
            m_Animator.SetBool("StrafeMovementRight", true);
            m_CurrentMovement = transform.right * StrafeSpeed;
            m_CurrentPosition = transform.position;
            if (m_CurrentPosition.y < -14)
            {
                transform.position = new Vector3(0, -11.5f, 0);
                reset = true;
                HPscripts.HP -= 20;
            }
            //Debug.Log("當前位置:" + m_CurrentPosition);
        }
    }

    void UpdateRotateMovement()//左右轉向
    {

        if (Input.GetKey(KeyCode.A) || Input.GetAxisRaw("Horizontal") < -0.1f)
        {
            m_CurrentTurnSpeed = -RotateSpeed;
            transform.Rotate(0.0f, -RotateSpeed * Time.deltaTime, 0.0f);
        }

        if (Input.GetKey(KeyCode.D) || Input.GetAxisRaw("Horizontal") > 0.1f)
        {
            m_CurrentTurnSpeed = RotateSpeed;
            transform.Rotate(0.0f, RotateSpeed * Time.deltaTime, 0.0f);
        }
    }
    void UpdatePickupAction() //撿起來動畫
    {
            bool Pickup = Input.GetKey(KeyCode.Space);//按住
            m_Animator.SetBool("Pickup", Pickup);        
            
        if (Pickup)
        {
           // m_Animator.SetBool("Pickup", true);
           
        }
        else
        {
            m_Animator.SetBool("Pickup", false);    
        }
        
    }
    void UpdateMagicAction() //魔法攻擊動畫
    {
        bool Magic01 = Input.GetKey(KeyCode.X);//按住
        m_Animator.SetBool("Magic01", Magic01);
        if(Magic01 && !LakeControl.IsTalking)
        {

        }
        else
        {
            m_Animator.SetBool("Magic01", false);
        }
    }

    void resetGUI()
    {
        guiStyle.fontSize = 18;
        guiStyle.normal.textColor = Color.white;
        GUI.Box(new Rect(Screen.width / 2 - (Screen.width / 6), Screen.height / 2 - (Screen.height / 6),  (Screen.width / 3), (Screen.height / 3)),""); //視窗大小依照顯示器不同調整;  x , y , 寬 , 高

        if (GUI.Button(new Rect((Screen.width / 2)-55, (Screen.height / 2 - (Screen.height / 6) ) + (Screen.height / 3)*.8f, 110, 25), "我知道了"))       //按鈕Login被按下之後
        {
            reset = false;                       
        }

        GUI.Label(new Rect(Screen.width / 2 - (Screen.width / 6) + (Screen.width / 3)*.1f, Screen.height / 2-36 , 220, 24), "湖內不可以進入!受到20點傷害", guiStyle);
        GUI.Label(new Rect(Screen.width / 2 - (Screen.width / 6) + (Screen.width / 3) * .1f, Screen.height / 2 - 12, 220, 24), "被湖中女神送回起始點", guiStyle);

    }
    void UpdatePlayerPosition()
    {    
        //判斷傳送到哪個NPC
        #region 
        if (MissionPosition[1] == true)
        {
            //程式碼
            transform.position = new Vector3(17, -10, -75);     //人物座標
            transform.rotation = Quaternion.Euler(0, -82, 0);   //人物旋轉
            PersonCamera.Camera.transform.rotation = Quaternion.Euler(0, -82, 0);  //鏡頭跟著轉
            MissionPosition[1] = false;
        }
        if (MissionPosition[2] == true)
        {
            //程式碼
            transform.position = new Vector3(-77, -9, -126);     //人物座標
            transform.rotation = Quaternion.Euler(0, -32, 0);   //人物旋轉
            PersonCamera.Camera.transform.rotation = Quaternion.Euler(0, -32, 0);  //鏡頭跟著轉
            MissionPosition[2] = false;
        }
        if (MissionPosition[3] == true)
        {
            //程式碼
            transform.position = new Vector3(-17, -10, -88);     //人物座標
            transform.rotation = Quaternion.Euler(0, -37, 0);   //人物旋轉
            PersonCamera.Camera.transform.rotation = Quaternion.Euler(0, -37, 0);  //鏡頭跟著轉
            MissionPosition[3] = false;
        }
        if (MissionPosition[4] == true)
        {
            //程式碼
            transform.position = new Vector3(-47, -10, -106);     //人物座標
            transform.rotation = Quaternion.Euler(0, -77, 0);   //人物旋轉
            PersonCamera.Camera.transform.rotation = Quaternion.Euler(0, -77, 0);  //鏡頭跟著轉
            MissionPosition[4] = false;
        }
        if (MissionPosition[5] == true)
        {
            //程式碼
            transform.position = new Vector3(94, -10, -257);     //人物座標
            transform.rotation = Quaternion.Euler(0, -30, 0);   //人物旋轉
            PersonCamera.Camera.transform.rotation = Quaternion.Euler(0, -30, 0);  //鏡頭跟著轉
            MissionPosition[5] = false;
        }
        if (MissionPosition[6] == true)
        {
            //程式碼
            transform.position = new Vector3(157, -10, -189);     //人物座標
            transform.rotation = Quaternion.Euler(0, 119, 0);   //人物旋轉
            PersonCamera.Camera.transform.rotation = Quaternion.Euler(0, 119, 0);  //鏡頭跟著轉
            MissionPosition[6] = false;
        }
        if (MissionPosition[7] == true)
        {
            //程式碼
            transform.position = new Vector3(72, -11, -78);     //人物座標
            transform.rotation = Quaternion.Euler(0, -20, 0);   //人物旋轉
            PersonCamera.Camera.transform.rotation = Quaternion.Euler(0, -20, 0);  //鏡頭跟著轉
            MissionPosition[7] = false;
        }
        if (MissionPosition[8] == true)
        {
            //程式碼
            transform.position = new Vector3(-113, -10, -255);     //人物座標
            transform.rotation = Quaternion.Euler(0, -183, 0);   //人物旋轉
            PersonCamera.Camera.transform.rotation = Quaternion.Euler(0, -183, 0);  //鏡頭跟著轉
            MissionPosition[8] = false;
        }
        if (MissionPosition[9] == true)
        {
            //程式碼
            transform.position = new Vector3(75.5f, -10, -283.7f);     //人物座標
            transform.rotation = Quaternion.Euler(0, 170.6f, 0);   //人物旋轉
            PersonCamera.Camera.transform.rotation = Quaternion.Euler(0, 170.6f, 0);  //鏡頭跟著轉
            MissionPosition[9] = false;
        }
        if (MissionPosition[10] == true)
        {
            //程式碼
            transform.position = new Vector3(154, -10, -120);     //人物座標
            transform.rotation = Quaternion.Euler(0, 92, 0);   //人物旋轉
            PersonCamera.Camera.transform.rotation = Quaternion.Euler(0, 92, 0);  //鏡頭跟著轉
            MissionPosition[10] = false;
        }
        if (MissionPosition[11] == true)
        {
            //程式碼
            transform.position = new Vector3(66, -10, -145.7f);     //人物座標
            transform.rotation = Quaternion.Euler(0, 261, 0);   //人物旋轉
            PersonCamera.Camera.transform.rotation = Quaternion.Euler(0, 261, 0);  //鏡頭跟著轉
            MissionPosition[11] = false;
        }
        if (MissionPosition[12] == true)
        {
            //程式碼
            transform.position = new Vector3(-46.1f, -10, -277);     //人物座標
            transform.rotation = Quaternion.Euler(0, 190.2f, 0);   //人物旋轉
            PersonCamera.Camera.transform.rotation = Quaternion.Euler(0, 190.2f, 0);  //鏡頭跟著轉
            MissionPosition[12] = false;
        }
        if (MissionPosition[13] == true)
        {
            //程式碼
            transform.position = new Vector3(101.1f, -10, -146.2f);     //人物座標
            transform.rotation = Quaternion.Euler(0, 161, 0);   //人物旋轉
            PersonCamera.Camera.transform.rotation = Quaternion.Euler(0, 161, 0);  //鏡頭跟著轉
            MissionPosition[13] = false;
        }
        if (MissionPosition[14] == true)
        {
            //程式碼
            transform.position = new Vector3(137.4f, -5, -169.4f);     //人物座標
            transform.rotation = Quaternion.Euler(0, -68, 0);   //人物旋轉
            PersonCamera.Camera.transform.rotation = Quaternion.Euler(0, -68, 0);  //鏡頭跟著轉
            MissionPosition[14] = false;
        }
        if(MissionPosition[15] == true)
        {
            //程式碼
            transform.position = new Vector3(21.6f, -11.5f, -25.2f);     //人物座標
            transform.rotation = Quaternion.Euler(0, 191.674f, 0);   //人物旋轉
            PersonCamera.Camera.transform.rotation = Quaternion.Euler(0, 191.674f, 0);  //鏡頭跟著轉
            MissionPosition[15] = false;
        }
        if (MissionPosition[16] == true)
        {
            //程式碼
            transform.position = new Vector3(10.7f, -10, -66.8f);     //人物座標
            transform.rotation = Quaternion.Euler(0, -29.6f, 0);   //人物旋轉
            PersonCamera.Camera.transform.rotation = Quaternion.Euler(0, -29.6f, 0);  //鏡頭跟著轉
            MissionPosition[16] = false;
        }
        if (MissionPosition[17] == true)
        {
            //程式碼
            transform.position = new Vector3(-71, -10, -135);     //人物座標
            transform.rotation = Quaternion.Euler(0, 247.8f, 0);   //人物旋轉
            PersonCamera.Camera.transform.rotation = Quaternion.Euler(0, 247.8f, 0);  //鏡頭跟著轉
            MissionPosition[17] = false;
        }
        if (MissionPosition[18] == true)
        {
            //程式碼
            transform.position = new Vector3(93, -10, -87);     //人物座標
            transform.rotation = Quaternion.Euler(0, -196, 0);   //人物旋轉
            PersonCamera.Camera.transform.rotation = Quaternion.Euler(0, -196, 0);  //鏡頭跟著轉
            MissionPosition[18] = false;
        }
        if (MissionPosition[19] == true)
        {
            //程式碼
            transform.position = new Vector3(-36.9f, -10, -114.2f);     //人物座標
            transform.rotation = Quaternion.Euler(0, 102, 0);   //人物旋轉
            PersonCamera.Camera.transform.rotation = Quaternion.Euler(0, 102, 0);  //鏡頭跟著轉
            MissionPosition[19] = false;
        }
        if (MissionPosition[20] == true)
        {
            //程式碼
            transform.position = new Vector3(127.1f, -10, -249.2f);     //人物座標
            transform.rotation = Quaternion.Euler(0, -155, 0);   //人物旋轉
            PersonCamera.Camera.transform.rotation = Quaternion.Euler(0, -155, 0);  //鏡頭跟著轉
            MissionPosition[20] = false;
        }
        if (MissionPosition[21] == true)
        {
            //程式碼
            transform.position = new Vector3(161, -10, -175);     //人物座標
            transform.rotation = Quaternion.Euler(0, -80, 0);   //人物旋轉
            PersonCamera.Camera.transform.rotation = Quaternion.Euler(0, -80, 0);  //鏡頭跟著轉
            MissionPosition[21] = false;
        }
        if (MissionPosition[22] == true)
        {
            //程式碼
            transform.position = new Vector3(-105.2f, -10, -225.5f);     //人物座標
            transform.rotation = Quaternion.Euler(0, 108.2f, 0);   //人物旋轉
            PersonCamera.Camera.transform.rotation = Quaternion.Euler(0, 108.2f, 0);  //鏡頭跟著轉
            MissionPosition[22] = false;
        }
        if (MissionPosition[23] == true)
        {
            //程式碼
            transform.position = new Vector3(-108.1f, -10, -249.2f);     //人物座標
            transform.rotation = Quaternion.Euler(0, 168.3f, 0);   //人物旋轉
            PersonCamera.Camera.transform.rotation = Quaternion.Euler(0, 168.3f, 0);  //鏡頭跟著轉
            MissionPosition[23] = false;
        }
        if (MissionPosition[24] == true)
        {
            //程式碼
            transform.position = new Vector3(66.2f, -10, -270.6f);     //人物座標
            transform.rotation = Quaternion.Euler(0, 62.6f, 0);   //人物旋轉
            PersonCamera.Camera.transform.rotation = Quaternion.Euler(0, 62.6f, 0);  //鏡頭跟著轉
            MissionPosition[24] = false;
        }
        if (MissionPosition[25] == true)
        {
            //程式碼
            transform.position = new Vector3(147, -10, -111);     //人物座標
            transform.rotation = Quaternion.Euler(0, -0, 0);   //人物旋轉
            PersonCamera.Camera.transform.rotation = Quaternion.Euler(0, -0, 0);  //鏡頭跟著轉
            MissionPosition[25] = false;
        }
        if (MissionPosition[26] == true)
        {
            //程式碼
            transform.position = new Vector3(56.9f, -11, -197.8f);     //人物座標
            transform.rotation = Quaternion.Euler(0, 160.2f, 0);   //人物旋轉
            PersonCamera.Camera.transform.rotation = Quaternion.Euler(0, 160.2f, 0);  //鏡頭跟著轉
            MissionPosition[26] = false;
        }
        if (MissionPosition[27] == true)
        {
            //程式碼
            transform.position = new Vector3(-51.4f, -10, -273.4f);     //人物座標
            transform.rotation = Quaternion.Euler(0, -1.1f, 0);   //人物旋轉
            PersonCamera.Camera.transform.rotation = Quaternion.Euler(0, -1.1f, 0);  //鏡頭跟著轉
            MissionPosition[27] = false;
        }
        if (MissionPosition[28] == true)
        {
            //程式碼
            transform.position = new Vector3(106.3f, -10, -131);     //人物座標
            transform.rotation = Quaternion.Euler(0, 1.3f, 0);   //人物旋轉
            PersonCamera.Camera.transform.rotation = Quaternion.Euler(0, 1.3f, 0);  //鏡頭跟著轉
            MissionPosition[28] = false;
        }
        if (MissionPosition[29] == true)
        {
            //程式碼
            transform.position = new Vector3(132.2f, -4, -178);     //人物座標
            transform.rotation = Quaternion.Euler(0, 5.5f, 0);   //人物旋轉
            PersonCamera.Camera.transform.rotation = Quaternion.Euler(0, 5.5f, 0);  //鏡頭跟著轉
            MissionPosition[29] = false;
        }
#endregion
    }



}
