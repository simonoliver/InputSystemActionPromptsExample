using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEditor;
public static class SetTextSpriteScale
{
    [MenuItem("Prompts/Set Text Sprite Scale")]
    public static void SetTextSpriteScales()
    {
        
        var allTextSprites=FindAllScriptableObjectsOfType<TMP_SpriteAsset>("","Packages");
        Debug.Log($"Found assets - length {allTextSprites.Count}");
        foreach (var textSprite in allTextSprites)
        {
            if (textSprite != null)
            {
                Debug.Log($"Found {textSprite.name}");
                ProcessSprites(textSprite);
            }
            //textSprite.spriteAssetScale = 1;
            
        }
    }

    private static void ProcessSprites(TMP_SpriteAsset textSprite)
    {
        foreach (var sprite in textSprite.spriteGlyphTable)
        {
            var metrics=sprite.metrics;
            metrics.horizontalBearingY = 80;
            sprite.metrics = metrics;
            sprite.scale = 1.2f;
        }
        EditorUtility.SetDirty(textSprite);
    }

    public static List<T> FindAllScriptableObjectsOfType<T>(string filter, string folder = "Assets")
        where T : ScriptableObject
    {
        return AssetDatabase.FindAssets(filter, new[] { folder })
            .Select(guid => AssetDatabase.LoadAssetAtPath<T>(AssetDatabase.GUIDToAssetPath(guid)))
            .ToList();
    }

    
}
