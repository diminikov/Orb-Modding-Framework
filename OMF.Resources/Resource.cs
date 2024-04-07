using OMF;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace OMF
{
    public static class Resource
    {

        private static List<ResourceSO> _AddedResources = new();

        /// <summary>
        /// Function to register a resource with OMF
        /// </summary>
        /// <param name="resource"> ResourceSO to register</param>
        public static void RegisterResource(ResourceSO resource)
        {
            //TODO: Add better upgrade validation
            if (_AddedResources.Count > 0 && _AddedResources.Find(x => x.GetGuid() == resource.GetGuid()))
            {
                Debug.Log("Trying to add identical resource");
                return;
            }
            _AddedResources.Add(resource);
        }

        /// <summary>
        /// Function to insert all registered resources into OoC. Do not use this!
        /// </summary>
        public static void AddRegisteredResources()
        {
            GameManager GameManager = OMFUtils.GetManager<GameManager>();
            ResourceListVariable resList = Resources.LoadAll<ResourceListVariable>("").ToList().Find(x => x.name == "NonManaCoreResources");

            GameManager.allResources.isStatic = false;
            resList.isStatic = false;
            foreach (var res in _AddedResources)
            {
                if (GameManager.allResources.Find(x => x.GetGuid() == res.GetGuid()))
                {
                    Debug.Log("Trying to add identical resource");
                    continue;
                }

                res.RegisterObject();

                GameManager.allResources.Add(res);
                resList.Add(res);

            }
            resList.isStatic = true;
            GameManager.allResources.isStatic = true;

        }

        /// <summary>
        /// Gets the resource with the specified name
        /// </summary>
        /// <param name="name">Name of the resource</param>
        /// <returns></returns>
        public static ResourceSO GetResourceSO(string name)
        {
            ResourceSO res = ResourceSO.All.Find(x => x.displayName == name);

            if (res != null)
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

