Feature: SourceFormat Business Logic - Inactivate a SourceFormat

  As a Data Owner and Data Curator
  I need to have the ability to inactivate SourceFormats in the system
  So that, I need a functionality covering this.

  Scenario: Inactivates a SourceFormat
    Given there is a saved SourceFormat domain object
      | Field     | Value     |
      | ResultKey | sf-result |
    And SourceFormat is inactivated
      | Field     | Value                 |
      | Key       | sf-result             |
      | ResultKey | sf-inactivated-result |
    When SourceFormat is queried by id
      | Field     | Value          |
      | Key       | sf-result      |
      | ResultKey | sf-result-byid |
    Then 'sf-result-byid' SourceFormat's 'IsActive' value is '0'

  Scenario: No error when the SourceFormat doesn't exist
    Given there is a saved SourceFormat domain object
      | Field     | Value     |
      | ResultKey | sf-result |
    And stored SourceFormat result Id is changed
      | Field     | Value         |
      | Key       | sf-result     |
      | ResultKey | sf-result-mod |
    When SourceFormat is inactivated
      | Field     | Value                 |
      | Key       | sf-result-mod         |
      | ResultKey | sf-inactivated-result |
    Then SourceFormat related operation doesn't show error
      | Field | Value                 |
      | Key   | sf-inactivated-result |
    