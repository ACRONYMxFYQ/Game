using LS;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInput),typeof(Rigidbody2D))]
public class BasicMovement : MonoBehaviour
{
    private PlayerInput _input;
    public float PlayerSpeed;
    public bool isAttack;

    public int hitcount = 0;

    private GameObject monster;
    private Animator _anim;
    private SpriteRenderer _spriteRenderer;

    #region MonoBehvaiour Callback
    private void Awake()
    {
        _input = GetComponent<PlayerInput>();
        _anim = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();        
    }

    private void Update()
    {
        Movement();
        if (_input.IsAttack)
            attack();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //取基本数据

        //PlayerSituation(x, y);//角色状态 如： 攻击 跑动 静止
        //float x = Input.GetAxisRaw("Horizontal");
        //float y = Input.GetAxisRaw("Vertical");

        //monster = GameObject.FindGameObjectWithTag("Monster");

        //PlayerMoving(x, y, monster);//角色运动 + 朝向 
        //if (Input.GetKeyDown(KeyCode.X))
        //{
        //    attack();
        //}

    }

    #endregion

    #region Private Methods
    private void Movement()
    {
        //移动
        transform.Translate(Vector3.right * _input.HorizontalValue * PlayerSpeed * Time.deltaTime, Space.World);
        transform.Translate(Vector3.up * _input.VerticalValue * PlayerSpeed * Time.deltaTime, Space.World);


        //Sprite的方向
        //_spriteRenderer.flipX = _input.HorizontalValue < 0 ? true : false;
        if (_input.HorizontalValue != 0)//方向
            _spriteRenderer.transform.localScale = new Vector3(_input.HorizontalValue, 1, 1);

        //动画
        if (_input.VerticalValue != 0 || _input.HorizontalValue != 0)
            _anim.SetBool("Moving", true);
        else
            _anim.SetBool("Moving", false);

    }
    #endregion

    public void PlayerMoving(float x, float y, GameObject monster)//人物移动 + 朝向 函数
    {

        transform.Translate(Vector3.right * x * PlayerSpeed * Time.deltaTime, Space.World);
        transform.Translate(Vector3.up * y * PlayerSpeed * Time.deltaTime, Space.World);//取x y 坐标

        if (x != 0)//方向
            transform.localScale = new Vector3(x, 1, 1);


        if (x != 0 || y != 0)//动画
            _anim.SetBool("Moving", true);
        else
            _anim.SetBool("Moving", false);


    }

    public void attack()
    {
        _anim.SetTrigger("Attack");
    }

}