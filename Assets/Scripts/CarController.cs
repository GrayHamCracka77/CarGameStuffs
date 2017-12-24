using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

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
    public float range = 100f;
    public float gunFireRate = 15f;
    public Transform bulletSpawn;

    public GameObject laserEffect;

    private float nextTimeToFire = 0f;
    private LineRenderer lineRenderer;

    // Slider is 0 - 1; 1 assumed to be 100 at this point
    public Slider health;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Debug.Log(rb.centerOfMass);
        rb.centerOfMass = com;
        Debug.Log(rb.centerOfMass);

        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.enabled = false;
        health.value = 1f;
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
        if (!PauseMenu.isPaused)
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
            
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.transform.tag == "Target")
        {
            health.value -= Target.damage / 100f;
        }
    }

    void fireRocket()
    {
        var bullet = (GameObject)Instantiate(
                         bulletPrefab,
                         rocketSpawn.position,
                         rb.rotation);

        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 50;

        Destroy(bullet, 2.0f);
    }

    void fireBullet()
    {
        
        StartCoroutine(shotEffect());
        RaycastHit hit;
        if (Physics.Raycast(bulletSpawn.transform.position, bulletSpawn.transform.forward, out hit, range))
        {
            lineRenderer.SetPosition(0, bulletSpawn.transform.position); //- new Vector3(0, 0.5f, 0));
            lineRenderer.SetPosition(1, hit.point);

            // Effect will start itself and destroy itself when finished so we don't need to destroy it
            Instantiate(laserEffect, hit.point, Quaternion.AngleAxis(180f, laserEffect.transform.right));

            if (hit.transform.tag == "Target")
            {
                hit.collider.GetComponent<Target>().TakeDamage(bulletDamage);
            }
        }
    }

    private IEnumerator shotEffect()
    {
        lineRenderer.enabled = true;
        yield return new WaitForSeconds(.07f);
        lineRenderer.enabled = false;
    }

         
}