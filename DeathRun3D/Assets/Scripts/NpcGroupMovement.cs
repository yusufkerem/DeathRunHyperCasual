using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class NpcGroupMovement : MonoBehaviour
{
    public List<GameObject> npcList = new List<GameObject>();

    private void Awake()
    {
        foreach (Transform npc in gameObject.transform)
        {
            npcList.Add(npc.gameObject);
        }
    }
    void Update()
    {
        foreach (Transform npc in gameObject.transform)
        {
            npc.gameObject.GetComponent<NpcAi>().Movement(npc.gameObject.GetComponent<NpcAi>().collisionStatus);
        }   
    }
}
