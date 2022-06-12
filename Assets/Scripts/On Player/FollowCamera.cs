using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Vector3 cameraOffset;

    void Start()
    {
        cameraOffset = transform.position - Camera.main.transform.position;
    }

    void Update()
    {
        Camera.main.transform.position = transform.position - cameraOffset;
    }
}
