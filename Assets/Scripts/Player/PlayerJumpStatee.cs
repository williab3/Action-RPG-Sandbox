using UnityEngine;

public class PlayerJumpStatee : CharacterState
{
    Player player;
    public PlayerJumpStatee(Player _player, StateController controller, string v) : base(controller, v)
    {
        player = _player;
    }
    public override void Update()
    {
        base.Update();
        // Implement jump logic here
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Transition to jump state
//            controller.ChangeState(player.Jump);
        }
    }
}
