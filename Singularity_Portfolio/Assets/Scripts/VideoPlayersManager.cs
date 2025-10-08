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
            //playerList[i].targetTexture.Release();
        }
    }


    public void TurnOffVideoPlayers(int id)
    {
        Debug.Log("Dhukse??");
        for (int i = 0; i < playerList.Length; i++)
        {
            if(i == id)
            {
                Debug.Log("id " + id);
                continue;
            }
            playerList[i].Stop();
            playerList[i].targetTexture.Release();
        }
    }
}
