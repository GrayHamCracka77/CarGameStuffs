using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class AxleInfo
{
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool motor;
    public bool steering;
}

public class CarController : MonoBehaviour
{
    public List<AxleInfo> axleInfos;
    public float maxMotorTorque;
    public float maxSteeringAngle;

    public Rigidbody rb;
    public Vector3 com;

    public GameObject bulletPrefab;
    public float launcherFireRate = 0.5f;
    public Transform rocketSpawn;

    public float bulletDamage = 10f;
    public static float rocketDamage = 20f;
    public float range = 100f;
    public float gunFireRate = 15f;
    public Transform bulletSpawn;

    private float nextTimeToFire = 0f;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Debug.Log(rb.centerOfMass);
        rb.centerOfMass = com;
        Debug.Log(rb.centerOfMass);
    }

    // finds the corresponding visual wheel
    // correctly applies the transform
    public void ApplyLocalPositionToVisuals(WheelCollider collider)
    {
        if (collider.transform.childCount == 0)
        {
            return;
        }

        Transform visualWheel = collider.transform.GetChild(0);

        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);

        visualWheel.transform.position = position;
        visualWheel.transform.rotation = rotation;
    }

    public void FixedUpdate()
    {
        float motor = maxMotorTorque * Input.GetAxis("Vertical");
        float steering = maxSteeringAngle * Input.GetAxis("Horizontal");

        foreach (AxleInfo axleInfo in axleInfos)
        {
            if (axleInfo.steering)
            {
                axleInfo.leftWheel.steerAngle = steering;
                axleInfo.rightWheel.steerAngle = steering;
            }
            if (axleInfo.motor)
            {
                axleInfo.leftWheel.motorTorque = motor;
                axleInfo.rightWheel.motorTorque = motor;
            }
            ApplyLocalPositionToVisuals(axleInfo.leftWheel);
            ApplyLocalPositionToVisuals(axleInfo.rightWheel);
        }
    }

    public void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / gunFireRate;
            fireBullet();
        }

        if (Input.GetButtonDown("Fire2") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / launcherFireRate;
            fireRocket();
        }
    }

    void fireRocket()
    {
        var bullet = (GameObject)Instantiate(
                         bulletPrefab,
                         rocketSpawn.position,
//            Camera.main.transform.rotation);
                         rb.rotation);

        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 75;

        Destroy(bullet, 2.0f);
    }

    void fireBullet()
    {
        RaycastHit hit;
        if (Physics.Raycast(bulletSpawn.transform.position, bulletSpawn.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            Debug.Log(hit.transform.tag);

            if (hit.transform.tag == "Target")
            {
                hit.collider.GetComponent<Target>().TakeDamage(bulletDamage);
            }
        }
    }
}