Feature: Skill Feature

As a Register User
I would like to Add ,edit and delete a Skill 
@smoke
Scenario Outline: Adding a Skill to the list
	Given I logged in as a register user
	When I add "<skillname>" and "<skilllevel>" to the list of skills
	Then I should see the new "<skillname>" and "<skilllevel>" in the list below
	Examples: 
	| skillname  | skilllevel    |
	| Coding     |Intermediate	 |
	| API        |Beginner		 |
	| Manual     |Expert         |
	| SQL        |Beginner	     |

	

Scenario Outline: Performing Deletion of an Existing Skill
	Given I logged in as a user
	 When I add the "<addskill>" to the list
	And I delete the Skill "<skill>" from the list
	Then I should not see the Skill "<skill>" in the list
	Examples:
	| skill		  |
	| SQL         |
	| API         |

Scenario Outline: Updating skill feature 
	Given I logged in as a register user in the portal
	When I add "<skillname>" and "<skilllevel>" to the table
	When I try to update the "<skillname>" "<skilllevel>" to "<newskillname>" "<newskilllevel>" in the table
	And I should see updated "<newskillname>" and "<newskilllevel>" in the table 
	Examples: 
	| skillname | skilllevel   | newskillname | newskilllevel |
	| Coding    | Intermediate | Automation   | Expert        |
	| Manual    | Expert       | Jira         | Intermediate  |


@Negative
Scenario Outline: Adding the Duplicate language
	Given I logged in as a user
	When I ensure "<skillname>" and "<skilllevel>" are in list
	Then I add duplicate entry of "<skillname>" and "<skilllevel>" 
	Then I should see error message indicating skill is already exists
	Examples: 
	| skillname | skilllevel |
	| Coding    | Expert     |
	| Coding    | Expert     |


@Negative
Scenario Outline: Trying to add the skill with blank space
	Given I logged in as a register user
	When I try to add skill "<skillname>" with blank space and "<skilllevel>"
	Then I should see the error message saying please enter skill and level.
	Examples: 
	| skillname | skilllevel |
	|           | Expert     |

Scenario Outline: Try deleting a skill that does not exist
Given I logged in as a register user
When I add the "<addskill>" to the list
When I try to delete a non-existing skill "<skill>"
Then I should see a message indicating that the skill "<skill>" does not exist
Examples:
| addskill | skill |
| Jira  | SQL   |