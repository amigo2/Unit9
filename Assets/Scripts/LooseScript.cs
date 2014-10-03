using UnityEngine;
using System.Collections;

public class LooseScript : MonoBehaviour {

    public void OnGUI()
    {
        if (Event.current.type == EventType.KeyDown)
        {
            Application.LoadLevel("Start");
        }
    }
}
