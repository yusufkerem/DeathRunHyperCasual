using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcAi : MonoBehaviour
{
    
    public float movementSpeed;
    public bool collisionStatus;
    public Animator anim;

    private void Start()
    {
        movementSpeed = Random.Range(1f, 2.2f);
    }
    void Update()
    {
        //Movement(collisionStatus);
    }

    public void Movement(bool collisionStatus)
    {
        if (!collisionStatus)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed);
            anim.SetBool("Run", true);
        }
        else
        {
            anim.SetBool("Run", false);
        }
    }
}
