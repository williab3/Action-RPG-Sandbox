
using UnityEngine;

public class PlayerFallState : CharacterState
{
    Player player;
    public PlayerFallState(Player _player, StateController controller, string stateName) : base(controller, stateName)
    {
        player = _player;
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log($"Entering Fall state: {animParam} is {player.PhysicalBody.linearVelocity.y}");
        player.PlayerAnimator.SetFloat(animParam, player.PhysicalBody.linearVelocity.y);
    }

    public override void Update()
    {
        player.PlayerAnimator.SetFloat(animParam, player.PhysicalBody.linearVelocity.y);

        base.Update();
        if (player.IsOnGround)
        {
            Debug.Log("Player is grounded, transitioning to Idle state.");
            player.PlayerAnimator.SetBool("isJumping", false);
            player.IsJumping = false;
            controller.ChangeState(player.Idle);
        }
        //if player is grounded, transition to idle state
    }

}
