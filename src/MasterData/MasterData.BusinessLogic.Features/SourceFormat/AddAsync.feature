Feature: SourceFormat Business Logic - Adding SourceFormat

  As data structure owner and manager
  I need functionality
  Which provides me the ability to
  Build and Manage SourceFormats

  Scenario: Adds a SourceFormat without DimensionStructure
    Given there is a SourceFormat domain object
      | Field            | Value   |
      | Key              | SF1     |
      | NameProperty     | SF1     |
      | DescProperty     | SF1Desc |
      | IsActiveProperty | 1       |
    When SourceFormat is saved
      | Field     | Value     |
      | Key       | SF1       |
      | ResultKey | SF1Result |
    Then 'SF1Result' SourceFormat save result is not null
    And 'SF1Result' SourceFormat save result Id is not '0'
    And SourceFormat result property equals to
      | Field        | Value     |
      | Key          | SF1Result |
      | PropertyName | Name      |
      | EqualsTo     | SF1       |
    And SourceFormat result property equals to
      | Field        | Value     |
      | Key          | SF1Result |
      | PropertyName | Desc      |
      | EqualsTo     | SF1       |
    And SourceFormat result property equals to
      | Field        | Value     |
      | Key          | SF1Result |
      | PropertyName | IsActive  |
      | EqualsTo     | SF1       |

  Scenario: Adds a SourceFormat with an existing root DimensionStructure
    Given there is a SourceFormat domain object
      | Field    | Value   |
      | Key      | SF1     |
      | Name     | SF1     |
      | Desc     | SF1Desc |
      | IsActive | 1       |
    And SourceFormat is saved
      | Field     | Value     |
      | Key       | SF1       |
      | ResultKey | SF1Result |
    And there is a DimensionStructure domain object
      | Field    | Value       |
      | Key      | SF1Root     |
      | Name     | SF1Root     |
      | Desc     | SF1RootDesc |
      | IsActive | 1           |
    And DimensionStructure is saved
      | Field     | Value         |
      | Key       | SF1Root       |
      | ResultKey | SF1RootResult |
    And DimensionStructure is added to SourceFormat as root dimensionstructure
      | Field                 | Value         |
      | SourceFormatKey       | SF1Result     |
      | DimensionStructureKey | SF1RootResult |
    When SourceFormat is requested with root DimensionStructure
      | Field     | Value             |
      | Key       | SF1Result         |
      | ResultKey | SF1ResultWithTree |
    Then 'SF1ResultWithTree' SourceFormat save result is not null
    And 'SF1ResultWithTree' SourceFormat save result Id is not '0'
    And SourceFormat result property equals to
      | Field        | Value             |
      | Key          | SF1ResultWithTree |
      | PropertyName | Name              |
      | EqualsTo     | SF1               |
    And SourceFormat result property equals to
      | Field        | Value             |
      | Key          | SF1ResultWithTree |
      | PropertyName | Desc              |
      | EqualsTo     | SF1               |
    And SourceFormat result property equals to
      | Field        | Value             |
      | Key          | SF1ResultWithTree |
      | PropertyName | IsActive          |
      | EqualsTo     | SF1               |
    And SourceFormat result's RootDimensionStructure property equals to
      | Field        | Value             |
      | Key          | SF1ResultWithTree |
      | PropertyName | Name              |
      | EqualsTo     | SF1Root           |
    And SourceFormat result's RootDimensionStructure property equals to
      | Field        | Value             |
      | Key          | SF1ResultWithTree |
      | PropertyName | Desc              |
      | EqualsTo     | SF1Root           |
    And SourceFormat result's RootDimensionStructure property equals to
      | Field        | Value             |
      | Key          | SF1ResultWithTree |
      | PropertyName | IsActive          |
      | EqualsTo     | SF1Root           |
    And 'SF1Result' SourceFormat result's RootDimensionStructure Id property is not zero
