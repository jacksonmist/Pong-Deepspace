using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    public Animator animeField;


    void Start()
    {
        animeField = GetComponent<Animator>();
       
    }

    
    void Update()
    {
        
    }

    public void FieldHit()
    {
        animeField.Play("Forcefield");
    }
}

