using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tile_generator : MonoBehaviour
{
    public GameObject[] tile_prefabs;
    public GameObject diamond_prefab; // Префаб алмаза
    private float tile_size = 10.0f;
    public Transform player_transform;
    private float player_last_transform_x;
    private float player_last_transform_z;
    public int number_of_tile_x;
    public int number_of_tile_z;

    public GameObject parent_object;
    Hashtable tiles = new Hashtable();

    // Seed для фиксированной генерации случайных чисел
    public int randomSeed = 1234834; // Измените это значение по вашему желанию

    private int targetScore = 1; // Целевое количество очков

    // Start is called before the first frame update
    void Start()
    {
        // Инициализируем генератор случайных чисел с фиксированным seed
        Random.InitState(randomSeed);

        player_last_transform_x = player_transform.position.x;
        player_last_transform_z = player_transform.position.z;
        for (int i = -number_of_tile_x; i < number_of_tile_x; i++)
        {
            for (int j = -number_of_tile_z; j < number_of_tile_z; j++)
            {
                int picked_tile = Random.Range(0, tile_prefabs.Length);

                Vector3 pos = new Vector3((i * tile_size + frnd(player_transform.position.x)), 0.0f, (j * tile_size + frnd(player_transform.position.z)));

                GameObject t = (GameObject)Instantiate(tile_prefabs[picked_tile]);
                t.transform.position = pos;
                t.transform.Rotate(0.0f, (Random.Range(0, 5) * 90.0f), 0.0f, Space.Self);

                string tile_name = "Tile_" + ((int)(pos.x)).ToString() + "_" + ((int)(pos.z)).ToString();
                t.name = tile_name;
                tiles.Add(tile_name, t);

                t.transform.parent = parent_object.transform;

                // Проверяем, является ли текущий тайл пятым в списке
                if (i % 4 == 0 && j % 4 == 0)
                {
                    // Размещаем алмаз в центре текущего тайла
                    Vector3 diamondPos = t.transform.position + new Vector3(0.0f, 0.5f, 0.0f);
                    GameObject diamond = (GameObject)Instantiate(diamond_prefab);
                    diamond.transform.position = diamondPos;

                    // Назначаем скрипт DiamondCollector к алмазу
                    DiamondCollector diamondCollector = diamond.AddComponent<DiamondCollector>();
                    diamondCollector.targetScore = targetScore; // Передаем целевое количество очков

                    // Увеличиваем целевое количество очков
                    targetScore++;
                }
            }
        }
    }

    void Update()
    {
        int x_move = (int)(player_transform.position.x - player_last_transform_x);
        int z_move = (int)(player_transform.position.z - player_last_transform_z);

        if (Mathf.Abs(x_move) >= tile_size || Mathf.Abs(z_move) >= tile_size)
        {
            player_last_transform_x = player_transform.position.x;
            player_last_transform_z = player_transform.position.z;
            generate_tiles();
        }
    }

    void generate_tiles()
    {
        for (int i = -number_of_tile_x; i < number_of_tile_x; i++)
        {
            for (int j = -number_of_tile_z; j < number_of_tile_z; j++)
            {
                int picked_tile = Random.Range(0, tile_prefabs.Length);
                Vector3 pos = new Vector3(i * tile_size + frnd(player_transform.position.x), 0.0f, j * tile_size + frnd(player_transform.position.z));
                string tile_name = "Tile_" + ((int)(pos.x)).ToString() + "_" + ((int)(pos.z)).ToString();

                if (!tiles.ContainsKey(tile_name))
                {
                    GameObject t = (GameObject)Instantiate(tile_prefabs[picked_tile]);
                    t.transform.position = pos;
                    t.transform.Rotate(0.0f, (Random.Range(0, 5) * 90.0f), 0.0f, Space.Self);
                    tiles.Add(tile_name, t);
                    t.name = tile_name;
                    t.transform.parent = parent_object.transform;

                    // Проверяем, является ли текущий тайл пятым в списке
                    if (i % 4 == 0 && j % 4 == 0)
                    {
                        // Размещаем алмаз в центре текущего тайла
                        Vector3 diamondPos = t.transform.position + new Vector3(0.0f, 0.5f, 0.0f);
                        GameObject diamond = (GameObject)Instantiate(diamond_prefab);
                        diamond.transform.position = diamondPos;

                        // Назначаем скрипт DiamondCollector к алмазу
                        DiamondCollector diamondCollector = diamond.AddComponent<DiamondCollector>();
                        diamondCollector.targetScore = targetScore; // Передаем целевое количество очков

                        // Увеличиваем целевое количество очков
                        targetScore++;
                    }
                }
            }
        }
    }

    float frnd(float num)
    {
        return Mathf.Floor(num / 10) * 10;
    }
}