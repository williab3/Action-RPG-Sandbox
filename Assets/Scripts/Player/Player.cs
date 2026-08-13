using UnityEngine;

public class Player : MonoBehaviour
{
    StateController stateController;
    public PlayerIdleState Idle { get; private set; }
    public PlayerRunState Run { get; private set; }
    public PlayerJumpStatee Jump { get; private set; }

    void Awake()
    {
        stateController = new StateController();
        Idle = new PlayerIdleState(this, stateController, "Idle State");
        Run = new PlayerRunState(this, stateController, "Run State");
        Jump = new PlayerJumpStatee(this, stateController, "Jump State");
    }
    
    void Start()
    {
        stateController.Initialize(Idle);
    }
    // Update is called once per frame
    void Update()
    {
        stateController.CurrentState.Update();
    }
}
