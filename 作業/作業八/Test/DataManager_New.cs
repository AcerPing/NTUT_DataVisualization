using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;

public class DataManager : MonoBehaviour
{
    IOCData data;
    private void Awake()
    {
        data = GameContainer.Get<IOCData>();
        InitIOCData();
    }
    void Start()
    {
        
    }

    void InitIOCData()
    {
        string allDataPath = Path.Combine(Application.streamingAssetsPath, "AllData");

        if (Directory.Exists(allDataPath))
        {
            // ����Ҧ���Ƨ����|
            string[] folderPaths = Directory.GetDirectories(allDataPath);

            foreach (string folderPath in folderPaths)
            {
                UserData userData = new UserData();

                // �����Ƨ��W�١]�Ǹ�_�W�r�^
                string folderName = Path.GetFileName(folderPath);

                // �ϥΩ��u���ξǸ��M�W�r
                string[] parts = folderName.Split('_');

                if (parts.Length == 2)
                {
                    string studentId = parts[0];
                    string studentName = parts[1];

                    userData.StudentID = studentId;
                    userData.Name = studentName;

                    // Debug.Log($"�Ǹ�: {studentId}, �W�r: {studentName}");

                    ReadSurveyData(folderPath);

                    // �զXtreasureMissiondata.json��������|
                    string jsonFilePath = Path.Combine(folderPath, "treasureMissiondata.json");

                    if (File.Exists(jsonFilePath))
                    {
                        // Ū��JSON�ɮפ��e
                        string json = File.ReadAllText(jsonFilePath);

                        // �ѪRJSON��ƨ�C#����
                        ThemeModelDataWrapper dataWrapper = JsonConvert.DeserializeObject<ThemeModelDataWrapper>(json);

                        // �b�o�̧A�i�H�ϥ� dataWrapper.themeModelDataItems �s�����
                        userData.MissionData = dataWrapper;
                        // Debug.Log($"Read JSON from: {jsonFilePath}");
                    }
                    else
                    {
                        Debug.LogError($"treasureMissiondata.json not found in folder: {folderPath}");
                    }
                    data.AllUserData.Add(userData);
                }
                else
                {
                    Debug.LogWarning($"Invalid folder name format: {folderName}");
                }
            }
        }
        else
        {
            Debug.LogError("AllData folder not found!");
        }

        Debug.LogWarning($"Q1:�D�`���P�N{data.Q1[0]}, ���P�N{data.Q1[1]}, �P�N{data.Q1[2]}, �D�`�P�N{data.Q1[3]}");
        Debug.LogWarning($"Q2:�D�`���P�N{data.Q2[0]}, ���P�N{data.Q2[1]}, �P�N{data.Q2[2]}, �D�`�P�N{data.Q2[3]}");
        Debug.LogWarning($"Q3:�D�`���P�N{data.Q3[0]}, ���P�N{data.Q3[1]}, �P�N{data.Q3[2]}, �D�`�P�N{data.Q3[3]}");
        Debug.LogWarning($"Q4:�D�`���P�N{data.Q4[0]}, ���P�N{data.Q4[1]}, �P�N{data.Q4[2]}, �D�`�P�N{data.Q4[3]}");
        Debug.LogWarning($"Q5:�D�`���P�N{data.Q5[0]}, ���P�N{data.Q5[1]}, �P�N{data.Q5[2]}, �D�`�P�N{data.Q5[3]}");
        Debug.LogWarning($"Q6:�D�`���P�N{data.Q6[0]}, ���P�N{data.Q6[1]}, �P�N{data.Q6[2]}, �D�`�P�N{data.Q6[3]}");
    }

    void ReadSurveyData(string folderPath)
    {
        string jsonFilePath = Path.Combine(folderPath, "themeModelSurveyData.json");

        if (File.Exists(jsonFilePath))
        {
            // Ū��JSON�ɮפ��e
            string json = File.ReadAllText(jsonFilePath);

            // �ѪRJSON��ƨ�C#����
            ThemeModelSurveyDataItem surveyData = JsonConvert.DeserializeObject<ThemeModelSurveyDataItem>(json);
            
            Count(surveyData);
        }
        else
        {
            Debug.LogError($"themeModelSurveyData.json not found in folder: {folderPath}");
        }
    }

    void Count(ThemeModelSurveyDataItem surveyData)
    {
        switch (surveyData.Q1)
        {
            case "StrongDisgree":
                data.Q1[0]++;
                break;
            case "Disgree ":
                data.Q1[1]++;
                break;
            case "Agree ":
                data.Q1[2]++;
                break;
            case "StrongAgree ":
                data.Q1[3]++;
                break;
            default:
                break;
        }

        switch (surveyData.Q2)
        {
            case "StrongDisgree":
                data.Q2[0]++;
                break;
            case "Disgree ":
                data.Q2[1]++;
                break;
            case "Agree ":
                data.Q2[2]++;
                break;
            case "StrongAgree ":
                data.Q2[3]++;
                break;
            default:
                break;
        }

        switch (surveyData.Q3)
        {
            case "StrongDisgree":
                data.Q3[0]++;
                break;
            case "Disgree ":
                data.Q3[1]++;
                break;
            case "Agree ":
                data.Q3[2]++;
                break;
            case "StrongAgree ":
                data.Q3[3]++;
                break;
            default:
                break;
        }

        switch (surveyData.Q4)
        {
            case "StrongDisgree":
                data.Q4[0]++;
                break;
            case "Disgree ":
                data.Q4[1]++;
                break;
            case "Agree ":
                data.Q4[2]++;
                break;
            case "StrongAgree ":
                data.Q4[3]++;
                break;
            default:
                break;
        }

        switch (surveyData.Q5)
        {
            case "StrongDisgree":
                data.Q5[0]++;
                break;
            case "Disgree ":
                data.Q5[1]++;
                break;
            case "Agree ":
                data.Q5[2]++;
                break;
            case "StrongAgree ":
                data.Q5[3]++;
                break;
            default:
                break;
        }

        switch (surveyData.Q6)
        {
            case "StrongDisgree":
                data.Q6[0]++;
                break;
            case "Disgree ":
                data.Q6[1]++;
                break;
            case "Agree ":
                data.Q6[2]++;
                break;
            case "StrongAgree ":
                data.Q6[3]++;
                break;
            default:
                break;
        }
    }
}
