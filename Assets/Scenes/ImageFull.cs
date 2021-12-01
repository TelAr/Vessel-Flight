using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageFull : MonoBehaviour
{


    private void Awake()
    {
        if (gameObject.GetComponent<RectTransform>() != null)
        {
            gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2 (Screen.width, Screen.height);



        }
    }
}
