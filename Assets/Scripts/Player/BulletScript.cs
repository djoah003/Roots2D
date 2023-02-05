using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float BulletDamage = 1; //Bullet's default damage.
    public GameObject Enemy; //Get enemy.
    public EnemyAI EnemyScript;//Get enemy script.

    private void Start()
    {
        Destroy(gameObject, 2f);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
        Enemy = col.gameObject;
        EnemyScript = Enemy.GetComponent<EnemyAI>(); //Gets the enemy's script.
        EnemyScript.Health -= BulletDamage;
        Destroy(this.gameObject);
        }
    }


}
