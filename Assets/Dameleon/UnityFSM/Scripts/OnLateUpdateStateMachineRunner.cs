using System.Collections.Generic;
using UnityEngine;

namespace UnityFSM
{
    public class OnLateUpdateStateMachineRunner : MonoBehaviourStateMachineRunner
    {
        void LateUpdate()
        {
            foreach (var stateMachine in _stateMachines)
            {
                stateMachine.Update();
            }
        }
    }
}
