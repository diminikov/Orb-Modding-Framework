using BepInEx;
using MonoMod.RuntimeDetour;
using System;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System.Linq;

namespace OMF
{
    [BepInPlugin("OMF", "Orb Modding Framework", "0.0.1")]
    public class MainHook : BaseUnityPlugin
    { 
        private void Awake()
        {
            Logger.LogInfo("Orb Modding Framework is loaded!");

            //Hooking the Start() function of GameManager
            IDetour preStart = new Hook(
                typeof(GameManager).GetMethod("Start", BindingFlags.Instance | BindingFlags.NonPublic),
                typeof(MainHook).GetMethod("PreStartGame", BindingFlags.Static | BindingFlags.Public)
            );
        }

        /// <summary>
        /// This function runs before the Start() of GameManager
        /// </summary>
        public static void PreStartGame(Action<GameManager> orig, GameManager self)
        {
            Upgrade.AddRegisteredUpgrades();
            orig(self);
        }
    }

}
