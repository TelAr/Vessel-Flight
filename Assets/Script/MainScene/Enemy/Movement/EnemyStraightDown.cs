using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStraightDown : EnemyMovement
{

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(speed);
    }

    // Update is called once per frame
    public override void FixedUpdate()
    {
        gameObject.transform.Translate(new Vector3(0, -1, 0) * speed * Time.deltaTime, Space.World);
    }
}
