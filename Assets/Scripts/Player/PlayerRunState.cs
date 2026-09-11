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
        player.PlayerAnimator.SetBool(animXParam, true);
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
    }

    public override void Exit()
    {
        player.PlayerAnimator.SetBool(animXParam, false);
    }
}

