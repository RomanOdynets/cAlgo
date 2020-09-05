using System.Collections;
using System.Collections.Generic;
using cAlgo.Exceptions;

namespace cAlgo.DLList
{
    /// <summary>
    /// Двухсторонний связной список, содержит ссылку на предыдущий обьект, информацию и ссылку на следующий элемент списка
    /// </summary>
    /// <typeparam name="T">Тип данных хранимый в списке</typeparam>
    public class DList<T> : IEnumerable<T>
    {
        private DoublyNode<T> head;
        private DoublyNode<T> tail;
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

                while (current != null)
                {
                    if (index == temp) return current.Data;
                    temp++;
                    current = current.Next;
                }

                throw new ListException("Index was not found");
            }
            set
            {
                if (index >= count) throw new ListException($"Index was more than elements count. (Count: {count}/Index: {index})");
                if (count == 0) throw new ListException($"List has no elements.");

                DoublyNode<T> current = head;
                int temp = 0;

                while (current != null)
                {
                    if (index == temp) current.Data = value;
                    temp++;
                    current = current.Next;
                }
            }
        }

        /// <summary>
        /// Добавление в конец списка значения по шаблону
        /// </summary>
        /// <param name="data">Записываемая информация по шаблону</param>
        public void Add(T data)
        {
            DoublyNode<T> node = new DoublyNode<T>(data);

            if (head == null) head = node;
            else
            {
                tail.Next = node;
                node.Previous = tail;
            }
            tail = node;
            count++;
        }

        /// <summary>
        /// Добавление в начало списка значения по шаблону
        /// </summary>
        /// <param name="data">Записываемая информация по шаблону</param>
        public void AddFirst(T data)
        {
            DoublyNode<T> node = new DoublyNode<T>(data);
            DoublyNode<T> temp = head;

            node.Next = temp;
            head = node;
            if (count == 0) tail = head;
            else temp.Previous = node;
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

            while(current != null)
            {
                if(current.Data.Equals(data))
                {
                    break;
                }
                current = current.Next;
            }

            if(current != null)
            {
                if (current.Next != null) current.Next.Previous = current.Previous;
                else tail = current.Previous;

                if (current.Previous != null) current.Previous.Next = current.Next;
                else head = current.Next;

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
            tail = null;
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
            while(current != null)
            {
                if (current.Data.Equals(data)) return true;
                current = current.Next;
            }
            return false;
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            DoublyNode<T> current = head;
            while(current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
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
            DoublyNode<T> current = tail;

            while(current != null)
            {
                yield return current.Data;
                current = current.Previous;
            }
        }
    }
}
