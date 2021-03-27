using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndControl : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Npc"))
        {
            FindObjectOfType<GameManager>().LevelFailed();
            other.gameObject.GetComponent<NpcAi>().finished = true;
            other.gameObject.GetComponent<NpcAi>().anim.SetBool("Run", false);
            other.gameObject.GetComponent<NpcAi>().anim.SetTrigger("Dance");
        }
    }
}
