using Game.AI;
using Game.AI.Decisions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Enemies.Beast.AI
{
    [CreateAssetMenu(menuName = "AI/Beast/Decision/IsLostTargetDecision")]
    public class IsLostTargetDecision : Decision
    {
        [Tooltip("离开距离的平方")]
        public float SqrLostDistance;

        public override bool Decide(FSMControllerBase controlller)
        {
            var col = controlller as BeastFSM;
            if ((col.TargetGameObject.transform.position - controlller.transform.position).sqrMagnitude < SqrLostDistance)
                return false;
            return true;
        }
    }

}