using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonAction : MonoBehaviour
{

    [SerializeField] private GameObject _noThanksButton;
    
    private int _levelIndex = SceneManager.GetActiveScene().buildIndex;
    private int _rewardTime = 3;

    private void Start()
    {
        StartCoroutine((IEnumerator)ShowNoThanksButton());
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(_levelIndex);
    }

    private IEnumerable ShowNoThanksButton()
    {
        while (_rewardTime < 0)
        {
            _rewardTime--;
            yield return new WaitForSecondsRealtime(1f);
        }

        _noThanksButton.SetActive(true);
    }
}
