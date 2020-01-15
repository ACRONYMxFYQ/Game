using Game.AI.States;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.AI
{
    public class FSMControllerBase : MonoBehaviour
    {

        public State EnterState;

         public State CurrentState;
        [HideInInspector] public State PreviousState;
        /// <summary> 目标对象，不具体指向某一GameObject，根据需求进行变化 </summary>
        public GameObject TargetGameObject;

        #region MonoBehaviour Callbacks

        private void Start()
        {
            OnStart();

            CurrentState = EnterState;
            CurrentState.OnEnter(this);
        }

        private void Update()
        {
            if (CurrentState != null)
                CurrentState.OnUpdate(this);

            OnUpdate();
        }

        #endregion

        public void TranslateState(State nextState)
        {
            CurrentState.OnExit(this);
            nextState.OnEnter(this);
            PreviousState = CurrentState;
            CurrentState = nextState;
        }

        #region Virtual Methods
        protected virtual void OnStart()
        {

        }

        protected virtual void OnUpdate()
        {

        }
        #endregion
    }

}