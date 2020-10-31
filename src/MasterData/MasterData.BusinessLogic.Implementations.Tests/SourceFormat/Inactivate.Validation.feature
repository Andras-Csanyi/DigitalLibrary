Feature: Inactivating SourceFormat entities in the system input validation

  As a Data Owner and Data Curator
  I need to have the ability to inactivate SourceFormats in the system
  In order to keep the data in safe
  I need functionality which prevents wrongdoings
  So that, I need a functionality covering this.

  Scenario: When input is wrong it throws exception
    Given there is a saved SourceFormat domain object
      | Field     | Value     |
      | ResultKey | sf-result |
    And SourceFormat is inactivated
      | Field | Value     |
      | Key   | sf-result |
    When SourceFormat is queried by id
      | Field     | Value          |
      | Key       | sf-result      |
      | ResultKey | sf-result-byid |
    Then 'sf-result-byid' SourceFormat's 'IsActive' value is '0'