namespace cAlgo.DLList
{
    /// <summary>
    /// Класс-шаблон элемента информации в двухсвязном списке
    /// </summary>
    /// <typeparam name="T">Тип данных по шаблону</typeparam>
    public class DoublyNode<T>
    {
        /// <summary>
        /// Данные хранимые в ячейке
        /// </summary>
        public T Data { get; set; }
        /// <summary>
        /// Следующий элемент списка
        /// </summary>
        public DoublyNode<T> Next { get; set; }
        /// <summary>
        /// Предыдущий элемент списка
        /// </summary>
        public DoublyNode<T> Previous { get; set; }

        /// <summary>
        /// Создание обьекта информации с данными, что записаны в нём
        /// </summary>
        /// <param name="data">Записываемая информация по шаблону</param>
        public DoublyNode(T data)
        {
            Data = data;
        }
    }
}
