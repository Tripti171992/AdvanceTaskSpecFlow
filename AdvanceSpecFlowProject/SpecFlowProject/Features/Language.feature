Feature: LanguageFeature

As a user, I would like to add, delete and update a language, so that 
I can manage languages successfully.

Scenario Outline: Add a language with valid credentials
	Given I sigin to the Mars portal successfully with valid credentials'<Credentials>'
	When I added a language '<Language>'
	Then A language '<Language>' record should be added successfully
Examples:
	| Credentials                                                                                                                                                                               | Language                                                                                                                                                                              |
	| C:\\Users\\Tripti Mehta\\Desktop\\Industry Connect\\GitHubRepository\\AdvanceTaskSpecFlow\\AdvanceTaskSpecFlow\\AdvanceSpecFlowProject\\SpecFlowProject\\JsonObject\\UserInformation.json | C:\\Users\\Tripti Mehta\\Desktop\\Industry Connect\\GitHubRepository\\AdvanceTaskSpecFlow\\AdvanceTaskSpecFlow\\AdvanceSpecFlowProject\\SpecFlowProject\\JsonObject\\AddLanguage.json |
	
Scenario Outline: Delete a language with valid credentials
	Given I sigin to the Mars portal successfully with valid credentials'<Credentials>'
	When I delete a language '<Language>'
	Then A language '<Language>' record should be deleted successfully
Examples:
	| Credentials                                                                                                                                                                               | Language                                                                                                                                                                                 |
	| C:\\Users\\Tripti Mehta\\Desktop\\Industry Connect\\GitHubRepository\\AdvanceTaskSpecFlow\\AdvanceTaskSpecFlow\\AdvanceSpecFlowProject\\SpecFlowProject\\JsonObject\\UserInformation.json | C:\\Users\\Tripti Mehta\\Desktop\\Industry Connect\\GitHubRepository\\AdvanceTaskSpecFlow\\AdvanceTaskSpecFlow\\AdvanceSpecFlowProject\\SpecFlowProject\\JsonObject\\DeleteLanguage.json |
	
Scenario Outline: Update a language with valid credentials
	Given I sigin to the Mars portal successfully with valid credentials'<Credentials>'
	When I updated an old language '<OldLanguage>' details to new language detail '<NewLanguage>'
	Then A language '<NewLanguage>' should get updated
Examples:
	| Credentials                                                                                                                                                                               | OldLanguage                                                                                                                                                                                 | NewLanguage                                                                                                                                                                              |
	| C:\\Users\\Tripti Mehta\\Desktop\\Industry Connect\\GitHubRepository\\AdvanceTaskSpecFlow\\AdvanceTaskSpecFlow\\AdvanceSpecFlowProject\\SpecFlowProject\\JsonObject\\UserInformation.json | C:\\Users\\Tripti Mehta\\Desktop\\Industry Connect\\GitHubRepository\\AdvanceTaskSpecFlow\\AdvanceTaskSpecFlow\\AdvanceSpecFlowProject\\SpecFlowProject\\JsonObject\\LanguageForUpdate.json | C:\\Users\\Tripti Mehta\\Desktop\\Industry Connect\\GitHubRepository\\AdvanceTaskSpecFlow\\AdvanceTaskSpecFlow\\AdvanceSpecFlowProject\\SpecFlowProject\\JsonObject\\UpdateLanguage.json |

Scenario Outline: Cancel language addition with valid credentials
	Given I sigin to the Mars portal successfully with valid credentials'<Credentials>'
	When I cancelled adding a language '<Language>'
	Then A language '<Language>' should not get added
Examples:
	| Credentials                                                                                                                                                                               | Language                                                                                                                                                                                    |
	| C:\\Users\\Tripti Mehta\\Desktop\\Industry Connect\\GitHubRepository\\AdvanceTaskSpecFlow\\AdvanceTaskSpecFlow\\AdvanceSpecFlowProject\\SpecFlowProject\\JsonObject\\UserInformation.json | C:\\Users\\Tripti Mehta\\Desktop\\Industry Connect\\GitHubRepository\\AdvanceTaskSpecFlow\\AdvanceTaskSpecFlow\\AdvanceSpecFlowProject\\SpecFlowProject\\JsonObject\\CancelAddLanguage.json |

