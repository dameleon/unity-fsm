using System.Collections.Generic;
using UnityEngine;

namespace UnityFSM
{
    public class OnUpdateStateMachineRunner : MonoBehaviourStateMachineRunner
    {
        void Update()
        {
            foreach (var stateMachine in _stateMachines)
            {
                stateMachine.Update();
            }
        }
    }
}
