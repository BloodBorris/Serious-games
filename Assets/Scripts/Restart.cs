using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public void StartOver()
    {

        SceneManager.LoadScene("SampleScene");
    }
}
