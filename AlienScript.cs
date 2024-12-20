using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlienScript : MonoBehaviour
{
    public Animator anim;
    public Animator alert;
    public OrbScript orbScript;
    public PlayerScript playerScript;
    public GameObject alienOrb;
    public GameObject healthBar;
    public Text wonText;
    public Text scoreText;
    public Text highScoreText;
    public Rigidbody2D myrb;
    public float health = 100;
    public float timer = 0;
    public float countdown = 16;
    public float score = 0;
    public float highScore;
    

    void Start()
    {
        anim = GetComponent<Animator>();
        highScore = PlayerPrefs.GetFloat("highScore");
    }

    void Update()
    {
        if (timer < countdown)
        {
            timer += Time.deltaTime;
            
        }
        else
        {
            OrbSpawn();
            
        }
    }

    void OrbSpawn()
    {
        for (int i = 0; i < 5; i++)
        {
            var orbInstance = Instantiate(alienOrb, new Vector2(8, Random.Range(-4, 4)), transform.rotation);
            Debug.Log(timer);
            timer = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Orb") && orbScript.charged == true)
        {
            AlienHealth(1);
            score += 30;
            //Debug.Log(health);
            anim.Play("AlienHit");
            /*for(int i = 0; i < 5; i++)
            {
                var orbInstance = Instantiate(alienOrb, new Vector2(8, Random.Range(-4, 4)), transform.rotation);
            }*/
            
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "ShipProj")
        {
            AlienHealth(.05f);
            score += 5;
        }

    }



    public float AlienHealth(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            score -= Time.deltaTime;
            score *= playerScript.health;
            scoreText.text = $"Score: {score.ToString("0")}";
            if(score > PlayerPrefs.GetFloat("highScore"))
            {
                highScore = score;
                PlayerPrefs.SetFloat("highScore", highScore);
                highScoreText.text = $"High Score: {highScore.ToString("0")}";
            }
            else
            {
                highScoreText.text = $"High Score: {highScore.ToString("0")}";
            }
            
            wonText.gameObject.SetActive(true);
            Destroy(gameObject);
            health = 0;
        }
        Vector3 temp = healthBar.transform.localScale;
        temp.x = health;
        healthBar.transform.localScale = temp;
        orbScript.charged = false;
        orbScript.animeOrb.SetTrigger("TrOrb");
        return health;
    }

    void Destroy()
    {
        Destroy(this.gameObject);
    }
}
