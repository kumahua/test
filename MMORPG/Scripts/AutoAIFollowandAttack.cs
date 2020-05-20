using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CharacterController))]

public class AutoAIFollowandAttack : MonoBehaviour {

    //[HideInInspector]
    public static Transform hero;//要跟随英雄
    private CharacterController MonsterCharacterController;//怪物的角色控制器
    private Animator ani;//動畫控制器

    public float followDis = 3f;//達到這個距離開始跟隨
    public float attackDis = 1.5f;//達到這個距離開始攻擊

    public float thinkTime = 3f;//思考的時間
    public float currentThinkTime = 0f;//紀錄思考的時間

    public float walkTime = 5f;//走的時間
    public float currentWalkTime = 0;//紀錄走的時間

    private bool isAttact = false;//是否攻擊

    void Start()
    {
        //hero = ServerManager.Player.transform; // 抓角色位置
        MonsterCharacterController = GetComponent<CharacterController>();//抓取角色控制器
        ani = GetComponent<Animator>();//抓取動畫
    }



    void Update()
    {
        Think();//思考
        Attack();//攻擊
    }

    //思考

    void Think()
    {
        if (!isAttact)//如果不攻击，就開始走

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

    //攻击

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
                //HPscripts.HP -= 1 * Time.deltaTime;
            }

        }
    }

}

