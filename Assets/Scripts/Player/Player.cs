using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerIdleState Idle { get; private set; }
    public PlayerRunState Run { get; private set; }
    public PlayerJumpState Jump { get; private set; }
    public PlayerFallState Fall { get; private set; }
    public Animator PlayerAnimator { get; private set; }
    public Rigidbody2D PhysicalBody { get; private set; }
    [Header("Ground Check")]
    public float DistanceToGround  = 1.38f;
    public bool IsOnGround;

    public LayerMask GroundLayer;
    [Header("Movement Details")]
    public float MoveSpeed = 5f;
    public float JumpForce = 6f;
    public bool isFacingRight { get; private set; } = true;
    public PlayerInputSet inputActions { get; private set; }
    public Vector2 inputValue;


    StateController stateController;
    JumpUtilities jumpCoordinator;


    //private void OnDrawGizmos()
    //{
    //    // Draw a line to visualize the ground check distance
    //    Gizmos.color = Color.magenta;
    //    Gizmos.DrawLine(transform.position, transform.position + new Vector3(0, -DistanceToGround));
    //}
    void Awake()
    {
        inputActions = new PlayerInputSet();
        PlayerAnimator = GetComponentInChildren<Animator>();
        stateController = new StateController();
        PhysicalBody = GetComponent<Rigidbody2D>();
        Idle = new PlayerIdleState(this, stateController, "isIdle");
        Run = new PlayerRunState(this, stateController, "isRunning");
        Jump = new PlayerJumpState(this, stateController, "yVelocity");
        Fall = new PlayerFallState(this, stateController, "yVelocity");
        jumpCoordinator = new JumpUtilities(this);
        GroundLayer = LayerMask.GetMask("Ground");
    }
    
    void OnEnable()
    {
        inputActions.Enable();
        inputActions.Player.Run.performed += ctx =>
        {
            // Read the input value when the run action is performed
            inputValue = ctx.ReadValue<Vector2>();
        };

        inputActions.Player.Run.canceled += ctx =>
        {
            // Reset the input value to zero when the run action is canceled
            inputValue = Vector2.zero;
        };

    }

    void OnDisable()
    {
        // Disable the input actions when the player is disabled (when player dies or game/round ends)
        inputActions.Disable();
    }
    void Start()
    {
        stateController.Initialize(Idle);
    }

    void Update()
   {
        jumpCoordinator.MeasureCharacterHeight();
        IsOnGround = jumpCoordinator.canJump();
        stateController.CurrentState.Update();
        PlayerAnimator.SetFloat("yVelocity", PhysicalBody.linearVelocity.y);

    }

    void FixedUpdate()
    {
        // Apply movement in physics loop
        SetVelocity(inputValue.x * MoveSpeed, PhysicalBody.linearVelocity.y);
    }

    public void SetVelocity(float xVelocity, float yVelocity)
    {
        PhysicalBody.linearVelocity = new Vector2(xVelocity, yVelocity);
    }


    public void turnAround()
    {
        transform.Rotate(0, 180, 0);
        isFacingRight = !isFacingRight;
    }

}
