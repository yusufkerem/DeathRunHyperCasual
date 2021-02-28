using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapController : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator pillarAnim;
    public Animator spikeAnim;
    public Animator spinnerAnim;

    public GameObject pillarTrap;
    private int useCount = 2;

    public List<GameObject> trapList = new List<GameObject>();


    // Update is called once per frame
    void Update()
    {
        TrapTrigger();
    }

    void TrapTrigger()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PillarTrap();
            SpikeTrap();
            SpinnerTrap();
        }
    }

    void PillarTrap()
    {
        
        if (useCount!=0)
        {
            if (useCount==2)
            {
                pillarAnim.SetTrigger("isTriggered");
                pillarTrap.transform.Find("Usage1").gameObject.GetComponent<Renderer>().material.SetColor("_Color",Color.red);
                useCount--;
            }
            else
            {
                pillarAnim.SetTrigger("isTriggered");
                pillarTrap.transform.Find("Usage2").gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
                useCount--;
            }           
        }
        
    }

    void SpikeTrap()
    {
        spikeAnim.SetTrigger("isTriggered");
    }

    void SpinnerTrap()
    {
        spinnerAnim.SetTrigger("isTriggered");
    }
}
