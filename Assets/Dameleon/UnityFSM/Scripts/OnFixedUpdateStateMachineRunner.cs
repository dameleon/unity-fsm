using System.Collections.Generic;
using UnityEngine;

namespace UnityFSM
{
    public class OnFixedUpdateStateMachineRunner : MonoBehaviourStateMachineRunner
    {
        void FixedUpdate()
        {
            foreach (var stateMachine in _stateMachines)
            {
                stateMachine.Update();
            }
        }
    }
}
