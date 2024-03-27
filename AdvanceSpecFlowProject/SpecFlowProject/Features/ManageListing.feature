Feature: ManageListing

As a user, I would like to add, delete and update a skill, so that 
I can manage skills successfully.

Scenario Outline: Delete skill in the user account.
	Given I sigin to the Mars portal successfully with valid credentials'<Credentials>'
	When I deleted skill '<Skill>'
	Then A skill '<Skill>' should get deleted
Examples:
	| Credentials                                                                                                                                                                               | Skill                                                                                                                                                                                      |
	| C:\\Users\\Tripti Mehta\\Desktop\\Industry Connect\\GitHubRepository\\AdvanceTaskSpecFlow\\AdvanceTaskSpecFlow\\AdvanceSpecFlowProject\\SpecFlowProject\\JsonObject\\UserInformation.json | C:\\Users\\Tripti Mehta\\Desktop\\Industry Connect\\GitHubRepository\\AdvanceTaskSpecFlow\\AdvanceTaskSpecFlow\\AdvanceSpecFlowProject\\SpecFlowProject\\JsonObject\\DeleteShareSkill.json |
	
Scenario Outline: Update a skill in the user account.
	Given I sigin to the Mars portal successfully with valid credentials'<Credentials>'
	When I updated a skill '<Skill>' detail to new skilldetails '<NewSkill>'
	Then A skill '<NewSkill>' should get updated
Examples:
	| Credentials                                                                                                                                                                               | Skill                                                                                                                                                                                        | NewSkill                                                                                                                                                                                       |
	| C:\\Users\\Tripti Mehta\\Desktop\\Industry Connect\\GitHubRepository\\AdvanceTaskSpecFlow\\AdvanceTaskSpecFlow\\AdvanceSpecFlowProject\\SpecFlowProject\\JsonObject\\UserInformation.json | C:\\Users\\Tripti Mehta\\Desktop\\Industry Connect\\GitHubRepository\\AdvanceTaskSpecFlow\\AdvanceTaskSpecFlow\\AdvanceSpecFlowProject\\SpecFlowProject\\JsonObject\\UpdateSkillDetails.json | C:\\Users\\Tripti Mehta\\Desktop\\Industry Connect\\GitHubRepository\\AdvanceTaskSpecFlow\\AdvanceTaskSpecFlow\\AdvanceSpecFlowProject\\SpecFlowProject\\JsonObject\\UpdateSkillNewDetais.json |

Scenario Outline: Update invalid skill in the user account.
	Given I sigin to the Mars portal successfully with valid credentials'<Credentials>'
	When I updated a skill '<Skill>' detail to new invalid skilldetails '<NewSkill>'
	Then A skill '<NewSkill>' should not get updated
Examples:
	| Credentials                                                                                                                                                                               | NewSkill                                                                                                                                                                                            | Skill                                                                                                                                                                                    |
	| C:\\Users\\Tripti Mehta\\Desktop\\Industry Connect\\GitHubRepository\\AdvanceTaskSpecFlow\\AdvanceTaskSpecFlow\\AdvanceSpecFlowProject\\SpecFlowProject\\JsonObject\\UserInformation.json | C:\\Users\\Tripti Mehta\\Desktop\\Industry Connect\\GitHubRepository\\AdvanceTaskSpecFlow\\AdvanceTaskSpecFlow\\AdvanceSpecFlowProject\\SpecFlowProject\\JsonObject\\UpdateInvalidSkillDetails.json | C:\\Users\\Tripti Mehta\\Desktop\\Industry Connect\\GitHubRepository\\AdvanceTaskSpecFlow\\AdvanceTaskSpecFlow\\AdvanceSpecFlowProject\\SpecFlowProject\\JsonObject\\SkillForUpdate.json |

Scenario Outline: Activate skill status.
	Given I sigin to the Mars portal successfully with valid credentials'<Credentials>'
	Then Skill'<Skill>' status should get changed to active on activation
