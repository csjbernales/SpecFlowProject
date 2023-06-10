Feature: GoogleSearch

Perform a Google search

@Google
Scenario: Search Fireship on Google
	Given Launch browser
	When Webpage is on google.com
	Then search fireship on searchbar
