using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    public int JumpForce = 100;

    public float speed = 5.0f;
    public Animator animator;

    private Rigidbody2D rigidbody2D;

    private InputMaster _inputMaster;
    
    

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();

        _inputMaster = new InputMaster();
        _inputMaster.Enable();
    }

    // ReSharper disable Unity.PerformanceAnalysis
    private void Movement()
    {
        
        Vector2 vector2 = _inputMaster.Player.Movement.ReadValue<Vector2>();
        
        if (vector2!= Vector2.zero)
        {
            Debug.Log(vector2);
             float _temp_speed = Mathf.Abs(vector2.x * speed);
             
             transform.localScale = new Vector3(-1, 1, 1);
             
             animator.SetFloat("speed",_temp_speed);
             if (_temp_speed < 4.5f)
             {
                 animator.Play("walk");
             }
             rigidbody2D.velocity = new Vector3(vector2.x, 0,vector2.y)*speed;
        }
        else
        {
            animator.Play("idle");
            rigidbody2D.velocity = Vector2.zero;
        }
    }

    // ReSharper disable Unity.PerformanceAnalysis
    private void Jump()
    {
        if (_inputMaster.Player.Jump.triggered)
        {
            Debug.Log("Jump");
            rigidbody2D.AddForce(new Vector3(0,JumpForce,0));
        }
    }
        
    void Update()
    {
        
        //Input
        Movement();
        Jump();


        //keycode
        if (Input.GetKey(KeyCode.A))
        { 
            rigidbody2D.velocity = new Vector2(-5, rigidbody2D.velocity.y);
            transform.localScale = new Vector3(-1, 1, 1);
            animator.SetBool("walking", true);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rigidbody2D.velocity -= new Vector2(5, rigidbody2D.velocity.y);
            transform.localScale = new Vector3(1, 1, 1);
            animator.SetBool("walking", true);
        }
    }
}