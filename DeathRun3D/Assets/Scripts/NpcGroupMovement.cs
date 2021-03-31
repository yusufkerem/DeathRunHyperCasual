using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class NpcGroupMovement : MonoBehaviour
{
    public List<GameObject> npcList = new List<GameObject>();
    public List<float> npcDist = new List<float>();
    public List<GameObject> Traps = new List<GameObject>();
    public GameObject firstPlaceNpc;
    public static NpcGroupMovement Instance { get; private set; }
    GameObject Ref;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(Instance);
        }
        foreach (Transform npc in gameObject.transform)
        {
            npcList.Add(npc.gameObject);
        }
        foreach (var item in GameObject.FindGameObjectsWithTag("Trap"))
        {
            Traps.Add(item);
        }
    }
    
    void Update()
    {
        //Npcs movements
        NpcMove();
        FindFirstPlaceNpc();
        TrapSelector();
        //try
        //{
            
        //}
        //catch 
        //{

            
        //}
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
        if (npcDist!=null)
        {
            try
            {
                float firstDistance = npcDist.Min();
                firstPlaceNpc = npcList[npcDist.IndexOf(firstDistance)];
                npcDist.Clear();
            }
            catch 
            {

                
            }
        }
        
    }
    public GameObject TrapSelector()
    {
        
        float ekb = Vector3.Distance(firstPlaceNpc.transform.forward, Traps[0].transform.position);
        
        for (int i = 0; i < Traps.Count; i++)
        {
            
            if (Vector3.Distance(firstPlaceNpc.transform.position, Traps[i].transform.position)<ekb)
            {
                
                ekb = Vector3.Distance(firstPlaceNpc.transform.position, Traps[i].transform.position);
                Ref = Traps[i].gameObject;
                //Debug.Log(ekb);
                //if (Vector3.Distance(firstPlaceNpc.transform.position, Traps[i].transform.position) <= 3.6f)
                //{
                //    Traps.Remove(Traps[i]);

                //}
                
                
            }


        }
        //Debug.Log(Ref.name);
        return Ref;


    }
    void NpcMove()
    {
        foreach (Transform npc in gameObject.transform)
        {
            npc.gameObject.GetComponent<NpcAi>().Movement(npc.gameObject.GetComponent<NpcAi>().collisionStatus);
        }
        //Npc distance to finish calculation
        foreach (Transform npc in gameObject.transform)
        {
            npc.gameObject.GetComponent<NpcAi>().FindDistance();
        }
    }
}
