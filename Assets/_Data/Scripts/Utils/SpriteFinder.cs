using UnityEditor;
using UnityEngine;

public class SpriteFinder
{
    public static Sprite GetSprite(string pathToImage, string spriteName)
    {
        //Tìm những obj con trong obj cha có path = pathToImage
        Object[] sprites = AssetDatabase.LoadAllAssetRepresentationsAtPath(pathToImage);

        foreach (Object sprite in sprites)
        {
            if (sprite is Sprite && sprite.name == spriteName)
            {
                return sprite as Sprite;
            }
        }

        Debug.LogError($"Sprite {spriteName} not found in {pathToImage}");
        return null;
    }
}