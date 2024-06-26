namespace TheOneStudio.DuckBase.Scripts.Utilities
{
    using System.Linq;
    using UnityEngine;

    public static class TransformUtils
    {
        /// <summary> 
        /// Rotates the current transform toward the target transform just by Y axis 
        /// </summary>
        public static void LookAtByY(this Transform currentTransform, Transform targetTransform)
        {
            currentTransform.LookAt(new Vector3(targetTransform.position.x, currentTransform.position.y, targetTransform.position.z));
        }

        /// <summary>
        /// Reset a transform to default values.
        /// </summary>
        public static void ResetTransform(this Transform transform)
        {
            transform.position      = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            transform.localScale    = Vector3.one;
        }

        /// <summary>
        /// Set active an object.
        /// </summary>
        public static void SetActive(this Transform transform, bool enable)
            => transform.gameObject.SetActive(enable);

        /// <summary> 
        /// Destroy children of an object. 
        /// </summary>
        public static void DestroyAllChildren(this GameObject gameObject)
        {
            foreach (var child in gameObject.transform.Cast<Transform>()) Object.Destroy(child.gameObject);
        }

        /// <summary> 
        /// Destroy children of an object. 
        /// </summary>
        public static void DestroyAllChildren(this Transform gameObject)
        {
            foreach (var child in gameObject.transform.Cast<Transform>()) Object.Destroy(child.gameObject);
        }

        /// <summary>
        /// Destroy child at index
        /// </summary>
        public static void DestroyChildAt(this Transform transform, int index) { Object.Destroy(transform.Cast<Transform>().ToList()[index]); }

        /// <summary>
        /// Set active all children of an object.
        /// </summary>
        public static void SetActiveAllChildren(this GameObject gameObject, bool enable)
        {
            foreach (Transform child in gameObject.transform)
            {
                child.gameObject.SetActive(enable);
            }
        }

        /// <summary>
        /// Set active all children of an object.
        /// </summary>
        public static void SetActiveAllChildren(this Transform gameObject, bool enable)
        {
            foreach (Transform child in gameObject.transform)
            {
                child.gameObject.SetActive(enable);
            }
        }

        /// <summary>
        /// Change index of a child.
        /// </summary>
        public static void ChangeChildIndex(this Transform transform, int from, int to) => transform.GetChild(from).SetSiblingIndex(to);

        public static void MoveChildToFirst(this Transform transform, int index) => transform.GetChild(index).SetAsFirstSibling();

        public static void MoveChildToLast(this Transform transform, int index) => transform.GetChild(index).SetAsLastSibling();
    }
}