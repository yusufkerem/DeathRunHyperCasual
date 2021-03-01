using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    
    public Transform target;

    public float smoothSpeed = .1f;

    public Vector3 offset;

    //public Vector3 offset2 = new Vector3(0.51f, 1.59f, 1.92f);
    
    void LateUpdate()
    {

        target = FindObjectOfType<NpcGroupMovement>().firstPlaceNpc.transform;
        if (target.gameObject.GetComponent<NpcAi>().finished)
        {
            Vector3 desiredFinishPosition =  new Vector3(-1.83f, 2.41f, 28.72f);
            Vector3 smoothedFinishPosition = Vector3.Lerp(transform.position, desiredFinishPosition, smoothSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(transform.rotation.x, -180, transform.rotation.z);
            transform.position = smoothedFinishPosition;
        }
        else
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
            transform.position = smoothedPosition;
        }
        
    }
}
