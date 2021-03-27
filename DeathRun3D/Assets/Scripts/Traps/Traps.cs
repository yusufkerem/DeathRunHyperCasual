﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Traps : MonoBehaviour
{
    public  Animator Anim;
    public abstract void Sthis();
    
    public int useCount = 2;
    
    void Start()
    {
        Anim = gameObject.GetComponentInChildren<Animator>();
    }
    
    
}
public class BarralTrap : Traps
{
    public override void Sthis()
    {
        
        foreach (var item in GameObject.Find("BarrellTrapGenel").GetComponentsInChildren<Animator>())
        {
            item.SetTrigger("isTriggered");
        }
        foreach (var item in GameObject.Find("BarrellTrapGenel").GetComponentsInChildren<Rigidbody>())
        {
            item.AddForce(Vector3.right * 300, ForceMode.Impulse);
        }
    }
    
}
public class SpinnerTrap : Traps
{
    public override void Sthis()
    {
        Anim.SetTrigger("isTriggered");
    }
    
}
public class Spike : Traps
{
    public override void Sthis()
    {
        Anim.SetTrigger("isTriggered");
    }
    
}
public class BoxTrap : Traps
{
    bool BoxControl=false;
    public IEnumerator BoxTrapp()
    {
        if (!BoxControl)
        {
            LeanTween.moveX(gameObject.transform.GetChild(0).gameObject, -1f, 0.2f);
            yield return new WaitForSeconds(1f);
            LeanTween.moveX(gameObject.transform.GetChild(0).gameObject, -3f, 0.2f);
        }
        BoxControl = true;
    }
    public override void Sthis()
    {
        //LeanTween.moveX(gameObject.transform.GetChild(0).gameObject, -1f, 0.2f);
        //LeanTween.moveX(gameObject.transform.GetChild(0).gameObject, -3.2f, 0.2f);
        StartCoroutine(BoxTrapp());

    }
    
}
public class SpringTrap : Traps
{
    IEnumerator SetAct()
    {
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
    }
    IEnumerator ColStatus()
    {
        yield return new  WaitForSeconds(0.1f);
        gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).GetComponent<BoxCollider>().enabled = false;
    }
    public override void Sthis()
    {
        Anim.SetTrigger("isTriggered");
        StartCoroutine(ColStatus());
        StartCoroutine(SetAct());
        //Destroy(gameObject, 2f);
        //gameObject.GetComponentInChildren<BoxCollider>().enabled = false;
    }
}
public class PiilerTrap : Traps
{
    public override void Sthis()
    {
        
        if (useCount != 0)
        {
            if (useCount == 2)
            {

                Anim.SetTrigger("isTriggered");
                gameObject.transform.Find("Usage1").gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
                useCount--;
            }
            else
            {
                Anim.SetTrigger("isTriggered");
                gameObject.transform.Find("Usage2").gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
                useCount--;
            }
        }
    }
    
}