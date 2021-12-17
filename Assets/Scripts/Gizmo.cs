using UnityEngine;

public class Gizmo : MonoBehaviour
{
    [SerializeField] private float gizmoSize = .75f;
    [SerializeField] private Color gizmoColor = Color.yellow;

    private void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor;
        Gizmos.DrawWireSphere(transform.position, gizmoSize);
    }
}
