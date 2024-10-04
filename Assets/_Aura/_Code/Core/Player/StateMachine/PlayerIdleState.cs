using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerGroundState
{
    public PlayerIdleState(Player _player, PlayerStateMachine _playeStateMachine, string _animBoolName) : base(_player, _playeStateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        //reset the animation trigger
        TriggerAnimationEvent(false);

        //zero out all velocity carried forward from other states
        player.SetVelocity(0f, 0f);
        player.PlayerAnim.SetBool(animBoolName, true);
    }

    public override void Update()
    {
        base.Update();

        if (xInput != 0 && player.CheckGrounded())
            playerStateMachine.ChangeState(player.MoveState);
    }
    public override void Exit()
    {
        base.Exit();

        player.PlayerAnim.SetBool(animBoolName, false);
    }

   
}
