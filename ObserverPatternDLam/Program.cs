using System;
using System.Collections.Generic;

namespace ObserverPatternDLam
{
    class Program
    {
        static void Main(string[] args)
        {
            //Player are only notify if table is open
            var subject = new Subject();
            
            var player1 = new Player("David");
            var player2 = new Player("Adams");
            var player3 = new Player("Byron");
            var player4 = new Player("Charles");

            subject.RegisterPlayer(player1);
            subject.RegisterPlayer(player2);
            subject.RegisterPlayer(player3);
            subject.RegisterPlayer(player4);
            //
            subject.RegisterPlayerRemove(player1);
            subject.RegisterPlayerRemove(player2);
            //subject.RegisterPlayerRemove(player3);
        
        }
    }

    public class Subject : ISubject
    {
        List<IPlayer> players = new List<IPlayer>();

        public void Notify()
        {
            foreach (var player in players)
            {
                player.Update();
            }  
        }

        public void RegisterPlayer(IPlayer player)
        {
            players.Add(player);
            Console.WriteLine($"Register: {player.firstName()}");
            DisplayPlayer();
        }

        public bool TableOpen()
        {
            return players.Count < 2;
        }

        private void DisplayPlayer() {
            Console.WriteLine("-------------------");
            Notify();
            Console.WriteLine("-------------------");
        }

        public void RegisterPlayerRemove(IPlayer player)
        {
            players.Remove(player);
            Console.WriteLine($"Remove:  {player.firstName()}");
            DisplayPlayer();
        }
    }

    public interface ISubject {
        bool TableOpen();
        void RegisterPlayer(IPlayer player);
        void RegisterPlayerRemove(IPlayer player);
        void Notify();
    }

    public interface IPlayer {
        void Update();
        string firstName();
    }

    public class Player : IPlayer
    {
        private string _firstName;

        public Player(string firstName)
        {
            _firstName = firstName;
        }

        public string firstName()
        {
            return this._firstName;
        }

        public void Update()
        {
            Console.WriteLine($"{this._firstName} notified");
        }
    }
}
