using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using TMPro;
using UnityEditor;

public class GroupData{
    public float CompleteMission = 0;
    public float CompleteMinute = 0;
}

public class DrawChartManager : MonoBehaviour
{
    [Header("��")]
    public int length = 100;

    [Header("�e")]
    public int width = 2;

    [Header("��")]
    public int height = 10;

    [Header("�u�P�u���������Z")]
    public float spacing = 1.0f;

    [Header("�u���C��")]
    public Color lineColor = Color.black;

    [Header("�u���ʫ�")]
    public float lineWidth = 0.1f;

    [Header("�y")]
    public GameObject PointPrefab;

    private List<LineRenderer> FlatPlaneLengthLineRenderers = new List<LineRenderer>();
    private List<LineRenderer> FlatPlaneWidthLineRenderers = new List<LineRenderer>();

    private List<LineRenderer> FlatLeftHeightLineRenderers = new List<LineRenderer>();
    private List<LineRenderer> FlatLeftWidthLineRenderers = new List<LineRenderer>();

    private List<LineRenderer> FlatBackWidthLineRenderers = new List<LineRenderer>();
    private List<LineRenderer> FlatBackHeightLineRenderers = new List<LineRenderer>();

    IOCData data;

    void Awake()
    {
        data = GameContainer.Get<IOCData>();
                
    }

    private void Start()
    {
        DrawLines();
        DrawPoints();
        DrawUI();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    // ø�s�T���u
    void DrawLines()
    {
        data.OriginPos = new Vector3(-length / 2f, -height / 2f , 0) * spacing;
        data.spacing = spacing;

        //�e������
        DrawPlane();

        //�e�k���䪺��
        //DrawFlatRight();
        //�e�����䪺��
        DrawFlatLeft();

        //�e�᭱����
        DrawFlatBack();
    }

    void DrawPlane()
    {
        for (int i = 0; i <= length; i++)
        {
            Vector3 startPoint = new Vector3(i * spacing - length * spacing / 2f,  - height * spacing / 2f, 0);
            Vector3 endPoint = new Vector3(i * spacing - length * spacing / 2f, -height * spacing / 2f, width  * spacing);

            DrawLine(FlatPlaneLengthLineRenderers, startPoint, endPoint);
        }

        for (int i = 0; i <= width; i++)
        {
            Vector3 startPoint = new Vector3(- length * spacing / 2f, -height * spacing / 2f, width * spacing - i * spacing);
            Vector3 endPoint = new Vector3((length - 1) * spacing - length * spacing / 2f +1 * spacing, -height * spacing / 2f, width * spacing - i * spacing);

            DrawLine(FlatPlaneWidthLineRenderers, startPoint, endPoint);
        }
    }

    void DrawFlatRight()
    {
        for (int i = 0; i <= width; i++)
        {
            Vector3 startPoint = new Vector3(length / 2f, -height / 2f,  i) * spacing;
            Vector3 endPoint = new Vector3(length / 2f, height / 2f,  i) * spacing;

            DrawLine(FlatLeftWidthLineRenderers, startPoint, endPoint);
        }

        for (int i = 0; i <= height; i++)
        {
            Vector3 startPoint = new Vector3(length / 2f, i -height / 2f, 0) * spacing;
            Vector3 endPoint = new Vector3(length / 2f, i  -height / 2f, (width - 1) * spacing + 1) * spacing;

            DrawLine(FlatLeftHeightLineRenderers, startPoint, endPoint);
        }
    }

    void DrawFlatLeft()
    {
        for (int i = 0; i <= width; i++)
        {
            Vector3 startPoint = new Vector3(-length / 2f, -height / 2f, i) * spacing;
            Vector3 endPoint = new Vector3(-length / 2f, height / 2f, i) * spacing;

            DrawLine(FlatLeftWidthLineRenderers, startPoint, endPoint);
        }

        for (int i = 0; i <= height; i++)
        {
            Vector3 startPoint = new Vector3(-length / 2f, i - height / 2f, 0) * spacing;
            Vector3 endPoint = new Vector3(-length / 2f, i - height / 2f, width ) * spacing;

            DrawLine(FlatLeftHeightLineRenderers, startPoint, endPoint);
        }
    }

    void DrawFlatBack()
    {
        // �e�e�פW���u
        for (int i = 0; i <= length; i++)
        {
            Vector3 startPoint = new Vector3(-length / 2f + i, -height / 2f, width) * spacing;
            Vector3 endPoint = new Vector3(-length / 2f + i, height / 2f, width) * spacing;

            DrawLine(FlatBackWidthLineRenderers, startPoint, endPoint);
        }

        // �e���פW���u
        for (int i = 0; i <= height; i++)
        {
            Vector3 startPoint = new Vector3(-length / 2f , -height / 2f + i, width) * spacing;
            Vector3 endPoint = new Vector3(length / 2f , -height / 2f + i, width) * spacing;

            DrawLine(FlatBackHeightLineRenderers, startPoint, endPoint);
        }
    }

    void DrawLine(List<LineRenderer> lineRenderers, Vector3 startPoint, Vector3 endPoint)
    {
        GameObject lineObject = new GameObject("LineRenderer");
        lineObject.transform.parent = transform;

        LineRenderer lineRenderer = lineObject.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;
        lineRenderer.startColor = lineColor;
        lineRenderer.endColor = lineColor;

        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, startPoint);
        lineRenderer.SetPosition(1, endPoint);

        lineRenderers.Add(lineRenderer);
    }

