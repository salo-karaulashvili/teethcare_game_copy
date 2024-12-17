using UnityEngine;

[ExecuteAlways]
public class SoundPlayer : MonoBehaviour
{
    [SerializeField] SoundManager soundManager;

    void Start()
    {
        if (soundManager == null) { soundManager = FindObjectOfType<SoundManager>(); }
    }

    public void PlaySFX(string soundID) { soundManager.PlaySFX(soundID); }
}