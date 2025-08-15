Feature: Language Feature

As a Register User
I would like to Add ,edit and delete a language 
@smoke
Scenario Outline: Adding a language to the list
	Given I logged in as a user
	When I navigate to the language management page
	When I add "<newlanguage>" and "<languagelevel>" to the list
	Then I should see the new "<newlanguage>" and "<languagelevel>" in the list
	Examples: 
	| newlanguage | languagelevel   |
	| Tamil       |Native/Bilingual |
	| Hindi       |Conversational	|
	| Spanish     |Basic            |
	| English     |Fluent           |


  
  Scenario Outline: Editing an existing language
	Given I logged in as a user
	When I navigate to the language management page
	And I update the"<languageName>" to "<updatedlanguageName>" in the language list
	And I update"<languagelevel>" to "<updatedlanguagelevel>"
	Then I should see the language "<updatedlanguageName>" in the list
	And the language level should be "<updatedlanguagelevel>" in the list

	

	Examples:
	| languageName | updatedlanguageName | languagelevel  | updatedlanguagelevel |  
	| Spanish      | Telugu              | Basic          | Fluent               | 
	| Hindi        | Malayalam           | Conversational | Fluent               |


	
  Scenario Outline: Performing Deletion of a language
  Given I logged in as a user
  When I navigate to the language management page
  When I delete the language "<deletelanguage>" from the list
  Then I should not see the language "<deletelanguage>" in the list
  Examples:
	| deletelanguage |	
	| Tamil          |		
	| Hindi          |