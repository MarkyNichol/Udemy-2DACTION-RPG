using System.Diagnostics;

public class PlayerAirState : PlayerState
{
    public PlayerAirState(Player _Player, PlayerStateMachine _StateMachine, string animBoolName) : base(_Player, _StateMachine, animBoolName)
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
        if(xInput != 0)
            player.SetVelocity(player.moveSpeed * .8f * xInput, rb.velocity.y);
        
        if (player.IsWallDetected()) 
            stateMachine.ChangeState(player.wallSlide);

        if (player.IsGroundDetected())
            stateMachine.ChangeState(player.idleState);
        
        
        
    }







}
