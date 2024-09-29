using UnityEngine;

public class PlayerPrimaryAttackState : PlayerState
{

    private int comboCounter;

    private float lastTimeAttacked;
    private float comboWindow = 1;



    public PlayerPrimaryAttackState(Player _Player, PlayerStateMachine _StateMachine, string animBoolName) : base(_Player, _StateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        xInput = 0; // We need this to fix bug on attackDirection


        if (comboCounter > 2 || Time.time >= lastTimeAttacked + comboWindow)
            comboCounter = 0;


        player.anim.SetInteger("ComboCounter", comboCounter);



        float attackDir = player.facingDir;

        if (xInput != 0)
            attackDir = xInput;





        player.SetVelocity(player.attackMovement[comboCounter].x * attackDir, player.attackMovement[comboCounter].y);

        stateTimer = .1f;
    }

    public override void Exit()
    {
        base.Exit();
        player.StartCoroutine("BusyFor", .15f);


        comboCounter++;

        lastTimeAttacked = Time.time;

    }

    public override void Update()
    {
        base.Update();

        if (stateTimer < 0)
            player.SetZeroVelocity();

        if (triggerCalled)
            stateMachine.ChangeState(player.idleState);


    }
}
