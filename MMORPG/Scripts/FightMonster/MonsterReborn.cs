using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityEngine.UI;
using System.Collections;
using Hashtable = ExitGames.Client.Photon.Hashtable;

/// <summary>
/// Makes a scene object pickup-able. Needs a PhotonView which belongs to the scene.
/// </summary>
/// <remarks>Includes a OnPhotonSerializeView implementation that </remarks>
[RequireComponent(typeof(PhotonView))]
[RequireComponent(typeof(CharacterController))]

public class MonsterReborn : Photon.MonoBehaviour,IPunObservable
{
    public GameObject M_HPBar; // 怪物的血條(整體)	
    public static MonsterReborn instance;

    public float M_MaxHP;//最高血量
    public float M_HP = 100; //目前血量 不能用全域變數
    public Text M_HPText; //HP值顯示
    public GameObject M_HPObject;//怪物血量
    public string M_HPUIName;
    public string M_HPName;
    public string M_HPTextName;

    public Flowchart Mission_Flowchart; //擺入指定的流程圖
    public string onTriggerEnter; //指定名稱要和進入的NPC(Block)名稱一樣
 
    Vector3 m_CurrentPosition;
    public float x;
    public float y;
    public float z;
#region
    //[HideInInspector] //自動跟隨與攻擊程式碼部分
    public static Transform hero;//要跟随英雄
    CharacterController MonsterCharacterController;//怪物的角色控制器
    Animator ani;//動畫控制器

    public float followDis = 3f;//達到這個距離開始跟隨
    public float attackDis = 1.5f;//達到這個距離開始攻擊

    public float thinkTime = 3f;//思考的時間
    public float currentThinkTime = 0f;//紀錄思考的時間

    public float walkTime = 5f;//走的時間
    public float currentWalkTime = 0;//紀錄走的時間

    private bool isAttact = false;//是否攻擊
    private bool isGethit = false;
#endregion
    private void Awake()
    {
        M_HPBar = GameObject.Find(M_HPUIName);
        M_HPObject = GameObject.Find(M_HPName);
        M_HPText = GameObject.Find(M_HPTextName).GetComponent<Text>();
        MonsterCharacterController = GetComponent<CharacterController>();//抓取角色控制器
        ani = GetComponent<Animator>();//抓取動畫
    }
    
