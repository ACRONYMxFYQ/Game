using Game.AI;
using Game.AI.Decisions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Enemies.Beast.AI
{
    [CreateAssetMenu(menuName = "AI/Beast/Decision/IsFollowDecision")]
    public class IsFollowDecision : Decision
    {
        public float CheckRadius;
        public override bool Decide(FSMControllerBase controlller)
        {
            var collider2D = Physics2D.OverlapCircle(controlller.transform.position, CheckRadius, 1 << 8);
            if (collider2D != null && collider2D.CompareTag("Player"))
            {
                (controlller as BeastFSM).TargetGameObject = collider2D.gameObject;
                return true;
            }
            return false;
        }
    }

}