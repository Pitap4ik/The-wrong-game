using UnityEngine;

namespace GeneralExtensions
{
    public static class Components
    {
        public static bool HasComponent <T>(this GameObject obj) where T:Component
        {
            return obj.GetComponent<T>() != null;
        }
    }
}