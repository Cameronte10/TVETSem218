using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{

    public List<GameObject> tiles = new List<GameObject>();
    public List<Vector3> positions = new List<Vector3>();

    public float timerTotal;
    public float timerCurrent;

    public int tileIndex;
    public int posIndex;

    // Use this for initialization
    void Start()
    {

        timerTotal = 1.5f;
        timerCurrent = timerTotal;
    }

    // Update is called once per frame
    void Update()
    {
        timerCurrent -= Time.deltaTime;
        if (timerCurrent <= 0)
        {
            Instantiate(tiles[tileIndex], positions[posIndex], Quaternion.identity);
            timerCurrent = timerTotal;
            if (tileIndex < tiles.Count - 1)
            {
                tileIndex++;
            }
            else
            {
                tileIndex = 0;
            }

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
