using UnityEngine;
using System;

namespace inFluent
{
    public static class FluentTransform
    {
        /// <summary>
        /// Move this GameObject by the provided destination vector.
        /// </summary>
        /// <param name="gameObject">This GameObject.</param>
        /// <param name="destination">Destination.</param>
        /// <returns>This GameObject.</returns>
        public static GameObject SetTranslation(this GameObject gameObject, Vector3 destination)
        {
            gameObject.transform.Translate(destination);
            return gameObject;
        }

        /// <summary>
        /// Move this GameObject by the provided destination vector.
        /// </summary>
        /// <param name="gameObject">This GameObject.</param>
        /// <param name="destinationHandler">Delegate that returns the destination.</param>
        /// <returns>This GameObject.</returns>
        public static GameObject SetTranslation(this GameObject gameObject, Func<Vector3> destinationHandler)
        {
            var destination = destinationHandler.Invoke();
            return gameObject.SetTranslation(destination);
        }

        /// <summary>
        /// Rotates this GameObject towards the provided target(world space).
        /// </summary>
        /// <param name="gameObject">This GameObject.</param>
        /// <param name="target">Look at target.</param>
        /// <returns>This GameObject.</returns>
        public static GameObject LookAt(this GameObject gameObject, Vector3 target)
        {
            gameObject.transform.LookAt(target);
            return gameObject;
        }

        /// <summary>
        /// Rotates this GameObject towards the provided target(world space).
        /// </summary>
        /// <param name="gameObject">This GameObject.</param>
        /// <param name="targetHandler">Delegate that returns the destination vector.</param>
        /// <returns>This GameObject.</returns>
        public static GameObject LookAt(this GameObject gameObject, Func<Vector3> targetHandler)
        {
            var target = targetHandler.Invoke();
            return gameObject.LookAt(target);
        }

        /// <summary>
        /// Applies rotation to this GameObject.
        /// </summary>
        /// <param name="gameObject">This GameObject.</param>
        /// <param name="eulerAngle">Rotation as EulerAngles.</param>
        /// <returns>This GameObjkect.</returns>
        public static GameObject RotateBy(this GameObject gameObject, Vector3 eulerAngle)
        {
            gameObject.transform.Rotate(eulerAngle);
            return gameObject;
        }

        /// <summary>
        /// Applies rotation to this GameObject.
        /// </summary>
        /// <param name="gameObject">This GameObject.</param>
        /// <param name="eulerAngleHandler">Delegate that returns the EulerAngles as Vector3</param>
        /// <returns>This GameObject.</returns>
        public static GameObject RotateBy(this GameObject gameObject, Func<Vector3> eulerAngleHandler)
        {
            var euler = eulerAngleHandler.Invoke();
            return gameObject.RotateBy(euler);
        }

        /// <summary>
        /// Set this GameObjects local position.
        /// </summary>
        /// <param name="gameObject">This GameObject.</param>
        /// <param name="position">Target position in local space.</param>
        /// <returns>This GameObject.</returns>
        public static GameObject SetLocalPosition(this GameObject gameObject, Vector3 position)
        {
            gameObject.transform.localPosition = position;
            return gameObject;
        }

        /// <summary>
        /// Set this GameObjects local position.
        /// </summary>
        /// <param name="gameObject">This GameObject.</param>
        /// <param name="positionHandler">Delegate that returns the position vector.</param>
        /// <returns>This GameObject</returns>
        public static GameObject SetLocalPosition(this GameObject gameObject, Func<Vector3> positionHandler)
        {
            var position = positionHandler.Invoke();
            return gameObject.SetLocalPosition(position);
        }

        /// <summary>
        /// Set this GameObjects world Position.
        /// </summary>
        /// <param name="gameObject">This GameObject.</param>
        /// <param name="position">Target world space position</param>
        /// <returns>This GameObject.</returns>
        public static GameObject SetPosition(this GameObject gameObject, Vector3 position)
        {
            gameObject.transform.position = position;
            return gameObject;
        }

        /// <summary>
        /// Set this GameObjects world position.
        /// </summary>
        /// <param name="gameObject">This GameObject.</param>
        /// <param name="positionHandler">Delegate that returns the target position in world space.</param>
        /// <returns>This GameObject.</returns>
        public static GameObject SetPosition(this GameObject gameObject, Func<Vector3> positionHandler)
        {
            var position = positionHandler.Invoke();
            return gameObject.SetPosition(position);
        }

        /// <summary>
        /// Set this GameObjects local scale.
        /// </summary>
        /// <param name="gameObject">This GameObject.</param>
        /// <param name="scale">Target local scale.</param>
        /// <returns>This GameObject.</returns>
        public static GameObject SetLocalScale(this GameObject gameObject, Vector3 scale)
        {
            gameObject.transform.localScale = scale;
            return gameObject;
        }

        /// <summary>
        /// Set this GameObjects local scale.
        /// </summary>
        /// <param name="gameObject">This GameObject.</param>
        /// <param name="scaleHandler">Delegate that returns the local scale vector.</param>
        /// <returns>This GameObject.</returns>
        public static GameObject SetLocalScale(this GameObject gameObject, Func<Vector3> scaleHandler)
        {
            var scale = scaleHandler.Invoke();
            return gameObject.SetLocalScale(scale);
        }
    } 
}
