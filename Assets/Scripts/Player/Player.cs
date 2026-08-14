using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerIdleState Idle { get; private set; }
    public PlayerRunState Run { get; private set; }
    public PlayerJumpStatee Jump { get; private set; }
    public Vector2 inputValue;
    public Animator PlayerAnimator { get; private set; }

    StateController stateController;
    PlayerInputSet inputActions;
    void Awake()
    {
        PlayerAnimator = GetComponentInChildren<Animator>();
        inputActions = new PlayerInputSet();
        stateController = new StateController();
        Idle = new PlayerIdleState(this, stateController, "isIdle");
        Run = new PlayerRunState(this, stateController, "isRunning");
        Jump = new PlayerJumpStatee(this, stateController, "isJumping");
    }
    
    void OnEnable()
    {
        // Enable the input actions when the player is enabled (when game/round starts)
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
}
