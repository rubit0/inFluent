using UnityEngine;
using System;

namespace inFluent
{
    public static class FluentGameObject
    {
        /// <summary>
        /// Set this GameObjects name.
        /// </summary>
        /// <param name="gameObject">This GameObject</param>
        /// <param name="name">This GameObjects new name.</param>
        /// <returns>This GameObject.</returns>
        public static GameObject SetName(this GameObject gameObject, string name)
        {
            gameObject.name = name;
            return gameObject;
        }

        /// <summary>
        /// Set this GameObjects name.
        /// </summary>
        /// <param name="gameObject">This GameObject.</param>
        /// <param name="nameHandler">Delegate that returns the desired name.</param>
        /// <returns>This GameObject.</returns>
        public static GameObject SetName(this GameObject gameObject, Func<string> nameHandler)
        {
            var name = nameHandler.Invoke();
            return gameObject.SetName(name);
        }

        /// <summary>
        /// Set this GameObjects current Tag.
        /// Be carefull and make sure that the Tag is part of the Tag Manager,
        /// otherwise the GameObject is null and the Fluent API chain breaks.
        /// </summary>
        /// <param name="gameObject">This GameObject.</param>
        /// <param name="tag">Applied Tag, make sure it is valid!</param>
        /// <returns>This GameObject.</returns>
        public static GameObject SetTag(this GameObject gameObject, string tag)
        {
            const string defaultTag = "Untagged";

            if (string.IsNullOrEmpty(tag))
                tag = defaultTag;

            gameObject.tag = tag;
            return gameObject;
        }

        /// <summary>
        /// Set this GameObjects current Tag.
        /// Be carefull and make sure that the Tag is part of the Tag Manager,
        /// otherwise the GameObject is null and the Fluent API chain breaks.
        /// </summary>
        /// <param name="gameObject">This GameObject.</param>
        /// <param name="tagHandler">Delegate that returns the Tag as a string.
        /// Make sure the string contains a valid Tag!
        /// </param>
        /// <returns>This GameObject.</returns>
        public static GameObject SetTag(this GameObject gameObject, Func<string> tagHandler)
        {
            var tag = tagHandler.Invoke();
            return gameObject.SetTag(tag);
        }

        /// <summary>
        /// Set this GameObjects Layer.
        /// </summary>
        /// <param name="gameObject">This GameObject.</param>
        /// <param name="layerId">Layer Id.</param>
        /// <returns>This GameObject.</returns>
        public static GameObject SetLayer(this GameObject gameObject, int layerId)
        {
            layerId = Mathf.Clamp(layerId, 0, 31);
            gameObject.layer = layerId;
            return gameObject;
        }

        /// <summary>
        /// Set this GameObjects Layer.
        /// </summary>
        /// <param name="gameObject">This GameObject.</param>
        /// <param name="layerHandler">Delegate that returns the desired Layer Id.</param>
        /// <returns>This GameObject.</returns>
        public static GameObject SetLayer(this GameObject gameObject, Func<int> layerHandler)
        {
            var layerId = layerHandler.Invoke();
            return gameObject.SetLayer(layerId);
        }

        /// <summary>
        /// Set this GameObjects static state.
        /// </summary>
        /// <param name="gameObject">This GameObject.</param>
        /// <param name="isStatic">Set static?</param>
        /// <returns>This GameObject.</returns>
        public static GameObject SetStatic(this GameObject gameObject, bool isStatic)
        {
            gameObject.isStatic = isStatic;
            return gameObject;
        }

        /// <summary>
        /// Set this GameObjects static state.
        /// </summary>
        /// <param name="gameObject">This GameObject.</param>
        /// <param name="isStaticHandler">Delegate that returns the desired static state.</param>
        /// <returns>This GameObject.</returns>
        public static GameObject SetStatic(this GameObject gameObject, Func<bool> isStaticHandler)
        {
            var isStatic = isStaticHandler.Invoke();
            return gameObject.SetStatic(isStatic);
        }

        /// <summary>
        /// Toggles this GameObjects state in the Hierachie.
        /// </summary>
        /// <param name="gameObject">This GameObject.</param>
        /// <returns>This GameObject.</returns>
        public static GameObject ToggleActiveState(this GameObject gameObject)
        {
            gameObject.SetActive(!gameObject.activeInHierarchy);
            return gameObject;
        }

        /// <summary>
        /// Toggles this GameObjects state in the Hierachie.
        /// </summary>
        /// <param name="gameObject">This GameObject.</param>
        /// <param name="stateResult">New state of the GameObject.</param>
        /// <returns>This GameObject.</returns>
        public static GameObject ToggleActiveState(this GameObject gameObject, out bool stateResult)
        {
            stateResult = !gameObject.activeInHierarchy;
            gameObject.SetActive(stateResult);
            return gameObject;
        }

        /// <summary>
        /// Set this GameObjects active state.
        /// </summary>
        /// <param name="gameObject">This GameObject.</param>
        /// <param name="state">Disable/Enable</param>
        /// <returns>This GameObject.</returns>
        public static GameObject SetActiveState(this GameObject gameObject, bool state)
        {
            gameObject.SetActive(state);
            return gameObject;
        }

        /// <summary>
        /// Set this GameObjects active state.
        /// </summary>
        /// <param name="gameObject">This GameObject.</param>
        /// <param name="stateHandler">Delegate that returns the desired state.</param>
        /// <returns></returns>
        public static GameObject SetActiveState(this GameObject gameObject, Func<bool> stateHandler)
        {
            bool result = stateHandler.Invoke();
            return gameObject.SetActiveState(result);
        }

        /// <summary>
        /// Sets the this GameObject to not be Destroyed when a new scene is loaded.
        /// </summary>
        /// <param name="gameObject">This GameObject.</param>
        /// <returns>This GameObject.</returns>
        public static GameObject SetDontDestroyOnLoad(this GameObject gameObject)
        {
            MonoBehaviour.DontDestroyOnLoad(gameObject);
            return gameObject;
        }

        /// <summary>
        /// Get the clone of this GameObject and return it on the out parameter.
        /// </summary>
        /// <param name="gameObject">This GameObject.</param>
        /// <param name="clone">The cloned GameObject.</param>
        /// <returns>This GameObject.</returns>
        public static GameObject GetClone(this GameObject gameObject, out GameObject clone)
        {
            clone = MonoBehaviour.Instantiate(gameObject);
            return gameObject;
        }

        /// <summary>
        /// Destroys this GameObject.
        /// </summary>
        /// <param name="gameObject">This GameObject.</param>
        public static void DestroyGameObject(this GameObject gameObject)
        {
            MonoBehaviour.Destroy(gameObject);
        }
    }
}