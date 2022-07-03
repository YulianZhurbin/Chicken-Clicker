using UnityEngine;

public class TextMover : MonoBehaviour
{
    [SerializeField] float speedY;
    [SerializeField] float terminalPoint = 0;
    RectTransform rectTransform;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        if (rectTransform.localPosition.y > terminalPoint)
        {
            rectTransform.Translate(speedY * Time.deltaTime * Vector2.down);
        }
    }
}
