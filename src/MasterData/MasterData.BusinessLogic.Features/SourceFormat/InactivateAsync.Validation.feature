Feature: SourceFormat Business Logic - Inactivate a SourceFormat input validation

  As a Data Owner and Data Curator
  I need to have the ability to inactivate SourceFormats in the system
  In order to keep the data in safe
  I need functionality which prevents wrongdoings
  So that, I need a functionality covering this.

  Scenario: When input is wrong Inactivate operation throws exception
    Given there is a SourceFormat domain object
      | Field | Value         |
      | Key   | sf-inactivate |
    When SourceFormat is inactivated
      | Field     | Value                |
      | Key       | sf-inactivate        |
      | ResultKey | sf-inactivate-result |
    Then SourceFormat inactivate operation shows an error
      | Field | Value                |
      | Key   | sf-inactivate-result |
