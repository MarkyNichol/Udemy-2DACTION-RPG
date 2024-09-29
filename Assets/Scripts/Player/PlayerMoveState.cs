using UnityEngine.AI;

public class PlayerMoveState : PlayerGroundedState
{
    public PlayerMoveState(Player _Player, PlayerStateMachine _StateMachine, string animBoolName) : base(_Player, _StateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
       
        base.Update();

        if (player.IsWallDetected())
            stateMachine.ChangeState(player.idleState);

        player.SetVelocity(xInput * player.moveSpeed, rb.velocity.y);


        if (xInput == 0)
            stateMachine.ChangeState(player.idleState);
    }
}
