using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Animator animator; // animator untuk transisi scene

    void Awake()
    {
        animator.enabled = false;
    }
    // Coroutine untuk memuat scene
    private IEnumerator LoadSceneAsync(string sceneName)
    {
       // mulai animasi "End" untuk menandakan transisi
       animator.enabled = true;

        yield return new WaitForSeconds(1);

        SceneManager.LoadSceneAsync(sceneName);

        animator.SetTrigger("Start");

        Player.Instance.transform.position = new(0, -4.5f);
    }

    // fungsi untuk memulai coroutine LoadSceneAsync
    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneAsync(sceneName));
    }
}
