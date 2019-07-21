using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Controller : MonoBehaviour
{
    public int health = 100;
    public float speed = 50f;
    public float jumpForce  = 5f;
    public bool isGrounded = false; 
    private float lastMove = 1f; 
    public bool facingRight = true;


    public KeyCode Up;
    public KeyCode Down;
    public KeyCode Right;
    public KeyCode Left;
    public KeyCode Fire; 

    void Start()
    {
        if(facingRight == false){
            rotate();
            lastMove = -1f;
        }
       print("Sprite Working?");
    }
 
    // Update is called once per frame
    void Update()
    { 
       
        Move();
        // float hInput = Input.GetAxisRaw("Horizontal");
        // print(hInput);
        // this.transform.position += new Vector3(hInput * speed * Time.deltaTime, 0, 0); 
        // if(hInput != 0){
        //     if(lastMove != hInput)
        //         rotate();
        //     lastMove = hInput;
        // }
       
    }

    public void takeDamage(int damage){
        this.health -= damage;
        if(this.health <= 0)
            Die();
    }

    void ToJump()
    { 
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse); 
    }

    private void rotate()
    {
        transform.Rotate(0f, 180f, 0f);
    }

    void Move()
    {
        if(Input.GetKeyDown(Up) && isGrounded)//Pressed Once
        {
            ToJump();
        }
        else if(Input.GetKey(Right))//Held
        {
             print("Updating");
            if(lastMove != 1) rotate();
             lastMove = 1;
             this.transform.position += new Vector3(1 * speed * Time.deltaTime, 0, 0); 
        }
        else if(Input.GetKey(Left))//Held
        {
            if(lastMove != -1) rotate();
             lastMove = -1;
             this.transform.position += new Vector3(-1 * speed * Time.deltaTime, 0, 0); 
        } 
    }

    void Die(){
        Destroy(gameObject);
    }
}    