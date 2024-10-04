using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallState : PlayerBaseState
{
    public PlayerFallState(Player _player, PlayerStateMachine _playeStateMachine, string _animBoolName) : base(_player, _playeStateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();  
    }

    public override void Exit()
    {
        base.Exit();
        player.PlayerAnim.SetBool(animBoolName, false);
    }

    public override void Update()
    {
        base.Update();

        playerRb.velocity = new Vector2(xInput * player.MoveSpeed, playerRb.velocity.y);

        if (player.CheckGrounded())
        {    
            playerStateMachine.ChangeState(player.IdleState);
        }

        if (player.CheckWallCollision())
        {
            playerStateMachine.ChangeState(player.WallSlideState);
        }
    }
}
