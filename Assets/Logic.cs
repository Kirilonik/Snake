using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Events;
using UnityEditor;

public class Logic : MonoBehaviour
{
    public List<Transform> Tails;
    [Range(0, 4)]
    public float BonesDistance;
    public GameObject BonePrefab;
    [Range(0,8)]
    public float Speed;
   

    private Transform _transform;

    public UnityEvent OnEat;
    public bool FruitAte = false;
    public GameObject Fruit;
   
    private void Start()
    {
        _transform = GetComponent<Transform>();
        ScoreCountSave.ShowBestScore();
    }

    private void Update()
    {
        MoveSnake(_transform.position + _transform.forward * Speed * Time.deltaTime);
        // удобный способо задать движение для обьекта
        float angel = Input.GetAxis("Horizontal")*2.5f; // когда d - 1, a - -1, ничего - 0;
        //
        // управление с телефона.
        //
        _transform.Rotate(0, angel, 0);
    }

    private void MoveSnake(Vector3 newPosition)
    {
        float sqrDistance = BonesDistance * BonesDistance;
        Vector3 previousPosition = _transform.position;

        foreach ( var bone in Tails)
        {
            if ((bone.position - previousPosition).sqrMagnitude > sqrDistance)
            {
                var temp = bone.position;
                bone.position = previousPosition;
                previousPosition = temp;
            }
            else
            {
                break;
            }
        }
        _transform.position = newPosition;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "food")
        {
            ScoreCountSave.ScoreInt += 1;
            ScoreCountSave.ShowBestScore();
            //Destroy(collision.gameObject);
            collision.gameObject.SetActive(false);

            var Bone = Instantiate(BonePrefab);
            Bone.transform.position = new Vector3(0, 0, 0);
            Tails.Add(Bone.transform);

            if (OnEat != null)
                OnEat.Invoke();

            FruitAte = true;
            SpawnNewFruit();
        }
    }

    private void SpawnNewFruit()
    {
        if (FruitAte) { 
        int posY = Random.Range(-34, -3);
        int posX = Random.Range(-18, 14);
        int angel = Random.Range(10, 80);
        Vector3 pos = new Vector3(posX, 0.5f, posY);
        Quaternion ang = new Quaternion(0, angel, 0, 0);
            Fruit.transform.position = pos;
            Fruit.transform.rotation = ang;
            Fruit.SetActive(true);
        }
        FruitAte = false;
    }
}
