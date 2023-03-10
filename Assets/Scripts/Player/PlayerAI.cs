using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerAI : MonoBehaviour
{
    public float PlayerHealth = 5; //Player health.
    public float DelayBetweenLoss = 2; //The delay between health losses.
    private float healthHEAT; //Delays cooldown.
                

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (healthHEAT > 0) //"Cools down" the delay.
        {
            healthHEAT -= Time.deltaTime; //Cooling down...
        }
        if (PlayerHealth <= 0) //If the player's health gets to zero, it dies.
        {
        SceneManager.LoadScene(0);
            Restart();
            Destroy(this.gameObject);
        }
    }
    public IEnumerator Restart()
    {
        yield return new WaitForSeconds(2f);
        
    }

}


