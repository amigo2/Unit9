using UnityEngine;
using System.Collections;

public class DestroyEnemy : MonoBehaviour {

    GameManager myGameManager;

    public Transform particles;
    public int score;

    public AudioClip explosionSound;

    void Start()
    {
        myGameManager = (GameManager)GameObject.Find("Main Camera").GetComponent<GameManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            print("touch");
            return;
        }
        if (other.tag == "Boundary")
        {
            return;
        }

        if (other.tag == "Bullet")
        {
            
            Instantiate(particles, gameObject.transform.position, gameObject.transform.rotation);
            audio.PlayOneShot(explosionSound);
            myGameManager.score += 10;
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
