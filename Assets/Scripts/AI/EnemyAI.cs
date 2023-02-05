using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyAI : MonoBehaviour
{
    public Transform PlayerLocation; //Get's the players location.
    private GameObject Player; //Get player.
    public float Speed = 10; //Enemy default speed.
    public float Damage = 1; //Enemy default damage.
    public float Health = 2; // Enemy default health.
    private float healthHEAT; //Delay.

    public PlayerAI PlayerScript; //Needs this to talk to PlayerAI script.


    void Start()
    {
       Player = GameObject.FindGameObjectWithTag("Player"); //When spawning, search for a game object with the tag "Player"
       PlayerScript = Player.GetComponent<PlayerAI>(); //Gets the players script.
       PlayerLocation = Player.transform; //Set the player transform as PlayerLocation.

    }
    // Update is called once per frame
    void Update()
    {
        if (healthHEAT > 0) //"Cools down" the delay.
        {
            healthHEAT -= Time.deltaTime; //Cooling down...
        }

        //get the distance between the player and enemy.
        float dist = Vector2.Distance(PlayerLocation.position, transform.position);
        //Move to player location.
        transform.position = Vector2.MoveTowards(transform.position, PlayerLocation.transform.position, Speed * Time.deltaTime);

        if(Health == 0) //When health reaches zero.
            Destroy(this.gameObject);
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (healthHEAT <= 0) //Delay between actions.
            {
                healthHEAT = 1f;  //Delay between health down..
                PlayerScript.PlayerHealth -= Damage; //Damage to player.
            }
        }

    }

}
