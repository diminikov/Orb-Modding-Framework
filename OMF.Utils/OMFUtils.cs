using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace OMF
{
    public static class OMFUtils
    {
        /// <summary>
        /// Finds the manager of type T in the scene
        /// </summary>
        /// <typeparam name="T"> The type of manager to find</typeparam>
        /// <returns></returns>
        public static T GetManager<T>()
        {
            T manager = SceneManager.GetActiveScene().GetRootGameObjects().ToList().Find(x => x.name == "Managers").GetComponentInChildren<T>();

            if(manager != null)
            {
                return manager;
            }
            else
            {
                Debug.Log("Could not find manager of type " +  typeof(T).FullName);
                return default;
            }
        }

        /// <summary>
        /// Gets the resource with the specified name
        /// </summary>
        /// <param name="name">Name of the resource</param>
        /// <returns></returns>
        public static ResourceSO GetResourceSO(string name)
        {
            ResourceSO res = Resources.LoadAll<ResourceSO>("").ToList().Find(x => x.displayName == name);
            if(res != null)
            {
                return res;
            }
            else
            {
                Debug.Log("Failed to find Resource: " + name);
                return null;
            }
            
        }
    }
}

