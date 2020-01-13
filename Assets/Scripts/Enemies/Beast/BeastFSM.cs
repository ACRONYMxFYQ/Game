using Game.AI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Enemies.Beast
{
    public class BeastFSM : FSMControllerBase
    {
        public Transform[] PartolPoints;
        [HideInInspector]public int PartolIndex;
        [HideInInspector]public BeastMovement Movement;

        protected override void OnStart()
        {
            Movement = GetComponent<BeastMovement>();
        }
    }

}