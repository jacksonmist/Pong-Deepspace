using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
public class PlayerScript : MonoBehaviour
{
    public Animator anim;
    public Rigidbody2D myrb;
    public AlienScript alienScript;
    public OrbScript orb;
    public Text scoreText;
    public Text highScoreText;
    
    public GameObject alienOrb;
    public GameObject shipHealth1;
    public GameObject shipHealth2;
    public GameObject shipHealth3;
    public GameObject forceField;
    public GameObject shipProj;

    public float projDelay = 0;
    public float projRate = .1f;
    public Text lossText;
    public float speed;
    public int health = 3;

    void Start()
    {
        anim = GetComponent<Animator>();
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "AlienOrb")
        {
            health -= 1;
        }
        
    }

    void Update()
    {
        myrb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, Input.GetAxisRaw("Vertical") * speed);
        Thrusters();
        if(health == 2)
        {
            shipHealth3.SetActive(false);
        }
        if (health == 1)
        {
            shipHealth2.SetActive(false);
            shipHealth3.SetActive(false);
        }
        if (health <= 0)
        {
            shipHealth1.SetActive(false);
            shipHealth2.SetActive(false);
            shipHealth3.SetActive(false);
            forceField.SetActive(false);           
            scoreText.text = $"Score: {alienScript.score.ToString("0")}";
            if (alienScript.score <= 0)
            {
                scoreText.text = "Bro you are god awful";
            }
            highScoreText.text = $"High Score: {alienScript.highScore.ToString("0")}";
            lossText.gameObject.SetActive(true);
            anim.Play("Explode");
            
        }

        ShipShoot();
        
        if(alienScript.timer > 12 && alienScript.timer < 17)
        {
            anim.Play("Alert");
        }
    }

    public void ShipShoot()
    {
        if (transform.position.x > 4.5)
        {
            projDelay += Time.deltaTime;
            if(projDelay > projRate)
            {
                var projInstance = Instantiate(shipProj, new Vector2(transform.position.x, transform.position.y), transform.rotation);
                projDelay = 0;
            }
            
        }
    }


    public void Thrusters()
    {
        if (myrb.velocity.y > 1)
        {
            anim.Play("RightThrust");
        }
        if (myrb.velocity.y < -1)
        {
            anim.Play("LeftThrust");
        }
    }

    void Destroy()
    {
        Destroy(this.gameObject);
    }
}
