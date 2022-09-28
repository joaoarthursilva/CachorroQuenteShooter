using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHealthManager : MonoBehaviour
{
    public List<GameObject> fullHearts;
    public List<GameObject> halfHearts;
    public List<GameObject> emptyHearts;
    private PlayerHealth _playerHealth;
    void Start()
    {
        _playerHealth = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>();
    }

    void FixedUpdate()
    {
        switch (_playerHealth.GetCurrentHealth())
        {
            case <=0:
                for (var i = 0; i < fullHearts.Count; i++)
                {
                    fullHearts[i].SetActive(false);
                    halfHearts[i].SetActive(false);
                    emptyHearts[i].SetActive(true);
                }
                break;
            case 1:
                fullHearts[0].SetActive(false);
                halfHearts[0].SetActive(true);
                emptyHearts[0].SetActive(false);
                
                fullHearts[1].SetActive(false);
                halfHearts[1].SetActive(false);
                emptyHearts[1].SetActive(true);
                
                fullHearts[2].SetActive(false);
                halfHearts[2].SetActive(false);
                emptyHearts[2].SetActive(true);
                break;
            case 2:
                fullHearts[0].SetActive(true);
                halfHearts[0].SetActive(false);
                emptyHearts[0].SetActive(false);
                
                fullHearts[1].SetActive(false);
                halfHearts[1].SetActive(false);
                emptyHearts[1].SetActive(true);
                
                fullHearts[2].SetActive(false);
                halfHearts[2].SetActive(false);
                emptyHearts[2].SetActive(true);
                
                break;
            case 3:fullHearts[0].SetActive(true);
                halfHearts[0].SetActive(false);
                emptyHearts[0].SetActive(false);
                
                fullHearts[1].SetActive(false);
                halfHearts[1].SetActive(true);
                emptyHearts[1].SetActive(false);
                
                fullHearts[2].SetActive(false);
                halfHearts[2].SetActive(false);
                emptyHearts[2].SetActive(true);
                
                break;
            case 4:
                fullHearts[0].SetActive(true);
                halfHearts[0].SetActive(false);
                emptyHearts[0].SetActive(false);
                
                fullHearts[1].SetActive(true);
                halfHearts[1].SetActive(false);
                emptyHearts[1].SetActive(false);
                
                fullHearts[2].SetActive(false);
                halfHearts[2].SetActive(false);
                emptyHearts[2].SetActive(true);
                break;
            case 5:
                fullHearts[0].SetActive(true);
                halfHearts[0].SetActive(false);
                emptyHearts[0].SetActive(false);
                
                fullHearts[1].SetActive(true);
                halfHearts[1].SetActive(false);
                emptyHearts[1].SetActive(false);
                
                fullHearts[2].SetActive(false);
                halfHearts[2].SetActive(true);
                emptyHearts[2].SetActive(false);
                break;
            case 6:
                for (var i = 0; i < fullHearts.Count; i++)
                {
                    fullHearts[i].SetActive(true);
                    halfHearts[i].SetActive(false);
                    emptyHearts[i].SetActive(false);
                }
                break;
            default:
                break;
        }
    }
}