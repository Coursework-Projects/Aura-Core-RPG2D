using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Move Settings
    [field:SerializeField]public float MoveSpeed {  get; private set; }
    [field:SerializeField]public float JumpHeight {  get; private set; }
    #endregion

    #region Dash Ability Settings
    [field:SerializeField]public float DashSpeed { get;private set; }
    [field:SerializeField]public float DashDuration { get;private set; }
    [field:SerializeField]public float DashCooldown { get;private set; }
    public float DashDirection { get;private set; }
    #endregion

    #region Collision Settings
    [Header("Collision Settings")]
    public float groundCheckDistance;
    public float wallCheckDistance;
    public LayerMask groundMask;
    #endregion
    public int FacingDirection { get; private set; } = 1;



    #region References
    public Transform groundChecker;
    public Transform wallChecker;
    public Animator PlayerAnim { get; private set; }
    public Rigidbody2D PlayerRb { get; private set; }


    #endregion

    #region State Machine Properties
    public PlayerStateMachine PlayerStateMachine { get; private set; }
    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }
    public PlayerJumpState JumpState { get; private set; }
    public PlayerFallState FallState { get; private set; }
    public PlayerDashState DashState { get; private set; }
    #endregion

    #region state flags
    private bool isFacingRight = true;
    private float dashDurationTimer;
    private float dashCooldownTimer;
    #endregion


    private void Awake()
    {
        //initializer references
        PlayerAnim = GetComponentInChildren<Animator>();
        PlayerRb=GetComponent<Rigidbody2D>();

        //initialize state machine
        PlayerStateMachine = new PlayerStateMachine();

        //initialize states
        IdleState = new PlayerIdleState(this, PlayerStateMachine, "idle");
        MoveState = new PlayerMoveState(this, PlayerStateMachine, "move");
        JumpState = new PlayerJumpState(this, PlayerStateMachine, "jump");
        FallState = new PlayerFallState(this, PlayerStateMachine, "jump");
        DashState = new PlayerDashState(this, PlayerStateMachine, "dash");
    }

    #region Monobehaviour Callbacks
    private void Start()
    {
        PlayerStateMachine.Initialize(IdleState);
    }

    private void Update()
    {
        FlipController(Input.GetAxisRaw("Horizontal"));
        PlayerStateMachine.CurrentState.Update();

        HandleDashInput();
    }

    private void HandleDashInput()
    {
       dashCooldownTimer -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.LeftShift) && dashCooldownTimer < 0)
        { 
            PlayerStateMachine.ChangeState(DashState);
            dashCooldownTimer = DashCooldown;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        //draw ground check gizmo
        Gizmos.DrawLine(groundChecker.position,new Vector2(groundChecker.position.x, groundChecker.position.y - groundCheckDistance));

        //draw wall check gizmo
        Gizmos.DrawLine (wallChecker.position,new Vector2(wallChecker.position.x + wallCheckDistance,wallChecker.position.y));    
    }
    #endregion


    #region Movement API
    public void SetVelocity(float _xValue, float _yValue)
    {
        PlayerRb.velocity = new Vector2(_xValue, _yValue);
       
    }

    public void FlipController(float _xValue)
    {
        if (_xValue > 0 && !isFacingRight)
        {
            Flip();
        }
        else if(_xValue < 0 && isFacingRight)
        {
            Flip();
        }
    }
    #endregion

    #region Collision API
    public bool CheckGrounded() => Physics2D.Raycast(groundChecker.position, Vector2.down, groundCheckDistance, groundMask);
    #endregion

    #region Private Utility
    private void Flip()
    {
        transform.Rotate(0, 180, 0);
        isFacingRight = !isFacingRight;
        FacingDirection = FacingDirection * -1;
    }
    #endregion
}
