using UnityEngine;
using System;
using System.Collections;

namespace inFluent
{
    public static class FluentRendering
    {
        public static GameObject SetMaterial(this GameObject gameObject, Material material)
        {
            var renderer = gameObject.GetComponent<Renderer>();
            if (renderer == null)
                return gameObject;
            
            renderer.material = material;
            return gameObject;
        }

        public static GameObject SetMaterial(this GameObject gameObject, Func<Material> materialLambda)
        {
            var material = materialLambda.Invoke();
            return gameObject.SetMaterial(material);
        }
    }
}
