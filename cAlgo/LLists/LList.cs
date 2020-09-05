using System;
using System.Collections;
using System.Collections.Generic;
using cAlgo.Exceptions;

namespace cAlgo.LList
{
    /// <summary>
    /// Связной список
    /// </summary>
    /// <typeparam name="T">Тип данных хранимый в списке</typeparam>
    public class LList<T> : IEnumerable<T>
    {
        /// <summary>
        /// Количество элементов в списке
        /// </summary>
        public int Count { get { return count; } }

        /// <summary>
        /// Возвращает пустой ли список
        /// </summary>
        public bool IsEmpty { get { return count == 0; } }

        private Node<T> head;
        private Node<T> tail;
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

                Node<T> current = head;
                int temp = 0;

                while(current != null)
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

                Node<T> current = head;
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
