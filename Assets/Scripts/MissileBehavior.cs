using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileBehavior : MonoBehaviour
{
  

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("hit " + other.name + "!");

        Destroy(gameObject);
    }
}
