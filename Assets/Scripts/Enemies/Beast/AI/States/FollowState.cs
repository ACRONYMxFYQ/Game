using Game.AI;
using Game.AI.States;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Enemies.Beast.AI
{
    [CreateAssetMenu(menuName = "AI/Beast/State/FollowState")]
    public class FollowState : State
    {
        public override void OnEnter(FSMControllerBase controller)
        {
            var col = controller as BeastFSM;
            if (col.TargetGameObject == null)
                col.TranslateState(col.PreviousState);
        }

        public override void OnExit(FSMControllerBase controller)
        {
            (controller as BeastFSM).TargetGameObject = null;
        }
    }

}