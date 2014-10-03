using UnityEngine;
using System.Collections;

public class EnemyFlipShoot : MonoBehaviour {

    public GameObject enemyFShot;
    public Transform enemyShotSpawner;
    public float enemyFBulletSpeed;

    public AudioClip laserSound;

    public float enemyFireRate;
    public float enemyNextFire;


    void Update()
    {
        if (Time.time > enemyNextFire)
        {
            audio.PlayOneShot(laserSound);
            enemyNextFire = Time.time + enemyFireRate;
            Instantiate(enemyFShot, enemyShotSpawner.position, enemyShotSpawner.rotation);
        }
    }
}
