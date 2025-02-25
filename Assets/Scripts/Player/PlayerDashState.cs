public class PlayerDashState : PlayerState
{
    public PlayerDashState(Player _Player, PlayerStateMachine _StateMachine, string animBoolName) : base(_Player, _StateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        player.skill.clone.CreateClone(player.transform);

        stateTimer = player.dashDuration;
    }


    public override void Exit()
    {
        base.Exit();

        player.SetVelocity(0,rb.velocity.y);
    }

    public override void Update()
    {
        base.Update();
        if (!player.IsGroundDetected() && player.IsWallDetected())
            stateMachine.ChangeState(player.wallSlide);


        player.SetVelocity(player.dashSpeed * player.dashDir,0);

        if (stateTimer < 0)
            stateMachine.ChangeState(player.idleState);







    }
}
