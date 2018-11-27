using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript instance;
    public Text score;
    public float curScore;
    public float increment;
    public List<GameObject> tiles = new List<GameObject>();
    public List<Vector3> positions = new List<Vector3>();
    public bool dead = false;
    public float timerTotal;
    public float timerCurrent;

    public int tileIndex;
    public int posIndex;

    // Use this for initialization
    void Start()
    {
        instance = this;
        
        score = GameObject.Find("Score").GetComponent<Text>();
        timerTotal = 2f;
        timerCurrent = timerTotal;
    }

    // Update is called once per frame
    void Update()
    {
        if (dead == false)
        {
            curScore += increment * Time.deltaTime;
            score.text = "Score: " + Mathf.FloorToInt(curScore);
            timerCurrent -= Time.deltaTime;
        }
        else
        {
            PlayerPrefs.SetInt("Score", Mathf.RoundToInt(curScore));
            SceneManager.LoadScene("Menu");
        }
       
        if (timerCurrent <= 0)
        {
            tileIndex = Random.Range(0, tiles.Count);

            Instantiate(tiles[tileIndex], positions[posIndex], Quaternion.identity);
            timerCurrent = timerTotal;
            /*if (tileIndex < tiles.Count - 1)
            {
                //tileIndex++;
            }
            else
            {
                //tileIndex = 0;
            }*/

            if (posIndex < positions.Count - 1)
            {
                posIndex++;
            }
            else
            {
                posIndex = 0;
            }
        }
    }
}
