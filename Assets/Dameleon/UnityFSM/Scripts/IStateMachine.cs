using System;
using UnityEngine;
using System.Collections;

namespace UnityFSM
{
    public interface IStateMachine
    {
        void Enter();
        void Update();
        void Exit();
    }

    public interface IStateMachineContext<T>
        where T : struct, IComparable, IConvertible
    {
        T CurrentState { get; }
        void ChangeState(T nextState, bool force = false);
    }
}
