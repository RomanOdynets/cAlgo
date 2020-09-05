namespace cAlgo.LList
{
    /// <summary>
    /// Класс-обьект одной ячейки информации в связанном списке
    /// </summary>
    /// <typeparam name="T">Типа данных хранимый в ячейке</typeparam>
    public class Node<T>
    {
        /// <summary>
        /// Информация хранимая в ячейке
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// Ссылка на следующий обьект хранимой информации
        /// </summary>
        public Node<T> Next { get; set; }

        /// <summary>
        /// Конструктор записывающий информацию при создании обьекта
        /// </summary>
        /// <param name="data">Информация с тип шаблона которая хранится в ячейке</param>
        public Node(T data)
        {
            Data = data;
        }
    }
}
