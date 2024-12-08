using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField]private Rigidbody2D _rb;
    [SerializeField] private CircleCollider2D _groundDetector;

    [SerializeField] private Animator _animator;

    [SerializeField] private bool _isGrounded = false;
    [SerializeField] private Vector2 _Move;
    [SerializeField] private float _Speed, _jumpForce;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _groundDetector = GetComponent<CircleCollider2D>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        _animator.SetFloat("VelocityY", _rb.velocity.y);
        _animator.SetBool("IsGrounded", _isGrounded);


        _rb.velocity = new Vector2(_Move.x * _Speed, _rb.velocity.y);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Ground")
        {
            _isGrounded = true;
            _animator.SetBool("Jump", false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _isGrounded = false;
        }
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (_isGrounded)
        {
            _animator.SetBool("Jump", true);
        }
    }
    public void OnJump() 
    {
            _rb.velocity = Vector3.up * _jumpForce;
    }

    
    public void OnMove(InputAction.CallbackContext context)
    {
        _Move = context.ReadValue<Vector2>();
        Debug.Log(_Move);
    }
}
