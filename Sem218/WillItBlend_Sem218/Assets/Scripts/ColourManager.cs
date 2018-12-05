using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
public class ColourManager : MonoBehaviour
{

    public static ColourManager instance;

    public string skin;
    public List<Color32> colours;
    public bool picker = false;
    public Image image;
    public int index;
    public int money;
    // Use this for initialization

    private void Awake()
    {
        /*Screen.SetResolution(420, 747, false);
        Screen.fullScreen = false;*/ //SETS SCREEN SIZE used for build testing
        Load();
        instance = this;
        SceneManager.sceneLoaded += OnSceneLoaded;

    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (GameObject.Find("Picker") != null)
        {
            image = MenuButtonLink.instance.GetComponent<Image>();
            image.color = colours[index];
        }
    }

    public void Save()
    {
        //Save data to file
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/playerinfo.dat", FileMode.Open);

        PlayerData data = new PlayerData();
        data.colours = colours;
        bf.Serialize(file, data);
        file.Close();
    }

    public void Load()
    {
        //Load data from file
        if (File.Exists(Application.persistentDataPath + "/playerinfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerinfo.dat", FileMode.Open);
            PlayerData data = (PlayerData) bf.Deserialize(file);
            file.Close();

            colours = data.colours;
        }
    }

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        colours.Add(new Color32(74, 255, 83, 255));
        colours.Add(new Color32(74, 166, 255, 255));
        colours.Add(new Color32(255, 86, 73, 255));
        money = PlayerPrefs.GetInt("money");
        money = 3000;
        skin = PlayerPrefs.GetString("skin");

        

    }


    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            Save(); //Save data when application is paused
        }
        
    }

    private void OnApplicationQuit()
    {
        
            Save(); //Save data when application is paused
        
    }

    public void Clicked()
    {
        SceneManager.LoadScene("Fall"); //Load game scene
    }

    public void ColourClicked()
    {
        //Increment colour List
        index++;
        if (index > colours.Count - 1)
        {
            index = 0;
        }
        image.color = colours[index];
    }

    public void BuyColour()
    {
        if (money >= 100)
        {
            //Generate random Colour
            byte randomR = (byte)UnityEngine.Random.Range(1, 255);
            byte randomG = (byte)UnityEngine.Random.Range(1, 255);
            byte randomB = (byte)UnityEngine.Random.Range(1, 255);
            colours.Add(new Color32(randomR, randomG, randomB, 255)); //Add new Colour to List
            money -= 100; //Subtract money
            PlayerPrefs.SetInt("money", money); //Set money
            //Send a message to Picker to update to latest colour
            image.color = colours[colours.Count - 1];
            index = colours.Count - 1;
        }
    }
}

[Serializable]
class PlayerData
{
    public List<Color32> colours;//Make colours persistent
}
