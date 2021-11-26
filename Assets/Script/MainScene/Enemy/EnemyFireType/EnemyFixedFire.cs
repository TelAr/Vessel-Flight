using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFixedFire : EnemyFireType
{

    public float angle=180;
    override public void Fire()
    {

        GameObject bullet;
        for (int k = 0; k < ebc.transform.childCount; k++)
        {

            if (!ebc.transform.GetChild(k).gameObject.activeSelf)
            {

                bullet = ebc.transform.GetChild(k).gameObject;
                bullet.transform.position = this.transform.position;
                bullet.transform.localEulerAngles = new Vector3(0, 0, angle);
                bullet.GetComponent<Bullet>().speed = bulletSpeed;
                bullet.SetActive(true);
                break;
            }
        }
    }
}
