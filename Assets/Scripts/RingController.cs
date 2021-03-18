using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingController : MonoBehaviour
{
    private float force = 0.35f;
    [SerializeField]
    private Vector3 dir;

    public GameObject rayCastObjectToShootFrom;
    private Vector3 rayOriginObjectPosition;
    private Rigidbody myRigidbody;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Bubbles"))
        {
            CastRay();
            if(force < 2f)
                force += 0.005f;
        }
    }   

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bubbles"))
        {
            CastRay();
            force = 0.35f;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Bubbles"))
        {
            force = 0.35f;
        }
    }

    private void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        rayOriginObjectPosition = rayCastObjectToShootFrom.transform.position;
    }

    public void CastRay()
    {
        //laserLine.SetPosition(0, transform.position);
        Vector3 dir = (rayOriginObjectPosition - transform.position).normalized;
        //Debug.DrawLine(transform.position, transform.position + dir * 100, Color.red, Mathf.Infinity);
        
        if (Physics.Raycast(transform.position, dir))
        {
            //laserLine.SetPosition(1, raycastHit.point);

            myRigidbody.AddForce(-dir * force);
        }

    }
}
