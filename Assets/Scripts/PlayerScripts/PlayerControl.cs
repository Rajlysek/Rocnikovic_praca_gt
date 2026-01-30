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
            _animator.SetBool("isMoving", false);
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            if (input != Vector2.zero)
            {
     
                _animator.SetBool("isMoving", true);
            }  
            if(input == Vector2.zero) 
            {
               
                _animator.SetBool("isMoving", false);
                
                 input = Vector2.zero;
            }
           
           
        }
        
       
        
        
    }
    private void FixedUpdate()
    {
        rb2.MovePosition(rb2.position + input * moveSpeed * Time.fixedDeltaTime);
        if (input != Vector2.zero)
        {
            _animator.SetBool("isMoving", true);

            _animator.SetFloat("InputX", input.x);
            _animator.SetFloat("InputY", input.y);
            _animator.SetFloat("LastDirX", input.x);
            _animator.SetFloat("LastDirY", input.y);
        }
        if (input == Vector2.zero)
        {
            
            _animator.SetBool("isMoving", false);
           
            input = Vector2.zero;
        }

    }
  

  
  
}
