using UnityEngine;
using System.Collections;

public class EnemyShoot : MonoBehaviour {

    public GameObject enemyShot;
    public Transform enemyShotSpawner;
    public float enemyBulletSpeed;

    public AudioClip laserSound;


    public float enemyFireRate;
    //time to wait for next fire
    public float enemyNextFire;


    void Update()
    {
        if (Time.time > enemyNextFire)
        {
            audio.PlayOneShot(laserSound);
            enemyNextFire = Time.time + enemyFireRate;
            Instantiate(enemyShot, enemyShotSpawner.position, enemyShotSpawner.rotation);
        }
    }
}
