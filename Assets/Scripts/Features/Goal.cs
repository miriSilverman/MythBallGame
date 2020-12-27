using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            StartCoroutine(winning());
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }

        IEnumerator winning()
        {
            GameController.Instance.Winning();
            yield return new WaitForSeconds(5f);
        }
    }

}
