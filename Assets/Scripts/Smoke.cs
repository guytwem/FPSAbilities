using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smoke : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("hit " + other.name + "!");
        //smoke
        Destroy(gameObject);
    }
}
