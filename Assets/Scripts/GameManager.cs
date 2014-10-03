using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {


    // Enemy variables    
    public GameObject enemy;
    public GameObject enemyFlip;

    bool isSpawning = false;
    public float minTime = 1f;
    public float maxTime = 3f;


    public int enemyCount;
    public Vector2 SpawnValues;
    public float spawnSeconds = 1;

    // Player related variables
    public GameObject player;
    DestroyPlayer destroyPLayer;

    // Score variables
    public GUIStyle scoreStyle;
    public int score;



	void Start () {

        // Spawn enemies  , amount, evryoften in seconds.
        SpawnObject(10, spawnSeconds);

        destroyPLayer = (DestroyPlayer)GameObject.Find("Player").GetComponent<DestroyPlayer>();
	}

    // Spawn Enemies on time
    IEnumerator SpawnObject(int enemyCount, float seconds)
    {

        float rangeX = Random.Range(2.3f, 3f);
        float rangeY = Random.Range(7, 10);

        float rangeXLeft = Random.Range(-2, -4);
        float rangeYLeft = Random.Range(8, 15);
     
        yield return new WaitForSeconds(seconds);
        Instantiate(enemy, new Vector2 (rangeX,rangeY), transform.rotation);

        Instantiate(enemyFlip, new Vector2(rangeXLeft, rangeYLeft), transform.rotation);

        //We've spawned, so now we could start another spawn     
        isSpawning = false;
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3.0f);
        Application.LoadLevel("Loose");
    }

 

    void Update()
    {
        // If no player wait and load Loose Menu
        if (!player)
        {
            StartCoroutine(Wait());  
        }

        //We only want to spawn one at a time
        if (!isSpawning)
        {
            isSpawning = true; //Yep, we're going to spawn
            int enemyIndex = 2;
            StartCoroutine(SpawnObject(enemyIndex, spawnSeconds));
        }

    }

    //GUI
    void OnGUI()
    {
        // Showing and updating the score
        GUI.Label (new Rect (60, 20, 100, 50), "Life: " + "  " + destroyPLayer.playerLife, scoreStyle) ;
        GUI.Label(new Rect(450, 20, 100, 50),  "Score: " + score, scoreStyle);
    }

}
