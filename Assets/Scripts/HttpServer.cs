using System.Net;
using System.Threading.Tasks;
using UnityEngine;
using System;

public class HttpServer : MonoBehaviour
{
    private HttpListener listener;

    // 添加一個靜態事件
    public static event Action<string> OnNotificationReceived;

    void Start()
    {
        listener = new HttpListener();
        listener.Prefixes.Add("http://192.168.50.168:8080/"); // 設定你的 IP 和端口
        listener.Start();
        Debug.Log("Listening for notifications...");
        Task.Run(() => Listen());
    }

    async Task Listen()
    {
        while (true)
        {
            var context = await listener.GetContextAsync();
            var request = context.Request;
            var response = context.Response;

            // 讀取通知數據
            string body;
            using (var reader = new System.IO.StreamReader(request.InputStream))
            {
                body = reader.ReadToEnd();
            }

            Debug.Log("Received notification: " + body);

            // 在主線程上觸發事件
            UnityMainThreadDispatcher.Instance().Enqueue(() => OnNotificationReceived?.Invoke(body));

            // 回應 OM2M
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes("Notification received");
            response.OutputStream.Write(buffer, 0, buffer.Length);
            response.Close();
        }
    }

    private void OnDestroy()
    {
        listener.Stop();
    }
}