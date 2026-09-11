using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerIdleState Idle { get; private set; }
    public PlayerRunState Run { get; private set; }
    public PlayerJumpStatee Jump { get; private set; }
    public Vector2 inputValue;
    public Animator PlayerAnimator { get; private set; }
    public Rigidbody2D PhysicalBody { get; private set; }
    public float MoveSpeed = 5f;
    public bool isFacingRight { get; private set; } = true;
    public PlayerInputSet inputActions { get; private set; }
    public LayerMask GroundLayer { get; private set; }
    [SerializeField]
    public bool IsOnGround;

    public float DistanceToGround  = 1f;

    StateController stateController;
    JumpUtilities jumpCoordinator;

    void Awake()
    {
        inputActions = new PlayerInputSet();
        PlayerAnimator = GetComponentInChildren<Animator>();
        stateController = new StateController();
        PhysicalBody = GetComponent<Rigidbody2D>();
        Idle = new PlayerIdleState(this, stateController, "isIdle");
        Run = new PlayerRunState(this, stateController, "isRunning");
        Jump = new PlayerJumpStatee(this, stateController, "isJumping");
        jumpCoordinator = new JumpUtilities(this);
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

        Debug.Log("Distance to ground: " + DistanceToGround);
    }

    void FixedUpdate()
    {
        // Apply movement in physics loop
        SetVelocity(inputValue.x * MoveSpeed, PhysicalBody.linearVelocity.y);
        stateController.CurrentState.Update();
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
