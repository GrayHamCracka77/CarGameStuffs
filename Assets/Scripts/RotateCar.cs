using UnityEngine;

public class RotateCar : MonoBehaviour
{
    public GameObject carRoot;
    public float speedH = 5.0f;
    public float speedV = 5.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            yaw -= speedH * Input.GetAxis("Mouse X");
            pitch += speedV * Input.GetAxis("Mouse Y");

            carRoot.transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        }

    }
}
