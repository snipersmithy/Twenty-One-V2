# Twenty-One-V2
 Version 2 of my pontoon / twenty one app. It is played using the console.
 
 The app uses two .dll files, ClassLib.dll and Quicktools.dll.
 
 Quicktools is a simple library which adds the AddMany() method to simplify adding multiple objects to a list.
 
 ClassLib contains the definition for Deck and Deck.Card, and uses a Dictionary to allow Card generation.
 It is responsible for rendomised Card objects being drawn. It uses a random number (cno) as a key to construct a new
 Card with the following properties:
 string cardsuite: Stores the suite of the card, one of "of Spades","of Hearts","of Clubs" or "of Diamonds".
 int cardvalue: Stores the points value of a card, assumes a value of 11 for an Ace.
 string cardname: Uses both cardsuite and cardvalue to generate a user friendly name for the card.

 The following methods are used in this program:

 BeginGame()
 This method clears the hands of both the player and dealer, sets both scores to zero 
 and deals the first player cards in order to begin the game.

 SummariseHand()
 Returns a string communicating to the player what is in their hand. 
 It updates each time it is called and it remains grammatically correct.

 GetPlayerPoints(), GetDealerPoints()
 Calculates points for player/dealer using the Card.cardvalue properties as stored in 
 the dealerhand or playerhand lists. Also responsible for Ace High/Low rule, deducting
 ten from the points score where an Ace Low is preferred.

 PlayRound()
 Deals the player a card and adds this to player's hand. Skipped if the player does not
 type twist when prompted.

 DealerPlays()
 Initially deals the first two cards in the dealer's hand. Then uses logic to decide 
 whether to stick or twist. 

 Game()
 Where each game takes place, each of the other functions is executed within this one.
 
 
