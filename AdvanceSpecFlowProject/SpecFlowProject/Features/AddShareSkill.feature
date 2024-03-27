Feature: AddShareSkill

As a user, I want to add, delete and update skill , so that
I can manage skill .

Scenario Outline: Add a skill in the user account.
	Given I sigin to the Mars portal successfully with valid credentials'<Credentials>'
	When I added skill '<Skill>'
	Then A skill '<Skill>' should get added

Examples:
	| Credentials                                                                                                                                                                               | Skill                                                                                                                                                                              |
	| C:\\Users\\Tripti Mehta\\Desktop\\Industry Connect\\GitHubRepository\\AdvanceTaskSpecFlow\\AdvanceTaskSpecFlow\\AdvanceSpecFlowProject\\SpecFlowProject\\JsonObject\\UserInformation.json | C:\\Users\\Tripti Mehta\\Desktop\\Industry Connect\\GitHubRepository\\AdvanceTaskSpecFlow\\AdvanceTaskSpecFlow\\AdvanceSpecFlowProject\\SpecFlowProject\\JsonObject\\AddSkill.json |

Scenario Outline: Cancel Adding skill in the user account.
	Given I sigin to the Mars portal successfully with valid credentials'<Credentials>'
	When I cancelled adding skill '<Skill>'
	Then A skill '<Skill>' should not get added

Examples:
	| Credentials                                                                                                                                                                               | Skill                                                                                                                                                                                         |
	| C:\\Users\\Tripti Mehta\\Desktop\\Industry Connect\\GitHubRepository\\AdvanceTaskSpecFlow\\AdvanceTaskSpecFlow\\AdvanceSpecFlowProject\\SpecFlowProject\\JsonObject\\UserInformation.json | C:\\Users\\Tripti Mehta\\Desktop\\Industry Connect\\GitHubRepository\\AdvanceTaskSpecFlow\\AdvanceTaskSpecFlow\\AdvanceSpecFlowProject\\SpecFlowProject\\JsonObject\\CancelAddShareSkill.json |

Scenario Outline: Adding invalid skill in the user account.
	Given I sigin to the Mars portal successfully with valid credentials'<Credentials>'
	When I add invalid skill '<Skill>'
	Then A skill '<Skill>' should not get added

Examples:
	| Credentials                                                                                                                                                                               | Skill                                                                                                                                                                                          |
	| C:\\Users\\Tripti Mehta\\Desktop\\Industry Connect\\GitHubRepository\\AdvanceTaskSpecFlow\\AdvanceTaskSpecFlow\\AdvanceSpecFlowProject\\SpecFlowProject\\JsonObject\\UserInformation.json | C:\\Users\\Tripti Mehta\\Desktop\\Industry Connect\\GitHubRepository\\AdvanceTaskSpecFlow\\AdvanceTaskSpecFlow\\AdvanceSpecFlowProject\\SpecFlowProject\\JsonObject\\AddInvalidShareSkill.json |

Scenario Outline: Adding skill with past end date in the user account.
	Given I sigin to the Mars portal successfully with valid credentials'<Credentials>'
	When I add skill '<Skill>' with past end date
	Then A skill '<Skill>' should not get added

Examples:
	| Credentials                                                                                                                                                                               | Skill                                                                                                                                                                                             |
	| C:\\Users\\Tripti Mehta\\Desktop\\Industry Connect\\GitHubRepository\\AdvanceTaskSpecFlow\\AdvanceTaskSpecFlow\\AdvanceSpecFlowProject\\SpecFlowProject\\JsonObject\\UserInformation.json | C:\\Users\\Tripti Mehta\\Desktop\\Industry Connect\\GitHubRepository\\AdvanceTaskSpecFlow\\AdvanceTaskSpecFlow\\AdvanceSpecFlowProject\\SpecFlowProject\\JsonObject\\AddSkillWithPastEndDate.json |

Scenario Outline: Validate empty title validation message.
	Given I sigin to the Mars portal successfully with valid credentials'<Credentials>'
	When I add skill '<Skill>' with empty title
	Then An error message should display for empty title

Examples:
	| Credentials                                                                                                                                                                               | Skill                                                                                                                                                                                                         |
	| C:\\Users\\Tripti Mehta\\Desktop\\Industry Connect\\GitHubRepository\\AdvanceTaskSpecFlow\\AdvanceTaskSpecFlow\\AdvanceSpecFlowProject\\SpecFlowProject\\JsonObject\\UserInformation.json | C:\\Users\\Tripti Mehta\\Desktop\\Industry Connect\\GitHubRepository\\AdvanceTaskSpecFlow\\AdvanceTaskSpecFlow\\AdvanceSpecFlowProject\\SpecFlowProject\\JsonObject\\ValidateEmptyTitleValidationMessage.json |

Scenario Outline: Validate empty description validation message.
	Given I sigin to the Mars portal successfully with valid credentials'<Credentials>'
	When I add skill '<Skill>' with empty description
	Then An error message should display for empty description

Examples:
	| Credentials                                                                                                                                                                               | Skill                                                                                                                                                                                                               |
	| C:\\Users\\Tripti Mehta\\Desktop\\Industry Connect\\GitHubRepository\\AdvanceTaskSpecFlow\\AdvanceTaskSpecFlow\\AdvanceSpecFlowProject\\SpecFlowProject\\JsonObject\\UserInformation.json | C:\\Users\\Tripti Mehta\\Desktop\\Industry Connect\\GitHubRepository\\AdvanceTaskSpecFlow\\AdvanceTaskSpecFlow\\AdvanceSpecFlowProject\\SpecFlowProject\\JsonObject\\ValidateEmptyDescriptionValidationMessage.json |
