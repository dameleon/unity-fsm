using System;

namespace UnityFSM
{
    public abstract class StateMachineEntryBase<T, C> : IStateMachineEntry<T, C>
        where T : struct, IComparable, IConvertible
        where C : IStateMachineContext<T>
    {
        public abstract T State { get; }

        public virtual void Enter(C context)
        {
        }

        public virtual void Update(C context)
        {
        }

        public virtual void Exit(C context)
        {
        }
    }
}
