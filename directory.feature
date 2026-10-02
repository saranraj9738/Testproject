Feature: Search the employee directory in the OrangeHRM

Scenario Outline: Fail to search the employee directory with not existent employee name  
    Given the user is on the OrangeHRM dashboard
    When the user click the Directory module
    And the user enters a not existent employee name<empname> 
    And the user click the search button
    Then the validation tag should display "Invalid" 


Examples:

    | empname | 
    | sanjay  |
