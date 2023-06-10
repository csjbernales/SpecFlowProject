Feature: SearchFireshipOnYoutube

Search 'Fireship' on youtube

@Youtube
Scenario: Search fireship on youtube
	Given Open browser
	When webpage is on youtube.com
	Then search fireship on searchbar
