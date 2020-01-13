using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// 清除Trigger的信号量
    /// </summary>
    public class FSMTriggerClear : StateMachineBehaviour
    {
        public string[] ClearAtEnter;
        public string[] ClearAtExit;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            foreach (var signal in ClearAtEnter)
                animator.ResetTrigger(signal);
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            foreach (var signal in ClearAtExit)
                animator.ResetTrigger(signal);
        }
    }

}