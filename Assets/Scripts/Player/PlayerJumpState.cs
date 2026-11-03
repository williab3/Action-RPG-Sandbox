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
        Debug.Log($"Entering InitialJump state: y velocity is {animParam}");
        
        //Enter into the Jump/Fall blend tree by setting the isJumping parameter to true
        player.PlayerAnimator.SetBool("isJumping", true);
        player.JumpCoordinator.InitialJump();
        player.IsJumping = true;
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

        player.JumpCoordinator.JumpButtonHold();
    }

    public override void Exit()
    {
        base.Exit();
    }
}
