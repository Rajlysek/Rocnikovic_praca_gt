using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    public float moveSpeed = 5f;

    public bool isMoving;

    public Vector2 input;

    private Rigidbody2D rb2;

    private Animator _animator;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2 = gameObject.GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        

        if(!isMoving)
        {

            _animator.SetBool("isMovingUp", false);
            _animator.SetBool("isMovingDown", false);
            _animator.SetBool("isMovingLeft", false);
            _animator.SetBool("isMovingRight", false);
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            if(input != Vector2.zero) 
            {
                var targetPos = rb2.position;
                targetPos.x += input.x;
                targetPos.y += input.y;

                _animator.SetBool("isRunning", true);
                if (input.x == 1)
                {
                    _animator.SetBool("isMovingRight", true);
                    _animator.SetBool("isRunning", true);
                }
                if (input.x == -1)
                {
                    _animator.SetBool("isMovingLeft", true);
                    _animator.SetBool("isRunning", true);
                }
                if (input.y == 1)
                {
                    _animator.SetBool("isMovingUp", true);
                    _animator.SetBool("isRunning", true);
                }
                if (input.y == -1)
                {
                    _animator.SetBool("isMovingDown", true);
                    _animator.SetBool("isRunning", true);
                }
            }
            if(input == Vector2.zero) 
            {
                input = Vector2.zero;
                _animator.SetBool("isRunning", false);
            }
           
           
        }
        
       
        
    }
    private void FixedUpdate()
    {
        rb2.MovePosition(rb2.position + input * moveSpeed * Time.fixedDeltaTime);
        if (input != Vector2.zero)
        {
            _animator.SetBool("isRunning", true);
            if (input.x == 1)
            {
                _animator.SetBool("isMovingRight", true);
                _animator.SetBool("isRunning", true);
            }
            if (input.x == -1)
            {
                _animator.SetBool("isMovingLeft", true);
                _animator.SetBool("isRunning", true);
            }
            if (input.y == 1)
            {
                _animator.SetBool("isMovingUp", true);
                _animator.SetBool("isRunning", true);
            }
            if (input.y == -1)
            {
                _animator.SetBool("isMovingDown", true);
                _animator.SetBool("isRunning", true);
            }
        }
        if (input == Vector2.zero)
        {
            input = Vector2.zero;
            _animator.SetBool("isRunning", false);
        }

    }
  

  
  
}
