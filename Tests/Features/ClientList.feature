Feature: Client List
	In order to find out information about my clients
	the homepage should show a summary of all known clients

@mytag
Scenario: Client list on homepage
	Given I have clients defined in the system
	When I navigate to the home page
	Then I should see summaries for all of the clients defined in the system
