using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcAi : MonoBehaviour
{
    // Start is called before the first frame update
    public float movementSpeed;
    public bool collisionStatus;
    public Animator anim;

    // Update is called once per frame
    private void Start()
    {
        movementSpeed = Random.Range(1f, 2.2f);
    }
    void Update()
    {
        Movement(collisionStatus);
    }

    void Movement(bool collisionStatus)
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
