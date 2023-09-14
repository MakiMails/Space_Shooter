using UnityEngine;

namespace Game.WeaponScripts
{
    internal class Weapon : MonoBehaviour
    {
        [SerializeField] private float _damage;

        public void Shot()
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 10 * hit.distance, Color.green, 1f);
            }
            else
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.red, 1f);
            }
        }

    }
}
