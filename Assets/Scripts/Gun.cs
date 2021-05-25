using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bulletPref;
    public Transform muzzle; //дуло, точка вылета

    public float power = 50f;

    private GameObject bullet;

    private void Start()
    {
   
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shot();
        }
    }

    private void Shot ()
    {
        bullet = Instantiate(bulletPref, muzzle.position, muzzle.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * power, ForceMode.Impulse);
        Destroy(bullet, 10f);
    }

}
