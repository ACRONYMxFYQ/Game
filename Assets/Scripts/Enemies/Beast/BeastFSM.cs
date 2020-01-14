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
        /// <summary> 目标对象，不具体指向某一GameObject，根据需求进行变化 </summary>
        public GameObject TargetGameObject;
        
        protected override void OnStart()
        {
            Movement = GetComponent<BeastMovement>();
        }
    }

}