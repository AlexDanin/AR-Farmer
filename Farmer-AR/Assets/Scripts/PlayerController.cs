using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    private FixedJoystick _joystick;
    [SerializeField] private Animator _animator;

    private float _moveSpeed = 0.3f;

    GameObject sound_apple, sound_pac;

    private void init()
    {
        _joystick = GameObject.Find("Fixed Joystick").GetComponent<FixedJoystick>();
        sound_apple = GameObject.Find("sound_apple");
        sound_pac = GameObject.Find("sound_pac");
    }

    private void FixedUpdate()
    {
        try
        {
            if (!_joystick)
            {
                init();
            }
            else if (_joystick)
            {
                _rigidbody.velocity = new Vector3(_joystick.Horizontal * _moveSpeed, _rigidbody.velocity.y, _joystick.Vertical * _moveSpeed);

                if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
                {
                    transform.rotation = Quaternion.LookRotation(-_rigidbody.velocity);
                    _animator.SetBool("isRunning", true);
                }
                else
                    _animator.SetBool("isRunning", false);
            }
        }
        catch (System.Exception)
        {

        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "objects" && GameMechanic.score < 5 && !GameMechanic.obj_destroy)
        {
            sound_apple.GetComponent<AudioSource>().Play();
            Destroy(collision.gameObject.transform.parent.gameObject);
            GameMechanic.score += 1;
            GameMechanic.obj_destroy = true;
        }

        if (collision.gameObject.tag == "storage")
        {
            sound_pac.GetComponent<AudioSource>().Play();
            GameMechanic.bag += GameMechanic.score;
            GameMechanic.score = 0;
            GameMechanic.put_to_bag = true;
        }
    }
}
