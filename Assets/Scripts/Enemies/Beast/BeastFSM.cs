using Game.AI;
using Game.AI.States;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Enemies.Beast
{

    public class IdleState : IState<BeastFSM>
    {
        public void OnEnter(BeastFSM controller)
        {
        }

        public void OnExit(BeastFSM controller)
        {
        }

        public void OnUpdate(BeastFSM controller)
        {
        }
    }

    public class FollowState:State<BeastFSM>
    {
        public FollowState(string name) : base(name) { }

        public override void OnEnter(BeastFSM controller)
        {
            controller.Log(StateName + " Enter");
        }

        public override void OnUpdate(BeastFSM controller)
        {
            base.OnUpdate(controller);
            controller.Movement.Movement(controller.TargetGameObject.transform);
            //满足某一条件后状态转换
            if (controller.IsLostTarget())
            {
                Debug.Log("Into");
                controller.FSM.ChangeState("Partol");
            }
        }

        public override void OnExit(BeastFSM controller)
        {
            controller.Log(StateName + " Exit");
            controller.TargetGameObject = null;
        }
    }


    public class BeastFSM : MonoBehaviour
    {
        public float SqrLostDistance;
        public float CheckRadius=5f;
        public Transform[] PartolPoints;
        [HideInInspector]public int PartolIndex;
        [HideInInspector]public BeastMovement Movement;
        /// <summary> 目标对象，不具体指向某一GameObject，根据需求进行变化 </summary>
        public GameObject TargetGameObject;

        private FSMControllerBase<BeastFSM> _fsm;
        public FSMControllerBase<BeastFSM> FSM => _fsm;

        private void Awake()
        {

            //第一步  ：初始化状态机
            _fsm = new FSMControllerBase<BeastFSM>(this);

            //新增状态，两种方式
            //第一种：用已经实现的State<T>作为状态机创建，缺点无状态进出时候的行为，只有Update的行为
            State<BeastFSM> state = new State<BeastFSM>("PartolState");
            //Update中的行为进行注册，UpdateEvent+=fun;这种形式
            //fun是一个函数  void fun(T controller) 这种签名的函数
            state.UpdateEvent += (col) =>
            {
                Movement.Movement(col.PartolPoints[col.PartolIndex]);

                if ((col.PartolPoints[col.PartolIndex].position - col.transform.position).sqrMagnitude <= 0.25f)
                {
                    col.PartolIndex = (col.PartolIndex + 1) % col.PartolPoints.Length;
                }
            };

            //状态转换
            state.UpdateEvent += col =>
            {
                if (IsFollow())
                    _fsm.ChangeState("Follow");
            };

            var fs = new FollowState("FollowState");
            //第二种通过继承IState<T> 或者State<T> 进行状态类的构建，全部自定义，可以看FollowState<T> 的实现
            //第二步：添加状态
            _fsm.AddState("Follow", fs);
            _fsm.AddState("Partol", state);

            //第三步：添加状态机进入时的状态
            _fsm.EntryState = fs;

            Movement = GetComponent<BeastMovement>();
        }

        private void Start()
        {
            //第四部：启动状态机
            _fsm.Start();

        }

        private void Update()
        {
            //第五步：在Update中调用Update
            _fsm.Update();
            
        }

        public void Log(string str)
        {
            Debug.Log(str);
        }

        public bool IsFollow()
        {
            var collider2D = Physics2D.OverlapCircle(transform.position, CheckRadius, 1 << 8);
            if (collider2D != null && collider2D.CompareTag("Player"))
            {
                TargetGameObject = collider2D.gameObject;
                return true;
            }
            return false;
        }

        public bool IsLostTarget()
        {
            Debug.Log((TargetGameObject.transform.position - transform.position).sqrMagnitude < SqrLostDistance);
            if ((TargetGameObject.transform.position - transform.position).sqrMagnitude < SqrLostDistance)
                return false;
            return true;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(transform.position, Mathf.Sqrt(SqrLostDistance));

            Gizmos.color = Color.green;
            Gizmos.DrawSphere(transform.position, CheckRadius);
        }
    }

}