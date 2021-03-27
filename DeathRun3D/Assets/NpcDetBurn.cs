using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcDetBurn : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Npc"))
        {
            if (!collision.gameObject.GetComponent<NpcAi>().alreadyRagdoll)
            {
                Debug.Log("Tetiklendi");
                StartCoroutine(collision.gameObject.GetComponent<NpcAi>().Burn());
                
                
                FindObjectOfType<GameManager>().killCount++;
            }
        }
    }
}
