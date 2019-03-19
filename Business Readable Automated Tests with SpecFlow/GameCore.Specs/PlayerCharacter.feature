Feature: PlayerCharacter
	In order to play the game
	As a human player
	I want my character attribute to be correctly represented


Scenario: Taking no damage when hit does't affect health
	Given I'm a new player
	When I take 0 damage
	Then My health should be 100

Scenario: Starting health is reduced when hit
	Given I'm a new player
	When I take 40 damage
	Then My health should now be 60

Scenario: Tking too much damage results in player death
	Given I'm a new player
	When I take 100 damage
	Then I should be dead