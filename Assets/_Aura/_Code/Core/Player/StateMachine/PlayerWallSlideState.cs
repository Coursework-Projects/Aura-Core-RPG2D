using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallSlideState : PlayerBaseState
{
    public PlayerWallSlideState(Player _player, PlayerStateMachine _playeStateMachine, string _animBoolName) : base(_player, _playeStateMachine, _animBoolName)
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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerStateMachine.ChangeState(player.wallJumpState);
        }

        if (yInput < 0)
        {

            playerRb.velocity = new Vector2(playerRb.velocity.x, playerRb.velocity.y * yInput * -1f);
        }
        else
        {
            playerRb.velocity = new Vector2(playerRb.velocity.x, playerRb.velocity.y * .3f);
        }

        if (player.CheckGrounded())
            playerStateMachine.ChangeState(player.IdleState);

        if (xInput != 0 && xInput != player.FacingDirection)
            playerStateMachine.ChangeState(player.IdleState);

    }
}
