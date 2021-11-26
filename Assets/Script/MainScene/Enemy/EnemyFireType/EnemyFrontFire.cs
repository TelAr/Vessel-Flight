using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFrontFire : EnemyFireType
{

    override public void Fire() {

        GameObject bullet;
        for (int k = 0; k < ebc.transform.childCount; k++) {

            if (!ebc.transform.GetChild(k).gameObject.activeSelf) {

                bullet = ebc.transform.GetChild(k).gameObject;
                bullet.transform.position = this.transform.position;
                bullet.transform.localEulerAngles = this.transform.localEulerAngles;
                bullet.GetComponent<Bullet>().speed = bulletSpeed;
                bullet.SetActive(true);
                break;
            }
        }
    }
}
