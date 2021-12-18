using UnityEngine;
using UnityEngine.EventSystems;
using Cinemachine;

public class InputAxisControl : MonoBehaviour
{
    private void Awake() {
        CinemachineCore.GetInputAxis = GetAxisCustom;
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
}