    void DrawPoints()
    {
        Debug.Log("�ͦ��I�I");

        GroupData[] groupDataArray = new GroupData[15];

        for (int i = 0; i < groupDataArray.Length; i++)
        {
            groupDataArray[i] = new GroupData();
        }
        
        groupDataArray[0].CompleteMission = 5f;
        groupDataArray[0].CompleteMinute = 7.7f;

        groupDataArray[1].CompleteMission = 5f;
        groupDataArray[1].CompleteMinute = 6.5f;

        groupDataArray[2].CompleteMission = 5f;
        groupDataArray[2].CompleteMinute = 7.3f;

        groupDataArray[3].CompleteMission = 4f;
        groupDataArray[3].CompleteMinute = 13.8f;

        groupDataArray[4].CompleteMission = 5f;
        groupDataArray[4].CompleteMinute = 12.3f;

        groupDataArray[5].CompleteMission = 4f;
        groupDataArray[5].CompleteMinute = 12.0f;

        groupDataArray[6].CompleteMission = 4.2f;
        groupDataArray[6].CompleteMinute = 19.9f;

        groupDataArray[7].CompleteMission = 5f;
        groupDataArray[7].CompleteMinute = 4.75f;

        groupDataArray[8].CompleteMission = 5f;
        groupDataArray[8].CompleteMinute = 11.45f;

        groupDataArray[9].CompleteMission = 5f;
        groupDataArray[9].CompleteMinute = 8.3f;

        groupDataArray[10].CompleteMission = 5f;
        groupDataArray[10].CompleteMinute = 7.5f;

        groupDataArray[11].CompleteMission = 5f;
        groupDataArray[11].CompleteMinute = 28.5f;

        groupDataArray[12].CompleteMission = 5f;
        groupDataArray[12].CompleteMinute = 5.95f;

        groupDataArray[13].CompleteMission = 5f;
        groupDataArray[13].CompleteMinute = 7.6f;

        groupDataArray[14].CompleteMission = 5f;
        groupDataArray[14].CompleteMinute = 4.25f;

        for (int i = 0; i < groupDataArray.Length; i++)
        {
            GameObject point = Instantiate(PointPrefab);
            Vector3 pointPos = data.OriginPos + new Vector3(i + 1, groupDataArray[i].CompleteMinute, groupDataArray[i].CompleteMission) * spacing;
            point.transform.position = pointPos;
        }
    }

    void DrawUI()
    {
        X();
        Y();
        Z();
    }

    void Y()
    {
        for (int i = 0; i <= height; i++)
        {
            GameObject textObject = new GameObject("RotatedText");
            TextMeshPro textMeshPro = textObject.AddComponent<TextMeshPro>();

            // �]�m��r���e
            textMeshPro.text = i.ToString();

            // �]�m�r���M�r���j�p�]�i�ھڻݨD���^
            textMeshPro.font = Resources.Load<TMP_FontAsset>("Fonts & Materials/Arial SDF");
            textMeshPro.fontSize = 20;
            textMeshPro.alignment = TextAlignmentOptions.Center;
            // �]�m��r���C��]�i�ھڻݨD���^
            textMeshPro.color = Color.black;

            // �]�m��r���󪺦�m
            textObject.transform.position = data.OriginPos +  new Vector3(0, i, -1) * spacing;

            // �N��r�������-90��¶Y�b
            textObject.transform.Rotate(new Vector3(0, -90, 0));
        }

        GameObject textObject1 = new GameObject("RotatedText");
        TextMeshPro textMeshPro1 = textObject1.AddComponent<TextMeshPro>();

        // �]�m��r���e
        textMeshPro1.text = "(Count)";

        // �]�m�r���M�r���j�p�]�i�ھڻݨD���^
        textMeshPro1.font = Resources.Load<TMP_FontAsset>("Fonts & Materials/Arial SDF");
        textMeshPro1.fontSize = 30;
        textMeshPro1.alignment = TextAlignmentOptions.Center;

        // �]�m��r���C��]�i�ھڻݨD���^
        textMeshPro1.color = Color.black;

        // �]�m��r���󪺦�m
        textObject1.transform.position = data.OriginPos + new Vector3(0, 0.5f + height, -3) * spacing;

        // �N��r�������-90��¶Y�b
        textObject1.transform.Rotate(new Vector3(0, -90, 0));
    }

