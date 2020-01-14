using Game.AI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Enemies.Beast.AI
{
    [CreateAssetMenu(menuName ="AI/Beast/Actions/FollowAction")]
    public class FollowAction : Action
    {
        public override void Act(FSMControllerBase controller)
        {
            var col = controller as BeastFSM;
            col.Movement.Movement(col.TargetGameObject.transform);
        }

    }

}