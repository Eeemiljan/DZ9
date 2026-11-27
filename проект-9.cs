using System;
using System.Collections.Generic;

class Team
{
    public string Country { get; }
    public int MemberCount { get; }

    public Team(string country, int memberCount)
    {
        Country = country;
        MemberCount = memberCount;
    }
}

interface IGame
{
    string Name { get; }

    int Play(Team team, Random random);
}

class BeachGame : IGame
{
    public string Name { get { return "Пляж"; } }

    public int Play(Team team, Random random)
    {
        int targets = random.Next(0, team.MemberCount + 1);
        return targets * 2;
    }
}

class MousetrapGame : IGame
{
    public string Name { get { return "Мышеловка"; } }

    public int Play(Team team, Random random)
    {
        int caught = random.Next(0, team.MemberCount + 1);
        int escaped = team.MemberCount - caught;
        return escaped * 2;
    }
}

class SeaGame : IGame
{
    public string Name { get { return "Море"; } }

    public int Play(Team team, Random random)
    {
        int buoys = random.Next(0, team.MemberCount + 1);
        int bonus = random.Next(0, 4);
        return buoys + bonus;
    }
}

class FishingGame : IGame
{
    public string Name { get { return "Рыбалка"; } }

    public int Play(Team team, Random random)
    {
        int score = 0;

        for (int i = 0; i < team.MemberCount; i++)
        {
            score = score + random.Next(0, 3);
        }

        return score;
    }
}

class PostmenGame : IGame
{
    public string Name { get { return "Почтальоны"; } }

    public int Play(Team team, Random random)
    {
        int delivered = random.Next(0, team.MemberCount + 1);
        int score = delivered;

        if (delivered == team.MemberCount)
        {
            score = score + 5;
        }

        return score;
    }
}

class SlideGame : IGame
{
    public string Name { get { return "Горка"; } }

    public int Play(Team team, Random random)
    {
        int finished = random.Next(0, team.MemberCount + 1);
        int bonus = finished / 3;
        return finished + bonus;
    }
}

class ObstacleCourseGame : IGame
{
    public string Name { get { return "Полоса препятствий"; } }

    public int Play(Team team, Random random)
    {
        int firstStage = random.Next(0, team.MemberCount + 1);
        int secondStage = random.Next(0, firstStage + 1);
        return firstStage + secondStage * 2;
    }
}

class BigRaces
{
    public void Run(Team[] teams, List<IGame> games, Random random)
    {
        int roundCount = 6;

        if (games.Count < roundCount)
        {
            Console.WriteLine("Для передачи нужно подготовить минимум шесть игр.");
            return;
        }

        List<IGame> remaining = new List<IGame>();

        foreach (IGame game in games)
        {
            remaining.Add(game);
        }

        for (int round = 1; round <= roundCount; round++)
        {
            int index = random.Next(0, remaining.Count);
            IGame game = remaining[index];
            remaining.RemoveAt(index);

            Console.WriteLine();
            Console.WriteLine($"Испытание {round}. {game.Name}");

            foreach (Team team in teams)
            {
                int score = game.Play(team, random);
                Console.WriteLine($"{team.Country}: {score} очков");
            }
        }

        Console.WriteLine();
        Console.WriteLine($"Каждая команда прошла испытаний: {roundCount}.");
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Проект 9. Большие гонки.");
        Console.WriteLine("Испытания выбираются случайно. Ввод не требуется.");
        Console.WriteLine();

        Team[] teams =
        {
            new Team("Россия", 15),
            new Team("Франция", 15),
            new Team("Китай", 15),
            new Team("Казахстан", 15)
        };

        Console.WriteLine("Команды:");

        foreach (Team team in teams)
        {
            Console.WriteLine($"{team.Country}: {team.MemberCount} человек");
        }

        List<IGame> games = new List<IGame>();
        games.Add(new BeachGame());
        games.Add(new MousetrapGame());
        games.Add(new SeaGame());
        games.Add(new FishingGame());
        games.Add(new PostmenGame());
        games.Add(new SlideGame());
        games.Add(new ObstacleCourseGame());

        Console.WriteLine();
        Console.WriteLine($"Доступно испытаний: {games.Count}.");

        BigRaces show = new BigRaces();
        show.Run(teams, games, new Random());
    }
}