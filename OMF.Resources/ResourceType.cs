using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OMF
{
    public class ResourceType
    {

        private static List<ResourceTypeSO> _AddedResourceTypes = new();

        /// <summary>
        /// Function to register a resource type with OMF
        /// </summary>
        /// <param name="resource"> ResourceTypeSO to register</param>
        public static void RegisterResourceType(ResourceTypeSO resourcetype)
        {
            //TODO: Add better upgrade validation
            if (_AddedResourceTypes.Count > 0 && _AddedResourceTypes.Find(x => x.GetGuid() == resourcetype.GetGuid()))
            {
                Debug.Log("Trying to add identical resource type");
                return;
            }
            _AddedResourceTypes.Add(resourcetype);
        }

        /// <summary>
        /// Function to insert all registered resource types into OoC
        /// </summary>
        public static void AddRegisteredResourceTypes()
        {
            GameManager GameManager = OMFUtils.GetManager<GameManager>();

            GameManager.allResourceTypes.isStatic = false;
            foreach (var type in _AddedResourceTypes)
            {
                if (GameManager.allResourceTypes.Find(x => x.GetGuid() == type.GetGuid()))
                {
                    Debug.Log("Trying to add identical resource type");
                    continue;
                }
                type.RegisterObject();

                GameManager.allResourceTypes.Add(type);

            }
            GameManager.allResourceTypes.isStatic = true;

        }

        /// <summary>
        /// Gets the resource type with the specified name
        /// </summary>
        /// <param name="name">Name of the resource type</param>
        /// <returns></returns>
        public static ResourceTypeSO GetResourceTypeSO(string name)
        {
            ResourceTypeSO type = ResourceTypeSO.All.Find(x => x.displayName == name);

            if (type != null)
            {
                return type;
            }
            else
            {
                Debug.Log("Failed to find Resource Type: " + name);
                return null;
            }
        }
    }

}
