using Game.AI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Enemies.Beast.AI
{
    [CreateAssetMenu(menuName ="AI/Beast/Actions/WalkAction")]
    public class WalkAction : Action
    {
        public float SqrDistance;

        public override void Act(FSMControllerBase controller)
        {
            var col= controller as BeastFSM;
            col.Movement.Movement(col.PartolPoints[col.PartolIndex]);

            if((col.PartolPoints[col.PartolIndex].position-col.transform.position).sqrMagnitude<=SqrDistance)
            {
                col.PartolIndex = (col.PartolIndex + 1) % col.PartolPoints.Length;
            }
        }
    }

}