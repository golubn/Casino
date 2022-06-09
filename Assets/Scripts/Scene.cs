using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
   public void LoadScene(int sceneid)
    {
        SceneManager.LoadScene(sceneid);
    }
}
