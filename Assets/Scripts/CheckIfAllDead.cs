using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIfAllDead : MonoBehaviour
{
    public GameObject nonactivateObject;

    void Update()
    {
        if (transform.childCount <= 0)
        {
            nonactivateObject.SetActive(true);
        }
    }
}
