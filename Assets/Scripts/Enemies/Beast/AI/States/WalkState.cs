using Game.AI;
using Game.AI.States;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Enemies.Beast.AI
{
    [CreateAssetMenu(menuName ="AI/Beast/State/WalkState")]
    public class WalkState : State
    {
        public override void OnEnter(FSMControllerBase controlller)
        {
            (controlller as BeastFSM).PartolIndex = 0;
        }

        public override void OnExit(FSMControllerBase controller)
        {
            (controller as BeastFSM).PartolIndex = 0;
        }
    }

}