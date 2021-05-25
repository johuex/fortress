using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ogon : MonoBehaviour
{
    public ParticleSystem dim;

    private void Start()
    {
        dim = GetComponent<ParticleSystem>();
        dim.Stop();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shot();
        }
    }

    private void Shot()
    {
        dim.Play();

    }
}
