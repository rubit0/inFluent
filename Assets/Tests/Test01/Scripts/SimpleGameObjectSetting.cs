using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using inFluent;

public class SimpleGameObjectSetting : MonoBehaviour
{
    public Transform LookAtTarget;
    public string TargetName = "FluentTestObject_01";
    public string TargetTag = "Player";
    public Vector3 TargetLocalScale;
    public Vector3 TargetLocalPosition;
    public Material CustomMaterial;

	void Start ()
    {
        var result = false;

        this.gameObject.SetName(() => TargetName.ToLower())
            .SetTag(TargetTag)
            .SetLayer(1)
            .SetLocalScale(TargetLocalScale)
            .SetLocalPosition(TargetLocalPosition)
            .MakeLookAt(LookAtTarget.position)
            .AttachComponent<AudioSource>((r) => Debug.Log("Attached Component: " + r))
            .AttachComponent<DummyBehaviourScript>((r) => Debug.Log("Attached Script: " + r))
            .AttachComponent<Button>(out result)
            .SetMaterial(() => (CustomMaterial) ? CustomMaterial : new Material(Shader.Find("Diffuse")))
            .SetStatic(() => (gameObject.isStatic) ? false : true);

        Debug.Log(result);
	}
}
