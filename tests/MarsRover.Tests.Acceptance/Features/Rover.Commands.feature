Feature: Rover commands execution
	As a member of the team that explores Mars
	I want to send commands to the rover
	In order to discover unknown locations

	Rule: For a list of valid commands, the rover execute the sequence and reports its new position
		Scenario: Curiosity makes its first short drive after landing
			Given the rover curiosity has landed on Mars at coordinates (15, 20) facing North
			When a team member sends command 'LFFFRFLLFFRRFRFFFL'
			Then the rover signals its position at (15, 20) facing North

	Rule: When it receive an invalid command, the rover stops the sequence and reports the error and its last position
		#Scenario: Curiosity receives an invalid commands sequence
		#	Given the rover curiosity is on Mars at coordinates (150, -20) facing East
		#	When a team member sends command 'FFM'
		#	Then the rover reports an error
		#	And signals its position at (152, -20) facing East
