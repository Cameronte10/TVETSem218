using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ColourManager : MonoBehaviour
{

    public static ColourManager instance;

    public string skin;
    public List<Color32> colours;
    public List<Color32> lockedColours;
    //public Color32 green = new Color32(74, 255, 83, 255);
    //public Color32 blue = new Color32(74, 166, 255, 255);
    //public Color32 red = new Color32(255, 86, 73, 255);
    public bool picker = false;
    public Image image;
    public int index;
    public int money;
    // Use this for initialization

    private void Awake()
    {
        instance = this;
        //SceneManager.sceneLoaded += OnSceneLoaded;

    }
    
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        colours.Add(new Color32(74, 255, 83, 255));
        colours.Add(new Color32(74, 166, 255, 255));
        colours.Add(new Color32(255, 86, 73, 255));
        money = PlayerPrefs.GetInt("money");
        if (GameObject.Find("Picker") != null)
        {
            image = MenuButtonLink.instance.GetComponent<Image>();
        }
        skin = PlayerPrefs.GetString("skin");
        if (picker)
        {
            //ColourClicked();
            image.color = colours[index];
            /*if (skin == "Red")
            {
                image.color = red;
                

            }
            else if (skin == "Green")
            {
                image.color = green;
                
            }
            else if (skin == "Blue")
            {

                //image.color = new Color(1f / 255f, 1f / 86f, 1f / 73f);
                image.color = blue;
                
            }*/
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Clicked()
    {
        SceneManager.LoadScene("Fall");
    }

    public void ColourClicked()
    {
        /*if (skin == "Red")
        {
            //image.color = Color.green;
            image.color = new Color32(74, 255, 83, 255);
            skin = "Green";
            PlayerPrefs.SetString("skin", "Green");
            
        }
        else if (skin == "Green")
        {
            //image.color = Color.blue;
            image.color = new Color32(74, 166, 255, 255);
            skin = "Blue";
            PlayerPrefs.SetString("skin", "Blue");
        }
        else if (skin == "Blue")
        {
            image.color = new Color32(255, 86, 73, 255);
            //image.color = Color.red;
            skin = "Red";
            PlayerPrefs.SetString("skin", "Red");
        }
        else
        {
            skin = "Blue";
            ColourClicked();
        }*/
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
            byte randomR = (byte)Random.Range(1, 255);
            byte randomG = (byte)Random.Range(1, 255);
            byte randomB = (byte)Random.Range(1, 255);
            colours.Add(new Color32(randomR, randomG, randomB, 255));
            money -= 100;
            PlayerPrefs.SetInt("money", money);

            image.color = colours[colours.Count - 1];
            //Send a message to Picker to update to latest colour
            index = colours.Count - 1;
        }
    }
}
