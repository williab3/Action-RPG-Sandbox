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

    StateController stateController;
    PlayerInputSet inputActions;
    void Awake()
    {
        PlayerAnimator = GetComponentInChildren<Animator>();
        inputActions = new PlayerInputSet();
        stateController = new StateController();
        PhysicalBody = GetComponent<Rigidbody2D>();
        Idle = new PlayerIdleState(this, stateController, "isIdle");
        Run = new PlayerRunState(this, stateController, "isRunning");
        Jump = new PlayerJumpStatee(this, stateController, "isJumping");
    }
    
    void OnEnable()
    {
        inputActions.Enable();
        
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
    // Update is called once per frame
    void Update()
    {
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

        stateController.CurrentState.Update();
    }

    public void SetVelocity(float xVelocity, float yVelocity)
    {
        PhysicalBody.linearVelocity = new Vector2(xVelocity, yVelocity);
    }
}
