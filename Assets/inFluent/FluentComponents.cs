using UnityEngine;
using System;

namespace inFluent
{
    public static class FluentComponents
    {
        /// <summary>
        /// Attach a Unity component or Script to this GameObject.
        /// Note: Attachment is skipped if the component is already present.
        /// </summary>
        /// <returns>GameObject</returns>
        /// <param name="gameObject">This GameObject.</param>
        /// <typeparam name="T">Unity Component or Script</typeparam>
        public static GameObject AttachComponent<T>(this GameObject gameObject) where T : Behaviour
        {
            if (gameObject.GetComponent<T>() != null)
                return gameObject;

            gameObject.AddComponent<T>();
            return gameObject;
        }

        /// <summary>
        /// Attach a Unity component or Script to this GameObject.
        /// Note: Attachment is skipped if the component is already present.
        /// </summary>
        /// <returns>GameObject</returns>
        /// <param name="gameObject">This GameObject.</param>
        /// <param name="skipped">Was the Component already attached?</param>
        /// <typeparam name="T">Unity Component or Script</typeparam>
        public static GameObject AttachComponent<T>(this GameObject gameObject, out bool skipped) where T : Behaviour
        {
            if (gameObject.GetComponent<T>() != null)
            {
                skipped = false;
                return gameObject;
            }

            skipped = true;
            return gameObject.AttachComponent<T>();
        }

        /// <summary>
        /// Attach a Unity component or Script to this GameObject.
        /// Note: Attachment is skipped if the component is already present.
        /// </summary>
        /// <returns>GameObject</returns>
        /// <param name="gameObject">This GameObject.</param>
        /// <param name="skippedLambda">Add an action according if the Attachment was skipped.</param>
        /// <typeparam name="T">Unity Component or Script</typeparam>
        public static GameObject AttachComponent<T>(this GameObject gameObject, Action<bool> skippedLambda) where T : Behaviour
        {
            var attachResult = false;
            gameObject.AttachComponent<T>(out attachResult);
            skippedLambda.Invoke(attachResult);

            return gameObject;
        }
    }
}