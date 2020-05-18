using System;
using System.Collections.Generic;

namespace Lab5
{
    /// <summary>
    /// Абстрактный класс, который хранит информацию об игроке
    /// </summary>
    abstract class Player
    {
        /// <summary>
        /// Класс персонажа
        /// </summary>
        protected string player_class;
        /// <summary>
        /// Приоритет развития
        /// </summary>
        protected string priority;
        /// <summary>
        /// Путь до графической модели персонажа
        /// </summary>
        protected string pathToGraphicModel;
        /// <summary>
        /// Получить информацию о персонаже
        /// </summary>
        public virtual void GetInfo()
        {
            Console.WriteLine("Class: " + player_class + ", priority: " + priority + ", path to graphic model: " + pathToGraphicModel);
        }
    }
    /// <summary>
    /// Класс персонажа: Mage
    /// </summary>
    class Mage : Player
    { 
        /// <summary>
        /// Конструктор класса Mage
        /// </summary>
        public Mage()
        {
            this.player_class = "Mage";
            this.priority = "magic";
            this.pathToGraphicModel = "/path/to/Mage/model";
        }
    }
    /// <summary>
    /// Класс персонажа: Warrior
    /// </summary>
    class Warrior : Player
    {
        /// <summary>
        /// Конструктор класса Warrior
        /// </summary>
        public Warrior()
        {
            this.player_class = "Warrior";
            this.priority = "strength";
            this.pathToGraphicModel = "/path/to/Warrior/model";
        }
    }
    /// <summary>
    /// Класс персонажа: Thief
    /// </summary>
    class Thief : Player
    {
        /// <summary>
        /// Конструктор класса Thief
        /// </summary>
        public Thief()
        {
            this.player_class = "Thief";
            this.priority = "agility";
            this.pathToGraphicModel = "/path/to/Thief/model";
        }
    }
    /// <summary>
    /// Класс для фабрики персонажей
    /// </summary>
    class PlayerFactory
    {
        /// <summary>
        /// Общий словарь, содержащий соответствующие классы для персонажей
        /// Ключ - название игрового класса персонажа
        /// Значение - соответствующий класс
        /// </summary>
        private static Dictionary<string, Player> classes = new Dictionary<string, Player>();
        /// <summary>
        /// Функция для получения нужного класса и записи его в словарь в том случае, если он ранее не вызывался
        /// </summary>
        /// <param name="player_class">Игровой класс персонажа</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Иключение возникает, если входная строка с названием игрового класса неверная</exception>
        public static Player GetClass(string player_class)
        {
            Player player;
            if (classes.ContainsKey(player_class))
            {
                player = classes[player_class];
                Console.WriteLine("(в словаре найден класс " + player_class + ")");
            }
            else
            {
                switch (player_class)
                {
                    case "Mage":
                        player = new Mage();
                        break;
                    case "Warrior":
                        player = new Warrior();
                        break;
                    case "Thief":
                        player = new Thief();
                        break;
                    default:
                        throw new ArgumentException("No such class");
                }
                classes.Add(player_class, player);
                Console.WriteLine("(в словарь добавлен класс " + player_class + ")");
            }
            return player;
        }
    }
    /// <summary>
    /// Класс с игрой
    /// </summary>
    class Game
    {
        ///<summary>
        ///Точка входа в программу
        ///</summary>
        ///<param name="args">Список аргументов командной строки</param>
        static void Main(string[] args)
        {
            try
            {
                Player p1 = PlayerFactory.GetClass("Mage");
                p1.GetInfo();
            }
            catch (ArgumentException)
            {
                Console.WriteLine("This class does not exist");
            }
            Console.WriteLine();
            try
            {
                Player p2 = PlayerFactory.GetClass("Warrior");
                p2.GetInfo();
            }
            catch (ArgumentException)
            {
                Console.WriteLine("This class does not exist");
            }
            Console.WriteLine();
            try
            {
                Player p3 = PlayerFactory.GetClass("Thief");
                p3.GetInfo();
            }
            catch (ArgumentException)
            {
                Console.WriteLine("This class does not exist");
            }
            Console.WriteLine();
            try
            {
                Player p4 = PlayerFactory.GetClass("Mage");
                p4.GetInfo();
            }
            catch (ArgumentException)
            {
                Console.WriteLine("This class does not exist");
            }
            Console.WriteLine();
            try
            {
                Player p5 = PlayerFactory.GetClass("Warrior");
                p5.GetInfo();
            }
            catch (ArgumentException)
            {
                Console.WriteLine("This class does not exist");
            }
            Console.WriteLine();
            try
            {
                Player p6 = PlayerFactory.GetClass("Thief");
                p6.GetInfo();
            }
            catch (ArgumentException)
            {
                Console.WriteLine("This class does not exist");
            }
            Console.WriteLine();
            try
            {
                Player p7 = PlayerFactory.GetClass("Wrong");
                Console.ReadKey();
            }
            catch (ArgumentException)
            {
                Console.WriteLine("This class does not exist");
            }

            Console.ReadKey();
        }
    }
}