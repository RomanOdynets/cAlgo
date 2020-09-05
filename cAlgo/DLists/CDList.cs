using System.Collections;
using System.Collections.Generic;
using cAlgo.Exceptions;

namespace cAlgo.DLList
{
    /// <summary>
    /// Двухсторонний связной список, содержит ссылку на предыдущий обьект, информацию и ссылку на следующий элемент списка
    /// </summary>
    /// <typeparam name="T">Тип данных хранимый в списке</typeparam>
    public class CDList<T> : IEnumerable<T>
    {
        private DoublyNode<T> head;
        private int count;

        /// <summary>
        /// Индексатор для получения узла по индексу
        /// </summary>
        /// <param name="index">Номер узла</param>
        /// <returns>Данные в этом узле</returns>
        public T this[int index]
        {
            get
            {
                if (index >= count) throw new ListException($"Index was more than elements count. (Count: {count}/Index: {index})");
                if (count == 0) throw new ListException($"List has no elements.");

                DoublyNode<T> current = head;
                int temp = 0;

                do
                {
                    if (index == temp) return current.Data;
                    temp++;
                    current = current.Next;
                } while (current != head);

                throw new ListException("Index was not found");
            }
            set
            {
                if (index >= count) throw new ListException($"Index was more than elements count. (Count: {count}/Index: {index})");
                if (count == 0) throw new ListException($"List has no elements.");

                DoublyNode<T> current = head;
                int temp = 0;

                do
                {
                    if (index == temp) current.Data = value;
                    temp++;
                    current = current.Next;
                } while (current != head);
            }
        }

        /// <summary>
        /// Добавление в конец списка значения по шаблону
        /// </summary>
        /// <param name="data">Записываемая информация по шаблону</param>
        public void Add(T data)
        {
            DoublyNode<T> node = new DoublyNode<T>(data);

            if(head == null)
            {
                head = node;
                head.Next = node;
                head.Previous = node;
            }
            else
            {
                node.Previous = head.Previous;
                node.Next = head;
                head.Previous.Next = node;
                head.Previous = node;
            }
            count++;
        }

        /// <summary>
        /// Удаление информации со списка
        /// </summary>
        /// <param name="data">Данные, которые требуется удалить</param>
        /// <returns>Результат удаления</returns>
        public bool Remove(T data)
        {
            DoublyNode<T> current = head;

            DoublyNode<T> removedItem = null;

            if (count == 0) return false;

            do
            {
                if(current.Data.Equals(data))
                {
                    removedItem = current;
                    break;
                }
                current = current.Next;
            } while (current != head);

            if(removedItem != null)
            {
                if (count == 1) head = null;
                else
                {
                    if(removedItem == head)
                    {
                        head = head.Next;
                    }
                    removedItem.Previous.Next = removedItem.Next;
                    removedItem.Next.Previous = removedItem.Previous;
                }
                count--;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Количество элементов в списке
        /// </summary>
        public int Count { get { return count; } }

        /// <summary>
        /// Возвращает пустой ли список
        /// </summary>
        public bool IsEmpty { get { return count == 0; } }


        /// <summary>
        /// Очищает список от всех элементов
        /// </summary>
        public void Clear()
        {
            head = null;
            count = 0;
        }

        /// <summary>
        /// Проверка на существование информации в списке
        /// </summary>
        /// <param name="data">Искомая информация по шаблону</param>
        /// <returns>Результат поиска</returns>
        public bool Contains(T data)
        {
            DoublyNode<T> current = head;
            if (current == null) return false;
            do
            {
                if (current.Data.Equals(data)) return true;
                current = current.Next;
            } while (current != head);
            return false;
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            DoublyNode<T> current = head;
            do
            {
                if(current != null)
                {
                    yield return current.Data;
                    current = current.Next;
                }
            }while(current != head);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        /// <summary>
        /// Вывод элементов списка в обратном порядке
        /// </summary>
        /// <returns>Интерфейс списка</returns>
        public IEnumerable<T> BackEnumerator()
        {
            DoublyNode<T> current = head;

            do
            {
                if (current != null)
                {
                    yield return current.Data;
                    current = current.Previous;
                }
            } while (current != head);
        }
    }
}
