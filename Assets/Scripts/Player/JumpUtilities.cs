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


    public void TransferToJumpSate(StateController priorState, String stateName)
    {
        if (player.inputActions.Player.Jump.WasPressedThisFrame())
        {
            Debug.Log("Jump button pressed, transitioning to Jump state from " + stateName);
            priorState.ChangeState(player.Jump);
            // Transition to jump state
        }
    }

    public bool canJump()
    {
        // Cast a 2D ray down and return whether we hit a collider on the ground layer.
        // Use the RaycastHit2D so we can inspect the result and draw an accurate debug line.
        Vector2 origin = player.transform.position;
        RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.down, player.DistanceToGround, player.GroundLayer);
        // Draw the ray to the hit point when present, otherwise draw the full distance.
        Vector3 end = hit.collider != null ? (Vector3)hit.point : player.transform.position + Vector3.down * player.DistanceToGround;
        Debug.DrawLine(player.transform.position, end, Color.magenta, 0f, false);
        return hit.collider != null;
    }

    public void MeasureCharacterHeight()
    {
        // Ensure the drawn line uses the configured distance. The previous code passed
        // Vector3.down (1 unit) as the end point and DistanceToGround as the duration,
        // so changing the distance only affected how long the line stayed visible.
        // Draw only for one frame (duration 0) to match what the raycast is doing.
        Debug.DrawLine(player.transform.position, player.transform.position + Vector3.down * player.DistanceToGround, Color.magenta, 0f, false);
        //Gizmos.color = Color.magenta;
        //Gizmos.DrawLine(player.transform.position, player.transform.position + Vector3.down * player.DistanceToGround);
        //Gizmos.DrawSphere(attackPoint.position, attackRange);
    }

}
