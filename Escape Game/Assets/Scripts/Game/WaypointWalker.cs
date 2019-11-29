using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Game
{
    using Assets.Scripts;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using System.Linq;

    public class WaypointWalker : MonoBehaviour
    {
        // Start is called before the first frame update
        [SerializeField]
        private Transform[] _waypoints;

        [SerializeField]
        private SimpleMovement characterControl;

        [SerializeField]
        private float _tolerance = 0.5f;


        [Header("Debug")]
        [SerializeField]
        private float _distance;

        private LinkedList<Vector3> _waypointLocations;
        private LinkedListNode<Vector3> _targetNode;


        private void Awake()
        {
            this._waypointLocations = new LinkedList<Vector3>(this._waypoints.Select(x => x.position));
            this._waypointLocations.AddLast(this.transform.position);
            this._targetNode = this._waypointLocations.First;
        }

        // Upda te is called once per frame
        private void Update()
        {
            this._distance = Vector3.Distance(this.transform.position, this._targetNode.Value);
            if (this._distance < this._tolerance)
            {
                this.MoveToNextNode();
            }
            Vector3 targetPos = this._targetNode.Value;
            Vector3 remain = Utils.ObjectSide(this.transform, targetPos);
            this.characterControl.MoveByInput(remain.x, 1f);
        }

        private void MoveToNextNode()
        {
            LogHelper.Log(typeof(WaypointWalker), "Moving to new waypoint");
            this._targetNode = this._targetNode.Next ?? this._waypointLocations.First;
        }
    }

}
