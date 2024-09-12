using UnityEngine;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq;
using Newtonsoft.Json.Linq;

public class NotificationHandler : MonoBehaviour
{
    public GameObject yellowObject;
    public GameObject blueObject;
    public GameObject redObject;

    private Dictionary<int, GameObject> valueToObjectMap;

    private void Awake()
    {
        // 確保 UnityMainThreadDispatcher 存在
        UnityMainThreadDispatcher.Instance();
    }

    private void Start()
    {
        valueToObjectMap = new Dictionary<int, GameObject>
        {
            { 1, yellowObject },
            { 2, blueObject },
            { 3, redObject }
        };

        // 訂閱 HttpServer 的消息事件
        HttpServer.OnNotificationReceived += ProcessNotification;
    }

    public void ProcessNotification(string jsonText)
    {
        // 確保在主線程上執行整個處理過程
        UnityMainThreadDispatcher.Instance().Enqueue(() =>
        {
            try
            {
                Debug.Log($"處理通知: {jsonText}");
                JObject jsonObject = JObject.Parse(jsonText);
                string xmlContent = jsonObject["m2m:sgn"]["m2m:nev"]["m2m:rep"]["m2m:cin"]["con"].ToString();
                Debug.Log($"提取的XML內容: {xmlContent}");

                XDocument xdoc = XDocument.Parse(xmlContent);
                XElement colorElement = xdoc.Descendants("str")
                    .Where(e => e.Attribute("name")?.Value == "Color")
                    .FirstOrDefault();

                if (colorElement != null && int.TryParse(colorElement.Attribute("val")?.Value, out int val))
                {
                    Debug.Log($"解析的顏色值: {val}");
                    ActivateObjectBasedOnValue(val);
                }
                else
                {
                    Debug.LogWarning("無法找到或解析 Color 值");
                }
            }
            catch (System.Exception e)
            {
                Debug.LogError($"解析錯誤: {e.Message}");
            }
        });
    }

    private void ActivateObjectBasedOnValue(int value)
    {
        foreach (var obj in valueToObjectMap.Values)
        {
            obj.SetActive(false);
        }

        if (valueToObjectMap.TryGetValue(value, out GameObject objectToActivate))
        {
            objectToActivate.SetActive(true);
            Debug.Log($"激活了值為 {value} 的物體");
        }
        else
        {
            Debug.LogWarning($"沒有映射到值 {value} 的物體");
        }
    }

    private void OnDestroy()
    {
        // 取消訂閱，防止內存泄漏
        HttpServer.OnNotificationReceived -= ProcessNotification;
    }
}