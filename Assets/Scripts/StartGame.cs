using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    void OnMouseUpAsButton()
    {
        SceneManager.LoadScene("Oven");
    }
}