using UnityEngine;

public class NPCWaveTrigger : MonoBehaviour
{
    [SerializeField] private Animator npcAnimator;
    private string playerNearbyBool = "isPlayerNearby";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            npcAnimator.SetBool(playerNearbyBool, true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            npcAnimator.SetBool(playerNearbyBool, false);
        }
    }
}
