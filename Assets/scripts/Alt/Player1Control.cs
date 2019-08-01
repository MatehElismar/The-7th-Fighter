using System.Timers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Control : MonoBehaviour
{
    public GameObject palyerPrefab;
    public float health = 100;
    public float speed = 50f;
    public float jumpForce  = 6.5f;
    private float lastMove = 1f; 
    public bool facingRight = true;
    private Rigidbody2D rb2d;
    private Animator Anim;
    private bool Jump;
    public bool isGrounded, isReload = false; 
    public int Ammo = 72, Tambor = 6;
    public Transform SpawnP;
    public float vidas = 5;

    // SpecialFunction
    public Timer Timer; 
    public bool CanDoSpecialFunction = true;
    public int SecondsCount = 0;
    public int SFTimeLapse = 10;
    public KeyCode Special; 

    public int secondsToReload = 3;

    // Cannot Move   
    public int FreezeSeconds = 3;
    public bool CanMove = true;

    public KeyCode Up;
    public KeyCode Down;
    public KeyCode Right;
    public KeyCode Left;
    public KeyCode Fire; 
    public KeyCode Reload;
    public KeyCode Scape;

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
        Anim.SetBool("Grounded", isGrounded);//utilisa esta misma funcion para llamar la animacion recarga usando "reload", isReload = false
        Anim.SetBool("Run", isReload); 
        // if(Input.GetKeyDown(Up)){
        //     Jump = true;
        // }
        if(Input.GetKeyDown(Special))
        {
            SpecialFunction();
        }
        else if(Input.GetKeyDown(Scape))
        {
            Application.LoadLevel("Menu");
        }
        else if(this.CanMove)
        {
            Move1();
        }
    }

    private void rotate()
    {
        transform.Rotate(0f, 180f, 0f);
    }

    public void takeDamage1(int damage){
        this.health -= damage;
        if(this.health <= 0){
            Die1();
        }
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

    void respawn(){
        this.transform.transform.position = SpawnP.position;
        this.Freeze();
    }

    public void Freeze()
    {
         // ReactiveActivate Timer
            this.Timer = new Timer(1000);
            this.Timer.Elapsed += UnFreezeTimeEvent;
            this.Timer.AutoReset = true;
            this.Timer.Enabled = true;
            
            // Disable The Special Function until the 10 seconds are over.
            this.CanMove = false;
            this.SecondsCount = this.FreezeSeconds;
    }

    public void StopReloading(System.Object source, ElapsedEventArgs e)
    {
        SecondsCount--;
        if(this.SecondsCount == 0)
        {
            this.isReload = false;
            this.Timer.Stop();
            this.Timer.Dispose();
        }
        print(SecondsCount.ToString() + " Seconds Missing"); 
    }

    
    void Die1()
    {
        if (vidas == 0)
        {
            Destroy(gameObject);
        }

        else
        {
            health=100;
            vidas-=1;
            respawn();
        }
    }

     void SpecialFunction()
    {
         print("Can Do It? " +  this.CanDoSpecialFunction.ToString());
        if(this.CanDoSpecialFunction)
        {
            // Do SpecialFunction
            // ...




            
            // ReactiveActivate Timer
            this.Timer = new Timer(1000);
            this.Timer.Elapsed += OnTimedEvent;
            this.Timer.AutoReset = true;
            this.Timer.Enabled = true;
            
            // Disable The Special Function until the 10 seconds are over.
            this.CanDoSpecialFunction = false;
            this.SecondsCount = this.SFTimeLapse;
        }
        
    }  

    private void UnFreezeTimeEvent(System.Object source, ElapsedEventArgs e)
    {
        SecondsCount--;
        if(this.SecondsCount == 0)
        {
            this.CanMove = true;
            this.Timer.Stop();
            this.Timer.Dispose();
        }
        print(SecondsCount.ToString() + " Seconds Missing"); 
    }

    private void OnTimedEvent(System.Object source, ElapsedEventArgs e)
    {
        SecondsCount--;
        if(this.SecondsCount == 0)
        {
            this.CanDoSpecialFunction = true;
            this.Timer.Stop();
            this.Timer.Dispose();
        }
        print(SecondsCount.ToString() + " Seconds Missing"); 
    }
}
 
  