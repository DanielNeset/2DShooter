using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{

    [Header("Team Settings")]
    [Tooltip("The team associated with this damage")]
    public int teamId = 0;

    [Header("Player")]
    public ShootingController shootingController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("HIT!");
        shootingController.SetFireRate(0.01f, 2.0f, 2.0f);
    }
}
