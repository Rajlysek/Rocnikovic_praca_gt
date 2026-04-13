
using System.Collections;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    public float moveSpeed = 5f;

    public bool isMoving;

    public Vector2 input;
    public Vector2 lastDirection;

    private Rigidbody2D rb2;

    private Animator _animator;
    private bool PlayerMovement;


   
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2 = gameObject.GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       
        bool ShiftIsHeld = Input.GetKey(KeyCode.LeftShift);
        //GETTIN AXIS FOR MOVEMENT
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");


        //NORMALIZING DIAGONAL MOVEMENT

        if (input.magnitude > 1)
        {
            input = input.normalized;
        }
       
        //if(Input.GetKeyDown(KeyCode.Space) && _animator.GetInteger("ItemID") == 1) 
        //{
        //    input = Vector2.zero;
        //    _animator.SetBool("isMoving", false);
        //}


        if (input != Vector2.zero)
        {
            PlayerMovement = true;
        }
        else
        {
            PlayerMovement = false;
        }

        if (PlayerMovement)
        {
            _animator.SetFloat("InputX", input.x);
            _animator.SetFloat("InputY", input.y);
            lastDirection = input;
            _animator.SetFloat("LastDirX", lastDirection.x);
            _animator.SetFloat("LastDirY", lastDirection.y);
        }

        _animator.SetBool("isMoving", PlayerMovement);
        ///////////////////
        if (ShiftIsHeld && PlayerMovement)
        {
            _animator.SetBool("isRunning", true);
            moveSpeed = 10f;
           
        }
        else
        {
            _animator.SetBool("isRunning", false);
            moveSpeed = 5f;
            
        }

        

    }
    private void FixedUpdate()
    {
        rb2.MovePosition(rb2.position + input * moveSpeed * Time.fixedDeltaTime);
    
        if (input == Vector2.zero)
        {  
            input = Vector2.zero;
        }

    }
    

  
  
}
