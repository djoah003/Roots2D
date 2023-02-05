using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class WeaponMoverScript : MonoBehaviour
{
    public Camera MainCamera;
   
    void Update()
    {
        Ray ray = MainCamera.ScreenPointToRay(Input.mousePosition);

        Vector3 mousePos = Input.mousePosition; //ota x ja z

            var projectionPos = ray.GetPoint(10);
        Vector3 lookPos = projectionPos;

       

        transform.LookAt( new Vector3(projectionPos.x, transform.position.y, projectionPos.z));
        Debug.Log(lookPos);
    }
  //  transform.rotation = new Vector3(transform.rotation.x, Target.rotation.y, transform.rotation.z);
   // transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, Target.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
}
