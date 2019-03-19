Feature: PlayerCharacter
	In order to play the game
	As a human player
	I want my character attribute to be correctly represented

# Background will be automatically executed before each scenario and scenario outline
Background: 
	Given I'm a new player

Scenario Outline: Health reduction	
	When I take <damage> damage
	Then My health should be <expectedHealth>

	Examples:
	| damage | expectedHealth |
	| 0      | 100            |
	| 40     | 60             |
	| 50     | 50             |


Scenario: Taking too much damage results in player death	
	When I take 100 damage
	Then I should be dead

Scenario: Elf race characters get additional 20 damage resistance	
		And I have a damage resistance of 10
		And I'm an Elf
	When I take 40 damage
	Then My health should be 90

# the scenario below can substitute the AND AND AND ...by using a data table
Scenario: Elf race characters get addtional 20 damage resistance using data table	
		And I have the following attributes
		| attribute  | value |
		| Race       | Elf   |
		| Resistance | 10    |
	When I take 40 damage
	Then My health should be 90


Scenario: Healers restore all health
	Given My character class is set to Healer
	When I take 40 damage
		And Cast a healing spell
	Then My health should be 100