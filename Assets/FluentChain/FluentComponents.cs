using UnityEngine;
using System;

namespace inFluent
{
    public static class FluentComponents
    {
        public static GameObject AttachComponent<T>(this GameObject gameObject) where T : Behaviour
        {
            if (gameObject.GetComponent<T>() != null)
                return gameObject;

            gameObject.AddComponent<T>();
            return gameObject;
        }

        public static GameObject AttachComponent<T>(this GameObject gameObject, out bool result) where T : Behaviour
        {
            if (gameObject.GetComponent<T>() != null)
            {
                result = false;
                return gameObject;
            }

            gameObject.AddComponent<T>();
            result = true;
            return gameObject;
        }

        public static GameObject AttachComponent<T>(this GameObject gameObject, Action<bool> resultLambda) where T : Behaviour
        {
            if (gameObject.GetComponent<T>() != null)
            {
                resultLambda.Invoke(false);
                return gameObject;
            }

            gameObject.AddComponent<T>();
            resultLambda.Invoke(true);
            return gameObject;
        }
    }
}