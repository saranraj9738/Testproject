Feature: OrangeHRM Login

Scenario: Successful login
    Given the user opens a OrangeHRM login page
    When the user enters a valid username and password
    Then the user navigates to the dashboard page

Scenario: Unsuccessful login
    Given the user opens a OrangeHRM login page
    When the user enters a invalid username and password
    Then the user should see the login validation message "Invalid credentials"

