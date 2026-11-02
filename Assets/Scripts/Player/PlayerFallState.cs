
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
        Debug.Log($"Entering Fall state: y velocity is {player.PhysicalBody.linearVelocity.y}");
        player.PlayerAnimator.SetFloat(animParam, player.PhysicalBody.linearVelocity.y);
    }

    public override void Update()
    {
        base.Update();
        if (player.IsOnGround)
        {
            Debug.Log("Player is grounded, transitioning to Idle state.");
            controller.ChangeState(player.Idle);
        }
        //if player is grounded, transition to idle state
    }

}
