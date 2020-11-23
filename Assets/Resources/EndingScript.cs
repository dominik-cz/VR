using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndingScript : MonoBehaviour
{

    public GameObject exitObject;
    public Image img;

    private double startX;
    private double startY;
    private double startZ;
    

    void Start()
    {
        startX = exitObject.transform.position.x;
        startY = exitObject.transform.position.y;
        startZ = exitObject.transform.position.z;

        img.gameObject.SetActive(true);
        img.canvasRenderer.SetAlpha(0.0f);

    }

    void Update()
    {
        if (exitObject.transform.position.x != startX ||
            exitObject.transform.position.y != startY ||
            exitObject.transform.position.z != startZ)
        {
            fadeIn();
            StartCoroutine(TeleportAfterSeconds(5, SceneManager.GetActiveScene().buildIndex - 1));
        }
    }

    void fadeIn()
    {
        img.CrossFadeAlpha(1, 1, false);
    }

















    IEnumerator TeleportAfterSeconds(int seconds, int sceneIndex)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(sceneIndex);
    }
}
