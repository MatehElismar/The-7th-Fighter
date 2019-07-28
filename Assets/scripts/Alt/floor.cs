using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floor : MonoBehaviour
{
    private Player1Control player;

    public
    // Start is called before the first frame update
    void Start()
    {
        player= GetComponentInParent<Player1Control>();
    }

    void OnCollisionStay2D(Collision2D col){
        if(col.gameObject.tag == "ground" ){
            player.isGrounded = true;
        }
        

    }

    
    void OnCollisionExit2D(Collision2D col){
         if(col.gameObject.tag == "ground" ){
            player.isGrounded = false;
         }
    }



}
