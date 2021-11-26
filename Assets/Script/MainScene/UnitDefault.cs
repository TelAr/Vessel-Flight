using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitDefault : MonoBehaviour
{

    public int health = 1;

    // Start is called before the first frame update
    void Awake()
    {
        if (health <= 0)
        {

            health = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (health == 0)
        {

            Object_Destroy();
        }
    }


    private void Object_Destroy()
    {

        //이후 파괴 연출 추가 시 다른 옵션으로 전환
        Destroy(this.gameObject);
    }
}
