Feature: YoutubeSearch

Perform a Youtube search with keyword 'Fireship'

@Youtube
Scenario: Search Fireship on youtube
	Given Launch browser and navigate to https://www.youtube.com
	When Webpage is on https://www.youtube.com
	Then search fireship.io on searchbar
