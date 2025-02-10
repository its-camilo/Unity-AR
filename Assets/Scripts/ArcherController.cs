using UnityEngine;
using UnityEngine.UI;

public class ArcherController : MonoBehaviour
{
    private Toggle hipHopToggle;
    private Toggle rumbaToggle;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        hipHopToggle = GameObject.Find("HipHop").GetComponent<Toggle>();
        rumbaToggle = GameObject.Find("Rumba").GetComponent<Toggle>();
        hipHopToggle.onValueChanged.AddListener(OnHipHopToggleChanged);
        rumbaToggle.onValueChanged.AddListener(OnRumbaToggleChanged);
    }

    private void OnHipHopToggleChanged(bool isOn)
    {
        animator.SetBool("HipHop", isOn);
    }

    private void OnRumbaToggleChanged(bool isOn)
    {
        animator.SetBool("Rumba", isOn);
    }
}
