using UnityEngine;

public class UIScroller : MonoBehaviour
{
    [SerializeField] private RectTransform contentToScroll;
    [SerializeField] private float scrollSpeed = 30f;
    private Vector2 initialPosition;
    private bool canScroll = false;

    private void Awake()
    {
        if(contentToScroll != null)
        {
            initialPosition = contentToScroll.anchoredPosition;
        }
    }

    private void Update()
    {
        if (canScroll && contentToScroll != null)
        {
            contentToScroll.Translate(Vector3.up * scrollSpeed * Time.deltaTime);
        }
    }

    public void StartScrolling()
    {
        contentToScroll.anchoredPosition = initialPosition;
        canScroll = true;
    }

    public void StopScrolling()
    {
        canScroll = false;
    }
}
