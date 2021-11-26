using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//abstract class
public abstract class EnemyFireType : MonoBehaviour
{

    protected GameObject ebc;
    public float bulletSpeed=3;

    private void Awake()
    {
        ebc = GameObject.Find("EnemyBulletContainer");
    }
    public abstract void Fire();
}
