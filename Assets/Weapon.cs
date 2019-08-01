
using System.Timers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{ 
    private int Nb;
    private Player1Control player;
    public GameObject bulletPrefab;
    public KeyCode FireKey;
    public KeyCode ReloadKey;
    private Animator Anim;

    public AudioClip CockSound;
    public AudioClip GunSound;
    public AudioClip ReloadingSound;
    private AudioSource Audio;
    // Start is called before the first frame update

    void Play(AudioClip clip)
    {
        this.Audio.clip = clip;
        this.Audio.Play();
    }
    void Start()
    {
        this.Audio = GetComponent<AudioSource>();
        Anim = gameObject.transform.parent.gameObject.GetComponent<Player1Control>().GetComponent<Animator>();
        FireKey = gameObject.transform.parent.gameObject.GetComponent<Player1Control>().Fire;
        ReloadKey = gameObject.transform.parent.gameObject.GetComponent<Player1Control>().Reload;
        player= GetComponentInParent<Player1Control>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(FireKey))//Pressed Once
        {
            shoot();
        }

        if (Input.GetKeyDown(ReloadKey))//Pressed Once
        {
            reloaded();
        }
    }

    void shoot()
    {
        if (player.Tambor > 0 )
        {
            Play(GunSound);
            player.Tambor -= 1; 
            Instantiate(bulletPrefab, this.transform.position, this.transform.rotation);
            Debug.Log(player.Tambor);    
            Nb=player.Tambor;        
        }
        else{
            Play(CockSound);
        }

        //Instantiate(bulletPrefab, this.transform.position, this.transform.rotation);
    }

    void reloaded(){
        
       if (player.Ammo > 0)
       {
            if (player.Tambor == 0 || player.Tambor== Nb && player.Ammo > 0)
            {
              
                reload();
            }
       }
        
        else if (player.Tambor ==0 && player.Ammo == 0)
        {
            Debug.Log("No se puede usar el arma");
        };
    }

     public void reload()
    {
         // ReactiveActivate Timer
            this.player.Timer = new Timer(1000);
            this.player.Timer.Elapsed += StopReloading;
            this.player.Timer.AutoReset = true;
            this.player.Timer.Enabled = true;
            
            // start reload
             player.isReload = true; 
            Play(ReloadingSound);
            this.player.SecondsCount = this.player.secondsToReload;
    }

    public void StopReloading(System.Object source, ElapsedEventArgs e)
    {
        this.player.SecondsCount--;
        if(this.player.SecondsCount == 0)
        {
            // complete reload
           
            this.player.isReload = false;
            player.Tambor += (6-Nb);
            player.Ammo -= (6-Nb);
            Debug.Log(player.Ammo);
            this.player.Timer.Stop();
            this.player.Timer.Dispose();
        }
        print(this.player.SecondsCount.ToString() + " Seconds Missing"); 
    }
}
