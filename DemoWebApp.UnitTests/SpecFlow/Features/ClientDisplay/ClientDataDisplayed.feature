Feature: Client Data Displayed

@mytag
Scenario: Display client information
	Given There are clients defined as
		| Name      | Address                            | NumAccounts |
		| Client #1 | 123 Test St., Testington, NJ 08615 | 2           |
		| Client #2 | 453 Test St., Testington, NJ 08615 | 2           |
	When I load the page
	Then all clients should be displayed with their name, address, and account summaries
