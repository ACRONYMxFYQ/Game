using Game.AI.Decisions;
using Game.AI.States;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.AI
{
    [System.Serializable]
    public class Transition : ScriptableObject
    {
        public Decision Decision;
        public State TrueState;
        public State FalseState;
    }

}