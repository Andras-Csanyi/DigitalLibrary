Feature: Source Format builder page default state

  Scenario: Displayed Controls
    Given I am on the Source Format page
    Then Source Format drop down list is displayed
    And Load Source Format button is displayed
    And New Source Format button is displayed
    And Cancel button is displayed
    And Save button is displayed

  Scenario: Displayed controls - Load Source Format button
    Given I am on the <Source Format> page
    Then <Load Source Format> button is <displayed>
    And <Load Source Format> button is <disabled>

  Scenario: Displayed Controls - Source Format dropdown list
    Given I am on the <Source Format> page
    Then <Source Format> <drop down list> is <displayed>
    And Source Format drop down list is active
    And Source Format drop down list first item is Select One

  Scenario: Displayed Controls - New Source Format button
    Given I am on the Source Format page
    Then New Source Format button is displayed
    And New Source Format button is inactive

  Scenario: Displayed Controls - Cancel button
    Given I am on the Source Format page
    Then Cancel button is inactive

  Scenario: Displayed Controls - Save button
    Given I am on the Source Format page
    Then Save button is inactive