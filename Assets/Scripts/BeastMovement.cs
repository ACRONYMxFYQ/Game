using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeastMovement : MonoBehaviour
{
    public float BeastSpeed;//怪物速度
    public Animator animator;//运动器
    public GameObject player;//玩家

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update

    // Update is called once per frame
    void LateUpdate()
    {
        //animator = GetComponent<Animator>();
        
        //if ((transform.position - player.transform.position).sqrMagnitude >= 3 && !player.GetComponent<BasicMovement>().isAttack)// 离玩家较远 或者 未被攻击
        //{
        //    animator.SetBool("Running", true);//移动信号
        //    transform.position = Vector3.MoveTowards(transform.position, player.transform.position, BeastSpeed * Time.deltaTime);
        //}
        //else if( ((transform.position - player.transform.position).sqrMagnitude <= 3 ) && (player.GetComponent<BasicMovement>().isAttack))//在攻击范围内 且被攻击
        //{
        //    animator.SetTrigger("Hitted");
        //}
        //else { //进入范围 

        //    animator.SetBool("Running", false);
        //    Random random = new Random();
        //    int n = Random.Range(0, 9);
        //    if ((n % 9) == 0)
        //        animator.SetTrigger("Attacking");
        //}

        //if (transform.position.x > player.transform.position.x)
        //{//物体在人物左侧 转身
        //    transform.localScale = new Vector3(-1, 1, 1);
        //}
        //else
        //    transform.localScale = new Vector3(1, 1, 1);
     }

    public void Movement(Transform target)
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, BeastSpeed * Time.deltaTime);
        animator.SetBool("Running", true);
    }

    public void StopMove()
    {
        animator.SetBool("Running", false);
    }

}
