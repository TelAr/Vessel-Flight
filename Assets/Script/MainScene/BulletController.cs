using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    GameObject[] bullets;

    public GameObject player;
    public float bulletSpeed = 20;

    // Start is called before the first frame update
    void Awake()
    {
        bullets = new GameObject[gameObject.transform.childCount];
        for (int k = 0; k < gameObject.transform.childCount; k++) {

            bullets[k] = gameObject.transform.GetChild(k).gameObject;
            bullets[k].SetActive(false);
        }
    }

    public void Fire() {

        for (int k = 0; k < gameObject.transform.childCount; k++)
        {
            if (!bullets[k].activeSelf) {
                bullets[k].transform.position = player.transform.position;
                bullets[k].GetComponent<Bullet>().speed = bulletSpeed;
                bullets[k].SetActive(true);
                return;
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {


    }
}
