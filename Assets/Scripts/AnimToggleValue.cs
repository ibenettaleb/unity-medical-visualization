using UnityEngine;

public class AnimToggleValue : MonoBehaviour
{
    [SerializeField] private string animeValue = string.Empty;
    [SerializeField] private float maxValue = 1.0f;
    [SerializeField] private float speed = 2.0f;
    private float destValue = 0.0f;
    private float currentValue = 0.0f;

    private Animator animator = null;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        destValue = currentValue = 0.0f;
    }

    public void ToggleValue() {
        destValue = (destValue < maxValue) ? maxValue : 0f;
    }

    private void Update() {
        currentValue = Mathf.Lerp(currentValue, destValue, Time.deltaTime * speed);
        animator.SetFloat(animeValue, Mathf.Round(currentValue * 10) / 10);
    }
}
