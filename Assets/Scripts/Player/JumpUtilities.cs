using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.U2D.Physics;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class JumpUtilities
{
    Player player;
    float verticalDirection;

    public JumpUtilities(Player _player)
    {
        player = _player;
        verticalDirection = player.PhysicalBody.linearVelocity.y;
    }


    public void TransferToJumpSate(StateController stateController, String stateName)
    {
        if (player.inputActions.Player.Jump.WasPressedThisFrame())
        {
            Debug.Log("InitialJump button pressed, transitioning to InitialJump state from " + stateName);
            stateController.ChangeState(player.Jump);
            // Transition to jump state
        }
    }

    public bool canJump()
    {
        // Cast a 2D ray down and return whether we hit a collider on the ground layer.
        // Use the RaycastHit2D so we can inspect the result and draw an accurate debug line.

        RaycastHit2D hit = Physics2D.Raycast(player.transform.position, Vector2.down, player.DistanceToGround, player.GroundLayer);
        // Draw the ray to the hit point when present, otherwise draw the full distance.

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

   

    internal void InitialJump()
    {
        if (player.IsOnGround)
        {
            // Apply initial jump force
            player.PhysicalBody.AddForce(Vector2.up * player.InitialJumpForce, ForceMode2D.Impulse);
            
        }
    }

    // This method handles the player's jump physics, including checking if the player is on the ground, applying continuous jump force while the jump button is held, and updating the player's vertical velocity. It also ensures that the player cannot exceed the maximum jump force and resets the jump button hold time when necessary.
    internal void JumpButtonHold()
    {

        if (player.inputActions.Player.Jump.IsPressed() && player.IsJumping)
        {
            // Apply continuous jump force while the jump button is held
            float deltaV = player.jumpHoldAcceleration * Time.fixedDeltaTime;
            player.PhysicalBody.linearVelocity = new Vector2(player.PhysicalBody.linearVelocity.x, player.PhysicalBody.linearVelocity.y + deltaV);
            Debug.Log($"Applied hold deltaV={deltaV:F3}, velY={player.PhysicalBody.linearVelocity.y:F3}");
        }
    }

    internal void handleJumpPhysics()
    {
        throw new NotImplementedException();
    }
}
