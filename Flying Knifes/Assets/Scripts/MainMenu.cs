using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject LevelsFrame;

    public void Show()
    {
        LevelsFrame.SetActive(true);
    }

    public void Hide()
    {
        LevelsFrame.SetActive(false);
    }
}