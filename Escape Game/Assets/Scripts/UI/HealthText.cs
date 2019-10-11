using Assets.Scripts.Game;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    [RequireComponent(typeof(Text))]
    class HealthText : MonoBehaviour
    {
        private Text _text;

        [SerializeField]
        private Gradient _gradient;

        private void Awake() { this._text = this.GetComponent<Text>(); }

        public void OnHealthChanged(HealthChangedEventArgs e)
        {
            this._text.text = $"{e.CurrentHealth}/{e.MaxHealth}";
            float fillAmount = (float)e.CurrentHealth / e.MaxHealth;
            this._text.color = _gradient.Evaluate(fillAmount);
        }
    }
}
