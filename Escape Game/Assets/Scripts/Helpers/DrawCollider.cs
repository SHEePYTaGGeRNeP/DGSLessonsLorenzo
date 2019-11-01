using UnityEngine;

namespace Assets.Scripts.Helpers.Components
{
    [RequireComponent(typeof(Collider))]
    class DrawCollider : MonoBehaviour
    {
        [SerializeField]
        private bool _draw = true;

        [SerializeField]
        private Collider _collider;

        [SerializeField]
        private Color _color = Color.magenta;


        protected void OnDrawGizmos()
        {
            if (this._draw)
                Utils.DrawColliderGizmo(this._collider, this._color);
        }

    }
}
