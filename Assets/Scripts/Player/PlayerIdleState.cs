using UnityEngine;

public class PlayerIdleState : CharacterState
{
    Player player;
    JumpUtilities jumpAction;
    public PlayerIdleState(Player _player, StateController controller, string v) : base(controller, v)
    {
        player = _player;
        jumpAction = new JumpUtilities(player);
    }

    public override void Enter()
    {
        Debug.Log($"Entering Idle state: {animParam} is true");
        player.PlayerAnimator.SetBool(animParam, true);
    }

    public override void Update()
    {
        if (player.inputValue.x != 0)
        {
            // Transition to run state
            controller.ChangeState(player.Run);
            Debug.Log("Player is moving, transitioning to Run state from Idle");
        }
        if (player.inputActions.Player.Jump.WasPressedThisFrame())
        {
            Debug.Log("InitialJump button pressed, transitioning to InitialJump state from Idle");
            controller.ChangeState(player.Jump);
        }
    }

    public override void Exit()
    {
        Debug.Log($"Exiting Idle state: {animParam} is false");
        player.PlayerAnimator.SetBool(animParam, false);
    }
}
