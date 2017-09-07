using UnityEngine;
using UnityEditor;
using System.IO;
using System.Collections.Generic;

public class ExportAssetBundles
{
    [MenuItem("Assets/Build AssetBundle")]
    static void ExportResource()
    {
        const string root = "Assets/";
        const string resPath = root + "Result/";

        List<Object> toInclude = new List<Object>();
        string[] assetsInFolder = Directory.GetFiles(root);

        List<string> assetListInFolder = new List<string>();

        foreach (string asset in assetsInFolder)
        {
            string thisFileName = Path.GetFileName(asset);
            if (asset.EndsWith(".xml") | asset.EndsWith(".txt"))
            {
                string internalFilePath = root + thisFileName;
                toInclude.Add((Object)Resources.LoadAssetAtPath(internalFilePath, typeof(Object)));
                assetListInFolder.Add(thisFileName);
            }
        }

        TextAsset nameStr = (TextAsset)Resources.LoadAssetAtPath(resPath + "PackName.txt", typeof(TextAsset));
        string dlcName = nameStr.text;

        string bundlePath = resPath + dlcName;
        BuildPipeline.BuildAssetBundle(null, toInclude.ToArray(), bundlePath, BuildAssetBundleOptions.DeterministicAssetBundle);
    }
}