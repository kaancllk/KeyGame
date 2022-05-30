using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerMovement : MonoBehaviour
{

    [SerializeField] float _speed;
    [SerializeField] Text _text;
    [SerializeField] Image wall;
    List<string> _keys = new List<string>();
    private SpriteRenderer _renderer;

    [SerializeField] GameObject _sec,redk, yellowk,door1,door,_barrier;

    void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
       
    }

    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        transform.position += new Vector3(Input.GetAxis("Horizontal") * Time.deltaTime * _speed,0);
       
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            _renderer.flipX = false;
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            _renderer.flipX = true;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
      if(collision.name=="redkey")
        {
            if (_keys.Count == 0)
            {
                _text.text = "KIRMIZI ANAHTAR ALINDI";
                _keys.Add("redkey");
                redk.SetActive(true);
            }
            
        }
        if (collision.name == "yellowkey")
        {
             if (_keys.Count == 1)
            {
                _text.text = "SARI ANAHTAR ALINDI";
                _keys.Add("yellowkey");
                yellowk.SetActive(true);
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name == "door")
        {
            if (_keys.Count == 0)
            {
                _text.text = "KAPIYI AÇMAK ÝÇÝN DOÐRU ANAHTARI BUL!";
                Destroy(_barrier);
            }
            else if (_keys.Count == 1)
            {
                _text.text = "YANLIÞ ANAHTAR!";
                wall.color = Color.red;
            }
            else
            {
                _text.text = "DOÐRU ANAHTARI SEÇÝNÝZ?";
                _sec.SetActive(true);
                wall.color = Color.yellow;

            }
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        wall.color = Color.white;
        if (collision.name == "door")
        {
            _sec.SetActive(false);
        }
        _text.text = "";

    }

    public void _keyselect()
    {
        door.SetActive(false);

        door1.SetActive(true);

        _text.text = "TEBRÝKLER! DOÐRU ANAHTARI BULDUNUZ.";
        _sec.SetActive(false);
       
    }
    public void _keyselect1()
    {
        _text.text = "YANLIÞ ANAHTAR!";
        _sec.SetActive(false);
        transform.position = new Vector3(0, -2,-2);

    }
    public void quit()
    {
        Application.Quit();
    }



}
