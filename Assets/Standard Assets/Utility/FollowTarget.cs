using System;
using UnityEngine;


namespace UnityStandardAssets.Utility
{
    public class FollowTarget : MonoBehaviour
    {
        public Transform target;
        public Vector3 offset = new Vector3(0f, 7.5f, 0f);
        public GameObject player;


        private void LateUpdate()
        {
            if (player == null)
            {
                player = GameObject.Find("Bullet(Clone)");
            }
            transform.position = target.position + offset;
        }
    }
}