Scenario Outline: Not able to add duplicate language with valid credentials
	Given I sigin to the Mars portal successfully with valid credentials'<Credentials>'
	Then A duplicate language '<Language>' should not get added
Examples:
	| Credentials                                                                                                                                                                               | Language                                                                                                                                                                                       |
	| C:\\Users\\Tripti Mehta\\Desktop\\Industry Connect\\GitHubRepository\\AdvanceTaskSpecFlow\\AdvanceTaskSpecFlow\\AdvanceSpecFlowProject\\SpecFlowProject\\JsonObject\\UserInformation.json | C:\\Users\\Tripti Mehta\\Desktop\\Industry Connect\\GitHubRepository\\AdvanceTaskSpecFlow\\AdvanceTaskSpecFlow\\AdvanceSpecFlowProject\\SpecFlowProject\\JsonObject\\AddDuplicateLanguage.json |

Scenario Outline: Not able to add invalid language with valid credentials
	Given I sigin to the Mars portal successfully with valid credentials'<Credentials>'
	When I add an invalid language '<Language>'
	Then A language '<Language>' should not get added
Examples:
	| Credentials                                                                                                                                                                               | Language                                                                                                                                                                                     |
	| C:\\Users\\Tripti Mehta\\Desktop\\Industry Connect\\GitHubRepository\\AdvanceTaskSpecFlow\\AdvanceTaskSpecFlow\\AdvanceSpecFlowProject\\SpecFlowProject\\JsonObject\\UserInformation.json | C:\\Users\\Tripti Mehta\\Desktop\\Industry Connect\\GitHubRepository\\AdvanceTaskSpecFlow\\AdvanceTaskSpecFlow\\AdvanceSpecFlowProject\\SpecFlowProject\\JsonObject\\AddInvalidLanguage.json |

Scenario Outline: Not able to update invalid language with valid credentials
	Given I sigin to the Mars portal successfully with valid credentials'<Credentials>'
	When I update an old language '<OldLanguage>' details to new invalid language detail '<NewLanguage>'
	Then A language '<NewLanguage>' should not get updated
Examples:
	| Credentials                                                                                                                                                                               | OldLanguage                                                                                                                                                                           | NewLanguage                                                                                                                                                                                     |
	| C:\\Users\\Tripti Mehta\\Desktop\\Industry Connect\\GitHubRepository\\AdvanceTaskSpecFlow\\AdvanceTaskSpecFlow\\AdvanceSpecFlowProject\\SpecFlowProject\\JsonObject\\UserInformation.json | C:\\Users\\Tripti Mehta\\Desktop\\Industry Connect\\GitHubRepository\\AdvanceTaskSpecFlow\\AdvanceTaskSpecFlow\\AdvanceSpecFlowProject\\SpecFlowProject\\JsonObject\\AddLanguage.json | C:\\Users\\Tripti Mehta\\Desktop\\Industry Connect\\GitHubRepository\\AdvanceTaskSpecFlow\\AdvanceTaskSpecFlow\\AdvanceSpecFlowProject\\SpecFlowProject\\JsonObject\\UpdateInvalidLanguage.json |
	
Scenario Outline: Cancel updating language with valid credentials
	Given I sigin to the Mars portal successfully with valid credentials'<Credentials>'
	When I cancel update an old language '<OldLanguage>' details to new language detail '<NewLanguage>'
	Then A language '<NewLanguage>' should not get updated
Examples:
	| Credentials                                                                                                                                                                               | OldLanguage                                                                                                                                                                           | NewLanguage                                                                                                                                                                                    |
	| C:\\Users\\Tripti Mehta\\Desktop\\Industry Connect\\GitHubRepository\\AdvanceTaskSpecFlow\\AdvanceTaskSpecFlow\\AdvanceSpecFlowProject\\SpecFlowProject\\JsonObject\\UserInformation.json | C:\\Users\\Tripti Mehta\\Desktop\\Industry Connect\\GitHubRepository\\AdvanceTaskSpecFlow\\AdvanceTaskSpecFlow\\AdvanceSpecFlowProject\\SpecFlowProject\\JsonObject\\AddLanguage.json | C:\\Users\\Tripti Mehta\\Desktop\\Industry Connect\\GitHubRepository\\AdvanceTaskSpecFlow\\AdvanceTaskSpecFlow\\AdvanceSpecFlowProject\\SpecFlowProject\\JsonObject\\CancelUpdateLanguage.json |

