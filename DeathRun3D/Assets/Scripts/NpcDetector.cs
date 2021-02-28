using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcDetector : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Npc"))
        {
            Debug.Log("Tetiklendi");
            collision.gameObject.GetComponent<NpcAi>().DoDeath();
        }
    }
    
    // Update is called once per frame

}
