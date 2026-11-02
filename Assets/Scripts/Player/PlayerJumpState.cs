using UnityEngine;

public class PlayerJumpState : CharacterState
{
    Player player;
    JumpUtilities jumpHelper;
    public PlayerJumpState(Player _player, StateController controller, string v) : base(controller, v)
    {
        player = _player;
        jumpHelper = new JumpUtilities(player);
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log($"Entering Jump state: y velocity is {animParam}");
        //player.PlayerAnimator.SetBool(animParam, true);
        // Implement jump logic here
        // For example, you can apply an upward force to the player's Rigidbody2D
        //player.PhysicalBody.AddForce(Vector2.up * 10f, ForceMode2D.Impulse); // Adjust the force as needed
        player.PlayerAnimator.SetBool("isJumping", true);
        player.SetVelocity(player.PhysicalBody.linearVelocity.x, player.JumpForce);
    }
    public override void Update()
    {
        base.Update();
        if (player.PhysicalBody.linearVelocity.y < 0)
        {
            // Transition to Fall state if the player is grounded
            Debug.Log("Player is falling, transitioning to Fall state.");
            controller.ChangeState(player.Fall);
        }

    }

    public override void Exit()
    {
        base.Exit();
        player.PlayerAnimator.SetBool("isJumping", false);
    }
}
