using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallJumpState : PlayerBaseState
{
    public PlayerWallJumpState(Player _player, PlayerStateMachine _playeStateMachine, string _animBoolName) : base(_player, _playeStateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.SetVelocity(player.wallJumpVelocity.x * -player.FacingDirection,player.wallJumpVelocity.y);
    }

    public override void Update()
    {
        if (player.CheckGrounded())
        {
            playerStateMachine.ChangeState(player.IdleState);
        }

        if (player.CheckWallCollision())
        {
            playerStateMachine.ChangeState(player.WallSlideState);
        }

        base.Update();
    }

    public override void Exit()
    {
        base.Exit();
    }


}
