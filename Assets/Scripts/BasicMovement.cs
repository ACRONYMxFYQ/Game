using Gane;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    private PlayerInput _input; 
    public float PlayerSpeed;
    public bool isAttack;

    public Animator animator;

    private GameObject monster;
    public int hitcount = 0;


    // Start is called before the first frame update

    private void Update()
    {
        //   Movement();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //取基本数据


        //PlayerSituation(x, y);//角色状态 如： 攻击 跑动 静止
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        monster = GameObject.FindGameObjectWithTag("Monster");

            PlayerMoving(x, y, monster);//角色运动 + 朝向 
        if (Input.GetKeyDown(KeyCode.X))
        {
            attack();
        }

    }




    public void PlayerMoving(float x, float y,GameObject monster)//人物移动 + 朝向 函数
    {


        if (monster != null)
            animator.SetBool("Ready", true);
        else
            animator.SetBool("Ready", false);

     
        transform.Translate(Vector3.right * x * PlayerSpeed * Time.deltaTime, Space.World);
        transform.Translate(Vector3.up * y * PlayerSpeed * Time.deltaTime, Space.World);//取x y 坐标

        if (x != 0)//方向
            transform.localScale = new Vector3(x, 1, 1);
        

        if (x != 0 || y != 0)//动画
            animator.SetBool("Moving", true);
        else
            animator.SetBool("Moving", false);
        

    }

    public void attack()
    {
            animator.SetTrigger("Attack");
    }

}