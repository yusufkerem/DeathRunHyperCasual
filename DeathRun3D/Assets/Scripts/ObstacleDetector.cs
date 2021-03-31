using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDetector : MonoBehaviour
{
    private NpcAi npc;
    private void Start()
    {
        npc = gameObject.transform.parent.gameObject.GetComponent<NpcAi>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "obstacle")
        {
            npc.collisionStatus = true;
        }
        //else
        //{
        //    npc.collisionStatus = false;
        //}
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "obstacle")
    //    {
    //        npc.collisionStatus = true;
    //    }
    //}
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "obstacle")
        {
            npc.collisionStatus = false;
        }
    }

}