    void Start()
    {       
        instance = this;
        M_HPBar.SetActive(false);

        x = gameObject.transform.position.x;
        y = gameObject.transform.position.y;
        z = gameObject.transform.position.z;

        //MonsterCharacterController = GetComponent<CharacterController>();//抓取角色控制器
        //ani = GetComponent<Animator>();//抓取動畫
    }
    void Update()
    {
        TouchMonsterandShow();
        isPostition();
        if (walkTime != -1 && thinkTime != -1)
        {
            Think();//思考
            Attack();//攻擊
            GetHit();
        }
    }
    void TouchMonsterandShow()//顯示怪物及資訊
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit; //射線擊中資訊      
        if (Input.GetMouseButton(0) && Physics.Raycast(ray, out hit, 1))
        {
            //Debug.DrawLine(Camera.main.transform.position, hit.transform.position, Color.red, 0.1f, true); //射線出現
            //Debug.Log("碰到東西名稱" + hit.transform.name);
            if (hit.collider.tag == "Mummy1")
            {
                //M_HPBar.SetActive(true); //全部的血量會開啟
                // Debug.Log("碰到怪物1");
            }
            else
            {
                M_HPBar.SetActive(false);
            }
        }
        else if (Input.GetMouseButton(0))
        {
            //Debug.Log("沒有碰到任何東西");
            M_HPBar.SetActive(false);
        }
        if (Vector3.Distance(transform.position, hero.position) > 6f)
        {
            M_HPBar.SetActive(false);
        }
    }

    void isPostition() //重新回到位置上
    {
        m_CurrentPosition = transform.position;
        if (m_CurrentPosition.y < -12)
        {
            transform.position = new Vector3(x, y, z);                   
        }
    }

    void PlayBlock(string targetBlcokName) //設定要撥放的對話名稱
    {

        Block targetBlock = Mission_Flowchart.FindBlock(onTriggerEnter);//名稱要和進入的NPC名稱一樣
        if (targetBlock != null)
        {
            Mission_Flowchart.ExecuteBlock(targetBlock);
        }
        else
        {
            Debug.LogError("找不到在" + Mission_Flowchart.name + "裡的" + targetBlcokName + "Block"); //錯誤訊息 表示找不到相對應的對話物件
        }
    }
    ///<summary>Enables you to define a timeout when the picked up item should re-spawn at the same place it was before.</summary>
    /// <remarks>
    /// Set in Inspector per GameObject! The value in code is just the default.
    ///
    /// If you don't want an item to respawn, set SecondsBeforeRespawn == 0.
    /// If an item does not respawn, it could be consumed or carried around and dropped somewhere else.
    ///
    /// A respawning item should stick to a fixed position. It should not be observed at all (in any PhotonView).
    /// It can only be consumed and can't be dropped somewhere else (cause that would double the item).
    ///
    /// This script uses PunRespawn() as RPC and as method that gets called by Invoke() after a timeout.
    /// No matter if the item respawns timed or by Drop, that method makes sure (temporary) owner and other status-values
    /// are being re-set.
    /// </remarks>
    public float SecondsBeforeRespawn = 2;

    /// <summary>The most likely trigger to pick up an item. Set in inspector!</summary>
    /// <remarks>Edit the collider and set collision masks to avoid pickups by random objects.</remarks>
    public bool PickupOnTrigger; //是否觸發成功,有勾起來才可以

    /// <summary>If the pickup item is currently yours. Interesting in OnPickedUp(PickupItem item).</summary>
    public bool PickupIsMine;

    /// <summary>GameObject to send an event "OnPickedUp(PickupItem item)" to.</summary>
    /// <remarks>
    /// Implement OnPickedUp(PickupItem item) {} in some script on the linked game object.
    /// The item will be "this" and item.PickupIsMine will help you to find if this pickup was done by "this player".
    /// </remarks>
    public MonoBehaviour OnPickedUpCall;


    // these values are internally used. they are public for debugging only

    /// <summary>If this client sent a pickup. To avoid sending multiple pickup requests before reply is there.</summary>
    public bool SentPickup;

    /// <summary>Timestamp when to respawn the item (compared to PhotonNetwork.time). </summary>
    public double TimeOfRespawn;    // needed when we want to update new players when a PickupItem respawns

    /// <summary></summary>
    public int ViewID { get { return this.photonView.viewID; } }

    public static HashSet<MonsterReborn> DisabledMonsterReborns = new HashSet<MonsterReborn>(); //要改成相對應名稱的程式碼


    public void OnTriggerEnter(Collider other) //觸發開始 OnTriggerEnter
    {
        // we only call Pickup() if "our" character collides with this PickupItem.
        // note: if you "position" remote characters by setting their translation, triggers won't be hit.

        PhotonView otherpv = other.GetComponent<PhotonView>();
        //PhotonView monsterHPv = M_HPBar.GetComponent<PhotonView>();
        if (otherpv != null && !otherpv.isMine)
        {
            Debug.Log("沒有動作");           
            return;
        }     
        else
        {
            if (Input.GetKey(KeyCode.X) && Vector3.Distance(transform.position, hero.position) < attackDis)
            {
                //血量扣血程式碼
                M_HPBar.SetActive(true); //攻擊到怪物顯示血條
                M_HP -= 14 + 2 * (int.Parse(BagViewScript.PlayerAttack.text) + Loadcharacter.LoadLevel); //隨著人物等級提升打怪變疼痛              
                isGethit = true;
                M_HPObject.transform.localPosition = new Vector3((-200 + 200 * (M_HP / M_MaxHP)), 0.0f, 0.0f); //能量條隨著能力值改變
                M_HPText.text = M_HP + " / 100"; // 更改PowerText的內容	

                //受到攻擊扣血
                //HPscripts.HP -= 2;
                //Debug.Log("受到怪物攻擊");

                //Debug.Log("OnTriggerEnter() calls Pickup().");
                if (M_HP <= 0) //怪物死亡  && monsterHPv != null && monsterHPv.isMine
                {
                    //Debug.Log("怪物死亡,獲得經驗值");
                    EXPscripts.EXP += 5; //擊殺一隻怪物經驗值獲得5
                    PlayBlock(onTriggerEnter);  
                    this.Pickup(); //執行程式碼
                    M_HP = 100;
                }
            }
        }            
    }



    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        // read the description in SecondsBeforeRespawn

        if (stream.isWriting && SecondsBeforeRespawn <= 0)
        {
            stream.SendNext(this.gameObject.transform.position);
        }
        else
        {
            // this will directly apply the last received position for this PickupItem. No smoothing. Usually not needed though.
            Vector3 lastIncomingPos = (Vector3)stream.ReceiveNext();
            this.gameObject.transform.position = lastIncomingPos;
        }
    }

    void Think()
    {
        if (!isAttact)//如果不攻擊，就開始走

        {

            currentWalkTime += Time.deltaTime;//開始記錄走的時間
            if (currentWalkTime >= walkTime)
            {//當走的時間大於設定的時間時
                //ani.CrossFade("Idle");//怪物進入跳舞狀態
                ani.SetBool("isIdle", true);
                ani.SetBool("isRun", false);
                ani.SetBool("isAttack", false);
                ani.SetBool("isdamage", false);
                currentThinkTime += Time.deltaTime;//記錄思考的時間

                if (currentThinkTime >= thinkTime)
                {//當思考的時間大於設定的時間
                    currentWalkTime = 0f;
                    currentThinkTime = 0f;
                    float x = Random.Range(-1f, 1f);
                    float y = Random.Range(-1f, 1f);

                    transform.LookAt(transform.position + new Vector3(x, 0, y));//讓怪物朝向一個隨機的方向走動
                }

            }
            else
            {//當怪物走的時間
             //ani.CrossFade("Run");
                ani.SetBool("isRun", true);              
                ani.SetBool("isAttack", false);
                ani.SetBool("isIdle", false);
                ani.SetBool("isdamage", false);
                Vector3 direction = transform.TransformDirection(Vector3.forward);
                direction.y -= 9.8f;
                MonsterCharacterController.Move(direction * 1f * Time.deltaTime);
            }
        }
    }

    //攻擊

    void Attack()
    {
        if (hero == null)
        {//如果英雄不存在直接返回
            return;
        }
        if (Vector3.Distance(transform.position, hero.position) <= followDis)//跟隨距離
        {
            transform.LookAt(hero);

            if (Vector3.Distance(transform.position, hero.position) > attackDis)
            {
                isAttact = false;//大於攻擊距離不攻擊
                isGethit = false;
                //ani.CrossFade("Run");//開始執行走路跟隨動畫
                ani.SetBool("isRun", true);
                ani.SetBool("isAttack", false);
                ani.SetBool("isIdle", false);
                ani.SetBool("isdamage", false);
                Vector3 dierction = transform.TransformDirection(Vector3.forward);
                dierction.y -= 9.8f;
                MonsterCharacterController.Move(dierction * 1f * Time.deltaTime);
            }
            else//小於攻擊距離開始攻擊
            {
                //ani.CrossFade("Attack");
                ani.SetBool("isAttack", true);
                ani.SetBool("isRun", false);
                ani.SetBool("isIdle", false);
                ani.SetBool("isdamage", false);
                isAttact = true;
                if (isGethit)
                {
                    isAttact = false;
                }
                //HPscripts.HP -= 1 * Time.deltaTime;
            }

        }
    }

    void GetHit()
    {
        AnimatorStateInfo stateinfo = ani.GetCurrentAnimatorStateInfo(0);
        if (isGethit)
        {
            stateinfo.IsName("Base Layer damage");
            ani.SetBool("isdamage", true);
            ani.SetBool("isAttack", false);
            isGethit = false;
            
        }
    }


    public void Pickup()
    {
        if (this.SentPickup)
        {
            // skip sending more pickups until the original pickup-RPC got back to this client
            return;
        }

        this.SentPickup = true;
        this.photonView.RPC("PunPickup", PhotonTargets.AllViaServer);
    }


    /// <summary>Makes use of RPC PunRespawn to drop an item (sent through server for all).</summary>
    public void Drop()
    {
        if (this.PickupIsMine)
        {
            this.photonView.RPC("PunRespawn", PhotonTargets.AllViaServer);
        }
    }

    /// <summary>Makes use of RPC PunRespawn to drop an item (sent through server for all).</summary>
    public void Drop(Vector3 newPosition)
    {
        if (this.PickupIsMine)
        {
            this.photonView.RPC("PunRespawn", PhotonTargets.AllViaServer, newPosition);
        }
    }


    [PunRPC]
    public void PunPickup(PhotonMessageInfo msgInfo)
    {
        // when this client's RPC gets executed, this client no longer waits for a sent pickup and can try again
        if (msgInfo.sender.IsLocal) this.SentPickup = false;


        // In this solution, picked up items are disabled. They can't be picked up again this way, etc.
        // You could check "active" first, if you're not interested in failed pickup-attempts.
        if (!this.gameObject.GetActive())
        {
            // optional logging:
            Debug.Log("Ignored PU RPC, cause item is inactive. " + this.gameObject + " SecondsBeforeRespawn: " + SecondsBeforeRespawn + " TimeOfRespawn: " + this.TimeOfRespawn + " respawn in future: " + (TimeOfRespawn > PhotonNetwork.time));
            return;     // makes this RPC being ignored
        }


        // if the RPC isn't ignored by now, this is a successful pickup. this might be "my" pickup and we should do a callback
        this.PickupIsMine = msgInfo.sender.IsLocal;

        // call the method OnPickedUp(PickupItem item) if a GameObject was defined as callback target
        if (this.OnPickedUpCall != null)
        {
            // you could also skip callbacks for items that are not picked up by this client by using: if (this.PickupIsMine)
            this.OnPickedUpCall.SendMessage("OnPickedUp", this);
        }


        // setup a respawn (or none, if the item has to be dropped)
        if (SecondsBeforeRespawn <= 0)
        {
            this.PickedUp(0.0f);    // item doesn't auto-respawn. must be dropped
        }
        else
        {
            // how long it is until this item respanws, depends on the pickup time and the respawn time
            double timeSinceRpcCall = (PhotonNetwork.time - msgInfo.timestamp);
            double timeUntilRespawn = SecondsBeforeRespawn - timeSinceRpcCall;

            //Debug.Log("msg timestamp: " + msgInfo.timestamp + " time until respawn: " + timeUntilRespawn);

            if (timeUntilRespawn > 0)
            {
                this.PickedUp((float)timeUntilRespawn);
            }
        }
    }

    internal void PickedUp(float timeUntilRespawn)
    {
        // this script simply disables the GO for a while until it respawns.
        this.gameObject.SetActive(false); //消失
        M_HPBar.SetActive(false); //消失
        MonsterReborn.DisabledMonsterReborns.Add(this);//改成相對應的程式碼名稱
        this.TimeOfRespawn = 0;

        if (timeUntilRespawn > 0)
        {
            this.TimeOfRespawn = PhotonNetwork.time + timeUntilRespawn;
            Invoke("PunRespawn", timeUntilRespawn);
        }
    }


    [PunRPC]
    internal void PunRespawn(Vector3 pos)
    {
        Debug.Log("PunRespawn with Position.");
        this.PunRespawn();
        this.gameObject.transform.position = pos;
    }

    [PunRPC]
    internal void PunRespawn()
    {
#if DEBUG
        // debugging: in some cases, the respawn is "late". it's unclear why! just be aware of this.
        double timeDiffToRespawnTime = PhotonNetwork.time - this.TimeOfRespawn;
        if (timeDiffToRespawnTime > 0.1f) Debug.LogWarning("Spawn time is wrong by: " + timeDiffToRespawnTime + " (this is not an error. you just need to be aware of this.)");
#endif


        // if this is called from another thread, we might want to do this in OnEnable() instead of here (depends on Invoke's implementation)
        MonsterReborn.DisabledMonsterReborns.Remove(this); //改成相對應的程式碼名稱
        this.TimeOfRespawn = 0;
        this.PickupIsMine = false;

        if (this.gameObject != null)
        {
            this.gameObject.SetActive(true);
        }
    }

    

}
