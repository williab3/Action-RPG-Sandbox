using System;
using System.Collections.Generic;
using System.Text;

public class PlayerFallState : CharacterState
{
    Player player;
    public PlayerFallState(Player _player, StateController controller, string stateName) : base(controller, stateName)
    {
        
    }

    public override void Update()
    {
        base.Update();
        if (player.IsOnGround)
        {
            controller.ChangeState(player.Idle);
        }
        //if player is grounded, transition to idle state
    }

}
