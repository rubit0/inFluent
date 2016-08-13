using UnityEngine;
using System;

namespace inFluent
{
    public static class FluentGameObject
    {
        public static GameObject SetName(this GameObject gameObject, string name)
        {
            gameObject.name = name;
            return gameObject;
        }

        public static GameObject SetName(this GameObject gameObject, Func<string> lambda)
        {
            var name = lambda.Invoke();
            return gameObject.SetName(name);
        }

        public static GameObject SetLayer(this GameObject gameObject, int layerId)
        {
            layerId = Mathf.Clamp(layerId, 0, 31);
            gameObject.layer = layerId;
            return gameObject;
        }

        public static GameObject SetLayer(this GameObject gameObject, Func<int> layerLambda)
        {
            var layerId = layerLambda.Invoke();
            return gameObject.SetLayer(layerId);
        }

        public static GameObject SetStatic(this GameObject gameObject, bool isStatic)
        {
            gameObject.isStatic = isStatic;
            return gameObject;
        }

        public static GameObject SetStatic(this GameObject gameObject, Func<bool> isStaticLambda)
        {
            var isStatic = isStaticLambda.Invoke();
            return gameObject.SetStatic(isStatic);
        }

        public static GameObject ToggleActiveState(this GameObject gameObject)
        {
            gameObject.SetActive(!gameObject.activeInHierarchy);
            return gameObject;
        }

        public static GameObject ToggleActiveState(this GameObject gameObject, out bool stateResult)
        {
            stateResult = !gameObject.activeInHierarchy;
            gameObject.SetActive(stateResult);
            return gameObject;
        }

        public static GameObject SetActiveState(this GameObject gameObject, bool state)
        {
            gameObject.SetActive(state);
            return gameObject;
        }

        public static GameObject SetActiveState(this GameObject gameObject, Func<bool> lambda)
        {
            bool result = lambda.Invoke();
            return gameObject.SetActiveState(result);
        }

        public static GameObject SetTag(this GameObject gameObject, string tag)
        {
            gameObject.tag = tag;
            return gameObject;
        }

        public static GameObject SetTag(this GameObject gameObject, Func<string> lambda)
        {
            var tag = lambda.Invoke();
            return gameObject.SetTag(tag);
        }

        public static GameObject SetDontDestroyOnLoad(this GameObject gameObject)
        {
            MonoBehaviour.DontDestroyOnLoad(gameObject);
            return gameObject;
        }

        public static GameObject MakeClone(this GameObject gameObject, out GameObject clone)
        {
            clone = MonoBehaviour.Instantiate(gameObject);
            return gameObject;
        }

        public static void MakeDestroyGameObject(this GameObject gameObject)
        {
            MonoBehaviour.Destroy(gameObject);
        }
    }
}