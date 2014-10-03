using UnityEngine;
using System.Collections;

public class BoundariesDestroyer : MonoBehaviour {



    void OnTriggerExit2D (Collider2D other)
    {
        Destroy(other.gameObject);

        if (other.tag == "EnemyBullet")
        {
            Destroy(other.gameObject);
        }
    }

}
