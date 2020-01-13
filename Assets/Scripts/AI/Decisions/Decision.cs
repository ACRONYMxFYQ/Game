using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.AI.Decisions
{
    public abstract class Decision : ScriptableObject
    {
        public abstract bool Decide(FSMControllerBase controlller);
    }

}