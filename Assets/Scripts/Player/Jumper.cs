using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Jumper
{
    Player player;

    public Jumper(Player _player)
    {
        player = _player;
    }


    public void ButtonPressed()
    {
        if (player.inputActions.Player.Jump.WasPressedThisFrame())
        {
            Debug.Log("Jump button pressed in Jumper");
            // Transition to jump state
        }
    }
}
