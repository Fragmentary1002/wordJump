// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using TMPro;

// public class Enemy : MonoBehaviour, IPrototype
// {
//     [SerializeField]
//     SpriteRenderer charRenderer;

//     public GameObject Clone(char character)
//     {
//         return Clone(character, true);
//     }

//     public GameObject Clone(char character, bool active)
//     {
//         GameObject obj = Instantiate<GameObject>(this.gameObject);
//         Sprite charSprite = Resources.Load<Sprite>("CharacterImages/" + character);
//         obj.GetComponent<Enemy>().charRenderer.sprite = charSprite;
//         return obj;
//     }

//     void Start()
//     {

//     }

//     // Update is called once per frame
//     void Update()
//     {

//     }
// }

// [SerializeField]
// public interface IPrototype
// {
//     GameObject Clone(char character);
//     GameObject Clone(char character, bool active);
// }
