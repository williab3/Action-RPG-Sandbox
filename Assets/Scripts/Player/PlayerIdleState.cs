using UnityEngine;

public class PlayerIdleState : EntityState
{
    Player player;
    public PlayerIdleState(Player _player, StateController controller, string v) : base(controller, v)
    {
        player = _player;
    }

    public override void Update()
    {
        base.Update();
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            // Transition to run state
            controller.ChangeState(player.Run);
        }
    }
}
