using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameContoller : MonoBehaviour
{
    static public int score;
    static public int life=3;

    public GameObject player;


    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!player.gameObject.activeSelf) {

            timer += Time.deltaTime;
            if (timer > 2f) {

                if (life > 0)
                {
                    Debug.Log(life);
                    Debug.Log(score);
                    life--;
                    player.transform.position = new Vector3(0, -3f);
                    player.GetComponent<PlayerFlightUnit>().ReAwake();
                }
                else { 
                
                    //game over event;
                }
                timer = 0;
            }
        }
    }
}
