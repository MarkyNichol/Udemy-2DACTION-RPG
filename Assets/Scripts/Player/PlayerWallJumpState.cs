public class PlayerWallJumpState : PlayerState
{
    public PlayerWallJumpState(Player _Player, PlayerStateMachine _StateMachine, string animBoolName) : base(_Player, _StateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        stateTimer = .4f;
        player.SetVelocity(5 * -player.facingDir, player.jumpForce);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if (stateTimer > 0)
            stateMachine.ChangeState(player.airState);


        if (player.IsGroundDetected())
            stateMachine.ChangeState(player.idleState);




    }
}
