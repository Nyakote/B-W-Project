using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject _cameraTarget;                  //В середовищі юніті вказуємо нашого гравця
    [SerializeField] float _heightLimit = 2f;                   //Наскільки високо персонаж може рухатись не змінюючи положення камери
    [SerializeField] float _lengthLimit = 5f;                   //Наскільки далеко персонаж може рухатись не змінюючи положення камери
    [SerializeField] float _distanceToTarget = -20f;            //Наскільки далеко камера від персонажа
    [SerializeField] float _followSpeed = 4f;                   //Наскільки швидко змінює своє положення

    private void Start()                                        //На старті задаємо камері позицію персонажа
    {
        transform.position = new Vector3(
            _cameraTarget.transform.position.x,
            _cameraTarget.transform.position.y,
            _distanceToTarget
        );
    }

    private void LateUpdate()                                   //Викликаємо метод SquareFollow який імітує камеру Hollow Knight
    {
        SquareFollow();
    }

    private void SquareFollow()                                 
    {
        Vector3 camPos = transform.position;                    //Змінна яка зберігає позицію камери
        Vector3 targetPos = _cameraTarget.transform.position;   //Змінна яка зберігає позицію персонажа

        bool outX = Mathf.Abs(camPos.x - targetPos.x) > _lengthLimit; //Перевірка умов дальності
        bool outY = Mathf.Abs(camPos.y - targetPos.y) > _heightLimit; //Перевірка умов висоти

        if (outX || outY)
            MoveToPlayer();                                           //Виклик руху камери якщо умови виконуються
    }

    private void MoveToPlayer()                                       //Рухає камеру до гравця в допустимі ліміти
    {
        Vector3 target = new Vector3(
            _cameraTarget.transform.position.x,
            _cameraTarget.transform.position.y,                       //Створення вектора з правильною z координатою
            _distanceToTarget
        );

        transform.position = Vector3.Lerp(
            transform.position,
            target,                                                   //зміна позиції камери з _followSpeed швидкістю
            _followSpeed * Time.deltaTime
        );
    }
}
