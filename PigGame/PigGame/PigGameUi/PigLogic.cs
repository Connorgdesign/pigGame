using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace PigGameUi
{
    class PigLogic

    {
        public string player1Name { get; set; }
        public string player2Name { get; set; }
        public int Roll { get; set; }


        public int player1Score { get; set; }
        public int player2Score { get; set; }

        public string playerTurn { get; set; }
        public string currentPlayer { get; set; }
        public int currentPoints { get; set; }

        private Random number = new Random();


        public PigLogic() {
            player1Score = 0;
            player2Score = 0;
            playerTurn = "player1";
            currentPoints = 0;
           
        }

        public void newGame() {
            playerTurn = "player1";
            player1Score = 0;
            player2Score = 0;
            currentPoints = 0;
            Roll = 0;
        }


        public string getCurrentPlayer() {

            if (playerTurn == "player1")
            {
                currentPlayer = player1Name;
                return player1Name;
            }
            else {
                currentPlayer = player2Name;
                return player2Name;
            }

        }

        public string getPlayerTurn() {
            if (currentPlayer == player1Name)
            {
                return "player1";
            }
            else {
                return "player2";
            }
        }

        public string switchPlayers() {
            if (playerTurn == "player1")
            {
                playerTurn = "player2";
                return playerTurn;
            }
            else if (playerTurn == "player2")
            {
                playerTurn = "player1";
                return playerTurn;
            }
            else {
                return playerTurn;
            }


        }

        public int endTurn() {
            string player = getCurrentPlayer();
            if (player == player1Name)
            {
                
                player1Score += currentPoints;
                currentPoints = 0;
                switchPlayers();

                return player1Score;
            }
            else {

                player2Score += currentPoints;
                currentPoints = 0;
                switchPlayers();
                return player2Score;
            }

        }


        public int RollDie() {

            Roll = number.Next(1,9);
            if (Roll == 8)
            {
                currentPoints = 0;
     
                return currentPoints;
            }
            else {
                currentPoints = currentPoints + Roll;

                return currentPoints;
            }
          

        }
    }
}