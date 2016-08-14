using UnityEngine;
using System.Collections;

public class DummyBehaviourScript : MonoBehaviour
{
    public string Name { get; set; }

    public void Log()
    {
        Debug.Log(Name);
	}
}
