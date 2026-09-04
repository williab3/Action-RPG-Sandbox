using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class JumpUtilities
{
    Player player;

    public JumpUtilities(Player _player)
    {
        player = _player;
    }


    public void ButtonPressed()
    {
        if (player.inputActions.Player.Jump.WasPressedThisFrame())
        {
            Debug.Log("Jump button pressed in JumpUtilities");
            // Transition to jump state
        }
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawLine(player.transform.position, player.transform.position + Vector3.down * player.DistanceToGround);
        //Gizmos.DrawSphere(attackPoint.position, attackRange);
    }

}
