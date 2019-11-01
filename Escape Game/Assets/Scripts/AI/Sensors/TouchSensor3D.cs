using UnityEngine;

namespace Assets.Scripts.AI.Sensors
{
    [RequireComponent(typeof(Collider))]
    public abstract class TouchSensor3D : TouchSensor
    {
        [Header("TouchSensor3D variable")]
        [SerializeField]
        private Collider _collider;

        protected override void Awake()
        {
            base.Awake();
            if (this._collider == null)
                this._collider = this.GetComponent<Collider>();
        }

        protected override void DebugDrawGizmos()
        {
            if (Application.isPlaying)
                Gizmos.color = this.IsTouching ? Color.red : Color.green;
            else
                Gizmos.color = Color.grey;
            if (this._collider is BoxCollider box)
                Gizmos.DrawWireCube(this.transform.position + box.center, box.size);
            else if (this._collider is SphereCollider sphere)
                Gizmos.DrawWireSphere(this.transform.position + sphere.center, sphere.radius);
            else if (this._collider is CapsuleCollider capsule)
            {
                // draw some spheres to fake capsule
                for (float position = -capsule.height / 2f + capsule.radius;
                    position < (capsule.height / 2f); position += (int)capsule.radius)
                {
                    switch (capsule.direction)
                    {
                        case 0: //x
                            Gizmos.DrawWireSphere(
                                this.transform.position + capsule.center + (this.transform.right * position),
                                capsule.radius);
                            break;
                        case 1: //y
                            Gizmos.DrawWireSphere(
                                this.transform.position + capsule.center + (this.transform.up * position),
                                capsule.radius);
                            break;
                        default: //z
                            Gizmos.DrawWireSphere(
                                this.transform.position + capsule.center + (this.transform.forward * position),
                                capsule.radius);
                            break;
                    }
                }
            }
        }

    }
}
