using UnityEngine;
using System.Collections;

public class StartScript : MonoBehaviour {

    public void OnGUI()
    {
        if (Event.current.type == EventType.KeyDown)
        {
            Application.LoadLevel("Main");
        }
    }
}
