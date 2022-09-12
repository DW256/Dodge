using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    Transform player;
    Transform head;

    public Transform spawnArea;
    public int shoot_interval_min;
    public int shoot_interval_max;
    public float projectile_speed;
    public int max_projectile;
    public int projectile_lifespan;
    public GameObject projectile_base;

    private float timer;
    private int shoot_interval;
    private List<GameObject> projectileList;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        head = this.gameObject.transform;
        timer = 0;
        shoot_interval = Random.Range(shoot_interval_min, shoot_interval_max);
        projectileList = new List<GameObject>();
    }

    void Update()
    {
        head.LookAt(new Vector3(player.position.x, this.gameObject.transform.position.y, player.position.z));

        timer += Time.deltaTime;

        if (timer > shoot_interval)
        {
            timer -= shoot_interval;
            shoot();
            shoot_interval = Random.Range(shoot_interval_min, shoot_interval_max);
        }

    }

    private void shoot()
    {
        if (projectileList.Count >= max_projectile) return;

        GameObject projectile = Instantiate(projectile_base, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z), Quaternion.identity, spawnArea);
        projectile.SetActive(true);
        projectile.GetComponent<Rigidbody>().AddForce(transform.forward * projectile_speed);
        projectileList.Add(projectile);
    }

    public void removeProjectile(GameObject projectile)
    {
        projectileList.Remove(projectile);
        Destroy(projectile);
    }
}
