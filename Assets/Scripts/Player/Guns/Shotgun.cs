using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour
{
    public GameObject Bullet; //Bullet, that we want to shoot.
                              // public Rigidbody Bulletrb; //Bullet's rigidbody.
    public GameObject GunBarrel; //Gun, from where we want the bullets to be shot from.
    private Vector3 GunBarrelPos; //Setup for transform ---> Vector 3
    private float GunHeat;

    void Start()
    {

    }

    void Update()
    {

        if (GunHeat > 0) //"Cools down" the delay.
        {
            GunHeat -= Time.deltaTime; //Cooling down...
        }

        if (Input.GetKeyDown("space"))
        {
            if (GunHeat <= 0) //Delay between actions.
            {
                GunHeat = 0.5f;  //Delay between health down..
                GunBarrelPos = GunBarrel.transform.position;
                for(int Shot = 0; Shot <= 6; Shot++)
                Shoot();

            }
        }

    }


    void Shoot()
    {
        GameObject ShotBullet = Instantiate(Bullet, GunBarrelPos, transform.rotation);
        ShotBullet.GetComponent<Rigidbody>().AddForce(transform.forward * 1000);
    }

}
