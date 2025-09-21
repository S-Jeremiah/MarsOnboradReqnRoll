Feature: Login Feature

As a Register User
I would like to Login to the application
@tag1
Scenario: Login with valid credentials, and be redirected to the dashboard in the home page
	Given I navigate to the login page 
	When I enter valid "<emailID>" and "<password>"
	Then I should be redirected to the dashboard and see my profile name
	Examples: 
	| emailID               | password  |
	| jeroshirley@gmail.com | World!123 |


	@Negative
	Scenario: Login with correctemail and blankpassword
	Given I navigate to the login page 
	When I enter correctemail and incorrectpassword
		| Email                 | password |
		| jeroshirley@gmail.com |     	   |
	Then I should see an error message indicating invalid password

	@Negative
	Scenario: Login with invalidemail and correctpassword
	Given I navigate to the login page 
	When I enter invalidemail and correctpassword
		| Email   | password |
		| abctybk | World!123 |
	Then I should see an error message indicating invalid email

	@Negative
	Scenario: Login with correct email and wrong password
	Given I navigate to the login page 
	When I enter correct email and wrong password
		| Email                 | password |
		| jeroshirley@gmail.com | hello123 |
	Then I should see an error message to check mail
