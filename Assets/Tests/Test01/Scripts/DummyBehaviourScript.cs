using UnityEngine;
using System.Collections;

public class DummyBehaviourScript : MonoBehaviour
{
    public string Name { get; set; }

    public void Log()
    {
        Debug.Log(Name);
	}

    public void DummyLog(string message)
    {
        Debug.LogFormat("{0} says: {1}", Name, message);
    }
}
