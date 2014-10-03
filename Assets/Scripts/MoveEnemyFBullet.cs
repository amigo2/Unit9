using UnityEngine;
using System.Collections;

public class MoveEnemyFBullet : MonoBehaviour {

    private float speed = 15;

    void Awake()
    {
        rigidbody2D.velocity = transform.right * speed;

    }
}
