using UnityEngine;
using System;

namespace inFluent
{
    public static class FluentTransform
    {
        public static GameObject SetTranslation(this GameObject gameObject, Vector3 destination)
        {
            gameObject.transform.Translate(destination);
            return gameObject;
        }

        public static GameObject SetTranslation(this GameObject gameObject, Func<Vector3> destinationLambda)
        {
            var destination = destinationLambda.Invoke();
            return gameObject.SetTranslation(destination);
        }

        public static GameObject MakeLookAt(this GameObject gameObject, Vector3 target)
        {
            gameObject.transform.LookAt(target);
            return gameObject;
        }

        public static GameObject MakeLookAt(this GameObject gameObject, Func<Vector3> targetLambda)
        {
            var target = targetLambda.Invoke();
            return gameObject.MakeLookAt(target);
        }

        public static GameObject MakeRotateTo(this GameObject gameObject, Vector3 eulerAngle)
        {
            gameObject.transform.Rotate(eulerAngle);
            return gameObject;
        }

        public static GameObject MakeRotateTo(this GameObject gameObject, Func<Vector3> eulerAngleLambda)
        {
            var euler = eulerAngleLambda.Invoke();
            return gameObject.MakeRotateTo(euler);
        }

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
