using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbScript : MonoBehaviour
{
    public AnimationScript forceField;
    public Animator animeOrb;
    public Rigidbody2D myrb;
    public GameObject field;
    public GameObject player;
    public float speed;
    public bool charged = false;
    void Start()
    {
        myrb.velocity = new Vector2(speed, speed);
        animeOrb = GetComponent<Animator>();
    }

    void Update()
    {

    }

    /*public void BallCheck()
    {
        if(player != null)
        {
            if (transform.position.x < field.transform.position.x + 1)
            {
               Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            }
        }
        
    }*/

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player") && transform.position.x > field.transform.position.x + 1)
        {
            charged = true;
            animeOrb.SetTrigger("TrOrbCharged");
            forceField.FieldHit();
            myrb.velocity = new Vector2(speed, speed);
        }
        

    }

    public bool ChargeOrb()
    {
        if(charged)
        {
            return charged;
        }
        return false;
    }

}
