using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class uiController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject tapToPlay;
    public GameObject Level2;
    void Start()
    {
        TapToPlay();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TapToPlay()
    {
        LeanTween.scale(tapToPlay, new Vector3(3, 3, 3), 0.5f).setLoopPingPong();
    }

    public void Retry()
    {
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
    }

    public void NextLvl()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        //GameObject.Find("Level1").SetActive(false);
        //Level2.SetActive(true);
        //FindObjectOfType<NpcUi>().npcİconAdd();
    }
}
