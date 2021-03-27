using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Npc : MonoBehaviour
{
    public float movementSpeed;
    public bool collisionStatus;
    public Animator anim;
    public GameObject Blood;
    public Color[] colors = new Color[9];
    public Color color;
    public AudioClip[] Audios;
    public bool alreadyRagdoll = false;
    public bool finished;
    public float movementTemp;
    Rigidbody Rg;
    public abstract void StartStatus();
    public float distanceToFinish;
    private void Start()
    {
        Rg = gameObject.GetComponent<Rigidbody>();
        StartCoroutine(StStatus());
    }
    IEnumerator StStatus()
    {
        foreach (var item in GetComponentsInChildren<CharacterJoint>())
        {
            item.enableProjection = true;
            yield return null;
        }
        gameObject.transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
    }
    public void Movement(bool collisionStatus)
    {
        if (!collisionStatus && !finished && FindObjectOfType<GameManager>().start)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed);
            anim.SetBool("Run", true);
        }
        else
        {
            anim.SetBool("Run", false);
        }
    }
    public void DoRagdoll()
    {
        int index = FindObjectOfType<NpcGroupMovement>().npcList.IndexOf(gameObject);
        AudioSource.PlayClipAtPoint(Audios[0], transform.position);
        gameObject.GetComponent<NpcAi>().enabled = false;
        gameObject.GetComponentInChildren<Animator>().enabled = false;
        gameObject.transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
        alreadyRagdoll = true;
        Destroy(FindObjectOfType<NpcUi>().npcIconList[index]);
        FindObjectOfType<NpcUi>().npcIconList.Remove(FindObjectOfType<NpcUi>().npcIconList[index]);
        FindObjectOfType<NpcGroupMovement>().npcList.Remove(gameObject);
        Destroy(gameObject, 2f);



    }
    public void SpringStatus()
    {
        int index = FindObjectOfType<NpcGroupMovement>().npcList.IndexOf(gameObject);
        AudioSource.PlayClipAtPoint(Audios[0], transform.position);
        gameObject.GetComponent<NpcAi>().enabled = false;
        foreach (var item in GetComponentsInChildren<Rigidbody>())
        {
            item.velocity = Vector3.up * 20f;
        }
        
        gameObject.GetComponentInChildren<Animator>().enabled = false;
        gameObject.transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
        alreadyRagdoll = true;
        Destroy(FindObjectOfType<NpcUi>().npcIconList[index]);
        FindObjectOfType<NpcUi>().npcIconList.Remove(FindObjectOfType<NpcUi>().npcIconList[index]);
        FindObjectOfType<NpcGroupMovement>().npcList.Remove(gameObject);
        Destroy(gameObject, 2f);
        
    }
    private void Update()
    {
        if (!FindObjectOfType<GameManager>().start)
        {
            movementSpeed = 0;
            anim.SetBool("Run", false);
        }
        else
        {
            movementSpeed = movementTemp;
        }
    }
    public void DoDeath()
    {
        int index = FindObjectOfType<NpcGroupMovement>().npcList.IndexOf(gameObject);
        Debug.Log(index);
        AudioSource.PlayClipAtPoint(Audios[1], transform.position);
        GameObject NewPar = Instantiate(Blood, transform.position, transform.rotation);
        NewPar.GetComponent<ParticleSystem>().GetComponent<Renderer>().material.color = gameObject.transform.GetChild(0).transform.GetChild(1).GetComponent<Renderer>().material.color;
        Destroy(NewPar, 2f);
        Destroy(FindObjectOfType<NpcUi>().npcIconList[index]);
        FindObjectOfType<NpcUi>().npcIconList.Remove(FindObjectOfType<NpcUi>().npcIconList[index]);
        FindObjectOfType<NpcGroupMovement>().npcList.Remove(gameObject);

        Destroy(gameObject);


    }
    public Color ColorSelect()
    {
        colors[0] = Color.red;
        colors[1] = Color.green;
        colors[2] = Color.blue;
        colors[3] = Color.cyan;
        colors[4] = Color.white;
        colors[5] = Color.black;
        colors[6] = Color.yellow;
        colors[7] = Color.grey;
        colors[8] = Color.magenta;
        int ColorValue = Random.Range(0, colors.Length);

        return colors[ColorValue];

    }
    public void FindDistance()
    {
        distanceToFinish = Vector3.Distance(gameObject.transform.position, GameObject.FindGameObjectWithTag("Finish").gameObject.transform.position);
    }
}
