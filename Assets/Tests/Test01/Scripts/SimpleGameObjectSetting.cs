using UnityEngine;
using System.Collections;
using inFluent;

public class SimpleGameObjectSetting : MonoBehaviour
{
    public string TargetName = "FluentTestObject_01";
    public string TargetTag = "Player";
    public Vector3 TargetLocalScale;
    public Vector3 TargetLocalPosition;

	void Start ()
    {
        this.gameObject.SetName(() => TargetName.ToLower())
            .SetTag(TargetTag)
            .SetLocalScale(TargetLocalScale)
            .SetLocalPosition(TargetLocalPosition)
            .AttachComponent<AudioSource>((r) => Debug.Log("Attached Component: " + r))
            .AttachComponent<DummyBehaviourScript>((r) => Debug.Log("Attached Script: " + r));
	}
}
