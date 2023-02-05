using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{

    public Rigidbody2D Enemy = null; //Enemy (e.g Bug), that we want the spawner to spawn.
    public int WaveEnemyAmount = 0, AmbushEnemyAmount = 0; //Tells the amount of spawned enemies currently on the map.
    public float WaveCount = 10, AmbushCount = 5; //Changeable amount of enemies. 10 is default.
    public float EnemyMultiplier = 1; //Multiplies the enemy spawn amount.
    public float EnemyIncrement = 0; //Adds to the EnemyMultiplier after each wave.
    public float x_pos, y_pos; //Modifiable float, that can change the spawn distance from the spawn centre.
    public float y; //Set default.
    public float SecondsDelay_Wave = 60, SecodsDelay_Ambush = 20;
    private Vector2 SpawnerPos;

    public float timer; //Debug timer.


    // Start is called before the first frame update
    void Start()
    {
        SpawnerPos = this.gameObject.transform.position; //Shortening...
        StartCoroutine("SpawnEnemyTimer"); //Call coroutine on start. (Start spawning)
    }

    void Update()
    {
        timer += 1 * Time.deltaTime;

    }

    public IEnumerator SpawnEnemyTimer()
    {
        timer = 0;
        yield return new WaitForSeconds(SecodsDelay_Ambush); //Delay before wave.

        while (true) //Forever loop
        {
            print("Ambush started");
            while (AmbushEnemyAmount < AmbushCount * EnemyMultiplier) //Ambush; Spawn ambush before wave.
            {
                InstantiateEnemy();
                AmbushEnemyAmount += 1;
                yield return new WaitForSeconds(1.0f); //Delay for if functions.
            }

            print("Ambush stopped & Wave started");

            timer = 0;
            yield return new WaitForSeconds(SecondsDelay_Wave); //Delay for next Ambush.

            while (WaveEnemyAmount < WaveCount * EnemyMultiplier) //Wave; Spawn wave after ambush.
            {
                InstantiateEnemy();
                WaveEnemyAmount += 1; //Adds +1 to the amount of bugs on the map
                yield return new WaitForSeconds(1.0f); //Delay for if functions.
            }

            print("Wave stopped"); //Notify when coroutine has stopped.
            WaveEnemyAmount = 0; AmbushEnemyAmount = 0; //Resets the counters.
            EnemyMultiplier += EnemyIncrement;

            timer = 0;
            yield return new WaitForSeconds(SecodsDelay_Ambush); //Delay before wave.

            //yield break; //Stop spawning.
        }
    }

    private void InstantiateEnemy()
    {
        //Randombly spawns enemy within a set area. The area is set with x_pos & z_pos as offsets from the spawners centre. 
        Instantiate(Enemy, new Vector2(Random.Range(SpawnerPos.x-x_pos, SpawnerPos.x + x_pos), Random.Range(SpawnerPos.y - y_pos, SpawnerPos.y + y_pos)), this.gameObject.transform.rotation);
    }
}
