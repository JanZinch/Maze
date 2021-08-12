using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GUIManager : MonoBehaviour
{
    public const int MainMenuScene = 0;
    public const int GameSessionScene = 1;

    [SerializeField] private RectTransform _mainMenu = null;
    [SerializeField] private RectTransform _settingsMenu = null;
    [SerializeField] private Slider _difficultySlider = null;
    [SerializeField] private float _buttonSpeed = 2.0f;

    [SerializeField] private MovingConstraints _menuPositions = default;

    [Serializable]
    private struct MovingConstraints {

        public RectTransform Left;
        public RectTransform Center;
        public RectTransform Right;    
    }


    public void StartGame() {

        SceneManager.LoadScene(GameSessionScene);    
    }

    public void ExitGame()
    {        
        Application.Quit();        
    }

    private IEnumerator Move(RectTransform current, RectTransform target, Action callback = null) {

        while (current.anchoredPosition != target.anchoredPosition) {

            current.anchoredPosition = Vector2.MoveTowards(current.anchoredPosition, target.anchoredPosition, _buttonSpeed * Time.deltaTime);
            yield return null;
        }

        callback?.Invoke();

        yield return null;    
    }


    public void ViewSettings() {

        StartCoroutine(Move(_mainMenu, _menuPositions.Left, () => _mainMenu.gameObject.SetActive(false)));
        _settingsMenu.gameObject.SetActive(true);
        StartCoroutine(Move(_settingsMenu, _menuPositions.Center));    
    }

    public void ViewMainMenu()
    {
        StartCoroutine(Move(_settingsMenu, _menuPositions.Right, () => _settingsMenu.gameObject.SetActive(false)));
        _mainMenu.gameObject.SetActive(true);
        StartCoroutine(Move(_mainMenu, _menuPositions.Center));
    }

    public void SetDifficultyLevel(Slider difficultySlider)
    {
        difficultySlider.value = (float)GameManager.DifficultyLevel;
    }

    public void ChangeDifficultyLevel(Slider difficultySlider)
    {        
        GameManager.DifficultyLevel = (Difficulty)difficultySlider.value;
    }

    private void Awake()
    {
        SetDifficultyLevel(_difficultySlider);
    }

}