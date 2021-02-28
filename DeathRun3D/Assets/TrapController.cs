using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapController : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator pillarAnim;
    

    // Update is called once per frame
    void Update()
    {
        TrapTrigger();
    }

    void TrapTrigger()
    {
        if (Input.GetMouseButtonDown(0))
        {
            pillarAnim.SetTrigger("isTriggered");
        }
    }
}
