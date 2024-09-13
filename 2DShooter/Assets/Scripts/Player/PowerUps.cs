using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{

    [Header("Team Settings")]
    [Tooltip("The team associated with this damage")]
    public int teamId = 0;

    [Header("Power up duration")]
    public float duration = 5f;

    [Header("Rapid Fire Settings")]
    public bool rapidFire = true;
    public float fireRate = 0.01f;
    public float spread = 2f;

    [Header("Speed Settings")]
    public bool speed = false;
    public float movementSpeed = 20f;
    public float rotationSpeed = 120f;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        PowerUpPlayer(collision.gameObject);
    }

    private void PowerUpPlayer(GameObject collisionGameObject)
    {
        Health collidedHealth = collisionGameObject.GetComponent<Health>();
        if (collidedHealth != null)
        {
            if (rapidFire)
            {
                ShootingController shootingController = collisionGameObject.GetComponent<ShootingController>();
                if (shootingController != null)
                {
                    shootingController.SetFireRate(fireRate, spread, duration);
                    Destroy(gameObject);
                }
            }
            else if (speed)
            {
                Controller controller = collisionGameObject.GetComponent<Controller>();
                if (controller != null)
                {
                    controller.SetPowerupSpeed(movementSpeed, rotationSpeed, duration);
                    Destroy(gameObject);
                }
            }
            else
            {
                Destroy(gameObject);
            }

        }
    }
}
