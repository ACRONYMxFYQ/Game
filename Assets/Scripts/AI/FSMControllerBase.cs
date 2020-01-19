using Game.AI.States;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.AI
{

    public class FSMControllerBase<T>
    {
        public IState<T> CurrentState { get; protected set; }
        public IState<T> EntryState { get; set; }
        private readonly T _owner;
        private readonly Dictionary<string, IState<T>> _stateDic;

        public FSMControllerBase(T o, IState<T> entry=null)
        {
            _owner = o;
            EntryState = entry;
            _stateDic = new Dictionary<string, IState<T>>();
        }

        public void Start()
        {
            if(EntryState!=null)
            {
                CurrentState = EntryState;
                CurrentState.OnEnter(_owner);
            }
        }

        public void Update()
        {
            if(CurrentState!=null)
            {
                CurrentState.OnUpdate(_owner);
            }
        }

        public void ChangeState(string name)
        {
            if(!_stateDic.ContainsKey(name))
            {
                Debug.LogError("FSMController/ChangeState Error : the name of state is invalid value");
                return;
            }
            if(CurrentState!=null)
            {
                CurrentState.OnExit(_owner);
                CurrentState = _stateDic[name];
                CurrentState.OnEnter(_owner);
            }
        }

        public void AddState(string name, IState<T> state)
        {
            if(_stateDic.ContainsKey(name))
            {
                Debug.LogWarning("FSMController/AddState Warning : the name of state is exist !");
                return;
            }
            _stateDic.Add(name, state);
        }

        public void RemoveState(string name)
        {
            if (_stateDic.ContainsKey(name))
                _stateDic.Remove(name);
            else
                Debug.LogError("FSMController/RemoveState Error : the name of state is invalid value");
        }
    }
   
}