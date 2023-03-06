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

        // ī�޶� ������� ĵ���� ������ ������ ũ�� �� ���Ѵ�.
        // width�� height �� �� �ϳ��� ������ ������ �����Ѵ�.
        canvasAspect.x = cameraSize.x / canvasSize.x;
        canvasAspect.y = canvasAspect.x;

        worldCanvas.transform.localScale = canvasAspect;
    }

    // Update is called once per frame
    void Update()
    {

    }
}