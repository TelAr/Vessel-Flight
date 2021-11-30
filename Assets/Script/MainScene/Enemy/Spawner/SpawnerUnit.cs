using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerUnit : MonoBehaviour
{
    private EnemyStraightDown sd = new EnemyStraightDown();

    private float last_x, last_y;
    private float last_rotation;
    private EnemyMovement last_movement;
    private float last_moveSpeed;
    private float last_sd, last_fd, last_bs;
    private bool before_spawn = false;

    // Start is called before the first frame update
    void Awake()
    {
        for (int t = 0; t < gameObject.transform.childCount; t++)
        {

            gameObject.transform.GetChild(t).gameObject.SetActive(false);
        }

        //for default setting
        Spawn(0, 20, 180, sd, 2f, 0.5f, 0.5f, 3);
    }

    // Update is called once per frame


    //Spwan �Լ� ��� ��
    //�ݵ�� �Լ� ����(Spawn(float x, float y, float rotation, EnemyMovement movement, float moveSpeed, EnemyFireType fireType, float startDelay, float fireDelay, float bulletSpeed))
    //���� ��� �� �ϴ��� �Ķ���� ������ �� �����ε� �Լ��� ����� ��
    //������ ������ ��� Spawn�� �ȵ� �� ����
    //�������� ���� ������ ���ؼ��� �ֱ� ����� ������ ������ �״�� ������
    //���� �߻縦 ���� �ʴ� ���̽��� ���ؼ��� fireType�� NO_fire �־�� �����ؾ� ��
    //rotation=180=>look at down
    //Spawn overload functions
    public void Spawn()
    {

        if (before_spawn)
        {

            Spawn(last_x, last_y, last_rotation, last_movement, last_moveSpeed, last_sd, last_fd, last_bs);
        }
    }

    public void Spawn(float x, float y)
    {

        if (before_spawn)
        {

            Spawn(x, y, last_rotation, last_movement, last_moveSpeed, last_sd, last_fd, last_bs);
        }
    }

    public void Spawn(float x, float y, float rotation)
    {

        if (before_spawn)
        {

            Spawn(x, y, rotation, last_movement, last_moveSpeed, last_sd, last_fd, last_bs);
        }
    }

    public void Spawn(float x, float y, float rotation, EnemyMovement movement, float moveSpeed)
    {

        if (before_spawn)
        {

            Spawn(x, y, rotation, movement, moveSpeed, last_sd, last_fd, last_bs);
        }
    }

    public void Spawn(float x, float y, float rotation, float startDelay, float fireDelay, float bulletSpeed)
    {

        if (before_spawn)
        {

            Spawn(x, y, rotation, last_movement, last_moveSpeed, startDelay, fireDelay, bulletSpeed);
        }
    }

    public void Spawn(float x, float y, float rotation, EnemyMovement movement, float moveSpeed, float startDelay, float fireDelay, float bulletSpeed)
    {

        for (int t = 0; t < gameObject.transform.childCount; t++)
        {
            GameObject enemy = gameObject.transform.GetChild(t).gameObject;
            if (!enemy.activeSelf)
            {

                enemy.transform.position = new Vector3(x, y);
                enemy.transform.localEulerAngles = new Vector3(0, 0, rotation);
                enemy.GetComponent<EnemyDefault>().movementSpeed = moveSpeed;
                Destroy(enemy.GetComponent<EnemyMovement>());
                enemy.AddComponent(movement.GetType());

                enemy.GetComponent<EnemyDefault>().start_delay = startDelay;
                enemy.GetComponent<EnemyDefault>().fire_delay = fireDelay;
                enemy.GetComponent<EnemyDefault>().bullet_speed = bulletSpeed;
                enemy.GetComponent<EnemyDefault>().ReAwake();

                last_x = x;
                last_y = y;
                last_rotation = rotation;
                last_movement = movement;
                last_moveSpeed = moveSpeed;
                last_sd = startDelay;
                last_fd = fireDelay;
                last_bs = bulletSpeed;

                before_spawn = true;
                break;
            }
        }
    }
}
