using UnityEngine;
using TMPro;
public class DisplayFps : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI fpsText;

    float pollingTime = 1f;
    float time;
    float frameCount;

    void Update()
    {
        time += Time.deltaTime;
        frameCount++;

        if (time >= pollingTime)
        {
            int _frameRate = Mathf.RoundToInt(frameCount / time);
            fpsText.text = _frameRate.ToString() + $" FPS   Time.DeltaTime - {Time.deltaTime * 100}";

            time -= pollingTime;
            frameCount = 0;
        }
    }
}
