using UnityEngine;

public class PlayerWalkState : IPlayerState
{
    private PlayerStateMachine stateMachine;

    public PlayerWalkState(PlayerStateMachine sm)
    {
        stateMachine = sm;
    }

    public void Enter()
    {

    }

    public void Update()
    {
        // Check transition condition
        if (stateMachine.moveInput.magnitude < 0.1f)
        {
            stateMachine.SwitchState(stateMachine.idleState);
            return;
        }

        // Movement logic
        Vector3 moveDirection = stateMachine.GetIsometricDirection();
        stateMachine.controller.Move(moveDirection * stateMachine.walkSpeed * Time.deltaTime);

        // Adjust rotation to move direction
        if (moveDirection != Vector3.zero)
        {
            RotateTowards(moveDirection);
        }
    }

    public void Exit()
    {

    }

    private void RotateTowards(Vector3 direction)
    {
        float rotationSpeed = 10f;
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        stateMachine.transform.rotation = Quaternion.Slerp(stateMachine.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
