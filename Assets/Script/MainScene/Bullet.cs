using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : UnitDefault
{

    public float speed = 10f;


    private void OnTriggerEnter(Collider collider) {

        if (this.CompareTag("Respawn")&&collider.CompareTag("Enemy")) {

            if (collider.GetComponent<FlightUnit>() != null) {
                collider.GetComponent<FlightUnit>().Damage(1);
            }
            Object_Disable();
        }

        if (this.CompareTag("Enemy_Bullet") && collider.CompareTag("Player"))
        {

            if (collider.GetComponent<FlightUnit>() != null)
            {
                collider.GetComponent<FlightUnit>().Damage(1);
            }
            Object_Disable();
        }

    }



    // Update is called once per frame
    new void FixedUpdate()
    {
        base.FixedUpdate();
        transform.Translate(new Vector3(0, 1)*speed*Time.deltaTime);
    }


}
