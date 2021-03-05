using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapController : MonoBehaviour
{
    public Animator pillarAnim;
    public Animator spikeAnim;
    public Animator spinnerAnim;
    public Animator barrelAnim;
    public GameObject boxTrap;

    public GameObject pillarTrap;
    private int useCount = 2;

    public List<GameObject> trapList = new List<GameObject>();


    void Update()
    {
        TrapTrigger();
    }

    void TrapTrigger()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //
            if (FindObjectOfType<NpcGroupMovement>().TrapSelector().name== "PillarTrapParent")
            {
                PillarTrap();
            }
            else if (FindObjectOfType<NpcGroupMovement>().TrapSelector().name == "BarrellTrapGenel")
            {
                BarrelTrap();
            }
            else if (FindObjectOfType<NpcGroupMovement>().TrapSelector().name == "Spinner")
            {
                SpinnerTrap();
                
            }

            //SpikeTrap();

            StartCoroutine("BoxTrapp");
        }
    }

    public void PillarTrap()
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

    public void SpikeTrap()
    {
        spikeAnim.SetTrigger("isTriggered");
    }

    public void SpinnerTrap()
    {
        spinnerAnim.SetTrigger("isTriggered");
    }

    public void BarrelTrap()
    {
        foreach (var item in GameObject.Find("BarrellTrapGenel").GetComponentsInChildren<Animator>())
        {
            item.SetTrigger("isTriggered");
        }
        foreach (var item in GameObject.Find("BarrellTrapGenel").GetComponentsInChildren<Rigidbody>())
        {
            item.AddForce(Vector3.right * 300, ForceMode.Impulse);
        }
        //barrelAnim.SetTrigger("isTriggered");
        //barrelAnim.gameObject.transform.parent.Find("varil").GetComponent<Rigidbody>().AddForce(Vector3.right * 300, ForceMode.Impulse);
        //barrelAnim.gameObject.transform.parent.parent.Find("BarrelTrap").transform.GetChild(0).gameObject.GetComponent<Animator>().SetTrigger("isTriggered");
        //barrelAnim.gameObject.transform.parent.parent.Find("BarrelTrap").Find("varil2").GetComponent<Rigidbody>().AddForce(Vector3.right * 300, ForceMode.Impulse);

    }

    public void BoxTrap()
    {
        LeanTween.moveX(boxTrap, -1f, 0.2f);
    }
    public IEnumerator BoxTrapp()
    {
        LeanTween.moveX(boxTrap, -1f, 0.2f);
        yield return new WaitForSeconds(1f);
        LeanTween.moveX(boxTrap, -3f, 0.2f);
    }
}
