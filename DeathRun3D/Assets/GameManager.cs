using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    
    public int killCount;
    public GameObject winUi;
    public GameObject failUi;
    void Start()
    {
        
    }

    
    void Update()
    {
        WinControl();
    }

    void WinControl()
    {
        if (killCount >= 6)
        {
            LevelCompleted();
        }
    }

    void LevelCompleted()
    {
        Debug.Log("YOU WON");
        winUi.SetActive(true);
        Camera.main.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        winUi.transform.Find("bg").gameObject.transform.GetChild(0).gameObject.GetComponent<Image>().fillAmount += 1 * 0.5f * Time.deltaTime;   
        
    }

    public void LevelFailed()
    {
        // Level Failed, Npc Dances
        Debug.Log("GAME OVER");
        failUi.SetActive(true);

    }
}
