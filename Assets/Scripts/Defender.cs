using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    #region Stats
    public float curHealth = 175;
    public float maxHealth = 175;
    public float movement = 40;
    #endregion

    #region grenade
    public GameObject grenadePrefab;
    public Transform grenadeSpawn;
    public float grenadeSpeed = 30;
    public float lifeTime = 3;
    #endregion
    #region Cooldowns
    public float altFireCD = 5f;
    private float nextAltFireTime = 0;
    private float nextPowerTime = 0;
    public float powerCD = 20f;
    #endregion
    #region Power
    public float pushRadius = 5;
    public float pushForce = 100;
    #endregion



    private void Update()
    {
        if (Time.time > nextAltFireTime)
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                AltFire();
                nextAltFireTime = Time.time + altFireCD;
            }
        }

        if (Time.time > nextPowerTime)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Power();
                nextPowerTime = Time.time + powerCD;
            }
        }

        //Passive?

       
    }

    private void AltFire()
    {
        GameObject grenade = Instantiate(grenadePrefab);

        Physics.IgnoreCollision(grenade.GetComponent<Collider>(),
            grenadeSpawn.parent.GetComponent<Collider>());

        grenade.transform.position = grenadeSpawn.position;

        Vector3 rotation = grenade.transform.rotation.eulerAngles;

        grenade.transform.rotation = Quaternion.Euler(rotation.x, transform.eulerAngles.y, rotation.z);

        grenade.GetComponent<Rigidbody>().AddForce(grenadeSpawn.forward * grenadeSpeed, ForceMode.Impulse);

        StartCoroutine(DestroyMissileAfterTime(grenade, lifeTime));
    }

    private void Power()
    {
        foreach (Collider collider in Physics.OverlapSphere(gameObject.transform.position, pushRadius))
        {
            Debug.Log(collider);
            // calculate direction from target to me
            Vector3 forceDirection = gameObject.transform.position - collider.transform.position;

            // apply force on target towards me
            collider.GetComponent<Rigidbody>().AddForce(forceDirection.normalized * pushForce * Time.deltaTime);


        }
    }

    private IEnumerator DestroyMissileAfterTime(GameObject grenade, float delay)
    {
        yield return new WaitForSeconds(delay);

        Destroy(grenade);
    }
}
