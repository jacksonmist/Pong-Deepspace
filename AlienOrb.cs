using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienOrb : MonoBehaviour
{
    public Rigidbody2D myrb;
    public GameObject alienOrb;

    void Start()
    {
        int speedX = Random.Range(3, 10);
        int speedY = Random.Range(-2, 2);
        myrb.velocity = alienOrb.GetComponent<Rigidbody2D>().velocity;
        myrb.velocity = new Vector2(-speedX, speedY);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }

    }

    void Update()
    {
        if (transform.position.x < -11)
        {
            Destroy(gameObject);
        }

    }  
}
