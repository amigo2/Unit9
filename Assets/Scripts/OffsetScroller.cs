using UnityEngine;
using System.Collections;

public class OffsetScroller : MonoBehaviour {

    //public var to control speed of scroll
    public float scrollSpeed;
    //Init point for the offset
    private Vector2 saveOffset;

	void Start () 
    {
        //Getting the Main Teaxture offset 
        saveOffset = renderer.sharedMaterial.GetTextureOffset("_MainTex");
	
	}
	

	void Update () 
    {
        float y = Mathf.Repeat(Time.time * scrollSpeed, 1);
        Vector2 offset = new Vector2(saveOffset.x, y);
        renderer.sharedMaterial.SetTextureOffset("_MainTex", offset);
	}

    void OnDisable()
    {
        renderer.sharedMaterial.SetTextureOffset("_MainText", saveOffset);
    }
}
