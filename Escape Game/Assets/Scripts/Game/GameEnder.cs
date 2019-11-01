using Assets.Scripts.Game;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    class GameEnder : MonoBehaviour
    {

        public void OnPlayerHealthChanged(HealthChangedEventArgs e)
        {
            if (e.CurrentHealth != 0)
                return;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
