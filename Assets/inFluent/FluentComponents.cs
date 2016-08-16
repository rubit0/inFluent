using UnityEngine;
using System;

namespace inFluent
{
    public static class FluentComponents
    {
        private static GameObject AttachComponent<T>(this GameObject gameObject,out bool skipped, out T component) where T : Behaviour
        {
            if (gameObject.GetComponent<T>() != null)
            {
                skipped = false;
                component = null;
                return gameObject;
            }

            skipped = true;
            component = gameObject.AddComponent<T>();
            return gameObject;
        }

        /// <summary>
        /// Attach a Unity component or Script to this GameObject.
        /// Note: Attachment is skipped if the component is already present.
        /// </summary>
        /// <returns>This GameObject.</returns>
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
        /// <returns>This GameObject.</returns>
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
        /// <returns>This GameObject.</returns>
        /// <param name="gameObject">This GameObject.</param>
        /// <param name="componentHandler">Delegate that can interact with the attached component. The first parameter tells if the component was attached.</param>
        /// <typeparam name="T">Unity Component or Script</typeparam>
        public static GameObject AttachComponent<T>(this GameObject gameObject, Action<bool, T> componentHandler) where T : Behaviour
        {
            var attachResult = false;
            T component = null;
            gameObject.AttachComponent(out attachResult, out component);
            componentHandler.Invoke(attachResult, component);

            return gameObject;
        }

        /// <summary>
        /// Destroys a component on this GameObject.
        /// </summary>
        /// <typeparam name="T">The components Type which must be a Unity Component or Script.</typeparam>
        /// <param name="gameObject">This GameObject.</param>
        /// <returns>This GameObject.</returns>
        public static GameObject DestroyComponent<T>(this GameObject gameObject) where T : Behaviour
        {
            var component = gameObject.GetComponent<T>();
            if (component != null)
                MonoBehaviour.Destroy(component);

            return gameObject;
        }

        /// <summary>
        /// Destroys a component on this GameObject.
        /// </summary>
        /// <typeparam name="T">The components Type which must be a Unity Component or Script.</typeparam>
        /// <param name="gameObject">This GameObject.</param>
        /// <param name="skipped">Was the destruction skipped?</param>
        /// <returns>This GameObject.</returns>
        public static GameObject DestroyComponent<T>(this GameObject gameObject, out bool skipped) where T : Behaviour
        {
            var component = gameObject.GetComponent<T>();
            if (component != null)
            {
                MonoBehaviour.Destroy(component);
                skipped = true;
            }
            else
            {
                skipped = false;
            }

            return gameObject;
        }

        /// <summary>
        /// Destroys a component on this GameObject.
        /// </summary>
        /// <typeparam name="C">The components Type which must be a Unity Component or Script.</typeparam>
        /// <param name="gameObject">This GameObject.</param>
        /// <param name="skippedHandler">Delegate that deals with the skipped desctruction state.</param>
        /// <returns>This GameObject.</returns>
        public static GameObject DestroyComponent<C>(this GameObject gameObject, Action<bool> skippedHandler) where C : Behaviour
        {
            var skipped = false;
            gameObject.DestroyComponent<C>(out skipped);
            skippedHandler.Invoke(skipped);

            return gameObject;
        }

        /// <summary>
        /// Allows you to work with a Component inline.
        /// </summary>
        /// <typeparam name="T">The components Type which must be a Unity Component or Script.</typeparam>
        /// <param name="gameObject">This GameObject./param>
        /// <param name="componentHandler">Delegate that allows you to work with the component. The first parameter tells if the component was present.</param>
        /// <returns>This GameObject.</returns>
        public static GameObject TouchComponent<T>(this GameObject gameObject, Action<bool, T> componentHandler) where T : Behaviour
        {
            var component = gameObject.GetComponent<T>();
            componentHandler.Invoke((component != null), component);
            return gameObject;
        }
    }
}