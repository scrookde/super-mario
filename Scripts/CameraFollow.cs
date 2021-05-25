using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 cameraOffset;

    void Update()
    {
        transform.position = new Vector3(player.position.x + cameraOffset.x, cameraOffset.y, cameraOffset.z);
    }
}
