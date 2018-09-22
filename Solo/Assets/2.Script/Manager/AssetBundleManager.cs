using System.Collections;
using UnityEngine;

namespace ManagerGroup
{
    public class AssetBundleManager : Singleton<AssetBundleManager>
    {
        const string ITEM_BUNDLE_NAME = "itembundle";
        
        AssetBundle itemBudle;
        
        void Awake()
        {
            StartCoroutine(LoadAssetBundle(ITEM_BUNDLE_NAME));
        }

        IEnumerator LoadAssetBundle(string assetName)
        {
            if (assetName == null)
                yield break;
            itemBudle = AssetBundle.LoadFromFile(SetPath(assetName));
            if (itemBudle == null)
            {
                Debug.Log("Load Fail : itemBundle is Null");
                yield break;
            }
            else
                Debug.Log("Successe");
        }

        string SetPath(string assetName)
        {
            return Application.dataPath + "/AssetBundles/" + assetName;
        }


        public Sprite LoadSprite(string assetName)
        {
            if (itemBudle == null)
                itemBudle = AssetBundle.LoadFromFile(SetPath(ITEM_BUNDLE_NAME));
            return itemBudle.LoadAsset<Sprite>(assetName);
        }
    }

    


}