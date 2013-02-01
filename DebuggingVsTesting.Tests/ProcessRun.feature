Feature: ProcessRun
	In order to make stuff
	As a control system
	I want to be in control of it

@example
Scenario: Running for 200 cycles does 2 cleanups
	Given I have a conveyor setup for 15 foot per cycle
	And I have cleanup after every 100 cycles
	And I have a control system ready to run 200 cycles
	And I have a robot that produces 3 widgets per build	
	When I run these cycles
	Then the result should be a cleaup after these cycles: 100, 200
	And the result should have 200 movements with a total 3000 feet moved
	And the result should have 600 widgets
