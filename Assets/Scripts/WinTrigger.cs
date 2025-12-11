using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinTrigger : MonoBehaviour
{
    public GameObject youWinText;
    public areOpponentsDead winState;
    public float delay;

    // Start is called before the first frame update
    void Start()
    {
        youWinText.SetActive(false);
    }

    void OnTriggerEnter (Collider other)
    {
        winState.CheckEnemyCount();
        print(winState.listOfOpponents.Count);
        if (other.gameObject.tag == "Player" && winState.AreOpponentsDead() == true)
        {
            youWinText.SetActive(true);
            StartCoroutine(Countdown());
        }
    }

    IEnumerator Countdown()
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(2);
    }

}
