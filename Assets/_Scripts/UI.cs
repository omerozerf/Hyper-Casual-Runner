using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace _Scripts
{
    public class UI : MonoBehaviour
    {
        
        public void RestartGame()
        {
            Debug.Log("tıklandım");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}