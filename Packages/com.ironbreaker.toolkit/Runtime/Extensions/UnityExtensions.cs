using System;
using System.Collections;
using UnityEngine;

namespace Ironbreaker.Toolkit.UnityExtensions
{
    public static class MonoBehaviourExtensions
    {
        public static void CallFunctionDelay(this MonoBehaviour behaviour, Action function, float delay)
        {
            behaviour.StartCoroutine(FunctionDelay(function, delay));
        }

        static IEnumerator FunctionDelay(Action function, float delay)
        {
            float timer = 0f;

            while (timer < delay)
            {
                timer += Time.unscaledDeltaTime;
                yield return null;
            }

            function.Invoke();
        }
    }

    public static class GameObjectExtensions
    {
        #region Children & Relations
        public static void DestroyChild(this GameObject gameObject, int childIndex)
        {
            gameObject.transform.DestroyChild(childIndex);
        }

        public static void DestroyChildren(this GameObject gameObject)
        {
            gameObject.transform.DestroyChildren();
        }
        #endregion
    }

    public static class TransformExtensions
    {
        #region Position
        public static void PlaceNextTo(this Transform transform, Transform target, Vector3 relativeOffset, Vector3 absoluteOffset)
        {
            Vector3 position = target.position;

            Vector3 forward = target.forward * relativeOffset.z;
            Vector3 right = target.right * relativeOffset.x;
            Vector3 up = target.up * relativeOffset.y;

            transform.position = forward + right + up + absoluteOffset + position;
        }

        public static void PlaceNextTo(this Transform transform, Transform target, Vector3 relativeOffset)
        {
            PlaceNextTo(transform, target, relativeOffset, Vector3.zero);
        }
        #endregion

        #region Rotation
        public static void LookAtInverse(this Transform transform, Vector3 lookAt)
        {
            transform.rotation = Quaternion.LookRotation(transform.position - lookAt);
        }

        public static void LookAtInverse(this Transform transform, Transform lookAt)
        {
            LookAtInverse(transform, lookAt.position);
        }
        #endregion

        #region Children & Relations
        public static void DestroyChild(this Transform transform, int childIndex)
        {
            UnityEngine.Object.Destroy(transform.GetChild(childIndex).gameObject);
        }   

        public static void DestroyChildren(this Transform transform)
        {
            for (int i = transform.childCount - 1; i >= 0; i--)
            {
                transform.DestroyChild(i);
            }
        }        
        #endregion
    }

    public static class Vector3Extensions
    {
        public static Vector3 ClearX(this Vector3 vector)
        {
            vector.x = 0f;
            return vector;
        }

        public static Vector3 ClearY(this Vector3 vector)
        {
            vector.y = 0f;
            return vector;
        }

        public static Vector3 ClearZ(this Vector3 vector)
        {
            vector.z = 0f;
            return vector;
        }

        public static Vector3 SetX(this Vector3 vector, float value)
        {
            vector.x = value;
            return vector;
        }

        public static Vector3 SetY(this Vector3 vector, float value)
        {
            vector.y = value;
            return vector;
        }

        public static Vector3 SetZ(this Vector3 vector, float value)
        {
            vector.z = value;
            return vector;
        }
    }

    public static class LayerMaskExtensions
    {
        public static bool Contains(this LayerMask layerMask, int layer)
        {
            return ((layerMask & (1 << layer)) != 0);
        }
    }
}