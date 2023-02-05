using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float BulletDamage = 1; //Bullet's default damage.
    public GameObject Enemy; //Get enemy.
    public EnemyAI EnemyScript;//Get enemy script.


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
        Enemy = collision.gameObject;
        EnemyScript = Enemy.GetComponent<EnemyAI>(); //Gets the enemy's script.
        EnemyScript.Health -= BulletDamage;
        Destroy(this.gameObject);
        }

    }


}
