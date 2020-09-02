using System;
using System.Collections;
using System.Collections.Generic;

namespace cAlgo.LList
{
    /// <summary>
    /// Связной список
    /// </summary>
    /// <typeparam name="T">Тип данных хранимый в списке</typeparam>
    public class LList<T> : IEnumerable<T>
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
            if (head == null) head = node;
            else tail.Next = node;
            tail = node;

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

            while(current != null)
            {
                if(current.Data.Equals(data))
                {
                    if(previous != null)
                    {
                        previous.Next = current.Next;

                        if (current.Next == null) tail = previous;
                    }
                    else
                    {
                        head = head.Next;
                        if (head == null) tail = null;
                    }
                    count--;
                    return true;
                }
                previous = current;
                current = current.Next;
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
        /// Проверяет существует ли искомая информация в списке
        /// </summary>
        /// <param name="data">Искомая информация по шаблону</param>
        /// <returns>Результат поиска</returns>
        public bool Contains(T data)
        {
            Node<T> current = head;

            while(current != null)
            {
                if (current.Data.Equals(data)) return true;
                current = current.Next;
            }
            return false;
        }

        /// <summary>
        /// Добавление информации в начало списка
        /// </summary>
        /// <param name="data">Записываемая информация по шаблону</param>
        public void AppendFirst(T data)
        {
            Node<T> node = new Node<T>(data) { Next = head };
            head = node;
            if (count == 0)
                tail = head;
            count++;
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Node<T> current = head;
            while(current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new Exception("Oooops");
        }
    }
}
