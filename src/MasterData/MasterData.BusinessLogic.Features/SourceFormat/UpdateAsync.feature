Feature: SourceFormat Business Logic - Update a SourceFormat

  As a Data Owner and Data Curator
  In order to have the data structure fit for its purpose
  I need to be able to modify SourceFormats in the system
  So that I need a functionality covering this.

  Scenario Outline: Updating SourceFormat

    Given there is a SourceFormat domain object
      | Field    | Value |
      | Key      | sf    |
      | Name     | asd   |
      | Desc     | asd   |
      | IsActive | 1     |
    And SourceFormat is saved
      | Field     | Value     |
      | Key       | sf        |
      | ResultKey | sf-result |
    And stored SourceFormat result Name is changed
      | Field     | Value     |
      | Key       | sf-result |
      | ResultKey | sf-result |
      | Name      | <NewName> |
    And stored SourceFormat result Desc is changed
      | Field     | Value     |
      | Key       | sf-result |
      | ResultKey | sf-result |
      | Desc      | <NewDesc> |
    And stored SourceFormat result IsActive is changed
      | Field     | Value         |
      | Key       | sf-result     |
      | ResultKey | sf-result     |
      | IsActive  | <NewIsActive> |
    And given SourceFormat is updated
      | Field     | Value       |
      | Key       | sf-result   |
      | ResultKey | sf-result-2 |
    When SourceFormat is queried by id
      | Field     | Value          |
      | Key       | sf-result      |
      | ResultKey | sf-result-byid |
    Then 'sf-result-byid' SourceFormat's 'Name' value is '<NewName>'
    And 'sf-result-byid' SourceFormat's 'Desc' value is '<NewDesc>'
    And 'sf-result-byid' SourceFormat's 'IsActive' value is '<NewIsActive>'

    Examples:
      | NewName | NewDesc | NewIsActive |
      | qqqqqq  | asd     | 1           |
      | asd     | wwwwww  | 1           |
      | asd     | asd     | 0           |
      | aaaaaa  | ddddd   | 0           |