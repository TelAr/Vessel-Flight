using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerMain : MonoBehaviour
{
    public SpawnerUnit normalEnemy, fixedFireEnemy, targettingFireEnemy;


    private float timer;
    private float global_timer;
    private float last_moveSpeed;
    private float last_rotation;
    // Start is called before the first frame update
    void Start()
    {
        last_moveSpeed = 2f;
        last_rotation = 180f;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime;
        global_timer += Time.deltaTime;
        if (global_timer < 11f)
        { //first phase

            if (timer > 1f)
            {
                normalEnemy.Spawn(-12 + global_timer * 2, 10);
                timer = 0;
            }
        }
        else if (global_timer < 22f)
        { //second phase


            if (timer > 1f)
            {
                normalEnemy.Spawn(12 - (global_timer - 11) * 2, 10);
                timer = 0;
            }
        }
        else if (global_timer < 43f)
        {//third phase
            last_moveSpeed = 1.5f;
            if (timer > 2f)
            {
                if (global_timer < 41f)
                {
                    fixedFireEnemy.Spawn((global_timer - 22) / 2, 10, 0, 1f, 1f, 4);
                    fixedFireEnemy.Spawn(-(global_timer - 22) / 2, 10, 0, 1f, 1f, 4);
                }
                else
                {
                    last_rotation = 180;
                    targettingFireEnemy.Spawn(4, 10, last_rotation, 3f, 0.5f, 3);
                    targettingFireEnemy.Spawn(-4, 10, last_rotation, 3f, 0.5f, 3);
                }
                timer = 0;
            }
        }
        else//return first
        {
            last_moveSpeed = 2f;
            global_timer = 0;
            timer = 0;
        }
    }
}
