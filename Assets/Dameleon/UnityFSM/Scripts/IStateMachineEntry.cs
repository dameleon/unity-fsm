using System;

namespace UnityFSM
{
    public interface IStateMachineEntry<T, C>
        where T : struct, IComparable, IConvertible
        where C : IStateMachineContext<T>
    {
        T State { get; }
        void Enter(C context);
        void Update(C context);
        void Exit(C context);
    }
}
