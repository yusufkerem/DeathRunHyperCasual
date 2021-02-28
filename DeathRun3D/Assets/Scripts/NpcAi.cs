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
    
    private void Start()
    {
        movementSpeed = Random.Range(1f, 2.2f);
        color = ColorSelect();
        gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).GetComponent<Renderer>().material.color = color;
        StartCoroutine(StStatus());
        
    }
    void Update()
    {
        //Movement(collisionStatus);
    }

    public void Movement(bool collisionStatus)
    {
        if (!collisionStatus)
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
        gameObject.GetComponent<NpcAi>().enabled = false;
        gameObject.GetComponentInChildren<Animator>().enabled = false;
        gameObject.transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
    }
    public void DoDeath()
    {
        GameObject NewPar = Instantiate(Blood, transform.position, transform.rotation);
        NewPar.GetComponent<ParticleSystem>().GetComponent<Renderer>().material.color = gameObject.transform.GetChild(0).transform.GetChild(1).GetComponent<Renderer>().material.color;
        Destroy(NewPar, 2f);
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
    
}
