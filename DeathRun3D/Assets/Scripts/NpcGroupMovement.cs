using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class NpcGroupMovement : MonoBehaviour
{
    public List<GameObject> npcList = new List<GameObject>();
    public List<float> npcDist = new List<float>();
    public GameObject firstPlaceNpc;
    private void Awake()
    {
        foreach (Transform npc in gameObject.transform)
        {
            npcList.Add(npc.gameObject);
        }
    }
    void Update()
    {
        //Npcs movements
        foreach (Transform npc in gameObject.transform)
        {
            npc.gameObject.GetComponent<NpcAi>().Movement(npc.gameObject.GetComponent<NpcAi>().collisionStatus);
        }
        //Npc distance to finish calculation
        foreach (Transform npc in gameObject.transform)
        {
            npc.gameObject.GetComponent<NpcAi>().FindDistance();
        }

        FindFirstPlaceNpc();
    }

    void FindFirstPlaceNpc()
    {
        foreach (GameObject npc in npcList)
        {
            if (npc!=null)
            {
                npcDist.Add(npc.gameObject.GetComponent<NpcAi>().distanceToFinish);
            }
        }
        float firstDistance = npcDist.Min();
        firstPlaceNpc = npcList[npcDist.IndexOf(firstDistance)];
        npcDist.Clear();
    }
}
