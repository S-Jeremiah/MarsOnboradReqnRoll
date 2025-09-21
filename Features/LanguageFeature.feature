Feature: Language Feature

As a Register User
I would like to Add ,edit and delete a language 
@smoke
Scenario Outline: Adding a language to the list
	Given I logged in as a user
	When I navigate to the language management page
	When I add "<language>" and "<level>" to the list
	Then I should see the new "<language>" and "<level>" in the list
	Examples: 
	| language | level            |
	| Tamil    | Native/Bilingual |
	| Hindi    | Conversational   |
	| Spanish  | Basic            |
	| English  | Fluent           |



	Scenario Outline: updating the language
	Given I logged in as a user
	When I navigate to the language management page
	When I add "<existingLanguage>" and "<existingLevel>" to the list
	And I update the"<existingLanguage>" to "<newLanguage>"  and "<existingLevel>" to "<newLevel>" in the language list
	Then I should see the language "<newLanguage>" and "<newLevel>"  in the list
	Examples:
	| existingLanguage | newLanguage | existingLevel  | newLevel |  
	| Spanish		   | Telugu      | Basic          | Fluent   | 
	| Hindi			   | Malayalam   | Conversational | Fluent   |
  
  
  Scenario Outline: Performing Deletion of a language
  Given I logged in as a user
  When I navigate to the language management page
  When I add "<language>" to the list
  When I delete the language "<language>" from the list
  Then I should not see the language "<language>" in the list
  Examples:
	| language		 | languagelevel| 
	| English		 | Fluent       | 
	| Hindi			 | Conversationa| 

@Negative
Scenario Outline: Trying to add language with blank entry
Given I logged in as a user
When I navigate to the language management page
When I add blank"<language>" and "<level>" to the list		
Then I should see an error message indicating that the language name is required
Examples:
| language | level  |
|          | Fluent |


@Negative
Scenario Outline: Trying to add duplicate language entry
Given I logged in as a user
When I navigate to the language management page
And I ensure "<language>" with "<level>" exists in the list
And I add duplicate entry of "<language>" and "<level>" to the list
Then I should see an error message indicating that the language already exists
Examples: 
| language | level  |
| English  | Fluent |
| English  | Fluent |