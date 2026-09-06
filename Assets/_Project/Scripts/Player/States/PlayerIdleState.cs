using UnityEngine;

public class PlayerIdleState : IPlayerState
{
    private PlayerStateMachine stateMachine;

    public PlayerIdleState(PlayerStateMachine sm)
    {
        stateMachine = sm;
    }

    public void Enter()
    {

    }

    public void Update()
    {
        // Check transition condition
        if (stateMachine.moveInput.magnitude >= 0.1f)
        {
            stateMachine.SwitchState(stateMachine.walkState);
            return;
        }

        // Keep character grounded
        Vector3 gravity = new Vector3(0, -2f, 0);
        stateMachine.controller.Move(gravity * Time.deltaTime);
    }

    public void Exit()
    {

    }
}