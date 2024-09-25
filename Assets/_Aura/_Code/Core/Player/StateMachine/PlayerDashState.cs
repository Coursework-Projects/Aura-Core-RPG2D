using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : PlayerBaseState
{
    public PlayerDashState(Player _player, PlayerStateMachine _playeStateMachine, string _animBoolName) : base(_player, _playeStateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();       
        timer = player.DashDuration;
    }

    public override void Exit()
    {
        base.Exit();
          
        player.SetVelocity(0f,playerRb.velocity.y);
    }

    public override void Update()
    {
        base.Update();

        player.SetVelocity(player.DashSpeed * player.FacingDirection, 0f);

        if (timer < 0 && player.CheckGrounded())
        {
            playerStateMachine.ChangeState(player.IdleState);
        }
        else if (timer < 0 && !player.CheckGrounded())
        {
            playerStateMachine.ChangeState(player.FallState);
        }
    }
}
