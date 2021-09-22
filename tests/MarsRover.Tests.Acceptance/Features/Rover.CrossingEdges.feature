Feature: Rover is crossing edges of the map
	As a member of the team that explores Mars
	I want the rover to cross map edges
	In order to make it turn around the planet

	Scenario: Test rover makes a roadtrip at Chile high desert
		Given the test rover is at Chile high desert at coordinates (0, 0) facing North
		When a team member sends command 'FFFFFLFFFFFRFF'
		Then the rover signals its position at (0, 2) facing North
