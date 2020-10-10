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
  
  
#  Scenario: Add DimensionStructure to the first level in the tree
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