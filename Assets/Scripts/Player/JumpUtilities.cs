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

    public bool canJump()
    {
        //TODO: let's ensure that there some kind of time delay before the jump for smoother control for when the user is holding the jump button 
        return Physics2D.Raycast(player.transform.position, Vector2.down, player.DistanceToGround, player.GroundLayer);
    }

    public void MeasureCharacterHeight()
    {
        Debug.DrawLine(player.transform.position, player.transform.position + Vector3.down,  Color.magenta, player.DistanceToGround, false);
        //Gizmos.color = Color.magenta;
        //Gizmos.DrawLine(player.transform.position, player.transform.position + Vector3.down * player.DistanceToGround);
        //Gizmos.DrawSphere(attackPoint.position, attackRange);
    }

}
