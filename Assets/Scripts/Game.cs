﻿using System.Collections.Generic;
using System.Linq; // algumas funcções adicionais
using UnityEngine;

public class Game : MonoBehaviour
{
    public GameObject coinPrefab;

    public GameObject inimigoPrefab;

    public List<Transform> spawnPoints = new List<Transform>();

    public List<Coin> listCoins = new List<Coin>();
    public List<Inimigo> listInimigos = new List<Inimigo>();

    //quantidade de inimigos para spawnar
    [SerializeField]
    private int quantityOfEnemies = 5;

    // Use this for initialization
    private void Start()
    {
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                GameObject go = Instantiate(coinPrefab, new Vector3(i * 1.0f, 2, j * -1.0f), Quaternion.identity);

                listCoins.Add(go.GetComponent<Coin>());
            }
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (listCoins.Count == 80)
        {
            print("POUCAS MOEDAS");

            for (int i = 0; i < quantityOfEnemies; i++)
            {
                if (spawnPoints.Any()) // caso tenha algum elemento na lista
                {
                    int pos = Random.Range(0, spawnPoints.Count - 1);
                    spawnEnemy(spawnPoints[pos].position);

                    spawnPoints.RemoveAt(pos);
                }
                else break;
            }
        }
    }

    public void RemoveCoinFromList(GameObject coin)
    {
        if (coin.GetComponent<Coin>())
        {
            listCoins.Remove(coin.GetComponent<Coin>());
        }
    }

    private void spawnEnemy(Vector3 position)
    {
        GameObject go = Instantiate(inimigoPrefab, position, Quaternion.identity);

        listInimigos.Add(go.GetComponent<Inimigo>());
    }
}