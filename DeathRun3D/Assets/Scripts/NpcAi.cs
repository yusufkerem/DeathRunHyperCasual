using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcAi : MonoBehaviour
{
    
    public float movementSpeed;
    public bool collisionStatus;
    public Animator anim;
    public GameObject Blood;
    Color[] colors = new Color[9];
    Color color;
    public AudioClip[] Audios;
    public bool alreadyRagdoll = false;
    public bool finished;
    public float movementTemp;

    public float distanceToFinish;
    
    private void Start()
    {
        movementSpeed = Random.Range(1.3f, 2.4f);
        movementTemp = movementSpeed;
        color = ColorSelect();
        gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).GetComponent<Renderer>().material.color = color;
        StartCoroutine(StStatus());
        //movementSpeed = 0f;
        
    }
    void Update()
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
        //Movement(collisionStatus);
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
        AudioSource.PlayClipAtPoint(Audios[0], transform.position);
        gameObject.GetComponent<NpcAi>().enabled = false;
        gameObject.GetComponentInChildren<Animator>().enabled = false;
        gameObject.transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
        alreadyRagdoll = true;
        FindObjectOfType<NpcGroupMovement>().npcList.Remove(gameObject);
    }
    public void DoDeath()
    {
        AudioSource.PlayClipAtPoint(Audios[1], transform.position);
        GameObject NewPar = Instantiate(Blood, transform.position, transform.rotation);
        NewPar.GetComponent<ParticleSystem>().GetComponent<Renderer>().material.color = gameObject.transform.GetChild(0).transform.GetChild(1).GetComponent<Renderer>().material.color;
        Destroy(NewPar, 2f);
        FindObjectOfType<NpcGroupMovement>().npcList.Remove(gameObject);
        Destroy(gameObject);
    }
    Color ColorSelect()
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
    IEnumerator StStatus()
    {
        foreach (var item in GetComponentsInChildren<CharacterJoint>())
        {
            item.enableProjection = true;
            yield return null;
        }
        gameObject.transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
    }

    public void FindDistance()
    {
        distanceToFinish = Vector3.Distance(gameObject.transform.position, GameObject.FindGameObjectWithTag("Finish").gameObject.transform.position);
    }
    
}
