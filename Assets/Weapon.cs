using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{ 
    public GameObject bulletPrefab;
    public KeyCode FireKey;
    // Start is called before the first frame update
    void Start()
    {
        FireKey = gameObject.transform.parent.gameObject.GetComponent<Player1Control>().Fire;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(FireKey))//Pressed Once
        {
            shoot();
        }
    }

    void shoot()
    {
        Instantiate(bulletPrefab, this.transform.position, this.transform.rotation);
    }
}
