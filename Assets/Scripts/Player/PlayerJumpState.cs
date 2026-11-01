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
    public override void Update()
    {
        base.Update();
        // Implement jump logic here

    }
}
