using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {

    private Transform bar;
    public GameObject Player;
    public float Health = 1f;

    private void Start () { 
         this.Health = this.Player.GetComponent<Player1Control>().health ;
         float health = this.Health / 100;
            if (health > 1f) {
                health -= 10f;
                this.SetSize(health);

                if (health < 30f) {
                    // Under 30% health
                    if ((int)(health * 100f) % 3 == 0) {
                        this.SetColor(Color.white);
                    } else {
                        this.SetColor(Color.red);
                    }
                }
            } else {
                health = 100f;
                this.SetColor(Color.red);
            } 
	}

    private void Update()
    { 
         this.Health = this.Player.GetComponent<Player1Control>().health;
         print("updating THAT SHIT");
        float health = this.Health / 100;
        this.SetSize(health);
        if (health < 30f) {
            // Under 30% health
            if ((int)(health * 100f) % 3 == 0) {
                this.SetColor(Color.white);
            } else {
                this.SetColor(Color.red);
            }
        }
        else {
            health = 100f;
            this.SetColor(Color.red);
        }
    }

	private void Awake () {
        bar = transform.Find("Bar");
	}

    public void SetSize(float sizeNormalized) {
        bar.localScale = new Vector3(sizeNormalized, 1f);
    }

    public void SetColor(Color color) {
        bar.Find("BarSprite").GetComponent<SpriteRenderer>().color = color;
    }
}
