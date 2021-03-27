using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcAi : Npc
{
    private void Start()
    {

        //movementSpeed = 0f;
        StartStatus();
    }
    public override void StartStatus()
    {
        movementSpeed = Random.Range(1.5f, 2.6f);
        movementTemp = movementSpeed;
        color = ColorSelect();
        gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).GetComponent<Renderer>().material.color = color;
    }

    
    

    
    
    
    
    

    
    
}
