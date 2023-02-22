using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface ISceneLoading
{
    void ReloadScene();
    void LoadScene(string pSceneName);
    void LoadScene(int pSceneIndexNumber);
}
