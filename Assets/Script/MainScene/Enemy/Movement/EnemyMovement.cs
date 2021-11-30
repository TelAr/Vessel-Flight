using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyMovement : MonoBehaviour
{
    public float speed = 1;
    public abstract void FixedUpdate();
    private void Awake()
    {
        speed = gameObject.GetComponent<EnemyDefault>().movementSpeed;
    }

}
