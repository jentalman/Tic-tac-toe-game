using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class ReloadButton : MonoBehaviour
    {
        public void ReloadGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
