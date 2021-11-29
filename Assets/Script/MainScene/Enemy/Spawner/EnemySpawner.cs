using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    private float timer=0;
    private float global_timer = 0;//for phase

    private EnemyStraightDown sd=new EnemyStraightDown();
    private EnemyFrontFire ff=new EnemyFrontFire();
    private EnemyTargettingFire tf = new EnemyTargettingFire();
    private EnemyNoFire NO_fire=new EnemyNoFire();


    private float last_x, last_y;
    private float last_rotation;
    private EnemyMovement last_movement;
    private float last_moveSpeed;
    private EnemyFireType last_fireType;
    private float last_sd, last_fd, last_bs;
    private bool before_spawn = false;
    
    // Start is called before the first frame update
    void Awake()
    {
        for (int t = 0; t < gameObject.transform.childCount; t++) {

            gameObject.transform.GetChild(t).gameObject.SetActive(false);
        }
        //for default setting
        Spawn(0, 20, 180, sd, 2f, NO_fire, 0.5f, 0.5f, 3);
    }

    // Update is called once per frame
    //rotation=180=>look at down
    void FixedUpdate()
    {
        timer += Time.deltaTime;
        global_timer += Time.deltaTime;
        if (global_timer < 11f)
        { //first phase

            if (timer > 1f)
            {
                Spawn(-12 + global_timer * 2, 10);
                timer = 0;
            }
        }
        else if (global_timer < 22f)
        { //second phase


            if (timer > 1f)
            {
                Spawn(12 - (global_timer - 11) * 2, 10);
                timer = 0;
            }
        }
        else if (global_timer < 43f) {//third phase

            last_moveSpeed = 1.5f;
            if (timer > 2f) {
                if (global_timer < 41f)
                {
                    Spawn((global_timer-22)/2, 10, last_rotation, ff, 1f, 1f, 3);
                    Spawn(-(global_timer - 22) / 2, 10, last_rotation, ff, 1f, 1f, 3);
                }
                else {

                    Spawn(4, 10, last_rotation, tf, 3f, 0.5f, 3);
                    Spawn(-4, 10, last_rotation, tf, 3f, 0.5f, 3);
                }
                timer = 0;
            }
        }
        else//return first
        {
            last_fireType = NO_fire;
            global_timer = 0;
            timer = 0;
        }

    }

    //Spwan 함수 사용 시
    //반드시 함수 원형(Spawn(float x, float y, float rotation, EnemyMovement movement, float moveSpeed, EnemyFireType fireType, float startDelay, float fireDelay, float bulletSpeed))
    //먼저 사용 후 하단의 파라미터 생략이 된 오버로드 함수를 사용할 것
    //서순이 엇나갈 경우 Spawn이 안될 수 있음
    //기입하지 않은 변수에 대해서는 최근 사용한 마지막 변수값 그대로 대응함
    //만약 발사를 하지 않는 케이스에 대해서는 fireType에 NO_fire 넣어서라도 구현해야 함

    //Spawn overload functions
    void Spawn() {

        if (before_spawn) {

            Spawn(last_x, last_y, last_rotation, last_movement, last_moveSpeed, last_fireType, last_sd, last_fd, last_bs);
        }
    }

    void Spawn(float x, float y) {

        if (before_spawn) {

            Spawn(x, y, last_rotation, last_movement, last_moveSpeed, last_fireType, last_sd, last_fd, last_bs);
        }
    }

    void Spawn(float x, float y, float rotation)
    {

        if (before_spawn)
        {

            Spawn(x, y, rotation, last_movement, last_moveSpeed, last_fireType, last_sd, last_fd, last_bs);
        }
    }

    void Spawn(float x, float y, float rotation, EnemyMovement movement, float moveSpeed) {

        if (before_spawn)
        {

            Spawn(x, y, rotation, movement, moveSpeed, last_fireType, last_sd, last_fd, last_bs);
        }
    }

    void Spawn(float x, float y, float rotation, EnemyFireType fireType, float startDelay, float fireDelay, float bulletSpeed)
    {

        if (before_spawn)
        {

            Spawn(x, y, rotation, last_movement, last_moveSpeed, fireType, startDelay, fireDelay, bulletSpeed);
        }
    }

    void Spawn(float x, float y, float rotation, EnemyMovement movement, float moveSpeed, EnemyFireType fireType, float startDelay, float fireDelay, float bulletSpeed) {

        Debug.Log("respawn");
        for (int t = 0; t < gameObject.transform.childCount; t++)
        {
            GameObject enemy = gameObject.transform.GetChild(t).gameObject;
            if (!enemy.activeSelf) {

                enemy.transform.position = new Vector3(x, y);
                enemy.transform.localEulerAngles = new Vector3(0, 0, rotation);
                enemy.GetComponent<EnemyDefault>().movementSpeed = moveSpeed;
                Destroy(enemy.GetComponent<EnemyMovement>());
                enemy.AddComponent(movement.GetType());

                Destroy(enemy.GetComponent<EnemyFireType>());

                enemy.AddComponent(fireType.GetType());
                enemy.GetComponent<EnemyDefault>().start_delay = startDelay;
                enemy.GetComponent<EnemyDefault>().fire_delay = fireDelay;
                enemy.GetComponent<EnemyDefault>().bullet_speed = bulletSpeed;
                enemy.GetComponent<EnemyDefault>().ReAwake();

                last_x = x;
                last_y = y;
                last_rotation = rotation;
                last_movement = movement;
                last_moveSpeed = moveSpeed;
                last_fireType = fireType;
                last_sd = startDelay;
                last_fd = fireDelay;
                last_bs = bulletSpeed;

                before_spawn = true;
                break;
            }
        }
    }
}
