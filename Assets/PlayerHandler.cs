using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    public int JumpForce = 100;

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
        Debug.Log(vector2);
        if (vector2!= Vector2.zero)
        {
            rigidbody2D.velocity = new Vector3(vector2.x, 0,vector2.y);
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
            rigidbody2D.velocity -= new Vector2(5, 0);
            transform.localScale = new Vector3(1, 1, 1);
            animator.SetBool("walking", true);
        }
    }
}