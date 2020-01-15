using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.AI.States
{

    public class State : ScriptableObject
    {
        public Action[] Actions;
        public Transition[] Transitions;

        public virtual void OnEnter(FSMControllerBase controller)
        {

        }

        public virtual void OnUpdate(FSMControllerBase controller)
        {
            DoActions(controller);
            CheckedTransition(controller);
        }

        public virtual void OnExit(FSMControllerBase controller)
        {

        }

        private void DoActions(FSMControllerBase controlller)
        {
            for (int i = 0; i < Actions.Length; i++)
                Actions[i].Act(controlller);
        }

        private void CheckedTransition(FSMControllerBase controlller)
        {
            foreach(var cell in Transitions)
            {
                bool res = cell.Decision.Decide(controlller);
                if(res)
                {
                    if (cell.TrueState == null)
                        continue;
                    controlller.TranslateState(cell.TrueState);
                }
                else
                {
                    if (cell.FalseState == null)
                        continue;
                    controlller.TranslateState(cell.FalseState);
                }
            }
        }

    }

}