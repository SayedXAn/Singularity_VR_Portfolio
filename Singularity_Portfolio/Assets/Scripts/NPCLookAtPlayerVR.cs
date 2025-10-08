using UnityEngine;
using System.Collections;
using TMPro;

public class NPCLookAtPlayerVR : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 5f;

    [SerializeField] private GameObject dialogueCanvas;

    private Transform playerCameraTransform;
    private bool isPlayerInside = false;
    private Coroutine lookAtCoroutine;

    [SerializeField] private UIScroller uiScroller;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerCameraTransform = Camera.main.transform;
            isPlayerInside = true;

            if (lookAtCoroutine != null)
            {
                StopCoroutine(lookAtCoroutine);
            }
            lookAtCoroutine = StartCoroutine(RotateTowardsPlayer());

            if (uiScroller != null)
            {
                // First, make the canvas visible.
                uiScroller.gameObject.SetActive(true);
                // Then, tell the script to start scrolling.
                uiScroller.StartScrolling();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInside = false;

            if (uiScroller != null)
            {
                // Tell the script to stop scrolling.
                uiScroller.StopScrolling();
                // Then, hide the canvas.
                uiScroller.gameObject.SetActive(false);
            }
        }
    }

    private IEnumerator RotateTowardsPlayer()
    {
        while (isPlayerInside)
        {
            if (playerCameraTransform != null)
            {
                Vector3 direction = playerCameraTransform.position - transform.position;

                direction.y = 0;

                Quaternion targetRotation = Quaternion.LookRotation(direction);

                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }

            yield return null;
        }
    }
}
