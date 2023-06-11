Feature: GoogleSearch

Perform a Google search with keyword 'Fireship'

@Google
Scenario: Search Fireship on Google
	Given Launch browser and navigate to https://www.google.com
	When Webpage is on https://www.google.com
	Then search fireship.io on searchbar
