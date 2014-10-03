using UnityEngine;
using System.Collections;

public class DestroyPlayer : MonoBehaviour {

    public int playerLife = 3;
    public Transform particlesP;
    public Transform particlesPTotalDeath;
    public AudioClip explosionSound;

    void OnTriggerEnter2D(Collider2D any)
    {
        if (any.tag == "EnemyBullet")
        {
            print("destrooy");

            playerLife--;

            Instantiate(particlesP, gameObject.transform.position, gameObject.transform.rotation);
            audio.PlayOneShot(explosionSound);
            Destroy(any.gameObject);

            if (playerLife <= 0)
            {
                audio.PlayOneShot(explosionSound);

                Instantiate(particlesP, gameObject.transform.position, gameObject.transform.rotation);
                Instantiate(particlesPTotalDeath, gameObject.transform.position, gameObject.transform.rotation);
                
                Destroy(gameObject);
            }
        }

        print("coolide");
        if (any.tag == "Boundary")
        {
            print("bounds");
            return;
           
        }

        
    }
}
