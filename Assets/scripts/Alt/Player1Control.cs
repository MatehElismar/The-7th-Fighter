using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Control : MonoBehaviour
{
    public int health = 100;
    public float speed = 50f;
    public float jumpForce  = 6.5f;
    private float lastMove = 1f; 
    public bool facingRight = true;
    private Rigidbody2D rb2d;
    private Animator Anim;
    private bool Jump;
    public bool isGrounded; 

    public KeyCode Up;
    public KeyCode Down;
    public KeyCode Right;
    public KeyCode Left;
    public KeyCode Fire; 

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        if(facingRight == false){
            rotate();
            lastMove = -1f;
        }
       print("Sprite Working?");
    }
 
    // Update is called once per frame
    void Update()
    { 
        if(Input.GetKeyDown(Up)){
            Jump = true;

        }
        Anim.SetBool("Grounded", isGrounded);
       //Anim.SetFloat("Speed", Mathf.Abs());
        Move1();
        // float hInput = Input.GetAxisRaw("Horizontal");
        // print(hInput);
        // this.transform.position += new Vector3(hInput * speed * Time.deltaTime, 0, 0); 
        // if(hInput != 0){
        //     if(lastMove != hInput)
        //         rotate();
        //     lastMove = hInput;
        // }
       
    }

    private void rotate()
    {
        transform.Rotate(0f, 180f, 0f);
    }

    public void takeDamage1(int damage){
        this.health -= damage;
        if(this.health <= 0)
            Die1();
    }

    void ToJump1()
    { 
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse); 
    }

    /* private void rotate1()
    {
        transform.rotate1(0f, 180f, 0f);
    }*/

    void Move1()
    {
        if (Input.GetKeyDown(Up) && isGrounded)
        {
            Jump = false;
            ToJump1();
        }

      if (Input.GetKey(Right)){
          /*if(GetComponent<SpriteRenderer>().flipX==true){
              GetComponent<SpriteRenderer>().flipX=false;
          }*/
          if(lastMove != 1) rotate();
             lastMove = 1;

          GetComponent<Animator> ().SetBool ("Run", true);
          transform.Translate (speed, 0,0);

      }
      if (Input.GetKey(Left)){
          /*if(GetComponent<SpriteRenderer>().flipX==false){
              GetComponent<SpriteRenderer>().flipX=true;
          } */
           if(lastMove != -1) rotate();
             lastMove = -1;
          GetComponent<Animator> ().SetBool ("Run", true);
          transform.Translate (speed, 0,0);

      }
      if(Input.GetKeyUp(Right) || Input.GetKeyUp(Left)){
          GetComponent<Animator> ().SetBool ("Run", false);
      }



    }

    // private void OnCollisionEnter2D(Collision2D collision){
    //     if (collision.transform.tag == "ground")
    //     {
    //         Jump = true;
    //     }

    // }

    /*void FixedUpdate2D(){
        if (Jump)
        {
            rb2d.AddForce(Vector2.Up* jumpForce, ForceMode2d.Impulse);
        }
    } */

    
      void Die1(){
        Destroy(gameObject);
    }
}
 
  