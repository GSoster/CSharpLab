@awaitingReviewBeforeStartingWork
Feature: InGameChat
	In order to increase the sense of game community
	As a human player
	I want to be able to chat via text with other human players


Scenario: Chat messages limited in length
	Given I have created a chat message longer than 100 characters	
	When I try to send
	Then The message should not be sent
		And I get an error notification

Scenario: Chat messages are not offensive
	Given I have created a chat message with swearing content
	When I try to send
	Then The message should not be sent
		And I get an error notification
