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
        Debug.Log($"Entering Idle state: {animXParam} is true");
        player.PlayerAnimator.SetBool(animXParam, true);
    }

    public override void Update()
    {
        if (player.inputValue.x != 0)
        {
            // Transition to run state
            controller.ChangeState(player.Run);
        }

        jumpAction.ButtonPressed();
    }

    public override void Exit()
    {
        Debug.Log($"Exiting Idle state: {animXParam} is false");
        player.PlayerAnimator.SetBool(animXParam, false);
    }
}
