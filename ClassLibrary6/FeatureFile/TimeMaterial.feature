Feature: TimeMaterial
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@weblogin
Scenario: Create Time and Material Record with Valid inputs
	Given I have logged into TurnUp portal
	And I have navigated to Time and Materal Page
	Then I should be able create a Time and Material Record, and it gets saved successfully.

	Scenario: Edit Time and Material Record with Valid inputs
	Given I have logged into TurnUp portal
	And I have navigated to Time and Materal Page
	Then I should be able Edit a Time and Material Record, and data gets updated successfully.


	Scenario: Delete Time and Material Record with Valid inputs
	Given I have logged into TurnUp portal
	And I have navigated to Time and Materal Page
	Then I should be able Delete a Time and Material Record, and it gets deleted successfully.
