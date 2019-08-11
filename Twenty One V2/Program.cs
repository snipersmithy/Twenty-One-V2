using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using CardGameClassLibrary;
using Quicktools;
using static CardGameClassLibrary.Deck;

namespace Twenty_One_V2
{
    class Program
    {
        // These communicate game state to the player.
        static string stickortwist = "Do you want to stick or twist? (Type 'stick' or 'twist')";
        static string playerinput;
        static string handsummary;

        // Breaks gameplay loop when set to true.
        static bool gameover = false;

        static int dealerpoints;
        static int playerpoints;

        // Represents the player's cards and the dealer's cards.
        static List<Card> playerhand = new List<Card>();
        static List<Card> dealerhand = new List<Card>();

        //Responsible for the initial two card deal and for re-initialising the variables for a new game.
        static bool initdone = false;
        static void BeginGame()
        {
            playerhand.Clear();
            dealerhand.Clear();

            dealerpoints = 0;
            playerpoints = 0;

            Console.WriteLine("Dealer to deal two cards...");

            var pc1 = new Card();
            var pc2 = new Card();

            playerhand.AddMany(pc1, pc2);
        }

        //Responsible for reading out the cards the player holds.
        static string SummariseHand()
        {
            handsummary = "";
            for (var i = 0; i < playerhand.Count(); i++)
            {
                if (i == playerhand.Count - 1)
                {
                    handsummary = handsummary + playerhand[i].cardname.ToString() + ".";
                }
                else if (i == playerhand.Count - 2)
                {
                    handsummary = handsummary + playerhand[i].cardname.ToString() + " and the ";
                }
                else if (i < playerhand.Count - 1)
                {
                    handsummary = handsummary + playerhand[i].cardname.ToString() + ", ";
                }
            }
            return "In your hand you have the " + handsummary;
        }

        // These are responsible for totting up player and dealer points respectively.
        static int GetPlayerPoints()
        {
            playerpoints = 0;
            for (var i = 0; i < playerhand.Count; i++)
            {
                playerpoints = playerpoints + playerhand[i].cardvalue;
                if (playerpoints > 21 && playerhand[i].cardname.Contains("Ace"))
                {
                    playerpoints = playerpoints - 10;
                }
            }
            return playerpoints;
        }
        static int GetDealerPoints()
        {
            dealerpoints = 0;
            for (var i = 0; i < playerhand.Count; i++)
            {
                dealerpoints = dealerpoints + dealerhand[i].cardvalue;
                if (dealerpoints > 21 && dealerhand[i].cardname.Contains("Ace"))
                {
                    dealerpoints = dealerpoints - 10;
                }
            }
            return dealerpoints;
        }
            //Responsible for any deals after the player decides to twist. If the player sticks or is dealt 21 initially this is skipped.
        static void PlayRound()
        {
            playerhand.Add(new Card());
        }
        //Responsible for the dealer's cards being drawn and the dealer's decision making.
        static void DealerRound()
        {

        }
        static void Game()
        {
            inter:

            if (GetPlayerPoints() < 21)
            {
                Console.WriteLine();
                Console.WriteLine(SummariseHand());

                Console.WriteLine("These are worth " + GetPlayerPoints() + " points.");
                Console.WriteLine(stickortwist);
                playerinput = Console.ReadLine();

                if (playerinput.ToLower() == "stick")
                {
                    DealerRound();
                }
                else if (playerinput.ToLower() == "twist")
                {
                    PlayRound();
                    goto inter;
                }
                else
                {
                    Console.WriteLine("Please type either stick or twist...");
                    goto inter;
                }
            }
            else if (GetPlayerPoints() == 21)
            {
                Console.WriteLine();
                Console.WriteLine("21! Dealer must match your score to win...");
                DealerRound();
            }
            else if (GetPlayerPoints() > 21)
            {
                Console.WriteLine();
                Console.WriteLine(SummariseHand());
                Console.WriteLine("Bust! Unlucky...");
            }
        }
        static void Main(string[] args)
        {
            do
            {
                if (initdone == false)
                {
                    BeginGame();
                    initdone = true;
                }

                Game();

                gameover = true;
            }
            while (gameover == false);
        }
    }
}
