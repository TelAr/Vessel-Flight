using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTargettingFire : EnemyFireType
{

    GameObject player;
    Vector3 targetVector;
    public override void Fire()
    {
        GameObject bullet;

        for (int k = 0; k < ebc.transform.childCount; k++)
        {

            if (!ebc.transform.GetChild(k).gameObject.activeSelf)
            {

                bullet = ebc.transform.GetChild(k).gameObject;
                bullet.transform.position = this.transform.position;
                if (player != null) {
                    targetVector = player.transform.position - this.transform.position;
                }

                if (targetVector.y < 0)
                {
                    bullet.transform.localEulerAngles = new Vector3(0, 0, 180 - Mathf.Rad2Deg * Mathf.Atan(targetVector.x / targetVector.y));
                }
                else {

                    bullet.transform.localEulerAngles = new Vector3(0, 0, 360 - Mathf.Rad2Deg * Mathf.Atan(targetVector.x / targetVector.y));
                }
                Debug.Log(bullet.transform.localEulerAngles);
                bullet.GetComponent<Bullet>().speed = bulletSpeed;
                bullet.SetActive(true);
                break;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

}
