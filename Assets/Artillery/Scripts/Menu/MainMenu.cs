using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{
    private VisualElement _root;

    private Button _startButton;
    private Button _levelChooseButton;
    private Button _exitButton;

    private void Awake() => _root = GetComponent<UIDocument>().rootVisualElement;

    private void OnEnable()
    {
        _startButton = _root.Q<Button>("Start");
        _startButton.clicked += StartGame;
        
        _levelChooseButton = _root.Q<Button>("LevelChoose");
        _levelChooseButton.clicked += ToLevelChoose;
        
        _exitButton = _root.Q<Button>("Exit");
        _exitButton.clicked += Leave;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ToLevelChoose()
    {
        
    }

    public void Leave() => Application.Quit();
}