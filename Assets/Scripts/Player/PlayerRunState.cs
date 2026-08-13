using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerRunState : EntityState
{
    Player player;
    public PlayerRunState(global::Player _player, StateController _controller, string v) : base(_controller, v)
    {
        player = _player;
    }

    public override void Update()
    {
        base.Update();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Transition to jump state
            //controller.ChangeState(player.ju);
        }
    }
}

