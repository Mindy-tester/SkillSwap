Feature: ShareSkillFeature1
	In order to share my skill
	As a skill trader
	I want to add, Edit and delete new skill

@mytag
Scenario: if user is able to add new skill
	Given User is on profile page
	When user click on share skill and add skill
	Then new skill should display on manage listings

	Scenario: if user is able to edit skill
	When user click on manage listings and click on edit listing
	Then skill should display with new updates

	Scenario: if user is able to delete skill
    When user click on manage listings and click on delete listing
	Then skill should not display in listings