    void Z()
    {
        for (int i = 0; i < width; i++)
        {
            GameObject textObject = new GameObject("RotatedText");
            TextMeshPro textMeshPro = textObject.AddComponent<TextMeshPro>();

            // �]�m��r���e
            textMeshPro.text = i.ToString();

            // �]�m�r���M�r���j�p�]�i�ھڻݨD���^
            textMeshPro.font = Resources.Load<TMP_FontAsset>("Fonts & Materials/Arial SDF");
            textMeshPro.fontSize = 20;
            textMeshPro.alignment = TextAlignmentOptions.Center;

            // �]�m��r���C��]�i�ھڻݨD���^
            textMeshPro.color = Color.black;

            // �]�m��r���󪺦�m
            textObject.transform.position = data.OriginPos + new Vector3(0, height + 1, i) * spacing;

            // �N��r�������-90��¶Y�b
            textObject.transform.Rotate(new Vector3(0, -90, 0));
        }

        GameObject textObject1 = new GameObject("RotatedText");
        TextMeshPro textMeshPro1 = textObject1.AddComponent<TextMeshPro>();

        // �]�m��r���e
        textMeshPro1.text = "(Complete Times)";

        // �]�m�r���M�r���j�p�]�i�ھڻݨD���^
        textMeshPro1.font = Resources.Load<TMP_FontAsset>("Fonts & Materials/Arial SDF");
        textMeshPro1.fontSize = 15;
        textMeshPro1.alignment = TextAlignmentOptions.Center;

        // �]�m��r���C��]�i�ھڻݨD���^
        textMeshPro1.color = Color.black;

        // �]�m��r���󪺦�m
        textObject1.transform.position = data.OriginPos + new Vector3(0, 3 + height, 0.5f) * spacing;

        // �N��r�������-90��¶Y�b
        textObject1.transform.Rotate(new Vector3(0, -90, 0));
    }
    void X()
    {
        for (int i = 0; i < length; i++)
        {
            GameObject textObject = new GameObject("RotatedText");
            TextMeshPro textMeshPro = textObject.AddComponent<TextMeshPro>();

            // �]�m��r���e
            textMeshPro.text = "Team " + i ;

            // �]�m�r���M�r���j�p�]�i�ھڻݨD���^
            textMeshPro.font = Resources.Load<TMP_FontAsset>("Fonts & Materials/Arial SDF");
            textMeshPro.fontSize = 20;
            textMeshPro.alignment = TextAlignmentOptions.Center;
            // �]�m��r���C��]�i�ھڻݨD���^
            textMeshPro.color = Color.black;

            // �]�m��r���󪺦�m
            textObject.transform.position = data.OriginPos + new Vector3(i+1, 0, -2) * spacing;

            // �N��r�������-90��¶Y�b
            textObject.transform.Rotate(new Vector3(90, 0, 90));
        }

        GameObject textObject1 = new GameObject("RotatedText");
        TextMeshPro textMeshPro1 = textObject1.AddComponent<TextMeshPro>();

        // �]�m��r���e
        textMeshPro1.text = "(Team ID)";

        // �]�m�r���M�r���j�p�]�i�ھڻݨD���^
        textMeshPro1.font = Resources.Load<TMP_FontAsset>("Fonts & Materials/Arial SDF");
        textMeshPro1.fontSize = 30;
        textMeshPro1.alignment = TextAlignmentOptions.Center;

        // �]�m��r���C��]�i�ھڻݨD���^
        textMeshPro1.color = Color.black;

        // �]�m��r���󪺦�m
        textObject1.transform.position = data.OriginPos + new Vector3(3, 0, -5) * spacing;

        // �N��r�������-90��¶Y�b
        textObject1.transform.Rotate(new Vector3(90, 90, 90));
    }
}
