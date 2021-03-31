using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using UnityEngine.Networking;
using Random = System.Random;

public class ComicCollection : MonoBehaviour{
    private int highestIndex;
    private Random random = new Random();
    private void Start(){
        StartCoroutine(Call("https://xkcd.com/info.0.json"));
    }

    public IEnumerator Call(string apiUrl){
        using (UnityWebRequest www = UnityWebRequest.Get(apiUrl)){
            yield return www.SendWebRequest();
            if (www.isNetworkError || www.isHttpError){
                Debug.Log(www.error);
            }
            else{
                JSONNode num = JSON.Parse(www.downloadHandler.text); 
                int.TryParse(num["num"].Value, out highestIndex);
            }
            using (UnityWebRequest.Get($"https://xkcd.com/{random.Next(highestIndex, 1)}/info.0.json")){
                yield return www.SendWebRequest();
                if (www.isNetworkError || www.isHttpError){
                    Debug.Log(www.error);
                }
                else{
                    JSONNode title = JSON.Parse(www.downloadHandler.text); 
                    int.TryParse(title["title"].Value, out highestIndex);
                }
            }
        }
    }
    
    
    // David's code...
    /*
    IEnumerator GetRequest(string url) {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url)) {
            yield return webRequest.SendWebRequest();

            switch (webRequest.responseCode) {
                case UnityWebRequest.kHttpVerbGET.:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError( "Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError( "HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log( "Received: " + webRequest.downloadHandler.text);
                    JSONNode JsonObject = JSON.Parse(webRequest.downloadHandler.text);
                    
                    //Example JSON response:
                    //{
                    //"type": "success",
                    //"value": {
                    //  "id": 485,
                    //  "joke": "Chuck Norris' Internet connection is faster upstream than downstream because even data has more incentive to run from him than to him.",
                    //  "categories": ["nerdy"]
                    // }
                    //}
                    
                    Debug.Log("Check out this AMAZING joke: " + JsonObject["value"]["joke"].Value);
                    Debug.Log("The ID of the joke is: " + JsonObject["value"]["id"].AsInt);
                    
                    break;
            }
        }
    }
    
    void Start() {
        StartCoroutine(GetRequest("http://api.icndb.com/jokes/random?limitTo=%5Bnerdy%5D"));
    }
*/
}