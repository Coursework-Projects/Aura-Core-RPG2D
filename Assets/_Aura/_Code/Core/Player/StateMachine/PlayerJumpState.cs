using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerBaseState
{
    public PlayerJumpState(Player _player, PlayerStateMachine _playeStateMachine, string _animBoolName) : base(_player, _playeStateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        player.SetVelocity(playerRb.velocity.x, player.JumpHeight);
        player.PlayerAnim.SetBool(animBoolName,true);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if(playerRb.velocity.y < 0)
        {
            playerStateMachine.ChangeState(player.FallState);
        }
    }
}
