@Chrome
Feature: Update Personal Information
	In order to have my correct and up-to-date details stored in the system
	As a user
	I want to update my personal information

	Background:
		Given a user has successfully logged on to the website
		And the user is on the personal information page
		


	Scenario Outline: Update name - valid
		When the user updates with a valid '<Family name>' and '<Given name>'
		Then the entered names are saved
		And the user can see their updated names
		
		Examples:
		| Example Description                                                                       | Family name      | Given name                                   |
		| Valid family name and given name with a length between minimum and maximum (2-30), static | "Smith"          | "John"                                       |
		| Valid family name and given name with a length between minimum and maximum (2-30), regex  | ^[A-Za-z]{2,30}$ | ^[A-Za-z]{2,30}$                             |
		| Valid family name and given name with minimum length (2)                                  | ^[A-Za-z]{2}$    | ^[A-Za-z]{2}$                                |
		| Valid family name and given name with maximum length (30)                                 | ^[A-Za-z]{30}$   | ^[A-Za-z]{30}$                               |
		| Valid family name only                                                                    | ^[A-Za-z]{2,30}$ | ""                                           |
		| Valid given name only                                                                     | ""               | ^[A-Za-z]{2,30}$                             |
		| Valid family name with multiple given names                                               | ^[A-Za-z]{2,30}$ | ^[A-Za-z]{8} {1}[A-Za-z]{8} {1}[A-Za-z]{12}$ |
		| Valid family name with valid special characters, e.g. apostrophe                          | O’Hare           | ^[A-Za-z]{2,30}$                             |
		| Valid given name with valid special characters, e.g. hyphen                               | ^[A-Za-z]{2,30}$ | Vanessa-Kate                                 |

	
	Scenario Outline: Update name - invalid
		When the user updates with an invalid '<Family name>' and or '<Given name>'
		Then the entered names are not saved
		And an '<Error Message>' is returned for the '<Field>' on the personal information page
		
		Examples:
		| Example Description                                           | Family name                            | Given name                             | Field      | Error Message                 |
		| No family name and given name                                 | ""                                     | ""                                     | Last Name  | At least one name is required |
		| Family name with numeric characters                           | ^[A-Za-z]{1,14}[0-9]{1}[A-Za-z]{1,15}$ | ^[A-Za-z]{2,30}$                       | Last Name  | Invalid Last Name             |
		| Family name with invalid special characters                   | ^[A-Za-z]{1,14},{1}[A-Za-z]{1,15}$     | ^[A-Za-z]{2,30}$                       | Last Name  | Invalid Last Name             |
		| Family name with less than minimum length of characters (<2)  | ^[A-Za-z]{1}$                          | ^[A-Za-z]{2,30}$                       | Last Name  | Last Name too short           |
		| Family name with more than maximum length of characters (>30) | ^[A-Za-z]{31}$                         | ^[A-Za-z]{2,30}$                       | Last Name  | Last Name too long            |
		| Given name with numeric characters                            | ^[A-Za-z]{2,30}$                       | ^[A-Za-z]{1,14}[0-9]{1}[A-Za-z]{1,15}$ | First Name | Invalid First Name            |
		| Given name with invalid special characters                    | ^[A-Za-z]{2,30}$                       | ^[A-Za-z]{1,14},{1}[A-Za-z]{1,15}$     | First Name | Invalid First Name            |
		| Given name with less than minimum length of characters (<2)   | ^[A-Za-z]{2,30}$                       | ^[A-Za-z]{1}$                          | First Name | First Name is too short       |
		| Given name with more than maximum length of characters (>30)  | ^[A-Za-z]{2,30}$                       | ^[A-Za-z]{31}$                         | First Name | First Name is too long        |