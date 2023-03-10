using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public static int cameratype = 0;
    public static int ReturnCameraType()
    {
        return cameratype;
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Battle");
    }
    // Color
    public void NormalColor()
    {
        Wilberforce.Colorblind CameraMenu = Camera.main.gameObject.GetComponent<Wilberforce.Colorblind>();
        CameraMenu.Type = 0;
        cameratype = 0;
    }
    public void Protanopia()
    {
        Wilberforce.Colorblind CameraMenu = Camera.main.gameObject.GetComponent<Wilberforce.Colorblind>();
        CameraMenu.Type = 1;
        cameratype = 1;
    }
    public void Deuteranopia()
    {
        Wilberforce.Colorblind CameraMenu = Camera.main.gameObject.GetComponent<Wilberforce.Colorblind>();
        CameraMenu.Type = 2;
        cameratype = 2;
    }
    public void Tritanopia()
    {
        Wilberforce.Colorblind CameraMenu = Camera.main.gameObject.GetComponent<Wilberforce.Colorblind>();
        CameraMenu.Type = 3;
        cameratype = 3;
    }
    // 2
    public void Quit()
    {
        Application.Quit();
    }
}
