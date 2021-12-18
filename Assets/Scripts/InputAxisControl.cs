using UnityEngine;
using UnityEngine.EventSystems;
using Cinemachine;

public class InputAxisControl : MonoBehaviour
{
    private CinemachineFreeLook m_camera = null;
    private CinemachineFreeLook.Orbit[] originalOrbit = new CinemachineFreeLook.Orbit[3];

    [SerializeField] [Range(-8f, 8f)] private float zoomRange = 0f;
    [SerializeField] private float mouseWheelSpeed = 2f;
    [SerializeField] private float zoomDampSpeed = 2f;

    private void Awake() {
        m_camera = GetComponent<CinemachineFreeLook>();
        CinemachineCore.GetInputAxis = GetAxisCustom;

        for (int i = 0; i < 3; i++) {
            originalOrbit[i] = m_camera.m_Orbits[i];
        }
    }

    float GetAxisCustom(string Axis) {
        if (Axis.Equals("Horizontal")) {
            if (EventSystem.current.currentSelectedGameObject != null) {
                return 0;
            }
            #if UNITY_EDITOR || UNITY_STANDALONE
            if (Input.GetMouseButton(0)) {
                return Input.GetAxis("Mouse X");
            }
            #endif
            #if UNITY_IOS || UNITY_ANDROID
            if (Input.touchCount > 0) {
                return Input.GetTouch(0).deltaPosition.x;
            }
            #endif
            return Input.GetAxisRaw("Horizontal");
        }

        if (Axis.Equals("Vertical")) {
            if (EventSystem.current.currentSelectedGameObject != null) {
                return 0;
            }
            #if UNITY_EDITOR || UNITY_STANDALONE
            if (Input.GetMouseButton(0)) {
                return Input.GetAxis("Mouse Y");
            }
            #endif
            #if UNITY_IOS || UNITY_ANDROID
            if (Input.touchCount > 0) {
                return Input.GetTouch(0).deltaPosition.y;
            }
            #endif
            return Input.GetAxisRaw("Vertical");
        }

        return 0f;
    }

    private void Update() {
        ScaleOrbits();
    }

    void ScaleOrbits() {
        if (Mathf.Abs(Input.mouseScrollDelta.y) == 0) {
            return;
        }

        zoomRange -= Input.mouseScrollDelta.y * mouseWheelSpeed;
        zoomRange = Mathf.Clamp(zoomRange, -8f, 8f);

        for (int i = 0; i < 3; i++) {
            m_camera.m_Orbits[i].m_Radius = Mathf.Lerp(m_camera.m_Orbits[i].m_Radius, m_camera.m_Orbits[i].m_Radius + zoomRange, Time.deltaTime * zoomDampSpeed);
        }
    }
}
