using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterController : MonoBehaviour
{
    private Rigidbody2D _rb = null;
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _jumpForce = 10f;
    
    [SerializeField] private Transform _feetPos;
    [SerializeField] private float _checkRadius = 0.2f;
    [SerializeField] private LayerMask _groundLayer;

    private float _moveHorizontal;
    private float _moveVertical;
    private Vector2 _currentVelocity;
    
    private bool _isJumping = false;
    private bool _isGrounded = false;

    public Rigidbody2D Rb => _rb;

    public void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void Move()
    {
        _moveHorizontal = Input.GetAxis("Horizontal");
        _rb.linearVelocity = new Vector2(_moveHorizontal * _speed, _rb.linearVelocity.y);
    }
    
    public void Jump()
    {
        _isJumping = true;
        _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Force);
    }

    public void Fall()
    {
        
    }
    
    public void Idle()
    {
        
    }
    
    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(_feetPos.position, _checkRadius, _groundLayer);
    }
}
