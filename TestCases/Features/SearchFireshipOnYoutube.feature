Feature: GoogleSearch

Perform a Google search with keyword 'Fireship'

@Google
Scenario: Search Fireship on Google
	Given Launch browser
	When Webpage is on https://www.google.com
	Then search fireship on searchbar
