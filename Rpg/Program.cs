using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rpg
{
    internal class Program
    {
        static void Main(string[] args)

        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("                      Добро пожаловать в The fantasy world of Ivan Kosykh");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("                            Вы готовы начать игру?");
            Console.WriteLine("");
            Console.WriteLine("                              Введите Да или Нет");
            string choice = Convert.ToString(Console.ReadLine());
            if (choice == "Да" || choice == "да" || choice == "ДА")
            {
                Console.WriteLine("                          Тогда начнём приключение в этом замечательном!");
                Console.ReadLine();
                Console.Clear();
            }
            else if (choice == "нет" || choice == "НЕТ" || choice == "Нет")
            {
                Console.Clear();
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("                      Ну да , согласен, врятли овощ справится с этой игрой");
                Console.ReadLine();
                Environment.Exit(0);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("              Возможно ты чем то болен, если не можешь напечатать да или нет...");
                Console.ReadLine();
                Environment.Exit(0);
            }
            Console.WriteLine("Предыстория:");
            Console.ReadKey();
            Console.WriteLine("Вы переродившийся в другом мир ГЕРОЙ!!!");
            Console.ReadKey();
            Console.WriteLine("Ваши воспоминания о прошлой жизни:");
            Console.ReadKey();
            Console.WriteLine("Вы были обычным студентов колледжа , не чем не отличавшимся от своих сверстников");
            Console.ReadKey();
            Console.WriteLine("Особых интересов у вас не было , кроме создания музыки");
            Console.ReadKey();
            Console.WriteLine("Для создания музыки , вас вдохновляло : хождение по ночным безлюдному городу");
            Console.ReadKey();
            Console.WriteLine("К сожадению вас это и погубило:");
            Console.ReadKey();
            Console.WriteLine("Вы вышли ночью прогуляться на улице , надели свои любимые наушники и погрузились в глубину своего познания");
            Console.ReadKey();
            Console.WriteLine("Не обращая внимания на проежающие машины рядом вы шли и слушали музыку , поглядывая на мёртвые с виду дома и серость вашего города");
            Console.ReadKey();
            Console.WriteLine("К моему сожадению , из вашей безпечности , вас сбила машина");
            Console.ReadKey();
            Console.WriteLine("Для того , чтобы вернуться в свой мир , вам придётся победить финального боса этого мира");
            Console.ReadKey();
            Console.WriteLine("Если вы хотите вернуться в свой мир и закончить свой альбом");
            Console.ReadKey();
            Console.WriteLine("Желаю вам удачи и да , пока не забыл :");
            Console.ReadKey();
            Console.WriteLine("Мой тебе совет , не стоит лезть сразу на босса , он будет в разы посильнее вас , сначала покачайся на простых мобах, если не хочешь снова отравиться в Вальхаллу");
            Console.ReadKey();
            Console.WriteLine("Прошу тебя прислушаться к моему совету, это твой последний шанс");
            Console.ReadKey();
            Console.WriteLine("Введите имя героя: ");
            string heroName = Console.ReadLine();

            Player player = new Player();
            player.Name = "Игрок";
            player.Health = 100;
            player.Strength = 10;
            player.Defense = 5;
            player.Experience = 0;
            player.Level = 1;

            Location startingLocation = new Location();
            startingLocation.Name = "Мир фантазии Ивана Косых";

            Monster monster1 = new Monster();
            monster1.Name = "Казенак";
            monster1.Health = 20;
            monster1.Strength = 5;
            monster1.Defense = 2;
            monster1.Reward = 10;
            startingLocation.Monsters = new List<Monster>() { monster1 };

            Boss finalBoss = new Boss();
            finalBoss.Name = "Обамка";
            finalBoss.Health = 100;
            finalBoss.Strength = 20;
            finalBoss.Defense = 10;
            finalBoss.Reward = 100;
            startingLocation.FinalBoss = finalBoss;

            Console.WriteLine("Вы находитесь в " + startingLocation.Name);

            while (player.Health > 0)
            {
                Console.WriteLine();
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1. Сражаться с монстром");
                Console.WriteLine("2. Сражаться с финальным боссом");
                Console.WriteLine("3. Выйти из игры");

                string input = Console.ReadLine();

                switch (int.Parse(input))
                {
                    case 1:
                        Console.WriteLine("Вы сражаетесь с монстром!");
                        Console.ReadKey();
                        Monster monster = startingLocation.Monsters[0];
                        while (monster.Health > 0 && player.Health > 0)
                        {
                            int damageDealtByPlayer = player.Strength - monster.Defense;
                            if (damageDealtByPlayer <= 0)
                                damageDealtByPlayer = 1;
                            Console.WriteLine("Вы нанесли монстру " + damageDealtByPlayer + " единиц урона.");
                            monster.Health -= damageDealtByPlayer;
                            if (monster.Health <= 0)
                                break;

                            int damageDealtByMonster = monster.Strength - player.Defense;
                            if (damageDealtByMonster <= 0)
                                damageDealtByMonster = 1;
                            Console.WriteLine("Монстр нанес вам " + damageDealtByMonster + " единиц урона.");
                            Console.ReadKey();
                            player.Health -= damageDealtByMonster;
                        }
                        if (player.Health > 0)
                        {
                            Console.WriteLine("Вы победили монстра! Получено " + monster.Reward + " единиц опыта.");
                            Console.ReadKey();
                            player.Experience += monster.Reward;
                            if (player.Experience >= 20)
                            {
                                player.Level++;
                                player.Experience = 0;
                                player.Strength += 5;
                                player.Defense += 2;
                                Console.WriteLine("Вы достигли нового уровня! Уровень " + player.Level + ".");
                                Console.WriteLine("Сила увеличена на 5 единиц, защита увеличена на 2 единицы.");
                                Console.ReadKey();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Вы проиграли битву, игра окончена.");
                            return;
                        }
                        break;
                    case 2:
                        Console.WriteLine("Вы сражаетесь с финальным боссом!");
                        Boss boss = startingLocation.FinalBoss;
                        while (boss.Health > 0 && player.Health > 0)
                        {
                            int damageDealtByPlayer = player.Strength - boss.Defense;
                            if (damageDealtByPlayer <= 0)
                                damageDealtByPlayer = 1;
                            Console.WriteLine("Вы нанесли боссу " + damageDealtByPlayer + " единиц урона.");
                            Console.ReadKey();
                            boss.Health -= damageDealtByPlayer;
                            if (boss.Health <= 0)
                                break;

                            int damageDealtByBoss = boss.Strength - player.Defense;
                            if (damageDealtByBoss <= 0)
                                damageDealtByBoss = 1;
                            Console.WriteLine("Босс нанес вам " + damageDealtByBoss + " единиц урона.");
                            Console.ReadKey();
                            player.Health -= damageDealtByBoss;
                        }
                        if (player.Health > 0)
                        {
                            Console.WriteLine("Вы победили финального босса и закончили игру!");
                                Console.ReadKey();
                            Console.WriteLine("Мои поздравления , я рад за тебя , и нарушать своё обещания не стану");
                            Console.ReadKey();
                            Console.WriteLine("Теперь ты спокойно можешь отправляться в свой мир и закончить свой альбом");
                            Console.ReadKey();
                            Console.WriteLine("Мой тебе совет , пока ты не ушёл , посматривай по сторонам , что бы не повторился инцидент с аварией");
                            Console.ReadKey();
                            Console.WriteLine("Контакты автора данной игры:https://www.tiktok.com/@white_hoodwink");
                            Console.ReadKey();
                            Console.WriteLine("Кому не жалко , можете поддержать автора ( номер сбербанк): +79272549803");
                            Console.ReadKey();
                            Console.WriteLine("Получено " + boss.Reward + " единиц золота.");
                            return;
                        }
                        else
                        {
                            Console.WriteLine("Вы проиграли битву, игра окончена.");
                            Console.ReadKey();
                            Console.WriteLine("А я ведь тебя предупреждал , что стоит сначала на простых казенаках подкачаться , а потом уже лезть на босса");
                            Console.ReadKey();
                            Console.WriteLine("Типерь у тебя одна дорога , в Вальхаллу");
                            Console.ReadKey();
                            return;
                        }

                    case 3:
                        Console.WriteLine("То есть ты думаешь , что так просто можешь выйти из игры ?");
                        Console.ReadKey();
                        Console.WriteLine("Да можешь , проваливай :( ");
                        Console.ReadKey();
                        return;

                }
            }
        }
    }
}

