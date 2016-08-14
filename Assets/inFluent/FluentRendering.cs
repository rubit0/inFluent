using UnityEngine;
using System;
using System.Collections;

namespace inFluent
{
    public static class FluentRendering
    {
        /// <summary>
        /// Set the Material on this GameObjects Renderer Component.
        /// This Method is skipped, in case this GameObject has no renderer Component.
        /// </summary>
        /// <param name="gameObject">This GameObject.</param>
        /// <param name="material">Material applied to this GameObject renderer Component.</param>
        /// <returns>This GameObject.</returns>
        public static GameObject SetMaterial(this GameObject gameObject, Material material)
        {
            var renderer = gameObject.GetComponent<Renderer>();
            if (renderer == null)
                return gameObject;
            
            renderer.material = material;
            return gameObject;
        }

        /// <summary>
        /// Set the Material on this GameObjects Renderer Component.
        /// The Delegates first parameter tells if this GameObject has a Renderer Component.
        /// </summary>
        /// <param name="gameObject">This GameObject.</param>
        /// <param name="materialHandler">Delegate that returns a Material.</param>
        /// <returns>This GameObject.</returns>
        public static GameObject SetMaterial(this GameObject gameObject, Func<bool, Material> materialHandler)
        {
            var hasRenderer = (gameObject.GetComponent<Renderer>() != null);
            var material = materialHandler.Invoke(hasRenderer);
            return gameObject.SetMaterial(material);
        }
    }
}
