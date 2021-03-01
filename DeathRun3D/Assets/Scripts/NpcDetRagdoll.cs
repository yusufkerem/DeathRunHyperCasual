using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcDetRagdoll : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Npc"))
        {
            if (!collision.gameObject.GetComponent<NpcAi>().alreadyRagdoll)
            {
                Debug.Log("Tetiklendi");
                collision.gameObject.GetComponent<NpcAi>().DoRagdoll();
                collision.gameObject.transform.SetParent(null);

                FindObjectOfType<GameManager>().killCount++;
            }      
        }
    }
}
