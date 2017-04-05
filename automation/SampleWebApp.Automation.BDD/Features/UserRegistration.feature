@Chrome
Feature: User Registration
	In order to be able to access the website
	As an unregistered user
	I want to register to the website

	
	Scenario: Unregistered user should see a link to signup
		Given a user is an unregistered user
		When the user goes to the website
		Then the user should see a link to signup

	
	Scenario: Unregistered user should be able to access to a registration form
		Given a user is an unregistered user
		And the user goes to the website
		When the user clicks on a registration link
		Then the user should see a form allowing them to sign up to the website	

	
	Scenario Outline: Unregistered user should be able to sign up with valid credentials
		Given an unregistered user is on the registration form
		When the user fills out the form with a valid '<Username>' and '<Password>'
		And the user further confirms with the entered password
		Then the user is signed up and taken to the landing page
		
		Examples:
		| Example Description                     | Username                                                                       | Password               |
		| Valid username and password, static     | "someone@planetinnovation.com.au"                                              | "Password123"          |
		| Valid username and password, regex      | ^[A-Za-z0-9]{1,60}@[A-Za-z0-9]{5,10}\.[A-Za-z]{2,4}$                           | ^[A-Za-z0-9]{8,20}$    |
		| Valid username with minimum length (6)  | "M@J.ex"                                                                       | "n6k5q_68"             |
		| Valid username with maximum length (76) | "T_NEf7_7%pJ-M+28+J%P_DFgX7W2.Z87OXP7M_uUJ%P_746+Q_vcxfd+1_3n@V1BWIuU9DB.BNAV" | "_Zs4HpF8_4XF_71r"     |
		| Valid password with minimum length (8)  | "8_%@2QRI8Z8jT.XfS"                                                            | "OS_GF.20"             |
		| Valid password with maximum length (20) | "DI%3N3phj@0W7oB.eXgH"                                                         | "Up_D_4_8IlorYm.yh63Y" |