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
    public GameObject pyroTrap;
    public GameObject spikeTrap;
    bool BoxControl = false;
    bool pyroControl = false;
    public GameObject pillarTrap;
    private int useCount = 2;
    Coroutine Ref;
    public List<GameObject> trapList = new List<GameObject>();
    public GameObject pyroParticle;
    public GameObject button;


    void Update()
    {
        TrapTrigger();
    }

    void TrapTrigger()
    {
        if (Input.GetMouseButtonDown(0) && FindObjectOfType<GameManager>().start)
        {
            //
            StartCoroutine(buttonPress());
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
            else if (FindObjectOfType<NpcGroupMovement>().TrapSelector().name == "BoxTrap")
            {
                Ref=StartCoroutine("BoxTrapp");
                
            }
            else if (FindObjectOfType<NpcGroupMovement>().TrapSelector().name == "SpikeBall")
            {
                SpikeTrap();
            }
            else if (FindObjectOfType<NpcGroupMovement>().TrapSelector().name == "PyroTrap")
            {
                Ref = StartCoroutine("PyroTrap");
            }

        }

        //if (pyroTrap!=null)
        //{
        //    if (Input.GetMouseButton(0) && FindObjectOfType<GameManager>().start)
        //    {
        //        if (FindObjectOfType<NpcGroupMovement>().TrapSelector().name == "PyroTrap")
        //        {
        //            PyroTrap();
        //        }
        //    }
        //    else
        //    {
        //        pyroTrap.GetComponent<BoxCollider>().enabled = false;
        //        pyroParticle.GetComponent<ParticleSystem>().Stop();
        //    }
        //}
        
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
                //pillarTrap.GetComponent<Outline>().enabled = false;
            }           
        }
        
    }

    public void SpikeTrap()
    {
        spikeAnim.SetTrigger("isTriggered");
        //spikeTrap.GetComponent<Outline>().enabled = false;
    }

    public void SpinnerTrap()
    {
        spinnerAnim.SetTrigger("isTriggered");
        //gameObject.GetComponent<Outline>().enabled = false;
    }

    public void BarrelTrap()
    {
        GameObject.Find("BarrellTrapGenel").transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
        GameObject.Find("BarrellTrapGenel").transform.GetChild(1).transform.GetChild(0).gameObject.SetActive(false);

        foreach (var item in GameObject.Find("BarrellTrapGenel").GetComponentsInChildren<Rigidbody>())
        {
            item.AddForce(Vector3.right * 350, ForceMode.Impulse);
        }
        //gameObject.GetComponent<Outline>().enabled = false;
        //barrelAnim.SetTrigger("isTriggered");
        //barrelAnim.gameObject.transform.parent.Find("varil").GetComponent<Rigidbody>().AddForce(Vector3.right * 300, ForceMode.Impulse);
        //barrelAnim.gameObject.transform.parent.parent.Find("BarrelTrap").transform.GetChild(0).gameObject.GetComponent<Animator>().SetTrigger("isTriggered");
        //barrelAnim.gameObject.transform.parent.parent.Find("BarrelTrap").Find("varil2").GetComponent<Rigidbody>().AddForce(Vector3.right * 300, ForceMode.Impulse);

    }

    public void BoxTrap()
    {
        LeanTween.moveX(boxTrap, -1f, 0.2f);
        //gameObject.GetComponent<Outline>().enabled = false;
    }
    public IEnumerator BoxTrapp()
    {
        if (!BoxControl)
        {
            LeanTween.moveX(boxTrap, -1f, 0.2f);
            yield return new WaitForSeconds(1f);
            LeanTween.moveX(boxTrap, -3f, 0.2f);
        }
        BoxControl = true;
    }
    public IEnumerator PyroTrap()
    {
        
        if (!pyroControl)
        {
            pyroTrap.GetComponent<BoxCollider>().enabled = true;
            pyroParticle.GetComponent<ParticleSystem>().Play();
            AudioSource.PlayClipAtPoint(FindObjectOfType<AudioController>().Audios[0], transform.position);
            yield return new WaitForSeconds(0.2f);
            pyroTrap.GetComponent<BoxCollider>().enabled = false;
            pyroParticle.GetComponent<ParticleSystem>().Stop();
            pyroControl = true;
            //gameObject.GetComponent<Outline>().enabled = false;
        }

    }
    public IEnumerator buttonPress()
    {
        LeanTween.moveLocalY(button, 0.2f, 0.3f).setEaseInOutCirc();
        yield return new WaitForSeconds(.2f);
        LeanTween.moveLocalY(button, 0.282f, 0.3f).setEaseInOutCirc();
    }
}
