using System;
using System.Collections.Generic;
using System.Text;

namespace Task2_2
{
    public class Program
    {
        private static void Main()
        {
            List<Team> teams = new List<Team>();

            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine();
                Console.WriteLine("1 - Створити команду");
                Console.WriteLine("2 - Додати співробітника");
                Console.WriteLine("3 - Вивести коротку інформацію");
                Console.WriteLine("4 - Вивести детальну інформацію");
                Console.WriteLine("0 - Вийти");

                Console.Write("Оберіть дію: ");
                string choice = Console.ReadLine() ?? string.Empty;

                switch (choice)
                {
                    case "1":
                        CreateTeam(teams);
                        break;

                    case "2":
                        AddWorkerToTeam(teams);
                        break;

                    case "3":
                        ShowTeams(teams, false);
                        break;

                    case "4":
                        ShowTeams(teams, true);
                        break;

                    case "0":
                        isRunning = false;
                        break;

                    default:
                        Console.WriteLine("Невідома команда.");
                        break;
                }
            }
        }

        private static void CreateTeam(List<Team> teams)
        {
            Console.Write("Введіть назву команди: ");
            string teamName = Console.ReadLine() ?? string.Empty;

            Team team = new Team(teamName);
            teams.Add(team);
        }

        private static void AddWorkerToTeam(List<Team> teams)
        {
            if (teams.Count == 0)
            {
                Console.WriteLine("Спочатку створіть команду.");
                return;
            }

            ShowTeamNumbers(teams);

            Console.Write("Оберіть номер команди: ");
            if (!int.TryParse(Console.ReadLine(), out int teamNumber)
                || teamNumber < 1 || teamNumber > teams.Count)
            {
                Console.WriteLine("Помилка: команди з таким номером немає.");
                return;
            }
            int teamIndex = teamNumber - 1;

            Console.Write("Введіть ім'я співробітника: ");
            string workerName = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("1 - Розробник");
            Console.WriteLine("2 - Менеджер");
            Console.Write("Оберіть посаду: ");

            string positionChoice = Console.ReadLine() ?? string.Empty;

            Worker worker;

            if (positionChoice == "1")
            {
                worker = new Developer(workerName);
            }
            else if (positionChoice == "2")
            {
                worker = new Manager(workerName);
            }
            else
            {
                Console.WriteLine("Помилка: невідома посада.");
                return;
            }

            worker.FillWorkDay();
            teams[teamIndex].AddWorker(worker);
        }

        private static void ShowTeamNumbers(List<Team> teams)
        {
            for (int index = 0; index < teams.Count; index++)
            {
                Console.WriteLine($"{index + 1} - {teams[index].Name}");
            }
        }

        private static void ShowTeams(List<Team> teams, bool showDetails)
        {
            foreach (Team team in teams)
            {
                Console.WriteLine();

                if (showDetails)
                {
                    team.ShowDetailedTeamInfo();
                }
                else
                {
                    team.ShowTeamInfo();
                }
            }
        }
    }
}
