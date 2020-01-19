using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.AI.States
{

    public delegate void StateEventHandle<T>(T controller);

    public interface IState<T>
    {
        void OnEnter(T controller);
        void OnUpdate(T controller);
        void OnExit(T controller);
    }

    public class State<T> : IState<T>
    {

        public string StateName { get; protected set; }
        public event StateEventHandle<T> UpdateEvent;

        public State(string name, StateEventHandle<T> action = null)
        {
            StateName = name;
            UpdateEvent = action;
        }


        public virtual void OnEnter(T controller)
        {
        }
        public virtual void OnUpdate(T controller)
        {
            UpdateEvent?.Invoke(controller);
        }

        public virtual void OnExit(T controller)
        {
        }


    }

}