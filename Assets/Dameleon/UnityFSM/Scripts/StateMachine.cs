using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Object = System.Object;

namespace UnityFSM
{
    public class StateMachine<T, E> : IStateMachine, IStateMachineContext<T>
        where T : struct, IComparable, IConvertible
        where E : IStateMachineEntry<T, IStateMachineContext<T>>
    {
        public T CurrentState { get; protected set; }
        protected IDictionary<T, E> EntryMap = new Dictionary<T, E>();
        protected E Entry {
            get { return EntryMap[CurrentState]; }
        }
        private readonly Object _sync = new Object();

        public StateMachine(T initialState, IList<E> entries)
        {
            foreach (var entry in entries)
            {
                if (EntryMap.ContainsKey(entry.State))
                {
                    throw new ArgumentException("duplicate state in entries. State: " + entry.State.ToString());
                }
                EntryMap[entry.State] = entry;
            }
            ChangeState(initialState);
        }

        public void ChangeState(T nextState, bool force = false)
        {
            CurrentState = nextState;

            if (CurrentState.Equals(nextState) && !force)
            {
                return;
            }
            lock (_sync)
            {
                if (Entry != null)
                {
                    Exit();
                }
                CurrentState = nextState;
                Enter();
            }
        }

        public void Enter()
        {
            lock (_sync)
            {
                Entry.Enter(this);
            }
        }

        public void Update()
        {
            lock (_sync)
            {
                Entry.Update(this);
            }
        }

        public void Exit()
        {
            lock (_sync)
            {
                Entry.Exit(this);
            }
        }
    }
}
