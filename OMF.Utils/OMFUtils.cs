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

    }
}

