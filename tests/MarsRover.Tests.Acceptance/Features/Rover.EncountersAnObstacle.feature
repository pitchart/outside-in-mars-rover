Feature: The rover encounters an obstacle
	As a member of the team that explores Mars
	I want the rover to detect obstacles and stop commands execution
	In order to cartography the field

	Rule: The rover moves up to the last possible point, stops the sequence and reports the obstacle
		#Scenario: Curiosity encounters a rock on its path
		#	Given the rover curiosity is on Mars at coordinates (150, -20) facing East
		#	And a rock is known at (152, -20)
		#	When a team member sends command 'FFLFR'
		#	Then the rover reports an obstacle
		#	And signals its position at (151, -20) facing East

		#Scenario: Curiosity receives a command making it cross Hale Crater
		#	Given the rover curiosity is on Mars at coordinates (128, -35) facing South
		#	And a crater is known from (130, -34) to (132, -36)
		#	When a team member sends command 'FLFFLFR'
		#	Then the rover reports an obstacle
		#	And signals its position at (151, -20) facing East
