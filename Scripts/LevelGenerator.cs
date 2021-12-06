using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using  DG.Tweening;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject startPlatform,endPlatform,platformPrefab;

    private float blockWidth = 0.5f;
    private float blockHeight = 0.2f;


  private int ammounToSpawn = 50;

  private int beginAmmount = 0;

  private Vector3 lastPos;

  //private List<GameObject> spawnedPlarforms = new List<GameObject>();

  [SerializeField] 
  private GameObject playerPrefab;

  private void Awake()
  {
      Instantiate(playerPrefab,new Vector3(0f,1f,0f),Quaternion.identity);

      StartCoroutine(nameof(AutoGenerate));
  }




  void InstantiateLevel()
  {
      for (int i = beginAmmount; i < ammounToSpawn; i++)
      {
          GameObject newPlatform;
           newPlatform = Instantiate(platformPrefab);
         

          newPlatform.transform.parent = transform;
          
      

          int left = Random.Range(0, 2);
          if (left == 0)
          {
              newPlatform.transform.position = new Vector3(lastPos.x - blockWidth, lastPos.y + blockHeight, lastPos.z);
          }
          else
          {
              newPlatform.transform.position = new Vector3(lastPos.x, lastPos.y + blockHeight, lastPos.z + blockWidth);
          }

          lastPos = newPlatform.transform.position;
          //fancy anim
          if (i < 25)
          {
              float endPos = newPlatform.transform.position.y;
              newPlatform.transform.position =
                  new Vector3(newPlatform.transform.position.x, newPlatform.transform.position.y - blockHeight * 3f,
                      newPlatform.transform.position.z);

              newPlatform.transform.DOLocalMoveY(endPos, 0.3f).SetDelay(i * 0.1f);
          }
      }
      
  }

  IEnumerator AutoGenerate()
  {
      while (true)
      {
          InstantiateLevel();
          yield return new WaitForSeconds(5f);
      }
         
      
  }
    
    
    
    
    
    
    
    
}//class
