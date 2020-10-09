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