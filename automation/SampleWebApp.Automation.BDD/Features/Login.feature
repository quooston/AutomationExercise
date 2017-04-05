@Chrome
Feature: Login
	In order to view and update my personal information
	As a user
	I want to login to the website

	Scenario Outline: A registered user is able to log in with valid credentials
		Given a user has already registered with a valid '<Username>' and '<Password>'
		When the user logs in with their valid credentials
		Then the user is logged into the website
		And the user can see their personal information
		
		Examples:
		| Example Description                     | Username                                             | Password            |
		| Valid username and password, static     | "somebody@planetinnovation.com.au"                   | "password123"       |
		| Valid username and password, regex      | ^[A-Za-z0-9]{1,60}@[A-Za-z0-9]{5,10}\.[A-Za-z]{2,4}$ | ^[A-Za-z0-9]{8,20}$ |
		| Valid username with minimum length (6)  | ^[A-Za-z0-9]{1}@[A-Za-z0-9]{1}\.[A-Za-z]{2}$         | ^[A-Za-z0-9]{8,20}$ |
		| Valid username with maximum length (76) | ^[A-Za-z0-9]{60}@[A-Za-z0-9]{10}\.[A-Za-z]{4}$       | ^[A-Za-z0-9]{8,20}$ |
		| Valid password with minimum length (8)  | ^[A-Za-z0-9]{1,60}@[A-Za-z0-9]{5,10}\.[A-Za-z]{2,4}$ | ^[A-Za-z0-9]{8}$    |
		| Valid password with maximum length (20) | ^[A-Za-z0-9]{1,60}@[A-Za-z0-9]{5,10}\.[A-Za-z]{2,4}$ | ^[A-Za-z0-9]{20}$   |

	Scenario Outline: A registered user is not able to log in with invalid credentials
		Given a user has already registered with a valid '<Username>' and '<Password>'
		When the user attempts to log in with invalid '<Credentials>'
		Then the user is not logged into the website
		And an '<Error Message>' is returned for the corresponding field on the login page
		
		Examples:
		| Example Description                 | Username                                             | Password            | Credentials | Error Message          |
		| Valid username and invalid password | ^[A-Za-z0-9]{1,60}@[A-Za-z0-9]{5,10}\.[A-Za-z]{2,4}$ | ^[A-Za-z0-9]{8,20}$ | Form        | Invalid login attempt. |
		| Invalid username and valid password | ^[A-Za-z0-9]{1,60}@[A-Za-z0-9]{5,10}\.[A-Za-z]{2,4}$ | ^[A-Za-z0-9]{8,20}$ | Form        | Invalid login attempt. |

	
	Scenario Outline: Username out of bounds
		Given a user of the website is on the login page
		When the user attempts to log in with a '<Field>' '<Username>' that is out of bounds
		Then the user is not logged into the website
		And an '<Error Message>' is returned for the corresponding field on the login page
		
		Examples:
		| Example Description                                        | Field    | Username                                            | Error Message                   |
		| Empty username                                             | Username | ""                                                  | The Username field is required. |
		| Username is not a valid email address                      | Username | ^[A-Za-z0-9]{1,60}[A-Za-z0-9]{5,10}\.[A-Za-z]{2,4}$ | Invalid Username                |
		| Username with less than minimum length of characters (<6)  | Username | ^[A-Za-z0-9]{1}@[A-Za-z0-9]{1}\.[A-Za-z]{1}$        | Username is too short           |
		| Username with more than maximum length of characters (>76) | Username | ^[A-Za-z0-9]{60}@[A-Za-z0-9]{11}\.[A-Za-z]{4}$      | Username is too long            |

	
	Scenario Outline: Password out of bounds
		Given a user of the website is on the login page
		When the user attempts to log in with a '<Field>' '<Password>' that is out of bounds
		Then the user is not logged into the website
		And an '<Error Message>' is returned for the corresponding field on the login page
		
		Examples:
		| Example Description                                        | Field    | Password              | Error Message                   |
		| Empty password                                             | Password | ""                    | The Password field is required. |
		| Password with unsupported characters                       | Password | ^[A-Za-z0-9]{7,19}\?$ | Invalid password                |
		| Password with less than minimum length of characters (<8)  | Password | ^[A-Za-z0-9]{7}$      | Password is too short           |
		| Password with more than maximum length of characters (>20) | Password | ^[A-Za-z0-9]{21}$     | Password is too long            |