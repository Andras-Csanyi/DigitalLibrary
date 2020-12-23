Feature: SourceFormatDimensionStructureNode REST Api - Add method

  As a Data Owner and Data Curator
  I need to be able to manage structures describing a document
  It includes CRUD operations of SourceFormatDimensionStructureNodes
  And these methods should be available via REST Api

  Scenario: Add a SourceFormatDimensionStructureNode

    Given there is a SourceFormatDimensionStructureNode domain object
      | Field     | Value |
      | ResultKey | sfdsn |

    When SourceFormatDimensionStructureNode is saved
      | Field     | Value        |
      | Key       | sfdsn        |
      | ResultKey | sfdsn-result |

    Then SourceFormatDimensionStructureNode id not equals to
      | Field       | Value        |
      | Key         | sfdsn-result |
      | NotEqualsTo | 0            |
    And SourceFormatDimensionStructureNode DimensionStructureNodeId nullable equals to
      | Field    | Value        |
      | Key      | sfdsn-result |
      | EqualsTo | null         |
    And SourceFormatDimensionStructureNode SourceFormatId nullable equals to
      | Field    | Value        |
      | Key      | sfdsn-result |
      | EqualsTo | null         |

#  Scenario: Add a SourceFormatDimensionStructureNode when only SourceFormat exists
#
#    Given there is a saved SourceFormat domain object
#      | Field     | Value |
#      | Name      | name  |
#      | Desc      | desc  |
#      | IsActive  | 1     |
#      | ResultKey | sf-1  |
#    And there is a SourceFormatDimensionStructureNode domain object
#      | Field           | Value |
#      | ResultKey       | sfdsn |
#      | SourceFormatKey | sf-1  |
#
#    When SourceFormatDimensionStructureNode is saved
#      | Field     | Value        |
#      | Key       | sfdsn        |
#      | ResultKey | sfdsn-result |
#
#    Then SourceFormatDimensionStructureNode id not equals to
#      | Field       | Value        |
#      | Key         | sfdsn-result |
#      | NotEqualsTo | 0            |
#    And SourceFormatDimensionStructureNode DimensionStructureNodeId nullable equals to
#      | Field    | Value        |
#      | Key      | sfdsn-result |
#      | EqualsTo | null         |
#    And SourceFormatDimensionStructureNode SourceFormatId is
#      | Field           | Value        |
#      | Key             | sfdsn-result |
#      | SourceFormatKey | sf-1         |
#
#  Scenario: Add a SourceFormatDimensionStructureNode when SourceFormat and DimensionStructureNode exist
#
#    Given there is a saved SourceFormat domain object
#      | Field     | Value |
#      | Name      | name  |
#      | Desc      | desc  |
#      | IsActive  | 1     |
#      | ResultKey | sf-1  |
#    And there is a saved DimensionStructureNode domain object
#      | Field     | Value |
#      | IsActive  | 1     |
#      | ResultKey | dsn-1 |
#    And there is a SourceFormatDimensionStructureNode domain object
#      | Field                     | Value |
#      | ResultKey                 | sfdsn |
#      | SourceFormatKey           | sf-1  |
#      | DimensionStructureNodeKey | dsn-1 |
#
#    When SourceFormatDimensionStructureNode is saved
#      | Field     | Value        |
#      | Key       | sfdsn        |
#      | ResultKey | sfdsn-result |
#
#    Then SourceFormatDimensionStructureNode id not equals to
#      | Field       | Value        |
#      | Key         | sfdsn-result |
#      | NotEqualsTo | 0            |
#    And SourceFormatDimensionStructureNode DimensionStructureNodeId is
#      | Field                     | Value        |
#      | Key                       | sfdsn-result |
#      | DimensionStructureNodeKey | dsn-1        |
#    And SourceFormatDimensionStructureNode SourceFormatId is
#      | Field           | Value        |
#      | Key             | sfdsn-result |
#      | SourceFormatKey | sf-1         |