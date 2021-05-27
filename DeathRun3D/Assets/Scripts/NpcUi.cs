using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NpcUi : MonoBehaviour
{
    public List<GameObject> npcIconList = new List<GameObject>();
    void Start()
    {
        npcİconAdd();
    }

    
    void Update()
    {
        //UpdateIconPositions();
    }
    public void npcİconAdd()
    {
        foreach (Transform icon in gameObject.transform)
        {
            npcIconList.Add(icon.gameObject);
        }

        for (int i = 0; i < npcIconList.Count; i++)
        {
            npcIconList[i].GetComponent<Image>().color = FindObjectOfType<NpcGroupMovement>().npcList[i].transform.GetChild(0).GetChild(1).gameObject.GetComponent<Renderer>().material.GetColor("_Color");  //Optimize this
        }
    }
    //void UpdateIconPositions()
    //{
    //    //foreach (GameObject icon in npcIconList)
    //    //{

    //    //}
        
    //    for (int i = 0; i < npcIconList.Count; i++)
    //    {
    //        //if (FindObjectOfType<NpcGroupMovement>().npcList[i] == null)
    //        //{
    //        //    Destroy(FindObjectOfType<NpcGroupMovement>().npcList[i]);
    //        //}
    //        if (npcIconList[i]!=null)
    //        {
    //            npcIconList[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(FindObjectOfType<NpcGroupMovement>().npcList[i].transform.position.z * 12.2f * 1.5f - 150, npcIconList[i].GetComponent<RectTransform>().anchoredPosition.y);
    //        }
            
    //    }
    //}
}
