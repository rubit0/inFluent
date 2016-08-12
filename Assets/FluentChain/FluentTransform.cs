using UnityEngine;
using System;

namespace inFluent
{
    public static class FluentTransform
    {
        public static GameObject SetLocalPosition(this GameObject gameObject, Vector3 position)
        {
            gameObject.transform.localPosition = position;
            return gameObject;
        }

        public static GameObject SetLocalPosition(this GameObject gameObject, Func<Vector3> lambda)
        {
            var position = lambda.Invoke();
            return gameObject.SetLocalPosition(position);
        }

        public static GameObject SetPosition(this GameObject gameObject, Vector3 position)
        {
            gameObject.transform.position = position;
            return gameObject;
        }

        public static GameObject SetPosition(this GameObject gameObject, Func<Vector3> lambda)
        {
            var position = lambda.Invoke();
            return gameObject.SetPosition(position);
        }

        public static GameObject SetLocalScale(this GameObject gameObject, Vector3 scale)
        {
            gameObject.transform.localScale = scale;
            return gameObject;
        }

        public static GameObject SetLocalScale(this GameObject gameObject, Func<Vector3> lambda)
        {
            var scale = lambda.Invoke();
            return gameObject.SetLocalScale(scale);
        }
    } 
}
