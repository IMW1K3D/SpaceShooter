using TMPro;
using UnityEngine;

public class Stats : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] int Wave;
    [SerializeField] int BlockStat;
    [SerializeField] int Bullets;
    [SerializeField] TMP_Text WaveText;
    int blockCount = GameObject.FindGameObjectsWithTag("Block").Length;

    void Restart() 
    {
        Wave = 0;
        BlockStat = 0;
        Bullets = 0;
    }

    void WaveStart()
    {
        print("Starting wave: "+Wave);
    }
    void Start()
    {
        print(blockCount);
        Restart();
    }

    // Update is called once per frame
    void Update()
    {
        blockCount = GameObject.FindGameObjectsWithTag("Block").Length;
        print(blockCount);
        if (blockCount <= 0) 
        {
            Wave += 1;
            WaveStart();
        }
    }
}