Examples:
	| Credentials                                                                                                                                                                               | Skill                                                                                                                                                                                        |
	| C:\\Users\\Tripti Mehta\\Desktop\\Industry Connect\\GitHubRepository\\AdvanceTaskSpecFlow\\AdvanceTaskSpecFlow\\AdvanceSpecFlowProject\\SpecFlowProject\\JsonObject\\UserInformation.json | C:\\Users\\Tripti Mehta\\Desktop\\Industry Connect\\GitHubRepository\\AdvanceTaskSpecFlow\\AdvanceTaskSpecFlow\\AdvanceSpecFlowProject\\SpecFlowProject\\JsonObject\\ActivateShareSkill.json |
		
Scenario Outline: Deactivate skill status.
	Given I sigin to the Mars portal successfully with valid credentials'<Credentials>'
	Then Skill'<Skill>' status should get changed to deactive on deactivation
Examples:
	| Credentials                                                                                                                                                                               | Skill                                                                                                                                                                                          |
	| C:\\Users\\Tripti Mehta\\Desktop\\Industry Connect\\GitHubRepository\\AdvanceTaskSpecFlow\\AdvanceTaskSpecFlow\\AdvanceSpecFlowProject\\SpecFlowProject\\JsonObject\\UserInformation.json | C:\\Users\\Tripti Mehta\\Desktop\\Industry Connect\\GitHubRepository\\AdvanceTaskSpecFlow\\AdvanceTaskSpecFlow\\AdvanceSpecFlowProject\\SpecFlowProject\\JsonObject\\DeactivateShareSkill.json |

Scenario Outline: Navigate to next page.
	Given I sigin to the Mars portal successfully with valid credentials'<Credentials>'
	Then I navigated to next page on clicking on next page
Examples:
	| Credentials                                                                                                                                                                               |
	| C:\\Users\\Tripti Mehta\\Desktop\\Industry Connect\\GitHubRepository\\AdvanceTaskSpecFlow\\AdvanceTaskSpecFlow\\AdvanceSpecFlowProject\\SpecFlowProject\\JsonObject\\UserInformation.json |

Scenario Outline: Navigate to previous page.
	Given I sigin to the Mars portal successfully with valid credentials'<Credentials>'
	Then I navigated to previous page on clicking on previous page
Examples:
	| Credentials                                                                                                                                                                               |
	| C:\\Users\\Tripti Mehta\\Desktop\\Industry Connect\\GitHubRepository\\AdvanceTaskSpecFlow\\AdvanceTaskSpecFlow\\AdvanceSpecFlowProject\\SpecFlowProject\\JsonObject\\UserInformation.json |

Scenario Outline: Watch skill details.
	Given I sigin to the Mars portal successfully with valid credentials'<Credentials>'
	Then I was nevigated to skill'<Skill>' details page on clicking on watch icon
Examples:
	| Credentials                                                                                                                                                                               | Skill                                                                                                                                                                                            |
	| C:\\Users\\Tripti Mehta\\Desktop\\Industry Connect\\GitHubRepository\\AdvanceTaskSpecFlow\\AdvanceTaskSpecFlow\\AdvanceSpecFlowProject\\SpecFlowProject\\JsonObject\\UserInformation.json | C:\\Users\\Tripti Mehta\\Desktop\\Industry Connect\\GitHubRepository\\AdvanceTaskSpecFlow\\AdvanceTaskSpecFlow\\AdvanceSpecFlowProject\\SpecFlowProject\\JsonObject\\WatchShareSkillDetails.json |

Scenario Outline: Cancel deleting skill in the user account.
	Given I sigin to the Mars portal successfully with valid credentials'<Credentials>'
	When I cancel deleting skill '<Skill>'
	Then A skill '<Skill>' should not get deleted
Examples:
	| Credentials                                                                                                                                                                               | Skill                                                                                                                                                                                            |
	| C:\\Users\\Tripti Mehta\\Desktop\\Industry Connect\\GitHubRepository\\AdvanceTaskSpecFlow\\AdvanceTaskSpecFlow\\AdvanceSpecFlowProject\\SpecFlowProject\\JsonObject\\UserInformation.json | C:\\Users\\Tripti Mehta\\Desktop\\Industry Connect\\GitHubRepository\\AdvanceTaskSpecFlow\\AdvanceTaskSpecFlow\\AdvanceSpecFlowProject\\SpecFlowProject\\JsonObject\\CancelDeleteShareSkill.json |
	