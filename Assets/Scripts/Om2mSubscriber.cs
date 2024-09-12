using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class Om2mSubscriber : MonoBehaviour
{
    private string origin = "admin:admin"; // OM2M CSE 的憑證
    private string cseUrl = "http://192.168.111.128:8080/~/mn-cse/mn-name/UNITY/DATA"; // 替換為你的 OM2M 容器 URL
    private string notificationUrl = "http://192.168.50.168:8080/"; // 訂閱時要發送的通知地址，這是你的 HTTP 伺服器地址
    private string subscriptionName = "unitysubscribe"; // 訂閱的名稱

    void Start()
    {
        StartCoroutine(DeleteAndSubscribe());
    }

    IEnumerator DeleteAndSubscribe()
    {
        // 首先嘗試刪除現有訂閱
        yield return StartCoroutine(DeleteSubscription());
        
        // 然後創建新的訂閱
        yield return StartCoroutine(SubscribeRequest());
    }

    IEnumerator DeleteSubscription()
    {
        string deleteUrl = $"{cseUrl}/{subscriptionName}";
        UnityWebRequest uwr = UnityWebRequest.Delete(deleteUrl);
        uwr.SetRequestHeader("X-M2M-Origin", origin);
        uwr.SetRequestHeader("X-M2M-RI", "12345");
        uwr.certificateHandler = new BypassCertificate();

        yield return uwr.SendWebRequest();

        if (uwr.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("舊訂閱刪除成功");
        }
        else
        {
            Debug.Log("舊訂閱不存在或刪除失敗，將繼續創建新訂閱");
        }
    }

    IEnumerator SubscribeRequest()
    {
        string json = $"{{\"m2m:sub\": {{\"rn\": \"{subscriptionName}\", \"nu\": [\"{notificationUrl}\"], \"nct\": 2}}}}";

        UnityWebRequest uwr = new UnityWebRequest(cseUrl, "POST");
        byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
        uwr.uploadHandler = new UploadHandlerRaw(jsonToSend);
        uwr.downloadHandler = new DownloadHandlerBuffer();
        uwr.SetRequestHeader("Content-Type", "application/json;ty=23");
        uwr.SetRequestHeader("X-M2M-Origin", origin);
        uwr.SetRequestHeader("X-M2M-RI", "12345");
        uwr.certificateHandler = new BypassCertificate();

        yield return uwr.SendWebRequest();

        if (uwr.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("訂閱成功: " + uwr.downloadHandler.text);
        }
        else
        {
            Debug.LogError("訂閱失敗: " + uwr.error);
        }
    }

    private class BypassCertificate : CertificateHandler
    {
        protected override bool ValidateCertificate(byte[] certificateData)
        {
            return true;
        }
    }
}