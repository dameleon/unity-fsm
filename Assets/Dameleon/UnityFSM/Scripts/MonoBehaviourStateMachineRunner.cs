using System.Collections.Generic;
using UnityEngine;

namespace UnityFSM
{
    public abstract class MonoBehaviourStateMachineRunner : MonoBehaviour, IStateMachineRunner
    {
        public enum Status
        {
            Initial,
            Started,
            Destroyed,
        }

        [SerializeField]
        protected readonly IList<IStateMachine> _stateMachines = new List<IStateMachine>();

        protected Status _status = Status.Initial;

        public void Register(IStateMachine stateMachine)
        {
            if (!_stateMachines.Contains(stateMachine))
            {
                _stateMachines.Add(stateMachine);
            }
            switch (_status) {
                case Status.Started:
                    stateMachine.Enter();
                    break;
                case Status.Destroyed:
                    stateMachine.Exit();
                    break;
            }
        }

        public void Unregister(IStateMachine stateMachine)
        {
            if (_stateMachines.Contains(stateMachine))
            {
                _stateMachines.Remove(stateMachine);
            }
        }

        void Start()
        {
            _status = Status.Started;
            foreach (var stateMachine in _stateMachines)
            {
                stateMachine.Enter();
            }
        }

        void OnDestroy()
        {
            _status = Status.Destroyed;
            foreach (var stateMachine in _stateMachines)
            {
                stateMachine.Exit();
            }
        }
    }
}
