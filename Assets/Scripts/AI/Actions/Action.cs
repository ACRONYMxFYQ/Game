using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.AI
{
    public abstract class Action : ScriptableObject
    {
        public abstract void Act(FSMControllerBase controller);
    }

}