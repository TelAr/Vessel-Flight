using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitDefault : MonoBehaviour
{


    public GameObject DestroyAnimation;
    // Start is called before the first frame update


    // Update is called once per frame
    protected void FixedUpdate()
    {


        if (Mathf.Abs(transform.position.y) > 12)
        {

            gameObject.SetActive(false);
        }
        if (Mathf.Abs(transform.position.x) > 15)
        {

            gameObject.SetActive(false);
        }
    }


    protected void Object_Disable()
    {
        if (DestroyAnimation != null) {
            Instantiate(DestroyAnimation, this.transform.position, Quaternion.identity);
        }
        //���� �ı� ���� �߰� �� �ٸ� �ɼ����� ��ȯ
        this.gameObject.SetActive(false);
    }
}
