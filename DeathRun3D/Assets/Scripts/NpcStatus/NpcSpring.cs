using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcSpring : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Npc"))
        {
            if (!collision.gameObject.GetComponent<NpcAi>().alreadyRagdoll)
            {
                Debug.Log("Tetiklendi");
                //collision.gameObject.GetComponent<NpcAi>().SpringStatus();
                collision.gameObject.transform.SetParent(null);

                FindObjectOfType<GameManager>().killCount++;
            }
        }
    }
}
