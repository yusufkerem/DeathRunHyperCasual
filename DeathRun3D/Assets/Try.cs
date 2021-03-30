using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSG.MeshAnimator;
public class Try : MonoBehaviour
{
    MeshAnimator Anim;
    private void Start()
    {
        Anim=GetComponent<MeshAnimator>();
        Anim.Play("Shuffling");
    }
}
