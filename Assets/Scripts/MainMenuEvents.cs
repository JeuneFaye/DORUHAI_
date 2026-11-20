using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenuEvents : MonoBehaviour
{
    private UIDocument document;
    private Button button;

    private void Awake()
    {
        document = GetComponent<UIDocument>();
        button = document.rootVisualElement.Q("StartGameButton") as Button;
        button.RegisterCallback<ClickEvent>(StartGameClick);
    }

    private void OnDisable()
    {
        button.UnregisterCallback<ClickEvent>(StartGameClick);
    }

    private void StartGameClick(ClickEvent click)
    {
        //Debug.Log("The Start Button is Working!");

        SceneManager.LoadSceneAsync(1);
    }
}
