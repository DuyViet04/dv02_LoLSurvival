using UnityEditor;
using UnityEngine;

public class SpriteFinder
{
    public static Sprite GetSprite(string pathToImage, string spriteName)
    {
        //Tìm những obj con trong obj cha có path = pathToImage
        Sprite[] sprites = Resources.LoadAll<Sprite>(pathToImage);

        foreach (Sprite sprite in sprites)
        {
            if (sprite.name == spriteName)
            {
                return sprite;
            }
        }

        Debug.LogError($"Sprite {spriteName} not found in {pathToImage}");
        return null;
    }

    public static Sprite GetStatIconSprite(string spriteName)
    {
        string path = "Sprites/Icon";
        Sprite[] sprites = Resources.LoadAll<Sprite>(path);
        foreach (Sprite sprite in sprites)
        {
            if (sprite.name == spriteName)
                return sprite;
        }

        Debug.LogError($"Sprite {spriteName} not found in {path}");
        return null;
    }
}