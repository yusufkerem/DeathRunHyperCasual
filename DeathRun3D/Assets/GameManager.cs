using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using YsoCorp.GameUtils;

public class GameManager : MonoBehaviour
{
    
    public int killCount;
    public GameObject winUi;
    public GameObject failUi;
    public bool start = false;
    public GameObject mainMenu;
    public GameObject bar;
    public int lvlIndex = 1;
    public GameObject lvl1;
    public GameObject lvl2;
    int ComplateCount;
    private void Awake()
    {
        ComplateCount = NpcGroupMovement.Instance.npcList.Count;
        GameStart();
    }
    void Update()
    {
        WinControl();
    }

    void WinControl()
    {
        if (killCount >=ComplateCount)
        {
            LevelCompleted();
        }
    }

    void LevelCompleted()
    {
        Debug.Log("YOU WON");
        GameFinish(true);
        winUi.SetActive(true);
        //Camera.main.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        winUi.transform.Find("bg").gameObject.transform.GetChild(0).gameObject.GetComponent<Image>().fillAmount += 1 * 0.5f * Time.deltaTime; 

    }

    public void LevelFailed()
    {
        // Level Failed, Npc Dances
        Debug.Log("GAME OVER");
        failUi.SetActive(true);

    }

    public void StartLevel()
    {
        start = true;
        mainMenu.SetActive(false);
        bar.SetActive(true);
        
    }
    void GameStart()
    {
        YCManager.instance.OnGameStarted(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void GameFinish(bool win)
    {
        YCManager.instance.OnGameFinished(win);
    }


}
