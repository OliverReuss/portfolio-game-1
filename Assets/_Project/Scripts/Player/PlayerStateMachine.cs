using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    // Components
    public CharacterController controller;
    public Transform cameraTransform;

    // Input Asset Instance
    private IA_PlayerControls inputActions;

    // States
    public IPlayerState currentState;
    public PlayerIdleState idleState;
    public PlayerWalkState walkState;

    // Input
    public Vector2 moveInput;

    // Variables
    public float walkSpeed = 5f;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();

        // Create states and reference this state machine
        idleState = new PlayerIdleState(this);
        walkState = new PlayerWalkState(this);
    }

    private void OnEnable()
    {
        if (inputActions == null)
        {
            inputActions = new IA_PlayerControls();
        }

        inputActions.Enable();

        // Subscribe to input events
        inputActions.Player.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        inputActions.Player.Move.canceled += ctx => moveInput = Vector2.zero;
    }

    private void OnDisable()
    {
        if (inputActions != null)
        {
            // Unsubscribe and disable actions
            inputActions.Player.Move.performed -= ctx => moveInput = ctx.ReadValue<Vector2>();
            inputActions.Player.Move.canceled -= ctx => moveInput = Vector2.zero;
            inputActions.Disable();
        }
    }

    private void Start()
    {
        // Set start state
        SwitchState(idleState);
    }

    private void Update()
    {
        // Execute the logic of current state each frame
        if (currentState != null)
        {
            currentState.Update();
        }
    }

    public void SwitchState(IPlayerState newState)
    {
        if (currentState != null)
        {
            currentState.Exit();
        }

        currentState = newState;
        currentState.Enter();
    }

    public Vector3 GetIsometricDirection()
    {
        if (cameraTransform == null)
        {
            return Vector3.zero;
        }

        // Calculate move direction relative to the isometric camera
        Vector3 camForward = cameraTransform.forward;
        Vector3 camRight = cameraTransform.right;

        camForward.y = 0;
        camRight.y = 0;

        return (camForward.normalized * moveInput.y + camRight.normalized * moveInput.x).normalized;
    }
}