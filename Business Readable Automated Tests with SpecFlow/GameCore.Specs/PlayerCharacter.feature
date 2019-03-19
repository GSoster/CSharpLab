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


Scenario: Reading a restore health scroll when over tired has no effect
	Given I last slept 3 days ago
	When I take 40 damage
		And I read a restore health scroll
	Then My health should be 60

# THIS SHOULD BE MOVED TO ANOTHER .feature
Scenario: Total magical power
	Given I have the followwing magical items
	| name   | value | power |
	| Ring   | 200   | 100   |
	| Amulet | 400   | 200   |
	| Gloves | 100   | 400   |
	Then My total magical power should be 700

# THIS SHOULD BE MOVED TO ANOTHER .feature
Scenario: Weapos are worth money
	Given I have the following weapons
	| name  | value |
	| sword | 50    |
	| Pick  | 40    |
	| Knife | 10    |
	Then My weapons should be worth 100

# THIS SHOULD BE MOVED TO ANOTHER .feature
Scenario: Elf race characters fon't lose magical item power
	Given I'm an Elf
		And I have an Amulet with a power of 200
	When I use a magical Amulet
	Then The Amulet power should not be reduced

