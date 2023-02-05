using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    //Metriä sekunnissa
    public float Speed = 30f;
    public float VerticalInput;
    public float HorizontalInput;

    public GameObject WeaponTest;

    // Update is called once per frame
    void Update()
    {
        //Menee oikeel ja vasemmal ja ylösalas

        VerticalInput = Input.GetAxis("Vertical");
        transform.position += transform.forward * Speed * Time.deltaTime * VerticalInput;

        HorizontalInput = Input.GetAxis("Horizontal");
        transform.position += transform.right * Speed * Time.deltaTime * HorizontalInput;

    }
}
