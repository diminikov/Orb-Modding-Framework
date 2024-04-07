using Newtonsoft.Json.Linq;
using System.IO;
using System.Reflection;
using UnityEngine;

namespace OMF
{
    public class JsonDecoding
    {
        public static ResourceTypeSO decodeResourceTypeSO(string path)
        {
            ResourceTypeSO resourceTypeSO = ScriptableObject.CreateInstance<ResourceTypeSO>();

            Debug.Log(File.ReadAllText(path));
            JObject rtJson = JObject.Parse(File.ReadAllText(path));

            Texture2D texture2D = new(2, 2);
            ImageConversion.LoadImage(texture2D, File.ReadAllBytes(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), rtJson["displayIcon"].ToString())));
            resourceTypeSO.displayIcon = Sprite.Create(texture2D, new Rect(0, 0, texture2D.width, texture2D.height), new Vector2(0, 0), 100.0f); ;
            resourceTypeSO.displayName = rtJson["displayName"].ToString();
            resourceTypeSO.name = rtJson["displayName"].ToString() + "ResourceType";
            Debug.Log((float)rtJson["displayColor"]["r"] / 255f);
            resourceTypeSO.displayColor = new((float)rtJson["displayColor"]["r"]/255f, (float)rtJson["displayColor"]["g"] / 255f, (float)rtJson["displayColor"]["b"] / 255f, (float)rtJson["displayColor"]["a"] / 255f);
            resourceTypeSO.description = rtJson["description"].ToString();

            resourceTypeSO.attributeCostMod = new();
            resourceTypeSO.rateMod = new();
            resourceTypeSO.maxQuantityMod = new();
            resourceTypeSO.maxQuantityRateMod = new();
            resourceTypeSO.qualityMod = new();
            resourceTypeSO.gainRateMod = new();
            resourceTypeSO.drainMod = new();
            resourceTypeSO.lossPercentMod = new();
            resourceTypeSO.restMod = new();
            resourceTypeSO.splashRate = new MergingModifierRecord();
            resourceTypeSO.splashRateMaxPercent = new MergingModifierRecord();
            resourceTypeSO.rawMaxQuantity = new MergingModifierRecord();

            return resourceTypeSO;
        }
    }

}
