using UnityEngine;
using System.Collections;

public class NPCLookAtPlayerVR : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 5f;

    private Transform playerCameraTransform;
    private bool isPlayerInside = false;
    private Coroutine lookAtCoroutine;

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
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInside = false;
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
