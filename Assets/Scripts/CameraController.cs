using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject playerCar;

    private Vector3 offset;

    // Use this for initialization
    void Start()
    {
        offset = transform.position - playerCar.transform.position;
    }

    // LateUpdate is called once per frame at the end of movement
    void LateUpdate()
    {
        float desiredAngle = playerCar.transform.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(0, desiredAngle, 0);
        transform.position = playerCar.transform.position + (rotation * offset);
        transform.LookAt(playerCar.transform);
    }
}
