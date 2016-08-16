using UnityEngine;
using System.Linq;
using inFluent;

public class SimpleGameObjectSetting : MonoBehaviour
{
    public Transform LookAtTarget;
    public string TargetName = "FluentTestObject_01";
    public string TargetTag = "Player";
    public Vector3 TargetLocalScale;
    public Vector3 TargetLocalPosition;
    public Material CustomMaterial;

    public SimpleGameObjectSetting(string name) :base()
    {
        this.TargetName = name;
    }

	void Start ()
    {
        this.gameObject.SetName(() => 
            {
                var chars = TargetName.ToCharArray();
                var reverse = chars.Reverse().ToString(); ;
                return reverse;
            })
            .SetTag(TargetTag)
            .SetLayer(1)
            .SetLocalScale(TargetLocalScale)
            .SetLocalPosition(TargetLocalPosition)
            .LookAt(LookAtTarget.position)
            .AttachComponent<AudioSource>()
            .AttachComponent<DummyBehaviourScript>((r, c) =>
            {
                if(r)
                {
                    c.Name = "Test!";
                    c.Log();
                }
            })
            .SetMaterial((r) => (CustomMaterial != null) ? CustomMaterial : new Material(Shader.Find("Diffuse")))
            .SetStatic(true)
            .TouchComponent<DummyBehaviourScript>((r, c) => 
            {
                if (r)
                {
                    c.name = "Dummy One";
                    c.DummyLog("Hello from the last part of the chain!");
                }
            });
	}
}
