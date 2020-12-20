using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChange : MonoBehaviour
{
    public void ShowHistory()
    {
        SceneManager.LoadScene("ViewHistory");
    }

    public void ShowPractical()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void ShowProcedure()
    {
        SceneManager.LoadScene("ViewProcedure");
    }
}
