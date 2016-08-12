using UnityEngine;
using System;

namespace inFluent
{
    public static class FluentProperties
    {
        public static GameObject SetName(this GameObject gameObject, string name)
        {
            gameObject.name = name;
            return gameObject;
        }

        public static GameObject SetName(this GameObject gameObject, Func<string> lambda)
        {
            var name = lambda.Invoke();
            gameObject.name = name;
            return gameObject;
        }

        public static GameObject ToggleActiveState(this GameObject gameObject)
        {
            gameObject.SetActive(!gameObject.activeInHierarchy);
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
            gameObject.tag = tag;
            return gameObject;
        }
    }
}