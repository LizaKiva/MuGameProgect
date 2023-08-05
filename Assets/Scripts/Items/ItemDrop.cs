using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static LogHandler;

public class ItemDrop : MonoBehaviour // Класс дропа
{
    [SerializeField] PlayerInventory inventory; // Инвентарь игрока, куда подбираетсся предмет

    BaseItem item; // Предмет который упал

    private void Start()
    {
        // Получаем предмет (хочется поменять)
        // TODO: Сделать получение спрайта по предметун
        item = GetComponent<BaseItem>();
        GetComponent<SpriteRenderer>().sprite = item.GetItemImage();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")) // Проверяем, что игрок столкнулся с предметом
        {
            Message(LogCategories.ITEMS, "Picked item: {0}", item); // Выводим информацию что игрок полнял

            inventory.AddItem(item);  // Добавляем предмет в инвентарь
            Destroy(this.gameObject); // Уничтожаем дроп
        }
    }
}
