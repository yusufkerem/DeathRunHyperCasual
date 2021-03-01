using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDetec : MonoBehaviour
{
    Camera Cam;
    int Sayac;
    void Start()
    {
        Cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        StartCoroutine(Traps());
    }

    // Update is called once per frame
    void Update()
    {
        //Traps();
    }
    IEnumerator Traps()
    {

        while (true)
        {
            if (Input.touchCount > 0)
            {

                Touch Finger = Input.GetTouch(0);
                RaycastHit touchedObject;
                if (Physics.Raycast(Cam.ScreenPointToRay(Finger.position), out touchedObject))
                {
                    if (touchedObject.collider.gameObject.CompareTag("TrapPiller"))
                    {
                        
                        Debug.Log(touchedObject.collider.name);
                        
                        touchedObject.point = new Vector3(0, 0, 0);
                        
                        FindObjectOfType<TrapController>().PillarTrap();
                        yield return new WaitForSeconds(1f);
                        






                        yield return null;
                        
                    }
                    yield return null;
                    if (touchedObject.collider.gameObject.name == "SpinnerTrap")
                    {
                        FindObjectOfType<TrapController>().SpinnerTrap();
                        yield return null;
                    }
                    if (touchedObject.collider.gameObject.name == "DikenliGulle360" || touchedObject.collider.gameObject.name == "GullePlatform (2)")
                    {
                        FindObjectOfType<TrapController>().SpikeTrap();
                        yield return null;
                    }
                    yield return null;
                }
                yield return null;
            }
            yield return null;
        }
    }
    }
    //void Traps()
    //{
    //}
    

