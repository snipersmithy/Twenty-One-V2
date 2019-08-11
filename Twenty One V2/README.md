# Twenty-One-V2
 Version 2 of my pontoon / twenty one app.

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
