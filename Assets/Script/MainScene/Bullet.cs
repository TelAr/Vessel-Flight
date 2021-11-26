using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider collider) {

        if (this.CompareTag("Respawn")&&collider.CompareTag("Enemy")) {

            if (collider.GetComponent<UnitDefault>() != null) {
                collider.GetComponent<UnitDefault>().health--;
            }
            Bullet_destroy();
        }

        if (this.CompareTag("Enemy_Bullet") && collider.CompareTag("Player"))
        {

            if (collider.GetComponent<UnitDefault>() != null)
            {
                collider.GetComponent<UnitDefault>().health--;
            }
            Bullet_destroy();
        }

    }


    void Bullet_destroy() {

        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(new Vector3(0, 1)*speed*Time.deltaTime);

        if (Mathf.Abs(transform.position.y) > 10) {

            gameObject.SetActive(false);
        }
        if (Mathf.Abs(transform.position.x) > 12)
        {

            gameObject.SetActive(false);
        }
    }


}
