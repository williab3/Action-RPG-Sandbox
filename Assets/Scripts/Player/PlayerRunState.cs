using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerRunState : CharacterState
{
    Player player;
    public PlayerRunState(global::Player _player, StateController _controller, string v) : base(_controller, v)
    {
        player = _player;
    }


    public override void Enter()
    {
        base.Enter();
        player.PlayerAnimator.SetBool(animParam, true);
        Debug.Log($"Entering Run state");
    }
    public override void Update()
    {
        if (player.inputValue.x == 0)
        {
            player.SetVelocity(0, 0);
            // Transition to Idle state if the player is not moving
            controller.ChangeState(player.Idle);
        }

        if(player.isFacingRight && player.inputValue.x < 0)
        {
            player.turnAround();
        }
        else if(!player.isFacingRight && player.inputValue.x > 0)
        {
            player.turnAround();
        }

        if(player.inputActions.Player.Jump.WasPressedThisFrame())
        {
            Debug.Log("InitialJump button pressed, transitioning to InitialJump state from Run");
            controller.ChangeState(player.Jump);
        }
    }

    public override void Exit()
    {
        player.PlayerAnimator.SetBool(animParam, false);
    }
}

