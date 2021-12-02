using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainGameContoller : MonoBehaviour
{
    static public int score;
    static public int life=3;

    public GameObject player;

    private AudioSource AudioSource;
    private bool is_die;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        AudioSource = this.gameObject.GetComponent<AudioSource>();
        score = 0;
        timer = 0;
        is_die = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!player.gameObject.activeSelf) {
            if (!is_die) {
                AudioSource.Play();
                is_die = true;
            }
            timer += Time.deltaTime;
            if (timer > 2f) {

                if (life > 0)
                {
                    Debug.Log(life);
                    Debug.Log(score);
                    life--;
                    player.transform.position = new Vector3(0, -3f);
                    player.GetComponent<PlayerFlightUnit>().ReAwake();
                    is_die = false;
                }
                else {

                    SceneManager.LoadScene("GameOver");
                }
                timer = 0;
            }
        }
    }
}
