using UnityEngine;
using System.Collections;

public class MoveBulletMain : MonoBehaviour {

    public float speed;

    private PLayerController playerController;



	void Awake()
    {
       
       playerController = GameObject.Find("Player").GetComponent<PLayerController>();

       if (playerController.facingRight)
       {
           rigidbody2D.velocity = transform.right * - speed;
       }
       else
       {
           rigidbody2D.velocity = transform.right * speed;
       }
	
	}


}
