Feature: Adding DimensionStructures

  As a data owner and data curator
  I have to be able to manage DimensionStructures
  and trees built from DimensionStructures so
  I need the capability to this

  Scenario: Add new DimensionStructure
    Given there is a DimensionStructure domain object
      | Field    | Value |
      | Key      | RD    |
      | Name     | RDd   |
      | Desc     | RDd   |
      | IsActive | 1     |
    And DimensionStructure is saved
      | Field     | Value    |
      | Key       | RD       |
      | ResultKey | RDResult |
    When DimensionStructure is requested
      | Field     | Value             |
      | Key       | RDResult          |
      | ResultKey | RDResultRequested |
    Then DimensionStructure property equals to
      | Field         | Value             |
      | Key           | RDResultRequested |
      | PropertyName  | Name              |
      | ComparedToKey | RD                |
    And DimensionStructure property equals to
      | Field         | Value             |
      | Key           | RDResultRequested |
      | PropertyName  | Desc              |
      | ComparedToKey | RD                |
    And DimensionStructure property equals to
      | Field         | Value             |
      | Key           | RDResultRequested |
      | PropertyName  | IsActive          |
      | ComparedToKey | RD                |
    And DimensionStructure property does not equal to
      | Field        | Value             |
      | Key          | RDResultRequested |
      | PropertyName | Id                |
      | NotEqualTo   | 0                 |


  Scenario: Add DimensionStructure to the first level in the tree
    Given there is a SourceFormat domain object
      | Field | Value |
      | Key   | SF    |
    And SourceFormat is saved
      | Field     | Value    |
      | Key       | SF       |
      | ResultKey | SFResult |
    And there is a DimensionStructure domain object
      | Field | Value |
      | Key   | DS    |
    And DimensionStructure is saved
      | Field     | Value    |
      | Key       | DS       |
      | ResultKey | DSResult |
    And DimensionStructure is added to SourceFormat as root dimensionstructure
      | Field                 | Value    |
      | SourceFormatKey       | SFResult |
      | DimensionStructureKey | DSResult |
    And there is a DimensionStructure domain object
      | Field | Value   |
      | Key   | DSChild |
    And DimensionStructure is saved
      | Field     | Value         |
      | Key       | DSChild       |
      | ResultKey | DSChildResult |
    And DimensionStructure is added to DimensionStructure as child in tree of SourceFormat
      | Field           | Value         |
      | ChildKey        | DSChildResult |
      | ParentKey       | DSResult      |
      | SourceFormatKey | SFResult      |
    When SourceFormat is requested with DimensionStructure tree
      | Field     | Value             |
      | Key       | SFResult          |
      | ResultKey | SFRequestedResult |
    Then 'SFRequestedResult' SourceFormat save result is not null
    And root DimensionStructure of 'SFRequestedResult' SourceFormat is not null
    And DimensionStructure tree contains given DimensionStructure
      | Field                          | Value             |
      | SourceFormatKey                | SFRequestedResult |
      | ContainedDimensionStructureKey | DSChildResult     |
    And given DimensionStructure is child of given DimensionStructure
      | Field           | Value             |
      | SourceFormatKey | SFRequestedResult |
      | ParentKey       | DSResult          |
      | ChildKey        | DSChildResult     |
#
#  Scenario: Add DimensionStructure to the first level as second node
#
#  Scenario: Add DimensionStructure to the first level as third node
#
#  Scenario: Add DimensionStructure to the second level
#
#  Scenario: Add DimensionStructure to the second level as second element
#
#  Scenario: Add DimensionStructure to the second level as third element