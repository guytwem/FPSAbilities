using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravGrenade : MonoBehaviour
{
    public float pullRadius = 100;
    public float pullForce = 100;

   
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("hit " + other.name + "!");
        foreach (Collider collider in Physics.OverlapSphere(other.transform.position, pullRadius))
        {
            Debug.Log(collider);
            // calculate direction from target to me
            Vector3 forceDirection = gameObject.transform.position - collider.transform.position;

            // apply force on target towards me
            collider.GetComponent<Rigidbody>().AddForce(forceDirection.normalized * pullForce * Time.deltaTime);

            
        }
        Destroy(gameObject);
    }
}
