using TMPro;
using UnityEngine;

public class Stats : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int Wave;
    public TMP_Text WaveText;
    public TMP_Text PointsText;
    public GameObject Block;
    public int points;
    int blockCount;

    void Restart() 
    {
        Wave = 1;
    }

    void WaveStart()
    {
        for (int i = 0; i <= 4; i++) 
        {
            GameObject SpawnedBlock = Instantiate(Block);
            SpawnedBlock.transform.position = new Vector3(-1.5f * i + 3f,4,0);
        }
    }
    void Start()
    {
        WaveStart();
        blockCount = GameObject.FindGameObjectsWithTag("Block").Length;
        print(blockCount);
        Restart();
    }

    // Update is called once per frame
    void Update()
    {
        PointsText.text = "Score: "+points;
        blockCount = GameObject.FindGameObjectsWithTag("Block").Length;
        WaveText.text = "Wave: "+Wave;
        if (blockCount == 0) 
        {
            if (Wave != 5)
            {
                Wave += 1;
                WaveStart();
            }
        }
    }
}