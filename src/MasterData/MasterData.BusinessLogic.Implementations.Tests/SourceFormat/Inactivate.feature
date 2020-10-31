Feature: Inactivating SourceFormat entities in the system

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