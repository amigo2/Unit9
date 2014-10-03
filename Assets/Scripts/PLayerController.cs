using UnityEngine;
using System.Collections;


public class PLayerController : MonoBehaviour 
{
    //Player variables
    public float turboForce = 5f;
    public GameObject enemy;
    Transform myTransform;
    GameObject myGameObject;
   

    // Fire variables
    public float fireRate;
    public float nextFire;
    public bool facingRight;
    bool isFiring = false;
    public AudioClip laserSound;
    public GameObject shot;
    public Transform shotSpawner;
    public float bulletSpeed;



    public float playerSpeed;

    //Raycast variables
    public Transform StartRayFront, StartRayReaar, EndRayFront, EndRayReear;
    public bool spottedLeft = false;
    public bool spottedRight = false;



    


	void Start () {

        myTransform = transform;

	}
	

	void Update () {

        Raycasting();
        
        // Jump turbo
        if (Input.GetKey(KeyCode.Space)  )
        {
            rigidbody2D.velocity = new Vector3(0, turboForce, 0);
            isFiring = true;
            
        }

        // Move torwads enemy and flip
        if (enemy)// if null new style
        {

            if (spottedLeft && !facingRight)
            {
                myTransform.position = Vector2.MoveTowards(transform.position, enemy.transform.position, playerSpeed * Time.deltaTime);

            }
            if (spottedLeft && facingRight)
            {
                myTransform.position = Vector2.MoveTowards(transform.position, enemy.transform.position,  -playerSpeed * Time.deltaTime);
            }

            if (spottedRight)
            {
                Flip();
            }

        }

            
        // Give time to not fire again
        if ( Time.time > nextFire)
        {

            nextFire = Time.time + fireRate;            
            Instantiate(shot, shotSpawner.position, shotSpawner.rotation);
            audio.PlayOneShot(laserSound);

        }

	}

    // Launch a ray to check enemies around
    void Raycasting()
    {
        Debug.DrawLine(StartRayFront.transform.position, EndRayFront.transform.position, Color.green);
        spottedLeft = Physics2D.Linecast(StartRayFront.transform.position, EndRayFront.transform.position, 1 << LayerMask.NameToLayer("Enemy"));

        Debug.DrawLine(StartRayReaar.transform.position, EndRayReear.transform.position, Color.red);
        spottedRight = Physics2D.Linecast(StartRayReaar.transform.position, EndRayReear.transform.position, 1 << LayerMask.NameToLayer("Enemy"));

    }

    // Flip the player
    void Flip()
    {
        facingRight = !facingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

  
}
