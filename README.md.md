**Mars Automation Project**

**Implementation Approach**



This project automates Add, Edit, and Delete operations for Languages and Skills on the Mars application.

The framework is implemented using:



SpecFlow (ReqnRoll) + NUnit for BDD-style test execution.



Page Object Model (POM) for maintainable and reusable test scripts.



Hooks to manage browser setup and teardown.



Assertions to validate successful operations.



The tests are written in Gherkin syntax for readability and easy collaboration.



**Page Object Model (POM) Structure**



**Features**

* **LanguageFeature.feature**
* **SkillFeature.feature**

**Pages**

* **HomePage.cs**
* **LanguagePage.cs**
* **LoginPage.cs**
* **SkillPage.cs**

**StepDefinitions**

* **LanguageFeatureStefDefinition.cs**
* **SkillFeatureStefDefinition.cs**

**Utilities**

* **Hooks.cs**
* **Waits.cs**
