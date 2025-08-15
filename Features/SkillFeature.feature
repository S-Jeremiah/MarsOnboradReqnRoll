Feature: Skill Feature

As a Register User
I would like to Add ,edit and delete a Skill 
@smoke
Scenario Outline: Adding a Skill to the list
	Given I logged in as a register user
	When I navigate to the Skill management page
	And I add "<newSkill>" and "<Skilllevel>" to the list of skills
	Then I should see the new "<newSkill>" and "<Skilllevel>" in the list below
	Examples: 
	| newSkill  | Skilllevel    |
	| Coding    |Intermediate	|
	| API       |Beginner		|
	| Manual    |Expert         |
	| SQL       |Beginner	    |

	Scenario Outline: Editing an existing Skill
	Given I logged in as a user
	When I navigate to the Skill management page
	And I update the"<SkillName>" to "<updatedSkillName>" in the skill list
	And I update"<Skilllevel>" to "<updatedSkilllevel>" in the skill list
	Then I should see the Skill "<updatedSkillName>" in the list
	And the Skill level should be "<updatedSkilllevel>"
	
	

	Examples:
	| SkillName   | updatedSkillName | Skilllevel     | updatedSkilllevel | 
	| Coding      | Automation		 | Intermediate   | Expert            | 
	| Manual      | Jira			 | Expert		  | Intermediate      | 

Scenario Outline: Performing Deletion of an Existing Skill
	Given I logged in as a user
	When I navigate to the Skill management page
	And I delete the Skill "<deleteSkill>" from the list
	Then I should not see the Skill "<deleteSkill>" in the list
	Examples:
	| deleteSkill |
	| SQL         |
	| API         |
