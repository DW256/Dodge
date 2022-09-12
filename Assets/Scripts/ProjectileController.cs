using StarterAssets;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    private TurretController Turret;

    private Vector3 directionForce;
    private float timer;
    private int lifeSpan;

    // Start is called before the first frame update
    void Start()
    {
        Turret = this.gameObject.GetComponentInParent<TurretController>();
        lifeSpan = Turret.projectile_lifespan;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > lifeSpan)
        {
            Debug.Log("1 PU is gone.");
            Turret.removeProjectile(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            directionForce = new Vector3(this.gameObject.transform.position.x, 0, this.gameObject.transform.position.z).normalized;
            ThirdPersonController kb = collision.gameObject.GetComponent<ThirdPersonController>();
            kb.addKnockback(directionForce);
        }

    }
}
