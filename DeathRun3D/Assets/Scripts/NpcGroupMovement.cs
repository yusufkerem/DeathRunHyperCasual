using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class NpcGroupMovement : MonoBehaviour
{
     // Update is called once per frame
    void Update()
    {
        foreach (Transform npc in gameObject.transform)
        {
            npc.gameObject.GetComponent<NpcAi>().Movement(npc.gameObject.GetComponent<NpcAi>().collisionStatus);
        }   
    }
}
