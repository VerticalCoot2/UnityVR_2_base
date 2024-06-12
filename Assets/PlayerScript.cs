using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public TextMesh remainingText;
    public float speed = 3f;

    public int collectiblesRemaining = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, 0, -1) * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Finish")
        {
            speed = 0;
            StartCoroutine(Restart());
        }
    }

    IEnumerator Restart()
    {
        while (true)
        {
            yield return new WaitForSeconds(5f);
            SceneManager.LoadScene("Demo");
        }
    }

    public void Collect()
    {
        --collectiblesRemaining;
        remainingText.text = "Remaining: " + collectiblesRemaining;
    }
}
