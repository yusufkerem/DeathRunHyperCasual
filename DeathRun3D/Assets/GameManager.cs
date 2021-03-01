using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int killCount;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        WinControl();
    }

    void WinControl()
    {
        if (killCount == FindObjectOfType<NpcGroupMovement>().npcList.Count)
        {
            LevelCompleted();
        }
    }

    void LevelCompleted()
    {
        Debug.Log("YOU WON");
    }

    public void LevelFailed()
    {
        // Level Failed, Npc Dances
        Debug.Log("GAME OVER");

    }
}
