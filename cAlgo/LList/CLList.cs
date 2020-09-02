using System;
using System.Collections;
using System.Collections.Generic;

namespace cAlgo.LList
{
    /// <summary>
    /// Связной список
    /// </summary>
    /// <typeparam name="T">Тип данных хранимый в списке</typeparam>
    public class CLList<T> : IEnumerable<T>
    {
        private Node<T> head;
        private Node<T> tail;
        private int count;

        /// <summary>
        /// Добавление информации в конец списка
        /// </summary>
        /// <param name="data">Записываемая информация по шаблону</param>
        public void Add(T data)
        {
            Node<T> node = new Node<T>(data);
            if (head == null)
            {
                head = node;
                tail = node;
                tail.Next = head;
            }
            else
            {
                node.Next = head;
                tail.Next = node;
                tail = node;
            }

            count++;
        }

        /// <summary>
        /// Удаление информации из списка
        /// </summary>
        /// <param name="data">Удаляемая информация по шаблону</param>
        /// <returns>Результат удаления</returns>
        public bool Remove(T data)
        {
            Node<T> current = head;
            Node<T> previous = null;

            if (IsEmpty) return false;

            do
            {
                if(current.Data.Equals(data))
                {
                    if(previous != null)
                    {
                        previous.Next = current.Next;
                        if (current == tail) tail = previous;
                    }
                    else
                    {
                        if(count == 1)
                        {
                            head = tail = null;
                        }
                        else
                        {
                            head = current.Next;
                            tail.Next = current.Next;
                        }
                    }
                    count--;
                    return true;
                }
                previous = current;
                current = current.Next;
            } while (current != head);

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
        /// Проверяет существует ли искомая информация в списке
        /// </summary>
        /// <param name="data">Искомая информация по шаблону</param>
        /// <returns>Результат поиска</returns>
        public bool Contains(T data)
        {
            Node<T> current = head;
            do
            {
                if (current.Data.Equals(data)) return true;
                current = current.Next;
            } while (current != head);
            return false;
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Node<T> current = head;
            do
            {
                if(current != null)
                {
                    yield return current.Data;
                    current = current.Next;
                }
            } while (current != head);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }
    }
}
