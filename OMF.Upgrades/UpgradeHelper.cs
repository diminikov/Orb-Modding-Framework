using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using UnityEngine;

namespace OMF
{
    public class UpgradeHelper
    {
        /// <summary>
        /// Adds a resource to a resource cost in the specified UpgradeSO
        /// </summary>
        /// <param name="upgrade">The UpgradeSO to add the resource to</param>
        /// <param name="resource">The resource to add</param>
        /// <param name="cost"> The cost of the resource</param>
        public static void AddResourceToCost(UpgradeSO upgrade, ResourceSO resource, BigDouble cost)
        {
            upgrade.resourceCost = new ResourceCostList(resource, cost);
        }

        /// <summary>
        /// Adds a resource to a permanent effect
        /// </summary>
        /// <param name="upgrade">The UpgradeSO to modify</param>
        /// <param name="resource">The resource to add</param>
        /// <param name="index">Defaults to zero. The index to add the resource to</param>
        public static void AddResourceToEffect(UpgradeSO upgrade, ResourceSO resource, int index = 0)
        {
            upgrade.permanentEffects.resourceEffects.ElementAt(index).resource = resource;
        }
    }

}
