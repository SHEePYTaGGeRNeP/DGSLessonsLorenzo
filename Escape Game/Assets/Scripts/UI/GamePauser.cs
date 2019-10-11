using UnityEngine;
using UnityEngine.Audio;

namespace Assets.Scripts.UI
{
    class GamePauser : MonoBehaviour
    {
        private bool _isPaused;
        [SerializeField]
        private AudioMixerSnapshot _paused;

        [SerializeField]
        private AudioMixerSnapshot _unpaused;

        private void Update()
        {
            if (!Input.GetKeyUp(KeyCode.Escape))
                return;
            this._isPaused = !this._isPaused;
            Time.timeScale = this._isPaused ? 0 : 1;
            AudioMixerSnapshot snapshot = this._isPaused ? _paused : _unpaused;
            snapshot.TransitionTo(0);
        }
    }
}
