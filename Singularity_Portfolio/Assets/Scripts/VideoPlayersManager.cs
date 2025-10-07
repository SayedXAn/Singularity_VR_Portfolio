using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoPlayersManager : MonoBehaviour
{
    public VideoPlayer[] playerList;

    void Start()
    {
        for(int i = 0; i < playerList.Length; i++)
        {
            playerList[i].Stop();
            playerList[i].targetTexture.Release();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TurnOffVideoPlayers(int id)
    {
        for (int i = 0; i < playerList.Length; i++)
        {
            if(i == id)
            {
                continue;
            }
            playerList[i].Stop();
            playerList[i].targetTexture.Release();
        }
    }
}
