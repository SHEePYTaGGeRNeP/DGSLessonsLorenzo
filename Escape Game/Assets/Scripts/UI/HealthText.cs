using Assets.Scripts.Game;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    [RequireComponent(typeof(Text))]
    class HealthText : MonoBehaviour
    {
        private Text _text;

        private void Awake() { this._text = this.GetComponent<Text>(); }

        public void OnHealthChanged(HealthChangedEventArgs eventArgs) { this._text.text = $"{eventArgs.CurrentHealth}/{eventArgs.MaxHealth}"; }
    }
}
