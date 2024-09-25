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
        if (player.CheckGrounded())//ToDo:implement ground check
        {    
            playerStateMachine.ChangeState(player.IdleState);
        }
    }
}
