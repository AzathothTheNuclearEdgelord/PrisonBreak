using System;
using System.Collections;
using UnityEngine;
using SimpleJSON;
using UnityEngine.Networking;
using UnityEngine.UI;
using Random = System.Random;

public class ComicCollection : MonoBehaviour {
    private Collider collider;
    private int highestIndex;
    private Random random = new Random();
    private Texture comicTexture;
    private string comicURL;
    public GameObject comicTitle;
    private Renderer renderer;

    private void Start() {
        collider = GetComponent<Collider>();
        renderer = GetComponent<Renderer>();
        StartCoroutine(Call("https://xkcd.com/info.0.json"));
    }

    // First get the latest comic in order to get the latest index...
    public IEnumerator Call(string apiUrl) {
        using (UnityWebRequest www = UnityWebRequest.Get(apiUrl)) {
            yield return www.SendWebRequest();
            if (www.isNetworkError || www.isHttpError) {
                Debug.Log(www.error);
            }
            else {
                JSONNode num = JSON.Parse(www.downloadHandler.text);
                int.TryParse(num["num"].Value, out highestIndex);
                print(highestIndex);
                StartCoroutine(GetURL($"https://xkcd.com/{random.Next(highestIndex)}/info.0.json"));
            }
        }
    }

    // ...then get a random comic based on the latest index...
    public IEnumerator GetURL(string apiUrl) {
        Debug.Log(apiUrl);
        using (UnityWebRequest www = UnityWebRequest.Get(apiUrl)) {
            yield return www.SendWebRequest();
            if (www.isNetworkError || www.isHttpError) {
                Debug.Log(www.error);
            }
            else {
                JSONNode comic = JSON.Parse(www.downloadHandler.text);
                comicTitle.GetComponent<Text>().text = comic["title"];
                StartCoroutine(GetComicImage(comic["img"]));
            }
        }
    }

    // ...download said comic and toss it into a texture variable.
    public IEnumerator GetComicImage(string apiURL) {
        using (UnityWebRequest www = UnityWebRequestTexture.GetTexture(apiURL)) {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError) {
                Debug.Log(www.error);
            }
            else {
                // Get downloaded texture
                comicTexture = DownloadHandlerTexture.GetContent(www);
                print($"Image height: {comicTexture.height}, Image width: {comicTexture.width}");
                renderer.material.SetTexture("_MainTex", comicTexture);
            }
        }
    }

    private void OnCollisionEnter(Collision other) {
        Debug.Log("TRIGGERED");
        if (other.gameObject.CompareTag("Player")) {
            comicTitle.SetActive(true);
            Debug.Log("Player entered the zone");
        }
    }
    private void OnCollisionExit() {
            comicTitle.gameObject.SetActive(false);
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