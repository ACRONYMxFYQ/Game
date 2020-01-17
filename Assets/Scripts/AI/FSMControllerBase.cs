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

        #region MonoBehaviour Callbacks

        private void Start()
        {
            CurrentState = EnterState;
            CurrentState.OnEnter(this);

            OnStart();
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