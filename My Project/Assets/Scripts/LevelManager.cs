using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Animator animator; // animator untuk transisi scene

    // Coroutine untuk memuat scene
    private IEnumerator LoadSceneAsync(string sceneName)
    {
            // mulai animasi "End" untuk menandakan transisi
            animator.SetTrigger("End");
            yield return new WaitForSeconds(1);
            SceneManager.LoadSceneAsync(sceneName);
            animator.SetTrigger("Start");

        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            player.transform.position = new Vector2(0, -4.5f);
        }
    }

    // fungsi untuk memulai coroutine LoadSceneAsync
    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneAsync(sceneName));
    }
}
