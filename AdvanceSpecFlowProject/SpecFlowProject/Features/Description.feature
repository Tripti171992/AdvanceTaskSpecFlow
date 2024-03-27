Feature: Description

As a user, I want to add/update description , so that
I can add/update description.

Scenario Outline: Add description in the user account.
	Given I sigin to the Mars portal successfully with valid credentials'<Credentials>'
	When I added description '<Description>'
	Then A description '<Description>' should get added

Examples:
	| Credentials                                                                                                                                                                               | Description                                                                                                                                                                              |
	| C:\\Users\\Tripti Mehta\\Desktop\\Industry Connect\\GitHubRepository\\AdvanceTaskSpecFlow\\AdvanceTaskSpecFlow\\AdvanceSpecFlowProject\\SpecFlowProject\\JsonObject\\UserInformation.json | C:\\Users\\Tripti Mehta\\Desktop\\Industry Connect\\GitHubRepository\\AdvanceTaskSpecFlow\\AdvanceTaskSpecFlow\\AdvanceSpecFlowProject\\SpecFlowProject\\JsonObject\\AddDescription.json |

Scenario Outline: Update description in the user account.
	Given I sigin to the Mars portal successfully with valid credentials'<Credentials>'
	When I updated description '<Description>'
	Then A description '<Description>' should get updated
Examples:
	| Credentials                                                                                                                                                                               | Description                                                                                                                                                                                 |
	| C:\\Users\\Tripti Mehta\\Desktop\\Industry Connect\\GitHubRepository\\AdvanceTaskSpecFlow\\AdvanceTaskSpecFlow\\AdvanceSpecFlowProject\\SpecFlowProject\\JsonObject\\UserInformation.json | C:\\Users\\Tripti Mehta\\Desktop\\Industry Connect\\GitHubRepository\\AdvanceTaskSpecFlow\\AdvanceTaskSpecFlow\\AdvanceSpecFlowProject\\SpecFlowProject\\JsonObject\\UpdateDescription.json |

Scenario Outline: Add out of limit description in the user account.
	Given I sigin to the Mars portal successfully with valid credentials'<Credentials>'
	When I added out of limit description '<Description>'
	Then A out of limit description '<Description>' not should get added

Examples:
	| Credentials                                                                                                                                                                               | Description                                                                                                                                                                                        |
	| C:\\Users\\Tripti Mehta\\Desktop\\Industry Connect\\GitHubRepository\\AdvanceTaskSpecFlow\\AdvanceTaskSpecFlow\\AdvanceSpecFlowProject\\SpecFlowProject\\JsonObject\\UserInformation.json | C:\\Users\\Tripti Mehta\\Desktop\\Industry Connect\\GitHubRepository\\AdvanceTaskSpecFlow\\AdvanceTaskSpecFlow\\AdvanceSpecFlowProject\\SpecFlowProject\\JsonObject\\AddOutOfLimitDescription.json |

Scenario Outline: Updating out of limit description in the user account.
	Given I sigin to the Mars portal successfully with valid credentials'<Credentials>'
	When I updated out of limit description '<Description>'
	Then A out of limit description '<Description>' not should get updated

Examples:
	| Credentials                                                                                                                                                                               | Description                                                                                                                                                                                           |
	| C:\\Users\\Tripti Mehta\\Desktop\\Industry Connect\\GitHubRepository\\AdvanceTaskSpecFlow\\AdvanceTaskSpecFlow\\AdvanceSpecFlowProject\\SpecFlowProject\\JsonObject\\UserInformation.json | C:\\Users\\Tripti Mehta\\Desktop\\Industry Connect\\GitHubRepository\\AdvanceTaskSpecFlow\\AdvanceTaskSpecFlow\\AdvanceSpecFlowProject\\SpecFlowProject\\JsonObject\\UpdateOutOfLimitDescription.json |
