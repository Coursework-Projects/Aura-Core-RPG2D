using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState :PlayerGroundState
{
    public PlayerMoveState(Player _player, PlayerStateMachine _playeStateMachine, string _animBoolName) : base(_player, _playeStateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.PlayerAnim.SetBool(animBoolName,true);
    }

    public override void Update()
    {
        base.Update();

        player.SetVelocity(xInput * player.MoveSpeed, playerRb.velocity.y);

      

        if (xInput == 0)
            playerStateMachine.ChangeState(player.IdleState);
    }

    public override void Exit()
    {
        base.Exit();
      
        player.PlayerAnim.SetBool(animBoolName, false);
    }

 
}
