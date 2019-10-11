using UnityEngine;
using UnityEngine.Audio;

namespace Assets.Scripts.Game
{
    class AudioPitchShifter : MonoBehaviour
    {
        [SerializeField]
        private string _parameterName;
        [SerializeField]
        private AudioMixer _audioMixer;

        [SerializeField]
        private float _offset;
        [SerializeField]
        private float _multiplier = 0.5f;

        public void OnHealthChanged(HealthChangedEventArgs e)
        {
            _audioMixer.SetFloat(this._parameterName, this._offset - ((float)e.CurrentHealth / e.MaxHealth * this._multiplier));            
        }
    }
}
