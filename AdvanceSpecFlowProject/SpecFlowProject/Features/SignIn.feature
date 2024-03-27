Feature: SignIn

As a user, I wannt to login to mars with valid and invalid credentials, so
that I can validate the login functionality.

Scenario Outline: Sign in to Mars with valid credentials
	Given I sigin to the Mars portal successfully with valid credentials'<Credentials>'
	Then User should be taken to his '<Credentials>'home page successfully
Examples:
	| Credentials                                                                                                                                                                               |
	| C:\\Users\\Tripti Mehta\\Desktop\\Industry Connect\\GitHubRepository\\AdvanceTaskSpecFlow\\AdvanceTaskSpecFlow\\AdvanceSpecFlowProject\\SpecFlowProject\\JsonObject\\UserInformation.json |

Scenario Outline: Sign in to Mars with invalid credentials
	Given I am not taken to home page on sigin with invalid credentials'<Credentials>'
Examples:
	| Credentials                                                                                                                                                                                      |
	| C:\\Users\\Tripti Mehta\\Desktop\\Industry Connect\\GitHubRepository\\AdvanceTaskSpecFlow\\AdvanceTaskSpecFlow\\AdvanceSpecFlowProject\\SpecFlowProject\\JsonObject\\InvalidUserInformation.json |
