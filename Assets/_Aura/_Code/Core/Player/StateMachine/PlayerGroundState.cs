using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundState : PlayerBaseState
{
    public PlayerGroundState(Player _player, PlayerStateMachine _playeStateMachine, string _animBoolName) : base(_player, _playeStateMachine, _animBoolName)
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
            playerStateMachine.ChangeState(player.JumpState);
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            playerStateMachine.ChangeState(player.AttackState);
        }


       

    }
}
