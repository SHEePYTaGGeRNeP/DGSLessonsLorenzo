using Assets.Scripts.Game;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    class GameEnder : MonoBehaviour
    {
        public void PlayerHealthReachedZero()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
