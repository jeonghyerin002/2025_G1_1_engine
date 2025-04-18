using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraYFixed : MonoBehaviour
{
    public float fixedYPosition = 10f; // 고정할 Y 값

    void LateUpdate()
    {
        Vector3 currentPosition = transform.position;
        currentPosition.y = fixedYPosition;
        transform.position = currentPosition;
    }
}
