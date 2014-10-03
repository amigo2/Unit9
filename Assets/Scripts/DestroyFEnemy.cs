using UnityEngine;
using System.Collections;

public class DestroyFEnemy : MonoBehaviour {
    
    GameManager myGameManager;

    public Transform particlesF;
    public int score;

    public AudioClip explosionSound;

    void Start()
    {
        myGameManager = (GameManager)GameObject.Find("Main Camera").GetComponent<GameManager>();
    }

    void OnTriggerEnter2D(Collider2D some)
    {
        if (some.tag == "Enemy")
        {
            print("touch");
            return;
        }
        if (some.tag == "Boundary")
        {
            return;
        }

        if (some.tag == "Bullet")
        {
           
            Instantiate(particlesF, gameObject.transform.position, gameObject.transform.rotation);
            audio.PlayOneShot(explosionSound);
            myGameManager.score += 10;
            Destroy(some.gameObject);
            Destroy(gameObject);
        }
    }
}
