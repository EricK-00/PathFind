using UnityEditor;
using UnityEngine;

public class WorldCanvasScaler : MonoBehaviour
{
    private Canvas worldCanvas;
    private Vector2 cameraSize;

    [SerializeField]
    private Vector2 canvasAspect;

    // Start is called before the first frame update
    void Start()
    {
        Vector2 canvasSize;

        worldCanvas = gameObject.GetComponentMust<Canvas>();
        cameraSize = GFunc.GetCameraSize();
        canvasSize = worldCanvas.gameObject.GetRectSizeDelta();

        // 카메라 사이즈와 캔버스 사이즈 사이의 크기 비를 구한다.
        // width와 height 둘 중 하나의 값으로 비율을 결정한다.
        canvasAspect.x = cameraSize.x / canvasSize.x;
        canvasAspect.y = canvasAspect.x;

        worldCanvas.transform.localScale = canvasAspect;
    }

    // Update is called once per frame
    void Update()
    {

    }
}