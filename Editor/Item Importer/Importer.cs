using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using System.IO;
using System.Threading;
using Assets.Scripts.ItemSystem.ItemTypes;
using Assets.Scripts.ItemSystem.ItemTypes.CargoItems;
using Component = Assets.Scripts.ItemSystem.ItemTypes.CargoItems.Component;

public class Importer : EditorWindow
{
    [MenuItem("Dev/Editor/Item Importer %#e")]
    static void Init()
    {
        // Get existing open window or if none, make a new one:
        Importer window = (Importer)EditorWindow.GetWindow(typeof(Importer));
        window.Show();
    }

    TextAsset modulesFile;
    TextAsset itemsFile;
    TextAsset shipsFile;
    TextAsset TurretsFile;
    TextAsset ToolsFile;

    private void ImportItems()
    {
        
        using (var reader = new StreamReader(AssetDatabase.GetAssetPath(itemsFile)))
        {
            
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');
                
                
                if (values[2] == "Raw")
                {

                    Debug.Log("Raw Item/n" +
                        "Name: " + values[1] + ", Img: " + values[3]);

                    Raw rawItem = CreateRaw(values[1]);
                    //rawItem.rarity = setRarityByName(values[4]);
                }

                if (values[2] == "Refined")
                {

                    Debug.Log("Refined Item/n" +
                        "Name: " + values[1] + ", Img: " + values[3]);

                    Refined rawItem = CreateRefined(values[1]);
                }
                if (values[2] == "Component")
                {

                    Debug.Log("Component Item/n" +
                        "Name: " + values[1] + ", Img: " + values[3]);

                    Component rawItem = CreateComponent(values[1]);
                }
                if (values[2] == "Commerce")
                {

                    Debug.Log("Commerce Item/n" +
                        "Name: " + values[1] + ", Img: " + values[3]);

                    Commerce rawItem = CreateCommerce(values[1]);
                }
            }
        }
        
    }
    
    void OnGUI()
    {
        itemsFile = EditorGUILayout.ObjectField("Items CSV", itemsFile, typeof(UnityEngine.TextAsset), false, GUILayout.Width(305)) as UnityEngine.TextAsset;
        
        if (GUILayout.Button("Import"))
        {
            
            ImportItems();
        }
    }

    public Raw CreateRaw(string name)
    {
        Raw asset = ScriptableObject.CreateInstance<Raw>();
        asset.itemName = name;
        Sprite sprite = AssetDatabase.LoadAssetAtPath("Assets/Materials/Textures/items/Raw/"+name+"_ore_img.png", typeof(Sprite)) as Sprite;
        if (sprite!=null) { asset.sprite = sprite; }
        if (!AssetDatabase.IsValidFolder("Assets/Resources/Items/Raw"))
        {
            AssetDatabase.CreateFolder("Assets/Resources/Items", "Raw");
        }
        AssetDatabase.CreateAsset(asset, "Assets/Resources/Items/Raw/" + name + ".asset");
        AssetDatabase.SaveAssets();
        return asset;
    }

    public Component CreateComponent(string name)
    {
        Component asset = ScriptableObject.CreateInstance<Component>();
        asset.itemName = name;
        Sprite sprite = AssetDatabase.LoadAssetAtPath("Assets/Materials/Textures/items/Components/" + name + "_component_img.png", typeof(Sprite)) as Sprite;
        if (sprite != null) { asset.sprite = sprite; }
        if (!AssetDatabase.IsValidFolder("Assets/Resources/Items/Components"))
        {
            AssetDatabase.CreateFolder("Assets/Resources/Items","Components");
        }
        AssetDatabase.CreateAsset(asset, "Assets/Resources/Items/Components/" + name + ".asset");
        AssetDatabase.SaveAssets();
        return asset;
    }

    public Refined CreateRefined(string name)
    {
        Refined asset = ScriptableObject.CreateInstance<Refined>();
        asset.itemName = name;
        Sprite sprite = AssetDatabase.LoadAssetAtPath("Assets/Materials/Textures/items/Refined/" + name + "_refined_img.png", typeof(Sprite)) as Sprite;
        if (sprite != null) { asset.sprite = sprite; }
        if (!AssetDatabase.IsValidFolder("Assets/Resources/Items/Refined"))
        {
            AssetDatabase.CreateFolder("Assets/Resources/Items", "Refined");
        }
        AssetDatabase.CreateAsset(asset, "Assets/Resources/Items/Refined/" + name + ".asset");
        AssetDatabase.SaveAssets();
        return asset;
    }

    public Commerce CreateCommerce(string name)
    {
        Commerce asset = ScriptableObject.CreateInstance<Commerce>();
        asset.itemName = name;
        Sprite sprite = AssetDatabase.LoadAssetAtPath("Assets/Materials/Textures/items/Commerce/" + name + "_commerce_img.png", typeof(Sprite)) as Sprite;
        if (sprite != null) { asset.sprite = sprite; }
        if (!AssetDatabase.IsValidFolder("Assets/Resources/Items/Commerce"))
        {
            AssetDatabase.CreateFolder("Assets/Resources/Items", "Commerce");
        }
        AssetDatabase.CreateAsset(asset, "Assets/Resources/Items/Commerce/" + name + ".asset");
        AssetDatabase.SaveAssets();
        return asset;
    }
}
