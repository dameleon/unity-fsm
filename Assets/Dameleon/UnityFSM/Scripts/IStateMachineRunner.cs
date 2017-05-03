namespace UnityFSM
{
    public interface IStateMachineRunner
    {
        void Register(IStateMachine stateMachine);
        void Unregister(IStateMachine stateMachine);
    }
}
