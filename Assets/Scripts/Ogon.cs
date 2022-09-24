using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ogon : MonoBehaviour
{
    public GameObject ObjectWithParticleSystem;
    private GameObject cloned;
    public Transform muzzle; //дуло, точка вылета

    private void Start()
    {
        ObjectWithParticleSystem.GetComponent<ParticleSystem>().Stop();
    }

    private void FixedUpdate()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shot();
        }
    }

    private void Shot()
    {
        cloned = Instantiate(ObjectWithParticleSystem, muzzle.position, muzzle.rotation);
        cloned.GetComponent<ParticleSystem>().Play();
        Destroy(gameObject, GetComponent<ParticleSystem>().duration);
    }
}
