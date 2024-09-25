using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBaseState 
{
    protected Player player;
    protected PlayerStateMachine playerStateMachine;
    protected string animBoolName = "";
    protected float xInput;
    protected float timer;
    protected Rigidbody2D playerRb;
    public PlayerBaseState(Player _player, PlayerStateMachine _playeStateMachine,string _animBoolName)
    {
        player = _player;
        playerStateMachine = _playeStateMachine;
        animBoolName = _animBoolName;
    }

    public virtual void Enter()
    {
        playerRb = player.PlayerRb;
        player.PlayerAnim.SetBool(animBoolName,true);
    }

    public virtual void Update()
    {
        timer -= Time.deltaTime;    

        xInput = Input.GetAxisRaw("Horizontal");
        player.PlayerAnim.SetFloat("yVelocity",playerRb.velocity.y);
    }
    public virtual void Exit()
    {
        player.PlayerAnim.SetBool(animBoolName, false);
    }
}
