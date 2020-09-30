using System;
using UnityEngine;

namespace ChinchetaGames
{
    public class ScreenshotCapture : MonoBehaviour
    {
#if UNITY_EDITOR
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                string screenshotName = DateTime.Now.ToString();
                screenshotName = screenshotName.Replace("/", "-");
                screenshotName = screenshotName.Replace(" ", "_");
                screenshotName = screenshotName.Replace(":", "-");

                ScreenCapture.CaptureScreenshot(Application.persistentDataPath + screenshotName + ".png");
                Debug.Log("Screenshot saved at " + Application.persistentDataPath + screenshotName + ".png");
            }
        }
#endif
    }
}