Feature: SourceFormat endpoint - Update method

  As a Data Owner and Data Curator
  I need to be able to modify data and data structure in the system
  So that, I modify functionality

  Scenario Outline: SourceFormat is updated

    Given there is a SourceFormat domain object
      | Field    | Value            |
      | Key      | orig             |
      | Name     | name-orig        |
      | Desc     | description-orig |
      | IsActive | 1                |
    And SourceFormat domain object is sent to SourceFormat endpoint
      | Field     | Value       |
      | Key       | orig        |
      | ResultKey | orig-result |
    And there is a SourceFormat domain object
      | Field    | Value         |
      | Key      | orig-modified |
      | Name     | <Name>        |
      | Desc     | <Description> |
      | IsActive | <IsActive>    |
    And stored SourceFormat domain object Id value is
      | Field         | Value         |
      | IdValueSource | orig-result   |
      | Key           | orig-modified |
      | ResultKey     | orig-modified |
    When modified SourceFormat domain object is sent to SourceFormat endpoint
      | Field     | Value                |
      | Key       | orig-modified        |
      | ResultKey | orig-modified-result |

    Then 'orig-modified-result' SourceFormat Name property is '<Name>'
    And 'orig-modified-result' SourceFormat Desc property is '<Description>'
    And 'orig-modified-result' SourceFormat IsActive property is '<IsActive>'

    Examples:
      | Name      | Description      | IsActive |
      | asd       | description-orig | 1        |
      | name-orig | asd              | 1        |
      | name-orig | description-orig | 0        |
      | asd       | asd              | 0        |