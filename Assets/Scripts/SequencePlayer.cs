using UnityEngine;

public class SequencePlayer : MonoBehaviour
{
    private int index = 0;

    private void Awake() {
        ResetItems();
    }

    public void ResetItems() {
        if (transform.childCount <= 0) {
            return;
        }
        index = 0;

        for (int i = 0; i < transform.childCount; i++) {
            transform.GetChild(i).gameObject.SetActive(false);
        }

        transform.GetChild(index).gameObject.SetActive(true);
    }
}
