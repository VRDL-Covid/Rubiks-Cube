using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoloCamera : MonoBehaviour, IGazeTap
{
    public bool snapIt = false;
    public bool startStop = false;
    Texture2D texture;
    public ImageProcessTrial imageManager;
    void Start()
    {
        this.GetComponent<Renderer>().material.EnableKeyword("_MAINTEX");
        webcam = new WebCamTexture();

        webcam.Play();

        print($"webcam: {webcam.deviceName},{webcam.height}, width:{webcam.width} ");

        toggleStartStop();
    }

    public void toggleStartStop()
    {
        startStop = !startStop;
        if (startStop)
            StartCoroutine("DoCapture");
        else
            StopCoroutine("DoCapture");
    }

    WebCamTexture webcam;
    public void OnSelect()
    {
        print($"onselect ");
        snapIt = true;
    }

    public void TakePhoto()
    {
        print($"TakePhoto ");

        Texture2D webcamImage = new Texture2D(webcam.width, webcam.height);
        webcamImage.SetPixels(webcam.GetPixels());
        webcamImage.Apply();
        if (snapIt)
        {
            imageManager.ParseFace(webcamImage);
            SaveImageToDisk(webcamImage);
            snapIt = false;
        }
    
        //this.GetComponent<Renderer>().material.mainTexture = webcamImage;
        float aspectRatio = (float)webcamImage.width / webcamImage.height;
        Vector3 scale = this.GetComponent<Renderer>().transform.localScale;
        scale.x = scale.y * aspectRatio;
        this.GetComponent<Renderer>().transform.localScale = scale;
        GetComponent<Renderer>().material.SetTexture("_MainTex", webcamImage);

    }

    public void SaveImageToDisk(Texture2D image)
    {

        byte[] bytes = image.EncodeToPNG();
        var dirPath = Application.persistentDataPath + "/SaveImages/";
        if (!System.IO.Directory.Exists(dirPath))
        {
            System.IO.Directory.CreateDirectory(dirPath);
        }
         System.IO.File.WriteAllBytes($"{dirPath}Image{System.DateTime.Now.Second}.png", bytes);
    }

    IEnumerator DoCapture()
    {
        for (; ; )
        {
            TakePhoto();
            yield return new WaitForSeconds(1f);
        }
    }
}
