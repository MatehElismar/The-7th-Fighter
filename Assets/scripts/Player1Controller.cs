using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Controller : MonoBehaviour
{
    public float speed{get; set;}
    public float jump{ get; set; }

    public float hola = 10; 
    // Start is called before the first frame update
    void Start()
    {
        this.speed = 15;
        this.jump = 10;
        print("Starting");
    }

    // Update is called once per frame
    void Update()
    {
        float hInput = Input.GetAxis("Horizontal");
        this.transform.position += new Vector3(hInput * speed * Time.deltaTime, 0, 0);

        float vInput = Input.GetAxis("Vertical");
        this.transform.position += new Vector3(0, vInput * jump * Time.deltaTime, 0);
    }
}
