Feature: Registration

As a user, I want to try registeration to mars with invalid and existing credentials, so that
I can validate the registration functionality.

Scenario Outline: Register to Mars with existing credentials
	Given I registered into the Mars portal with existing credentials '<Credentials>'
	Then A user should not be registered successfully
Examples:
	| Credentials                                                                                                                                                                                               |
	| C:\\Users\\Tripti Mehta\\Desktop\\Industry Connect\\GitHubRepository\\AdvanceTaskSpecFlow\\AdvanceTaskSpecFlow\\AdvanceSpecFlowProject\\SpecFlowProject\\JsonObject\\RegistrationExistingCredentials.json |

Scenario Outline: Register to Mars with invalid credentials
	Given I am not able to register into the Mars portal with invalid credentials '<Credentials>'
Examples:
	| Credentials                                                                                                                                                                                              |
	| C:\\Users\\Tripti Mehta\\Desktop\\Industry Connect\\GitHubRepository\\AdvanceTaskSpecFlow\\AdvanceTaskSpecFlow\\AdvanceSpecFlowProject\\SpecFlowProject\\JsonObject\\RegistrationInvalidInformation.json |
