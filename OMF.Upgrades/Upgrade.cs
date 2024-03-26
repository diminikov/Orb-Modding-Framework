using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace OMF
{
    public static class Upgrade
    {
        private static List<UpgradeSO> _AddedUpgrades = new();

        /// <summary>
        /// Function to register an upgrade with OMF
        /// </summary>
        /// <param name="upgrade"> UpgradeSO to register</param>
        public static void RegisterUpgrade(UpgradeSO upgrade)
        {
            //TODO: Add better upgrade validation
            if (_AddedUpgrades.Count > 0 && _AddedUpgrades.Find(x => x.GetGuid() == upgrade.GetGuid()))
            {
                Debug.Log("Trying to add identical upgrade");
                return;
            }
            _AddedUpgrades.Add(upgrade);
        }

        /// <summary>
        /// Function to add all registered upgrades to OoC
        /// </summary>
        public static void AddRegisteredUpgrades()
        {
            GameManager GameManager = OMFUtils.GetManager<GameManager>();
            ViewManager ViewManager = OMFUtils.GetManager<ViewManager>();

            foreach (var u in _AddedUpgrades)
            {
                if (GameManager.allUpgrades.Find(x => x.GetGuid() == u.GetGuid()))
                {
                    Debug.Log("Trying to add identical upgrade");
                    continue;
                }
                u.RegisterObject();

                GameManager.allUpgrades.isStatic = false;
                GameManager.allUpgrades.Add(u);
                GameManager.allUpgrades.isStatic = true;

                UpgradeListVariable magic = (UpgradeListVariable)ViewManager.coreViews.Find(x => x.displayName == "Magic").relevantLists.Find(x => x.name == "MagicScreenUpgrades");
                magic.isStatic = false;
                magic.Add(u);
                magic.isStatic = true;
            }

        }
    }

}
