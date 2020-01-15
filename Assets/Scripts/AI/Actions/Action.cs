using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.AI
{

    public interface IColliderAction
    {
        void Act(FSMControllerBase controller, Collider2D other);
    }

    public abstract class Action : ScriptableObject
    {
        public abstract void Act(FSMControllerBase controller);
    }

    public abstract class ColliderAction : ScriptableObject, IColliderAction
    {
        public abstract void Act(FSMControllerBase controller, Collider2D other);
    }
}