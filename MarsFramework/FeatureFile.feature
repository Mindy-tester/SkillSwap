Feature: FeatureFile
	In order to share my skill
	As a skill trader
	I want to add and share new skill

@mytag
Scenario: if user is able to add new skill
	Given User is on profile page
	When user click on share skill and add skill
	Then new skill should display on manage listings
